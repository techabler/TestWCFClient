using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorEquipmentList
{
    public partial class MainForm : Form
    {
        private string _csvFilePath = string.Empty;
        private DataTable _table;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;

            openFileDialog1.FileName = "";

            openFileDialog1.Filter = "csv(*.csv)|*.csv";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _csvFilePath = openFileDialog1.FileName;

                setEqpList(_csvFilePath);
                Console.Write(_csvFilePath);
            }
        }

        private bool setEqpList(string csvFilePath)
        {
            string[] columns = { "EqpType", "ApplicationName", "OPCServerAddress", "UserID", "UserPW", "EqpID", "OPCTemplateFile", "UseYesNo", "CSV_WhiteListForBrowsing", "Note" };

            _table = new DataTable();
            foreach(string column in columns)
            {
                _table.Columns.Add(column);
            }

            try
            {
                using (StreamReader sr = new StreamReader(csvFilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] data = line.Split(',');

                        if (data.Contains("EqpType"))
                            continue;

                        _table.Rows.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            

            dataGridView1.DataSource = _table;

            return false;
        }

        private bool saveCsv()
        {
            FileStream fs = new FileStream(_csvFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.ASCII);

            string line = string.Join(",", _table.Columns.Cast<object>());
            sw.WriteLine(line);

            foreach(DataRow item in _table.Rows)
            {
                line = string.Join(",", item.ItemArray.Cast<object>());
                sw.WriteLine(line);
            }

            sw.Close();
            fs.Close();

            return false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveCsv())
            {
                MessageBox.Show("Saved!");
            }
        }
    }
}
