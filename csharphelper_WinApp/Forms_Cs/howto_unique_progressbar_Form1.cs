using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_unique_progressbar_Form1:Form
  { 


        public howto_unique_progressbar_Form1()
        {
            InitializeComponent();
        }

        // Groups of controls to use as progress bars.
        private Control[] Labels;
        private Control[] ColoredLabels;
        private Control[] SmallLabels;

        // The bitmap displayed for the colors PictureBox.
        private Bitmap ColorsBm;

        // The bitmap displayed for the picture.
        private Bitmap PictureBm;

        private void howto_unique_progressbar_Form1_Load(object sender, EventArgs e)
        {
            // Initialize the control arrays.
            Labels = new Control[] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10 };
            ColoredLabels = new Control[] { label11, label12, label13, label14, label15, label16, label17, label18, label19, label20 };
            SmallLabels = new Control[] { label21, label22, label23, label24, label25, label26, label27, label28, label29, label30, label31, label32, label33, label34, label35, label36, label37, label38, label39, label40 };

            // Set ColoredLabels colors.
            for (int i = 0; i < ColoredLabels.Length; i++)
            {
                int g = (int)(255f * i / (ColoredLabels.Length - 1f));
                ColoredLabels[i].BackColor = Color.FromArgb(255, 255, g, 0);
            }

            // Hide the control arrays.
            HideControls(Labels);
            HideControls(ColoredLabels);
            HideControls(SmallLabels);

            // Make the color bitmap.
            ColorsBm = new Bitmap(picColors.ClientSize.Width, picColors.ClientSize.Height);
            picColors.Image = ColorsBm;
            picColors.Visible = false;

            // Make the picture bitmap.
            PictureBm = new Bitmap(picHidden.Image.Width, picHidden.Image.Height);
            picVisible.Image = PictureBm;
        }

        // Start or stop the timer.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Disable the button and enable the timers.
            btnGo.Enabled = false;
            tmrFinish.Enabled = true;
            tmrLabels.Enabled = true;
            tmrColoredLabels.Enabled = true;
            tmrSmallLabels.Enabled = true;
            tmrColorBar.Enabled = true;
            tmrPicture.Enabled = true;

            // Clear the colorbar.
            using (Graphics gr = Graphics.FromImage(ColorsBm))
            {
                gr.Clear(picColors.BackColor);
            }
            picColors.Visible = true;

            // Display a pale picture.
            using (Graphics gr = Graphics.FromImage(PictureBm))
            {
                Rectangle rect = new Rectangle(0, 0, PictureBm.Width, PictureBm.Height);
                using (TextureBrush br = new TextureBrush(picHidden.Image))
                {
                    gr.FillRectangle(br, rect);
                }
                using (SolidBrush br = new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                {
                    gr.FillRectangle(br, rect);
                }
            }
            picVisible.Visible = true;
            
            this.Cursor = Cursors.WaitCursor;
        }

        // Show progress by displaying some hidden controls.
        private void ShowProgressWithVisible(float value, float max_value, Control[] controls)
        {
            // Calculate the index of the last visible control.
            int last_visible = (int)(controls.Length * value / max_value);

            // Make sure all controls up to this one are visible.
            for (int i = 0; i <= last_visible; i++)
            {
                if (!controls[i].Visible) controls[i].Visible = true;
            }
        }

        // Hide the progress controls.
        private void HideControls(Control[] controls)
        {
            foreach (Control ctl in controls) ctl.Visible = false;
        }

        // Display progress using labels.
        private int ProgressLabels = -1;
        private void tmrLabels_Tick(object sender, EventArgs e)
        {
            // Increment progress and see if we're done.
            if (++ProgressLabels >= Labels.Length)
            {
                // We're done. Stop the timer.
                ProgressLabels = -1;
                tmrLabels.Enabled = false;
                return;
            }

            // Display the progress.
            ShowProgressWithVisible(ProgressLabels, Labels.Length, Labels);
        }

        // Display progress using colored labels.
        private int ProgressColored = -1;
        private void tmrColoredLabels_Tick(object sender, EventArgs e)
        {
            // Increment progress and see if we're done.
            if (++ProgressColored >= ColoredLabels.Length)
            {
                // We're done. Stop the timer.
                ProgressColored = -1;
                tmrColoredLabels.Enabled = false;
                return;
            }

            // Display the progress.
            ShowProgressWithVisible(ProgressColored, ColoredLabels.Length, ColoredLabels);
        }

        // Display the next small label progress indicator.
        private int ProgressSmall = -1;
        private void tmrSmallLabels_Tick(object sender, EventArgs e)
        {
            // Increment progress and see if we're done.
            if (++ProgressSmall >= SmallLabels.Length)
            {
                // We're done. Stop the timer.
                ProgressSmall = -1;
                tmrSmallLabels.Enabled = false;
                return;
            }

            // Display the next progress control.
            SmallLabels[ProgressSmall].Visible = true;
        }

        // Display progress with a colored bar.
        private int ProgressColorBar = -1;
        private void tmrColorBar_Tick(object sender, EventArgs e)
        {
            const int max_progress = 20;

            // Increment progress and see if we're done.
            if (++ProgressColorBar >= max_progress)
            {
                // We're done. Stop the timer.
                ProgressColorBar = -1;
                tmrColorBar.Enabled = false;
                return;
            }

            // Display the next chunk of colors.
            using (LinearGradientBrush br = new LinearGradientBrush(
                new Point(0, 0), new Point(ColorsBm.Width, 0), Color.Red, Color.Yellow))
            {
                using (Graphics gr = Graphics.FromImage(ColorsBm))
                {
                    float wid = ColorsBm.Width * ProgressColorBar / (max_progress - 1);
                    float hgt = ColorsBm.Height;
                    RectangleF rect = new RectangleF(0, 0, wid, hgt);
                    gr.FillRectangle(br, rect);
                }
            }
            picColors.Refresh();
        }

        // Display progress with a picture.
        private int ProgressPicture = -1;
        private void tmrPicture_Tick(object sender, EventArgs e)
        {
            const int max_progress = 20;

            // Increment progress and see if we're done.
            if (++ProgressPicture >= max_progress)
            {
                // We're done. Stop the timer.
                ProgressPicture = -1;
                tmrPicture.Enabled = false;
                return;
            }

            // Display the next chunk of picture.
            using (TextureBrush br = new TextureBrush(picHidden.Image))
            {
                using (Graphics gr = Graphics.FromImage(PictureBm))
                {
                    float wid = PictureBm.Width * ProgressPicture / (max_progress - 1);
                    float hgt = PictureBm.Height;
                    RectangleF rect = new RectangleF(0, 0, wid, hgt);
                    gr.FillRectangle(br, rect);
                }
            }
            picVisible.Refresh();
        }

        // Hide all of the progress bars.
        private void tmrFinish_Tick(object sender, EventArgs e)
        {
            tmrFinish.Enabled = false;

            HideControls(Labels);
            HideControls(ColoredLabels);
            HideControls(SmallLabels);
            picColors.Visible = false;
            picVisible.Visible = false;

            btnGo.Enabled = true;
            this.Cursor = Cursors.Default;
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.picVisible = new System.Windows.Forms.PictureBox();
            this.picHidden = new System.Windows.Forms.PictureBox();
            this.picColors = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.tmrSmallLabels = new System.Windows.Forms.Timer(this.components);
            this.tmrLabels = new System.Windows.Forms.Timer(this.components);
            this.tmrColoredLabels = new System.Windows.Forms.Timer(this.components);
            this.tmrColorBar = new System.Windows.Forms.Timer(this.components);
            this.tmrPicture = new System.Windows.Forms.Timer(this.components);
            this.tmrFinish = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picVisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHidden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColors)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(118, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(28, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(54, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(80, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(106, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(132, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(158, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(184, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(210, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(236, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 20);
            this.label9.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(262, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 20);
            this.label10.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(28, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 20);
            this.label11.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(54, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 20);
            this.label12.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(80, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 20);
            this.label13.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(106, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 20);
            this.label14.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(132, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 20);
            this.label15.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(158, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 20);
            this.label16.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Location = new System.Drawing.Point(184, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 20);
            this.label17.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Location = new System.Drawing.Point(210, 92);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 20);
            this.label18.TabIndex = 13;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Location = new System.Drawing.Point(236, 92);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 20);
            this.label19.TabIndex = 12;
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Location = new System.Drawing.Point(262, 92);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 20);
            this.label20.TabIndex = 11;
            // 
            // picVisible
            // 
            this.picVisible.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picVisible.Location = new System.Drawing.Point(28, 221);
            this.picVisible.Name = "picVisible";
            this.picVisible.Size = new System.Drawing.Size(253, 87);
            this.picVisible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picVisible.TabIndex = 21;
            this.picVisible.TabStop = false;
            this.picVisible.Visible = false;
            // 
            // picHidden
            // 
            this.picHidden.Image = Properties.Resources.Flowers;
            this.picHidden.Location = new System.Drawing.Point(194, -52);
            this.picHidden.Name = "picHidden";
            this.picHidden.Size = new System.Drawing.Size(253, 87);
            this.picHidden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHidden.TabIndex = 22;
            this.picHidden.TabStop = false;
            this.picHidden.Visible = false;
            // 
            // picColors
            // 
            this.picColors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picColors.Location = new System.Drawing.Point(28, 177);
            this.picColors.Name = "picColors";
            this.picColors.Size = new System.Drawing.Size(253, 24);
            this.picColors.TabIndex = 23;
            this.picColors.TabStop = false;
            this.picColors.Visible = false;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Gray;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label21.Location = new System.Drawing.Point(28, 133);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(6, 6);
            this.label21.TabIndex = 43;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Gray;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label22.Location = new System.Drawing.Point(41, 144);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(6, 6);
            this.label22.TabIndex = 42;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Gray;
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label23.Location = new System.Drawing.Point(54, 135);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(6, 6);
            this.label23.TabIndex = 41;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Gray;
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label24.Location = new System.Drawing.Point(67, 144);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(6, 6);
            this.label24.TabIndex = 40;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Gray;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.Location = new System.Drawing.Point(80, 152);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(6, 6);
            this.label25.TabIndex = 39;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Gray;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label26.Location = new System.Drawing.Point(93, 133);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(6, 6);
            this.label26.TabIndex = 38;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Gray;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label27.Location = new System.Drawing.Point(106, 144);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(6, 6);
            this.label27.TabIndex = 37;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Gray;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label28.Location = new System.Drawing.Point(119, 140);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(6, 6);
            this.label28.TabIndex = 36;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Gray;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label29.Location = new System.Drawing.Point(132, 144);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(6, 6);
            this.label29.TabIndex = 35;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Gray;
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label30.Location = new System.Drawing.Point(145, 155);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(6, 6);
            this.label30.TabIndex = 34;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Gray;
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label31.Location = new System.Drawing.Point(158, 139);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(6, 6);
            this.label31.TabIndex = 33;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Gray;
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label32.Location = new System.Drawing.Point(171, 146);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(6, 6);
            this.label32.TabIndex = 32;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Gray;
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label33.Location = new System.Drawing.Point(184, 133);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(6, 6);
            this.label33.TabIndex = 31;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.Gray;
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label34.Location = new System.Drawing.Point(197, 133);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(6, 6);
            this.label34.TabIndex = 30;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Gray;
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label35.Location = new System.Drawing.Point(210, 144);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(6, 6);
            this.label35.TabIndex = 29;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.Gray;
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label36.Location = new System.Drawing.Point(223, 144);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(6, 6);
            this.label36.TabIndex = 28;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Gray;
            this.label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label37.Location = new System.Drawing.Point(236, 156);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(6, 6);
            this.label37.TabIndex = 27;
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.Gray;
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label38.Location = new System.Drawing.Point(249, 138);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(6, 6);
            this.label38.TabIndex = 26;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.Gray;
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label39.Location = new System.Drawing.Point(262, 144);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(6, 6);
            this.label39.TabIndex = 25;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.Gray;
            this.label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label40.Location = new System.Drawing.Point(275, 140);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(6, 6);
            this.label40.TabIndex = 24;
            // 
            // tmrSmallLabels
            // 
            this.tmrSmallLabels.Interval = 150;
            this.tmrSmallLabels.Tick += new System.EventHandler(this.tmrSmallLabels_Tick);
            // 
            // tmrLabels
            // 
            this.tmrLabels.Interval = 300;
            this.tmrLabels.Tick += new System.EventHandler(this.tmrLabels_Tick);
            // 
            // tmrColoredLabels
            // 
            this.tmrColoredLabels.Interval = 300;
            this.tmrColoredLabels.Tick += new System.EventHandler(this.tmrColoredLabels_Tick);
            // 
            // tmrColorBar
            // 
            this.tmrColorBar.Interval = 150;
            this.tmrColorBar.Tick += new System.EventHandler(this.tmrColorBar_Tick);
            // 
            // tmrPicture
            // 
            this.tmrPicture.Interval = 150;
            this.tmrPicture.Tick += new System.EventHandler(this.tmrPicture_Tick);
            // 
            // tmrFinish
            // 
            this.tmrFinish.Interval = 3500;
            this.tmrFinish.Tick += new System.EventHandler(this.tmrFinish_Tick);
            // 
            // howto_unique_progressbar_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 320);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.picColors);
            this.Controls.Add(this.picHidden);
            this.Controls.Add(this.picVisible);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Name = "howto_unique_progressbar_Form1";
            this.Text = "howto_unique_progressbar";
            this.Load += new System.EventHandler(this.howto_unique_progressbar_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picVisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHidden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox picVisible;
        private System.Windows.Forms.PictureBox picHidden;
        private System.Windows.Forms.PictureBox picColors;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Timer tmrSmallLabels;
        private System.Windows.Forms.Timer tmrLabels;
        private System.Windows.Forms.Timer tmrColoredLabels;
        private System.Windows.Forms.Timer tmrColorBar;
        private System.Windows.Forms.Timer tmrPicture;
        private System.Windows.Forms.Timer tmrFinish;
    }
}

