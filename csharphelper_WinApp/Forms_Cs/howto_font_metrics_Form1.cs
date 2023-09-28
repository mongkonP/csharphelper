using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

 

using howto_font_metrics;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_font_metrics_Form1:Form
  { 


        public howto_font_metrics_Form1()
        {
            InitializeComponent();
        }

        private void howto_font_metrics_Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
        }

        private void howto_font_metrics_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            string txt = "Mgfi";
            RectangleF layout_rect = new RectangleF(0, 0,
                this.ClientSize.Width / 3, this.ClientSize.Height);
            using (StringFormat string_format = new StringFormat())
            {
                string_format.LineAlignment = StringAlignment.Center;
                string_format.Alignment = StringAlignment.Center;

                // using (the_font As New Font("Times New Roman", 240, FontStyle.Bold, GraphicsUnit.Document)
                // using (the_font As New Font("Times New Roman", 0.8, FontStyle.Bold, GraphicsUnit.Inch)
                // using (the_font As New Font("Times New Roman", 60, FontStyle.Bold, GraphicsUnit.Point)
                // using (the_font As New Font("Times New Roman", 80, FontStyle.Bold, GraphicsUnit.Pixel)
                //using (the_font As New Font("Times New Roman", 22, FontStyle.Bold, GraphicsUnit.Millimeter)
                using (Font the_font = new Font("Times New Roman", 80, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    MeasureCharacters(e.Graphics, the_font, txt, layout_rect, string_format);
                }

                layout_rect.X += this.ClientSize.Width / 3;
                using (Font the_font = new Font("Comic Sans MS", 80, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    MeasureCharacters(e.Graphics, the_font, txt, layout_rect, string_format);
                }

                layout_rect.X += this.ClientSize.Width / 3;
                using (Font the_font = new Font("Courier New", 80, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    MeasureCharacters(e.Graphics, the_font, txt, layout_rect, string_format);
                }
            }
        }

        // Draw the string's metrics.
        public void MeasureCharacters(Graphics gr, Font the_font, string txt, RectangleF layout_rect , StringFormat string_format )
        {
            // Define an array of CharacterRange objects, 
            // one for each character.
            CharacterRange[] character_ranges = new CharacterRange[txt.Length];
            for (int i = 0; i <  txt.Length ; i++)
            {
                character_ranges[i] = new CharacterRange(i, 1);
            }

            // Set the ranges in the StringFormat object.
            string_format.SetMeasurableCharacterRanges(character_ranges);

            // Get the character range regions.
            Region[] character_regions = gr.MeasureCharacterRanges(
                txt, the_font, layout_rect, string_format);

            // Get the font's metrics.
            FontInfo font_info = new FontInfo(gr, the_font);

            // Draw each region's bounds.
            foreach (Region rgn in character_regions)
            {
                // Convert the region into a Rectangle.
                RectangleF character_bounds = rgn.GetBounds(gr);
                Rectangle character_rect = Rectangle.Round(character_bounds);

                // Draw the bounds.
                gr.FillRectangle(Brushes.Pink, character_rect);

                // Draw the top.
                using (Pen dashed_pen = new Pen(Color.Black))
                {
                    dashed_pen.DashStyle = DashStyle.Custom;
                    dashed_pen.DashPattern = new float[] { 3, 3 };
                    gr.DrawLine(dashed_pen,
                        character_rect.X - 20,
                        character_rect.Y,
                        character_rect.Right,
                        character_rect.Y);
                }

                // Draw the internal leading.
                gr.DrawLine(Pens.Red,
                    character_rect.X - 3,
                    character_rect.Y + font_info.RelTop,
                    character_rect.Right + 3,
                    character_rect.Y + font_info.RelTop);

                // Draw the ascent.
                gr.DrawLine(Pens.Green,
                    character_rect.X - 3,
                    character_rect.Y + font_info.RelBaseline,
                    character_rect.Right + 3,
                    character_rect.Y + font_info.RelBaseline);

                // Draw the descent.
                gr.DrawLine(Pens.Blue,
                    character_rect.X - 3,
                    character_rect.Y + font_info.RelBottom,
                    character_rect.Right + 3,
                    character_rect.Y + font_info.RelBottom);

                // Draw the next line.
                using (Pen dashed_pen = new Pen(Color.Blue))
                {
                    dashed_pen.DashStyle = DashStyle.Custom;
                    dashed_pen.DashPattern = new float[] { 1, 2, 3, 2 };
                    gr.DrawLine(dashed_pen,
                        character_rect.X,
                        character_rect.Y + font_info.LineSpacingPixels,
                        character_rect.Right + 30,
                        character_rect.Y + font_info.LineSpacingPixels);
                }

                // Fill the external leading.
                gr.FillRectangle(Brushes.Orange,
                    character_rect.X,
                    character_rect.Y + font_info.AscentPixels + font_info.DescentPixels,
                    character_rect.Width,
                    font_info.ExternalLeadingPixels);
            }

            // Draw the text.
            gr.DrawString(txt, the_font, Brushes.Black, layout_rect, string_format);
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
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label6.ForeColor = System.Drawing.Color.Blue;
            this.Label6.Location = new System.Drawing.Point(374, 272);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(102, 13);
            this.Label6.TabIndex = 11;
            this.Label6.Text = "Next Line (dash-dot)";
            // 
            // Label5
            // 
            this.Label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(298, 272);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(70, 13);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "Top (dashed)";
            // 
            // Label4
            // 
            this.Label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Label4.ForeColor = System.Drawing.Color.Orange;
            this.Label4.Location = new System.Drawing.Point(206, 272);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(86, 13);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "External Leading";
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.Blue;
            this.Label3.Location = new System.Drawing.Point(153, 272);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(47, 13);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Descent";
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.Green;
            this.Label2.Location = new System.Drawing.Point(107, 272);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 13);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Ascent";
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.Red;
            this.Label1.Location = new System.Drawing.Point(18, 272);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(83, 13);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Internal Leading";
            // 
            // howto_font_metrics_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 294);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "howto_font_metrics_Form1";
            this.Text = "howto_font_metrics";
            this.Load += new System.EventHandler(this.howto_font_metrics_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_font_metrics_Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}

