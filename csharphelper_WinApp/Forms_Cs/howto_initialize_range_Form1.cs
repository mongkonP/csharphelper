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
     public partial class howto_initialize_range_Form1:Form
  { 


        public howto_initialize_range_Form1()
        {
            InitializeComponent();
        }

        private void howto_initialize_range_Form1_Load(object sender, EventArgs e)
        {
            // 101, 102, 103, ... 120.
            int[] array_range = Enumerable.Range(101, 20).ToArray<int>();
            lstArrayRange.DataSource = array_range;

            // 1001, 1002, 1003, ... 1020.
            List<int> list_range = Enumerable.Range(1001, 20).ToList<int>();
            lstListRange.DataSource = list_range;

            // 13, 13, 13, ... 13.
            int[] array_repeat = Enumerable.Repeat<int>(13, 20).ToArray();
            lstArrayRepeat.DataSource = array_repeat;

            // 1337, 1337, 1337, ... 1337.
            List<int> list_repeat = Enumerable.Repeat(1337, 20).ToList<int>();
            lstListRepeat.DataSource = list_repeat;
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
            this.lstArrayRange = new System.Windows.Forms.ListBox();
            this.lstArrayRepeat = new System.Windows.Forms.ListBox();
            this.lstListRepeat = new System.Windows.Forms.ListBox();
            this.lstListRange = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstArrayRange
            // 
            this.lstArrayRange.FormattingEnabled = true;
            this.lstArrayRange.Location = new System.Drawing.Point(12, 12);
            this.lstArrayRange.Name = "lstArrayRange";
            this.lstArrayRange.Size = new System.Drawing.Size(120, 95);
            this.lstArrayRange.TabIndex = 0;
            // 
            // lstArrayRepeat
            // 
            this.lstArrayRepeat.FormattingEnabled = true;
            this.lstArrayRepeat.Location = new System.Drawing.Point(138, 12);
            this.lstArrayRepeat.Name = "lstArrayRepeat";
            this.lstArrayRepeat.Size = new System.Drawing.Size(120, 95);
            this.lstArrayRepeat.TabIndex = 1;
            // 
            // lstListRepeat
            // 
            this.lstListRepeat.FormattingEnabled = true;
            this.lstListRepeat.Location = new System.Drawing.Point(138, 113);
            this.lstListRepeat.Name = "lstListRepeat";
            this.lstListRepeat.Size = new System.Drawing.Size(120, 95);
            this.lstListRepeat.TabIndex = 3;
            // 
            // lstListRange
            // 
            this.lstListRange.FormattingEnabled = true;
            this.lstListRange.Location = new System.Drawing.Point(12, 113);
            this.lstListRange.Name = "lstListRange";
            this.lstListRange.Size = new System.Drawing.Size(120, 95);
            this.lstListRange.TabIndex = 2;
            // 
            // howto_initialize_range_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 218);
            this.Controls.Add(this.lstListRepeat);
            this.Controls.Add(this.lstListRange);
            this.Controls.Add(this.lstArrayRepeat);
            this.Controls.Add(this.lstArrayRange);
            this.Name = "howto_initialize_range_Form1";
            this.Text = "howto_initialize_range";
            this.Load += new System.EventHandler(this.howto_initialize_range_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstArrayRange;
        private System.Windows.Forms.ListBox lstArrayRepeat;
        private System.Windows.Forms.ListBox lstListRepeat;
        private System.Windows.Forms.ListBox lstListRange;
    }
}

