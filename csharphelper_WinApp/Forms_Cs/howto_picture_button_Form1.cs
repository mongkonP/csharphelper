using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// At design time, set the PictureBox properties:
//      BackColor = Transparent
//      Image = the button up image

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_picture_button_Form1:Form
  { 


        public howto_picture_button_Form1()
        {
            InitializeComponent();
        }

        // Keep track of whether the button is pressed.
        private bool ClickMeButtonIsPressed = false;

        // Display the button down image.
        private void picClickMe_MouseDown(object sender, MouseEventArgs e)
        {
            // See if the mouse is over the masked area.
            if (MouseIsOverButton(e.Location))
            {
                ClickMeButtonIsPressed = true;
                picClickMe.Image = Properties.Resources.ButtonDown;
            }
        }

        // Display the button up image.
        private void picClickMe_MouseUp(object sender, MouseEventArgs e)
        {
            ClickMeButtonIsPressed = false;
            picClickMe.Image = Properties.Resources.ButtonUp;
        }

        // If the button is pressed, display the appropriate image.
        private void picClickMe_MouseMove(object sender, MouseEventArgs e)
        {
            // The picture the button should have.
            Image desired_picture = Properties.Resources.ButtonUp;

            // See if the mouse is over the button's masked area.
            if (MouseIsOverButton(e.Location))
            {
                // The mouse is over the masked area.
                // See if the mouse is pressed.
                if (ClickMeButtonIsPressed)
                    desired_picture = Properties.Resources.ButtonDown;
                else
                    desired_picture = Properties.Resources.ButtonMouseOver;
            }
            else
            {
                // The mouse is not over the masked area.
                // The button should be in the up position.
                desired_picture = Properties.Resources.ButtonUp;
            }

            // See if we need to change the button image.
            if (picClickMe.Image != desired_picture)
                picClickMe.Image = desired_picture;
        }

        // Return true if the mouse is over the button's masked area.
        private bool MouseIsOverButton(Point location)
        {
            // Make sure the location is over the image.
            if (location.X < 0) return false;
            if (location.Y < 0) return false;
            if (location.X >= Properties.Resources.ButtonMask.Width) return false;
            if (location.Y >= Properties.Resources.ButtonMask.Height) return false;

            // See if the mask pixel at this position is black.
            Color color =
                Properties.Resources.ButtonMask.GetPixel(
                    location.X, location.Y);
            return ((color.A == 255) &&
                    (color.R == 0) &&
                    (color.G == 0) &&
                    (color.B == 0));
        }

        // The button has been clicked.
        private void picClickMe_MouseClick(object sender, MouseEventArgs e)
        {
            // See if the mouse is over the masked area.
            if (MouseIsOverButton(e.Location))
            {
                MessageBox.Show("Clicked");
            }
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
            this.picClickMe = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClickMe)).BeginInit();
            this.SuspendLayout();
            // 
            // picClickMe
            // 
            this.picClickMe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picClickMe.BackColor = System.Drawing.Color.Transparent;
            this.picClickMe.Image = Properties.Resources.ButtonUp;
            this.picClickMe.Location = new System.Drawing.Point(75, 63);
            this.picClickMe.Name = "picClickMe";
            this.picClickMe.Size = new System.Drawing.Size(145, 85);
            this.picClickMe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picClickMe.TabIndex = 1;
            this.picClickMe.TabStop = false;
            this.picClickMe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picClickMe_MouseMove);
            this.picClickMe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picClickMe_MouseClick);
            this.picClickMe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picClickMe_MouseDown);
            this.picClickMe.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picClickMe_MouseUp);
            // 
            // howto_picture_button_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = Properties.Resources.Flowers;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(294, 211);
            this.Controls.Add(this.picClickMe);
            this.Name = "howto_picture_button_Form1";
            this.Text = "howto_picture_button";
            ((System.ComponentModel.ISupportInitialize)(this.picClickMe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picClickMe;
    }
}

