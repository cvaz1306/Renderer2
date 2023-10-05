using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Renderer2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
class P1
{
/*    public static void X()
    {


        Bitmap x = CaptureScreen();
        using (var graphics = Control.CreateGraphics())
        {
            graphics.DrawImage(x, 0, 0);

            //graphics.DrawImage(screenCapture, 0, 0);
        }
    }*/
    
}