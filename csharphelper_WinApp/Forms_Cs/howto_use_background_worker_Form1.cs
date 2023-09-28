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
     public partial class howto_use_background_worker_Form1:Form
  { 


        public howto_use_background_worker_Form1()
        {
            InitializeComponent();
        }

        // Use the BackgroundWorker to perform a long task.
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (btnGo.Text == "Go")
            {
                // Start the process.
                lblStatus.Text = "Working...";
                btnGo.Text = "Stop";
                prgPercentComplete.Value = 0;
                prgPercentComplete.Visible = true;

                // Start the BackgroundWorker.
                bgwLongTask.RunWorkerAsync();
            }
            else
            {
                // Stop the process.
                bgwLongTask.CancelAsync();
            }
        }

        // Perform the long task.
        private void bgwLongTask_DoWork(object sender, DoWorkEventArgs e)
        {
            // Spend 10 seconds doing nothing.
            for (int i = 1; i <= 10; i++)
            {
                // If we should stop, do so.
                if (bgwLongTask.CancellationPending)
                {
                    // Indicate that the task was canceled.
                    e.Cancel = true;
                    break;
                }

                // Sleep.
                System.Threading.Thread.Sleep(1000);

                // Notify the UI thread of our progress.
                bgwLongTask.ReportProgress(i * 10);
            }
        }

        // Update the progress bar.
        private void bgwLongTask_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgPercentComplete.Value = e.ProgressPercentage;
        }

        // The long task is done.
        private void bgwLongTask_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblStatus.Text = "Canceled";
            }
            else
            {
                lblStatus.Text = "Finished";
            }
            btnGo.Text = "Go";
            prgPercentComplete.Visible = false;
        }

        // Display the current time.
        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("T");
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
            this.components = new System.ComponentModel.Container();
            this.btnGo = new System.Windows.Forms.Button();
            this.prgPercentComplete = new System.Windows.Forms.ProgressBar();
            this.lblClock = new System.Windows.Forms.Label();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.bgwLongTask = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(139, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 20;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // prgPercentComplete
            // 
            this.prgPercentComplete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prgPercentComplete.Location = new System.Drawing.Point(12, 41);
            this.prgPercentComplete.Name = "prgPercentComplete";
            this.prgPercentComplete.Size = new System.Drawing.Size(329, 17);
            this.prgPercentComplete.TabIndex = 25;
            this.prgPercentComplete.Visible = false;
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Location = new System.Drawing.Point(4, 4);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(0, 13);
            this.lblClock.TabIndex = 26;
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 74);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 27;
            // 
            // bgwLongTask
            // 
            this.bgwLongTask.WorkerReportsProgress = true;
            this.bgwLongTask.WorkerSupportsCancellation = true;
            this.bgwLongTask.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLongTask_DoWork);
            this.bgwLongTask.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLongTask_RunWorkerCompleted);
            this.bgwLongTask.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwLongTask_ProgressChanged);
            // 
            // howto_use_background_worker_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 96);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.prgPercentComplete);
            this.Controls.Add(this.btnGo);
            this.Name = "howto_use_background_worker_Form1";
            this.Text = "howto_use_background_worker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ProgressBar prgPercentComplete;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.Label lblStatus;
        private System.ComponentModel.BackgroundWorker bgwLongTask;

    }
}

