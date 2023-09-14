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
    ///         https://s-engineer.tistory.com/349
    ///         https://yunwoong.tistory.com/148
    ///         https://github.com/googleapis/google-api-dotnet-client
    ///         
    /// </summary>
    public partial class MainForm : Form
    {
        #region [Field]

        private ImageAnnotatorClient client;
        private OpenFileDialog openFileDialog;
        private BackgroundWorker backgroudWorker;
        private StringBuilder stringBuilder = null;
        private List<string> filePathList = null;
        private List<Recipe> recipeList = null;
        private int selectedImageIndexNo = -1;
        private bool bCanBackgroundWorker = true;

        #endregion

        /// <summary>
        /// TODO : Export Excel 기능 추가 
        /// </summary>
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

            #region - Control initialize
            //dgvResult.Columns.Add("No", "No");
            ////dgvResult.Columns.Add("File", "File");
            //dgvResult.Columns.Add("Date", "Date");
            //dgvResult.Columns.Add("Price", "Price");

            filePathList = new List<string>();

            recipeList = new List<Recipe>();
            #endregion


            #region - Context Menu
            ContextMenu ctx = new ContextMenu();
            ctx.MenuItems.Add("Date 등록", new EventHandler(RIGHT_MENU_DATE));
            ctx.MenuItems.Add("Price 등록", new EventHandler(RIGHT_MENU_PRICE));
            resultTextBox.ContextMenu = ctx;
            
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
        /// Pay Price 등록 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RIGHT_MENU_PRICE(object sender, EventArgs e)
        {
            if (selectedImageIndexNo > -1 && recipeList.Count > 0)
            {
                var recipe = recipeList[selectedImageIndexNo];

                var tmpPrice = resultTextBox.SelectedText;
                
                //예외처리 
                recipe.price = tmpPrice.Trim().Replace('.', ',');

                //dgvResult.Rows[selectedImageIndexNo].Cells[3].Value = recipe.price;

                dgvResult.DataSource = null;
                dgvResult.DataSource = recipeList;

            }
        }

        /// <summary>
        /// Pay Date 등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RIGHT_MENU_DATE(object sender, EventArgs e)
        {
            if (selectedImageIndexNo > -1 && recipeList.Count > 0)
            {
                var recipe = recipeList[selectedImageIndexNo];

                var tempDate = resultTextBox.SelectedText;

                try
                {
                    DateTime tmp = DateTime.Parse(tempDate);
                    tempDate = tmp.ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("DateTime Parse Error");
                }

                //recipe.recipeDate = resultTextBox.SelectedText;
                recipe.recipeDate = tempDate;

                //dgvResult.Rows[selectedImageIndexNo].Cells[2].Value = recipe.recipeDate;

                dgvResult.DataSource = null;
                dgvResult.DataSource = recipeList;

            }
        }

        /// <summary>
        /// 백그라운드 작업자 실행 완료시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void BackgroudWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.resultTextBox.Text = this.stringBuilder?.ToString();

            this.imageButton.Text = "image";

            this.imageButton.Enabled = true;

            this.bCanBackgroundWorker = true;
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
            if (this.stringBuilder != null)
            {
                this.stringBuilder.Clear();

                this.stringBuilder = null;
            }

            this.stringBuilder = new StringBuilder();


            #region [초기 File List를 args로 받을 경우]
            //List<string> filePathList = e.Argument as List<string>;

            //for (int i = 0; i < filePathList.Count; i++)
            //{
            //    string filePath = filePathList[i];

            //    backgroudWorker.ReportProgress(i, filePathList.Count);

            //    try
            //    {
            //        Google.Cloud.Vision.V1.Image image = Google.Cloud.Vision.V1.Image.FromFile(filePath);

            //        var response = client.DetectText(image);

            //        string text = response.First()?.Description;

            //        this.stringBuilder.AppendLine(text.Replace("\n", "\r\n"));

            //        backgroudWorker.ReportProgress(i + 1, filePathList.Count);
            //    }
            //    catch
            //    {
            //        continue;
            //    }
            //    finally
            //    {
            //        this.stringBuilder.AppendLine("--------------------------------------------------");
            //        this.stringBuilder.AppendLine();
            //        this.stringBuilder.AppendLine();
            //    }
            //}
            #endregion

            #region [파일 개별적으로 Image detection 할 경우]
            string filePath = e.Argument as string;

            if(filePath != null  && filePath.Length > 0)
            {
                this.stringBuilder.AppendLine(filePath);
                this.stringBuilder.AppendLine("--------------------------------------------------");
                

                try
                {
                    if (selectedImageIndexNo > -1)
                    {
                        if (recipeList[selectedImageIndexNo].parseData.Length > 0)
                        {
                            this.stringBuilder.AppendLine(recipeList[selectedImageIndexNo].parseData);
                            Console.WriteLine("None Vision Processing");
                        }
                        else
                        {
                            Google.Cloud.Vision.V1.Image image = Google.Cloud.Vision.V1.Image.FromFile(filePath);

                            var response = client.DetectText(image);

                            string text = response.First()?.Description;
                            string parseText = text.Replace("\n", "\r\n");

                            this.stringBuilder.AppendLine(parseText);

                            recipeList[selectedImageIndexNo].parseData = parseText;

                            Console.WriteLine("Do Vision Processing");
                        }
                    }
                    
                }
                catch
                {
                    Console.WriteLine("File is not found");
                }
                finally
                {
                    this.stringBuilder.AppendLine("--------------------------------------------------");
                    this.stringBuilder.AppendLine();
                    this.stringBuilder.AppendLine();
                }
            }
            #endregion


        }

        /// <summary>
        /// Image 새로 읽어올 경우 모든 컨트롤 초기화
        /// </summary>
        /// <returns></returns>
        private bool initControl()
        {
            bool result = true;

            try
            {
                if (filePathList.Count > 0)
                {
                    filePathList.Clear();
                    recipeList.Clear();
                    selectedImageIndexNo = -1;
                    dgvResult.Rows.Clear();
                }

                pnlFlowList.Controls.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 분석 대상 이미지 불러오기 
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

            if (initControl())
            {
                imageButton.Enabled = false;

                filePathList = openFileDialog.FileNames.OrderBy(x => x).ToList();

                //backgroudWorker.RunWorkerAsync(filePathList);

                for(int i = 0; i < filePathList.Count; i++)
                {
                    Panel panel = create_thumbnail(filePathList[i], i);
                    
                    //Image Control 추가
                    pnlFlowList.Controls.Add(panel);

                    var fileName = panel.Tag.ToString();
                    var splitFileName = fileName.Split('\\');

                    Recipe recipe = new Recipe
                    {
                        //idx = i,
                        //fileName = fileName,
                        recipeDate = "0000-00-00 00:00:00",
                        price = "0",
                        parseData = "",
                    };

                    recipeList.Add(recipe);

                    //dgvResult.Rows.Add(splitFileName[splitFileName.Length-1], "", "");
                }

                dgvResult.DataSource = recipeList;

                //foreach (string filePath in filePathList)
                //{
                //    Panel panel = create_thumbnail(filePath);
                //    //pnlImageList.Controls.Add(panel);
                //    pnlFlowList.Controls.Add(panel);
                //}
            }
            else
            {
                Console.WriteLine("init error");
            }

        }


        private Panel create_thumbnail(string filepath, int index)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(filepath);

            Panel nPanel = new Panel();
            nPanel.BackColor = Color.Black;
            nPanel.Size = new Size(180, 180);
            nPanel.Padding = new System.Windows.Forms.Padding(4);
            nPanel.Tag = filepath;

            PictureBox pBox = new PictureBox();
            pBox.BackColor = Color.DimGray;
            pBox.Dock = DockStyle.Fill;
            pBox.SizeMode = PictureBoxSizeMode.Zoom;
            pBox.Image = img.GetThumbnailImage(178,178, null, IntPtr.Zero);
            pBox.Click += PBox_Click;
            pBox.Tag = new imageItem { idx=index, fileName=filepath };
            nPanel.Controls.Add(pBox);

            return nPanel;
        }

        private void PBox_Click(object sender, EventArgs e)
        {
            if(sender is PictureBox)
            {
                if (!this.bCanBackgroundWorker)
                {
                    MessageBox.Show("OCR 진행 중입니다. 잠시 후 다시 시도해 주세요!");return;
                }

                PictureBox imageBox = (PictureBox)sender;

                if(imageBox.Tag.ToString().Length > 0)
                {
                    var imgItem = imageBox.Tag as imageItem;
                    selectedImageIndexNo = imgItem.idx; //현재 선택 이미지의 index of list

                    var paramImagePath = imgItem.fileName;

                    //if (recipeList[imgItem.idx].parseData.Length > 0)
                    //{
                    //    paramImagePath = string.Empty;
                    //}

                    imageBox.Parent.BackColor = Color.DarkBlue;
                    this.bCanBackgroundWorker = false;
                    backgroudWorker.RunWorkerAsync(paramImagePath);
                }
            }


        }


        // Excel Export
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcel excel = new ExportExcel(dgvResult);
            MSG result = excel.Export();
            MessageBox.Show(result.MSG_MESSAGE);
        }
    }

    public class imageItem
    {
        public int idx { get; set; }
        public string fileName { get; set; }
    }

    public class Recipe
    {
        //public int idx { get; set; }
        //public string fileName { get; set; }
        public string recipeDate { get; set; }
        public string price { get; set; }
        public string parseData { get; set; }
    }

}
