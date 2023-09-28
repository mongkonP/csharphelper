using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_show_exif_orientations;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_show_exif_orientations_Form1:Form
  { 


        public howto_show_exif_orientations_Form1()
        {
            InitializeComponent();
        }

        private void howto_show_exif_orientations_Form1_Load(object sender, EventArgs e)
        {
            pic1.Image = ExifStuff.OrientationImage((ExifStuff.ExifOrientations)1);
            pic2.Image = ExifStuff.OrientationImage((ExifStuff.ExifOrientations)2);
            pic3.Image = ExifStuff.OrientationImage((ExifStuff.ExifOrientations)3);
            pic4.Image = ExifStuff.OrientationImage((ExifStuff.ExifOrientations)4);
            pic5.Image = ExifStuff.OrientationImage((ExifStuff.ExifOrientations)5);
            pic6.Image = ExifStuff.OrientationImage((ExifStuff.ExifOrientations)6);
            pic7.Image = ExifStuff.OrientationImage((ExifStuff.ExifOrientations)7);
            pic8.Image = ExifStuff.OrientationImage((ExifStuff.ExifOrientations)8);
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
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pic8 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pic7 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pic6 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pic5 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(504, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 19);
            this.label9.TabIndex = 47;
            this.label9.Text = "8";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(434, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 19);
            this.label10.TabIndex = 46;
            this.label10.Text = "7";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(364, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 19);
            this.label11.TabIndex = 45;
            this.label11.Text = "6";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(294, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 19);
            this.label12.TabIndex = 44;
            this.label12.Text = "5";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(224, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 19);
            this.label13.TabIndex = 43;
            this.label13.Text = "4";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(154, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 19);
            this.label14.TabIndex = 42;
            this.label14.Text = "3";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(84, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 19);
            this.label15.TabIndex = 41;
            this.label15.Text = "2";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(14, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 19);
            this.label16.TabIndex = 40;
            this.label16.Text = "1";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pic8
            // 
            this.pic8.Location = new System.Drawing.Point(507, 56);
            this.pic8.Name = "pic8";
            this.pic8.Size = new System.Drawing.Size(64, 64);
            this.pic8.TabIndex = 39;
            this.pic8.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(504, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 23);
            this.label5.TabIndex = 38;
            this.label5.Text = "LeftBottom";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pic7
            // 
            this.pic7.Location = new System.Drawing.Point(437, 56);
            this.pic7.Name = "pic7";
            this.pic7.Size = new System.Drawing.Size(64, 64);
            this.pic7.TabIndex = 37;
            this.pic7.TabStop = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(434, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 23);
            this.label6.TabIndex = 36;
            this.label6.Text = "RightBottom";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pic6
            // 
            this.pic6.Location = new System.Drawing.Point(367, 56);
            this.pic6.Name = "pic6";
            this.pic6.Size = new System.Drawing.Size(64, 64);
            this.pic6.TabIndex = 35;
            this.pic6.TabStop = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(364, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 23);
            this.label7.TabIndex = 34;
            this.label7.Text = "RightTop";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pic5
            // 
            this.pic5.Location = new System.Drawing.Point(297, 56);
            this.pic5.Name = "pic5";
            this.pic5.Size = new System.Drawing.Size(64, 64);
            this.pic5.TabIndex = 33;
            this.pic5.TabStop = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(294, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 23);
            this.label8.TabIndex = 32;
            this.label8.Text = "LeftTop";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pic4
            // 
            this.pic4.Location = new System.Drawing.Point(227, 56);
            this.pic4.Name = "pic4";
            this.pic4.Size = new System.Drawing.Size(64, 64);
            this.pic4.TabIndex = 31;
            this.pic4.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(224, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 23);
            this.label3.TabIndex = 30;
            this.label3.Text = "BottomLeft";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pic3
            // 
            this.pic3.Location = new System.Drawing.Point(157, 56);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(64, 64);
            this.pic3.TabIndex = 29;
            this.pic3.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(154, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 23);
            this.label4.TabIndex = 28;
            this.label4.Text = "BottomRight";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pic2
            // 
            this.pic2.Location = new System.Drawing.Point(87, 56);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(64, 64);
            this.pic2.TabIndex = 27;
            this.pic2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(84, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 26;
            this.label2.Text = "TopRight";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(17, 56);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(64, 64);
            this.pic1.TabIndex = 25;
            this.pic1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "TopLeft";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // howto_show_exif_orientations_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 130);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.pic8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pic7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pic6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pic5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pic4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pic3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.label1);
            this.Name = "howto_show_exif_orientations_Form1";
            this.Text = "howto_show_exif_orientations";
            this.Load += new System.EventHandler(this.howto_show_exif_orientations_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pic8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pic7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pic6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pic5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pic4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Label label1;
    }
}

