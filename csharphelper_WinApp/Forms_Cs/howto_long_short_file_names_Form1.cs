using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Needed to use DllImport.
using System.Runtime.InteropServices;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_long_short_file_names_Form1:Form
  { 


        // Define GetShortPathName API function.
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint GetShortPathName(string lpszLongPath, char[] lpszShortPath, int cchBuffer);
        
        public howto_long_short_file_names_Form1()
        {
            InitializeComponent();
        }

        // Display the executable's long and short file names.
        private void howto_long_short_file_names_Form1_Load(object sender, EventArgs e)
        {
            txtLongName.Text = Application.ExecutablePath;
        }

        // Display the long file name.
        private void btnToLong_Click(object sender, EventArgs e)
        {
            txtLongName.Text = LongFileName(txtShortName.Text);
        }

        // Display the short file name.
        private void btnToShort_Click(object sender, EventArgs e)
        {
            txtShortName.Text = ShortFileName(txtLongName.Text);
        }

        // Return the short file name for a long file name.
        private string ShortFileName(string long_name)
        {
            char[] name_chars = new char[1024];
            long length = GetShortPathName(
                long_name, name_chars,
                name_chars.Length);

            string short_name = new string(name_chars);
            return short_name.Substring(0, (int)length);
        }

        // Return the long file name for a short file name.
        private string LongFileName(string short_name)
        {
            return new FileInfo(short_name).FullName;
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
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.txtLongName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnToShort = new System.Windows.Forms.Button();
            this.btnToLong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Short Name:";
            // 
            // txtShortName
            // 
            this.txtShortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortName.Location = new System.Drawing.Point(83, 14);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(252, 20);
            this.txtShortName.TabIndex = 1;
            // 
            // txtLongName
            // 
            this.txtLongName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLongName.Location = new System.Drawing.Point(83, 43);
            this.txtLongName.Name = "txtLongName";
            this.txtLongName.Size = new System.Drawing.Size(252, 20);
            this.txtLongName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Long Name:";
            // 
            // btnToShort
            // 
            this.btnToShort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToShort.Image = Properties.Resources.Up;
            this.btnToShort.Location = new System.Drawing.Point(341, 41);
            this.btnToShort.Name = "btnToShort";
            this.btnToShort.Size = new System.Drawing.Size(25, 23);
            this.btnToShort.TabIndex = 7;
            this.btnToShort.UseVisualStyleBackColor = true;
            this.btnToShort.Click += new System.EventHandler(this.btnToShort_Click);
            // 
            // btnToLong
            // 
            this.btnToLong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToLong.Image = Properties.Resources.Down;
            this.btnToLong.Location = new System.Drawing.Point(341, 12);
            this.btnToLong.Name = "btnToLong";
            this.btnToLong.Size = new System.Drawing.Size(25, 23);
            this.btnToLong.TabIndex = 4;
            this.btnToLong.UseVisualStyleBackColor = true;
            this.btnToLong.Click += new System.EventHandler(this.btnToLong_Click);
            // 
            // howto_long_short_file_names_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 76);
            this.Controls.Add(this.btnToShort);
            this.Controls.Add(this.txtLongName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnToLong);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.label1);
            this.Name = "howto_long_short_file_names_Form1";
            this.Text = "howto_long_short_file_names";
            this.Load += new System.EventHandler(this.howto_long_short_file_names_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Button btnToLong;
        private System.Windows.Forms.Button btnToShort;
        private System.Windows.Forms.TextBox txtLongName;
        private System.Windows.Forms.Label label2;
    }
}

