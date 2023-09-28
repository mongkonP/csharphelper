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
     public partial class howto_wandering_labels_Form1:Form
  { 


        public howto_wandering_labels_Form1()
        {
            InitializeComponent();
        }

        // The Label controls we will animate and their properties.
        private List<Label> AnimateLabels = new List<Label>();
        private List<int> AnimateStartXs = new List<int>();
        private List<int> AnimateStartYs = new List<int>();
        private List<float> AnimateDxs = new List<float>();
        private List<float> AnimateDys = new List<float>();
        private List<float> AnimateXs = new List<float>();
        private List<float> AnimateYs = new List<float>();
        private List<int> AnimateTotalTicks = new List<int>();
        private List<int> AnimateTicksToGo = new List<int>();

        // Make lists of the controls to move.
        private void howto_wandering_labels_Form1_Load(object sender, EventArgs e)
        {
            // Move down 20 pixels in 1 second.
            StoreAnimationInfo(lblTitle1, 0, 20, 500);

            // Move right 40 pixels in 2 seconds.
            StoreAnimationInfo(lblTitle2, 40, 0, 1000);

            // Move left 40 pixels in 2 seconds.
            StoreAnimationInfo(lblTitle3, -40, 0, 1000);

            // Move up 20 pixels in 1 second.
            StoreAnimationInfo(lblTitle4, 0, -20, 500);
        }

        // Store information to move a label.
        private void StoreAnimationInfo(Label lbl, float dx, float dy, float milliseconds)
        {
            // Calculate the number of times the Timer will tick.
            int ticks = (int)(milliseconds / tmrMoveLabels.Interval);

            // Add the values.
            AnimateLabels.Add(lbl);
            AnimateStartXs.Add((int)(lbl.Location.X - dx));
            AnimateStartYs.Add((int)(lbl.Location.Y - dy));
            AnimateDxs.Add(dx / ticks);
            AnimateDys.Add(dy / ticks);
            AnimateTotalTicks.Add(ticks);
        }

        // Move the labels to the start positions and start animating them.
        private void btnAnimate_Click(object sender, EventArgs e)
        {
            btnAnimate.Enabled = false;
            AnimateTicksToGo = new List<int>();
            AnimateXs = new List<float>();
            AnimateYs = new List<float>();

            for (int i = 0; i < AnimateLabels.Count; i++)
            {
                AnimateXs.Add(AnimateStartXs[i]);
                AnimateYs.Add(AnimateStartYs[i]);
                AnimateLabels[i].Location =
                    new Point((int)AnimateXs[i], (int)AnimateYs[i]);
                AnimateLabels[i].Visible = true;
                AnimateTicksToGo.Add(AnimateTotalTicks[i]);
            }

            tmrMoveLabels.Enabled = true;
        }

        // Move the labels.
        private void tmrMoveLabels_Tick(object sender, EventArgs e)
        {
            bool done_moving = true;
            DateTime now = DateTime.Now;
            for (int i = 0; i < AnimateLabels.Count; i++)
            {
                if (AnimateTicksToGo[i]-- > 0)
                {
                    done_moving = false;
                    AnimateXs[i] += AnimateDxs[i];
                    AnimateYs[i] += AnimateDys[i];
                    AnimateLabels[i].Location =
                        new Point((int)AnimateXs[i], (int)AnimateYs[i]);
                }
            }

            // If all labels are done moving, disable the Timer.
            if (done_moving)
            {
                tmrMoveLabels.Enabled = false;
                tmrHideLabels.Enabled = true;
            }
        }

        // Hide the controls.
        private void tmrHideLabels_Tick(object sender, EventArgs e)
        {
            foreach (Label lbl in AnimateLabels) lbl.Visible = false;
            tmrHideLabels.Enabled = false;
            btnAnimate.Enabled = true;
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
            this.btnAnimate = new System.Windows.Forms.Button();
            this.tmrMoveLabels = new System.Windows.Forms.Timer(this.components);
            this.lblTitle4 = new System.Windows.Forms.Label();
            this.tmrHideLabels = new System.Windows.Forms.Timer(this.components);
            this.lblTitle3 = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAnimate
            // 
            this.btnAnimate.Location = new System.Drawing.Point(191, 20);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(75, 23);
            this.btnAnimate.TabIndex = 9;
            this.btnAnimate.Text = "Animate";
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            // 
            // tmrMoveLabels
            // 
            this.tmrMoveLabels.Interval = 10;
            this.tmrMoveLabels.Tick += new System.EventHandler(this.tmrMoveLabels_Tick);
            // 
            // lblTitle4
            // 
            this.lblTitle4.AutoSize = true;
            this.lblTitle4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle4.Location = new System.Drawing.Point(21, 99);
            this.lblTitle4.Name = "lblTitle4";
            this.lblTitle4.Size = new System.Drawing.Size(108, 16);
            this.lblTitle4.TabIndex = 8;
            this.lblTitle4.Text = "24-Hour Trainer";
            this.lblTitle4.Visible = false;
            // 
            // tmrHideLabels
            // 
            this.tmrHideLabels.Interval = 1000;
            this.tmrHideLabels.Tick += new System.EventHandler(this.tmrHideLabels_Tick);
            // 
            // lblTitle3
            // 
            this.lblTitle3.AutoSize = true;
            this.lblTitle3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle3.ForeColor = System.Drawing.Color.Red;
            this.lblTitle3.Location = new System.Drawing.Point(21, 78);
            this.lblTitle3.Name = "lblTitle3";
            this.lblTitle3.Size = new System.Drawing.Size(186, 21);
            this.lblTitle3.TabIndex = 7;
            this.lblTitle3.Text = "with Visual Studio 2010";
            this.lblTitle3.Visible = false;
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle2.ForeColor = System.Drawing.Color.Red;
            this.lblTitle2.Location = new System.Drawing.Point(18, 47);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(197, 31);
            this.lblTitle2.TabIndex = 6;
            this.lblTitle2.Text = "C# Programming";
            this.lblTitle2.Visible = false;
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.ForeColor = System.Drawing.Color.Red;
            this.lblTitle1.Location = new System.Drawing.Point(21, 31);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(60, 16);
            this.lblTitle1.TabIndex = 5;
            this.lblTitle1.Text = "Stephens\'";
            this.lblTitle1.Visible = false;
            // 
            // howto_wandering_labels_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 135);
            this.Controls.Add(this.btnAnimate);
            this.Controls.Add(this.lblTitle4);
            this.Controls.Add(this.lblTitle3);
            this.Controls.Add(this.lblTitle2);
            this.Controls.Add(this.lblTitle1);
            this.Name = "howto_wandering_labels_Form1";
            this.Text = "howto_wandering_labels";
            this.Load += new System.EventHandler(this.howto_wandering_labels_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnimate;
        private System.Windows.Forms.Timer tmrMoveLabels;
        private System.Windows.Forms.Label lblTitle4;
        private System.Windows.Forms.Timer tmrHideLabels;
        private System.Windows.Forms.Label lblTitle3;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblTitle1;
    }
}

