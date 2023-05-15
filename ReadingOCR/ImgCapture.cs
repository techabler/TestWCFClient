using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingOCR
{
    public class ImgCapture
    {
        private int _refX = 0;
        private int _refY = 0;
        private int _imgW = 0;
        private int _imgH = 0;

        private string filePath = string.Empty;

        public ImgCapture(int refX, int refY, int imgW, int imgH)
        {
            _refX = refX;
            _refY = refY;
            _imgW = imgW;
            _imgH = imgH;
        }

        public void SetPath(string path)
        {
            filePath = path;
        }

        public void DoCaptureImage()
        {
            if (filePath != string.Empty) 
            {
                if (_imgW == 0 || _imgH == 0) return;

                using(System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(_imgW, _imgH))
                {
                    using(System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(_refX, _refY, 0, 0, bitmap.Size);
                    }
                    bitmap.Save(filePath, ImageFormat.Png);
                }
            }

        }
    }
}
