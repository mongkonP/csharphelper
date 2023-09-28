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
     public partial class howto_rtf_subscripts_Form1:Form
  { 


        public howto_rtf_subscripts_Form1()
        {
            InitializeComponent();
        }

        private void howto_rtf_subscripts_Form1_Load(object sender, EventArgs e)
        {
            rchEquation.Text = "2H2 + O2 = 2H2O\n32 + 42 = 52";

            // A smaller font.
            float font_size = rchEquation.Font.Size;
            Font small_font = new Font(
                rchEquation.Font.FontFamily,
                font_size * 0.75f);

            // Subscripts.
            int[] subs = { 2, 7, 13 };
            int offset = (int)(font_size * 0.5);
            foreach (int position in subs)
            {
                rchEquation.Select(position, 1);
                rchEquation.SelectionCharOffset = -offset;
                rchEquation.SelectionFont = small_font;
            }

            // Superscripts.
            int[] supers = { 17, 22, 27 };
            foreach (int position in supers)
            {
                rchEquation.Select(position, 1);
                rchEquation.SelectionCharOffset = +offset;
                rchEquation.SelectionFont = small_font;
            }

            // Center.
            rchEquation.Select(0, rchEquation.Text.Length);
            rchEquation.SelectionAlignment = HorizontalAlignment.Center;

            rchEquation.Select(0, 0);
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
            this.rchEquation = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rchEquation
            // 
            this.rchEquation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchEquation.Location = new System.Drawing.Point(12, 12);
            this.rchEquation.Name = "rchEquation";
            this.rchEquation.Size = new System.Drawing.Size(260, 87);
            this.rchEquation.TabIndex = 0;
            this.rchEquation.Text = "";
            // 
            // howto_rtf_subscripts_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.rchEquation);
            this.Name = "howto_rtf_subscripts_Form1";
            this.Text = "howto_rtf_subscripts";
            this.Load += new System.EventHandler(this.howto_rtf_subscripts_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchEquation;
    }
}

