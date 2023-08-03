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

using Google.Cloud.Vision.V1;

namespace ReadVisionApi
{
    /// <summary>
    /// 참조 : https://icodebroker.tistory.com/6925 
    /// </summary>
    public partial class MainForm : Form
    {
        #region [Field]

        private ImageAnnotatorClient client;
        private OpenFileDialog openFileDialog;
        private BackgroundWorker backgroudWorker;
        private StringBuilder stringBuilder = null;

        #endregion

        public MainForm()
        {
            InitializeComponent();

            init();
        }

        private bool init()
        {
            #region - Image Client 설정
            try
            {
                string credentialsString = File.ReadAllText("D:\\09.Workspace\\AI\\GoogleCloud\\CloudVision\\auth_key\\visionexam-d2dcc7765a69.json");

                client = new ImageAnnotatorClientBuilder 
                { 
                    JsonCredentials = credentialsString,
                }.Build();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            #region - Open File Dialog
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image File(*.jpg)|*.jpg";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = true;
            openFileDialog.DefaultExt = ".jpg";
            #endregion

            #region - create background worker
            backgroudWorker = new BackgroundWorker();
            backgroudWorker.WorkerReportsProgress = true;
            #endregion

            resultTextBox.ReadOnly = true;

            imageButton.Click += imageButton_Click;
            backgroudWorker.DoWork += BackgroudWorker_DoWork;
            backgroudWorker.ProgressChanged += BackgroudWorker_ProgressChanged;
            backgroudWorker.RunWorkerCompleted += BackgroudWorker_RunWorkerCompleted;

            return true;
        }

        /// <summary>
        /// 백그라운드 작업자 실행 완료시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void BackgroudWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.resultTextBox.Text = this.stringBuilder?.ToString();

            this.imageButton.Text = "이미지";

            this.imageButton.Enabled = true;
        }

        /// <summary>
        /// 백그라운드 작업자 진행 변경시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void BackgroudWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int index = e.ProgressPercentage;
            int count = (int)e.UserState;

            this.imageButton.Text = $"{index}/{count}";

            this.imageButton.Update();
        }

        /// <summary>
        /// 백그라운드 작업자 작업 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void BackgroudWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> filePathList = e.Argument as List<string>;

            if (this.stringBuilder != null)
            {
                this.stringBuilder.Clear();

                this.stringBuilder = null;
            }

            this.stringBuilder = new StringBuilder();

            for (int i = 0; i < filePathList.Count; i++)
            {
                string filePath = filePathList[i];

                backgroudWorker.ReportProgress(i, filePathList.Count);

                this.stringBuilder.AppendLine(filePath);
                this.stringBuilder.AppendLine("--------------------------------------------------");

                try
                {
                    Google.Cloud.Vision.V1.Image image = Google.Cloud.Vision.V1.Image.FromFile(filePath);

                    var response = client.DetectText(image);

                    string text = response.First()?.Description;

                    this.stringBuilder.AppendLine(text.Replace("\n", "\r\n"));

                    backgroudWorker.ReportProgress(i + 1, filePathList.Count);
                }
                catch
                {
                    continue;
                }
                finally
                {
                    this.stringBuilder.AppendLine("--------------------------------------------------");
                    this.stringBuilder.AppendLine();
                    this.stringBuilder.AppendLine();
                }
            }
        }

        /// <summary>
        /// 이미지 버튼 클릭시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void imageButton_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if(openFileDialog.FileNames == null || openFileDialog.FileNames.Length == 0)
            {
                return;
            }

            imageButton.Enabled = false;

            List<string> filePathList = openFileDialog.FileNames.OrderBy(x => x).ToList();

            backgroudWorker.RunWorkerAsync(filePathList);

        }

        private void resultTextBox_MouseCaptureChanged(object sender, EventArgs e)
        {
            Console.WriteLine(resultTextBox.SelectedText);
        }
    }
}
