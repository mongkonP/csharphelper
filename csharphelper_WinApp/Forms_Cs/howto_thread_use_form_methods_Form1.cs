using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

 

using howto_thread_use_form_methods;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_thread_use_form_methods_Form1:Form
  { 


        public howto_thread_use_form_methods_Form1()
        {
            InitializeComponent();
        }

        // This value is incremented by the thread.
        public int Value = 0;

        // Make and start a new counter object.
        private int thread_num = 0;
        private void btnStartThread_Click(object sender, EventArgs e)
        {
            // Make a new counter object.
            Counter new_counter = new Counter(this, thread_num);
            thread_num++;

            // Make a thread to run the object's Run method.
            Thread counter_thread = new Thread(new_counter.Run);

            // Make this a background thread so it automatically
            // aborts when the main program stops.
            counter_thread.IsBackground = true;

            // Start the thread.
            counter_thread.Start();
        }

        // Add the text to the results.
        // The form provides this service because the
        // thread cannot access the form's controls directly.
        public void DisplayValue(string txt)
        {
            lstResults.Items.Add(txt);
            lstResults.SelectedIndex = lstResults.Items.Count - 1;
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
            this.lstResults = new System.Windows.Forms.ListBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.btnStartThread = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(15, 208);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(324, 121);
            this.lstResults.TabIndex = 16;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(12, 189);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(72, 16);
            this.Label2.TabIndex = 15;
            this.Label2.Text = "Results:";
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.Location = new System.Drawing.Point(12, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(327, 32);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Note that you can interact with the form (for example, enter text in the TextBox)" +
                " while the thread is running.";
            // 
            // TextBox1
            // 
            this.TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox1.Location = new System.Drawing.Point(15, 45);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(324, 112);
            this.TextBox1.TabIndex = 12;
            // 
            // btnStartThread
            // 
            this.btnStartThread.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStartThread.Location = new System.Drawing.Point(138, 163);
            this.btnStartThread.Name = "btnStartThread";
            this.btnStartThread.Size = new System.Drawing.Size(75, 23);
            this.btnStartThread.TabIndex = 13;
            this.btnStartThread.Text = "Start Thread";
            this.btnStartThread.Click += new System.EventHandler(this.btnStartThread_Click);
            // 
            // howto_thread_use_form_methods_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 339);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.btnStartThread);
            this.Name = "howto_thread_use_form_methods_Form1";
            this.Text = "howto_thread_use_form_methods";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstResults;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Button btnStartThread;
    }
}

