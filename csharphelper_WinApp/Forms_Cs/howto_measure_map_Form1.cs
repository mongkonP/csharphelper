using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_measure_map_Form1:Form
  { 


        public howto_measure_map_Form1()
        {
            InitializeComponent();
        }

        // The loaded map.
        private Bitmap Map = null;

        // Known units.
        enum Units
        {
            Undefined,
            Miles,
            Yards,
            Feet,
            Kilometers,
            Meters,
        };

        // Key map values.
        private double ScaleDistanceInUnits = -1;
        private double ScaleDistanceInPixels = -1;
        private Units CurrentUnit = Units.Miles;
        private double CurrentDistance = 0;

        // Open a map image.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdMap.ShowDialog() == DialogResult.OK)
            {
                Map = LoadUnlocked(ofdMap.FileName);
                picMap.Image = Map;
            }

            btnScale.Enabled = true;
            btnDistance.Enabled = true;
        }

        // Set the desired units.
        private void btnUnit_Click(object sender, EventArgs e)
        {
            Units old_unit = CurrentUnit;
            ToolStripMenuItem menu_item = sender as ToolStripMenuItem;
            switch (menu_item.Text)
            {
                case "Miles":
                    CurrentUnit = Units.Miles;
                    break;
                case "Yards":
                    CurrentUnit = Units.Yards;
                    break;
                case "Feet":
                    CurrentUnit = Units.Feet;
                    break;
                case "Kilometers":
                    CurrentUnit = Units.Kilometers;
                    break;
                case "Meters":
                    CurrentUnit = Units.Meters;
                    break;
            }
            btnUnits.Text = CurrentUnit.ToString();

            // Display the map scale and distance in this unit.
            // Find a factor to convert from the old units to meters.
            double conversion = 1;
            if (old_unit == Units.Feet) conversion = 0.3048;
            else if (old_unit == Units.Yards) conversion = 0.9144;
            else if (old_unit == Units.Miles) conversion = 1609.344;
            else if (old_unit == Units.Kilometers) conversion = 1000;

            // Find a factor to convert from meters to the new units.
            if (CurrentUnit == Units.Feet) conversion *= 3.28083;
            else if (CurrentUnit == Units.Yards) conversion *= 1.09361;
            else if (CurrentUnit == Units.Miles) conversion *= 0.000621;
            else if (CurrentUnit == Units.Kilometers) conversion *= 0.001;

            // Convert and display the values.
            ScaleDistanceInUnits *= conversion;
            CurrentDistance *= conversion;

            btnScale.Text = string.Format("{0} {1}/pixel",
                ScaleDistanceInUnits / ScaleDistanceInPixels,
                CurrentUnit.ToString());
            btnDistance.Text = string.Format("Distance: {0} {1}",
                CurrentDistance, CurrentUnit);
        }

        // Reset the scale.
        private Point StartPoint, EndPoint;
        private void btnScale_Click(object sender, EventArgs e)
        {
            lblInstructions.Text = "Click and drag from the start and end point of the map's scale bar.";
            picMap.Cursor = Cursors.Cross;

            picMap.MouseDown += Scale_MouseDown;
        }
        private void Scale_MouseDown(object sender, MouseEventArgs e)
        {
            StartPoint = e.Location;
            picMap.MouseDown -= Scale_MouseDown;
            picMap.MouseMove += Scale_MouseMove;
            picMap.MouseUp += Scale_MouseUp;
        }
        private void Scale_MouseMove(object sender, MouseEventArgs e)
        {
            EndPoint = e.Location;
            DisplayScaleLine();
        }
        private void Scale_MouseUp(object sender, MouseEventArgs e)
        {
            picMap.MouseMove -= Scale_MouseMove;
            picMap.MouseUp -= Scale_MouseUp;
            picMap.Cursor = Cursors.Default;
            lblInstructions.Text = "";

            // Get the scale.
            howto_measure_map_ScaleDialog dlg = new  howto_measure_map_ScaleDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Get the distance on the screen.
                int dx = EndPoint.X - StartPoint.X;
                int dy = EndPoint.Y - StartPoint.Y;
                double dist = Math.Sqrt(dx * dx + dy * dy);
                if (dist < 1) return;
                ScaleDistanceInPixels = dist;

                // Parse the distance.
                ParseDistanceString(dlg.txtScaleLength.Text,
                    out ScaleDistanceInUnits, out CurrentUnit);

                // Display the units.
                btnUnits.Text = CurrentUnit.ToString();

                // Display the scale.
                btnScale.Text = string.Format("{0} {1}/pixel",
                    ScaleDistanceInUnits / ScaleDistanceInPixels,
                    CurrentUnit.ToString());

                // Clear the distance.
                btnDistance.Text = "Distance <undefined>";
            }
        }

        // Load the image into a Bitmap, clone it, and
        // set the PictureBox's Image property to the Bitmap.
        private Bitmap LoadUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                Bitmap result = new Bitmap(bm.Width, bm.Height);
                using (Graphics gr = Graphics.FromImage(result))
                {
                    gr.DrawImage(bm, 0, 0);
                }
                return result;
            }
        }

        // Display the scale line.
        private void DisplayScaleLine()
        {
            Bitmap bm = (Bitmap)Map.Clone();
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawLine(Pens.Red, StartPoint, EndPoint);
            }
            picMap.Image = bm;
        }

        // Parse a distance string. Return the length in meters.
        private void ParseDistanceString(string txt, out double distance, out Units unit)
        {
            txt = txt.Trim();

            // Find the longest substring that makes sense as a double.
            int i = DoublePrefixLength(txt);
            if (i <= 0)
            {
                distance = -1;
                unit = Units.Undefined;
            }
            else
            {
                // Get the distance.
                distance = double.Parse(txt.Substring(0, i));

                // Get the unit.
                string unit_string = txt.Substring(i).Trim().ToLower();
                if (unit_string.StartsWith("mi")) unit = Units.Miles;
                else if (unit_string.StartsWith("y")) unit = Units.Yards;
                else if (unit_string.StartsWith("f")) unit = Units.Feet;
                else if (unit_string.StartsWith("'")) unit = Units.Feet;
                else if (unit_string.StartsWith("k")) unit = Units.Kilometers;
                else if (unit_string.StartsWith("m")) unit = Units.Meters;
                else unit = Units.Undefined;
            }
        }

        // Return the length of the longest prefix
        // string that makes sense as a double.
        private int DoublePrefixLength(string txt)
        {
            for (int i = 1; i <= txt.Length; i++)
            {
                string test_string = txt.Substring(0, i);
                double test_value;
                if (!double.TryParse(test_string, out test_value)) return i - 1;
            }
            return txt.Length;
        }

        // Exit.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Let the user draw something and calculate its length.
        private void btnDistance_Click(object sender, EventArgs e)
        {
            lblInstructions.Text = "Click and draw to define the path that you want to measure.";
            picMap.Cursor = Cursors.Cross;

            DistancePoints = new List<Point>();
            picMap.MouseDown += Distance_MouseDown;
        }

        private List<Point> DistancePoints;
        private void Distance_MouseDown(object sender, MouseEventArgs e)
        {
            DistancePoints.Add(e.Location);
            picMap.MouseDown -= Distance_MouseDown;
            picMap.MouseMove += Distance_MouseMove;
            picMap.MouseUp += Distance_MouseUp;
        }
        private void Distance_MouseMove(object sender, MouseEventArgs e)
        {
            DistancePoints.Add(e.Location);
            DisplayDistanceCurve();
        }
        private void Distance_MouseUp(object sender, MouseEventArgs e)
        {
            picMap.MouseMove -= Distance_MouseMove;
            picMap.MouseUp -= Distance_MouseUp;
            picMap.Cursor = Cursors.Default;
            lblInstructions.Text = "";

            // Measure the curve.
            double distance = 0;
            for (int i = 1; i < DistancePoints.Count; i++)
            {
                int dx = DistancePoints[i].X - DistancePoints[i - 1].X;
                int dy = DistancePoints[i].Y - DistancePoints[i - 1].Y;
                distance += Math.Sqrt(dx * dx + dy * dy);
            }

            // Convert into the proper units.
            CurrentDistance = distance * ScaleDistanceInUnits / ScaleDistanceInPixels;

            // Display the result.
            btnDistance.Text = string.Format("Distance: {0} {1}",
                CurrentDistance, CurrentUnit);
        }

        // Display the distance curve.
        private void DisplayDistanceCurve()
        {
            Bitmap bm = (Bitmap)Map.Clone();
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawLines(Pens.Red, DistancePoints.ToArray());
            }
            picMap.Image = bm;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_measure_map_Form1));
            this.btnKilometers = new System.Windows.Forms.ToolStripMenuItem();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.btnMeters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnScale = new System.Windows.Forms.ToolStripButton();
            this.lblInstructions = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDistance = new System.Windows.Forms.ToolStripButton();
            this.btnFeet = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnYards = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnUnits = new System.Windows.Forms.ToolStripDropDownButton();
            this.ofdMap = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKilometers
            // 
            this.btnKilometers.Name = "btnKilometers";
            this.btnKilometers.Size = new System.Drawing.Size(152, 22);
            this.btnKilometers.Text = "Kilometers";
            this.btnKilometers.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // picMap
            // 
            this.picMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picMap.Location = new System.Drawing.Point(12, 52);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(463, 444);
            this.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMap.TabIndex = 5;
            this.picMap.TabStop = false;
            // 
            // btnMeters
            // 
            this.btnMeters.Name = "btnMeters";
            this.btnMeters.Size = new System.Drawing.Size(152, 22);
            this.btnMeters.Text = "Meters";
            this.btnMeters.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // btnScale
            // 
            this.btnScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnScale.Enabled = false;
            this.btnScale.Image = ((System.Drawing.Image)(resources.GetObject("btnScale.Image")));
            this.btnScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScale.Name = "btnScale";
            this.btnScale.Size = new System.Drawing.Size(114, 22);
            this.btnScale.Text = "Scale: <undefined>";
            this.btnScale.Click += new System.EventHandler(this.btnScale_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(0, 17);
            // 
            // btnDistance
            // 
            this.btnDistance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDistance.Enabled = false;
            this.btnDistance.Image = ((System.Drawing.Image)(resources.GetObject("btnDistance.Image")));
            this.btnDistance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDistance.Name = "btnDistance";
            this.btnDistance.Size = new System.Drawing.Size(132, 22);
            this.btnDistance.Text = "Distance: <undefined>";
            this.btnDistance.Click += new System.EventHandler(this.btnDistance_Click);
            // 
            // btnFeet
            // 
            this.btnFeet.Name = "btnFeet";
            this.btnFeet.Size = new System.Drawing.Size(152, 22);
            this.btnFeet.Text = "Feet";
            this.btnFeet.BackColorChanged += new System.EventHandler(this.btnUnit_Click);
            this.btnFeet.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInstructions});
            this.statusStrip1.Location = new System.Drawing.Point(0, 510);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(486, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnYards
            // 
            this.btnYards.Name = "btnYards";
            this.btnYards.Size = new System.Drawing.Size(152, 22);
            this.btnYards.Text = "Yards";
            this.btnYards.BackColorChanged += new System.EventHandler(this.btnUnit_Click);
            this.btnYards.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(155, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(155, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // btnMiles
            // 
            this.btnMiles.Name = "btnMiles";
            this.btnMiles.Size = new System.Drawing.Size(152, 22);
            this.btnMiles.Text = "Miles";
            this.btnMiles.BackColorChanged += new System.EventHandler(this.btnUnit_Click);
            this.btnMiles.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(486, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnUnits
            // 
            this.btnUnits.AutoSize = false;
            this.btnUnits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUnits.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMiles,
            this.btnYards,
            this.btnFeet,
            this.toolStripSeparator1,
            this.btnKilometers,
            this.btnMeters});
            this.btnUnits.Image = ((System.Drawing.Image)(resources.GetObject("btnUnits.Image")));
            this.btnUnits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnits.Name = "btnUnits";
            this.btnUnits.Size = new System.Drawing.Size(100, 22);
            this.btnUnits.Text = "Miles";
            // 
            // ofdMap
            // 
            this.ofdMap.Filter = "Graphic Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUnits,
            this.btnScale,
            this.btnDistance});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(486, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // howto_measure_map_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 532);
            this.Controls.Add(this.picMap);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_measure_map_Form1";
            this.Text = "howto_measure_map";
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem btnKilometers;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.ToolStripMenuItem btnMeters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnScale;
        private System.Windows.Forms.ToolStripStatusLabel lblInstructions;
        private System.Windows.Forms.ToolStripButton btnDistance;
        private System.Windows.Forms.ToolStripMenuItem btnFeet;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnYards;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem btnMiles;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnUnits;
        private System.Windows.Forms.OpenFileDialog ofdMap;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}

