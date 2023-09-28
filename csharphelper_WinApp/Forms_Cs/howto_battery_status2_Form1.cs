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
     public partial class howto_battery_status2_Form1:Form
  { 


        public howto_battery_status2_Form1()
        {
            InitializeComponent();
        }

        private void howto_battery_status2_Form1_Load(object sender, EventArgs e)
        {
            ShowPowerStatus();
        }
        private void tmrCheckStatus_Tick(object sender, EventArgs e)
        {
            ShowPowerStatus();
        }

        private void ShowPowerStatus()
        {
            PowerStatus status = SystemInformation.PowerStatus;
            float percent = status.BatteryLifePercent;
            // percent = 0.67f; // For easy testing.
            string percent_text = percent.ToString("P0");

            if (status.PowerLineStatus == PowerLineStatus.Online)
            {
                if (percent < 1.0f)
                    lblStatus.Text = percent_text + ", charging";
                else
                    lblStatus.Text = "Online fully charged";
            }
            else
            {
                lblStatus.Text = "Offline, " + percent_text + " remaining";
            }

            // Draw battery images.
            picVBattery1.Image = DrawBattery(
                percent,
                picVBattery1.ClientSize.Width,
                picVBattery1.ClientSize.Height,
                Color.Transparent, Color.Gray,
                Color.LightGreen, Color.White,
                true);
            picVBattery2.Image = DrawBattery(
                percent,
                picVBattery1.ClientSize.Width,
                picVBattery1.ClientSize.Height,
                Color.Transparent, Color.Gray,
                Color.LightGreen, Color.White,
                false);
            picHBattery1.Image = DrawBattery(
                percent,
                picHBattery1.ClientSize.Width,
                picHBattery1.ClientSize.Height,
                Color.Transparent, Color.Gray,
                Color.LightGreen, Color.White,
                true);
            picHBattery2.Image = DrawBattery(
                percent,
                picHBattery1.ClientSize.Width,
                picHBattery1.ClientSize.Height,
                Color.Transparent, Color.Gray,
                Color.LightGreen, Color.White,
                false);
        }

        private Bitmap DrawBattery(
            float percent, int wid, int hgt,
            Color bg_color, Color outline_color,
            Color charged_color, Color uncharged_color,
            bool striped)
        {
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // If the battery has a horizontal orientation,
                // rotate so we can draw it vertically.
                if (wid > hgt)
                {
                    gr.RotateTransform(90, MatrixOrder.Append);
                    gr.TranslateTransform(wid, 0, MatrixOrder.Append);
                    int temp = wid;
                    wid = hgt;
                    hgt = temp;
                }

                // Draw the battery.
                DrawVerticalBattery(gr, percent, wid, hgt, bg_color,
                    outline_color, charged_color, uncharged_color,
                    striped);
            }
            return bm;
        }

        // Draw a vertically oriented battery with
        // the indicated percentage filled in.
        private void DrawVerticalBattery(Graphics gr,
            float percent, int wid, int hgt,
            Color bg_color, Color outline_color,
            Color charged_color, Color uncharged_color,
            bool striped)
        {
            gr.Clear(bg_color);
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            // Make a rectangle for the main body.
            float thickness = hgt / 20f;
            RectangleF body_rect = new RectangleF(
                thickness * 0.5f, thickness * 1.5f,
                wid - thickness, hgt - thickness * 2f);

            using (Pen pen = new Pen(outline_color, thickness))
            {
                // Fill the body with the uncharged color.
                using (Brush brush = new SolidBrush(uncharged_color))
                {
                    gr.FillRectangle(brush, body_rect);
                }

                // Fill the charged area.
                float charged_hgt = body_rect.Height * percent;
                RectangleF charged_rect = new RectangleF(
                    body_rect.Left, body_rect.Bottom - charged_hgt,
                    body_rect.Width, charged_hgt);
                using (Brush brush = new SolidBrush(charged_color))
                {
                    gr.FillRectangle(brush, charged_rect);
                }

                // Optionally stripe multiples of 25%
                if (striped)
                    for (int i = 1; i <= 3; i++)
                    {
                        float y = body_rect.Bottom - i * 0.25f * body_rect.Height;
                        gr.DrawLine(pen, body_rect.Left, y, body_rect.Right, y);
                    }

                // Draw the main body.
                gr.DrawPath(pen, MakeRoundedRect(
                    body_rect, thickness, thickness,
                    true, true, true, true));

                // Draw the positive terminal.
                RectangleF terminal_rect = new RectangleF(
                    wid / 2f - thickness, 0,
                    2 * thickness, thickness);
                gr.DrawPath(pen, MakeRoundedRect(
                    terminal_rect, thickness / 2f, thickness / 2f,
                    true, true, false, false));
            }
        }

        // Draw a rectangle in the indicated Rectangle
        // rounding the indicated corners.
        private GraphicsPath MakeRoundedRect(
            RectangleF rect, float xradius, float yradius,
            bool round_ul, bool round_ur, bool round_lr, bool round_ll)
        {
            // Make a GraphicsPath to draw the rectangle.
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();

            // Upper left corner.
            if (round_ul)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 180, 90);
                point1 = new PointF(rect.X + xradius, rect.Y);
            }
            else point1 = new PointF(rect.X, rect.Y);

            // Top side.
            if (round_ur)
                point2 = new PointF(rect.Right - xradius, rect.Y);
            else
                point2 = new PointF(rect.Right, rect.Y);
            path.AddLine(point1, point2);

            // Upper right corner.
            if (round_ur)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 270, 90);
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else point1 = new PointF(rect.Right, rect.Y);

            // Right side.
            if (round_lr)
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            else
                point2 = new PointF(rect.Right, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower right corner.
            if (round_lr)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius,
                    rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 0, 90);
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else point1 = new PointF(rect.Right, rect.Bottom);

            // Bottom side.
            if (round_ll)
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            else
                point2 = new PointF(rect.X, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower left corner.
            if (round_ll)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 90, 90);
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else point1 = new PointF(rect.X, rect.Bottom);

            // Left side.
            if (round_ul)
                point2 = new PointF(rect.X, rect.Y + yradius);
            else
                point2 = new PointF(rect.X, rect.Y);
            path.AddLine(point1, point2);

            // Join with the start point.
            path.CloseFigure();

            return path;
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmrCheckStatus = new System.Windows.Forms.Timer(this.components);
            this.picVBattery1 = new System.Windows.Forms.PictureBox();
            this.picHBattery1 = new System.Windows.Forms.PictureBox();
            this.picVBattery2 = new System.Windows.Forms.PictureBox();
            this.picHBattery2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picVBattery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHBattery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVBattery2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHBattery2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(12, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(251, 40);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Offline";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrCheckStatus
            // 
            this.tmrCheckStatus.Enabled = true;
            this.tmrCheckStatus.Interval = 5000;
            this.tmrCheckStatus.Tick += new System.EventHandler(this.tmrCheckStatus_Tick);
            // 
            // picVBattery1
            // 
            this.picVBattery1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picVBattery1.Location = new System.Drawing.Point(269, 12);
            this.picVBattery1.Name = "picVBattery1";
            this.picVBattery1.Size = new System.Drawing.Size(40, 80);
            this.picVBattery1.TabIndex = 2;
            this.picVBattery1.TabStop = false;
            // 
            // picHBattery1
            // 
            this.picHBattery1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picHBattery1.Location = new System.Drawing.Point(12, 52);
            this.picHBattery1.Name = "picHBattery1";
            this.picHBattery1.Size = new System.Drawing.Size(80, 40);
            this.picHBattery1.TabIndex = 3;
            this.picHBattery1.TabStop = false;
            // 
            // picVBattery2
            // 
            this.picVBattery2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picVBattery2.Location = new System.Drawing.Point(315, 12);
            this.picVBattery2.Name = "picVBattery2";
            this.picVBattery2.Size = new System.Drawing.Size(40, 80);
            this.picVBattery2.TabIndex = 4;
            this.picVBattery2.TabStop = false;
            // 
            // picHBattery2
            // 
            this.picHBattery2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picHBattery2.Location = new System.Drawing.Point(98, 52);
            this.picHBattery2.Name = "picHBattery2";
            this.picHBattery2.Size = new System.Drawing.Size(80, 40);
            this.picHBattery2.TabIndex = 5;
            this.picHBattery2.TabStop = false;
            // 
            // howto_battery_status2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 106);
            this.Controls.Add(this.picHBattery2);
            this.Controls.Add(this.picVBattery2);
            this.Controls.Add(this.picHBattery1);
            this.Controls.Add(this.picVBattery1);
            this.Controls.Add(this.lblStatus);
            this.Name = "howto_battery_status2_Form1";
            this.Text = "howto_battery_status2";
            this.Load += new System.EventHandler(this.howto_battery_status2_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picVBattery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHBattery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVBattery2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHBattery2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer tmrCheckStatus;
        private System.Windows.Forms.PictureBox picVBattery1;
        private System.Windows.Forms.PictureBox picHBattery1;
        private System.Windows.Forms.PictureBox picVBattery2;
        private System.Windows.Forms.PictureBox picHBattery2;
    }
}

