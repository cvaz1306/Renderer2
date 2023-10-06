using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using Renderer2;
using System.Drawing.Imaging;
using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Renderer2
{
    public partial class Form1 : Form
    {


        public int Hue;
        private Frame frame;
        private Timer animationTimer;
        private int currentFrame = 0;
        Bitmap webcam1 = new Bitmap(1920, 1080);
        Vector3 pointIn3DSpace1 = new Vector3(-7, 5, 20);
        Vector3 pointIn3DSpace2 = new Vector3(-7, -5, 20);
        Vector3 pointIn3DSpace3 = new Vector3(7, 5, 20);
        Vector3 pointIn3DSpace4 = new Vector3(7, -5, 20);
        Screen primaryScreen;
        Rectangle screenBounds;
        Bitmap screenCapture;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        bool wii=false;
        private void InitializeWebcam()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[2].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            videoSource.Start();
            
        }
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            wii = true;
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            
            webcam1=(Bitmap)bitmap.Clone();
            bitmap.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            primaryScreen = Screen.PrimaryScreen;
            screenBounds = primaryScreen.Bounds;
            
            screenCapture = new Bitmap(screenBounds.Width, screenBounds.Height);
            screenCapture.Dispose();
            InitializeWebcam();
        }
        public Form1()
        {
            InitializeComponent();

            // Create a frame with 300 rows, 400 columns, and a cell size of 2 pixels
            frame = new Frame(300, 400, 1);

            // Initialize the frame with random colors
            //frame.FillWithRandomColors();

            // Set up a timer for animation
            animationTimer = new Timer();
            animationTimer.Interval = 1; // Adjust the interval as needed for your desired frame rate
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {

            RenderFrame();
        }

        private void UpdateFrame()
        {
            frame.FillWithColor(new MyColor(240, 255, 255));
        }
        static Bitmap ScaleImage(Bitmap bmp, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / bmp.Width;
            var ratioY = (double)maxHeight / bmp.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(bmp.Width * ratio);
            var newHeight = (int)(bmp.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(bmp, 0, 0, newWidth, newHeight);

            return newImage;
        }
        int frameCt=0;
        private void RenderFrame()
        {
            Color x = Color.FromArgb(255, 255, 255);
            frameCt++;
            /*using (var bitmap = frame.ToBitmap())
            {*/
                using (var graphics = CreateGraphics())
                {
                //graphics.DrawImage(bitmap, 0, 0);
                Bitmap S = CaptureScreenX();
                int wx = (int)(1920 / ((float)this.v1.Value / 10));
                int hy = (int)(1080 / ((float)this.v1.Value / 10));
                int offsetX = 1920 - (int)((float)wx / 2);
                int offsetY = 1080 - (int)((float)hy / 2);
                Console.WriteLine("WX: " + wx);
                if (S != null) try { graphics.DrawImage(overlayBitmaps(webcam1, scaleBitmap(S, wx, hy), this.trackBar1.Value, this.trackBar2.Value), 0, 0, 1920, 1080); } catch(Exception) { }
                webcam1.Dispose();
                //graphics.DrawImage(S, 0, 0, (int)(1920 / ((float)this.v1.Value/10)), (int)(1080 / ((float)this.v1.Value/10)));
                graphics.Dispose();
                //graphics.DrawImage(S, 0, 0);
                if(S!=null) S.Dispose();
                
                }
            /*}
*/
        }
        private Bitmap overlayBitmaps(Bitmap bitmap1, Bitmap bitmap2)
        {
            Bitmap result=new Bitmap(Math.Max(bitmap1.Width, bitmap2.Width), Math.Max(bitmap1.Height, bitmap2.Height));
            using(Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bitmap1, 0,0);
                g.DrawImage(bitmap2, 0,0);

            }
            return result;
        }
        private Bitmap overlayBitmaps(Bitmap bitmap1, Bitmap bitmap2, int offsetX, int offsertY)
        {
            Bitmap result = new Bitmap(Math.Max(bitmap1.Width, bitmap2.Width), Math.Max(bitmap1.Height, bitmap2.Height));
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bitmap1, 0, 0);
                g.DrawImage(bitmap2, offsetX, offsertY);
                
            }
            return result;
        }
        private Bitmap scaleBitmap(Bitmap bitmap1, int width, int height)
        {
            Bitmap result = (Bitmap)bitmap1.Clone();//new Bitmap(width, height);
            result.SetResolution(400,400);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bitmap1, 0, 0, width, height);//, width, height);//, width, height);

            }
            return result;
        }

        public static Bitmap CaptureScreenX()
        {
            try
            {
                // Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);

                // Creating a Rectangle object which will capture our Current Screen
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

                // Creating a new Graphics Object
                using (Graphics captureGraphics = Graphics.FromImage(captureBitmap))
                {
                    // Copying Image from The Screen
                    captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                    // You can return the captured Bitmap here if you want to use it further
                    //captureBitmap.SetResolution(768, 480);
                    return captureBitmap;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during screen capture
                return null;
            }
        }

        

        public static MyColor HSVToRGB(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            switch (hi)
            {
                case 0:
                    return new MyColor(v, t, p);
                case 1:
                    return new MyColor(q, v, p);
                case 2:
                    return new MyColor(p, v, t);
                case 3:
                    return new MyColor(p, q, v);
                case 4:
                    return new MyColor(t, p, v);
                default:
                    return new MyColor(v, p, q);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            pointIn3DSpace1 = new Vector3(-7, 5, -6);
            pointIn3DSpace2 = new Vector3(-7, -5, -6);
            pointIn3DSpace3 = new Vector3(7, 5, -6);
            pointIn3DSpace4 = new Vector3(7, -5, -6);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }
        static void HandleFrameCaptured(Bitmap frame)
        {
            // Handle the captured frame here
            // For example, save it to a file or display it
        }
    }
}

public class MyColor
{
    public int R { get; set; } // Red component (0-255)
    public int G { get; set; } // Green component (0-255)
    public int B { get; set; } // Blue component (0-255)

    public MyColor(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }
}


