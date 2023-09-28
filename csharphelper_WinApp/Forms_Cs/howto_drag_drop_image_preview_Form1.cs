using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_drag_drop_image_preview_Form1:Form
  { 


        public howto_drag_drop_image_preview_Form1()
        {
            InitializeComponent();
        }

        // Set the drop target PictureBox's AllowDrop property at run time.
        // It is unavailable in the Properties window and doesn't
        // even show up in IntelliSense!
        private void howto_drag_drop_image_preview_Form1_Load(object sender, EventArgs e)
        {
            picDropTarget.AllowDrop = true;
        }

        // Start the drag.
        private void picDragSource_MouseDown(object sender, MouseEventArgs e)
        {
            // Start the drag if it's the right mouse button.
            if (e.Button == MouseButtons.Right)
            {
                PictureBox source = sender as PictureBox;
                picDragSource.DoDragDrop(source.Image, DragDropEffects.Copy);
            }
        }

        // The current image during a drag.
        private Image OldImage = null;

        // Allow a copy of an image.
        private void picDropTarget_DragEnter(object sender, DragEventArgs e)
        {
            // See if this is a copy and the data includes an image.
            if (e.Data.GetDataPresent(DataFormats.Bitmap) &&
                (e.AllowedEffect & DragDropEffects.Copy) != 0)
            {
                // Allow this.
                e.Effect = DragDropEffects.Copy;

                // Save the current image.
                OldImage = picDropTarget.Image;

                // Display the preview image.
                Bitmap bm = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
                Bitmap copy_bm = (Bitmap)bm.Clone();
                using (Graphics gr = Graphics.FromImage(copy_bm))
                {
                    // Cover with translucent white.
                    using (SolidBrush br = new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                    {
                        gr.FillRectangle(br, 0, 0, bm.Width, bm.Height);
                    }
                }
                picDropTarget.Image = copy_bm;
            }
            else
            {
                // Don't allow any other drop.
                e.Effect = DragDropEffects.None;
            }
        }

        // Remove the drag enter image.
        private void picDropTarget_DragLeave(object sender, EventArgs e)
        {
            // Restore the saved image.
            picDropTarget.Image = OldImage;
        }

        // Accept the drop.
        private void picDropTarget_DragDrop(object sender, DragEventArgs e)
        {
            Bitmap bm = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            picDropTarget.Image = bm;
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picDragSource2 = new System.Windows.Forms.PictureBox();
            this.picDropTarget = new System.Windows.Forms.PictureBox();
            this.picDragSource = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDragSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDropTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDragSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Drop Target:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Drag Sources:";
            // 
            // picDragSource2
            // 
            this.picDragSource2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picDragSource2.Image = Properties.Resources.dog_small;
            this.picDragSource2.Location = new System.Drawing.Point(292, 25);
            this.picDragSource2.Name = "picDragSource2";
            this.picDragSource2.Size = new System.Drawing.Size(210, 139);
            this.picDragSource2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDragSource2.TabIndex = 8;
            this.picDragSource2.TabStop = false;
            this.picDragSource2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDragSource_MouseDown);
            // 
            // picDropTarget
            // 
            this.picDropTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picDropTarget.Location = new System.Drawing.Point(12, 192);
            this.picDropTarget.Name = "picDropTarget";
            this.picDropTarget.Size = new System.Drawing.Size(100, 100);
            this.picDropTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDropTarget.TabIndex = 6;
            this.picDropTarget.TabStop = false;
            this.picDropTarget.DragDrop += new System.Windows.Forms.DragEventHandler(this.picDropTarget_DragDrop);
            this.picDropTarget.DragLeave += new System.EventHandler(this.picDropTarget_DragLeave);
            this.picDropTarget.DragEnter += new System.Windows.Forms.DragEventHandler(this.picDropTarget_DragEnter);
            // 
            // picDragSource
            // 
            this.picDragSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picDragSource.Image = Properties.Resources.banner;
            this.picDragSource.Location = new System.Drawing.Point(12, 25);
            this.picDragSource.Name = "picDragSource";
            this.picDragSource.Size = new System.Drawing.Size(274, 88);
            this.picDragSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDragSource.TabIndex = 4;
            this.picDragSource.TabStop = false;
            this.picDragSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDragSource_MouseDown);
            // 
            // howto_drag_drop_image_preview_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 349);
            this.Controls.Add(this.picDragSource2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picDropTarget);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picDragSource);
            this.Name = "howto_drag_drop_image_preview_Form1";
            this.Text = "howto_drag_drop_image_preview";
            this.Load += new System.EventHandler(this.howto_drag_drop_image_preview_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDragSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDropTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDragSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picDropTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picDragSource;
        private System.Windows.Forms.PictureBox picDragSource2;
    }
}

