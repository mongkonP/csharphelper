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
     public partial class howto_print_justified_Form1:Form
  { 


        public howto_print_justified_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_print_justified_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Print some text left justified, right justified, and centered.
        private void howto_print_justified_Form1_Paint(object sender, PaintEventArgs e)
        {
            const int gap = 10;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.Clear(this.BackColor);

            string text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            int wid = (this.ClientSize.Width - 4 * gap) / 3;
            int hgt = this.ClientSize.Height - 2 * gap;

            // Left alignment.
            Rectangle rect = new Rectangle(gap, gap, wid, hgt);
            e.Graphics.DrawRectangle(Pens.Blue, rect);
            DrawText(e.Graphics, text, rect, StringAlignment.Near);

            // Right alignment.
            rect.X += wid + gap;
            e.Graphics.DrawRectangle(Pens.Blue, rect);
            DrawText(e.Graphics, text, rect, StringAlignment.Far);

            // Center alignment.
            rect.X += wid + gap;
            e.Graphics.DrawRectangle(Pens.Blue, rect);
            DrawText(e.Graphics, text, rect, StringAlignment.Center);
        }

        private void DrawText(Graphics gr, string text, Rectangle rect, StringAlignment alignment)
        {
            gr.DrawRectangle(Pens.Blue, rect);
            using (StringFormat string_format = new StringFormat())
            {
                // Center alignment.
                string_format.Alignment = alignment;
                string_format.FormatFlags = StringFormatFlags.LineLimit;
                string_format.Trimming = StringTrimming.Word;

                gr.DrawString(text, this.Font, Brushes.Black, rect, string_format);
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
            this.SuspendLayout();
            // 
            // howto_print_justified_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 287);
            this.Name = "howto_print_justified_Form1";
            this.Text = "howto_print_justified";
            this.Load += new System.EventHandler(this.howto_print_justified_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_print_justified_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

