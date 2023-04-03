using RestSharp;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MonitorFMS
{
    public partial class MainFrm : Form
    {
        // 클래스 내부에 
        [DllImport("user32")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        private string _RestUri = string.Empty;
        private string _APIKey = string.Empty;

        private string _EQP_ID = string.Empty;
        private string _TRAY_ID = string.Empty;

        private bool _isRunning = false;
        private bool _IsConnection = false;

        private int _timerInterval = 10;
        private int _currentCount = 0;


        #region [Tools - 선언]
        List<MyProcess> processList;
        #endregion

        private Timer _Timer;
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            _RestUri = "http://localhost:48091";
            _APIKey = "MPwjAXk0KkGPNLOykR5ZGQ==";

            _timerInterval = txtSec.Text.Length > 0 ? Convert.ToInt32(txtSec.Text) : 10;

            _Timer = new Timer();
            _Timer.Interval = 1000;
            _Timer.Tick += _Timer_Tick;


            processList = new List<MyProcess>();
            processList.Add(new MyProcess() { enumName= "OP_UI", pName="AtemFMSOpUI", pPath= @"D:\07.Dev\99.FormationTool\OPUI\", pFullPath= @"D:\07.Dev\99.FormationTool\OPUI\AtemFMSOpUI.exe" , pType="EXE"});
            processList.Add(new MyProcess() { enumName = "ReWork_UI", pName = "AtemFMSOpStationUI", pPath = @"D:\07.Dev\99.FormationTool\OPReworkUI\", pFullPath = @"D:\07.Dev\99.FormationTool\OPReworkUI\AtemFMSOpStationUI.exe", pType = "EXE" });
            processList.Add(new MyProcess() { enumName = "Sequence_Editor", pName = "MCFSequenceDesignerUI", pPath = @"D:\07.Dev\99.FormationTool\SequenceEditor\", pFullPath = @"D:\07.Dev\99.FormationTool\SequenceEditor\AtemMCFUI.exe", pType = "EXE" });
            processList.Add(new MyProcess() { enumName = "MCSimulator", pName = "Run_batch", pPath = @"D:\07.Dev\99.FormationTool\MCSimulator\", pFullPath = @"D:\07.Dev\99.FormationTool\MCSimulator\_RUN_bat", pType = "BAT" });
            processList.Add(new MyProcess() { enumName = "CSV_Editor", pName = "EditorSimulatorCSV", pPath = @"D:\07.Dev\99.FormationTool\CSVEditor\", pFullPath = @"D:\07.Dev\99.FormationTool\CSVEditor\EditorSimulatorCSV.exe", pType = "EXE" });

        }

        private void _Timer_Tick(object sender, EventArgs e)
        {
            if (getCheckRest())
            {
                if(_currentCount % _timerInterval == 0)
                {
                    _currentCount = _timerInterval;
                    getStatus(_EQP_ID, _TRAY_ID);
                }
                txtCount.Text = _currentCount.ToString();
                _currentCount--;
                
            }
            else
            {
                changeTimer(false);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _RestUri = txtURL.Text.Length > 0 ? txtURL.Text : "http://localhost:48091";

            _timerInterval = txtSec.Text.Length > 0 ? Convert.ToInt32(txtSec.Text) : 10;
            _currentCount = _timerInterval;

            changeTimer(true);
            //string eqp_result = await getEquipmentStatus(eqp_id);
            //getStatus(eqp_id, tray_id);
        }

        private bool getCheckRest()
        {
            _EQP_ID = txtEqpId.Text ?? "";
            _TRAY_ID = txtTrayId.Text ?? "";

            if (string.IsNullOrEmpty(_EQP_ID))
            {
                MessageBox.Show("Enter the Equipment ID "); return false;
            }

            if (string.IsNullOrEmpty(_TRAY_ID))
            {
                MessageBox.Show("Enter the Tray ID "); return false;
            }

            return true;
        }

        private void changeTimer(bool isStart)
        {
            if(isStart)
            {
                _Timer.Start();
                _isRunning = true;
                btnSearch.Enabled = false;
                btnStop.Enabled = true;
            }
            else
            {
                _Timer.Stop();
                _isRunning = false;
                btnSearch.Enabled = true;
                btnStop.Enabled = false;
            }
        }


        private async void getStatus(string eqp_id, string tray_id)
        {
            txtCount.BackColor = System.Drawing.SystemColors.MenuHighlight;

            var options = new RestClientOptions(_RestUri)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest($"/fmsbiz/eqp/{eqp_id}", Method.Get);

            request.AddHeader("APIKey", _APIKey);
            RestResponse res_eqp = await client.ExecuteAsync(request);

            if(res_eqp.ResponseStatus == ResponseStatus.Completed)
            {
                viewEquipment(res_eqp.Content);
            }
            else
            {
                MessageBox.Show("Not connected to RestAPI");
                changeTimer(false);
                return;
            }

            request = new RestRequest($"/fmsbiz/tray/{tray_id}", Method.Get);
            request.AddHeader("APIKey", _APIKey);

            RestResponse res_tray = await client.ExecuteAsync(request);
            if(res_tray.ResponseStatus == ResponseStatus.Completed)
            {
                viewTray(res_tray.Content);
            }

            txtCount.BackColor = System.Drawing.SystemColors.ButtonFace;
        }

        private bool viewEquipment(string EQUIPMENT)
        {
            RESLUT_EQP json = JsonConvert.DeserializeObject<RESLUT_EQP>(EQUIPMENT);

            dgEqp.Rows.Clear();

            dgEqp.Rows.Add("eqp_type", json.data.eqp_type);
            dgEqp.Rows.Add("eqp_id", json.data.eqp_id);
            dgEqp.Rows.Add("tray_id", json.data.tray_id);
            dgEqp.Rows.Add("fms_use", json.data.fms_use);
            dgEqp.Rows.Add("op_mode", json.data.op_mode);
            dgEqp.Rows.Add("op_proc", json.data.op_proc);
            dgEqp.Rows.Add("op_maint", json.data.op_maint);
            dgEqp.Rows.Add("job_start_time", json.data.job_start_time);
            dgEqp.Rows.Add("job_end_time", json.data.job_end_time);
            dgEqp.Rows.Add("fire_flag", json.data.fire_flag);

            return true;
        }

        private bool viewTray(string TRAY)
        {
            RESLUT_TRAY json = JsonConvert.DeserializeObject<RESLUT_TRAY>(TRAY);

            dgTray.Rows.Clear();

            dgTray.Rows.Add("tray_id", json.data.tray_id);
            dgTray.Rows.Add("model_id", json.data.model_id);
            dgTray.Rows.Add("route_id", json.data.route_id);
            dgTray.Rows.Add("lot_id", json.data.lot_id);
            dgTray.Rows.Add("work_order_id", json.data.work_order_id);
            dgTray.Rows.Add("full_flag", json.data.full_flag);
            dgTray.Rows.Add("eqp_type", json.data.eqp_type);
            dgTray.Rows.Add("oper_type", json.data.oper_type);
            dgTray.Rows.Add("oper_no", json.data.oper_no);
            dgTray.Rows.Add("next_eqp_type", json.data.next_eqp_type);
            dgTray.Rows.Add("next_oper_type", json.data.next_oper_type);
            dgTray.Rows.Add("job_start_time", json.data.job_start_time);
            dgTray.Rows.Add("job_end_time", json.data.job_end_time);
            dgTray.Rows.Add("oper_in_cells_csv", json.data.oper_in_cells_csv);
            dgTray.Rows.Add("current_cells_csv", json.data.current_cells_csv);

            return true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            changeTimer(false);
        }



        #region [Tool-Execute Process]

        enum EM_Process
        {
            OP_UI,
            ReWork_UI,
            Sequence_Editor,
            MCSimulator,
            CSV_Editor,
        }

        private void callProcess(MyProcess myProcess)
        {
            string exe_name = string.Empty;

            // Process.GetProcess(): 실행중인 프로세스 배열 반환
            foreach (Process process in Process.GetProcesses())
            {
                // "exe_name"라는 이름을 가진 프로세스가 존재하면 true를 리턴한다.
                if (process.ProcessName.StartsWith(myProcess.pPath))
                {
                    // 프로세스를 윈도우 화면 최상단에 배치
                    SetForegroundWindow(process.MainWindowHandle);
                    // 프로세스를 죽이는 함수
                    process.Kill();
                }
            }

            // 실행파일 경로와 이름
            exe_name = myProcess.pFullPath;

            // 실행파일 실행
            Process.Start(exe_name);
        }

        private void callBatchProcess(string path) 
        {
            ProcessStartInfo psInfo = new ProcessStartInfo();
            psInfo.FileName = "cmd.exe";

            psInfo.CreateNoWindow = true;
            psInfo.UseShellExecute = false;
            psInfo.RedirectStandardInput = true;
            psInfo.RedirectStandardOutput = true;
            psInfo.RedirectStandardError = true;

            var process = new Process();
            process.StartInfo = psInfo;
            process.Start();

            process.StandardInput.Write(path + Environment.NewLine);
            process.StandardInput.Close();

            //psInfo.Arguments = $"/C {path}";

            //Process.Start(psInfo);

            
        }
        

        private void executeProcess(EM_Process myProcess, bool isFolderOpen)
        {
            string exe_name = string.Empty;
            var targetProcess = new MyProcess();

            foreach(var prc in processList)
            {
                if(prc.enumName == myProcess.ToString())
                {
                    targetProcess = prc;
                }
            }

            if(!isFolderOpen)
            {
                if (targetProcess.pType.Equals("EXE"))
                {
                    callProcess(targetProcess);
                }
                else if(targetProcess.pType.Equals("BAT"))
                {
                    callBatchProcess(targetProcess.pFullPath);
                }
                
            }
            else
            {
                exe_name= targetProcess.pPath;

                // 실행파일 실행
                Process.Start(exe_name);
            }

            
            
        }

        #endregion

        #region [Button Event]
        private void oPUIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            executeProcess(EM_Process.OP_UI, false);
        }

        private void reworkUIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            executeProcess(EM_Process.ReWork_UI, false);
        }

        private void sequenceEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            executeProcess(EM_Process.Sequence_Editor, false);
        }
        private void mCSimulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            executeProcess(EM_Process.MCSimulator, false);
        }

        private void oPUIToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            executeProcess(EM_Process.OP_UI, true);
        }

        private void reworkUIToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            executeProcess(EM_Process.ReWork_UI, true);
        }

        private void sequenceEditorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            executeProcess(EM_Process.Sequence_Editor, true);
        }

        private void mCSimulatorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            executeProcess(EM_Process.MCSimulator, true);
        }



        #endregion


        private void editorSimulatorToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            executeProcess(EM_Process.CSV_Editor, false);
        }

        private void editorSimulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            executeProcess(EM_Process.CSV_Editor, true);
        }
    }

    public class RESLUT_EQP
    {
        public int count { get; set; }
        public string table { get; set; }
        public TB_EQP data { get; set; }
    }

    public class TB_EQP
    {
        public string eqp_type { get; set; }
        public string eqp_id { get; set; }
        public string tray_id { get; set; }
        public string fms_use { get; set; }
        public string op_mode { get; set; }
        public string op_proc { get; set; }
        public string op_maint { get; set; }
        public string job_start_time { get; set; }
        public string job_end_time { get; set; }
        public string fire_flag { get; set; }
    }

    public class RESLUT_TRAY
    {
        public int count { get; set; }
        public string table { get; set; }
        public TB_TRAY data { get; set; }
    }

    public class TB_TRAY 
    {
        public string tray_id { get; set; }
        public string model_id { get; set; }
        public string route_id { get; set; }
        public string lot_id { get; set; }
        public string work_order_id { get; set; }
        public string full_flag { get; set; }
        public string eqp_type { get; set; }
        public string oper_type { get; set; }
        public string oper_no { get; set; }

        public string next_eqp_type { get; set; }

        public string next_oper_type { get; set; }

        public string job_start_time { get; set; }
        public string job_end_time { get; set; }

        public string oper_in_cells_csv { get; set; }

        public string current_cells_csv { get; set; }
    }


    public class MyProcess
    {
        public string enumName { get; set; }
        public string pName { get; set; }
        public string pPath { get; set; }
        public string pFullPath { get; set; }
        public string pType { get; set; } = string.Empty;
    }


}
