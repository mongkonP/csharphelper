using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// At design time:
//   Set the ImageList's ImageSize properties to the correct values:
//      imlSmallIcons.ImageSize = 32,32
//      imlLargeIcons.ImageSize = 64,64
//   Set the ImageList's ColorDepth properties to the correct values:
//      imlSmallIcons.ColorDepth = Depth32bit
//      imlLargeIcons.ColorDepth = Depth32bit

using System.Drawing.Drawing2D;

 

using howto_listview_custom_icons;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_listview_custom_icons_Form1:Form
  { 


        public howto_listview_custom_icons_Form1()
        {
            InitializeComponent();
        }

        private void howto_listview_custom_icons_Form1_Load(object sender, EventArgs e)
        {
            // Select the first style.
            cboStyle.SelectedIndex = 0;

            // Initialize the ListView.
            lvwBooks.SmallImageList = imlSmallIcons;
            lvwBooks.LargeImageList = imlLargeIcons;

            // Make the column headers.
            lvwBooks.MakeColumnHeaders(
                "Title", 230, HorizontalAlignment.Left,
                "URL", 220, HorizontalAlignment.Left,
                "ISBN", 130, HorizontalAlignment.Left,
                "Picture", 230, HorizontalAlignment.Left,
                "Pages", 50, HorizontalAlignment.Right,
                "Year", 60, HorizontalAlignment.Right);

            // Create images.
            RectangleF small_rect = new RectangleF(0, 0, 32, 32);
            RectangleF large_rect = new RectangleF(3, 3, 58, 58);
            imlSmallIcons.Images.Clear();
            imlLargeIcons.Images.Clear();
            using (Pen small_pen = new Pen(Color.Blue, 2))
            {
                using (Pen large_pen = new Pen(Color.Blue, 3))
                {
                    large_pen.LineJoin = LineJoin.Round;
                    for (int i = 1; i <= 7; i++)
                    {
                        Bitmap bm32x32 = new Bitmap(32, 32);
                        using (Graphics gr = Graphics.FromImage(bm32x32))
                        {
                            gr.SmoothingMode = SmoothingMode.AntiAlias;
                            gr.Clear(Color.Transparent);
                            DrawStar(gr, small_rect, i + 3, small_pen, Brushes.Yellow);
                            // Save the image using i as the image's key.
                            imlSmallIcons.Images.Add(i.ToString(), bm32x32);
                        }

                        Bitmap bm64x64 = new Bitmap(64, 64);
                        using (Graphics gr = Graphics.FromImage(bm64x64))
                        {
                            gr.Clear(Color.Transparent);
                            gr.SmoothingMode = SmoothingMode.AntiAlias;
                            DrawStar(gr, large_rect, i + 3, large_pen, Brushes.Yellow);
                            // Save the image using i as the image's key.
                            imlLargeIcons.Images.Add(i.ToString(), bm64x64);
                        }
                    }
                }
            }

            // Add data rows.
            lvwBooks.AddRow("1", "WPF 3d", "http://www.csharphelper.com/wpf3d.html", "978-1983905964", "http://www.csharphelper.com/wpf3d_350_429.jpg", "430", "2018");
            lvwBooks.AddRow("2", "The C# Helper Top 100", "http://www.csharphelper.com/top100.htm", "978-1546886716", "http://www.csharphelper.com/top100_350_433.jpg", "380", "2017");
            lvwBooks.AddRow("3", "Interview Puzzles Dissected", "http://www.csharphelper.com/puzzles.htm", "978-1539504887", "http://www.csharphelper.com/interview_puzzles_350_433.jpg", "300", "2016");
            lvwBooks.AddRow("4", "C# 24-Hour Trainer, 2e", "http://tinyurl.com/n2a5797", "978-1-119-06566-1", "http://www.csharphelper.com/csharp24hr_2e_79x100.jpg", "600", "2015");
            lvwBooks.AddRow("5", "Beginning Software Engineering", "http://tinyurl.com/pz7bavo", "978-1-118-96914-4", "http://tinyurl.com/y7zusrct", "480", "2015");
            lvwBooks.AddRow("6", "Essential Algorithms", "http://tinyurl.com/y9uqajqv", "978-1-118-61210-1", "http://tinyurl.com/y84d2jgp", "624", "2013");
            lvwBooks.AddRow("7", "Beginning Database Design Solutions", "http://www.vb-helper.com/db_design.htm", "978-0-470-38549-4", "http://www.vb-helper.com/db_design.jpg", "522", "2008");
        }

        // Change the ListView's display style.
        private void cboStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboStyle.Text)
            {
                case "Large Icons":
                    lvwBooks.View = View.LargeIcon;
                    break;
                case "Small Icons":
                    lvwBooks.View = View.SmallIcon;
                    break;
                case "List":
                    lvwBooks.View = View.List;
                    break;
                case "Tile":
                    lvwBooks.View = View.Tile;
                    break;
                case "Details":
                    lvwBooks.View = View.Details;
                    break;
            }
        }

        // Draw a star with the indicated number of points.
        private void DrawStar(Graphics gr, RectangleF rect, int num_points, Pen pen, Brush brush)
        {
            // Compute geometry.
            float cx = (rect.Left + rect.Right) / 2f;
            float cy = (rect.Top + rect.Bottom) / 2f;
            float rx1 = rect.Width / 2f - 1;
            float ry1 = rect.Height / 2f - 1;
            float rx2 = rx1 / 3f;
            float ry2 = ry1 / 3f;

            // Generate the star's points.
            double theta = -Math.PI / 2;
            double dtheta = Math.PI / num_points;
            List<PointF> points = new List<PointF>();
            for (int i = 0; i < num_points; i++)
            {
                points.Add(new PointF(
                    (float)(cx + rx1 * Math.Cos(theta)),
                    (float)(cy + ry1 * Math.Sin(theta))));
                theta += dtheta;
                points.Add(new PointF(
                    (float)(cx + rx2 * Math.Cos(theta)),
                    (float)(cy + ry2 * Math.Sin(theta))));
                theta += dtheta;
            }

            // Draw.
            PointF[] point_array = points.ToArray();
            gr.FillPolygon(brush, point_array);
            gr.DrawPolygon(pen, point_array);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_listview_custom_icons_Form1));
            this.cboStyle = new System.Windows.Forms.ComboBox();
            this.lvwBooks = new System.Windows.Forms.ListView();
            this.imlSmallIcons = new System.Windows.Forms.ImageList(this.components);
            this.imlLargeIcons = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboStyle
            // 
            this.cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStyle.FormattingEnabled = true;
            this.cboStyle.Items.AddRange(new object[] {
            "Large Icons",
            "Small Icons",
            "List",
            "Tile",
            "Details"});
            this.cboStyle.Location = new System.Drawing.Point(51, 12);
            this.cboStyle.Name = "cboStyle";
            this.cboStyle.Size = new System.Drawing.Size(121, 21);
            this.cboStyle.TabIndex = 14;
            this.cboStyle.SelectedIndexChanged += new System.EventHandler(this.cboStyle_SelectedIndexChanged);
            // 
            // lvwBooks
            // 
            this.lvwBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBooks.Location = new System.Drawing.Point(12, 39);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(780, 183);
            this.lvwBooks.TabIndex = 15;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            // 
            // imlSmallIcons
            // 
            this.imlSmallIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmallIcons.ImageStream")));
            this.imlSmallIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmallIcons.Images.SetKeyName(0, "1_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(1, "2_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(2, "3_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(3, "4_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(4, "5_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(5, "6_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(6, "7_32x32.png");
            // 
            // imlLargeIcons
            // 
            this.imlLargeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLargeIcons.ImageStream")));
            this.imlLargeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlLargeIcons.Images.SetKeyName(0, "1_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(1, "2_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(2, "3_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(3, "4_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(4, "5_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(5, "6_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(6, "7_64x64.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "View:";
            // 
            // howto_listview_custom_icons_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 234);
            this.Controls.Add(this.cboStyle);
            this.Controls.Add(this.lvwBooks);
            this.Controls.Add(this.label1);
            this.Name = "howto_listview_custom_icons_Form1";
            this.Text = "howto_listview_custom_icons";
            this.Load += new System.EventHandler(this.howto_listview_custom_icons_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboStyle;
        private System.Windows.Forms.ListView lvwBooks;
        internal System.Windows.Forms.ImageList imlSmallIcons;
        internal System.Windows.Forms.ImageList imlLargeIcons;
        private System.Windows.Forms.Label label1;
    }
}

