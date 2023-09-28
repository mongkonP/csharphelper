using System;
using System.Windows.Forms;

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_debug_trace_listeners_Form1:Form
  { 


        public howto_debug_trace_listeners_Form1()
        {
            InitializeComponent();
        }

        // Make the listener.
        private void howto_debug_trace_listeners_Form1_Load(object sender, EventArgs e)
        {
            string trace_file = Application.StartupPath + "//trace.txt";
            Trace.Listeners.Add(new TextWriterTraceListener(trace_file));
            Trace.AutoFlush = true;
        }

        // Send a message to the Debug listeners.
        private void btnDebug_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(txtMessage.Text);
            txtMessage.Clear();
            txtMessage.Focus();
        }

        // Send a message to the Trace listeners.
        private void btnTrace_Click(object sender, EventArgs e)
        {
            Trace.WriteLine(txtMessage.Text);
            txtMessage.Clear();
            txtMessage.Focus();
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
            this.btnTrace = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTrace
            // 
            this.btnTrace.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTrace.Location = new System.Drawing.Point(177, 46);
            this.btnTrace.Name = "btnTrace";
            this.btnTrace.Size = new System.Drawing.Size(75, 23);
            this.btnTrace.TabIndex = 7;
            this.btnTrace.Text = "Trace";
            this.btnTrace.UseVisualStyleBackColor = true;
            this.btnTrace.Click += new System.EventHandler(this.btnTrace_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDebug.Location = new System.Drawing.Point(82, 46);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 6;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(71, 13);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(251, 20);
            this.txtMessage.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Message:";
            // 
            // howto_debug_trace_listeners_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 81);
            this.Controls.Add(this.btnTrace);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label1);
            this.Name = "howto_debug_trace_listeners_Form1";
            this.Text = "howto_debug_trace_listeners";
            this.Load += new System.EventHandler(this.howto_debug_trace_listeners_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrace;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label1;
    }
}

