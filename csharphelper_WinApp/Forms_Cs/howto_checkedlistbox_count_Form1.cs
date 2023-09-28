using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_checkedlistbox_count_Form1:Form
  { 


        public howto_checkedlistbox_count_Form1()
        {
            InitializeComponent();
        }

        // List the files in the startup directory.
        private void howto_checkedlistbox_count_Form1_Load(object sender, EventArgs e)
        {
            // list the files.
            DirectoryInfo dir_info = new DirectoryInfo(Application.StartupPath);
            foreach (FileInfo file_info in dir_info.GetFiles())
                clbFiles.Items.Add(file_info.Name);

            // Display the count.
            lblCount.Text = clbFiles.Items.Count + " items, 0 selected";

            // Check items when the user clicks on them.
            clbFiles.CheckOnClick = true;
        }

        // Update the display of files checked.
        private void clbFiles_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Get the current number checked.
            int num_checked = clbFiles.CheckedItems.Count;

            // See if the item is being checked or unchecked.
            if ((e.CurrentValue != CheckState.Checked) &&
                (e.NewValue == CheckState.Checked))
                num_checked++;
            if ((e.CurrentValue == CheckState.Checked) &&
                (e.NewValue != CheckState.Checked))
                num_checked--;

            // Display the count.
            lblCount.Text = clbFiles.Items.Count + " items, " +
                num_checked + " selected";
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
            this.lblCount = new System.Windows.Forms.Label();
            this.clbFiles = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCount.Location = new System.Drawing.Point(12, 128);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(310, 23);
            this.lblCount.TabIndex = 3;
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clbFiles
            // 
            this.clbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbFiles.FormattingEnabled = true;
            this.clbFiles.IntegralHeight = false;
            this.clbFiles.Location = new System.Drawing.Point(12, 11);
            this.clbFiles.Name = "clbFiles";
            this.clbFiles.Size = new System.Drawing.Size(310, 111);
            this.clbFiles.TabIndex = 2;
            this.clbFiles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbFiles_ItemCheck);
            // 
            // howto_checkedlistbox_count_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.clbFiles);
            this.Name = "howto_checkedlistbox_count_Form1";
            this.Text = "howto_checkedlistbox_count";
            this.Load += new System.EventHandler(this.howto_checkedlistbox_count_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.CheckedListBox clbFiles;
    }
}

