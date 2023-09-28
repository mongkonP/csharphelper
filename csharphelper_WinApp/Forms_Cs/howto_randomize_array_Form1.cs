using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_randomize_array;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_randomize_array_Form1:Form
  { 


        public howto_randomize_array_Form1()
        {
            InitializeComponent();
        }

        private void Randomize_Click(object sender, EventArgs e)
        {
            // Put the items in an array.
            string[] items = txtItems.Lines;

            // Randomize.
            Randomizer.Randomize(items);

            // Display the result.
            txtResult.Lines = items;
            txtResult.Select(0, 0);
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
            this.txtItems = new System.Windows.Forms.TextBox();
            this.Randomize = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtItems
            // 
            this.txtItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtItems.Location = new System.Drawing.Point(12, 12);
            this.txtItems.Multiline = true;
            this.txtItems.Name = "txtItems";
            this.txtItems.Size = new System.Drawing.Size(107, 165);
            this.txtItems.TabIndex = 0;
            this.txtItems.Text = "Apple\r\nBanana\r\nCherry\r\nDate\r\nEagle\r\nFish\r\nGolf\r\nHarp\r\nIbex\r\nJackel\r\nKangaroo";
            // 
            // Randomize
            // 
            this.Randomize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Randomize.Location = new System.Drawing.Point(125, 83);
            this.Randomize.Name = "Randomize";
            this.Randomize.Size = new System.Drawing.Size(75, 23);
            this.Randomize.TabIndex = 2;
            this.Randomize.Text = "Randomize";
            this.Randomize.UseVisualStyleBackColor = true;
            this.Randomize.Click += new System.EventHandler(this.Randomize_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResult.Location = new System.Drawing.Point(206, 12);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(107, 165);
            this.txtResult.TabIndex = 3;
            // 
            // howto_randomize_array_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 189);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.Randomize);
            this.Controls.Add(this.txtItems);
            this.Name = "howto_randomize_array_Form1";
            this.Text = "howto_randomize_array";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItems;
        private System.Windows.Forms.Button Randomize;
        private System.Windows.Forms.TextBox txtResult;
    }
}

