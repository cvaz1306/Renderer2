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

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            videoSource.Start();
            
        }
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            wii = true;
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            bitmap.Dispose();
            webcam1=(Bitmap)bitmap.Clone();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            primaryScreen = Screen.PrimaryScreen;
            screenBounds = primaryScreen.Bounds;
            
            screenCapture = new Bitmap(screenBounds.Width, screenBounds.Height);
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

/*            this.Angle1.Text = (this.trackBar1.Value).ToString();
            this.Angle2.Text = (this.trackBar2.Value).ToString();
            this.Angle3.Text = (this.trackBar3.Value).ToString();
            Point screenMousePos = Control.MousePosition;
            Point clientMousePos = PointToClient(screenMousePos);

            int mouseX = clientMousePos.X;
            int mouseY = clientMousePos.Y;

            Vector3 screenNormal = Geometry.CalculateScreenNormal((float)this.trackBar1.Value, (float)this.trackBar2.Value, (float)this.trackBar3.Value); // Replace with your screen center.
            Vector3 screenCenter = new Vector3(0.0f+this.trackBar4.Value/25, 0.0f+this.trackBar5.Value/25, 1.0f+this.trackBar6.Value/25); // Replace with your screen normal vector.

            Vector2 intersection1 = Geometry.FindIntersectionOnScreen(pointIn3DSpace1, screenCenter, screenNormal);
            Vector2 intersection2 = Geometry.FindIntersectionOnScreen(pointIn3DSpace2, screenCenter, screenNormal);
            Vector2 intersection3 = Geometry.FindIntersectionOnScreen(pointIn3DSpace3, screenCenter, screenNormal);
            Vector2 intersection4 = Geometry.FindIntersectionOnScreen(pointIn3DSpace4, screenCenter, screenNormal);



            UpdateFrame();
            frame.SetColor((int)intersection1.Y + 150, (int)intersection1.X + 200, new MyColor(0, 0, 0));
            frame.SetColor((int)intersection2.Y + 150, (int)intersection2.X + 200, new MyColor(255, 0, 0));
            frame.SetColor((int)intersection3.Y + 150, (int)intersection3.X + 200, new MyColor(0, 255, 0));
            frame.SetColor((int)intersection4.Y + 150, (int)intersection4.X + 200, new MyColor(0, 0, 255));

*//*            frame.AddLine(intersection1 * 2, intersection3 * 2, new MyColor(255, 0, 0));
            frame.AddLine(intersection3 * 2, intersection4 * 2, new MyColor(0, 255, 0));
            frame.AddLine(intersection2 * 2, intersection4 * 2, new MyColor(0, 0, 255));
            frame.AddLine(intersection1 * 2, intersection2 * 2, new MyColor(0, 255, 255));*//*
            frame.AddLine(pointIn3DSpace1, pointIn3DSpace3, new MyColor(0, 0, 0), screenCenter, screenNormal, screenCenter);
            frame.AddLine(pointIn3DSpace3, pointIn3DSpace4, new MyColor(0, 0, 0), screenCenter, screenNormal, screenCenter);
            frame.AddLine(pointIn3DSpace2, pointIn3DSpace4, new MyColor(0, 0, 0), screenCenter, screenNormal, screenCenter);
            frame.AddLine(pointIn3DSpace1, pointIn3DSpace2, new MyColor(0, 0, 0), screenCenter, screenNormal, screenCenter);
            Rectangle bounds = primaryScreen.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                frame.RenderBitmap(bitmap, new Vector3[] { new Vector3(-7f, 5f, 5f), new Vector3(7f, 5f, 5f), new Vector3(-7f, -5f, 5f), new Vector3(7f, -5f, 0f) }, screenCenter, screenNormal);
            }
            */
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

                using (var q = Graphics.FromImage(new Bitmap(1048, 720)))
                {
                    if (frameCt % 10 == 0)
                    {
                        Bitmap sx = new Bitmap(1920, 1080);
                        //graphics.Clear(x);
                    }


                    if (wii) graphics.DrawImage(webcam1, 0, 0);
                    webcam1.Dispose();
                    graphics.DrawImage(S, 0, 0, (int)(1920 / ((float)this.v1.Value/10)), (int)(1080 / ((float)this.v1.Value/10)));
                    graphics.Dispose();
                    //graphics.DrawImage(S, 0, 0);
                    S.Dispose();
                }
                }
            /*}
*/
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
                throw ex;
            }
        }

        private static Bitmap Blur(Bitmap image, Int32 blurSize)
        {
            return Blur(image, new Rectangle(0, 0, image.Width, image.Height), blurSize);
        }

        private static Bitmap Blur(Bitmap image, Rectangle rectangle, Int32 blurSize)
        {
            unsafe
            {
                Bitmap blurred = new Bitmap(image.Width, image.Height);

                // make an exact copy of the bitmap provided
                using (Graphics graphics = Graphics.FromImage(blurred))
                    graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                        new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

                // Lock the bitmap's bits
                BitmapData blurredData = blurred.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, blurred.PixelFormat);

                // Get bits per pixel for current PixelFormat
                int bitsPerPixel = Image.GetPixelFormatSize(blurred.PixelFormat);

                // Get pointer to first line
                byte* scan0 = (byte*)blurredData.Scan0.ToPointer();

                // look at every pixel in the blur rectangle
                for (int xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
                {
                    for (int yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
                    {
                        int avgR = 0, avgG = 0, avgB = 0;
                        int blurPixelCount = 0;

                        // average the color of the red, green and blue for each pixel in the
                        // blur size while making sure you don't go outside the image bounds
                        for (int x = xx; (x < xx + blurSize && x < image.Width); x++)
                        {
                            for (int y = yy; (y < yy + blurSize && y < image.Height); y++)
                            {
                                // Get pointer to RGB
                                byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;

                                avgB += data[0]; // Blue
                                avgG += data[1]; // Green
                                avgR += data[2]; // Red

                                blurPixelCount++;
                            }
                        }

                        avgR = avgR / blurPixelCount;
                        avgG = avgG / blurPixelCount;
                        avgB = avgB / blurPixelCount;

                        // now that we know the average for the blur size, set each pixel to that color
                        for (int x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++)
                        {
                            for (int y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++)
                            {
                                // Get pointer to RGB
                                byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;

                                // Change values
                                data[0] = (byte)avgB;
                                data[1] = (byte)avgG;
                                data[2] = (byte)avgR;
                            }
                        }
                    }
                }
                blurred.UnlockBits(blurredData);

                return blurred;
            }

            // Unlock the bits

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


