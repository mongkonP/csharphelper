using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_make_logger;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_make_logger_Form1:Form
  { 


        public howto_make_logger_Form1()
        {
            InitializeComponent();
        }

        // Start with a fresh log file.
        private void howto_make_logger_Form1_Load(object sender, EventArgs e)
        {
            Logger.DeleteLog();
        }

        // Record MouseEnter and MouseLeave events.
        private void picVolleyball_MouseEnter(object sender, EventArgs e)
        {
            Logger.WriteLine("MouseEnter");
        }
        private void picVolleyball_MouseLeave(object sender, EventArgs e)
        {
            Logger.WriteLine("MouseLeave");
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
            this.picVolleyball = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picVolleyball)).BeginInit();
            this.SuspendLayout();
            // 
            // picVolleyball
            // 
            this.picVolleyball.BackColor = System.Drawing.Color.White;
            this.picVolleyball.Image = Properties.Resources.Volleyball;
            this.picVolleyball.Location = new System.Drawing.Point(53, 41);
            this.picVolleyball.Name = "picVolleyball";
            this.picVolleyball.Size = new System.Drawing.Size(179, 179);
            this.picVolleyball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picVolleyball.TabIndex = 3;
            this.picVolleyball.TabStop = false;
            this.picVolleyball.MouseLeave += new System.EventHandler(this.picVolleyball_MouseLeave);
            this.picVolleyball.MouseEnter += new System.EventHandler(this.picVolleyball_MouseEnter);
            // 
            // howto_make_logger_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picVolleyball);
            this.Name = "howto_make_logger_Form1";
            this.Text = "howto_make_logger";
            this.Load += new System.EventHandler(this.howto_make_logger_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picVolleyball)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picVolleyball;
    }
}

