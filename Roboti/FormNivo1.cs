using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Roboti
{
    public partial class FormNivo1 : Form
    {
        Bitmap bb8;
        Bitmap fire;
        int poeni;
        DateTime pocetak;
        public FormNivo1()
        {
            InitializeComponent();

            string fileName1 = @"C:\Users\marinao\source\repos\Zmijica\Roboti\Images\bb8.jpg";
            FileInfo info1 = new FileInfo(fileName1);
            Image image1 = Image.FromFile(fileName1);
            bb8 = ResizeImage(image1, 100, 150);
            //Bitmap resizedImage = ResizeImage(image, 20);

            string fileName = @"C:\Users\marinao\source\repos\Zmijica\Roboti\Images\fire.jpg";
            FileInfo info = new FileInfo(fileName);
            Image image = Image.FromFile(fileName);
            fire = ResizeImage(image, 50, 50);

            poeni = 0;
            pocetak = DateTime.Now;

            
        }

        public void dodajPoen()
        {
            poeni++;
            if(poeni == 4)
            {
                var kraj = DateTime.Now;
                if((kraj - pocetak).TotalSeconds <10)
                {
                    MessageBox.Show("* * *", "Bravo!");
                    //3 zvezdeice
                }
                else
                {
                    MessageBox.Show("* *", "Nije loše!");
                }
                this.Close();
            }
        }

        private void FormNivo1_Load(object sender, EventArgs e)
        {
            _pbBB8.Image = bb8;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static Bitmap ResizeImage(Image image, decimal percentage)
        {
            int width = (int)Math.Round(image.Width * percentage, MidpointRounding.AwayFromZero);
            int height = (int)Math.Round(image.Height * percentage, MidpointRounding.AwayFromZero);
            return ResizeImage(image, width, height);
        }

        private void button_Click(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = fire;
            ((Button)sender).Enabled = false;
            dodajPoen();
        }

        //public static Bitmap FlipImage(Image image)
        //{
        //    ScaleTransform scaleTransform = new ScaleTransform();
        //    scaleTransform.CenterX = 0.5;
        //    scaleTransform.CenterY = 0.5;
        //    scaleTransform.ScaleY = -1;

        //    TransformedBitmap flippedImage = new TransformedBitmap(bmpsrc, scaleTransform);
        //}

    }
}
