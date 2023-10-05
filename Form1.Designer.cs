namespace Renderer2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.Angle1 = new System.Windows.Forms.Label();
            this.Angle2 = new System.Windows.Forms.Label();
            this.Angle3 = new System.Windows.Forms.Label();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FOV = new System.Windows.Forms.TrackBar();
            this.v1 = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FOV)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1413, 96);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(24, 18);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Maximum = 360;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(543, 56);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 1;
            this.trackBar2.Location = new System.Drawing.Point(24, 81);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar2.Maximum = 360;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(543, 56);
            this.trackBar2.TabIndex = 1;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.LargeChange = 1;
            this.trackBar3.Location = new System.Drawing.Point(24, 144);
            this.trackBar3.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar3.Maximum = 360;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(543, 56);
            this.trackBar3.TabIndex = 1;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Angle1
            // 
            this.Angle1.AutoSize = true;
            this.Angle1.Location = new System.Drawing.Point(20, -1);
            this.Angle1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Angle1.Name = "Angle1";
            this.Angle1.Size = new System.Drawing.Size(14, 16);
            this.Angle1.TabIndex = 2;
            this.Angle1.Text = "0";
            // 
            // Angle2
            // 
            this.Angle2.AutoSize = true;
            this.Angle2.Location = new System.Drawing.Point(20, 58);
            this.Angle2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Angle2.Name = "Angle2";
            this.Angle2.Size = new System.Drawing.Size(14, 16);
            this.Angle2.TabIndex = 2;
            this.Angle2.Text = "0";
            // 
            // Angle3
            // 
            this.Angle3.AutoSize = true;
            this.Angle3.Location = new System.Drawing.Point(20, 124);
            this.Angle3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Angle3.Name = "Angle3";
            this.Angle3.Size = new System.Drawing.Size(14, 16);
            this.Angle3.TabIndex = 2;
            this.Angle3.Text = "0";
            // 
            // trackBar4
            // 
            this.trackBar4.LargeChange = 1;
            this.trackBar4.Location = new System.Drawing.Point(28, 16);
            this.trackBar4.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar4.Maximum = 360;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(543, 56);
            this.trackBar4.TabIndex = 1;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar5
            // 
            this.trackBar5.LargeChange = 1;
            this.trackBar5.Location = new System.Drawing.Point(28, 79);
            this.trackBar5.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar5.Maximum = 360;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(543, 56);
            this.trackBar5.TabIndex = 1;
            this.trackBar5.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar6
            // 
            this.trackBar6.LargeChange = 1;
            this.trackBar6.Location = new System.Drawing.Point(28, 142);
            this.trackBar6.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar6.Maximum = 360;
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(543, 56);
            this.trackBar6.TabIndex = 1;
            this.trackBar6.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, -4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trackBar4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.trackBar5);
            this.panel1.Controls.Add(this.trackBar6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(971, 438);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 206);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.trackBar2);
            this.panel2.Controls.Add(this.Angle3);
            this.panel2.Controls.Add(this.trackBar3);
            this.panel2.Controls.Add(this.Angle2);
            this.panel2.Controls.Add(this.Angle1);
            this.panel2.Location = new System.Drawing.Point(971, 196);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 206);
            this.panel2.TabIndex = 4;
            // 
            // FOV
            // 
            this.FOV.LargeChange = 1;
            this.FOV.Location = new System.Drawing.Point(999, 673);
            this.FOV.Margin = new System.Windows.Forms.Padding(4);
            this.FOV.Minimum = 1;
            this.FOV.Name = "FOV";
            this.FOV.Size = new System.Drawing.Size(543, 56);
            this.FOV.TabIndex = 1;
            this.FOV.Value = 1;
            this.FOV.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // v1
            // 
            this.v1.LargeChange = 2;
            this.v1.Location = new System.Drawing.Point(12, 11);
            this.v1.Maximum = 10000;
            this.v1.Minimum = 1;
            this.v1.Name = "v1";
            this.v1.Size = new System.Drawing.Size(1580, 17);
            this.v1.TabIndex = 5;
            this.v1.Value = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 769);
            this.Controls.Add(this.v1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FOV);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Virtual Displays";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FOV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label Angle1;
        private System.Windows.Forms.Label Angle2;
        private System.Windows.Forms.Label Angle3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar FOV;
        private System.Windows.Forms.HScrollBar v1;
    }
}

