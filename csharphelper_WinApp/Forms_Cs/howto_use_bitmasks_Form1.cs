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
     public partial class howto_use_bitmasks_Form1:Form
  { 


        public howto_use_bitmasks_Form1()
        {
            InitializeComponent();
        }

        // Anchor the PictureBox.
        private void howto_use_bitmasks_Form1_Load(object sender, EventArgs e)
        {
            // Anchor the PictureBox at the bottom and right.
            picAnchor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
            this.picAnchor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAnchor)).BeginInit();
            this.SuspendLayout();
            // 
            // picAnchor
            // 
            this.picAnchor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picAnchor.BackColor = System.Drawing.Color.LightGreen;
            this.picAnchor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picAnchor.Location = new System.Drawing.Point(12, 12);
            this.picAnchor.Name = "picAnchor";
            this.picAnchor.Size = new System.Drawing.Size(210, 90);
            this.picAnchor.TabIndex = 1;
            this.picAnchor.TabStop = false;
            // 
            // howto_use_bitmasks_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 114);
            this.Controls.Add(this.picAnchor);
            this.Name = "howto_use_bitmasks_Form1";
            this.Text = "howto_use_bitmasks";
            this.Load += new System.EventHandler(this.howto_use_bitmasks_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAnchor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picAnchor;
    }
}

