using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_is_file_locked_Form1:Form
  { 


        public howto_is_file_locked_Form1()
        {
            InitializeComponent();
        }

        private void howto_is_file_locked_Form1_Load(object sender, EventArgs e)
        {
            txtFileName.Text = Application.ExecutablePath;
            cboAccess.SelectedIndex = 0;
        }

        private void btnIsLocked_Click(object sender, EventArgs e)
        {
            FileAccess file_access;
            switch (cboAccess.Text)
            {
                case "Read":
                    file_access = FileAccess.Read;
                    break;
                case "Write":
                    file_access = FileAccess.Write;
                    break;
                default:
                    file_access = FileAccess.ReadWrite;
                    break;
            }
            if (FileIsLocked(txtFileName.Text, file_access))
            {
                MessageBox.Show("Locked");
            }
            else
            {
                MessageBox.Show("Not locked");
            }
        }

        // Return true if the file is locked for the indicated access.
        private bool FileIsLocked(string filename, FileAccess file_access)
        {
            // Try to open the file with the indicated access.
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open, file_access);
                fs.Close();
                return false;
            }
            catch (IOException)
            {
                return true;
            }
            catch (Exception)
            {
                throw;
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
            this.cboAccess = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIsLocked = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboAccess
            // 
            this.cboAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccess.FormattingEnabled = true;
            this.cboAccess.Items.AddRange(new object[] {
            "Read",
            "Write",
            "Read/Write"});
            this.cboAccess.Location = new System.Drawing.Point(75, 36);
            this.cboAccess.Name = "cboAccess";
            this.cboAccess.Size = new System.Drawing.Size(121, 21);
            this.cboAccess.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Access:";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(75, 10);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(197, 20);
            this.txtFileName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Name:";
            // 
            // btnIsLocked
            // 
            this.btnIsLocked.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnIsLocked.Location = new System.Drawing.Point(105, 63);
            this.btnIsLocked.Name = "btnIsLocked";
            this.btnIsLocked.Size = new System.Drawing.Size(75, 23);
            this.btnIsLocked.TabIndex = 6;
            this.btnIsLocked.Text = "Is Locked?";
            this.btnIsLocked.UseVisualStyleBackColor = true;
            this.btnIsLocked.Click += new System.EventHandler(this.btnIsLocked_Click);
            // 
            // howto_is_file_locked_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 96);
            this.Controls.Add(this.cboAccess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIsLocked);
            this.Name = "howto_is_file_locked_Form1";
            this.Text = "howto_is_file_locked";
            this.Load += new System.EventHandler(this.howto_is_file_locked_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAccess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIsLocked;
    }
}

