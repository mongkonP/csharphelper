using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_generic_priority_queue;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_generic_priority_queue_Form1:Form
  { 


        public howto_generic_priority_queue_Form1()
        {
            InitializeComponent();
        }

        // The priority queue.
        private PriorityQueue<string> Queue = new PriorityQueue<string>();

        // Add an item to the queue.
        private void btnEnqueue_Click(object sender, EventArgs e)
        {
            Queue.Enqueue(txtValue.Text, int.Parse(txtPriority.Text));
            txtValue.Clear();
            txtPriority.Clear();
            txtValue.Focus();
            btnDequeue.Enabled = true;
        }

        // Remove the highest priority item from the queue.
        private void btnDequeue_Click(object sender, EventArgs e)
        {
            string top_value;
            int top_priority;
            Queue.Dequeue(out top_value, out top_priority);
            txtValue.Text = top_value;
            txtPriority.Text = top_priority.ToString();
            btnDequeue.Enabled = (Queue.NumItems > 0);
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
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnEnqueue = new System.Windows.Forms.Button();
            this.btnDequeue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(59, 14);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(192, 20);
            this.txtValue.TabIndex = 0;
            // 
            // btnEnqueue
            // 
            this.btnEnqueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnqueue.Location = new System.Drawing.Point(257, 12);
            this.btnEnqueue.Name = "btnEnqueue";
            this.btnEnqueue.Size = new System.Drawing.Size(75, 23);
            this.btnEnqueue.TabIndex = 2;
            this.btnEnqueue.Text = "Enqueue";
            this.btnEnqueue.UseVisualStyleBackColor = true;
            this.btnEnqueue.Click += new System.EventHandler(this.btnEnqueue_Click);
            // 
            // btnDequeue
            // 
            this.btnDequeue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDequeue.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDequeue.Enabled = false;
            this.btnDequeue.Location = new System.Drawing.Point(257, 41);
            this.btnDequeue.Name = "btnDequeue";
            this.btnDequeue.Size = new System.Drawing.Size(75, 23);
            this.btnDequeue.TabIndex = 3;
            this.btnDequeue.Text = "Dequeue";
            this.btnDequeue.UseVisualStyleBackColor = true;
            this.btnDequeue.Click += new System.EventHandler(this.btnDequeue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Priority:";
            // 
            // txtPriority
            // 
            this.txtPriority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPriority.Location = new System.Drawing.Point(59, 40);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(192, 20);
            this.txtPriority.TabIndex = 1;
            // 
            // howto_generic_priority_queue_Form1
            // 
            this.AcceptButton = this.btnEnqueue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDequeue;
            this.ClientSize = new System.Drawing.Size(344, 79);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPriority);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDequeue);
            this.Controls.Add(this.btnEnqueue);
            this.Controls.Add(this.txtValue);
            this.Name = "howto_generic_priority_queue_Form1";
            this.Text = "howto_generic_priority_queue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnEnqueue;
        private System.Windows.Forms.Button btnDequeue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPriority;
    }
}

