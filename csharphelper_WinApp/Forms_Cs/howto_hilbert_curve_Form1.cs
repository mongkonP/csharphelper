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
     public partial class howto_hilbert_curve_Form1:Form
  { 


        public howto_hilbert_curve_Form1()
        {
            InitializeComponent();
        }

        private bool DoRefresh;
        private float LastX, LastY;
        private Bitmap HilbertImage;

        private void btnGo_Click(object sender, EventArgs e)
        {
            int depth = int.Parse(txtDepth.Text);
            if (depth > 8)
            {
                if (MessageBox.Show("A large depth may take a long time to draw (and will be mostly black anyway). Do you want to continue?",
                    "Continue?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // See if we should refresh as we draw.
            DoRefresh = chkRefresh.Checked;

            // Get the parameters.
            float total_length, start_x, start_y, start_length;

            // See how big we can make the curve.
            if (picCanvas.ClientSize.Height < picCanvas.ClientSize.Width)
            {
                total_length = (float)(0.9 * picCanvas.ClientSize.Height);
            }
            else
            {
                total_length = (float)(0.9 * picCanvas.ClientSize.Width);
            }

            start_x = (picCanvas.ClientSize.Width - total_length) / 2;
            start_y = (picCanvas.ClientSize.Height - total_length) / 2;

            // Compute the side length for this level.
            start_length = (float)(total_length / (Math.Pow(2, depth) - 1));

            HilbertImage = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height);
            picCanvas.Image = HilbertImage;

            using (Graphics gr = Graphics.FromImage(HilbertImage))
            {
                // Draw the curve.
                gr.Clear(picCanvas.BackColor);
                LastX = (int)start_x;
                LastY = (int)start_y;
                Hilbert(gr, depth, start_length, 0);
            }

            // Display the result.
            picCanvas.Refresh();
            this.Cursor = Cursors.Default;
        }

        // Draw a Hilbert curve.
        private void Hilbert(Graphics gr, int depth, float dx, float dy)
        {
            if (depth > 1) Hilbert(gr, depth - 1, dy, dx);
            DrawRelative(gr, dx, dy);
            if (depth > 1) Hilbert(gr, depth - 1, dx, dy);
            DrawRelative(gr, dy, dx);
            if (depth > 1) Hilbert(gr, depth - 1, dx, dy);
            DrawRelative(gr, -dx, -dy);
            if (depth > 1) Hilbert(gr, depth - 1, -dy, -dx);

            if (DoRefresh) picCanvas.Refresh();
        }

        // Draw the line (LastX, LastY)-(LastX + dx, LastY + dy) and
        // update LastX = LastX + dx, LastY = LastY + dy.
        private void DrawRelative(Graphics gr, float dx, float dy)
        {
            gr.DrawLine(Pens.Black, LastX, LastY, LastX + dx, LastY + dy);
            LastX = LastX + dx;
            LastY = LastY + dy;
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.chkRefresh = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(84, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(272, 272);
            this.picCanvas.TabIndex = 9;
            this.picCanvas.TabStop = false;
            // 
            // chkRefresh
            // 
            this.chkRefresh.Location = new System.Drawing.Point(12, 72);
            this.chkRefresh.Name = "chkRefresh";
            this.chkRefresh.Size = new System.Drawing.Size(64, 16);
            this.chkRefresh.TabIndex = 8;
            this.chkRefresh.Text = "Refresh";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(20, 40);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(40, 24);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(44, 8);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(32, 20);
            this.txtDepth.TabIndex = 6;
            this.txtDepth.Text = "4";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(4, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(36, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Depth";
            // 
            // howto_hilbert_curve_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 273);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.chkRefresh);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtDepth);
            this.Controls.Add(this.Label1);
            this.Name = "howto_hilbert_curve_Form1";
            this.Text = "howto_hilbert_curve";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picCanvas;
        internal System.Windows.Forms.CheckBox chkRefresh;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtDepth;
        internal System.Windows.Forms.Label Label1;
    }
}

