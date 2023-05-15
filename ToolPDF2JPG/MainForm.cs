using Acrobat;
using Aspose.Pdf;
using Aspose.Pdf.Devices;
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

namespace ToolPDF2JPG
{

    /// <summary>
    /// Ref : https://blog.conholdate.com/ko/total/convert-pdf-to-images-using-csharp/
    ///       https://products.aspose.com/words/ko/net/conversion/pdf-to-jpg/
    /// </summary>
    public partial class MainForm : Form
    {
        private string filePath = string.Empty;
        private string fileName = string.Empty;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "PDF Open";

            DialogResult dr = openFileDialog1.ShowDialog();

            if(dr == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
                fileName = openFileDialog1.SafeFileName;
                filePath = openFileDialog1.FileName.Replace(fileName, "");
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            //var doc = new Aspose.Words.Document(txtFilePath.Text);

            //for(int page = 0; page< doc.Count; page++)
            //{
            //    var extractedPage = doc.ExtractPages(page, 1);
            //    extractedPage.Save($"sample.{page}.jpg");
            //}

            // REF : https://mirwebma.tistory.com/121


            Document pdfDoc = new Document(txtFilePath.Text);

            foreach(var page in pdfDoc.Pages)
            {
                //해상도 정의
                Resolution resolution = new Resolution(720);


                //지정된 속성으로 png 장치 만들기
                // 너비, 높이, 해상도
                PngDevice pngDevice = new PngDevice(resolution);


                //특정 페이지를 변환하고 이미지를 스트림에 저장
                var newFile = string.Concat(filePath, fileName, "_", page.Number, ".png");
                Console.WriteLine(newFile);
                pngDevice.Process(pdfDoc.Pages[page.Number], newFile);
            }

            MessageBox.Show("Convert is done!");
        }
    }
}
