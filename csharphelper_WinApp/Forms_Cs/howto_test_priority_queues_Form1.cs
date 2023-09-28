using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

using howto_test_priority_queues;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_test_priority_queues_Form1:Form
  { 


        public howto_test_priority_queues_Form1()
        {
            InitializeComponent();
        }

        // Enable the Go button if we have all of the values.
        private void txt_TextChanged(object sender, EventArgs e)
        {
            btnGo.Enabled = (
                (txtNumItems.Text.Length > 0) &&
                (txtNumTrials.Text.Length > 0) &&
                (txtMaxPriority.Text.Length > 0));
        }

        // Run the tests.
        private void btnGo_Click(object sender, EventArgs e)
        {
            lblHeapQueue.Text = "";
            lblListQueue.Text = "";
            Cursor = Cursors.WaitCursor;
            Refresh();

            // Get the input parameters.
            int num_items = int.Parse(txtNumItems.Text);
            int num_trials = int.Parse(txtNumTrials.Text);
            int max_priority = int.Parse(txtMaxPriority.Text) + 1;

            // Make some random values.
            string[] values = new string[num_items];
            int[] priorities = new int[num_items];
            Random rand = new Random();
            for (int i = 0; i < num_items; i++)
            {
                priorities[i] = rand.Next(0, max_priority);
                values[i] = priorities[i].ToString();
            }

            string value;
            int priority;
            Stopwatch watch = new Stopwatch();

            // Test the heap queue.
            watch.Start();
            HeapQueue<string> heap_queue =
                new HeapQueue<string>();
            for (int trial = 0; trial < num_trials; trial++)
            {
                // Save the values.
                for (int i = 0; i < num_items; i++)
                    heap_queue.Enqueue(values[i], priorities[i]);
                // Retrieve the values.
                for (int i = 0; i < num_items; i++)
                    heap_queue.Dequeue(out value, out priority);
            }
            watch.Stop();
            lblHeapQueue.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " seconds";
            lblHeapQueue.Refresh();

            // Test the list queue.
            watch.Reset();
            watch.Start();
            PriorityQueue<string> list_queue =
                new PriorityQueue<string>();
            for (int trial = 0; trial < num_trials; trial++)
            {
                // Save the values.
                for (int i = 0; i < num_items; i++)
                    list_queue.Enqueue(values[i], priorities[i]);
                // Retrieve the values.
                for (int i = 0; i < num_items; i++)
                    list_queue.Dequeue(out value, out priority);
            }
            watch.Stop();
            lblListQueue.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " seconds";
            lblListQueue.Refresh();

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
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxPriority = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHeapQueue = new System.Windows.Forms.Label();
            this.lblListQueue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "# Items:";
            // 
            // txtNumItems
            // 
            this.txtNumItems.Location = new System.Drawing.Point(114, 12);
            this.txtNumItems.Name = "txtNumItems";
            this.txtNumItems.Size = new System.Drawing.Size(73, 20);
            this.txtNumItems.TabIndex = 0;
            this.txtNumItems.Text = "1000";
            this.txtNumItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumItems.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Max Priority:";
            // 
            // txtMaxPriority
            // 
            this.txtMaxPriority.Location = new System.Drawing.Point(114, 64);
            this.txtMaxPriority.Name = "txtMaxPriority";
            this.txtMaxPriority.Size = new System.Drawing.Size(73, 20);
            this.txtMaxPriority.TabIndex = 2;
            this.txtMaxPriority.Text = "1000";
            this.txtMaxPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(208, 36);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "# Trials:";
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Location = new System.Drawing.Point(114, 38);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(73, 20);
            this.txtNumTrials.TabIndex = 1;
            this.txtNumTrials.Text = "1000";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Heap Queue:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "List Queue:";
            // 
            // lblHeapQueue
            // 
            this.lblHeapQueue.AutoSize = true;
            this.lblHeapQueue.Location = new System.Drawing.Point(121, 129);
            this.lblHeapQueue.Name = "lblHeapQueue";
            this.lblHeapQueue.Size = new System.Drawing.Size(0, 13);
            this.lblHeapQueue.TabIndex = 18;
            // 
            // lblListQueue
            // 
            this.lblListQueue.AutoSize = true;
            this.lblListQueue.Location = new System.Drawing.Point(121, 155);
            this.lblListQueue.Name = "lblListQueue";
            this.lblListQueue.Size = new System.Drawing.Size(0, 13);
            this.lblListQueue.TabIndex = 19;
            // 
            // howto_test_priority_queues_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 183);
            this.Controls.Add(this.lblListQueue);
            this.Controls.Add(this.lblHeapQueue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaxPriority);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumItems);
            this.Name = "howto_test_priority_queues_Form1";
            this.Text = "howto_test_priority_queues";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxPriority;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHeapQueue;
        private System.Windows.Forms.Label lblListQueue;
    }
}

