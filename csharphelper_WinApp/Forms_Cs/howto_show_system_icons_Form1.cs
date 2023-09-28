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
     public partial class howto_show_system_icons_Form1:Form
  { 


        public howto_show_system_icons_Form1()
        {
            InitializeComponent();
        }

        // Draw samples.
        private const int column_width = 150;
        private const int row_height = 50;
        private void howto_show_system_icons_Form1_Paint(object sender, PaintEventArgs e)
        {
            int x = 10;
            int y = 10;
            DrawIconSample(e.Graphics, ref x, y, SystemIcons.Application, "Application");
            DrawIconSample(e.Graphics, ref x, y, SystemIcons.Asterisk, "Asterisk");
            DrawIconSample(e.Graphics, ref x, y, SystemIcons.Error, "Error");
            x = 10;
            y += 50;
            DrawIconSample(e.Graphics, ref x, y, SystemIcons.Exclamation, "Exclamation");
            DrawIconSample(e.Graphics, ref x, y, SystemIcons.Hand, "Hand");
            DrawIconSample(e.Graphics, ref x, y, SystemIcons.Information, "Information");
            x = 10;
            y += row_height;
            DrawIconSample(e.Graphics, ref x, y, SystemIcons.Question, "Question");
            DrawIconSample(e.Graphics, ref x, y, SystemIcons.Shield, "Shield");
            DrawIconSample(e.Graphics, ref x, y, SystemIcons.Warning, "Warning");
            x = 10;
            y += 50;
            DrawIconSample(e.Graphics, ref x, y, SystemIcons.WinLogo, "WinLogo");

            this.ClientSize = new Size(3 * column_width, 4 * row_height);
        }

        // Draw a sample and its name.
        private void DrawIconSample(Graphics gr, ref int x, int y, Icon ico, string ico_name)
        {
            gr.DrawIconUnstretched(ico, new Rectangle(x, y, ico.Width, ico.Height));
            int text_y = y + (int)(ico.Height - gr.MeasureString(ico_name, this.Font).Height) / 2;
            gr.DrawString(ico_name, this.Font, Brushes.Black, x + ico.Width + 5, text_y);
            x += column_width;
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
            this.SuspendLayout();
            // 
            // howto_show_system_icons_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 264);
            this.Name = "howto_show_system_icons_Form1";
            this.Text = "howto_show_system_icons";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_show_system_icons_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

