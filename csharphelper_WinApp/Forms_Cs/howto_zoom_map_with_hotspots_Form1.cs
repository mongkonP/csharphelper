// #define DRAW_HOTSPOTS

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
     public partial class howto_zoom_map_with_hotspots_Form1:Form
  { 


        public howto_zoom_map_with_hotspots_Form1()
        {
            InitializeComponent();
        }

        // The map.
        private Bitmap Map;

        // The hotspots.
        private List<Rectangle> Hotspots = new List<Rectangle>();

        // The current scale.
        private float MapScale;

        // Exit.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Prepare the map for first viewing.
        private void howto_zoom_map_with_hotspots_Form1_Load(object sender, EventArgs e)
        {
            // Initialize the hotspots.
            Hotspots.Add(new Rectangle(88, 509, 22, 22));
            Hotspots.Add(new Rectangle(140, 577, 20, 20));
            Hotspots.Add(new Rectangle(161, 609, 20, 20));
            Hotspots.Add(new Rectangle(630, 138, 20, 20));
            Hotspots.Add(new Rectangle(447, 626, 20, 20));
            Hotspots.Add(new Rectangle(966, 179, 20, 20));
            Hotspots.Add(new Rectangle(958, 214, 20, 20));
            Hotspots.Add(new Rectangle(1062, 301, 20, 20));
            Hotspots.Add(new Rectangle(1109, 581, 20, 20));
            Hotspots.Add(new Rectangle(1099, 621, 20, 20));
            Hotspots.Add(new Rectangle(1247, 262, 20, 16));
            Hotspots.Add(new Rectangle(1314, 224, 20, 20));
            Hotspots.Add(new Rectangle(1344, 651, 20, 20));
            Hotspots.Add(new Rectangle(1098, 753, 20, 20));
            Hotspots.Add(new Rectangle(655, 797, 20, 20));
            Hotspots.Add(new Rectangle(549, 846, 20, 20));
            Hotspots.Add(new Rectangle(449, 935, 20, 20));
            Hotspots.Add(new Rectangle(826, 876, 20, 20));
            Hotspots.Add(new Rectangle(991, 930, 20, 20));
            Hotspots.Add(new Rectangle(1095, 900, 20, 20));
            Hotspots.Add(new Rectangle(1249, 942, 20, 20));
            Hotspots.Add(new Rectangle(254, 1079, 20, 20));
            Hotspots.Add(new Rectangle(298, 1110, 20, 20));
            Hotspots.Add(new Rectangle(1234, 1076, 16, 18));

            // If we should draw the hotspots, add them to the map.
            Map = Properties.Resources.GCMap;

#if DRAW_HOTSPOTS
            using (Graphics gr = Graphics.FromImage(Map))
            {
                foreach (Rectangle hotspot in Hotspots)
                {
                    gr.FillRectangle(Brushes.Blue, hotspot);
                }
            }
#endif

            // Display the initial map.
            picMap.SizeMode = PictureBoxSizeMode.Zoom;
            picMap.Image = Map;

            // Start at small scale.
            SetMapScale(mnuScale4);
        }

        // Scale the map.
        private void mnuScaleMap_Click(object sender, EventArgs e)
        {
            SetMapScale(sender as ToolStripMenuItem);
        }
        private void SetMapScale(ToolStripMenuItem checked_item)
        {
            // Select the correct menu item.
            foreach (ToolStripMenuItem item in
                scaleToolStripMenuItem.DropDownItems)
                    item.Checked = (item == checked_item);

            // Scale the map.
            MapScale = float.Parse(checked_item.Tag.ToString());
            picMap.Size = new Size(
                (int)(Map.Width * MapScale),
                (int)(Map.Height * MapScale));
        }

        // See if we're over a hotspot.
        private void picMap_MouseMove(object sender, MouseEventArgs e)
        {
            // See if we're over a hotspot.
            if (HotspotAtPoint(e.Location) >= 0)
                picMap.Cursor = Cursors.Hand;
            else
                picMap.Cursor = Cursors.Default;
        }

        // See if we clicked a hotspot.
        private void picMap_MouseClick(object sender, MouseEventArgs e)
        {
            int i = HotspotAtPoint(e.Location);
            if (i >= 0) MessageBox.Show("You clicked hotspot " + i);
        }

        // Return the index of the hotspot at this point
        // or -1 if there is no hotspot there.
        private int HotspotAtPoint(Point mouse_point)
        {
            // Adjust for the current map scale.
            mouse_point = new Point(
                (int)(mouse_point.X / MapScale),
                (int)(mouse_point.Y / MapScale));

            // Check the hotspots.
            //return Hotspots.FindIndex(hotspot => hotspot.Contains(mouse_point));

            for (int i = 0; i < Hotspots.Count; i++)
                if (Hotspots[i].Contains(mouse_point)) return i;

            // We didn't find a hotspot that contains the point.
            return -1;
        }

        // Display a hotspot definition in the Output window.
        private void mnuMakeHotspot_Click(object sender, EventArgs e)
        {
            picMap.MouseMove -= picMap_MouseMove;
            picMap.MouseClick -= picMap_MouseClick;
            picMap.MouseDown += makeHotspot_MouseDown;
            picMap.Cursor = Cursors.Cross;
        }

        // Begin defining a hotspot.
        private Point HotspotStart, HotspotEnd;
        private Bitmap HotspotBm;
        private Graphics HotspotGr;
        private void makeHotspot_MouseDown(object sender, MouseEventArgs e)
        {
            HotspotStart = e.Location;
            picMap.MouseDown -= makeHotspot_MouseDown;
            picMap.MouseMove += makeHotspot_MouseMove;
            picMap.MouseUp += makeHotspot_MouseUp;

            // Get ready to draw a selection rectangle.
            HotspotBm = (Bitmap)Map.Clone();
            HotspotGr = Graphics.FromImage(HotspotBm);
            picMap.Image = HotspotBm;
        }

        // Draw a selection rectangle.
        private void makeHotspot_MouseMove(object sender, MouseEventArgs e)
        {
            // Save the new point.
            HotspotEnd = e.Location;

            // Draw the selection rectangle.
            HotspotGr.DrawImage(Map, 0, 0);
            float x = Math.Min(HotspotStart.X, HotspotEnd.X) * MapScale;
            float y = Math.Min(HotspotStart.Y, HotspotEnd.Y) * MapScale;
            float wid = Math.Abs(HotspotStart.X - HotspotEnd.X) * MapScale;
            float hgt = Math.Abs(HotspotStart.Y - HotspotEnd.Y) * MapScale;
            using (Pen thin_pen = new Pen(Color.Red, 1 * MapScale))
            {
                thin_pen.DashStyle = DashStyle.Dash;
                HotspotGr.DrawRectangle(thin_pen, x, y, wid, hgt);
            }

            picMap.Refresh();
        }

        // Finish defining a hotspot.
        private void makeHotspot_MouseUp(object sender, MouseEventArgs e)
        {
            // End hotspot definition mode.
            picMap.MouseMove -= makeHotspot_MouseMove;
            picMap.MouseUp -= makeHotspot_MouseUp;
            picMap.MouseMove += picMap_MouseMove;
            picMap.MouseClick += picMap_MouseClick;
            picMap.Image = Map;
            picMap.Cursor = Cursors.Default;
            picMap.Refresh();

            // Display the hotspot definition.
            float x = Math.Min(HotspotStart.X, HotspotEnd.X) * MapScale;
            float y = Math.Min(HotspotStart.Y, HotspotEnd.Y) * MapScale;
            float wid = Math.Abs(HotspotStart.X - HotspotEnd.X) * MapScale;
            float hgt = Math.Abs(HotspotStart.Y - HotspotEnd.Y) * MapScale;
            Console.WriteLine(
                "            Hotspots.Add(new Rectangle({0}, {1}, {2}, {3}));",
                (int)x, (int)y, (int)wid, (int)hgt);
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
            this.mnuScale2 = new System.Windows.Forms.ToolStripMenuItem();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.mnuScale4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMakeHotspot = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panMap = new System.Windows.Forms.Panel();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.panMap.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuScale2
            // 
            this.mnuScale2.Name = "mnuScale2";
            this.mnuScale2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.mnuScale2.Size = new System.Drawing.Size(163, 22);
            this.mnuScale2.Tag = "0.5";
            this.mnuScale2.Text = "1/&2";
            this.mnuScale2.Click += new System.EventHandler(this.mnuScaleMap_Click);
            // 
            // picMap
            // 
            this.picMap.Location = new System.Drawing.Point(3, 3);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(96, 81);
            this.picMap.TabIndex = 1;
            this.picMap.TabStop = false;
            this.picMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseMove);
            this.picMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseClick);
            // 
            // mnuScale4
            // 
            this.mnuScale4.Name = "mnuScale4";
            this.mnuScale4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.mnuScale4.Size = new System.Drawing.Size(163, 22);
            this.mnuScale4.Tag = "0.25";
            this.mnuScale4.Text = "1/&4";
            this.mnuScale4.Click += new System.EventHandler(this.mnuScaleMap_Click);
            // 
            // mnuScale1
            // 
            this.mnuScale1.Name = "mnuScale1";
            this.mnuScale1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuScale1.Size = new System.Drawing.Size(163, 22);
            this.mnuScale1.Tag = "1";
            this.mnuScale1.Text = "&Full Scale";
            this.mnuScale1.Click += new System.EventHandler(this.mnuScaleMap_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMakeHotspot});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "&Data";
            this.dataToolStripMenuItem.Visible = false;
            // 
            // mnuMakeHotspot
            // 
            this.mnuMakeHotspot.Name = "mnuMakeHotspot";
            this.mnuMakeHotspot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnuMakeHotspot.Size = new System.Drawing.Size(192, 22);
            this.mnuMakeHotspot.Text = "Make Hotspot";
            this.mnuMakeHotspot.Click += new System.EventHandler(this.mnuMakeHotspot_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScale1,
            this.mnuScale2,
            this.mnuScale4});
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.scaleToolStripMenuItem.Text = "&Scale";
            // 
            // panMap
            // 
            this.panMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panMap.AutoScroll = true;
            this.panMap.Controls.Add(this.picMap);
            this.panMap.Location = new System.Drawing.Point(12, 33);
            this.panMap.Name = "panMap";
            this.panMap.Size = new System.Drawing.Size(330, 222);
            this.panMap.TabIndex = 2;
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(92, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scaleToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(354, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // howto_zoom_map_with_hotspots_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 261);
            this.Controls.Add(this.panMap);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_zoom_map_with_hotspots_Form1";
            this.Text = "howto_zoom_map_with_hotspots";
            this.Load += new System.EventHandler(this.howto_zoom_map_with_hotspots_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.panMap.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuScale2;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.ToolStripMenuItem mnuScale4;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuMakeHotspot;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.Panel panMap;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    }
}

