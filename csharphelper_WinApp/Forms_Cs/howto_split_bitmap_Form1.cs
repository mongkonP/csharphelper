using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_split_bitmap_Form1:Form
  { 


        public howto_split_bitmap_Form1()
        {
            InitializeComponent();
        }

        // Split the file.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get the inputs.
            int wid = int.Parse(txtWidth.Text);
            int hgt = int.Parse(txtHeight.Text);
            Bitmap bm = LoadUnlocked(txtFile.Text);

            // Start splitting the Bitmap.
            string piece_name = Path.GetFileNameWithoutExtension(txtFile.Text);
            Bitmap piece = new Bitmap(wid, hgt);
            Rectangle dest_rect = new Rectangle(0, 0, wid, hgt);
            using (Graphics gr = Graphics.FromImage(piece))
            {
                int num_rows = bm.Height / hgt;
                int num_cols = bm.Width / wid;
                Rectangle source_rect = new Rectangle(0, 0, wid, hgt);
                for (int row = 0; row < num_rows; row++)
                {
                    source_rect.X = 0;
                    for (int col = 0; col < num_cols; col++)
                    {
                        // Copy the piece of the image.
                        gr.DrawImage(bm, dest_rect, source_rect, GraphicsUnit.Pixel);

                        // Save the piece.
                        string filename = piece_name +
                            row.ToString("00") +
                            col.ToString("00") + ".bmp";
                        piece.Save(filename, ImageFormat.Bmp);

                        // Move to the next column.
                        source_rect.X += wid;
                    }
                    source_rect.Y += hgt;
                }
                MessageBox.Show("Created " + num_rows * num_cols + " files",
                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Load a Bitmap without locking its file.
        private Bitmap LoadUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
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
            this.btnGo = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(134, 50);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 13;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(61, 64);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(49, 20);
            this.txtHeight.TabIndex = 12;
            this.txtHeight.Text = "28";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Height:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(61, 38);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(49, 20);
            this.txtWidth.TabIndex = 10;
            this.txtWidth.Text = "28";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Width:";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(61, 12);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(211, 20);
            this.txtFile.TabIndex = 8;
            this.txtFile.Text = "test.bmp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "File:";
            // 
            // howto_split_bitmap_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 94);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Name = "howto_split_bitmap_Form1";
            this.Text = "howto_split_bitmap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
    }
}

