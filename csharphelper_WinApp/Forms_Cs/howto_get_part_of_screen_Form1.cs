using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_part_of_screen_Form1:Form
  { 


        public howto_get_part_of_screen_Form1()
        {
            InitializeComponent();
        }

        // The image of the whole screen.
        private Bitmap ScreenBm, VisibleBm;

        // The area we are selecting.
        private int X0, Y0, X1, Y1;

        // Minimize.
        private void howto_get_part_of_screen_Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.Visible = false;
            this.Cursor = Cursors.Cross;
        }

        // Close the program.
        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Capture the whole screen.
        private void mnuWholeScreen_Click(object sender, EventArgs e)
        {
            // Get the whole screen's image.
            using (Bitmap bm = GetScreenImage())
            {
                // Save it.
                SavePicture(bm);
            }
        }

        // Let the user select a part of the screen.
        private void mnuCaptureArea_Click(object sender, EventArgs e)
        {
            // Get the whole screen's image.
            ScreenBm = GetScreenImage();

            // Display a copy.
            VisibleBm = (Bitmap)ScreenBm.Clone();

            // Display it.
            this.BackgroundImage = VisibleBm;
            this.Location = new Point(0, 0);
            this.ClientSize = VisibleBm.Size;
            this.MouseDown += howto_get_part_of_screen_Form1_MouseDown;
            this.Show();
        }

        // Start selecting an area.
        private void howto_get_part_of_screen_Form1_MouseDown(object sender, MouseEventArgs e)
        {
            X0 = e.X;
            Y0 = e.Y;
            X1 = e.X;
            Y1 = e.Y;

            this.MouseDown -= howto_get_part_of_screen_Form1_MouseDown;
            this.MouseMove += howto_get_part_of_screen_Form1_MouseMove;
            this.MouseUp += howto_get_part_of_screen_Form1_MouseUp;
        }

        // Continue selecting an area.
        private void howto_get_part_of_screen_Form1_MouseMove(object sender, MouseEventArgs e)
        {
            X1 = e.X;
            Y1 = e.Y;

            using (Graphics gr = Graphics.FromImage(VisibleBm))
            {
                // Copy the original image.
                gr.DrawImage(ScreenBm, 0, 0);

                // Draw the selected area.
                Rectangle rect = new Rectangle(
                    Math.Min(X0, X1),
                    Math.Min(Y0, Y1),
                    Math.Abs(X1 - X0),
                    Math.Abs(Y1 - Y0));
                gr.DrawRectangle(Pens.Yellow, rect);
            }
            this.Refresh();
        }

        // Finish selecting an area.
        private void howto_get_part_of_screen_Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Visible = false;
            this.MouseMove -= howto_get_part_of_screen_Form1_MouseMove;
            this.MouseUp -= howto_get_part_of_screen_Form1_MouseUp;

            // Save the selected part of the image.
            int wid = Math.Abs(X1 - X0);
            int hgt = Math.Abs(Y1 - Y0);
            Rectangle dest_rect = new Rectangle(0, 0, wid, hgt);
            Rectangle source_rect = new Rectangle(
                Math.Min(X0, X1),
                Math.Min(Y0, Y1),
                Math.Abs(X1 - X0),
                Math.Abs(Y1 - Y0));
            using (Bitmap selection = new Bitmap(wid, hgt))
            {
                // Copy the selected area.
                using (Graphics gr = Graphics.FromImage(selection))
                {
                    gr.DrawImage(ScreenBm, dest_rect, source_rect, GraphicsUnit.Pixel);
                }

                // Save the selected area.
                SavePicture(selection);
            }

            // Dispose of the other bitmaps.
            this.BackgroundImage = null;
            ScreenBm.Dispose();
            VisibleBm.Dispose();
            ScreenBm = null;
            VisibleBm = null;
        }

        // Grab the screen's image.
        private Bitmap GetScreenImage()
        {
            // Make a bitmap to hold the result.
            Bitmap bm = new Bitmap(
                Screen.PrimaryScreen.Bounds.Width, 
                Screen.PrimaryScreen.Bounds.Height, 
                PixelFormat.Format24bppRgb);

            // Copy the image into the bitmap.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.CopyFromScreen(
                    Screen.PrimaryScreen.Bounds.X,
                    Screen.PrimaryScreen.Bounds.Y,
                    0, 0,
                    Screen.PrimaryScreen.Bounds.Size,
                    CopyPixelOperation.SourceCopy);
            }

            // Return the result.
            return bm;
        }

        // Save the picture in a file selected by the user.
        private void SavePicture(Bitmap bm)
        {
            // Let the user pick a file to hold the image.
            if (sfdScreenImage.ShowDialog() == DialogResult.OK)
            {
                // Save the bitmap in the selected file.
                string filename = sfdScreenImage.FileName;
                FileInfo file_info = new FileInfo(filename);
                switch (file_info.Extension.ToLower())
                {
                    case ".bmp":
                        bm.Save(filename, ImageFormat.Bmp);
                        break;
                    case ".gif":
                        bm.Save(filename, ImageFormat.Gif);
                        break;
                    case ".jpg":
                    case ".jpeg":
                        bm.Save(filename, ImageFormat.Jpeg);
                        break;
                    case ".png":
                        bm.Save(filename, ImageFormat.Png);
                        break;
                    default:
                        MessageBox.Show("Unknown file type " +
                            file_info.Extension, "Unknown Extension",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_get_part_of_screen_Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxCommands = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuWholeScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCaptureArea = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdScreenImage = new System.Windows.Forms.SaveFileDialog();
            this.ctxCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.ctxCommands;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ScreenGrabber";
            this.notifyIcon1.Visible = true;
            // 
            // ctxCommands
            // 
            this.ctxCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWholeScreen,
            this.mnuCaptureArea,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.ctxCommands.Name = "ctxCommands";
            this.ctxCommands.Size = new System.Drawing.Size(176, 76);
            // 
            // mnuWholeScreen
            // 
            this.mnuWholeScreen.Name = "mnuWholeScreen";
            this.mnuWholeScreen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuWholeScreen.Size = new System.Drawing.Size(175, 22);
            this.mnuWholeScreen.Text = "Capture &All";
            this.mnuWholeScreen.Click += new System.EventHandler(this.mnuWholeScreen_Click);
            // 
            // mnuCaptureArea
            // 
            this.mnuCaptureArea.Name = "mnuCaptureArea";
            this.mnuCaptureArea.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuCaptureArea.Size = new System.Drawing.Size(175, 22);
            this.mnuCaptureArea.Text = "&Select Area";
            this.mnuCaptureArea.Click += new System.EventHandler(this.mnuCaptureArea_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(175, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // sfdScreenImage
            // 
            this.sfdScreenImage.Filter = "Graphic Files|*.bmp;*.gif;*.jpg;*.png|All Files|*.*";
            // 
            // howto_get_part_of_screen_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 145);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "howto_get_part_of_screen_Form1";
            this.Load += new System.EventHandler(this.howto_get_part_of_screen_Form1_Load);
            this.ctxCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip ctxCommands;
        private System.Windows.Forms.ToolStripMenuItem mnuWholeScreen;
        private System.Windows.Forms.ToolStripMenuItem mnuCaptureArea;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.SaveFileDialog sfdScreenImage;
    }
}

