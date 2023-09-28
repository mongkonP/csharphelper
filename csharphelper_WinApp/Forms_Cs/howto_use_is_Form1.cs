using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_use_is;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_use_is_Form1:Form
  { 


        public howto_use_is_Form1()
        {
            InitializeComponent();
        }

        private void howto_use_is_Form1_Load(object sender, EventArgs e)
        {
            Person person = new Person();
            Student student = new Student();
            object obj = student;

            if (student is Student)
                lstResults.Items.Add("a_student is a Student");
            else
                lstResults.Items.Add("a_student is not a Student");

            if (student is Person)
                lstResults.Items.Add("a_student is a Person");
            else
                lstResults.Items.Add("a_student is not a Person");

            if (person is Person)
                lstResults.Items.Add("a_person is a Person");
            else
                lstResults.Items.Add("a_person is not a Person");

            if (person is Student)
                lstResults.Items.Add("a_person is a Student");
            else
                lstResults.Items.Add("a_person is not a Student");
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
            this.lstResults = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(12, 13);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(212, 69);
            this.lstResults.TabIndex = 1;
            // 
            // howto_use_is_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 95);
            this.Controls.Add(this.lstResults);
            this.Name = "howto_use_is_Form1";
            this.Text = "howto_use_is";
            this.Load += new System.EventHandler(this.howto_use_is_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstResults;
    }
}

