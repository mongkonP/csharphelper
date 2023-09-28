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
     public partial class howto_bind_listbox_Form1:Form
  { 


        public howto_bind_listbox_Form1()
        {
            InitializeComponent();
        }

        // Display data in the ListBoxes.
        private void howto_bind_listbox_Form1_Load(object sender, EventArgs e)
        {
            string[] animal_array = { "ape", "bear", "cat", "dolphin", "eagle", "fox", "giraffe" };
            List<string> animal_list = new List<string>(animal_array);

            lstArray.DataSource = animal_array;
            lstList.DataSource = animal_list;
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
            this.lstArray = new System.Windows.Forms.ListBox();
            this.lstList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Array";
            // 
            // lstArray
            // 
            this.lstArray.FormattingEnabled = true;
            this.lstArray.IntegralHeight = false;
            this.lstArray.Location = new System.Drawing.Point(12, 25);
            this.lstArray.Name = "lstArray";
            this.lstArray.Size = new System.Drawing.Size(120, 96);
            this.lstArray.TabIndex = 1;
            // 
            // lstList
            // 
            this.lstList.FormattingEnabled = true;
            this.lstList.IntegralHeight = false;
            this.lstList.Location = new System.Drawing.Point(138, 25);
            this.lstList.Name = "lstList";
            this.lstList.Size = new System.Drawing.Size(120, 96);
            this.lstList.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "List";
            // 
            // howto_bind_listbox_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 133);
            this.Controls.Add(this.lstList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstArray);
            this.Controls.Add(this.label1);
            this.Name = "howto_bind_listbox_Form1";
            this.Text = "howto_bind_listbox";
            this.Load += new System.EventHandler(this.howto_bind_listbox_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstArray;
        private System.Windows.Forms.ListBox lstList;
        private System.Windows.Forms.Label label2;
    }
}

