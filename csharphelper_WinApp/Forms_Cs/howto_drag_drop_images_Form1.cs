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
     public partial class howto_drag_drop_images_Form1:Form
  { 


        public howto_drag_drop_images_Form1()
        {
            InitializeComponent();
        }

        // Set the drop target PictureBox's AllowDrop property at run time.
        // It is unavailable in the Properties window and doesn't
        // even show up in IntelliSense!
        private void howto_drag_drop_images_Form1_Load(object sender, EventArgs e)
        {
            picDropTarget.AllowDrop = true;
        }

        // Start the drag.
        private void picDragSource_MouseDown(object sender, MouseEventArgs e)
        {
            // Start the drag if it's the right mouse button.
            if (e.Button == MouseButtons.Right)
            {
                picDragSource.DoDragDrop(picDragSource.Image, DragDropEffects.Copy);
            }
        }

        // Allow a copy of an image.
        private void picDropTarget_DragEnter(object sender, DragEventArgs e)
        {
            // See if this is a copy and the data includes an image.
            if (e.Data.GetDataPresent(DataFormats.Bitmap) &&
                (e.AllowedEffect & DragDropEffects.Copy) != 0)
            {
                // Allow this.
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                // Don't allow any other drop.
                e.Effect = DragDropEffects.None;
            }
        }

        // Accept the drop.
        private void picDropTarget_DragDrop(object sender, DragEventArgs e)
        {
            picDropTarget.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
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
            this.picDragSource = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picDropTarget = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDragSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDropTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // picDragSource
            // 
            this.picDragSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picDragSource.Image = Properties.Resources.banner;
            this.picDragSource.Location = new System.Drawing.Point(12, 25);
            this.picDragSource.Name = "picDragSource";
            this.picDragSource.Size = new System.Drawing.Size(274, 88);
            this.picDragSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDragSource.TabIndex = 0;
            this.picDragSource.TabStop = false;
            this.picDragSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDragSource_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Drag Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Drop Target:";
            // 
            // picDropTarget
            // 
            this.picDropTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picDropTarget.Location = new System.Drawing.Point(12, 144);
            this.picDropTarget.Name = "picDropTarget";
            this.picDropTarget.Size = new System.Drawing.Size(100, 100);
            this.picDropTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDropTarget.TabIndex = 2;
            this.picDropTarget.TabStop = false;
            this.picDropTarget.DragDrop += new System.Windows.Forms.DragEventHandler(this.picDropTarget_DragDrop);
            this.picDropTarget.DragEnter += new System.Windows.Forms.DragEventHandler(this.picDropTarget_DragEnter);
            // 
            // howto_drag_drop_images_Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 256);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picDropTarget);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picDragSource);
            this.Name = "howto_drag_drop_images_Form1";
            this.Text = "howto_drag_drop_images";
            this.Load += new System.EventHandler(this.howto_drag_drop_images_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDragSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDropTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDragSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picDropTarget;
    }
}

