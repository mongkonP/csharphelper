using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using System.IO;

 

using howto_scribble_zoom2;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_scribble_zoom2_Form1:Form
  { 


        public howto_scribble_zoom2_Form1()
        {
            InitializeComponent();
        }

        // The polylines we draw.
        private List<Polyline> Polylines = new List<Polyline>();

        // The new polyline we are drawing.
        private Polyline NewPolyline = null;

        // The currently selected drawing parameters.
        private Color DrawingColor = Color.Black;
        private int DrawingThickness = 1;
        private DashStyle DrawingDashStyle = DashStyle.Solid;

        // The auto-save file name.
        private string AutoSaveFile = Path.GetTempPath() + "scribble.tmp";

        // The dimensions of the drawing area in world coordinates.
        private const int WorldWidth = 200;
        private const int WorldHeight = 200;

        // The current scale.
        private float PictureScale = 1.0f;

        // Inverse transform to convert mouse coordinates.
        private Matrix InverseTransform = new Matrix();

        // Initially select full scale.
        // Look for an auto-save file.
        // Load some test data.
        private void howto_scribble_zoom2_Form1_Load(object sender, EventArgs e)
        {
            cboScale.SelectedIndex = 2;

            // See if the file exists.
            if (File.Exists(AutoSaveFile))
            {
                // Ask the user if we should load this file.
                if (MessageBox.Show("An auto-save file exists. Do you want to load it?",
                    "Restore?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    // Load the file.
                    LoadFromFile(AutoSaveFile);
                }
            }

            MakeTestData();
            picCanvas.Refresh();
        }

        // Make some test data.
        private void MakeTestData()
        {
            Color[] colors = 
            {
                Color.Black, Color.Red, Color.Green, Color.Blue,
                Color.Lime, Color.Cyan, Color.Orange, Color.Yellow,
            };
            DashStyle[] styles =
            {
                DashStyle.Solid, DashStyle.Solid, DashStyle.Solid, 
                DashStyle.Dash, DashStyle.DashDot,
            };
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int cx = rand.Next(30, WorldWidth - 30);
                int cy = rand.Next(30, WorldHeight - 30);
                int radius = rand.Next(10, 100);
                Polyline polyline = DrawCircle(cx, cy, radius, 100);
                polyline.Color = colors[rand.Next(0, colors.Length)];
                polyline.DashStyle = styles[rand.Next(0, styles.Length)];
                polyline.Thickness = rand.Next(1, 6);
                Polylines.Add(polyline);
            }
        }

        // Draw a circle.
        private Polyline DrawCircle(int cx, int cy, int radius, int num_lines)
        {
            Polyline polyline = new Polyline();

            float theta = 0;
            float dtheta = (float)(2 * Math.PI / num_lines);
            for (int i = 0; i <= num_lines; i++)
            {
                int x = (int)(cx + radius * Math.Cos(theta));
                int y = (int)(cy + radius * Math.Sin(theta));
                theta += dtheta;
                polyline.Points.Add(new Point(x, y));
            }
            return polyline;
        }

        // Remove the auto-save file.
        private void howto_scribble_zoom2_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(AutoSaveFile)) File.Delete(AutoSaveFile);
        }

        // Auto-save.
        private void AutoSave()
        {
            SaveIntoFile(AutoSaveFile);
        }

        // Halt immediately.
        private void toolBomb_Click(object sender, EventArgs e)
        {
            throw new Exception();
        }

        // Select the appropriate color.
        private void ColorTool_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tool = sender as ToolStripMenuItem;
            toolColor.Image = tool.Image;
            DrawingColor = tool.ForeColor;
        }

        // Select the line thickness.
        private void ThicknessTool_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tool = sender as ToolStripMenuItem;
            toolThick.Image = tool.Image;
            DrawingThickness = int.Parse(tool.Text);
        }

        // Select the dash style.
        private void StyleTool_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tool = sender as ToolStripMenuItem;
            toolStyle.Image = tool.Image;
            switch (tool.Text)
            {
                case "Solid":
                    DrawingDashStyle = DashStyle.Solid;
                    break;
                case "Dash":
                    DrawingDashStyle = DashStyle.Dash;
                    break;
                case "Dot":
                    DrawingDashStyle = DashStyle.Dot;
                    break;
                case "Custom":
                    DrawingDashStyle = DashStyle.Custom;
                    break;
            }
        }

        // Start drawing.
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            // Create the new polyline.
            NewPolyline = new Polyline();
            Polylines.Add(NewPolyline);

            // Initialize it and add the first point.
            NewPolyline.Color = DrawingColor;
            NewPolyline.Thickness = DrawingThickness;
            NewPolyline.DashStyle = DrawingDashStyle;

            // Transform the point for the current scale.
            Point[] points = { e.Location };
            InverseTransform.TransformPoints(points);
            NewPolyline.Points.Add(points[0]);
        }

        // Continue drawing.
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (NewPolyline == null) return;

            // Transform the point for the current scale.
            Point[] points = { e.Location };
            InverseTransform.TransformPoints(points);
            NewPolyline.Points.Add(points[0]);

            picCanvas.Refresh();
        }

        // Stop drawing.
        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (NewPolyline == null) return;

            // See if the new polyline contains more than 1 point.
            if (NewPolyline.Points.Count < 2)
            {
                // Remove it.
                Polylines.RemoveAt(Polylines.Count - 1);
            }

            // Redraw.
            NewPolyline = null;
            picCanvas.Refresh();

            // Save a new snapshot in the undo list.
            SaveSnapshot(true);
        }

        // Exit.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Start a new drawing.
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            Polylines = new List<Polyline>();
            picCanvas.Refresh();

            // Save a new snapshot in the undo list.
            UndoList = new Stack<string>();
            RedoList = new Stack<string>();
        }

        // Save the drawing.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                SaveIntoFile(sfdFile.FileName);
            }
        }

        // Save the current picture into a file.
        private void SaveIntoFile(string filename)
        {
            XmlSerializer xml_serializer = new XmlSerializer(Polylines.GetType());
            using (StreamWriter stream_writer = new StreamWriter(filename))
            {
                xml_serializer.Serialize(stream_writer, Polylines);
                stream_writer.Close();
            }
        }

        // Open a saved drawing.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                LoadFromFile(ofdFile.FileName);
            }
        }

        // Load a saved picture from a file.
        private void LoadFromFile(string filename)
        {
            try
            {
                XmlSerializer xml_serializer = new XmlSerializer(Polylines.GetType());
                using (FileStream file_stream = new FileStream(filename, FileMode.Open))
                {
                    List<Polyline> new_polylines =
                        (List<Polyline>)xml_serializer.Deserialize(file_stream);
                    Polylines = new_polylines;
                    picCanvas.Refresh();

                    // Save a new snapshot in the undo list.
                    UndoList = new Stack<string>();
                    RedoList = new Stack<string>();
                    SaveSnapshot(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // The undo and redo history lists.
        private Stack<string> UndoList = new Stack<string>();
        private Stack<string> RedoList = new Stack<string>();

        // Save a snapshot in the undo list.
        private void SaveSnapshot(bool auto_save)
        {
            // Save the snapshot.
            UndoList.Push(GetSnapshot());

            // Empty the redo list.
            if (RedoList.Count > 0) RedoList = new Stack<string>();

            // Enable or disable the Undo and Redo menu items.
            EnableUndo();

            // Auto-save.
            if (auto_save) AutoSave();
        }

        // Enable or disable the Undo and Redo menu items.
        private void EnableUndo()
        {
            mnuEditUndo.Enabled = (UndoList.Count > 0);
            mnuEditRedo.Enabled = (RedoList.Count > 0);
        }

        // Return an XML serialization of the current drawing.
        private string GetSnapshot()
        {
            XmlSerializer xml_serializer = new XmlSerializer(Polylines.GetType());
            using (StringWriter string_writer = new StringWriter())
            {
                xml_serializer.Serialize(string_writer, Polylines);
                return string_writer.ToString();
            }
        }

        // Use an XML serialization to load a drawing.
        private void RestoreTopUndoItem()
        {
            if (UndoList.Count == 0)
            {
                // The undo list is empty. Display a blank drawing.
                Polylines = new List<Polyline>();
            }
            else
            {
                // Restore the first serialization from the undo list.
                XmlSerializer xml_serializer = new XmlSerializer(Polylines.GetType());
                using (StringReader string_reader = new StringReader(UndoList.Peek()))
                {
                    List<Polyline> new_polylines =
                        (List<Polyline>)xml_serializer.Deserialize(string_reader);
                    Polylines = new_polylines;
                }
            }
            picCanvas.Refresh();

            // Auto-save.
            AutoSave();
        }

        // Undo.
        private void mnuEditUndo_Click(object sender, EventArgs e)
        {
            // Move the most recent change to the redo list.
            RedoList.Push(UndoList.Pop());

            // Restore the top item in the Undo list.
            RestoreTopUndoItem();

            // Enable or disable the Undo and Redo menu items.
            EnableUndo();
        }

        // Redo.
        private void mnuEditRedo_Click(object sender, EventArgs e)
        {
            // Move the most recently undone item back to the undo list.
            UndoList.Push(RedoList.Pop());

            // Restore the top item in the Undo list.
            RestoreTopUndoItem();

            // Enable or disable the Undo and Redo menu items.
            EnableUndo();
        }

        // Select the new scale.
        private void cboScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboScale.Text)
            {
                case "x 1/4":
                    SetScale(0.25f);
                    break;
                case "x 1/2":
                    SetScale(0.5f);
                    break;
                case "x 1":
                    SetScale(1.0f);
                    break;
                case "x 2":
                    SetScale(2.0f);
                    break;
                case "x 4":
                    SetScale(4.0f);
                    break;
                case "x 8":
                    SetScale(8.0f);
                    break;
            }
        }

        // Set the scale and redraw.
        private void SetScale(float picture_scale)
        {
            // Set the scale.
            PictureScale = picture_scale;

            // Resize the PictureBox.
            picCanvas.ClientSize = new Size(
                (int)(WorldWidth * PictureScale),
                (int)(WorldHeight * PictureScale));

            // Prepare the inverse transformation for points.
            InverseTransform = new Matrix();
            InverseTransform.Scale(1.0f / picture_scale, 1.0f / picture_scale);

            // Redraw.
            picCanvas.Refresh();
        }

        // Draw the picture.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            // Ready.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);

            // Scale.
            e.Graphics.ScaleTransform(PictureScale, PictureScale);

            // Draw.
            foreach (Polyline polyline in Polylines)
            {
                polyline.Draw(e.Graphics);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_scribble_zoom2_Form1));
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolColor = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolBlack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOrange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolYellow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolThick = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolThick1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolThick2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolThick3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolThick4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolThick5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStyle = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolSolid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDash = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBomb = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cboScale = new System.Windows.Forms.ToolStripComboBox();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.panWindow = new System.Windows.Forms.Panel();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // sfdFile
            // 
            this.sfdFile.Filter = "Polyline Files|*.pln|All Files|*.*";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolColor,
            this.toolThick,
            this.toolStyle,
            this.toolBomb,
            this.toolStripSeparator1,
            this.cboScale});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolColor
            // 
            this.toolColor.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBlack,
            this.toolRed,
            this.toolGreen,
            this.toolBlue,
            this.toolOrange,
            this.toolYellow,
            this.toolLime});
            this.toolColor.ForeColor = System.Drawing.Color.Black;
            this.toolColor.Image = ((System.Drawing.Image)(resources.GetObject("toolColor.Image")));
            this.toolColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolColor.Name = "toolColor";
            this.toolColor.Size = new System.Drawing.Size(29, 22);
            this.toolColor.Text = "toolStripDropDownButton1";
            // 
            // toolBlack
            // 
            this.toolBlack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBlack.ForeColor = System.Drawing.Color.Black;
            this.toolBlack.Image = Properties.Resources.black;
            this.toolBlack.Name = "toolBlack";
            this.toolBlack.Size = new System.Drawing.Size(113, 22);
            this.toolBlack.Text = "Black";
            this.toolBlack.Click += new System.EventHandler(this.ColorTool_Click);
            // 
            // toolRed
            // 
            this.toolRed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRed.ForeColor = System.Drawing.Color.Red;
            this.toolRed.Image = Properties.Resources.red;
            this.toolRed.Name = "toolRed";
            this.toolRed.Size = new System.Drawing.Size(113, 22);
            this.toolRed.Text = "Red";
            this.toolRed.Click += new System.EventHandler(this.ColorTool_Click);
            // 
            // toolGreen
            // 
            this.toolGreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolGreen.ForeColor = System.Drawing.Color.Green;
            this.toolGreen.Image = Properties.Resources.green;
            this.toolGreen.Name = "toolGreen";
            this.toolGreen.Size = new System.Drawing.Size(113, 22);
            this.toolGreen.Text = "Green";
            this.toolGreen.Click += new System.EventHandler(this.ColorTool_Click);
            // 
            // toolBlue
            // 
            this.toolBlue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBlue.ForeColor = System.Drawing.Color.Blue;
            this.toolBlue.Image = Properties.Resources.blue;
            this.toolBlue.Name = "toolBlue";
            this.toolBlue.Size = new System.Drawing.Size(113, 22);
            this.toolBlue.Text = "Blue";
            this.toolBlue.Click += new System.EventHandler(this.ColorTool_Click);
            // 
            // toolOrange
            // 
            this.toolOrange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolOrange.ForeColor = System.Drawing.Color.Orange;
            this.toolOrange.Image = Properties.Resources.orange;
            this.toolOrange.Name = "toolOrange";
            this.toolOrange.Size = new System.Drawing.Size(113, 22);
            this.toolOrange.Text = "Orange";
            this.toolOrange.Click += new System.EventHandler(this.ColorTool_Click);
            // 
            // toolYellow
            // 
            this.toolYellow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolYellow.ForeColor = System.Drawing.Color.Yellow;
            this.toolYellow.Image = Properties.Resources.yellow;
            this.toolYellow.Name = "toolYellow";
            this.toolYellow.Size = new System.Drawing.Size(113, 22);
            this.toolYellow.Text = "Yellow";
            this.toolYellow.Click += new System.EventHandler(this.ColorTool_Click);
            // 
            // toolLime
            // 
            this.toolLime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLime.ForeColor = System.Drawing.Color.Lime;
            this.toolLime.Image = Properties.Resources.lime;
            this.toolLime.Name = "toolLime";
            this.toolLime.Size = new System.Drawing.Size(113, 22);
            this.toolLime.Text = "Lime";
            this.toolLime.Click += new System.EventHandler(this.ColorTool_Click);
            // 
            // toolThick
            // 
            this.toolThick.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolThick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolThick.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolThick1,
            this.toolThick2,
            this.toolThick3,
            this.toolThick4,
            this.toolThick5});
            this.toolThick.Image = ((System.Drawing.Image)(resources.GetObject("toolThick.Image")));
            this.toolThick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolThick.Name = "toolThick";
            this.toolThick.Size = new System.Drawing.Size(29, 22);
            this.toolThick.Text = "toolStripDropDownButton1";
            // 
            // toolThick1
            // 
            this.toolThick1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolThick1.Image = Properties.Resources.line1;
            this.toolThick1.Name = "toolThick1";
            this.toolThick1.Size = new System.Drawing.Size(80, 22);
            this.toolThick1.Text = "1";
            this.toolThick1.Click += new System.EventHandler(this.ThicknessTool_Click);
            // 
            // toolThick2
            // 
            this.toolThick2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolThick2.Image = Properties.Resources.line2;
            this.toolThick2.Name = "toolThick2";
            this.toolThick2.Size = new System.Drawing.Size(80, 22);
            this.toolThick2.Text = "2";
            this.toolThick2.Click += new System.EventHandler(this.ThicknessTool_Click);
            // 
            // toolThick3
            // 
            this.toolThick3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolThick3.Image = Properties.Resources.line3;
            this.toolThick3.Name = "toolThick3";
            this.toolThick3.Size = new System.Drawing.Size(80, 22);
            this.toolThick3.Text = "3";
            this.toolThick3.Click += new System.EventHandler(this.ThicknessTool_Click);
            // 
            // toolThick4
            // 
            this.toolThick4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolThick4.Image = Properties.Resources.line4;
            this.toolThick4.Name = "toolThick4";
            this.toolThick4.Size = new System.Drawing.Size(80, 22);
            this.toolThick4.Text = "4";
            this.toolThick4.Click += new System.EventHandler(this.ThicknessTool_Click);
            // 
            // toolThick5
            // 
            this.toolThick5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolThick5.Image = Properties.Resources.line5;
            this.toolThick5.Name = "toolThick5";
            this.toolThick5.Size = new System.Drawing.Size(80, 22);
            this.toolThick5.Text = "5";
            this.toolThick5.Click += new System.EventHandler(this.ThicknessTool_Click);
            // 
            // toolStyle
            // 
            this.toolStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSolid,
            this.toolDash,
            this.toolDot,
            this.toolCustom});
            this.toolStyle.Image = ((System.Drawing.Image)(resources.GetObject("toolStyle.Image")));
            this.toolStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStyle.Name = "toolStyle";
            this.toolStyle.Size = new System.Drawing.Size(29, 22);
            this.toolStyle.Text = "toolStripDropDownButton1";
            // 
            // toolSolid
            // 
            this.toolSolid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSolid.Image = Properties.Resources.solid;
            this.toolSolid.Name = "toolSolid";
            this.toolSolid.Size = new System.Drawing.Size(116, 22);
            this.toolSolid.Text = "Solid";
            this.toolSolid.Click += new System.EventHandler(this.StyleTool_Click);
            // 
            // toolDash
            // 
            this.toolDash.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDash.Image = Properties.Resources.dash;
            this.toolDash.Name = "toolDash";
            this.toolDash.Size = new System.Drawing.Size(116, 22);
            this.toolDash.Text = "Dash";
            this.toolDash.Click += new System.EventHandler(this.StyleTool_Click);
            // 
            // toolDot
            // 
            this.toolDot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDot.Image = Properties.Resources.dot;
            this.toolDot.Name = "toolDot";
            this.toolDot.Size = new System.Drawing.Size(116, 22);
            this.toolDot.Text = "Dot";
            this.toolDot.Click += new System.EventHandler(this.StyleTool_Click);
            // 
            // toolCustom
            // 
            this.toolCustom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCustom.Image = Properties.Resources.custom_dash;
            this.toolCustom.Name = "toolCustom";
            this.toolCustom.Size = new System.Drawing.Size(116, 22);
            this.toolCustom.Text = "Custom";
            this.toolCustom.Click += new System.EventHandler(this.StyleTool_Click);
            // 
            // toolBomb
            // 
            this.toolBomb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolBomb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBomb.Image = ((System.Drawing.Image)(resources.GetObject("toolBomb.Image")));
            this.toolBomb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBomb.Name = "toolBomb";
            this.toolBomb.Size = new System.Drawing.Size(23, 22);
            this.toolBomb.Text = "toolStripButton1";
            this.toolBomb.Click += new System.EventHandler(this.toolBomb_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cboScale
            // 
            this.cboScale.AutoSize = false;
            this.cboScale.Items.AddRange(new object[] {
            "x 1/4",
            "x 1/2",
            "x 1",
            "x 2",
            "x 4",
            "x 8"});
            this.cboScale.Name = "cboScale";
            this.cboScale.Size = new System.Drawing.Size(50, 23);
            this.cboScale.SelectedIndexChanged += new System.EventHandler(this.cboScale_SelectedIndexChanged);
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            this.ofdFile.Filter = "Polyline Files|*.pln|All Files|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSaveAs,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuFileNew.Size = new System.Drawing.Size(163, 22);
            this.mnuFileNew.Text = "&New";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(163, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(163, 22);
            this.mnuFileSaveAs.Text = "Save &As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(163, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditUndo,
            this.mnuEditRedo});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // mnuEditUndo
            // 
            this.mnuEditUndo.Enabled = false;
            this.mnuEditUndo.Name = "mnuEditUndo";
            this.mnuEditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.mnuEditUndo.Size = new System.Drawing.Size(145, 22);
            this.mnuEditUndo.Text = "&Undo";
            this.mnuEditUndo.Click += new System.EventHandler(this.mnuEditUndo_Click);
            // 
            // mnuEditRedo
            // 
            this.mnuEditRedo.Enabled = false;
            this.mnuEditRedo.Name = "mnuEditRedo";
            this.mnuEditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuEditRedo.Size = new System.Drawing.Size(145, 22);
            this.mnuEditRedo.Text = "&Redo";
            this.mnuEditRedo.Click += new System.EventHandler(this.mnuEditRedo_Click);
            // 
            // panWindow
            // 
            this.panWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panWindow.AutoScroll = true;
            this.panWindow.Controls.Add(this.picCanvas);
            this.panWindow.Location = new System.Drawing.Point(12, 52);
            this.panWindow.Name = "panWindow";
            this.panWindow.Size = new System.Drawing.Size(260, 197);
            this.panWindow.TabIndex = 11;
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(3, 3);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(200, 200);
            this.picCanvas.TabIndex = 6;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
            // 
            // howto_scribble_zoom2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panWindow);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_scribble_zoom2_Form1";
            this.Text = "howto_scribble_zoom2";
            this.Load += new System.EventHandler(this.howto_scribble_zoom2_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_scribble_zoom2_Form1_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog sfdFile;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolColor;
        private System.Windows.Forms.ToolStripMenuItem toolBlack;
        private System.Windows.Forms.ToolStripMenuItem toolRed;
        private System.Windows.Forms.ToolStripMenuItem toolGreen;
        private System.Windows.Forms.ToolStripMenuItem toolBlue;
        private System.Windows.Forms.ToolStripMenuItem toolOrange;
        private System.Windows.Forms.ToolStripMenuItem toolYellow;
        private System.Windows.Forms.ToolStripMenuItem toolLime;
        private System.Windows.Forms.ToolStripDropDownButton toolThick;
        private System.Windows.Forms.ToolStripMenuItem toolThick1;
        private System.Windows.Forms.ToolStripMenuItem toolThick2;
        private System.Windows.Forms.ToolStripMenuItem toolThick3;
        private System.Windows.Forms.ToolStripMenuItem toolThick4;
        private System.Windows.Forms.ToolStripMenuItem toolThick5;
        private System.Windows.Forms.ToolStripDropDownButton toolStyle;
        private System.Windows.Forms.ToolStripMenuItem toolSolid;
        private System.Windows.Forms.ToolStripMenuItem toolDash;
        private System.Windows.Forms.ToolStripMenuItem toolDot;
        private System.Windows.Forms.ToolStripMenuItem toolCustom;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuEditRedo;
        private System.Windows.Forms.ToolStripButton toolBomb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox cboScale;
        private System.Windows.Forms.Panel panWindow;
        private System.Windows.Forms.PictureBox picCanvas;
    }
}

