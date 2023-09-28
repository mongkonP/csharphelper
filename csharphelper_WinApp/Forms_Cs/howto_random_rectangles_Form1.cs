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
     public partial class howto_random_rectangles_Form1:Form
  { 


        public howto_random_rectangles_Form1()
        {
            InitializeComponent();
        }

        private Random Rand = new Random();
        private Bitmap Bm;
        private Graphics Gr;

        // Make a bitmap to display.
        private void howto_random_rectangles_Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            MaximizeBox = false;
            DoubleBuffered = true;
            // Set at design time:
            //      StartPosition = FormStartPosition.CenterScreen;

            Bm = new Bitmap(ClientSize.Width, ClientSize.Height);
            Gr = Graphics.FromImage(Bm);
            BackgroundImage = Bm;
        }

        private void tmrMakeRectangle_Tick(object sender, EventArgs e)
        {
            int x = Rand.Next(ClientSize.Width - 10);
            int y = Rand.Next(ClientSize.Height - 10);
            int width = Rand.Next(ClientSize.Width - x);
            int height = Rand.Next(ClientSize.Height - y);
            Color color = Color.FromArgb(128,
                255 * Rand.Next(2),
                255 * Rand.Next(2),
                255 * Rand.Next(2));
            using (Brush brush = new SolidBrush(color))
            {
                Gr.FillRectangle(brush, x, y, width, height);
            }
            Refresh();
        }

        private void howto_random_rectangles_Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Gr.Clear(BackColor);
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
            this.components = new System.ComponentModel.Container();
            this.tmrMakeRectangle = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrMakeRectangle
            // 
            this.tmrMakeRectangle.Enabled = true;
            this.tmrMakeRectangle.Tick += new System.EventHandler(this.tmrMakeRectangle_Tick);
            // 
            // howto_random_rectangles_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Name = "howto_random_rectangles_Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "howto_random_rectangles";
            this.Load += new System.EventHandler(this.howto_random_rectangles_Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.howto_random_rectangles_Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrMakeRectangle;
    }
}

