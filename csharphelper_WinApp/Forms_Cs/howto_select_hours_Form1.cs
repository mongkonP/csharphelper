using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_select_hours_Form1:Form
  { 


        public howto_select_hours_Form1()
        {
            InitializeComponent();
        }

        // The selected hours.
        private int StartHour = 6;
        private int StopHour = 18;

        private void howto_select_hours_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        private void picHours_Paint(object sender, PaintEventArgs e)
        {
            DrawHours(picHours, e.Graphics, StartHour, StopHour);
        }

        // Draw the hour indicator on this PictureBox.
        private void DrawHours(PictureBox pic, Graphics gr, int start_hour, int stop_hour)
        {
            gr.Clear(Color.LightGreen);

            // Scale to fit a 24-hour period.
            const int margin = 3;
            float scale_x = XScale(pic);
            float hgt = pic.ClientSize.Height;
            float y1 = margin;
            float y2 = hgt - margin;

            // Draw the selected time range.
            RectangleF hours_rect =
                new RectangleF(
                    start_hour * scale_x, y1,
                    (stop_hour - start_hour) * scale_x, y2 - y1);
            gr.FillRectangle(Brushes.Blue, hours_rect);

            // Draw tick marks.
            float x = 0;
            for (int i = 0; i <= 24; i++)
            {
                gr.DrawLine(Pens.DarkGray, x, 0, x, hgt);
                x += scale_x;
            }

            // Draw times.
            gr.RotateTransform(-90);
            int xmid = -pic.ClientSize.Height / 2;
            using (Font font = new Font(FontFamily.GenericSansSerif, 12))
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    x = 0;
                    for (int i = 0; i <= 24; i++)
                    {
                        gr.DrawString(HourToString(i), font,
                            Brushes.Black, xmid, x, sf);
                        x += scale_x;
                    }
                }
            }
        }

        // Return the hour formatted as we want to display it.
        private string HourToString(int hour)
        {
            if (hour == 0) return "midnight";
            if (hour == 12) return "noon";
            if (hour == 24) return "midnight";
            if (hour <= 12) return hour.ToString() + "am";
            return (hour - 12).ToString() + "pm";
        }

        // Get the horizontal scale factor.
        private float XScale(PictureBox pic)
        {
            return pic.ClientSize.Width / 24;
        }

        // Handle mouse events.
        private bool Drawing = false;
        private int DrawingStartHour, DrawingStopHour;
        private void picHours_MouseDown(object sender, MouseEventArgs e)
        {
            Drawing = true;
            DrawingStartHour = (int)Math.Round(e.X / XScale(picHours));
            DrawingStopHour = DrawingStartHour;
            StartHour = DrawingStartHour;
            StopHour = DrawingStartHour;
            picHours.Refresh();
        }

        private void picHours_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;

            // Calculate the value and display a tooltip.
            int hour = (int)Math.Round(e.X / XScale(picHours));
            string new_tip = HourToString(hour);
            if (tipHour.GetToolTip(picHours) != new_tip)
                tipHour.SetToolTip(picHours, new_tip);

            // Save the new value.
            DrawingStopHour = hour;

            // Redraw.
            if (DrawingStartHour < DrawingStopHour)
            {
                StopHour = DrawingStopHour;
                StartHour = DrawingStartHour;
            }
            else
            {
                StartHour = DrawingStopHour;
                StopHour = DrawingStartHour;
            }
            picHours.Refresh();
        }

        private void picHours_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;
            tipHour.SetToolTip(picHours, "");
            Drawing = false;
            DisplayTimes();
        }

        // Show the times in the TextBoxes.
        private void DisplayTimes()
        {
            DateTime start_time = new DateTime(2000, 1, 1, StartHour, 0, 0);
            DateTime stop_time = new DateTime(2000, 1, 1, StopHour, 0, 0);
            txtStartTime.Text = start_time.ToShortTimeString();
            txtStopTime.Text = stop_time.ToShortTimeString();
        }
    

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
            this.components = new System.ComponentModel.Container();
            this.txtStopTime = new System.Windows.Forms.TextBox();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tipHour = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.picHours = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHours)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStopTime
            // 
            this.txtStopTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStopTime.Location = new System.Drawing.Point(374, 85);
            this.txtStopTime.Name = "txtStopTime";
            this.txtStopTime.ReadOnly = true;
            this.txtStopTime.Size = new System.Drawing.Size(100, 20);
            this.txtStopTime.TabIndex = 9;
            this.txtStopTime.TabStop = false;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStartTime.Location = new System.Drawing.Point(175, 85);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(100, 20);
            this.txtStartTime.TabIndex = 7;
            this.txtStartTime.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start Time:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Stop Time:";
            // 
            // picHours
            // 
            this.picHours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picHours.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picHours.Location = new System.Drawing.Point(12, 9);
            this.picHours.Name = "picHours";
            this.picHours.Size = new System.Drawing.Size(560, 70);
            this.picHours.TabIndex = 5;
            this.picHours.TabStop = false;
            this.picHours.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picHours_MouseMove);
            this.picHours.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHours_MouseDown);
            this.picHours.Paint += new System.Windows.Forms.PaintEventHandler(this.picHours_Paint);
            this.picHours.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picHours_MouseUp);
            // 
            // howto_select_hours_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 115);
            this.Controls.Add(this.txtStopTime);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picHours);
            this.Name = "howto_select_hours_Form1";
            this.Text = "howto_select_hours";
            this.Load += new System.EventHandler(this.howto_select_hours_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStopTime;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip tipHour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picHours;
    }
}

