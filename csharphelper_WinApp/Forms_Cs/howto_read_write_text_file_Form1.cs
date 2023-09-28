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
     public partial class howto_read_write_text_file_Form1:Form
  { 


        public howto_read_write_text_file_Form1()
        {
            InitializeComponent();
        }

        // Initialize the File TextBox.
        private void howto_read_write_text_file_Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text=Application.StartupPath + "\\data.txt";
        }

        // Write the text values into the file.
        private void btnWrite_Click(object sender, EventArgs e)
        {
            StreamWriter stream_writer = new StreamWriter(txtFile.Text);
            stream_writer.WriteLine(txtName.Text);
            stream_writer.WriteLine(txtStreet.Text);
            stream_writer.WriteLine(txtCity.Text);
            stream_writer.WriteLine(txtState.Text);
            stream_writer.WriteLine(txtZip.Text);
            stream_writer.Close();  // Don't forget to close the file!

            // Clear the TextBoxes.
            txtName.Clear();
            txtStreet.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtZip.Clear();
        }

        // Read the values back into the TextBoxes.
        private void btnRead_Click(object sender, EventArgs e)
        {
            StreamReader stream_reader = new StreamReader(txtFile.Text);

            txtName.Text = stream_reader.ReadLine();
            txtStreet.Text = stream_reader.ReadLine();
            txtCity.Text = stream_reader.ReadLine();
            txtState.Text = stream_reader.ReadLine();
            txtZip.Text = stream_reader.ReadLine();
            stream_reader.Close();
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(56, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(241, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Rod Stephens";
            // 
            // txtStreet
            // 
            this.txtStreet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet.Location = new System.Drawing.Point(56, 38);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(241, 20);
            this.txtStreet.TabIndex = 3;
            this.txtStreet.Text = "1337 Leet St";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Street:";
            // 
            // txtState
            // 
            this.txtState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtState.Location = new System.Drawing.Point(56, 90);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(241, 20);
            this.txtState.TabIndex = 7;
            this.txtState.Text = "CO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "State:";
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.Location = new System.Drawing.Point(56, 64);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(241, 20);
            this.txtCity.TabIndex = 5;
            this.txtCity.Text = "Programmeria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "City:";
            // 
            // txtZip
            // 
            this.txtZip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZip.Location = new System.Drawing.Point(56, 116);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(241, 20);
            this.txtZip.TabIndex = 9;
            this.txtZip.Text = "80305";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ZIP:";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(56, 171);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(241, 20);
            this.txtFile.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "File:";
            // 
            // btnWrite
            // 
            this.btnWrite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnWrite.Location = new System.Drawing.Point(70, 197);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 12;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnRead
            // 
            this.btnRead.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRead.Location = new System.Drawing.Point(163, 197);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 13;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // howto_read_write_text_file_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 228);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "howto_read_write_text_file_Form1";
            this.Text = "howto_read_write_text_file";
            this.Load += new System.EventHandler(this.howto_read_write_text_file_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnRead;
    }
}

