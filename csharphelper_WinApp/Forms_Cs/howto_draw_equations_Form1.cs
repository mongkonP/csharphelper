using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_draw_equations;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_draw_equations_Form1:Form
  { 


        public howto_draw_equations_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_draw_equations_Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
        }

        // Draw a sample equation.
        private void howto_draw_equations_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Font font = new Font("Times New Roman", 16))
            {
                // Make the equation.
                Equation equation =
                    new IntegralEquation(
                        new BarEquation(
                            new MatrixEquation(3, 4, false, false,
                                new FractionEquation("A", "B", true),
                                new StringEquation("(0, 1)"),
                                new StringEquation("(0, 2)"),
                                new StringEquation("(0, 3)"),
                                new StringEquation("(1, 0)"),
                                new StringEquation("<middle>"),
                                new StringEquation("(1, 2)"),
                                new StringEquation("(1, 3)"),
                                new StringEquation("(2, 0)"),
                                new RootEquation(
                                    new StringEquation("e"),
                                    new SigmaEquation(
                                        new PowerEquation("X", "2"),
                                        new StringEquation("100"),
                                        new StringEquation("X = 1")
                                    )
                                ),
                                new StringEquation("(2, 2)"),
                                new StringEquation("(2, 3)")
                            ),
                            BarEquation.BarStyles.Parenthesis,
                            BarEquation.BarStyles.Parenthesis
                        ),
                        new StringEquation("y = 10"),
                        new StringEquation("y = 1")
                    );

                // Set the equation font sizes.
                equation.SetFontSizes(18);

                // See how big it is.
                SizeF equation_size = equation.GetSize(e.Graphics, font);

                // See where to put the equation to center it.
                float x = (ClientSize.Width - equation_size.Width) / 2;
                float y = (ClientSize.Height - equation_size.Height) / 2;

                // Draw the equation's area.
                e.Graphics.FillRectangle(Brushes.White, x, y,
                    equation_size.Width, equation_size.Height);

                // Draw the equation.
                equation.Draw(e.Graphics, font, Pens.Black, Brushes.Black, x, y);
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
            // howto_draw_equations_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(403, 169);
            this.Name = "howto_draw_equations_Form1";
            this.Text = "howto_draw_equations";
            this.Load += new System.EventHandler(this.howto_draw_equations_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_draw_equations_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

    }
}

