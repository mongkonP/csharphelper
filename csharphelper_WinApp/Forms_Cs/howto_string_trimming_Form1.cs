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
     public partial class howto_string_trimming_Form1:Form
  { 


        public howto_string_trimming_Form1()
        {
            InitializeComponent();
        }

        private void howto_string_trimming_Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
        }

        private void howto_string_trimming_Form1_Paint(object sender, PaintEventArgs e)
        {
            // A Mark Twain quote:
            const string quote =
                "The trouble ain't that there is too many fools, " +
                "but that the lightning ain't distributed right.";
            const int margin = 5;
            StringTrimming[] values =
                (StringTrimming[])Enum.GetValues(typeof(StringTrimming));
            int height = (ClientSize.Height - (values.Length + 1) * margin) / values.Length;
            int width = ClientSize.Width - 2 * margin;

            using (Font font = new Font("Times New Roman", 16))
            {
                using (StringFormat string_format = new StringFormat())
                {
                    int y = margin;
                    foreach (StringTrimming trimmming in values)
                    {
                        Rectangle rect = new Rectangle(margin, y, width, height);
                        e.Graphics.DrawRectangle(Pens.Black, rect);
                        string_format.Trimming = trimmming;
                        e.Graphics.DrawString(trimmming.ToString() +
                            ": " + quote, font, Brushes.Blue, rect, string_format);

                        y += height + margin;
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
            this.SuspendLayout();
            // 
            // howto_string_trimming_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 335);
            this.Name = "howto_string_trimming_Form1";
            this.Text = "howto_string_trimming";
            this.Load += new System.EventHandler(this.howto_string_trimming_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_string_trimming_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

