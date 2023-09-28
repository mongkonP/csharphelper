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
     public partial class howto_sierpinski_curve_Form1:Form
  { 


        public howto_sierpinski_curve_Form1()
        {
            InitializeComponent();
        }

        private bool m_Refresh;
        private Bitmap m_Bm;

        private void btnGo_Click(object sender, EventArgs e)
        {
            int depth = int.Parse(txtDepth.Text);
            if (depth > 8)
            {
                if (MessageBox.Show("A large depth may take a long time to draw. Do you want to continue?",
                    "Continue?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // See if we should refresh as we draw.
            m_Refresh = chkRefresh.Checked;

            m_Bm = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height);
            picCanvas.Image = m_Bm;

            using (Graphics gr = Graphics.FromImage(m_Bm))
            {
                // Draw the curve.
                gr.Clear(picCanvas.BackColor);

                float dx = (float)(m_Bm.Width / Math.Pow(2, depth - 1) / 8);
                float dy = (float)(m_Bm.Height / Math.Pow(2, depth - 1) / 8);
                Sierpinski(gr, depth, dx, dy);
            }

            // Display the result.
            picCanvas.Refresh();
            this.Cursor = Cursors.Default;
        }

        // Draw a Sierpinski curve.
        private void Sierpinski(Graphics gr, int depth, float dx, float dy)
        {
            float x = 2 * dx;
            float y = dy;

            SierpA(gr, depth, dx, dy, ref x, ref y);
            DrawRel(gr, ref x, ref y, dx, dy);
            SierpB(gr, depth, dx, dy, ref x, ref y);
            DrawRel(gr, ref x, ref y, -dx, dy);
            SierpC(gr, depth, dx, dy, ref x, ref y);
            DrawRel(gr, ref x, ref y, -dx, -dy);
            SierpD(gr, depth, dx, dy, ref x, ref y);
            DrawRel(gr, ref x, ref y, dx, -dy);

            picCanvas.Refresh();
        }

        // Draw right across the top.
        private void SierpA(Graphics gr, float depth, float dx, float dy, ref float x, ref float y)
        {
            if (depth > 0)
            {
                depth--;

                SierpA(gr, depth, dx, dy, ref x, ref y);
                DrawRel(gr, ref x, ref y, dx, dy);
                SierpB(gr, depth, dx, dy, ref x, ref y);
                DrawRel(gr, ref x, ref y, 2 * dx, 0);
                SierpD(gr, depth, dx, dy, ref x, ref y);
                DrawRel(gr, ref x, ref y, dx, -dy);
                SierpA(gr, depth, dx, dy, ref x, ref y);
            }

            if (m_Refresh) picCanvas.Refresh();
        }

        // Draw down on the right.
        private void SierpB(Graphics gr, float depth, float dx, float dy, ref float x, ref float y)
        {
            if (depth > 0)
            {
                depth--;
                SierpB(gr, depth, dx, dy, ref x, ref y);
                DrawRel(gr, ref x, ref y, -dx, dy);
                SierpC(gr, depth, dx, dy, ref x, ref y);
                DrawRel(gr, ref x, ref y, 0, 2 * dy);
                SierpA(gr, depth, dx, dy, ref x, ref y);
                DrawRel(gr, ref x, ref y, dx, dy);
                SierpB(gr, depth, dx, dy, ref x, ref y);
            }

            if (m_Refresh) picCanvas.Refresh();
        }

        // Draw left across the bottom.
        private void SierpC(Graphics gr, float depth, float dx, float dy, ref float x, ref float y)
        {
            if (depth > 0)
            {
                depth--;
                SierpC(gr, depth, dx, dy, ref x, ref y);
                DrawRel(gr, ref x, ref y, -dx, -dy);
                SierpD(gr, depth, dx, dy, ref x, ref y);
                DrawRel(gr, ref x, ref y, -2 * dx, 0);
                SierpB(gr, depth, dx, dy, ref x, ref y);
                DrawRel(gr, ref x, ref y, -dx, dy);
                SierpC(gr, depth, dx, dy, ref x, ref y);
            }

            if (m_Refresh) picCanvas.Refresh();
        }

        // Draw up along the left.
        private void SierpD(Graphics gr, float depth, float dx, float dy, ref float x, ref float y)
        {
            if (depth > 0)
            {
                depth--;
                SierpD(gr, depth, dx, dy, ref x, ref y);
                DrawRel(gr, ref x, ref y, dx, -dy);
                SierpA(gr, depth, dx, dy, ref x, ref y);
                DrawRel(gr, ref x, ref y, 0, -2 * dy);
                SierpC(gr, depth, dx, dy, ref x, ref y);
                DrawRel(gr, ref x, ref y, -dx, -dy);
                SierpD(gr, depth, dx, dy, ref x, ref y);
            }

            if (m_Refresh) picCanvas.Refresh();
        }

        // Draw a line between (x, y) and (x + dx, y + dy).
        // Update x and y.
        private void DrawRel(Graphics gr, ref float x, ref float y, float dx, float dy)
        {
            gr.DrawLine(Pens.Black, x, y, x + dx, y + dy);
            x += dx;
            y += dy;
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
            this.picCanvas.TabIndex = 19;
            this.picCanvas.TabStop = false;
            // 
            // chkRefresh
            // 
            this.chkRefresh.Location = new System.Drawing.Point(12, 72);
            this.chkRefresh.Name = "chkRefresh";
            this.chkRefresh.Size = new System.Drawing.Size(64, 16);
            this.chkRefresh.TabIndex = 18;
            this.chkRefresh.Text = "Refresh";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(20, 40);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(40, 24);
            this.btnGo.TabIndex = 17;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(44, 8);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(32, 20);
            this.txtDepth.TabIndex = 16;
            this.txtDepth.Text = "4";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(4, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(36, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Depth";
            // 
            // howto_sierpinski_curve_Form1
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
            this.Name = "howto_sierpinski_curve_Form1";
            this.Text = "howto_sierpinski_curve";
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

