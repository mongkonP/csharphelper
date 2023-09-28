using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

 

using howto_thread_priority;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_thread_priority_Form1:Form
  { 


        public howto_thread_priority_Form1()
        {
            InitializeComponent();
        }

        // Start threads with different priorities.
        private void btnRunThreads_Click(object sender, EventArgs e)
        {
            int num_low = int.Parse(txtNumLow.Text);
            for (int i = 0; i < num_low; i++)
                MakeThread("Low" + i.ToString(),
                    ThreadPriority.BelowNormal);

            int num_normal = int.Parse(txtNumNormal.Text);
            for (int i = 0; i < num_normal; i++)
                MakeThread("Normal" + i.ToString(),
                    ThreadPriority.Normal);

            int num_high = int.Parse(txtNumHigh.Text);
            for (int i = 0; i < num_high; i++)
                MakeThread("High" + i.ToString(),
                    ThreadPriority.AboveNormal);
        }

        // Make a thread with the indicated priority.
        private void MakeThread(string thread_name, ThreadPriority thread_priority)
        {
            // Initialize the thread.
            Counter new_counter = new Counter(thread_name);
            Thread thread = new Thread(new_counter.Run);
            thread.Priority = thread_priority;
            thread.IsBackground = true;
            thread.Name = thread_name;

            // Start the thread.
            thread.Start();
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
            this.btnAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumHigh = new System.Windows.Forms.TextBox();
            this.txtNumNormal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumLow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(174, 30);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(89, 35);
            this.btnAll.TabIndex = 3;
            this.btnAll.Text = "Run Threads";
            this.btnAll.Click += new System.EventHandler(this.btnRunThreads_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "# High Priority:";
            // 
            // txtNumHigh
            // 
            this.txtNumHigh.Location = new System.Drawing.Point(105, 12);
            this.txtNumHigh.Name = "txtNumHigh";
            this.txtNumHigh.Size = new System.Drawing.Size(41, 20);
            this.txtNumHigh.TabIndex = 0;
            this.txtNumHigh.Text = "4";
            this.txtNumHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumNormal
            // 
            this.txtNumNormal.Location = new System.Drawing.Point(105, 38);
            this.txtNumNormal.Name = "txtNumNormal";
            this.txtNumNormal.Size = new System.Drawing.Size(41, 20);
            this.txtNumNormal.TabIndex = 1;
            this.txtNumNormal.Text = "4";
            this.txtNumNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "# Normal Priority:";
            // 
            // txtNumLow
            // 
            this.txtNumLow.Location = new System.Drawing.Point(105, 64);
            this.txtNumLow.Name = "txtNumLow";
            this.txtNumLow.Size = new System.Drawing.Size(41, 20);
            this.txtNumLow.TabIndex = 2;
            this.txtNumLow.Text = "4";
            this.txtNumLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "# Low Priority:";
            // 
            // howto_thread_priority_Form1
            // 
            this.AcceptButton = this.btnAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 96);
            this.Controls.Add(this.txtNumLow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumNormal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumHigh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAll);
            this.Name = "howto_thread_priority_Form1";
            this.Text = "howto_thread_priority";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumHigh;
        private System.Windows.Forms.TextBox txtNumNormal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumLow;
        private System.Windows.Forms.Label label3;
    }
}

