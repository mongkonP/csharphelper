using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_shaded_ellipse;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_shaded_ellipse_Form1:Form
  { 


        public howto_shaded_ellipse_Form1()
        {
            InitializeComponent();
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
            this.shadedEllipse11 = new howto_shaded_ellipse.ShadedEllipse();
            this.shadedEllipse6 = new howto_shaded_ellipse.ShadedEllipse();
            this.shadedEllipse7 = new howto_shaded_ellipse.ShadedEllipse();
            this.shadedEllipse8 = new howto_shaded_ellipse.ShadedEllipse();
            this.shadedEllipse9 = new howto_shaded_ellipse.ShadedEllipse();
            this.shadedEllipse10 = new howto_shaded_ellipse.ShadedEllipse();
            this.shadedEllipse5 = new howto_shaded_ellipse.ShadedEllipse();
            this.shadedEllipse3 = new howto_shaded_ellipse.ShadedEllipse();
            this.shadedEllipse4 = new howto_shaded_ellipse.ShadedEllipse();
            this.shadedEllipse2 = new howto_shaded_ellipse.ShadedEllipse();
            this.shadedEllipse1 = new howto_shaded_ellipse.ShadedEllipse();
            this.SuspendLayout();
            // 
            // shadedEllipse11
            // 
            this.shadedEllipse11.BackColor = System.Drawing.Color.Blue;
            this.shadedEllipse11.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.shadedEllipse11.Location = new System.Drawing.Point(45, 103);
            this.shadedEllipse11.Name = "shadedEllipse11";
            this.shadedEllipse11.Size = new System.Drawing.Size(205, 76);
            this.shadedEllipse11.TabIndex = 10;
            this.shadedEllipse11.Text = "This is a shaded ellipse!";
            this.shadedEllipse11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shadedEllipse6
            // 
            this.shadedEllipse6.BackColor = System.Drawing.Color.Green;
            this.shadedEllipse6.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.shadedEllipse6.Location = new System.Drawing.Point(207, 50);
            this.shadedEllipse6.Name = "shadedEllipse6";
            this.shadedEllipse6.Size = new System.Drawing.Size(32, 32);
            this.shadedEllipse6.TabIndex = 9;
            this.shadedEllipse6.Text = "9";
            this.shadedEllipse6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shadedEllipse7
            // 
            this.shadedEllipse7.BackColor = System.Drawing.Color.Green;
            this.shadedEllipse7.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.shadedEllipse7.Location = new System.Drawing.Point(169, 50);
            this.shadedEllipse7.Name = "shadedEllipse7";
            this.shadedEllipse7.Size = new System.Drawing.Size(32, 32);
            this.shadedEllipse7.TabIndex = 8;
            this.shadedEllipse7.Text = "8";
            this.shadedEllipse7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shadedEllipse8
            // 
            this.shadedEllipse8.BackColor = System.Drawing.Color.Green;
            this.shadedEllipse8.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.shadedEllipse8.Location = new System.Drawing.Point(131, 50);
            this.shadedEllipse8.Name = "shadedEllipse8";
            this.shadedEllipse8.Size = new System.Drawing.Size(32, 32);
            this.shadedEllipse8.TabIndex = 7;
            this.shadedEllipse8.Text = "7";
            this.shadedEllipse8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shadedEllipse9
            // 
            this.shadedEllipse9.BackColor = System.Drawing.Color.Green;
            this.shadedEllipse9.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.shadedEllipse9.Location = new System.Drawing.Point(93, 50);
            this.shadedEllipse9.Name = "shadedEllipse9";
            this.shadedEllipse9.Size = new System.Drawing.Size(32, 32);
            this.shadedEllipse9.TabIndex = 6;
            this.shadedEllipse9.Text = "6";
            this.shadedEllipse9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shadedEllipse10
            // 
            this.shadedEllipse10.BackColor = System.Drawing.Color.Green;
            this.shadedEllipse10.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.shadedEllipse10.Location = new System.Drawing.Point(55, 50);
            this.shadedEllipse10.Name = "shadedEllipse10";
            this.shadedEllipse10.Size = new System.Drawing.Size(32, 32);
            this.shadedEllipse10.TabIndex = 5;
            this.shadedEllipse10.Text = "5";
            this.shadedEllipse10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shadedEllipse5
            // 
            this.shadedEllipse5.BackColor = System.Drawing.Color.Green;
            this.shadedEllipse5.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.shadedEllipse5.Location = new System.Drawing.Point(207, 12);
            this.shadedEllipse5.Name = "shadedEllipse5";
            this.shadedEllipse5.Size = new System.Drawing.Size(32, 32);
            this.shadedEllipse5.TabIndex = 4;
            this.shadedEllipse5.Text = "1";
            this.shadedEllipse5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shadedEllipse3
            // 
            this.shadedEllipse3.BackColor = System.Drawing.Color.Green;
            this.shadedEllipse3.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.shadedEllipse3.Location = new System.Drawing.Point(169, 12);
            this.shadedEllipse3.Name = "shadedEllipse3";
            this.shadedEllipse3.Size = new System.Drawing.Size(32, 32);
            this.shadedEllipse3.TabIndex = 3;
            this.shadedEllipse3.Text = "4";
            this.shadedEllipse3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shadedEllipse4
            // 
            this.shadedEllipse4.BackColor = System.Drawing.Color.Green;
            this.shadedEllipse4.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.shadedEllipse4.Location = new System.Drawing.Point(131, 12);
            this.shadedEllipse4.Name = "shadedEllipse4";
            this.shadedEllipse4.Size = new System.Drawing.Size(32, 32);
            this.shadedEllipse4.TabIndex = 2;
            this.shadedEllipse4.Text = "2";
            this.shadedEllipse4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shadedEllipse2
            // 
            this.shadedEllipse2.BackColor = System.Drawing.Color.Green;
            this.shadedEllipse2.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.shadedEllipse2.Location = new System.Drawing.Point(93, 12);
            this.shadedEllipse2.Name = "shadedEllipse2";
            this.shadedEllipse2.Size = new System.Drawing.Size(32, 32);
            this.shadedEllipse2.TabIndex = 1;
            this.shadedEllipse2.Text = "1";
            this.shadedEllipse2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shadedEllipse1
            // 
            this.shadedEllipse1.BackColor = System.Drawing.Color.Green;
            this.shadedEllipse1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.shadedEllipse1.Location = new System.Drawing.Point(55, 12);
            this.shadedEllipse1.Name = "shadedEllipse1";
            this.shadedEllipse1.Size = new System.Drawing.Size(32, 32);
            this.shadedEllipse1.TabIndex = 0;
            this.shadedEllipse1.Text = "0";
            this.shadedEllipse1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_shaded_ellipse_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 201);
            this.Controls.Add(this.shadedEllipse11);
            this.Controls.Add(this.shadedEllipse6);
            this.Controls.Add(this.shadedEllipse7);
            this.Controls.Add(this.shadedEllipse8);
            this.Controls.Add(this.shadedEllipse9);
            this.Controls.Add(this.shadedEllipse10);
            this.Controls.Add(this.shadedEllipse5);
            this.Controls.Add(this.shadedEllipse3);
            this.Controls.Add(this.shadedEllipse4);
            this.Controls.Add(this.shadedEllipse2);
            this.Controls.Add(this.shadedEllipse1);
            this.Name = "howto_shaded_ellipse_Form1";
            this.Text = "howto_shaded_ellipse";
            this.ResumeLayout(false);

        }

        #endregion

        private ShadedEllipse shadedEllipse1;
        private ShadedEllipse shadedEllipse2;
        private ShadedEllipse shadedEllipse3;
        private ShadedEllipse shadedEllipse4;
        private ShadedEllipse shadedEllipse5;
        private ShadedEllipse shadedEllipse6;
        private ShadedEllipse shadedEllipse7;
        private ShadedEllipse shadedEllipse8;
        private ShadedEllipse shadedEllipse9;
        private ShadedEllipse shadedEllipse10;
        private ShadedEllipse shadedEllipse11;
    }
}

