using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_animate_control;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_animate_control_Form1:Form
  { 


        public howto_animate_control_Form1()
        {
            InitializeComponent();
        }

        private ControlSprite ButtonSprite, LabelSprite;

        // Make the control sprites.
        private void howto_animate_control_Form1_Load(object sender, EventArgs e)
        {
            ButtonSprite = new ControlSprite(btnStart);
            ButtonSprite.Done += ButtonSprite_Done;
            LabelSprite = new ControlSprite(lblMessage);
        }

        // Start or stop.
        private void btnStart_Click(object sender, EventArgs e)
        {
            const int PixelsPerSecond = 200;

            if (btnStart.Text == "Start")
            {
                // Start button. Change the caption to Stop.
                btnStart.Text = "Stop";

                // See where we are.
                if (btnStart.Location.X == 12)
                {
                    // Move the button down and right.
                    ButtonSprite.Start(197, 229, PixelsPerSecond);
                    LabelSprite.Start(12, 232, PixelsPerSecond);
                }
                else if (btnStart.Location.X == 197)
                {
                    // Move the button up and left.
                    ButtonSprite.Start(12, 12, PixelsPerSecond);
                    LabelSprite.Start(186, 12, PixelsPerSecond);
                }
                else
                {
                    // Continue the button's previous move.
                    ButtonSprite.Start();
                    LabelSprite.Start();
                }
            }
            else
            {
                // Stop button. Change the caption to Start.
                btnStart.Text = "Start";

                // Stop moving.
                ButtonSprite.Stop();
                LabelSprite.Stop();
            }
        }

        // The button is done moving.
        public void ButtonSprite_Done(object sender)
        {
            btnStart.Text = "Start";
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
            this.btnStart = new System.Windows.Forms.Button();
            this.tmrMoveControls = new System.Windows.Forms.Timer(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessage.Location = new System.Drawing.Point(186, 12);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(86, 23);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "This is a label.";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_animate_control_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnStart);
            this.Name = "howto_animate_control_Form1";
            this.Text = "howto_animate_control";
            this.Load += new System.EventHandler(this.howto_animate_control_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer tmrMoveControls;
        private System.Windows.Forms.Label lblMessage;
    }
}

