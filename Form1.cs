using System;
using System.Drawing;
using System.Windows.Forms;
using Renderer2;
using System.Drawing.Imaging;
using Accord.Video;
using Accord.Video.DirectShow;

namespace Renderer2
{
    public partial class Form1 : Form
    {


        public int Hue;
        private Timer animationTimer;
        private int currentFrame = 0;
        Bitmap webcam1 = new Bitmap(1920, 1080);
        Screen primaryScreen;
        Rectangle screenBounds;
        int interval;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public int scale;
        private void InitializeWebcam(int xy)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
                return;
            }
            
            videoSource = new VideoCaptureDevice(videoDevices[xy].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);

            videoSource.Start();
            videoDevices.Clear();

        }
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            webcam1 = (Bitmap)eventArgs.Frame.Clone();
            Console.WriteLine("HHHHH");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            primaryScreen = Screen.PrimaryScreen;
            screenBounds = primaryScreen.Bounds;
            
            InitializeWebcam(2);
        }
        public Form1()
        {
            InitializeComponent();

            // Set up a timer for animation
            animationTimer = new Timer();
            animationTimer.Interval = 10; // Adjust the interval as needed for your desired frame rate
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
            //this.OnClosing += formclosed;
        }
        public Form1(int inte, string t)
        {
            InitializeComponent();

            // Set up a timer for animation
            animationTimer = new Timer();
            animationTimer.Interval = 1; // Adjust the interval as needed for your desired frame rate
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
            interval = inte;
            this.Text = t;
            //this.OnClosing += formclosed;
            this.FormClosing += MainForm_FormClosing;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(webcam1!=null) videoSource.SignalToStop();
        }

            private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            CID.Maximum= Math.Max(new FilterInfoCollection(FilterCategory.VideoInputDevice).Count - 1, 0);
            Console.WriteLine("VFR: " + this.videoSource.FramesReceived);
            RenderFrame();
            
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
            if (frameCt % 180 == 0)
            {
                GC.Collect();
            }
            /*using (var bitmap = frame.ToBitmap())
            {*/
                using (var graphics = CreateGraphics())
                {
                //graphics.DrawImage(bitmap, 0, 0);
                Bitmap S = CaptureScreenX();
                scale = this.v1.Value;
                int wx = (int)(1920 / ((float)v1.Value / 10));
                int hy = (int)(1080 / ((float)v1.Value / 10));
                int offsetX = 1920 - (int)((float)wx / 2);
                int offsetY = 1080 - (int)((float)hy / 2);
                Console.WriteLine("WX: " + wx);
                if (S != null) try { graphics.DrawImage(overlayBitmaps(webcam1, scaleBitmap(S, wx, hy), this.trackBar1.Value, this.trackBar2.Value), 0, 0, 1920, 1080); } catch(Exception) { }
                webcam1.Dispose();
                
                graphics.Dispose();
                
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
            bitmap1.Dispose();
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
            if(videoSource.IsRunning) videoSource.Stop(); else videoSource.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //InitializeWebcam(CID.Value);
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


