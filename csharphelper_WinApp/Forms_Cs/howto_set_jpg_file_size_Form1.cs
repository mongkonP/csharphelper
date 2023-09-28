using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_set_jpg_file_size;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_set_jpg_file_size_Form1:Form
  { 


        public howto_set_jpg_file_size_Form1()
        {
            InitializeComponent();
        }

        // A temporary file name.
        private string TempFile;

        // The image loaded from the file.
        private Image OriginalImage = null;

        private void howto_set_jpg_file_size_Form1_Load(object sender, EventArgs e)
        {
            cboCompressionLevel.Text = "75";
            TempFile = Application.StartupPath + @"\__temp.jpg";
        }

        // Open a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdPicture.ShowDialog() == DialogResult.OK)
            {
                txtOriginalSize.Clear();
                txtActualLevel.Clear();
                txtActualSize.Clear();

                try
                {
                    // Load the file.
                    OriginalImage = ImageStuff.LoadBitmap(ofdPicture.FileName);
                    picImage.Image = OriginalImage;
                    mnuFileSaveAs.Enabled = true;
                    btnGo.Enabled = true;

                    // See how big the file is.
                    txtOriginalSize.Text = ImageStuff.GetFileSize(ofdPicture.FileName).ToFileSizeApi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading file //" +
                        ofdPicture.FileName + "//\n" + ex.Message,
                        "Load Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // Save the file with the selected compression level.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (OriginalImage == null) return;

            if (sfdPicture.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (radSetCompressionLevel.Checked)
                    {
                        // Save at the indicated compression level.
                        int level = int.Parse(cboCompressionLevel.Text);
                        ImageStuff.SaveJpg(OriginalImage, sfdPicture.FileName, level);
                    }
                    else
                    {
                        // Save with the indicated maximum file size.
                        long max_size = 1024 * long.Parse(txtMaxFileSize.Text);
                        int level = ImageStuff.SaveJpgAtFileSize(OriginalImage, sfdPicture.FileName, max_size);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file //" +
                        sfdPicture.FileName + "//\n" + ex.Message,
                        "Save Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Compress the file.
        private void btnGo_Click(object sender, EventArgs e)
        {
            DateTime start_time = DateTime.Now;
            Cursor = Cursors.WaitCursor;

            if (radSetCompressionLevel.Checked)
            {
                // Save at the indicated compression level.
                int level = int.Parse(cboCompressionLevel.Text);
                ImageStuff.SaveJpg(OriginalImage, TempFile, level);
                txtActualLevel.Text = level.ToString();
            }
            else
            {
                // Save with the indicated maximum file size.
                long max_size = 1024 * long.Parse(txtMaxFileSize.Text);
                int level = ImageStuff.SaveJpgAtFileSize(OriginalImage, TempFile, max_size);
                txtActualLevel.Text = level.ToString();
            }

            // Display the actual size.
            txtActualSize.Text = ImageStuff.GetFileSize(TempFile).ToFileSizeApi();

            // Display the file.
            picImage.Image = ImageStuff.LoadBitmap(TempFile);

            Cursor = Cursors.Default;
            DateTime stop_time = DateTime.Now;
            TimeSpan elapsed = stop_time - start_time;
            Console.WriteLine("Level: " + txtActualLevel.Text +
                ", Size: " + txtActualSize.Text +
                ", Time: " + elapsed.TotalSeconds.ToString("0.00") + " sec");
        }

        // Select the Compression Level radio button.
        private void cboCompressionLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            radSetCompressionLevel.Checked = true;
        }

        // Select the Max File Size radio button.
        private void txtMaxFileSize_TextChanged(object sender, EventArgs e)
        {
            radSetMaxFileSize.Checked = true;
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOriginalSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtActualSize = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sfdPicture = new System.Windows.Forms.SaveFileDialog();
            this.txtActualLevel = new System.Windows.Forms.TextBox();
            this.txtMaxFileSize = new System.Windows.Forms.TextBox();
            this.cboCompressionLevel = new System.Windows.Forms.ComboBox();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.radSetMaxFileSize = new System.Windows.Forms.RadioButton();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.radSetCompressionLevel = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "New Size:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Compression Level:";
            // 
            // txtOriginalSize
            // 
            this.txtOriginalSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOriginalSize.Location = new System.Drawing.Point(438, 34);
            this.txtOriginalSize.Name = "txtOriginalSize";
            this.txtOriginalSize.ReadOnly = true;
            this.txtOriginalSize.Size = new System.Drawing.Size(55, 20);
            this.txtOriginalSize.TabIndex = 43;
            this.txtOriginalSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Original Size:";
            // 
            // txtActualSize
            // 
            this.txtActualSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActualSize.Location = new System.Drawing.Point(438, 87);
            this.txtActualSize.Name = "txtActualSize";
            this.txtActualSize.ReadOnly = true;
            this.txtActualSize.Size = new System.Drawing.Size(55, 20);
            this.txtActualSize.TabIndex = 45;
            this.txtActualSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(240, 56);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 42;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "kb";
            // 
            // sfdPicture
            // 
            this.sfdPicture.Filter = " Graphic Files|*.bmp,*.gif,*.jpg,*.jpeg,*.png,*.tif,*.tiff|All Files|*.*";
            // 
            // txtActualLevel
            // 
            this.txtActualLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActualLevel.Location = new System.Drawing.Point(438, 60);
            this.txtActualLevel.Name = "txtActualLevel";
            this.txtActualLevel.ReadOnly = true;
            this.txtActualLevel.Size = new System.Drawing.Size(55, 20);
            this.txtActualLevel.TabIndex = 44;
            this.txtActualLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaxFileSize
            // 
            this.txtMaxFileSize.Location = new System.Drawing.Point(154, 71);
            this.txtMaxFileSize.Name = "txtMaxFileSize";
            this.txtMaxFileSize.Size = new System.Drawing.Size(55, 20);
            this.txtMaxFileSize.TabIndex = 41;
            this.txtMaxFileSize.Text = "1000";
            this.txtMaxFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaxFileSize.TextChanged += new System.EventHandler(this.txtMaxFileSize_TextChanged);
            // 
            // cboCompressionLevel
            // 
            this.cboCompressionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompressionLevel.FormattingEnabled = true;
            this.cboCompressionLevel.Items.AddRange(new object[] {
            "100",
            "95",
            "90",
            "85",
            "80",
            "75",
            "70",
            "65",
            "60",
            "55",
            "50",
            "45",
            "40",
            "35",
            "30",
            "25",
            "20",
            "15",
            "10",
            "5"});
            this.cboCompressionLevel.Location = new System.Drawing.Point(154, 44);
            this.cboCompressionLevel.Name = "cboCompressionLevel";
            this.cboCompressionLevel.Size = new System.Drawing.Size(55, 21);
            this.cboCompressionLevel.TabIndex = 40;
            this.cboCompressionLevel.SelectedIndexChanged += new System.EventHandler(this.cboCompressionLevel_SelectedIndexChanged);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(163, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // radSetMaxFileSize
            // 
            this.radSetMaxFileSize.AutoSize = true;
            this.radSetMaxFileSize.Location = new System.Drawing.Point(12, 72);
            this.radSetMaxFileSize.Name = "radSetMaxFileSize";
            this.radSetMaxFileSize.Size = new System.Drawing.Size(109, 17);
            this.radSetMaxFileSize.TabIndex = 50;
            this.radSetMaxFileSize.Text = "Set Max File Size:";
            this.radSetMaxFileSize.UseVisualStyleBackColor = true;
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Enabled = false;
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(163, 22);
            this.mnuFileSaveAs.Text = "&Save As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSaveAs,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
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
            // ofdPicture
            // 
            this.ofdPicture.Filter = "Graphic Files|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif;*.tiff|All Files|*.*";
            // 
            // radSetCompressionLevel
            // 
            this.radSetCompressionLevel.AutoSize = true;
            this.radSetCompressionLevel.Checked = true;
            this.radSetCompressionLevel.Location = new System.Drawing.Point(12, 45);
            this.radSetCompressionLevel.Name = "radSetCompressionLevel";
            this.radSetCompressionLevel.Size = new System.Drawing.Size(136, 17);
            this.radSetCompressionLevel.TabIndex = 49;
            this.radSetCompressionLevel.TabStop = true;
            this.radSetCompressionLevel.Text = "Set Compression Level:";
            this.radSetCompressionLevel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picImage);
            this.panel1.Location = new System.Drawing.Point(12, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 254);
            this.panel1.TabIndex = 46;
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(62, 54);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 19;
            this.picImage.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(505, 24);
            this.menuStrip1.TabIndex = 47;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // howto_set_jpg_file_size_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 375);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOriginalSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtActualSize);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtActualLevel);
            this.Controls.Add(this.txtMaxFileSize);
            this.Controls.Add(this.cboCompressionLevel);
            this.Controls.Add(this.radSetMaxFileSize);
            this.Controls.Add(this.radSetCompressionLevel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_set_jpg_file_size_Form1";
            this.Text = "howto_set_jpg_file_size";
            this.Load += new System.EventHandler(this.howto_set_jpg_file_size_Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOriginalSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtActualSize;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog sfdPicture;
        private System.Windows.Forms.TextBox txtActualLevel;
        private System.Windows.Forms.TextBox txtMaxFileSize;
        private System.Windows.Forms.ComboBox cboCompressionLevel;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.RadioButton radSetMaxFileSize;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdPicture;
        private System.Windows.Forms.RadioButton radSetCompressionLevel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
    }
}

