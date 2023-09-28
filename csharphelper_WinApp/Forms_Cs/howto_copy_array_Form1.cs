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
     public partial class howto_copy_array_Form1:Form
  { 


        public howto_copy_array_Form1()
        {
            InitializeComponent();
        }

        // Run the trials.
        private void btnGo_Click(object sender, EventArgs e)
        {
            lblForLoop.Text = "";
            lblArrayCopy.Text = "";
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            int num_items = int.Parse(txtNumItems.Text);
            int num_trials = int.Parse(txtNumTrials.Text);

            int[] array1 = new int[num_items];
            int[] array2 = new int[num_items];

            // Initialize the first array.
            for (int i = 0; i < num_items; i++)
            {
                array1[i] = i;
            }
            DateTime start_time, stop_time;
            TimeSpan elapsed;

            // Use a for loop.
            start_time = DateTime.Now;
            for (int trial = 0; trial < num_trials; trial++)
            {
                for (int i = 0; i < num_items; i++)
                {
                    array2[i] = array1[i];
                }
            }
            stop_time = DateTime.Now;
            elapsed = stop_time - start_time;
            lblForLoop.Text = elapsed.TotalSeconds.ToString("0.00") + " seconds";
            Application.DoEvents();

            // Use Array.Copy.
            start_time = DateTime.Now;
            for (int trial = 0; trial < num_trials; trial++)
            {
                Array.Copy(array1, array2, array1.Length);
            }
            stop_time = DateTime.Now;
            elapsed = stop_time - start_time;
            lblArrayCopy.Text = elapsed.TotalSeconds.ToString("0.00") + " seconds";

            Cursor = Cursors.Default;
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
            this.txtNumItems = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblArrayCopy = new System.Windows.Forms.Label();
            this.lblForLoop = new System.Windows.Forms.Label();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Items:";
            // 
            // txtNumItems
            // 
            this.txtNumItems.Location = new System.Drawing.Point(79, 14);
            this.txtNumItems.Name = "txtNumItems";
            this.txtNumItems.Size = new System.Drawing.Size(67, 20);
            this.txtNumItems.TabIndex = 0;
            this.txtNumItems.Text = "100000";
            this.txtNumItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(168, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "For Loop:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Array.Copy:";
            // 
            // lblArrayCopy
            // 
            this.lblArrayCopy.AutoSize = true;
            this.lblArrayCopy.Location = new System.Drawing.Point(79, 98);
            this.lblArrayCopy.Name = "lblArrayCopy";
            this.lblArrayCopy.Size = new System.Drawing.Size(0, 13);
            this.lblArrayCopy.TabIndex = 6;
            // 
            // lblForLoop
            // 
            this.lblForLoop.AutoSize = true;
            this.lblForLoop.Location = new System.Drawing.Point(79, 72);
            this.lblForLoop.Name = "lblForLoop";
            this.lblForLoop.Size = new System.Drawing.Size(0, 13);
            this.lblForLoop.TabIndex = 7;
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Location = new System.Drawing.Point(79, 40);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(67, 20);
            this.txtNumTrials.TabIndex = 1;
            this.txtNumTrials.Text = "10000";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "# Trials:";
            // 
            // howto_copy_array_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 129);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblForLoop);
            this.Controls.Add(this.lblArrayCopy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumItems);
            this.Controls.Add(this.label1);
            this.Name = "howto_copy_array_Form1";
            this.Text = "howto_copy_array";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumItems;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblArrayCopy;
        private System.Windows.Forms.Label lblForLoop;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Label label4;
    }
}

