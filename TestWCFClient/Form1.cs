using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWCFClient
{
    public partial class MainForm : Form
    {
        Dictionary<string, List<MethodInfo>> eqpList = new Dictionary<string, List<MethodInfo>>();
        

        public MainForm()
        {
            InitializeComponent();
        }

        private IAtemFMSCmdService GetChannel()
        {
            IAtemFMSCmdService channel = null;

            try
            {
                ChannelFactory<IAtemFMSCmdService> factory = new ChannelFactory<IAtemFMSCmdService>();

                // Address
                //string address = "http://localhost:48010/atemfmscmd";
                string address = txtURL.Text.Trim();
                factory.Endpoint.Address = new EndpointAddress(address);

                // Binding : TCP 사용
                //factory.Endpoint.Binding = new NetTcpBinding();
                factory.Endpoint.Behaviors.Add(new WebHttpBehavior());

                WebHttpBinding webHttpBinding = new WebHttpBinding();
                factory.Endpoint.Binding = webHttpBinding;
                factory.Endpoint.Binding.OpenTimeout = new TimeSpan(0, 0, 10);
                factory.Endpoint.Binding.CloseTimeout = new TimeSpan(0, 0, 10);
                factory.Endpoint.Binding.ReceiveTimeout = new TimeSpan(0, 0, 10);
                factory.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 60);


                // Contract 설정
                factory.Endpoint.Contract.ContractType = typeof(IAtemFMSCmdService);

                // Channel Factory 만들기
                channel = factory.CreateChannel();

                btnAlert.BackColor = Color.ForestGreen;
            }
            catch (Exception ex)
            {
                btnAlert.BackColor = Color.Tomato;
                lstLog.Items.Add($"WCF Connecion is fail : {ex.Message}");
            }
            return channel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Channel Factory 만들기
            IAtemFMSCmdService channel = GetChannel();

            if(channel == null)
            {
                btnAlert.Text = "NO";return;
            }

            lstLog.Items.Add("Write TAG Start");
            lstLog.Items.Add($"{txtWriteEqpId.Text.Trim()} | {txtWriteTagPath.Text.Trim()} | {txtWriteValue.Text.Trim()}");

            try
            {
                bool result = channel.WriteTag(txtWriteEqpId.Text.Trim(), txtWriteTagPath.Text.Trim(), txtWriteValue.Text.Trim());
                lstLog.Items.Add($"Write TAG Result : {result}");
                if(!result) btnAlert.BackColor = Color.Tomato;
            }
            catch (Exception ex)
            {
                btnAlert.BackColor = Color.Tomato;
                lstLog.Items.Add($"Exception Error:{ex.Message}");
            }

            ((ICommunicationObject)channel).Close();
        }

        private void btnCallMethod_Click(object sender, EventArgs e)
        {
            // Channel Factory 만들기
            IAtemFMSCmdService channel = GetChannel();

            if (channel == null)
            {
                btnAlert.Text = "NO"; return;
            }

            string[] in_arg = txtCallInputArg.Text.Split(',');
            int outputCount = Convert.ToInt32(txtCallOutputCount.Text.Trim());

            lstLog.Items.Add("Call Method Start");
            lstLog.Items.Add($"{txtCallEqpID.Text.Trim()} | {txtCallParentPath.Text.Trim()} | {txtCallMethodPath.Text.Trim()} | {txtCallInputArg.Text} | {txtCallOutputCount.Text.Trim()}");

            try
            {
                var rtn = channel.CallMethod(txtCallEqpID.Text.Trim(), txtCallParentPath.Text.Trim(), txtCallMethodPath.Text.Trim(), in_arg, outputCount);
                lstLog.Items.Add($"Call Method Result는 서버로그로 확인");
            }
            catch (Exception ex)
            {
                btnAlert.BackColor = Color.Tomato;
                lstLog.Items.Add($"Exception Error:{ex.Message}");
            }

            ((ICommunicationObject)channel).Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //btnAlert.BackColor = Color.DarkRed;
            if (loadMethodList())
            {
                List<string> eqps =  eqpList.Keys.ToList<string>();

                cboEquipment.Items.Clear();
                cboEquipment.DataSource = eqps;
            }
            
        }

        private bool loadMethodList()
        {
            bool result = false;
            List<MethodInfo> list = new List<MethodInfo>();

            eqpList.Add("Select", null);

            list.Add(new MethodInfo
            {
                eqpId = "F01MIP01100101",
                method_id = "MachineControl",
                method_path = "F01MIP01100101.MachineInfo.MachineControl",
                method_parent_path = "F01MIP01100101.MachineInfo",
                parent_arg_info = "R:Restart, X:Test End",
                method_output_count = 1
            });

            list.Add(new MethodInfo
            {
                eqpId = "F01MIP01100101",
                method_id = "ModeChange",
                method_path = "F01MIP01100101.MachineInfo.ModeChange",
                method_parent_path = "F01MIP01100101.MachineInfo",
                parent_arg_info = "0:Control, 1:Manual",
                method_output_count = 1
            });

            eqpList.Add("F01MIP01100101", list);

            list = new List<MethodInfo>();
            list.Add(new MethodInfo
            {
                eqpId = "F01PRE01100101",
                method_id = "MachineControl",
                method_path = "F01PRE01100101.MachineInfo.MachineControl",
                method_parent_path = "F01PRE01100101.MachineInfo",
                parent_arg_info = "E:End Curren, P:Pause, C:Continue, R:Restart, X:Test End",
                method_output_count = 1
            });

            list.Add(new MethodInfo
            {
                eqpId = "F01PRE01100101",
                method_id = "ModeChange",
                method_path = "F01PRE01100101.MachineInfo.ModeChange",
                method_parent_path = "F01PRE01100101.MachineInfo",
                parent_arg_info = "0:Control, 1:Manual",
                method_output_count = 1
            });

            eqpList.Add("F01PRE01100101", list);


            result = true;

            return result;
        }

        private void cboEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEqpName = cboEquipment.Items[cboEquipment.SelectedIndex].ToString();
            if (!selectedEqpName.Equals("Select"))
            {
                cboMethodList.Items.Clear();
                List<MethodInfo> list = eqpList.FirstOrDefault(item => item.Key == selectedEqpName).Value;
                foreach(var item in list)
                {
                    cboMethodList.Items.Add(item.method_id);
                }
            }
        }

        private void cboMethodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEqpName = cboEquipment.Items[cboEquipment.SelectedIndex].ToString();
            string selectedMethodId = cboMethodList.Items[cboMethodList.SelectedIndex].ToString();

            List<MethodInfo> list = eqpList.FirstOrDefault(item => item.Key == selectedEqpName).Value;
            MethodInfo method = list.FirstOrDefault(x => x.method_id.Equals(selectedMethodId));

            txtCallMethodPath.Text = method.method_path;
            txtCallEqpID.Text = selectedEqpName;
            txtCallParentPath.Text = method.method_parent_path;
            txtCallOutputCount.Text = method.method_output_count.ToString();
            txtInputArgInfo.Text = method.parent_arg_info;
        }
    }

    [ServiceContract]
    public interface IAtemFMSCmdService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ReadTag", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        object ReadTag(string eqp_id, string node_path_from_eqp_id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ReadTags", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        Dictionary<string, object> ReadTags(string eqp_id, List<string> list_of_node_path_from_eqp_id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "WriteTag", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool WriteTag(string eqp_id, string node_path_from_eqp_id, object value);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "WriteTags", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool WriteTags(string eqp_id, Dictionary<string, object> tags);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CallMethod", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        object[] CallMethod(string eqp_id, string parent_path_from_eqp_id, string method_path_from_eqp_id, object[] in_args, int out_args_count);
    }

    public class MethodInfo
    {
        public string eqpId { get; set; }
        public string method_id { get; set; }   
        public string method_path { get; set; }
        public string method_parent_path { get; set; }
        public int method_output_count { get; set; }
        public string parent_path_from_eqp_id { get; set; }
        public string parent_arg_info{ get; set; }

    }

}
