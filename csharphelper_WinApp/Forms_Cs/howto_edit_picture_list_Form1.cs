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
     public partial class howto_edit_picture_list_Form1:Form
  { 


        public howto_edit_picture_list_Form1()
        {
            InitializeComponent();
        }

        // The currently loaded pictures.
        private List<Bitmap> Pictures = new List<Bitmap>();
        private const int PictureMargin = 8;

        // The index of the picture we clicked or
        // the picture before which we clicked.
        private int ClickedIndex = -1;

        private void ArrangePanel()
        {
            panPictures.Controls.Clear();
            int x = PictureMargin;
            int y = PictureMargin;
            foreach (Bitmap picture in Pictures)
            {
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.AutoSize;
                pic.Location = new Point(x, y);
                pic.Image = picture;
                pic.Visible = true;
                pic.MouseDown += pic_MouseDown;
                panPictures.Controls.Add(pic);

                x += pic.Width + PictureMargin;
            }

            // Add one placeholder PictureBox.
            PictureBox placeholder = new PictureBox();
            placeholder.Location = new Point(x, y);
            placeholder.Size = new Size(0, 0);
            placeholder.Visible = true;
            placeholder.MouseDown += pic_MouseDown;
            panPictures.Controls.Add(placeholder);
        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            // Ignore left mouse clicks.
            if (e.Button != MouseButtons.Right) return;

            // Display the context menu.
            PictureBox pic = sender as PictureBox;
            ShowContextMenu(new Point(pic.Left + e.X, pic.Top + e.Y));
        }

        private void panPictures_MouseDown(object sender, MouseEventArgs e)
        {
            // Ignore left mouse clicks.
            if (e.Button != MouseButtons.Right) return;

            // Display the context menu.
            ShowContextMenu(e.Location);
        }

        private void mnuMoveLeft_Click(object sender, EventArgs e)
        {
            Bitmap bm = Pictures[ClickedIndex];
            Pictures.RemoveAt(ClickedIndex);
            Pictures.Insert(ClickedIndex - 1, bm);
            ArrangePanel();
        }

        private void mnuMoveRight_Click(object sender, EventArgs e)
        {
            Bitmap bm = Pictures[ClickedIndex];
            Pictures.RemoveAt(ClickedIndex);
            Pictures.Insert(ClickedIndex + 1, bm);
            ArrangePanel();
        }

        private void mnuDeletePicture_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to delete this picture?",
                "Delete Picture?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Pictures.RemoveAt(ClickedIndex);
                ArrangePanel();
            }
        }

        // Let the user insert a picture.
        private void mnuInsertPicture_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdPicture.ShowDialog() == DialogResult.OK)
                {
                    int i = 0;
                    foreach (string filename in ofdPicture.FileNames)
                    {
                        Bitmap bm = new Bitmap(filename);
                        Pictures.Insert(ClickedIndex + i, bm);
                        i++;
                    }
                    ArrangePanel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Prepare the context menu and display it.
        private void ShowContextMenu(Point location)
        {
            // Assume we click after the final picture.
            bool clicked_on_picture = false;
            ClickedIndex = Pictures.Count;

            // See if we clicked on or before a picture.
            int x = location.X + panPictures.HorizontalScroll.Value;
            for (int i = 0; i < Pictures.Count; i++)
            {
                // See if we are before the next picture.
                x -= PictureMargin;
                if (x < 0)
                {
                    ClickedIndex = i;
                    break;
                }   

                // See if we are on this picture.
                x -= panPictures.Controls[i].Width;
                if (x < 0)
                {
                    ClickedIndex = i;
                    clicked_on_picture = true;
                    break;
                }
            }

            // Enable and disable contect menu items.
            mnuMoveLeft.Enabled =
                (clicked_on_picture && (ClickedIndex > 0));
            mnuMoveRight.Enabled =
                (clicked_on_picture && (ClickedIndex < Pictures.Count - 1));
            mnuDeletePicture.Enabled = clicked_on_picture;
            mnuInsertPicture.Enabled = !clicked_on_picture;

            // Display the context menu.
            ctxPictures.Show(panPictures, location);
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
            this.panPictures = new System.Windows.Forms.Panel();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.ctxPictures = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMoveLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveRight = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeletePicture = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsertPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxPictures.SuspendLayout();
            this.SuspendLayout();
            // 
            // panPictures
            // 
            this.panPictures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panPictures.AutoScroll = true;
            this.panPictures.BackColor = System.Drawing.Color.White;
            this.panPictures.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panPictures.ContextMenuStrip = this.ctxPictures;
            this.panPictures.Location = new System.Drawing.Point(12, 12);
            this.panPictures.Name = "panPictures";
            this.panPictures.Size = new System.Drawing.Size(260, 207);
            this.panPictures.TabIndex = 1;
            this.panPictures.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panPictures_MouseDown);
            // 
            // ofdPicture
            // 
            this.ofdPicture.DefaultExt = "png";
            this.ofdPicture.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All FIles|*.*";
            this.ofdPicture.Multiselect = true;
            // 
            // ctxPictures
            // 
            this.ctxPictures.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMoveLeft,
            this.mnuMoveRight,
            this.mnuDeletePicture,
            this.mnuInsertPicture});
            this.ctxPictures.Name = "ctxPictures";
            this.ctxPictures.Size = new System.Drawing.Size(157, 92);
            // 
            // mnuMoveLeft
            // 
            this.mnuMoveLeft.Name = "mnuMoveLeft";
            this.mnuMoveLeft.Size = new System.Drawing.Size(152, 22);
            this.mnuMoveLeft.Text = "Move &Left";
            this.mnuMoveLeft.Click += new System.EventHandler(this.mnuMoveLeft_Click);
            // 
            // mnuMoveRight
            // 
            this.mnuMoveRight.Name = "mnuMoveRight";
            this.mnuMoveRight.Size = new System.Drawing.Size(152, 22);
            this.mnuMoveRight.Text = "Move &Right";
            this.mnuMoveRight.Click += new System.EventHandler(this.mnuMoveRight_Click);
            // 
            // mnuDeletePicture
            // 
            this.mnuDeletePicture.Name = "mnuDeletePicture";
            this.mnuDeletePicture.Size = new System.Drawing.Size(156, 22);
            this.mnuDeletePicture.Text = "&Delete Picture...";
            this.mnuDeletePicture.Click += new System.EventHandler(this.mnuDeletePicture_Click);
            // 
            // mnuInsertPicture
            // 
            this.mnuInsertPicture.Name = "mnuInsertPicture";
            this.mnuInsertPicture.Size = new System.Drawing.Size(152, 22);
            this.mnuInsertPicture.Text = "&Insert Picture...";
            this.mnuInsertPicture.Click += new System.EventHandler(this.mnuInsertPicture_Click);
            // 
            // howto_edit_picture_list_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 231);
            this.Controls.Add(this.panPictures);
            this.Name = "howto_edit_picture_list_Form1";
            this.Text = "howto_edit_picture_list";
            this.ctxPictures.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panPictures;
        private System.Windows.Forms.OpenFileDialog ofdPicture;
        private System.Windows.Forms.ContextMenuStrip ctxPictures;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveLeft;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveRight;
        private System.Windows.Forms.ToolStripMenuItem mnuDeletePicture;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertPicture;
    }
}

