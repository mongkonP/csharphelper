using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

using howto_manage_recycle_bin;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_manage_recycle_bin_Form1:Form
  { 


        public howto_manage_recycle_bin_Form1()
        {
            InitializeComponent();
        }

        private void howto_manage_recycle_bin_Form1_Load(object sender, EventArgs e)
        {
            // Display the number of items in the recycle bin.
            lblNumItems.Text = Recycler.NumberOfFilesInRecycleBin().ToString() +
                " items in wastebasket";

            // Make files we can delete.
            MakeTestFiles();
        }

        // Delete the file.
        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            Recycler.DeleteFile(
                txtFile.Text,
                chkConfirmDelete.Checked,
                radDeletePermanently.Checked);
        }

        // Delete the directory.
        private void btnDeleteDirectory_Click(object sender, EventArgs e)
        {
            Recycler.DeleteDirectory(
                txtDirectory.Text,
                chkConfirmDelete.Checked,
                radDeletePermanently.Checked);
        }

        // Empty the wastebasket.
        private void btnEmpty_Click(object sender, EventArgs e)
        {
            Recycler.EmptyWastebasket(
                chkProgress.Checked, 
                chkPlaySound.Checked, 
                chkConfirmEmpty.Checked);
        }

        // Display the number of items in the recycle bin.
        private void tmrCheckBin_Tick(object sender, EventArgs e)
        {
            lblNumItems.Text = Recycler.NumberOfFilesInRecycleBin().ToString() +
                " items in wastebasket";
        }

        // Make a file and a directory that we can delete.
        private void MakeTestFiles()
        {
            // Make a file.
            string filename = Application.StartupPath + "\\Test.txt";
            if (!File.Exists(filename))
            {
                File.WriteAllText(filename, "This is a test file.");
            }
            txtFile.Text = filename;

            // Make a directory.
            string dirname = Application.StartupPath + "\\TestFiles";
            if (!Directory.Exists(dirname))
            {
                Directory.CreateDirectory(dirname);
            }
            txtDirectory.Text = dirname;

            filename = dirname + "\\Test2.txt";
            if (!File.Exists(filename))
            {
                File.WriteAllText(filename, "This is another test file.");
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
            this.lblNumItems = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.chkConfirmEmpty = new System.Windows.Forms.CheckBox();
            this.chkPlaySound = new System.Windows.Forms.CheckBox();
            this.chkProgress = new System.Windows.Forms.CheckBox();
            this.btnEmpty = new System.Windows.Forms.Button();
            this.radDeletePermanently = new System.Windows.Forms.RadioButton();
            this.radSendToWastebasket = new System.Windows.Forms.RadioButton();
            this.chkConfirmDelete = new System.Windows.Forms.CheckBox();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.tmrCheckBin = new System.Windows.Forms.Timer(this.components);
            this.txtFile = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteDirectory = new System.Windows.Forms.Button();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumItems
            // 
            this.lblNumItems.AutoSize = true;
            this.lblNumItems.Location = new System.Drawing.Point(12, 196);
            this.lblNumItems.Name = "lblNumItems";
            this.lblNumItems.Size = new System.Drawing.Size(0, 13);
            this.lblNumItems.TabIndex = 13;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.chkConfirmEmpty);
            this.GroupBox2.Controls.Add(this.chkPlaySound);
            this.GroupBox2.Controls.Add(this.chkProgress);
            this.GroupBox2.Controls.Add(this.btnEmpty);
            this.GroupBox2.Location = new System.Drawing.Point(15, 116);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(463, 77);
            this.GroupBox2.TabIndex = 12;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Empty Wastebasket";
            // 
            // chkConfirmEmpty
            // 
            this.chkConfirmEmpty.AutoSize = true;
            this.chkConfirmEmpty.Checked = true;
            this.chkConfirmEmpty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConfirmEmpty.Location = new System.Drawing.Point(281, 24);
            this.chkConfirmEmpty.Name = "chkConfirmEmpty";
            this.chkConfirmEmpty.Size = new System.Drawing.Size(61, 17);
            this.chkConfirmEmpty.TabIndex = 2;
            this.chkConfirmEmpty.Text = "Confirm";
            this.chkConfirmEmpty.UseVisualStyleBackColor = true;
            // 
            // chkPlaySound
            // 
            this.chkPlaySound.AutoSize = true;
            this.chkPlaySound.Checked = true;
            this.chkPlaySound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPlaySound.Location = new System.Drawing.Point(152, 24);
            this.chkPlaySound.Name = "chkPlaySound";
            this.chkPlaySound.Size = new System.Drawing.Size(80, 17);
            this.chkPlaySound.TabIndex = 1;
            this.chkPlaySound.Text = "Play Sound";
            this.chkPlaySound.UseVisualStyleBackColor = true;
            // 
            // chkProgress
            // 
            this.chkProgress.AutoSize = true;
            this.chkProgress.Checked = true;
            this.chkProgress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProgress.Location = new System.Drawing.Point(24, 24);
            this.chkProgress.Name = "chkProgress";
            this.chkProgress.Size = new System.Drawing.Size(97, 17);
            this.chkProgress.TabIndex = 0;
            this.chkProgress.Text = "Show Progress";
            this.chkProgress.UseVisualStyleBackColor = true;
            // 
            // btnEmpty
            // 
            this.btnEmpty.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEmpty.Location = new System.Drawing.Point(171, 47);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(120, 23);
            this.btnEmpty.TabIndex = 3;
            this.btnEmpty.Text = "Empty Wastebasket";
            this.btnEmpty.UseVisualStyleBackColor = true;
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // radDeletePermanently
            // 
            this.radDeletePermanently.AutoSize = true;
            this.radDeletePermanently.Location = new System.Drawing.Point(261, 11);
            this.radDeletePermanently.Name = "radDeletePermanently";
            this.radDeletePermanently.Size = new System.Drawing.Size(117, 17);
            this.radDeletePermanently.TabIndex = 2;
            this.radDeletePermanently.Text = "Delete Permanently";
            this.radDeletePermanently.UseVisualStyleBackColor = true;
            // 
            // radSendToWastebasket
            // 
            this.radSendToWastebasket.AutoSize = true;
            this.radSendToWastebasket.Checked = true;
            this.radSendToWastebasket.Location = new System.Drawing.Point(105, 11);
            this.radSendToWastebasket.Name = "radSendToWastebasket";
            this.radSendToWastebasket.Size = new System.Drawing.Size(128, 17);
            this.radSendToWastebasket.TabIndex = 1;
            this.radSendToWastebasket.TabStop = true;
            this.radSendToWastebasket.Text = "Send to Wastebasket";
            this.radSendToWastebasket.UseVisualStyleBackColor = true;
            // 
            // chkConfirmDelete
            // 
            this.chkConfirmDelete.AutoSize = true;
            this.chkConfirmDelete.Checked = true;
            this.chkConfirmDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConfirmDelete.Location = new System.Drawing.Point(13, 12);
            this.chkConfirmDelete.Name = "chkConfirmDelete";
            this.chkConfirmDelete.Size = new System.Drawing.Size(61, 17);
            this.chkConfirmDelete.TabIndex = 0;
            this.chkConfirmDelete.Text = "Confirm";
            this.chkConfirmDelete.UseVisualStyleBackColor = true;
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFile.Location = new System.Drawing.Point(403, 39);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFile.TabIndex = 4;
            this.btnDeleteFile.Text = "Delete";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // tmrCheckBin
            // 
            this.tmrCheckBin.Enabled = true;
            this.tmrCheckBin.Interval = 1000;
            this.tmrCheckBin.Tick += new System.EventHandler(this.tmrCheckBin_Tick);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(70, 41);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(327, 20);
            this.txtFile.TabIndex = 3;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 44);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(26, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "File:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 67);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(327, 20);
            this.txtDirectory.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Directory:";
            // 
            // btnDeleteDirectory
            // 
            this.btnDeleteDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDirectory.Location = new System.Drawing.Point(403, 65);
            this.btnDeleteDirectory.Name = "btnDeleteDirectory";
            this.btnDeleteDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDirectory.TabIndex = 6;
            this.btnDeleteDirectory.Text = "Delete";
            this.btnDeleteDirectory.UseVisualStyleBackColor = true;
            this.btnDeleteDirectory.Click += new System.EventHandler(this.btnDeleteDirectory_Click);
            // 
            // howto_manage_recycle_bin_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 220);
            this.Controls.Add(this.btnDeleteDirectory);
            this.Controls.Add(this.radDeletePermanently);
            this.Controls.Add(this.radSendToWastebasket);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.chkConfirmDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.lblNumItems);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.Label1);
            this.Name = "howto_manage_recycle_bin_Form1";
            this.Text = "howto_manage_recycle_bin";
            this.Load += new System.EventHandler(this.howto_manage_recycle_bin_Form1_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblNumItems;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.CheckBox chkConfirmEmpty;
        internal System.Windows.Forms.CheckBox chkPlaySound;
        internal System.Windows.Forms.CheckBox chkProgress;
        internal System.Windows.Forms.Button btnEmpty;
        internal System.Windows.Forms.RadioButton radDeletePermanently;
        internal System.Windows.Forms.RadioButton radSendToWastebasket;
        internal System.Windows.Forms.CheckBox chkConfirmDelete;
        internal System.Windows.Forms.Button btnDeleteFile;
        internal System.Windows.Forms.Timer tmrCheckBin;
        internal System.Windows.Forms.TextBox txtFile;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtDirectory;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteDirectory;
    }
}

