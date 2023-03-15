using RestSharp;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace MonitorFMS
{
    public partial class MainFrm : Form
    {
        private string _RestUri = string.Empty;
        private string _APIKey = string.Empty;

        private string _EQP_ID = string.Empty;
        private string _TRAY_ID = string.Empty;

        private bool _isRunning = false;
        private bool _IsConnection = false;

        private int _timerInterval = 10;
        private int _currentCount = 0;

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

            string result_eqp = res_eqp.Content;

            viewEquipment(result_eqp);

            request = new RestRequest($"/fmsbiz/tray/{tray_id}", Method.Get);
            request.AddHeader("APIKey", _APIKey);

            RestResponse res_tray = await client.ExecuteAsync(request);

            string result_tray = res_tray.Content;

            viewTray(result_tray);

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


}
