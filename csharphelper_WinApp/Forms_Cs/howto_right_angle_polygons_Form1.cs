// #define TEST

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
     public partial class howto_right_angle_polygons_Form1:Form
  { 


        public howto_right_angle_polygons_Form1()
        {
            InitializeComponent();
        }

        // The baseline start and end points.
        private Point BaselineStart = new Point(0, 00);
        private Point BaselineEnd = new Point(200, 100);

        // The polygons.
        private List<List<PointF>> Polygons = new List<List<PointF>>();

        // The new polygon while under construction.
        private List<PointF> NewPolygon = null;
        private PointF LastPoint;

#if TEST
        // Dashed lines.
        private PointF DashStart, DashEnd1, DashEnd2;
#endif

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdBackground.ShowDialog() == DialogResult.OK)
            {
                picCanvas.Image = LoadBitmapUnlocked(ofdBackground.FileName);
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

#region Draw Baseline

        // Let the user draw the baseline.
        private void mnuDrawingSetBaseline_Click(object sender, EventArgs e)
        {
            picCanvas.MouseDown += DrawBaseline_MouseDown;
            picCanvas.Cursor = Cursors.Cross;
        }

        private void DrawBaseline_MouseDown(object sender, MouseEventArgs e)
        {
            picCanvas.MouseDown -= DrawBaseline_MouseDown;
            picCanvas.MouseMove += DrawBaseline_MouseMove;
            picCanvas.MouseUp += DrawBaseline_MouseUp;

            BaselineStart = e.Location;
            BaselineEnd = e.Location;
            picCanvas.Refresh();
        }

        private void DrawBaseline_MouseMove(object sender, MouseEventArgs e)
        {
            BaselineEnd = e.Location;
            picCanvas.Refresh();
        }

        private void DrawBaseline_MouseUp(object sender, MouseEventArgs e)
        {
            picCanvas.MouseMove -= DrawBaseline_MouseMove;
            picCanvas.MouseUp -= DrawBaseline_MouseUp;
            picCanvas.Cursor = Cursors.Default;
        }

#endregion Draw Baseline

#region Draw Polygon

        // Let the user draw a polygon.
        private void mnuDrawingDrawPolygon_Click(object sender, EventArgs e)
        {
            NewPolygon = new List<PointF>();

            picCanvas.MouseClick += DrawPolygon_MouseClick;
            picCanvas.MouseMove += DrawPolygon_MouseMove;
            picCanvas.Cursor = Cursors.Cross;
        }

        private void DrawPolygon_MouseClick(object sender, MouseEventArgs e)
        {
            // See if we are done with this polygon.
            if (e.Button == MouseButtons.Right)
            {
                // End this polygon.
                picCanvas.MouseClick -= DrawPolygon_MouseClick;
                picCanvas.MouseMove -= DrawPolygon_MouseMove;
                picCanvas.Cursor = Cursors.Default;

                // Is we have at least four points,
                // save the new polygon.
                if (NewPolygon.Count > 3)
                {
                    SaveNewPolygon();
                }

                // Reset the new polygon.
                NewPolygon = null;

#if TEST
                DashStart = new PointF();
                DashEnd1 = new PointF();
                DashEnd2 = new PointF();
#endif
            }
            else
            {
                // Continue this polygon.
                PointF adjusted_point = AdjustPoint(e.Location);
                NewPolygon.Add(adjusted_point);
                LastPoint = adjusted_point;
            }

            picCanvas.Refresh();
        }

        private void DrawPolygon_MouseMove(object sender, MouseEventArgs e)
        {
            if (NewPolygon.Count == 0) return;
            LastPoint = AdjustPoint(e.Location);
            picCanvas.Refresh();
        }

        // Fix the new polygon's last point so the final
        // segment forms a right angle with the first segment.
        private void SaveNewPolygon()
        {
            NewPolygon[NewPolygon.Count - 1] =
                AdjustPoints(
                    NewPolygon[NewPolygon.Count - 1],
                    NewPolygon[0]);

            Polygons.Add(NewPolygon);
        }

#endregion Draw Polygon

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.Red, 2))
            {
                // Draw the baseline.
                e.Graphics.DrawLine(pen, BaselineStart, BaselineEnd);

                pen.Color = Color.Yellow;
                pen.DashPattern = new float[] { 3, 3 };
                e.Graphics.DrawLine(pen, BaselineStart, BaselineEnd);

                // Draw the defined polygons.
                pen.Color = Color.Blue;
                pen.DashStyle = DashStyle.Solid;
                using (Brush brush = new SolidBrush(Color.FromArgb(128, Color.LightBlue)))
                {
                    foreach (List<PointF> points in Polygons)
                    {
                        e.Graphics.FillPolygon(brush, points.ToArray());
                        e.Graphics.DrawPolygon(pen, points.ToArray());
                    }
                }

                // Draw the new polygon if there is one.
                if (NewPolygon != null)
                {
                    pen.Color = Color.Green;
                    pen.DashStyle = DashStyle.Solid;
                    if (NewPolygon.Count > 1)
                        e.Graphics.DrawLines(pen, NewPolygon.ToArray());
                    e.Graphics.DrawLine(pen,
                        NewPolygon[NewPolygon.Count - 1],
                        LastPoint);
                    foreach (PointF point in NewPolygon)
                        e.Graphics.FillEllipse(Brushes.Red,
                            point.X - 3, point.Y - 3, 6, 6);
                }
            }

#if TEST
            // Draw dashed lines if they are defined.
            if (DashStart != DashEnd1)
            {
                using (Pen pen = new Pen(Color.Blue, 1))
                {
                    pen.DashPattern = new float[] { 5, 5 };
                    e.Graphics.DrawLine(pen, DashStart, DashEnd1);
                    e.Graphics.DrawLine(pen, DashStart, DashEnd2);
                }
            }
#endif
        }

        private float Distance(PointF point1, PointF point2)
        {
            float dx = point2.X - point1.X;
            float dy = point2.Y - point1.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        // Adjust this point so it is perpendicular
        // to the previous point in the new polygon.
        private PointF AdjustPoint(PointF point)
        {
            if (NewPolygon == null) return point;
            if (NewPolygon.Count == 0) return point;

            // Adjust the point to the last point
            // that is currently in the new polygon.
            return AdjustPoints(point, NewPolygon[NewPolygon.Count - 1]);
        }

        // Adjust a point so it is perpendicular
        // to a reference point.
        private PointF AdjustPoints(PointF point_to_adjust, PointF reference_point)
        {
            if (NewPolygon == null) return point_to_adjust;
            if (NewPolygon.Count == 0) return point_to_adjust;

            // Transform the last point in the new polygon
            // and this point.
            Matrix matrix = GetTransform();
            PointF[] points =
            {
                reference_point,
                point_to_adjust,
            };
            matrix.TransformPoints(points);

#if TEST
            PointF[] dash_points =
            {
                new PointF(points[1].X, points[0].Y),
                new PointF(points[0].X, points[1].Y),
            };
#endif

            // Fix the transformed point.
            float dx = Math.Abs(points[1].X - points[0].X);
            float dy = Math.Abs(points[1].Y - points[0].Y);
            if (dx <= dy)
                points[1].X = points[0].X;
            else
                points[1].Y = points[0].Y;

            // Untransform the result.
            matrix.Invert();
            matrix.TransformPoints(points);

#if TEST
            matrix.TransformPoints(dash_points);
            DashEnd1 = dash_points[0];
            DashEnd2 = dash_points[1];
            DashStart = point_to_adjust;
#endif

            return points[1];
        }

        // Return a transformation matrix that rotates
        // the baseline so it is parallel to the X axis.
        private Matrix GetTransform()
        {
            float dx = BaselineStart.X - BaselineEnd.X;
            float dy = BaselineStart.Y - BaselineEnd.Y;
            double angle = -Math.Atan2(dy, dx) * 180 / Math.PI;
            Matrix matrix = new Matrix();
            matrix.Rotate((float)angle);
            return matrix;
        }

        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
            }
        }

        // Clear the background image and polygons.
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            picCanvas.Image = null;
            Polygons.Clear();
            picCanvas.Refresh();
        }

        // Clear the polygons.
        private void mnuDrawingClearPolygons_Click(object sender, EventArgs e)
        {
            Polygons.Clear();
            picCanvas.Refresh();
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDrawingSetBaseline = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDrawingDrawPolygon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDrawingClearPolygons = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdBackground = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Cursor = System.Windows.Forms.Cursors.Default;
            this.picCanvas.Location = new System.Drawing.Point(12, 27);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 222);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.drawToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileNew,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(155, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuFileNew.Size = new System.Drawing.Size(155, 22);
            this.mnuFileNew.Text = "&New";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(155, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDrawingSetBaseline,
            this.mnuDrawingDrawPolygon,
            this.toolStripMenuItem2,
            this.mnuDrawingClearPolygons});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.drawToolStripMenuItem.Text = "&Drawing";
            // 
            // mnuDrawingSetBaseline
            // 
            this.mnuDrawingSetBaseline.Name = "mnuDrawingSetBaseline";
            this.mnuDrawingSetBaseline.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.mnuDrawingSetBaseline.Size = new System.Drawing.Size(195, 22);
            this.mnuDrawingSetBaseline.Text = "&Set Baseline";
            this.mnuDrawingSetBaseline.Click += new System.EventHandler(this.mnuDrawingSetBaseline_Click);
            // 
            // mnuDrawingDrawPolygon
            // 
            this.mnuDrawingDrawPolygon.Name = "mnuDrawingDrawPolygon";
            this.mnuDrawingDrawPolygon.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuDrawingDrawPolygon.Size = new System.Drawing.Size(195, 22);
            this.mnuDrawingDrawPolygon.Text = "&Draw Polygon";
            this.mnuDrawingDrawPolygon.Click += new System.EventHandler(this.mnuDrawingDrawPolygon_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuDrawingClearPolygons
            // 
            this.mnuDrawingClearPolygons.Name = "mnuDrawingClearPolygons";
            this.mnuDrawingClearPolygons.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuDrawingClearPolygons.Size = new System.Drawing.Size(195, 22);
            this.mnuDrawingClearPolygons.Text = "&Clear Polygons";
            this.mnuDrawingClearPolygons.Click += new System.EventHandler(this.mnuDrawingClearPolygons_Click);
            // 
            // ofdBackground
            // 
            this.ofdBackground.Filter = "Picture Files|  *.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // howto_right_angle_polygons_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_right_angle_polygons_Form1";
            this.Text = "howto_right_angle_polygons";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.OpenFileDialog ofdBackground;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDrawingSetBaseline;
        private System.Windows.Forms.ToolStripMenuItem mnuDrawingDrawPolygon;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuDrawingClearPolygons;
    }
}

