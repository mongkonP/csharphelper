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
     public partial class howto_map_closeup_Form1:Form
  { 


        public howto_map_closeup_Form1()
        {
            InitializeComponent();
        }

        private const int ScaleFactor = 2;
        private const int SmallRadius = 25;
        private const int BigRadius = SmallRadius * ScaleFactor;
        private const int BigDiameter = 2 * BigRadius;

        private int OriginalWid, OriginalHgt;
        private Bitmap BigMap, OriginalMap, ModifiedMap, MapPatch;
        private Rectangle PatchRect = new Rectangle(0, 0, BigDiameter, BigDiameter);

        private Rectangle SrcRect = new Rectangle(0, 0, BigDiameter, BigDiameter);
        private Rectangle DestRect = new Rectangle(0, 0, BigDiameter, BigDiameter);

        // Save the original small map image.
        private void howto_map_closeup_Form1_Load(object sender, EventArgs e)
        {
            OriginalWid = picMap.Image.Width;
            OriginalHgt = picMap.Image.Height;

            // Save the big map.
            BigMap = (Bitmap)picHidden.Image;

            // Save the original map.
            OriginalMap = (Bitmap)picMap.Image;

            // Make a copy to display.
            ModifiedMap = (Bitmap)(OriginalMap.Clone());

            // Make a patch area.
            MapPatch = new Bitmap(BigDiameter, BigDiameter);
        }

            // Prepare the new map image.
            private void picMap_MouseMove(object sender, MouseEventArgs e)
            {
                // Adjust where the source and destination bitmaps are.
                SrcRect.X = e.X * ScaleFactor - BigRadius;
                SrcRect.Y = e.Y * ScaleFactor - BigRadius;
                DestRect.X = e.X - BigRadius;
                DestRect.Y = e.Y - BigRadius;

                // Make a piece of the small map with a transparent hole in it.
                using (Graphics gr = Graphics.FromImage(MapPatch))
                {
                    // Draw the small map image into the patch.
                    gr.DrawImage(OriginalMap, PatchRect, DestRect, GraphicsUnit.Pixel);

                    // Make a transparent hole in the patch.
                    using (SolidBrush br = new SolidBrush(Color.FromArgb(255, 1, 2, 3)))
                    {
                        gr.FillEllipse(br, PatchRect);
                        MapPatch.MakeTransparent(br.Color);
                    }
                }

                using (Graphics gr = Graphics.FromImage(ModifiedMap))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;

                    // Restore the original map.
                    gr.DrawImage(OriginalMap, 0, 0, OriginalWid, OriginalHgt);

                    // Copy a chunk of the big image into it.
                    gr.DrawImage(BigMap, DestRect, SrcRect, GraphicsUnit.Pixel);

                    // Draw the patch to make the closeup round.
                    gr.DrawImage(MapPatch, DestRect, PatchRect, GraphicsUnit.Pixel);

                    // Outline the area.
                    gr.DrawEllipse(Pens.Blue, DestRect);

                    // Display the result.
                    picMap.Image = ModifiedMap;
                }
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
            this.picHidden = new System.Windows.Forms.PictureBox();
            this.picMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHidden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.SuspendLayout();
            // 
            // picHidden
            // 
            this.picHidden.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picHidden.Image = Properties.Resources.usmap;
            this.picHidden.Location = new System.Drawing.Point(222, 180);
            this.picHidden.Name = "picHidden";
            this.picHidden.Size = new System.Drawing.Size(1104, 708);
            this.picHidden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHidden.TabIndex = 4;
            this.picHidden.TabStop = false;
            this.picHidden.Visible = false;
            // 
            // picMap
            // 
            this.picMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMap.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picMap.Image = Properties.Resources.usmapsmall;
            this.picMap.Location = new System.Drawing.Point(11, 12);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(554, 356);
            this.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMap.TabIndex = 5;
            this.picMap.TabStop = false;
            this.picMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseMove);
            // 
            // howto_map_closeup_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 378);
            this.Controls.Add(this.picHidden);
            this.Controls.Add(this.picMap);
            this.Name = "howto_map_closeup_Form1";
            this.Text = "howto_map_closeup";
            this.Load += new System.EventHandler(this.howto_map_closeup_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHidden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picHidden;
        internal System.Windows.Forms.PictureBox picMap;
    }
}

