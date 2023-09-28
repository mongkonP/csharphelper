using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_threaded_graph_Form1:Form
  { 


        public howto_threaded_graph_Form1()
        {
            InitializeComponent();
        }

        private int Ymid;
        private int YValue;
        private const int GridStep = 40;

        private Thread GraphThread;

        // Get ready.
        private void howto_threaded_graph_Form1_Load(object sender, EventArgs e)
        {
            Ymid = picGraph.ClientSize.Height / 2;
            YValue = Ymid;

            // Make the Bitmap and Graphics objects.
            int wid = picGraph.ClientSize.Width;
            int hgt = picGraph.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            Graphics gr = Graphics.FromImage(bm);

            // Draw guide lines.
            gr.Clear(Color.Blue);
            for (int i = Ymid; i <= picGraph.ClientSize.Height; i += GridStep)
            {
                gr.DrawLine(Pens.LightBlue, 0, i, wid - 1, i);
            }
            for (int i = Ymid; i >= 0; i -= GridStep)
            {
                gr.DrawLine(Pens.LightBlue, 0, i, wid - 1, i);
            }

            picGraph.Image = bm;
        }

        // Start drawing the graph.
        private void btnGraph_Click(object sender, EventArgs e)
        {
            // Uncomment the following two lines
            // to see what happens without threading.
            //DrawGraph();
            //return;

            if (GraphThread == null)
            {
                // The thread isn't running. Start it.
                AddStatus("Starting thread");

                GraphThread = new Thread(DrawGraph);
                GraphThread.Priority = ThreadPriority.BelowNormal;
                GraphThread.IsBackground = true;
                GraphThread.Start();

                AddStatus("Thread started");

                btnGraph.Text = "Stop";
            }
            else
            {
                // The thread is running. Stop it.
                AddStatus("Stopping thread");

                GraphThread.Abort();
                GraphThread = null;

                AddStatus("Thread stopped");

                btnGraph.Text = "Start";
            }
        }

        // Draw a graph until stopped.
        private void DrawGraph()
        {
            try
            {
                // Generate pseudo-random values.
                int y = YValue;
                for (; ; )
                {
                    // Generate the next value.
                    NewValue();

                    // Plot the new value.
                    PlotValue(y, YValue);
                    y = YValue;
                }
            }
            catch (Exception ex)
            {
                AddStatus("[Thread] " + ex.Message);
            }
        }

        // Generate the next value.
        private Random Rnd = new Random();
        private void NewValue()
        {
            // Delay a bit before calculating the value.
            DateTime stop_time = DateTime.Now.AddMilliseconds(20);
            while (DateTime.Now < stop_time) { };

            // Calculate the next value.
            YValue += Rnd.Next(-4, 5);
            if (YValue < 0) YValue = 0;
            if (YValue >= picGraph.ClientSize.Height - 1)
                YValue = picGraph.ClientSize.Height - 1;
        }

        // Define a delegate type that takes two int parameters.
        private delegate void PlotValueDelegate(int old_y, int new_y);

        // Plot a new value.
        private void PlotValue(int old_y, int new_y)
        {
            // See if we're on the worker thread and thus
            // need to invoke the main UI thread.
            if (this.InvokeRequired)
            {
                // Make arguments for the delegate.
                object[] args = new object[] { old_y, new_y };

                // Make the delegate.
                PlotValueDelegate plot_value_delegate = PlotValue;

                // Invoke the delegate on the main UI thread.
                this.Invoke(plot_value_delegate, args);

                // We're done.
                return;
            }

            // Invoke not required. Go ahead and plot.
            // Make the Bitmap and Graphics objects.
            int wid = picGraph.ClientSize.Width;
            int hgt = picGraph.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            Graphics gr = Graphics.FromImage(bm);

            // Move the old data one pixel to the left.
            gr.DrawImage(picGraph.Image, -1, 0);

            // Erase the right edge and draw guide lines.
            gr.DrawLine(Pens.Blue, wid - 1, 0, wid - 1, hgt - 1);
            for (int i = Ymid; i <= picGraph.ClientSize.Height; i += GridStep)
            {
                gr.DrawLine(Pens.LightBlue, wid - 2, i, wid - 1, i);
            }
            for (int i = Ymid; i >= 0; i -= GridStep)
            {
                gr.DrawLine(Pens.LightBlue, wid - 2, i, wid - 1, i);
            }

            // Plot a new pixel.
            gr.DrawLine(Pens.White, wid - 2, old_y, wid - 1, new_y);

            // Display the result.
            picGraph.Image = bm;
            picGraph.Refresh();

            gr.Dispose();
        }

        // Define a delegate type that takes a string parameter.
        private delegate void AddStatusDelegate(string txt);

        // Add a status string to txtStatus.
        private void AddStatus(string txt)
        {
            // See if we're on the worker thread and thus
            // need to invoke the main UI thread.
            if (this.InvokeRequired)
            {
                // Make arguments for the delegate.
                object[] args = new object[] { txt };

                // Make the delegate.
                AddStatusDelegate add_status_delegate = AddStatus;

                // Invoke the delegate on the main UI thread.
                this.Invoke(add_status_delegate, args);

                // We're done.
                return;
            }

            // No Invoke required. Just display the message.
            txtStatus.AppendText("\r\n" + txt);
            txtStatus.Select(txtStatus.Text.Length, 0);
            txtStatus.ScrollToCaret();
        }

        // Display the current time.
        private void tmrUpdateClock_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("T");
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
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnGraph = new System.Windows.Forms.Button();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.tmrUpdateClock = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(1, 220);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(291, 48);
            this.txtStatus.TabIndex = 11;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(81, 4);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(80, 16);
            this.lblTime.TabIndex = 10;
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(9, 4);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(48, 24);
            this.btnGraph.TabIndex = 9;
            this.btnGraph.Text = "Graph";
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(1, 36);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(291, 180);
            this.picGraph.TabIndex = 8;
            this.picGraph.TabStop = false;
            // 
            // tmrUpdateClock
            // 
            this.tmrUpdateClock.Enabled = true;
            this.tmrUpdateClock.Interval = 250;
            this.tmrUpdateClock.Tick += new System.EventHandler(this.tmrUpdateClock_Tick);
            // 
            // howto_threaded_graph_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_threaded_graph_Form1";
            this.Text = "howto_threaded_graph";
            this.Load += new System.EventHandler(this.howto_threaded_graph_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtStatus;
        internal System.Windows.Forms.Label lblTime;
        internal System.Windows.Forms.Button btnGraph;
        internal System.Windows.Forms.PictureBox picGraph;
        internal System.Windows.Forms.Timer tmrUpdateClock;
    }
}

