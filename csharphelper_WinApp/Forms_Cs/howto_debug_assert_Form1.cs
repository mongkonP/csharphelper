using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_debug_assert_Form1:Form
  { 


        public howto_debug_assert_Form1()
        {
            InitializeComponent();
        }

        private void btnAssertOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Average: " + Average(new float[] { 1, 2, 3, 4, 5 }));
        }

        private void btnAssertFails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Average: " + Average(null));
        }

        // Return the average of the numbers.
        private float Average(float[] values)
        {
            Debug.Assert(values != null, "Values array cannot be null");
            Debug.Assert(values.Length > 0, "Values array cannot be empty");
            Debug.Assert(values.Length < 100, "Values array should not contain more than 100 items");

            // If there are no values, return NaN.
            if (values == null || values.Length < 1) return float.NaN;

            // Calculate the average.
            return values.Average();
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
            this.btnAssertOk = new System.Windows.Forms.Button();
            this.btnAssertFails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAssertOk
            // 
            this.btnAssertOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAssertOk.Location = new System.Drawing.Point(105, 29);
            this.btnAssertOk.Name = "btnAssertOk";
            this.btnAssertOk.Size = new System.Drawing.Size(75, 23);
            this.btnAssertOk.TabIndex = 0;
            this.btnAssertOk.Text = "Assert OK";
            this.btnAssertOk.UseVisualStyleBackColor = true;
            this.btnAssertOk.Click += new System.EventHandler(this.btnAssertOk_Click);
            // 
            // btnAssertFails
            // 
            this.btnAssertFails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAssertFails.Location = new System.Drawing.Point(105, 62);
            this.btnAssertFails.Name = "btnAssertFails";
            this.btnAssertFails.Size = new System.Drawing.Size(75, 23);
            this.btnAssertFails.TabIndex = 1;
            this.btnAssertFails.Text = "Assert Fails";
            this.btnAssertFails.UseVisualStyleBackColor = true;
            this.btnAssertFails.Click += new System.EventHandler(this.btnAssertFails_Click);
            // 
            // howto_debug_assert_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 114);
            this.Controls.Add(this.btnAssertFails);
            this.Controls.Add(this.btnAssertOk);
            this.Name = "howto_debug_assert_Form1";
            this.Text = "howto_debug_assert";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAssertOk;
        private System.Windows.Forms.Button btnAssertFails;
    }
}

