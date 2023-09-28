using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_font_aliasing_Form1:Form
  { 


        public howto_font_aliasing_Form1()
        {
            InitializeComponent();
        }

        // List the fonts.
        private void howto_font_aliasing_Form1_Load(object sender, EventArgs e)
        {
            InstalledFontCollection fonts = new InstalledFontCollection();
            var font_names =
                from family in fonts.Families
                select family.Name;
            cboFonts.DataSource = font_names.ToArray();
        }

        // Draw font samples.
        private void howto_font_aliasing_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            int x = 20;
            int y = cboFonts.Bottom + 5;
            DrawSamples(e.Graphics, TextRenderingHint.AntiAlias, x, ref y);

            y += 10;
            DrawSamples(e.Graphics, TextRenderingHint.AntiAliasGridFit, x, ref y);

            y += 10;
            DrawSamples(e.Graphics, TextRenderingHint.ClearTypeGridFit, x, ref y);

            x += 250;
            y = cboFonts.Bottom + 5;
            DrawSamples(e.Graphics, TextRenderingHint.SingleBitPerPixel, x, ref y);

            y += 10;
            DrawSamples(e.Graphics, TextRenderingHint.SingleBitPerPixelGridFit, x, ref y);

            y += 10;
            DrawSamples(e.Graphics, TextRenderingHint.SystemDefault, x, ref y);
        }

        private void DrawSamples(Graphics gr, TextRenderingHint hint, int x, ref int y)
        {
            gr.TextRenderingHint = TextRenderingHint.AntiAlias;
            gr.DrawString(hint.ToString(), this.Font, Brushes.Blue, x - 10, y);
            y += 20;
            gr.TextRenderingHint = hint;
            for (int font_size = 6; font_size <= 16; font_size += 2)
            {
                DrawSample(gr, font_size, x, ref y);
            }
        }

        // Draw a sample of the indicated text.
        private void DrawSample(Graphics gr, float font_size, int x, ref int y)
        {
            try
            {
                using (Font font = new Font(cboFonts.Text, font_size))
                {
                    string text = cboFonts.Text + ", " + font_size.ToString();
                    gr.DrawString(text, font, Brushes.Black, x, y);
                    y = (int)(y + font_size) + 10;
                }
            }
            catch
            {
            }
        }

        // Redraw the samples using the new font.
        private void cboFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Refresh();
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboFonts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Font:";
            // 
            // cboFonts
            // 
            this.cboFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFonts.FormattingEnabled = true;
            this.cboFonts.Location = new System.Drawing.Point(49, 12);
            this.cboFonts.Name = "cboFonts";
            this.cboFonts.Size = new System.Drawing.Size(213, 24);
            this.cboFonts.TabIndex = 1;
            this.cboFonts.SelectedIndexChanged += new System.EventHandler(this.cboFonts_SelectedIndexChanged);
            // 
            // howto_font_aliasing_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 514);
            this.Controls.Add(this.cboFonts);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "howto_font_aliasing_Form1";
            this.Text = "howto_font_aliasing";
            this.Load += new System.EventHandler(this.howto_font_aliasing_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_font_aliasing_Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFonts;

    }
}

