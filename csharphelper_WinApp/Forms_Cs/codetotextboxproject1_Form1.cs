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
     public partial class codetotextboxproject1_Form1:Form
  { 


        public codetotextboxproject1_Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\CodeToTextProject\CodeToTextBoxProject1\CodeToTextBoxProject1\codetotextboxproject1_Form1.cs")) //Open and close StreamReader
                {
                    // Read and Display text from codetotextboxproject1_Form1.cs
                    string parser;
                    while ((parser = sr.ReadLine()) != null)
                    {
                        textBox1.Text += parser + "\r\n";
                    }
                }
            }
            catch (Exception error)
            {
                textBox1.Text = ("The file could not be read:" + " " + error.Message); //If something goes wrong, show this.
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Go!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 43);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1280, 175);
            this.textBox1.TabIndex = 1;
            // 
            // codetotextboxproject1_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 231);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "codetotextboxproject1_Form1";
            this.Text = "Code To Text Box Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

