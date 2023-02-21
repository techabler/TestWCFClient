using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWCFClient
{
    public class CMethod
    {
        public string method_id { get; set; }   
        public string eqp_type { get; set; }
        public string method_path { get; set; }
        public int method_output_count { get; set; }
        public string method_arg_info { get; set; }
    }

    public class MakeMethodList
    {
        public Dictionary<string, List<CMethod>> _list;
        public MakeMethodList()
        {
            _list = new Dictionary<string, List<CMethod>>();

            _list.Add(EM_Equipment.FOR.ToString(), getFOR());
            _list.Add(EM_Equipment.MIP.ToString(), getMIP());

        }

        public List<CMethod> getMIP()
        {
            List<CMethod> list = new List<CMethod>();

            list.Add(new CMethod
            {
                eqp_type = EM_Equipment.MIP.ToString(),
                method_id = "MachineControl",
                method_path = ".MachineInfo.MachineControl",
                method_output_count = 1,
                method_arg_info = "R:Restart, X:Test End"
            });

            list.Add(new CMethod
            {
                eqp_type = EM_Equipment.MIP.ToString(),
                method_id = "ModeChange",
                method_path = ".MachineInfo.ModeChange",
                method_output_count = 1,
                method_arg_info = "0:Control, 1:Manual"
            });

            return list;

        }

        public List<CMethod> getFOR()
        {
            List<CMethod> list = new List<CMethod>();
            list.Add(new CMethod
            {
                eqp_type = EM_Equipment.FOR.ToString(),
                method_id = "MachineControl",
                method_path = ".MachineInfo.MachineControl",
                method_output_count = 1,
                method_arg_info = "E:End Curren, P:Pause, C:Continue, R:Restart, X:Test End"
            });

            list.Add(new CMethod
            {
                eqp_type = EM_Equipment.FOR.ToString(),
                method_id = "ModeChange",
                method_path = ".MachineInfo.ModeChange",
                method_output_count = 1,
                method_arg_info = "0:Control, 1:Manual, 2:Auto-Cal"
            });

            list.Add(new CMethod
            {
                eqp_type = EM_Equipment.FOR.ToString(),
                method_id = "HostTrouble",
                method_path = ".Host.HostTrouble",
                method_output_count = 0,
                method_arg_info = "9999: Error No"
            });

            list.Add(new CMethod
            {
                eqp_type = EM_Equipment.FOR.ToString(),
                method_id = "TrayInputAvailable",
                method_path = ".MachineInfo.TrayInputAvailable",
                method_output_count = 1,
                method_arg_info = "R:Request Input Availability"
            });

            list.Add(new CMethod
            {
                eqp_type = EM_Equipment.FOR.ToString(),
                method_id = "StackerCraneFork",
                method_path = ".MachineInfo.StackerCraneFork",
                method_output_count = 0,
                method_arg_info = "0:Forking, 1:Not Forking"
            });

            return list;
        }


    }


    public enum EM_Equipment
    {
        FOR,
        IRO,
        DCR,
        PPC,
        DGS,
        PRE,
        MIC,
        MIP,
        SEL,
        RGV
    }


}
