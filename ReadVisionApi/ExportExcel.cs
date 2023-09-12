using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace ReadVisionApi
{
    public class ExportExcel
    {
        private DataGridView dgvGrid;
        private bool canUseGrid = false;
        public ExportExcel(DataGridView dgv) { 
            dgvGrid = null;

            if(dgv != null)
            {
                dgvGrid = dgv;
                canUseGrid = true;
            }
        }

        public MSG Export()
        {
            MSG result = new MSG()
            {
                MSG_RESULT = false,
                MSG_MESSAGE = "",
            };

            if(canUseGrid) 
            {
                //DataGrid Data 체크
                if(dgvGrid.Rows.Count == 0)
                {
                    result.MSG_MESSAGE = "Export Data is nothing!";
                }
                else
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook workbook = excel.Workbooks.Add(Type.Missing);
                    Worksheet sheet = null;
                    sheet = workbook.ActiveSheet;

                    int cellRowIndex = 1;

                    //Set Header
                    //for(int col = 0; col < dgvGrid.Columns.Count; col++) 
                    //{ 
                    //    if(cellRowIndex == 1)
                    //    {
                    //        sheet.Cells[cellRowIndex, col++] = dgvGrid.Columns[col].HeaderText;
                    //    }
                    //}

                    sheet.Cells[1, 1] = "Pay Price";
                    sheet.Cells[1, 2] = "EMPTY";
                    sheet.Cells[1, 3] = "Pay Description";
                    sheet.Cells[1, 4] = "Org Date";


                    for (int row = 0; row < dgvGrid.Rows.Count; row++)
                    {
                        //for (int col = 0; col < dgvGrid.Columns.Count - 1; col++)
                        //{
                        //    sheet.Cells[(row + 2), (col + 1)] = dgvGrid.Rows[row].Cells[col].Value;
                        //}
                        // ERP Format에 맞게 수정 : 통화구분자 삭제 
                        string tmpPrice = dgvGrid.Rows[row].Cells[1].Value.ToString();   // Price
                        sheet.Cells[(row + 2), 1] = tmpPrice.Replace(",", "");
                        sheet.Cells[(row + 2), 2] = string.Empty;
                        // ERP Format에 맞게 수정 : 날짜 표현
                        string tmpDate = dgvGrid.Rows[row].Cells[0].Value.ToString();   // Date
                        string getDate = "00.00";
                        string strAMPM = "[None]";

                        try
                        {
                            DateTime date = DateTime.Parse(tmpDate);
                            getDate = date.ToString("M.d");
                            int getTime = Int32.Parse(date.ToString("HH"));
                            strAMPM = "점심";
                            if (getTime > 18) strAMPM = "저녁";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        sheet.Cells[(row + 2), 3] = $"{getDate} 서울사무소 {strAMPM} 식대";
                        sheet.Cells[(row + 2), 4] = tmpDate;
                    }

                    try
                    {

                        SaveFileDialog saveFileDialog = GetExcelOptions();
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(saveFileDialog.FileName);
                            result.MSG_MESSAGE = "Export is done";
                            result.MSG_RESULT = true;
                        }
                        else
                        {
                            result.MSG_MESSAGE = "Export is canceled";
                        }

                        workbook.Close(true);
                        excel.Quit();

                    }
                    catch (Exception ex)
                    {
                        result.MSG_MESSAGE = ex.Message;
                    }
                    finally
                    {
                        GC.Collect();
                    }
                }
               
            }

            return result;
        }

        private SaveFileDialog GetExcelOptions()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.AddExtension = true;
            saveFileDialog.ValidateNames = true;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            saveFileDialog.DefaultExt = ".xlsx";
            saveFileDialog.Filter = "Microsoft Excel Workbook (*.xlsx)|*.xlsx";
            ///saveFileDialog.FileName = "";

            return saveFileDialog;
        }
    }

    public class MSG
    {
        public bool MSG_RESULT { get; set; }
        public string MSG_MESSAGE { get; set; }
    }
}
