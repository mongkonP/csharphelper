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
     public partial class howto_use_tag_Form1:Form
  { 


        public howto_use_tag_Form1()
        {
            InitializeComponent();
        }

        // Use the selected color for the form's background.
        private void btnColor_Click(object sender, EventArgs e)
        {
            // Get the sender as a button.
            Button btn = sender as Button;

            // Convert its Tag value into a color.
            this.BackColor = Color.FromName(btn.Tag.ToString());
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
            this.btnPink = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPink
            // 
            this.btnPink.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPink.Location = new System.Drawing.Point(24, 12);
            this.btnPink.Name = "btnPink";
            this.btnPink.Size = new System.Drawing.Size(75, 23);
            this.btnPink.TabIndex = 0;
            this.btnPink.Tag = "Pink";
            this.btnPink.Text = "Pink";
            this.btnPink.UseVisualStyleBackColor = true;
            this.btnPink.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBlue.Location = new System.Drawing.Point(186, 12);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(75, 23);
            this.btnBlue.TabIndex = 1;
            this.btnBlue.Tag = "LightBlue";
            this.btnBlue.Text = "Blue";
            this.btnBlue.UseVisualStyleBackColor = true;
            this.btnBlue.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGreen.Location = new System.Drawing.Point(105, 12);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(75, 23);
            this.btnGreen.TabIndex = 2;
            this.btnGreen.Tag = "LightGreen";
            this.btnGreen.Text = "Green";
            this.btnGreen.UseVisualStyleBackColor = true;
            this.btnGreen.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // howto_use_tag_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 114);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnPink);
            this.Name = "howto_use_tag_Form1";
            this.Text = "howto_use_tag";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPink;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnGreen;
    }
}

