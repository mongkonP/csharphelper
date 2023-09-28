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
     public partial class howto_initialize_dictionary_Form1:Form
  { 


        public howto_initialize_dictionary_Form1()
        {
            InitializeComponent();
        }

        // The dictionary of digit names.
        private Dictionary<int, string> Numbers = new Dictionary<int, string>()
        {
            {0, "Zero"},
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"}
        };

        // Display values from the dictionary.
        private void howto_initialize_dictionary_Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                lstNumbers.Items.Add(i.ToString() + '\t' + Numbers[i]);
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
            this.lstNumbers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstNumbers
            // 
            this.lstNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNumbers.FormattingEnabled = true;
            this.lstNumbers.IntegralHeight = false;
            this.lstNumbers.Location = new System.Drawing.Point(0, 0);
            this.lstNumbers.Name = "lstNumbers";
            this.lstNumbers.Size = new System.Drawing.Size(311, 151);
            this.lstNumbers.TabIndex = 0;
            // 
            // howto_initialize_dictionary_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 151);
            this.Controls.Add(this.lstNumbers);
            this.Name = "howto_initialize_dictionary_Form1";
            this.Text = "howto_initialize_dictionary";
            this.Load += new System.EventHandler(this.howto_initialize_dictionary_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstNumbers;
    }
}

