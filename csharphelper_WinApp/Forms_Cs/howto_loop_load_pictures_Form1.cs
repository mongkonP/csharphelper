using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_loop_load_pictures_Form1:Form
  { 


        public howto_loop_load_pictures_Form1()
        {
            InitializeComponent();
        }

        private void howto_loop_load_pictures_Form1_Load(object sender, EventArgs e)
        {
            string dirname = Path.GetFullPath(
                Path.Combine(Application.StartupPath, @"..\..\"));

            // Make an array holding the PictureBoxes.
            PictureBox[] pics = { PictureBox1, PictureBox2, PictureBox3, PictureBox4 };

            // Load the pictures in a loop.
            for (int i = 0; i < pics.Length; i++)
            {
                string filename = dirname + "pic" + i.ToString() + ".png";
                using (Bitmap bm = new Bitmap(filename))
                {
                    pics[i].Image = (Bitmap)bm.Clone();
                }
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
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            this.FlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.Controls.Add(this.PictureBox1);
            this.FlowLayoutPanel1.Controls.Add(this.PictureBox2);
            this.FlowLayoutPanel1.Controls.Add(this.PictureBox3);
            this.FlowLayoutPanel1.Controls.Add(this.PictureBox4);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(513, 167);
            this.FlowLayoutPanel1.TabIndex = 5;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBox1.Location = new System.Drawing.Point(3, 3);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(100, 50);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // PictureBox2
            // 
            this.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBox2.Location = new System.Drawing.Point(109, 3);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(100, 50);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox2.TabIndex = 1;
            this.PictureBox2.TabStop = false;
            // 
            // PictureBox3
            // 
            this.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBox3.Location = new System.Drawing.Point(215, 3);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(100, 50);
            this.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox3.TabIndex = 2;
            this.PictureBox3.TabStop = false;
            // 
            // PictureBox4
            // 
            this.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBox4.Location = new System.Drawing.Point(321, 3);
            this.PictureBox4.Name = "PictureBox4";
            this.PictureBox4.Size = new System.Drawing.Size(100, 50);
            this.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox4.TabIndex = 3;
            this.PictureBox4.TabStop = false;
            // 
            // howto_loop_load_pictures_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 167);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Name = "howto_loop_load_pictures_Form1";
            this.Text = "howto_loop_load_pictures";
            this.Load += new System.EventHandler(this.howto_loop_load_pictures_Form1_Load);
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.FlowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.PictureBox PictureBox3;
        internal System.Windows.Forms.PictureBox PictureBox4;
    }
}

