using System;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Renderer2
{
    public partial class FloatingTrackBar : UserControl
    {
        private float minValue = 0.0f;
        private float maxValue = 1.0f;
        private float value = 0.5f; // Initial value

        public FloatingTrackBar()
        {
            
            InitializeComponent();
            this.trackBar.Minimum = 0;
            trackBar.Maximum = 0b1100100; // Use a larger range to provide finer granularity
            this.trackBar.Value = (int)((value - minValue) / (maxValue - minValue) * 100);
            UpdateLabel();
        }
        private void FloatingTrackBar_Load(object sender, EventArgs e)
        {
            // Your initialization or event handling code here
            InitializeComponent();
            this.trackBar.Minimum = 0;
            this.trackBar.Maximum = 100; // Use a larger range to provide finer granularity
            this.trackBar.Value = (int)((value - minValue) / (maxValue - minValue) * 100);
            UpdateLabel();
        }

        public float MinValue
        {
            get { return minValue; }
            set
            {
                minValue = value;
                UpdateLabel();
            }
        }

        public float MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                UpdateLabel();
            }
        }

        public float Value
        {
            get { return value; }
            set
            {
                this.value = Math.Max(minValue, Math.Min(maxValue, value));
                int trackBarValue = (int)((this.value - minValue) / (maxValue - minValue) * 100);
                this.trackBar.Value = trackBarValue;
                UpdateLabel();
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            value = minValue + (maxValue - minValue) * (trackBar.Value / 100.0f);
            UpdateLabel();
        }

        private void UpdateLabel()
        {
            this.label.Text = value.ToString("F2"); // Display value with two decimal places
        }
    }
}
