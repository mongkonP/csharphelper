using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_enumerate_pairs;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_enumerate_pairs_Form1:Form
  { 


        public howto_enumerate_pairs_Form1()
        {
            InitializeComponent();
        }

        private void howto_enumerate_pairs_Form1_Load(object sender, EventArgs e)
        {
            // Display the original values.
            string[] value_array =
            {
                "Ankylosaurus", "Brachiosaurus", "Caenagnathus",
                "Diplodocus", "Enigmosaurus","Fabrosaurus",
            };
            lstValues.DataSource = value_array;

            // Display pairs from the array.
            foreach (PairsTools.Pair<string> pair in value_array.Pairs())
                lstFromArray.Items.Add(pair);

            // Make a list holding the values.
            List<string> value_list = new List<string>();
            foreach (string value in value_array) value_list.Add(value);

            // Display pairs from the list.
            foreach (PairsTools.Pair<string> pair in value_list.Pairs())
                lstFromIEnumerable.Items.Add(pair);
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
            this.lstValues = new System.Windows.Forms.ListBox();
            this.lstFromArray = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstFromIEnumerable = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Values";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstValues
            // 
            this.lstValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstValues.FormattingEnabled = true;
            this.lstValues.IntegralHeight = false;
            this.lstValues.Location = new System.Drawing.Point(12, 35);
            this.lstValues.Name = "lstValues";
            this.lstValues.Size = new System.Drawing.Size(80, 225);
            this.lstValues.TabIndex = 1;
            // 
            // lstFromArray
            // 
            this.lstFromArray.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFromArray.FormattingEnabled = true;
            this.lstFromArray.IntegralHeight = false;
            this.lstFromArray.Location = new System.Drawing.Point(98, 35);
            this.lstFromArray.Name = "lstFromArray";
            this.lstFromArray.Size = new System.Drawing.Size(160, 225);
            this.lstFromArray.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(98, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "From Array";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstFromIEnumerable
            // 
            this.lstFromIEnumerable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFromIEnumerable.FormattingEnabled = true;
            this.lstFromIEnumerable.IntegralHeight = false;
            this.lstFromIEnumerable.Location = new System.Drawing.Point(264, 35);
            this.lstFromIEnumerable.Name = "lstFromIEnumerable";
            this.lstFromIEnumerable.Size = new System.Drawing.Size(160, 225);
            this.lstFromIEnumerable.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(264, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "From IEnumerable";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_enumerate_pairs_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 272);
            this.Controls.Add(this.lstFromIEnumerable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstFromArray);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstValues);
            this.Controls.Add(this.label1);
            this.Name = "howto_enumerate_pairs_Form1";
            this.Text = "howto_enumerate_pairs";
            this.Load += new System.EventHandler(this.howto_enumerate_pairs_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstValues;
        private System.Windows.Forms.ListBox lstFromArray;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstFromIEnumerable;
        private System.Windows.Forms.Label label3;
    }
}

