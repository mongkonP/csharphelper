using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_display_cursors_Form1:Form
  { 


        public howto_display_cursors_Form1()
        {
            InitializeComponent();
        }

        private const int Wid = 75;
        private const int Hgt = 70;
        private const int BmWid = 32;

        // Display samples of the cursors.
        private void howto_display_cursors_Form1_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            ShowCursor("AppStarting", Cursors.AppStarting);
            ShowCursor("Arrow", Cursors.Arrow);
            ShowCursor("Cross", Cursors.Cross);
            ShowCursor("Default", Cursors.Default);
            ShowCursor("Hand", Cursors.Hand);
            ShowCursor("Help", Cursors.Help);
            ShowCursor("HSplit", Cursors.HSplit);
            ShowCursor("IBeam", Cursors.IBeam);
            ShowCursor("No", Cursors.No);
            ShowCursor("NoMove2D", Cursors.NoMove2D);
            ShowCursor("NoMoveHoriz", Cursors.NoMoveHoriz);
            ShowCursor("NoMoveVert", Cursors.NoMoveVert);
            ShowCursor("PanEast", Cursors.PanEast);
            ShowCursor("PanNE", Cursors.PanNE);
            ShowCursor("PanNorth", Cursors.PanNorth);
            ShowCursor("PanNorth", Cursors.PanNW);
            ShowCursor("PanSE", Cursors.PanSE);
            ShowCursor("PanSouth", Cursors.PanSouth);
            ShowCursor("PanSW", Cursors.PanSW);
            ShowCursor("PanWest", Cursors.PanWest);
            ShowCursor("SizeAll", Cursors.SizeAll);
            ShowCursor("SizeNESW", Cursors.SizeNESW);
            ShowCursor("SizeNS", Cursors.SizeNS);
            ShowCursor("SizeNWSE", Cursors.SizeNWSE);
            ShowCursor("SizeWE", Cursors.SizeWE);
            ShowCursor("UpArrow", Cursors.UpArrow);
            ShowCursor("VSplit", Cursors.VSplit);
            ShowCursor("WaitCursor", Cursors.WaitCursor);
        }

        // Display a cursor.
        private void ShowCursor(string cursor_name, Cursor the_cursor)
        {
            // Make a Panel to hold the Label and PictureBox.
            Panel pan = new Panel();
            pan.Size = new Size(Wid, Hgt);
            pan.Cursor = the_cursor;
            flpSamples.Controls.Add(pan);

            // Display the cursor's name in a Label.
            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.Text = cursor_name;
            lbl.Size = new Size(Wid, 13);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Location = new Point(0, 0);
            pan.Controls.Add(lbl);

            // Draw the cursor onto a Bitmap.
            Bitmap bm = new Bitmap(BmWid, BmWid);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                the_cursor.Draw(gr, new Rectangle(0, 0, BmWid, BmWid));
            }

            // Display the Bitmap in a PictureBox.
            PictureBox pic = new PictureBox();
            pic.Location = new Point((Wid - BmWid) / 2, 15);
            pic.BorderStyle = BorderStyle.Fixed3D;
            pic.ClientSize = new Size(BmWid, BmWid);
            pic.Image = bm;
            pan.Controls.Add(pic);
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
            this.flpSamples = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpSamples
            // 
            this.flpSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSamples.Location = new System.Drawing.Point(0, 0);
            this.flpSamples.Name = "flpSamples";
            this.flpSamples.Size = new System.Drawing.Size(588, 315);
            this.flpSamples.TabIndex = 0;
            // 
            // howto_display_cursors_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 315);
            this.Controls.Add(this.flpSamples);
            this.Name = "howto_display_cursors_Form1";
            this.Text = "howto_display_cursors";
            this.Load += new System.EventHandler(this.howto_display_cursors_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSamples;
    }
}

