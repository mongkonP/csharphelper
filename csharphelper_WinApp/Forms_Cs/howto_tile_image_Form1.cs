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
     public partial class howto_tile_image_Form1:Form
  { 


        public howto_tile_image_Form1()
        {
            InitializeComponent();
        }

        // Tile the image.
        private void picTile_Paint(object sender, PaintEventArgs e)
        {
            using (TextureBrush brush = new TextureBrush(Properties.Resources.Smiley))
            {
                e.Graphics.FillRectangle(brush, picTile.ClientRectangle);
            }
        }

        // Refresh the PictureBox.
        private void howto_tile_image_Form1_Resize(object sender, EventArgs e)
        {
            picTile.Refresh();
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
            this.picTile = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTile)).BeginInit();
            this.SuspendLayout();
            // 
            // picTile
            // 
            this.picTile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTile.Location = new System.Drawing.Point(12, 12);
            this.picTile.Name = "picTile";
            this.picTile.Size = new System.Drawing.Size(260, 237);
            this.picTile.TabIndex = 0;
            this.picTile.TabStop = false;
            this.picTile.Paint += new System.Windows.Forms.PaintEventHandler(this.picTile_Paint);
            // 
            // howto_tile_image_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picTile);
            this.Name = "howto_tile_image_Form1";
            this.Text = "howto_tile_image";
            this.Resize += new System.EventHandler(this.howto_tile_image_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picTile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picTile;
    }
}

