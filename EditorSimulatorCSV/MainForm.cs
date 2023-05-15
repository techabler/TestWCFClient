using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorSimulatorCSV
{
    public partial class MainForm : Form
    {
        private ENCsvType currCsvType = ENCsvType.Simulator;
        
        private string _simulatorCsvFilePath = string.Empty;
        public MainForm()
        {
            InitializeComponent();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = @"D:\02.Project\02.FMS\03.Dev\Ford\AtemFMS_20230215_Collabo\AtemFMS_FORD_PILOT\AtemOPCUAServer\bin\Debug\Settings\";
            openFileDialog.Title = "Sinulator 설정 파일 불러오기";
            openFileDialog.FileName = "SIM_FOR.csv";
            openFileDialog.Filter = "CSV File (*.csv) | *.csv";

            DialogResult = openFileDialog.ShowDialog();

            if(DialogResult == DialogResult.OK)
            {
                string csvFileName = openFileDialog.FileName;
                _simulatorCsvFilePath = csvFileName;

                txtCsvPath.Text = csvFileName;

                Console.WriteLine(csvFileName);
            }

            dgrList.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_simulatorCsvFilePath)) return;
            LoadCsvToGrid();
        }

        /// <summary>
        /// 선택한 CSV 파일을 로드하여 DatagridView에 저장 
        /// </summary>
        private void LoadCsvToGrid()
        {
            DataTable dt = new DataTable();

            using (StreamReader sr = new StreamReader(_simulatorCsvFilePath))
            {
                int rowCount = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] data = line.Split(',');

                    if (rowCount == 0)   //첫행은 Column header로 사용
                    {
                        foreach (string s in data)
                        {
                            dt.Columns.Add(new DataColumn(s));
                        }
                    }
                    else
                    {
                        dt.Rows.Add(data);
                    }

                    rowCount++;

                    Console.WriteLine(line);
                }

            }

            if (dt.Rows.Count > 0)
            {
                dgrList.DataSource = dt;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_simulatorCsvFilePath)) return;
            if (dgrList.Rows.Count == 0) return;
            SaveGridToCsv();

        }


        /// <summary>
        /// DataGridView 내용을 CSV 파일에 저장
        /// </summary>
        private void SaveGridToCsv()
        {
            string delimitr = ",";
            bool isExistHeader = true;
            FileStream fs = new FileStream(_simulatorCsvFilePath, FileMode.Create, FileAccess.Write);
            StreamWriter csvExport = new StreamWriter(fs, Encoding.ASCII);


            if (isExistHeader)
            {
                for (int i = 0; i < dgrList.Columns.Count; i++)
                {
                    csvExport.Write(dgrList.Columns[i].HeaderText);
                    if (i != dgrList.Columns.Count - 1)
                    {
                        csvExport.Write(delimitr);
                    }
                }
            }

            csvExport.Write(csvExport.NewLine);

            foreach (DataGridViewRow row in dgrList.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < dgrList.Columns.Count; i++)
                    {
                        csvExport.Write(row.Cells[i].Value);
                        if (i != dgrList.Columns.Count - 1)
                        {
                            csvExport.Write(delimitr);
                        }
                    }
                    csvExport.Write(csvExport.NewLine);
                }
            }

            csvExport.Flush();
            csvExport.Close();
            fs.Close();

            MessageBox.Show("Saved!");
        }

        private void simulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currCsvType = ENCsvType.Simulator;

            Console.WriteLine(currCsvType.GetDescription());
            lbCsvType.Text = currCsvType.GetDescription();
        }

        private void equipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currCsvType = ENCsvType.Equipment;
            Console.WriteLine(currCsvType.GetDescription());
            lbCsvType.Text = currCsvType.GetDescription();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dgrList.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }

        private void PasteClipboard()
        {
            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int iFail = 0;
                int iRow = dgrList.CurrentCell.RowIndex;
                int iCol = dgrList.CurrentCell.ColumnIndex;

                DataGridViewCell oCell;

                foreach (string line in lines)
                {
                    if (iRow < dgrList.RowCount && line.Length > 0)
                    {
                        string[] sCells = line.Split(',');
                        for (int i = 0; i < sCells.GetLength(0); ++i)
                        {
                            if (iCol + i < this.dgrList.ColumnCount)
                            {
                                oCell = dgrList[iCol + i, iRow];
                                if (!oCell.ReadOnly)
                                {
                                    if (oCell.Value.ToString() != sCells[i])
                                    {
                                        oCell.Value = Convert.ChangeType(sCells[i], oCell.ValueType);
                                        oCell.Style.BackColor = Color.Tomato;
                                    }
                                    else
                                    {
                                        iFail++;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        iRow++;
                    }
                    else
                    {
                        break;
                    }
                    if (iFail > 0)
                    {
                        MessageBox.Show(string.Format("{0} updates failed due to read only column setting", iFail));
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }

            

        }

        private void dgrList_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.Control && e.KeyCode == Keys.Insert) || (e.Shift && e.KeyCode == Keys.Insert))
            {
                PasteClipboard();
            }
        }
    }

    //Enum 확장 method
    public static class GeneralEnum
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var meminfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAtt = meminfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAtt != null)
                        {
                            return descriptionAtt.Description;
                        }
                    }
                }

                return null;
            }

            return e.ToString();
        }
    }

    enum ENCsvType
    {
        [Description("Simulator CSV")]
        Simulator = 0,
        [Description("Equipment CSV")]
        Equipment = 1
    }
}
