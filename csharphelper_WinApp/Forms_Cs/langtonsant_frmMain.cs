#region Copyright
/*
 * Copyright (c) 2011 Gregory L. Ables
 */
#endregion

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

 

using LangtonsAnt;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class langtonsant_frmMain:Form
  { 


        private static string ApplicationPath
        {
            get
            {
                return System.IO.Path.GetDirectoryName(
                  System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }
        private static string AppDataFile = @"antMap.txt";

        private GridVirtual gridVirtual;
        private langtonsant_GridBoard gridBoard;

        private static string screenShotFileNamePrefix = "screenshot";
        private static string screenShotFileNameExt = "png";

        public langtonsant_frmMain()
        {
            InitializeComponent();
        }

        private void langtonsant_frmMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((this.gridBoard != null) && (Control.ModifierKeys == Keys.Control))
            {
                this.gridBoard.Scale(sender, e);
            }
        }

        private void langtonsant_frmMain_Load(object sender, EventArgs e)
        {
            InitializeGridVirtual(Path.Combine(ApplicationPath, AppDataFile));
            InitializeGridBoard();
            LoadEmbeddedImages();

            startToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
        }

        private void langtonsant_frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridVirtual.SaveGrid(Path.Combine(ApplicationPath, AppDataFile));
        }

        private void langtonsant_frmMain_Resize(object sender, EventArgs e)
        {
            this.gridBoard.Size =
                new System.Drawing.Size(this.ClientSize.Width,
                                       (this.ClientSize.Height - this.menuStrip.Height - this.statusStrip.Height));
        }

        private void InitializeGridVirtual(string dataFile)
        {
            gridVirtual = new GridVirtual();
            gridVirtual.LoadGrid(dataFile);
        }

        private void InitializeGridBoard()
        {
            this.gridBoard = new   langtonsant_GridBoard(gridVirtual);

            this.SuspendLayout();
            this.Controls.Add(this.gridBoard);
            this.gridBoard.Location =
                new System.Drawing.Point(0,
                                         this.menuStrip.Height);
            this.gridBoard.Name = "gridBoard";
            this.gridBoard.BringToFront();
            this.gridBoard.Dock = DockStyle.Fill;
            //this.gridBoard.Size =
                //new System.Drawing.Size(this.ClientSize.Width,
                                       //(this.ClientSize.Height - this.menuStrip.Height - this.statusStrip.Height));
            this.gridBoard.TabIndex = 0;
            //this.Controls.Add(this.gridBoard);
            this.ResumeLayout(false);
        }

        private void LoadEmbeddedImages()
        {
            if (gridBoard != null)
            {
                Image[] images = new Image[4];

                Stream imgStream = null;
                Assembly assembly = Assembly.GetExecutingAssembly();

                imgStream = assembly.GetManifestResourceStream("LangtonsAnt.images.Ant.North.png");
                if (imgStream != null)
                {
                    images[0] = Image.FromStream(imgStream);
                    imgStream = null;
                }
                imgStream = assembly.GetManifestResourceStream("LangtonsAnt.images.Ant.East.png");
                if (imgStream != null)
                {
                    images[1] = Image.FromStream(imgStream);
                    imgStream = null;
                }
                imgStream = assembly.GetManifestResourceStream("LangtonsAnt.images.Ant.South.png");
                if (imgStream != null)
                {
                    images[2] = Image.FromStream(imgStream);
                    imgStream = null;
                }
                imgStream = assembly.GetManifestResourceStream("LangtonsAnt.images.Ant.West.png");
                if (imgStream != null)
                {
                    images[3] = Image.FromStream(imgStream);
                    imgStream = null;
                }

                this.gridBoard.AntImages = images;
            }
        }

        #region Menu Event Handlers
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (langtonsant_frmNew _frmNew = new  langtonsant_frmNew())
            {
                if (_frmNew.ShowDialog(this) == DialogResult.OK)
                {
                    this.gridBoard.GridVirtual = new GridVirtual(_frmNew.GridSize, _frmNew.GridStyle);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.DefaultExt = ".txt";
                openFileDialog.Filter = "Text file (*.txt)|*.txt";
                openFileDialog.AddExtension = true;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Open File";
                openFileDialog.InitialDirectory = ApplicationPath;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    InitializeGridVirtual(openFileDialog.FileName);
                    this.gridBoard.GridVirtual = this.gridVirtual;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridVirtual.SaveGrid(Path.Combine(ApplicationPath, AppDataFile));
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.DefaultExt = ".txt";
                saveFileDialog.Filter = "Text file (*.txt)|*.txt";
                saveFileDialog.AddExtension = true;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Save As";
                saveFileDialog.InitialDirectory = ApplicationPath;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void screenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Bitmap bitmap = new Bitmap(this.gridBoard.Width,
                                              this.gridBoard.Height,
                                              PixelFormat.Format32bppArgb))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Point point = this.PointToScreen(this.gridBoard.Location);
                    graphics.CopyFromScreen(point, this.gridBoard.Location, this.gridBoard.ClientSize);

                    bitmap.Save(Path.Combine(ApplicationPath,
                                             screenShotFileNamePrefix +
                                             "." +
                                             Utilities.IsoDateTime(DateTime.Now) +
                                             "." +
                                             screenShotFileNameExt),
                                ImageFormat.Png);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridVirtual.Start();
            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = true;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridVirtual.Stop();
            startToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridVirtual.Restart();
        }
        #endregion Menu Event Handlers

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (gridVirtual.Speed > 110)
            {
                gridVirtual.Speed = (gridVirtual.Speed - 100);
            }
            checkSpeedMenuItems();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (gridVirtual.Speed < 1010)
            {
                gridVirtual.Speed = (gridVirtual.Speed + 100);
            }
            checkSpeedMenuItems();
        }

        private void checkSpeedMenuItems()
        {
            if (gridVirtual.Speed < 1010)
            {
                toolStripMenuItem3.Enabled = true;
            }
            else
            {
                toolStripMenuItem3.Enabled = false;
            }

            if (gridVirtual.Speed > 110)
            {
                toolStripMenuItem2.Enabled = true;
            }
            else
            {
                toolStripMenuItem2.Enabled = false;
            }
        }
    

#region Copyright
/*
 * Copyright (c) 2011 Gregory L. Ables
 */
#endregion

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(langtonsant_frmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.screenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.speedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // menuStrip
            //
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(645, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            //
            // fileToolStripMenuItem
            //
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator4,
            this.screenshotToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            //
            // newToolStripMenuItem
            //
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            //
            // openToolStripMenuItem
            //
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
            //
            // saveToolStripMenuItem
            //
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            //
            // saveAsToolStripMenuItem
            //
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            //
            // toolStripSeparator4
            //
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(129, 6);
            //
            // screenshotToolStripMenuItem
            //
            this.screenshotToolStripMenuItem.Name = "screenshotToolStripMenuItem";
            this.screenshotToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.screenshotToolStripMenuItem.Text = "Screenshot";
            this.screenshotToolStripMenuItem.Click += new System.EventHandler(this.screenshotToolStripMenuItem_Click);
            //
            // toolStripSeparator2
            //
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(129, 6);
            //
            // exitToolStripMenuItem
            //
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            //
            // editToolStripMenuItem
            //
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator3,
            this.restartToolStripMenuItem,
            this.toolStripSeparator5,
            this.speedToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            //
            // startToolStripMenuItem
            //
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            //
            // stopToolStripMenuItem
            //
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            //
            // toolStripSeparator3
            //
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            //
            // restartToolStripMenuItem
            //
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            //
            // statusStrip
            //
            this.statusStrip.Location = new System.Drawing.Point(0, 515);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(645, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            //
            // toolStripSeparator5
            //
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            //
            // speedToolStripMenuItem
            //
            this.speedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.speedToolStripMenuItem.Name = "speedToolStripMenuItem";
            this.speedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.speedToolStripMenuItem.Text = "Speed";
            //
            // toolStripMenuItem2
            //
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "+100";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            //
            // toolStripMenuItem3
            //
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "-100";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            //
            // langtonsant_frmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(645, 537);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "langtonsant_frmMain";
            this.Text = "Langtons\'s Ant Simulator";
            this.Load += new System.EventHandler(this.langtonsant_frmMain_Load);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.langtonsant_frmMain_MouseWheel);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.langtonsant_frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.langtonsant_frmMain_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem screenshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem speedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}

