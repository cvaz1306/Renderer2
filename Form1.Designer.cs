﻿namespace Renderer2
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.v1 = new System.Windows.Forms.HScrollBar();
            this.resol = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1060, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 2;
            this.trackBar1.Location = new System.Drawing.Point(82, 25);
            this.trackBar1.Maximum = 720;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(407, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 86;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 2;
            this.trackBar2.Location = new System.Drawing.Point(41, 66);
            this.trackBar2.Maximum = 720;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 407);
            this.trackBar2.TabIndex = 1;
            this.trackBar2.Value = 86;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.trackBar2);
            this.panel2.Location = new System.Drawing.Point(670, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 476);
            this.panel2.TabIndex = 4;
            // 
            // v1
            // 
            this.v1.Location = new System.Drawing.Point(9, 9);
            this.v1.Minimum = 1;
            this.v1.Name = "v1";
            this.v1.Size = new System.Drawing.Size(1185, 17);
            this.v1.TabIndex = 5;
            this.v1.Value = 10;
            // 
            // resol
            // 
            this.resol.Location = new System.Drawing.Point(9, 26);
            this.resol.Maximum = 300;
            this.resol.Minimum = 1;
            this.resol.Name = "resol";
            this.resol.Size = new System.Drawing.Size(1185, 17);
            this.resol.TabIndex = 5;
            this.resol.Value = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 625);
            this.Controls.Add(this.resol);
            this.Controls.Add(this.v1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Virtual Displays";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.HScrollBar v1;
        private System.Windows.Forms.HScrollBar resol;
    }
}

