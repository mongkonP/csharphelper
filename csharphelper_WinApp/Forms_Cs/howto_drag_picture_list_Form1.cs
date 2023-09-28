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
     public partial class howto_drag_picture_list_Form1:Form
  { 


        public howto_drag_picture_list_Form1()
        {
            InitializeComponent();
        }

        // The currently loaded PictureBoxes.
        private List<PictureBox> PictureBoxes =
            new List<PictureBox>();
        private const int PictureMargin = 8;

        // A placeholder to ensure that the Panel
        // control has some empty area to the right.
        PictureBox Placeholder;

        // The index of the picture we clicked or
        // the picture before which we clicked.
        private int ClickedIndex = -1;

        // Used to drag PictureBoxes.
        private PictureBox DragPic = null;
        private Point DragOffset;

        // Create the placeholder PictureBox.
        private void howto_drag_picture_list_Form1_Load(object sender, EventArgs e)
        {
            Placeholder = new PictureBox();
            Placeholder.Location = new Point(PictureMargin, PictureMargin);
            Placeholder.Size = new Size(0, 0);
            Placeholder.Visible = true;
            panPictures.Controls.Add(Placeholder);
        }

        // Arrange the PictureBoxes.
        private void ArrangePictureBoxes()
        {
            int ymax = 0;
            int x = PictureMargin;
            int y = PictureMargin;
            foreach (PictureBox pic in PictureBoxes)
            {
                pic.Location = new Point(x, y);
                x += pic.Width + PictureMargin;
                if (ymax < pic.Height) ymax = pic.Height;
            }

            // Position one placeholder PictureBox.
            y = ymax + 2 * PictureMargin;
            Placeholder.Location = new Point(x, y);
        }

        // Rearrange the picture list so the controls
        // are ordered by their X coordinates.
        private void OrderPictureBoxes()
        {
            // Sort the PictureBoxes list.
            PictureBoxes.Sort((pic1, pic2) =>
                pic1.Location.X.CompareTo(pic2.Location.X));

            // Rearrange the controls.
            ArrangePictureBoxes();
        }

        // Start dragging the control or display the context menu.
        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pic = sender as PictureBox;

            if (e.Button == MouseButtons.Left)
            {
                // Start dragging.
                DragPic = pic;
                int dx = -e.Location.X;
                int dy = -e.Location.Y;
                DragOffset = new Point(dx, dy);

                // Move the PictureBox to the top of the
                // panPictures stacking order.
                panPictures.Controls.SetChildIndex(pic, 0);

                // Let panPictures handle the MouseMove and MouseUp.
                DragPic.Capture = false;
                panPictures.Capture = true;
                panPictures.MouseMove += panPictures_MouseMove;
                panPictures.MouseUp += panPictures_MouseUp;
            }
            else
            {
                // Get the mouse's location in panPictures coordinates.
                Point screen_point = pic.PointToScreen(e.Location);
                Point parent_point = panPictures.PointToClient(screen_point);

                // Display the context menu.
                ShowContextMenu(new Point(
                    parent_point.X,
                    parent_point.Y));
            }
        }

        // Move a PictureBox.
        private void panPictures_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.Location.X + DragOffset.X;
            int y = e.Location.Y + DragOffset.Y;
            DragPic.Location = new Point(x, y);
        }

        // Stop dragging DragPic.
        private void panPictures_MouseUp(object sender, MouseEventArgs e)
        {
            DragPic = null;
            panPictures.MouseMove -= panPictures_MouseMove;
            panPictures.MouseUp -= panPictures_MouseUp;
            OrderPictureBoxes();
        }

        // Display the context menu.
        private void panPictures_MouseDown(object sender, MouseEventArgs e)
        {
            // Ignore left mouse clicks.
            if (e.Button != MouseButtons.Right) return;

            // Display the context menu.
            ShowContextMenu(e.Location);
        }

        private void mnuMoveLeft_Click(object sender, EventArgs e)
        {
            PictureBox pic = PictureBoxes[ClickedIndex];
            PictureBoxes.RemoveAt(ClickedIndex);
            PictureBoxes.Insert(ClickedIndex - 1, pic);
            ArrangePictureBoxes();
        }

        private void mnuMoveRight_Click(object sender, EventArgs e)
        {
            PictureBox pic = PictureBoxes[ClickedIndex];
            PictureBoxes.RemoveAt(ClickedIndex);
            PictureBoxes.Insert(ClickedIndex + 1, pic);
            ArrangePictureBoxes();
        }

        private void mnuDeletePicture_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to delete this picture?",
                "Delete Picture?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                panPictures.Controls.Remove(PictureBoxes[ClickedIndex]);
                PictureBoxes.RemoveAt(ClickedIndex);
                ArrangePictureBoxes();
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

                        PictureBox pic = new PictureBox();
                        pic.SizeMode = PictureBoxSizeMode.AutoSize;
                        pic.Image = bm;
                        pic.Visible = true;
                        pic.BorderStyle = BorderStyle.Fixed3D;
                        pic.MouseDown += pic_MouseDown;
                        panPictures.Controls.Add(pic);

                        PictureBoxes.Insert(ClickedIndex + i, pic);
                        i++;
                    }
                    ArrangePictureBoxes();
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
            ClickedIndex = PictureBoxes.Count;

            // See if we clicked on or before a picture.
            int x = location.X + panPictures.HorizontalScroll.Value;
            for (int i = 0; i < PictureBoxes.Count; i++)
            {
                // See if we are before the next picture.
                x -= PictureMargin;
                if (x < 0)
                {
                    ClickedIndex = i;
                    break;
                }   

                // See if we are on this picture.
                x -= PictureBoxes[i].Width;
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
                (clicked_on_picture && (ClickedIndex < PictureBoxes.Count - 1));
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
            this.ctxPictures = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMoveLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveRight = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeletePicture = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsertPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
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
            this.mnuMoveLeft.Size = new System.Drawing.Size(156, 22);
            this.mnuMoveLeft.Text = "Move &Left";
            this.mnuMoveLeft.Click += new System.EventHandler(this.mnuMoveLeft_Click);
            // 
            // mnuMoveRight
            // 
            this.mnuMoveRight.Name = "mnuMoveRight";
            this.mnuMoveRight.Size = new System.Drawing.Size(156, 22);
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
            this.mnuInsertPicture.Size = new System.Drawing.Size(156, 22);
            this.mnuInsertPicture.Text = "&Insert Picture...";
            this.mnuInsertPicture.Click += new System.EventHandler(this.mnuInsertPicture_Click);
            // 
            // ofdPicture
            // 
            this.ofdPicture.DefaultExt = "png";
            this.ofdPicture.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All FIles|*.*";
            this.ofdPicture.Multiselect = true;
            // 
            // howto_drag_picture_list_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 231);
            this.Controls.Add(this.panPictures);
            this.Name = "howto_drag_picture_list_Form1";
            this.Text = "howto_edit_picture_list";
            this.Load += new System.EventHandler(this.howto_drag_picture_list_Form1_Load);
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

