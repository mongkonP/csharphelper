using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;

 

using howto_randomize_2d_array;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_randomize_2d_array_Form1:Form
  { 


        public howto_randomize_2d_array_Form1()
        {
            InitializeComponent();
        }

        // Some random values.
        private int[,] Values =
        {
            {1, 2, 3, 4, 5},
            {6, 7, 8, 9, 10},
            {11, 12, 13, 14, 15},
            {16, 17, 18, 19, 20},
        };

        // Randomize.
        private void btnRandomize_Click(object sender, EventArgs e)
        {
            Values.Randomize();
            Refresh();
        }

        // Draw the values.
        private void howto_randomize_2d_array_Form1_Paint(object sender, PaintEventArgs e)
        {
            int num_rows = Values.GetUpperBound(0) + 1;
            int num_cols = Values.GetUpperBound(1) + 1;
            int col_wid = this.ClientSize.Width / num_cols;
            int row_hgt =
                (this.ClientSize.Height - btnRandomize.Bottom) / num_rows;

            e.Graphics.TextRenderingHint =
                TextRenderingHint.AntiAliasGridFit;
            using (Font the_font = new Font("Times New Roman", 20))
            {
                using (StringFormat string_format = new StringFormat())
                {
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Center;
                    int y = btnRandomize.Bottom;
                    for (int row = 0; row < num_rows; row++)
                    {
                        int x = 0;
                        for (int col = 0; col < num_cols; col++)
                        {
                            Rectangle rect = new Rectangle(
                                x, y, col_wid, row_hgt);
                            e.Graphics.DrawString(Values[row, col].ToString(),
                                the_font, Brushes.Blue, rect, string_format);
                            x += col_wid;
                        }
                        y += row_hgt;
                    }
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
            this.btnRandomize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRandomize
            // 
            this.btnRandomize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRandomize.Location = new System.Drawing.Point(126, 12);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(75, 23);
            this.btnRandomize.TabIndex = 1;
            this.btnRandomize.Text = "Randomize";
            this.btnRandomize.UseVisualStyleBackColor = true;
            this.btnRandomize.Click += new System.EventHandler(this.btnRandomize_Click);
            // 
            // howto_randomize_2d_array_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 210);
            this.Controls.Add(this.btnRandomize);
            this.Name = "howto_randomize_2d_array_Form1";
            this.Text = "howto_randomize_2d_array";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_randomize_2d_array_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRandomize;
    }
}

