using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_efficient_priority_queue2;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_efficient_priority_queue2_Form1:Form
  { 


        public howto_efficient_priority_queue2_Form1()
        {
            InitializeComponent();
        }

        // The priority queue.
        private HeapQueue<string> Queue = new HeapQueue<string>();

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

        // Enable the Enqueue button if the user has
        // entered a data value and a numeric priority.
        private void txt_TextChanged(object sender, EventArgs e)
        {
            int priority;
            bool enabled = int.TryParse(txtPriority.Text, out priority);
            enabled &= (txtValue.Text.Length > 0);
            btnEnqueue.Enabled = enabled;
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDequeue = new System.Windows.Forms.Button();
            this.btnEnqueue = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Priority:";
            // 
            // txtPriority
            // 
            this.txtPriority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPriority.Location = new System.Drawing.Point(59, 41);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(192, 20);
            this.txtPriority.TabIndex = 7;
            this.txtPriority.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Value:";
            // 
            // btnDequeue
            // 
            this.btnDequeue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDequeue.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDequeue.Enabled = false;
            this.btnDequeue.Location = new System.Drawing.Point(257, 42);
            this.btnDequeue.Name = "btnDequeue";
            this.btnDequeue.Size = new System.Drawing.Size(75, 23);
            this.btnDequeue.TabIndex = 9;
            this.btnDequeue.Text = "Dequeue";
            this.btnDequeue.UseVisualStyleBackColor = true;
            this.btnDequeue.Click += new System.EventHandler(this.btnDequeue_Click);
            // 
            // btnEnqueue
            // 
            this.btnEnqueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnqueue.Enabled = false;
            this.btnEnqueue.Location = new System.Drawing.Point(257, 13);
            this.btnEnqueue.Name = "btnEnqueue";
            this.btnEnqueue.Size = new System.Drawing.Size(75, 23);
            this.btnEnqueue.TabIndex = 8;
            this.btnEnqueue.Text = "Enqueue";
            this.btnEnqueue.UseVisualStyleBackColor = true;
            this.btnEnqueue.Click += new System.EventHandler(this.btnEnqueue_Click);
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(59, 15);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(192, 20);
            this.txtValue.TabIndex = 6;
            this.txtValue.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // howto_efficient_priority_queue2_Form1
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
            this.Name = "howto_efficient_priority_queue2_Form1";
            this.Text = "howto_efficient_priority_queue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDequeue;
        private System.Windows.Forms.Button btnEnqueue;
        private System.Windows.Forms.TextBox txtValue;
    }
}

