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
     public partial class howto_drag_scroll_image_Form1:Form
  { 


        public howto_drag_scroll_image_Form1()
        {
            InitializeComponent();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Bitmap OriginalImage;
        private float CurrentScale;
        private Bitmap VisibleImage = null;
        private Graphics VisibleGraphics = null;

        // Upper left corner of the image in the PictureBox.
        private int PicX = 0, PicY = 0;

        // Initially display at full scale.
        private void howto_drag_scroll_image_Form1_Load(object sender, EventArgs e)
        {
            // Use a grabbing hand cursor.
            picMap.Cursor = new Cursor("hand2.cur");

            // Get the map image.
            OriginalImage = Properties.Resources.Map;

            // Get ready to draw.
            PrepareGraphics();

            // Start at full scale.
            mnuScale_Click(mnuScaleFull, null);
        }

        // Make a display Bitmap and Graphics.
        private void howto_drag_scroll_image_Form1_Resize(object sender, EventArgs e)
        {
            PrepareGraphics();
            DrawMap();
        }

        private void PrepareGraphics()
        {
            // Skip it if we've been minimized.
            if ((picMap.ClientSize.Width == 0) ||
                (picMap.ClientSize.Height == 0)) return;

            // Free old resources.
            if (VisibleGraphics != null)
            {
                picMap.Image = null;
                VisibleGraphics.Dispose();
                VisibleImage.Dispose();
            }

            // Make the new Bitmap and Graphics.
            VisibleImage = new Bitmap(
                picMap.ClientSize.Width,
                picMap.ClientSize.Height);
            VisibleGraphics = Graphics.FromImage(VisibleImage);
            VisibleGraphics.InterpolationMode = InterpolationMode.High;

            // Display the Bitmap.
            picMap.Image = VisibleImage;
        }

        // Set the scale.
        private void mnuScale_Click(object sender, EventArgs e)
        {
            // Check the selected scale item.
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            foreach (ToolStripMenuItem menu_item in mnuScale.DropDownItems)
                menu_item.Checked = (menu_item == item);

            // Set the selected scale.
            CurrentScale = float.Parse(item.Tag.ToString());

            // Draw.
            DrawMap();
        }

        // Set the PictureBox's position.
        private void SetOrigin()
        {
            // Keep x and y within bounds.
            float scaled_width = CurrentScale * OriginalImage.Width;
            int xmin = (int)(picMap.ClientSize.Width - scaled_width);
            if (xmin > 0) xmin = 0;
            if (PicX < xmin) PicX = xmin;
            else if (PicX > 0) PicX = 0;

            float scaled_height = CurrentScale * OriginalImage.Height;
            int ymin = (int)(picMap.ClientSize.Height - scaled_height);
            if (ymin > 0) ymin = 0;
            if (PicY < ymin) PicY = ymin;
            else if (PicY > 0) PicY = 0;
        }

        // Draw the image at the correct scale and location.
        private void DrawMap()
        {
            // Validate PicX and PicY.
            SetOrigin();

            // Get the destination area.
            float scaled_width = CurrentScale * OriginalImage.Width;
            float scaled_height = CurrentScale * OriginalImage.Height;
            PointF[] dest_points =
            {
                new PointF(PicX, PicY),
                new PointF(PicX + scaled_width, PicY),
                new PointF(PicX, PicY + scaled_height),
            };

            // Draw the whole image.
            RectangleF source_rect = new RectangleF(
                0, 0, OriginalImage.Width, OriginalImage.Height);

            // Draw.
            VisibleGraphics.Clear(picMap.BackColor);
            VisibleGraphics.DrawImage(OriginalImage,
                dest_points, source_rect, GraphicsUnit.Pixel);

            // Update the display.
            picMap.Refresh();
        }
    
        // Let the user drag the image around.
        private bool Dragging = false;
        private int LastX, LastY;

        private void picMap_MouseDown(object sender, MouseEventArgs e)
        {
            LastX = e.X;
            LastY = e.Y;
            Dragging = true;
        }

        private void picMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Dragging) return;
            
            PicX += e.X - LastX;
            PicY += e.Y - LastY;
            LastX = e.X;
            LastY = e.Y;

            DrawMap();
        }

        private void picMap_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScaleFull = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScaleHalf = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScaleQuarter = new System.Windows.Forms.ToolStripMenuItem();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuScale});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(319, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(92, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuScale
            // 
            this.mnuScale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScaleFull,
            this.mnuScaleHalf,
            this.mnuScaleQuarter});
            this.mnuScale.Name = "mnuScale";
            this.mnuScale.Size = new System.Drawing.Size(46, 20);
            this.mnuScale.Text = "&Scale";
            // 
            // mnuScaleFull
            // 
            this.mnuScaleFull.Name = "mnuScaleFull";
            this.mnuScaleFull.Size = new System.Drawing.Size(123, 22);
            this.mnuScaleFull.Tag = "1";
            this.mnuScaleFull.Text = "&Full Scale";
            this.mnuScaleFull.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScaleHalf
            // 
            this.mnuScaleHalf.Name = "mnuScaleHalf";
            this.mnuScaleHalf.Size = new System.Drawing.Size(123, 22);
            this.mnuScaleHalf.Tag = "0.5";
            this.mnuScaleHalf.Text = "1/&2";
            this.mnuScaleHalf.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScaleQuarter
            // 
            this.mnuScaleQuarter.Name = "mnuScaleQuarter";
            this.mnuScaleQuarter.Size = new System.Drawing.Size(123, 22);
            this.mnuScaleQuarter.Tag = "0.25";
            this.mnuScaleQuarter.Text = "1/&4";
            this.mnuScaleQuarter.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // picMap
            // 
            this.picMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMap.Location = new System.Drawing.Point(12, 27);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(295, 222);
            this.picMap.TabIndex = 0;
            this.picMap.TabStop = false;
            this.picMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseMove);
            this.picMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseDown);
            this.picMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseUp);
            // 
            // howto_drag_scroll_image_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 261);
            this.Controls.Add(this.picMap);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_drag_scroll_image_Form1";
            this.Text = "howto_drag_scroll_image";
            this.Load += new System.EventHandler(this.howto_drag_scroll_image_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_drag_scroll_image_Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuScale;
        private System.Windows.Forms.ToolStripMenuItem mnuScaleFull;
        private System.Windows.Forms.ToolStripMenuItem mnuScaleHalf;
        private System.Windows.Forms.ToolStripMenuItem mnuScaleQuarter;
        private System.Windows.Forms.PictureBox picMap;
    }
}

