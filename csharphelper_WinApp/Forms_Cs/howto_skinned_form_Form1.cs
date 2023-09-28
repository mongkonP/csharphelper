using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_skinned_form_Form1:Form
  { 


        public howto_skinned_form_Form1()
        {
            InitializeComponent();
        }

        // Prepare the form.
        private void howto_skinned_form_Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.Cyan;
            this.BackColor = Color.Cyan;

            // Start with the Safety skin.
            cboSkin.SelectedIndex = 0;

            this.Visible = true;
        }

        // Switch skins.
        private void cboSkin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dir = Application.StartupPath;
            int pos = dir.LastIndexOf(@"\");
            pos = dir.LastIndexOf(@"\", pos - 1);
            dir = dir.Substring(0, pos + 1);

            switch (cboSkin.SelectedIndex)
            {
                case 0:
                    LoadSkinFromDirectory(dir + "Safety");
                    lblTitle.Top = panTopContainer.Height - lblTitle.Height - 14;
                    lblTitle.ForeColor = Color.Yellow;
                    break;
                case 1:
                    LoadSkinFromDirectory(dir + "Rivets");
                    lblTitle.Top = panTopContainer.Height - lblTitle.Height - 4;
                    lblTitle.ForeColor = Color.White;
                    break;
                case 2:
                    LoadSkinFromDirectory(dir + "Pipes");
                    lblTitle.Top = panTopContainer.Height - lblTitle.Height - 8;
                    lblTitle.ForeColor = Color.White;
                    break;
            }
        }

        // Load skin images from the files in a directory.
        private void LoadSkinFromDirectory(string dir)
        {
            this.Visible = false;

            if (!dir.EndsWith("/")) dir += "/";
            picLeft.BackgroundImage = LoadImage(dir + "Left.png");
            picRight.BackgroundImage = LoadImage(dir + "Right.png");
            picBottom.BackgroundImage = LoadImage(dir + "Bottom.png");
            picLowerRight.Image = LoadImage(dir + "LowerRight.png");
            picLowerLeft.Image = LoadImage(dir + "LowerLeft.png");
            picUpperLeft.Image = LoadImage(dir + "UpperLeft.png");
            picUpperRight.Image = LoadImage(dir + "UpperRight.png");
            panTop.BackgroundImage = LoadImage(dir + "Top.png");
            panMiddle.BackgroundImage = LoadImage(dir + "Middle.png");

            if (picLeft.BackgroundImage != null) picLeft.Width = picLeft.BackgroundImage.Width;
            if (picRight.BackgroundImage != null) picRight.Width = picRight.BackgroundImage.Width;

            CloseButtonUp = LoadImage(dir + "CloseUp.png");
            CloseButtonDown = LoadImage(dir + "CloseDown.png");

            if (picBottom.BackgroundImage != null) panBottomContainer.Height = picBottom.BackgroundImage.Height;
            if (picUpperLeft.Image != null) panTopContainer.Height = picUpperLeft.Image.Height;

            picClose.Image = CloseButtonUp;
            picClose.Left = (picUpperLeft.Width - picClose.Width) / 2;
            picClose.Top = (picUpperLeft.Height - picClose.Height) / 2;

            lblTitle.Top = panTopContainer.Height - lblTitle.Height - 2;

            this.Visible = true;
        }

        // Load a skin image with error handling.
        private Bitmap LoadImage(string file)
        {
            try { return new Bitmap(file); }
            catch { return null; }
        }

        // Only close if the user clicked the Close button.
        private bool CloseOk = false;
        private void howto_skinned_form_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CloseOk;
        }

        // Close the form.
        private void picClose_Click(object sender, EventArgs e)
        {
            CloseOk = true;
            Close();
        }

        // On mouse down, start moving the form.
        private void panTop_MouseDown(object sender, MouseEventArgs e)
        {
            ProcessMouseDownMessage(panTop, HT_CAPTION);
        }

        // On mouse down, start moving the form.
        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ProcessMouseDownMessage(lblTitle, HT_CAPTION);
        }

        // Resize with various controls.
        private void picLowerRight_MouseDown(object sender, MouseEventArgs e)
        {
            ProcessMouseDownMessage(sender as Control, HT_BOTTOMRIGHT);
        }
        private void picLowerLeft_MouseDown(object sender, MouseEventArgs e)
        {
            ProcessMouseDownMessage(sender as Control, HT_BOTTOMLEFT);
        }
        private void picUpperLeft_MouseDown(object sender, MouseEventArgs e)
        {
            ProcessMouseDownMessage(sender as Control, HT_TOPLEFT);
        }
        private void picUpperRight_MouseDown(object sender, MouseEventArgs e)
        {
            ProcessMouseDownMessage(sender as Control, HT_TOPRIGHT);
        }
        private void picRight_MouseDown(object sender, MouseEventArgs e)
        {
            ProcessMouseDownMessage(sender as Control, HT_RIGHT);
        }
        private void picBottom_MouseDown(object sender, MouseEventArgs e)
        {
            ProcessMouseDownMessage(sender as Control, HT_BOTTOM);
        }
        private void picLeft_MouseDown(object sender, MouseEventArgs e)
        {
            ProcessMouseDownMessage(sender as Control, HT_LEFT);
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 2;
        private const int HT_BOTTOM = 15;
        private const int HT_BOTTOMLEFT = 16;
        private const int HT_BOTTOMRIGHT = 17;
        private const int HT_LEFT = 10;
        private const int HT_RIGHT = 11;
        private const int HT_TOP = 12;
        private const int HT_TOPLEFT = 13;
        private const int HT_TOPRIGHT = 14;

        // Let the user move the form.
        private void ProcessMouseDownMessage(Control ctl, int wParam)
        {
            ctl.Capture = false;

            Message msg = Message.Create(this.Handle,
                WM_NCLBUTTONDOWN, (IntPtr)wParam, IntPtr.Zero);
            WndProc(ref msg);
        }

        // The Close button's images.
        private Image CloseButtonDown, CloseButtonUp;

        // Make the close button act like a button.
        private bool CloseButtonIsDown = false;
        private void picClose_MouseDown(object sender, MouseEventArgs e)
        {
            CloseButtonIsDown = true;
            picClose.Image = CloseButtonDown;
        }
        private void picClose_MouseUp(object sender, MouseEventArgs e)
        {
            picClose.Image = CloseButtonUp;
            CloseButtonIsDown = false;
        }
        private void picClose_MouseMove(object sender, MouseEventArgs e)
        {
            if (CloseButtonIsDown)
            {
                Rectangle rect = new Rectangle(0, 0, picClose.Width, picClose.Height);
                if (rect.Contains(e.Location))
                {
                    picClose.Image = CloseButtonDown;
                }
                else
                {
                    picClose.Image = CloseButtonUp;
                }
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
            this.panTopContainer = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picUpperRight = new System.Windows.Forms.PictureBox();
            this.picUpperLeft = new System.Windows.Forms.PictureBox();
            this.panBottomContainer = new System.Windows.Forms.Panel();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.picLowerRight = new System.Windows.Forms.PictureBox();
            this.picLowerLeft = new System.Windows.Forms.PictureBox();
            this.panMiddle = new System.Windows.Forms.Panel();
            this.cboSkin = new System.Windows.Forms.ComboBox();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.panTopContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUpperRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUpperLeft)).BeginInit();
            this.panBottomContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLowerRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLowerLeft)).BeginInit();
            this.panMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // panTopContainer
            // 
            this.panTopContainer.Controls.Add(this.picClose);
            this.panTopContainer.Controls.Add(this.panTop);
            this.panTopContainer.Controls.Add(this.picUpperRight);
            this.panTopContainer.Controls.Add(this.picUpperLeft);
            this.panTopContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTopContainer.Location = new System.Drawing.Point(0, 0);
            this.panTopContainer.Name = "panTopContainer";
            this.panTopContainer.Size = new System.Drawing.Size(284, 51);
            this.panTopContainer.TabIndex = 0;
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.No;
            this.picClose.Image = Properties.Resources.CloseUp;
            this.picClose.Location = new System.Drawing.Point(15, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(16, 16);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picClose.TabIndex = 14;
            this.picClose.TabStop = false;
            this.picClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picClose_MouseMove);
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picClose_MouseDown);
            this.picClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picClose_MouseUp);
            // 
            // panTop
            // 
            this.panTop.BackgroundImage = Properties.Resources.Top;
            this.panTop.Controls.Add(this.lblTitle);
            this.panTop.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTop.Location = new System.Drawing.Point(50, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(204, 51);
            this.panTop.TabIndex = 13;
            this.panTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panTop_MouseDown);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Yellow;
            this.lblTitle.Location = new System.Drawing.Point(0, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(123, 13);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "howto_skinned_form";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // picUpperRight
            // 
            this.picUpperRight.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.picUpperRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.picUpperRight.Image = Properties.Resources.UpperRight;
            this.picUpperRight.Location = new System.Drawing.Point(254, 0);
            this.picUpperRight.Name = "picUpperRight";
            this.picUpperRight.Size = new System.Drawing.Size(30, 51);
            this.picUpperRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picUpperRight.TabIndex = 10;
            this.picUpperRight.TabStop = false;
            this.picUpperRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picUpperRight_MouseDown);
            // 
            // picUpperLeft
            // 
            this.picUpperLeft.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.picUpperLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picUpperLeft.Image = Properties.Resources.UpperLeft;
            this.picUpperLeft.Location = new System.Drawing.Point(0, 0);
            this.picUpperLeft.Name = "picUpperLeft";
            this.picUpperLeft.Size = new System.Drawing.Size(50, 51);
            this.picUpperLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picUpperLeft.TabIndex = 9;
            this.picUpperLeft.TabStop = false;
            this.picUpperLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picUpperLeft_MouseDown);
            // 
            // panBottomContainer
            // 
            this.panBottomContainer.Controls.Add(this.picBottom);
            this.panBottomContainer.Controls.Add(this.picLowerRight);
            this.panBottomContainer.Controls.Add(this.picLowerLeft);
            this.panBottomContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottomContainer.Location = new System.Drawing.Point(0, 228);
            this.panBottomContainer.Name = "panBottomContainer";
            this.panBottomContainer.Size = new System.Drawing.Size(284, 36);
            this.panBottomContainer.TabIndex = 6;
            // 
            // picBottom
            // 
            this.picBottom.BackgroundImage = Properties.Resources.Bottom;
            this.picBottom.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.picBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBottom.Location = new System.Drawing.Point(30, 0);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(224, 36);
            this.picBottom.TabIndex = 13;
            this.picBottom.TabStop = false;
            this.picBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBottom_MouseDown);
            // 
            // picLowerRight
            // 
            this.picLowerRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.picLowerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.picLowerRight.Image = Properties.Resources.LowerRight;
            this.picLowerRight.Location = new System.Drawing.Point(254, 0);
            this.picLowerRight.Name = "picLowerRight";
            this.picLowerRight.Size = new System.Drawing.Size(30, 36);
            this.picLowerRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLowerRight.TabIndex = 12;
            this.picLowerRight.TabStop = false;
            this.picLowerRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLowerRight_MouseDown);
            // 
            // picLowerLeft
            // 
            this.picLowerLeft.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.picLowerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLowerLeft.Image = Properties.Resources.LowerLeft;
            this.picLowerLeft.Location = new System.Drawing.Point(0, 0);
            this.picLowerLeft.Name = "picLowerLeft";
            this.picLowerLeft.Size = new System.Drawing.Size(30, 36);
            this.picLowerLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLowerLeft.TabIndex = 11;
            this.picLowerLeft.TabStop = false;
            this.picLowerLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLowerLeft_MouseDown);
            // 
            // panMiddle
            // 
            this.panMiddle.BackColor = System.Drawing.SystemColors.Control;
            this.panMiddle.Controls.Add(this.cboSkin);
            this.panMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMiddle.Location = new System.Drawing.Point(34, 51);
            this.panMiddle.Name = "panMiddle";
            this.panMiddle.Size = new System.Drawing.Size(216, 177);
            this.panMiddle.TabIndex = 9;
            // 
            // cboSkin
            // 
            this.cboSkin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSkin.FormattingEnabled = true;
            this.cboSkin.Items.AddRange(new object[] {
            "Safety",
            "Rivets",
            "Pipes"});
            this.cboSkin.Location = new System.Drawing.Point(6, 6);
            this.cboSkin.Name = "cboSkin";
            this.cboSkin.Size = new System.Drawing.Size(92, 21);
            this.cboSkin.TabIndex = 11;
            this.cboSkin.SelectedIndexChanged += new System.EventHandler(this.cboSkin_SelectedIndexChanged);
            // 
            // picRight
            // 
            this.picRight.BackgroundImage = Properties.Resources.Right;
            this.picRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.picRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.picRight.Location = new System.Drawing.Point(250, 51);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(34, 177);
            this.picRight.TabIndex = 8;
            this.picRight.TabStop = false;
            this.picRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picRight_MouseDown);
            // 
            // picLeft
            // 
            this.picLeft.BackgroundImage = Properties.Resources.Left;
            this.picLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.picLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLeft.Location = new System.Drawing.Point(0, 51);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(34, 177);
            this.picLeft.TabIndex = 7;
            this.picLeft.TabStop = false;
            this.picLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLeft_MouseDown);
            // 
            // howto_skinned_form_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.panMiddle);
            this.Controls.Add(this.picRight);
            this.Controls.Add(this.picLeft);
            this.Controls.Add(this.panBottomContainer);
            this.Controls.Add(this.panTopContainer);
            this.Name = "howto_skinned_form_Form1";
            this.Text = "howto_skinned_form";
            this.Load += new System.EventHandler(this.howto_skinned_form_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_skinned_form_Form1_FormClosing);
            this.panTopContainer.ResumeLayout(false);
            this.panTopContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUpperRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUpperLeft)).EndInit();
            this.panBottomContainer.ResumeLayout(false);
            this.panBottomContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLowerRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLowerLeft)).EndInit();
            this.panMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTopContainer;
        private System.Windows.Forms.PictureBox picUpperRight;
        private System.Windows.Forms.PictureBox picUpperLeft;
        private System.Windows.Forms.Panel panBottomContainer;
        private System.Windows.Forms.PictureBox picLowerRight;
        private System.Windows.Forms.PictureBox picLowerLeft;
        private System.Windows.Forms.PictureBox picRight;
        private System.Windows.Forms.PictureBox picBottom;
        private System.Windows.Forms.PictureBox picLeft;
        private System.Windows.Forms.Panel panTop;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panMiddle;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.ComboBox cboSkin;
    }
}

