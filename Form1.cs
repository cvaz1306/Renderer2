using System;
using System.Drawing;
using System.Windows.Forms;
using Renderer2;
using System.Drawing.Imaging;
using Accord.Video;
using Accord.Video.DirectShow;
using Accord.Vision.Detection;
namespace Renderer2
{
    public partial class Form1 : Form
    {


        public int Hue;
        private Timer animationTimer;
        private Timer animationTimer2;
        private Timer animationTimer3;
        private int currentFrame = 0;
        Bitmap webcam1 = new Bitmap(1920, 1080);
        Bitmap S = new Bitmap(1920, 1080);
        Bitmap scaledMirror = new Bitmap(1920, 1080);
        Bitmap finalImage = new Bitmap(1920, 1080);
        Screen primaryScreen;
        Rectangle screenBounds;
        int interval;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public int scale;
        int wx, hy;
        int offsetX, offsetY;
        Accord.Vision.Detection.Cascades.FaceHaarCascade cascade = new Accord.Vision.Detection.Cascades.FaceHaarCascade();
        HaarObjectDetector detector;
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
            detector = new HaarObjectDetector(this.cascade, minSize: 50,
    searchMode: ObjectDetectorSearchMode.NoOverlap);
            
            animationTimer = new Timer();
            animationTimer.Interval = 10; 
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();

            animationTimer2 = new Timer();
            animationTimer2.Interval = 10; 
            animationTimer2.Tick += AnimationTimer_Tick;
            animationTimer2.Start();

            animationTimer3 = new Timer();
            animationTimer3.Interval = 10; 
            animationTimer3.Tick += AnimationTimer_Tick;
            animationTimer3.Start();
           
        }
        public Form1(int inte, string t)
        {
            InitializeComponent();

            
            animationTimer = new Timer();
            animationTimer.Interval = 1; 
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();

            animationTimer2 = new Timer();
            animationTimer2.Interval = 1; 
            animationTimer2.Tick += AnimationTimer_Tick2;
            animationTimer2.Start();

            animationTimer3 = new Timer();
            animationTimer3.Interval = 1; 
            animationTimer3.Tick += AnimationTimer_Tick3;
            animationTimer3.Start();
            interval = inte;
            this.Text = t;
            this.FormClosing += MainForm_FormClosing;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(webcam1!=null) videoSource.SignalToStop();
        }
        
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            S = CaptureScreenX(0);
            scale = this.v1.Value;
            wx = (int)(1920 / ((float)v1.Value / 10));
            hy = (int)(1080 / ((float)v1.Value / 10));
            offsetX = -wx/8;
            offsetY = -hy/8;

        }
        private void AnimationTimer_Tick2(object sender, EventArgs e)
        {
            if (S != null) try { scaledMirror = scaleBitmap(S, wx, hy); } catch (Exception) { }
            if (S != null) try { finalImage = overlayBitmaps(webcam1, scaledMirror, this.trackBar1.Value-60+offsetX, -this.trackBar2.Value+207+360+offsetY); } catch (Exception) { }


        }
        private void AnimationTimer_Tick3(object sender, EventArgs e)
        {
            frameCt++;
            if (frameCt % 50 == 0)
            {
                GC.Collect();
            }
            using (var graphics = CreateGraphics())
            {
                try { graphics.DrawImage(finalImage, 0, 0); } catch (Exception) { }
            }
        }
        int frameCt=0;
        
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
            Bitmap result = new Bitmap(width, height);
            result.SetResolution(400,400);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bitmap1, 0, 0, width, height);

            }
            bitmap1.Dispose();
            return result;
        }

        public static Bitmap CaptureScreenX(int xy)
        {
            try
            {
                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);

                Rectangle captureRectangle = Screen.AllScreens[xy].Bounds;

                using (Graphics captureGraphics = Graphics.FromImage(captureBitmap))
                {
                    captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                    return captureBitmap;
                }
            }
            catch (Exception)
            {
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


