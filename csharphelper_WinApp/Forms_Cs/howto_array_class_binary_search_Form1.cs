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
     public partial class howto_array_class_binary_search_Form1:Form
  { 


        public howto_array_class_binary_search_Form1()
        {
            InitializeComponent();
        }

        // The data values.
        private const int NumValues = 100;
        private int[] Values;

        // Make some random values.
        private void howto_array_class_binary_search_Form1_Load(object sender, EventArgs e)
        {
            // Generate random values.
            Random rand = new Random();
            Values = new int[NumValues];
            for (int i = 0; i < NumValues; i++)
            {
                Values[i] = rand.Next(0, 100);
            }

            // Sort the values.
            Array.Sort(Values);

            // Display the values.
            lstValues.DataSource = Values;
        }

        // Find a value.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the target value.
            int target = int.Parse(txtValue.Text);

            // Try to find it.
            int index = Array.BinarySearch(Values, target);

            // Select the value.
            if (index >= 0)
            {
                // We found the target. Select it.
                lstValues.SelectedIndex = index;
            }
            else
            {
                // We didn't find the target. Select a nearby value.
                index = -index;
                if (index >= NumValues) index = NumValues - 1;
                lstValues.SelectedIndex = index;
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstValues = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(147, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(55, 14);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(56, 20);
            this.txtValue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Value:";
            // 
            // lstValues
            // 
            this.lstValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstValues.FormattingEnabled = true;
            this.lstValues.IntegralHeight = false;
            this.lstValues.Location = new System.Drawing.Point(15, 41);
            this.lstValues.Name = "lstValues";
            this.lstValues.Size = new System.Drawing.Size(207, 208);
            this.lstValues.TabIndex = 6;
            // 
            // howto_array_class_binary_search_Form1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 261);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstValues);
            this.Name = "howto_array_class_binary_search_Form1";
            this.Text = "howto_array_class_binary_search";
            this.Load += new System.EventHandler(this.howto_array_class_binary_search_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstValues;
    }
}

