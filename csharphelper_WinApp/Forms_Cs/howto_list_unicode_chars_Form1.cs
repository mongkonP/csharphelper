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
     public partial class howto_list_unicode_chars_Form1:Form
  { 


        public howto_list_unicode_chars_Form1()
        {
            InitializeComponent();
        }

        // Display the desired Unicode characters
        private void btnList_Click(object sender, EventArgs e)
        {
            txtChars.Clear();
            txtCharCode.Clear();
            lblSample.Text = "";
            Cursor = Cursors.WaitCursor;
            Refresh();

            // Set the font size.
            float font_size = float.Parse(txtFontSize.Text);
            Font font = new Font("Times New Roman", font_size);
            txtChars.Font = font;
            lblSample.Font = font;

            // Display the characters.
            int min = int.Parse(txtMin.Text);
            int max = int.Parse(txtMax.Text);
            StringBuilder sb = new StringBuilder();
            for (int i = min; i <= max; i++)
                sb.Append(((char)i).ToString());
            txtChars.Text = sb.ToString();
            txtChars.Select(0, 0);

            Cursor = Cursors.Default;
        }

        // Display the code for the character under the mouse.
        private void txtChars_MouseMove(object sender, MouseEventArgs e)
        {
            char ch = txtChars.GetCharFromPosition(e.Location);
            lblSample.Text = ch.ToString();
            txtCharCode.Text = ((int)ch).ToString();
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
            this.txtChars = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.btnList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFontSize = new System.Windows.Forms.TextBox();
            this.txtCharCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSample = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtChars
            // 
            this.txtChars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChars.BackColor = System.Drawing.Color.White;
            this.txtChars.Cursor = System.Windows.Forms.Cursors.Cross;
            this.txtChars.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChars.Location = new System.Drawing.Point(12, 41);
            this.txtChars.Multiline = true;
            this.txtChars.Name = "txtChars";
            this.txtChars.ReadOnly = true;
            this.txtChars.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChars.Size = new System.Drawing.Size(560, 182);
            this.txtChars.TabIndex = 4;
            this.txtChars.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtChars_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "to";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(55, 14);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(45, 20);
            this.txtMin.TabIndex = 0;
            this.txtMin.Text = "10000";
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(117, 14);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(45, 20);
            this.txtMax.TabIndex = 1;
            this.txtMax.Text = "20000";
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Location = new System.Drawing.Point(497, 12);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 3;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chars:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Font Size:";
            // 
            // txtFontSize
            // 
            this.txtFontSize.Location = new System.Drawing.Point(248, 14);
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(30, 20);
            this.txtFontSize.TabIndex = 2;
            this.txtFontSize.Text = "20";
            this.txtFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCharCode
            // 
            this.txtCharCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCharCode.Location = new System.Drawing.Point(102, 229);
            this.txtCharCode.Name = "txtCharCode";
            this.txtCharCode.ReadOnly = true;
            this.txtCharCode.Size = new System.Drawing.Size(45, 20);
            this.txtCharCode.TabIndex = 5;
            this.txtCharCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Character Code:";
            // 
            // lblSample
            // 
            this.lblSample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSample.AutoSize = true;
            this.lblSample.Location = new System.Drawing.Point(153, 226);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(0, 13);
            this.lblSample.TabIndex = 10;
            // 
            // howto_list_unicode_chars_Form1
            // 
            this.AcceptButton = this.btnList;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.lblSample);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCharCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFontSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChars);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "howto_list_unicode_chars_Form1";
            this.Text = "howto_list_unicode_chars";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFontSize;
        private System.Windows.Forms.TextBox txtCharCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSample;
    }
}

