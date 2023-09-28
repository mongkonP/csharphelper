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
     public partial class howto_format_richtextbox_Form1:Form
  { 


        public howto_format_richtextbox_Form1()
        {
            InitializeComponent();
        }

        private void howto_format_richtextbox_Form1_Load(object sender, EventArgs e)
        {
            // Format RichTextBox1.
            richTextBox1.Select(4, 5);
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.Select(16, 3);
            richTextBox1.SelectionFont =
                new Font(richTextBox1.Font, FontStyle.Italic);
            richTextBox1.Select(35, 4);
            richTextBox1.SelectionBackColor = Color.Yellow;
            richTextBox1.SelectionColor = Color.Brown;
            richTextBox1.Select(0, 0);

            // Format RichTextBox2.
            SelectRichText(richTextBox2, "quick");
            richTextBox2.SelectionColor = Color.Red;
            SelectRichText(richTextBox2, "fox");
            richTextBox2.SelectionFont =
                new Font(richTextBox2.Font, FontStyle.Italic);
            SelectRichText(richTextBox2, "lazy");
            richTextBox2.SelectionBackColor = Color.Yellow;
            richTextBox2.SelectionColor = Color.Brown;
            richTextBox2.Select(0, 0);
        }

        // Select the indicated text.
        private void SelectRichText(RichTextBox rch, string target)
        {
            int pos = rch.Text.IndexOf(target);
            if (pos < 0)
            {
                // Not found. Select nothing.
                rch.Select(0, 0);
            }
            else
            {
                // Found the text. Select it.
                rch.Select(pos, target.Length);
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(337, 34);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "The quick brown fox jumps over the lazy dog.";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(12, 52);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(337, 34);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "The quick brown fox jumps over the lazy dog.";
            // 
            // howto_format_richtextbox_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 100);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Name = "howto_format_richtextbox_Form1";
            this.Text = "howto_format_richtextbox";
            this.Load += new System.EventHandler(this.howto_format_richtextbox_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}

