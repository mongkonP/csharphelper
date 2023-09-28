using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_list_exif_properties;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_exif_properties_Form1:Form
  { 


        public howto_list_exif_properties_Form1()
        {
            InitializeComponent();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                // Open the file.
                using (Bitmap bm = new Bitmap(ofdFile.FileName))
                {
                    // Get EXIF property data.
                    List<ExifStuff.ExifPropertyData> property_data
                        = ExifStuff.GetExifProperties(bm);

                    // Display the property information.
                    List<string> results = new List<string>();
                    foreach (ExifStuff.ExifPropertyData data in property_data)
                    {
                        ListViewItem item = lvwProperties.Items.Add(
                            data.PropertyType.ToString());
                        item.SubItems.Add(data.Id.ToString());
                        item.SubItems.Add(data.DataType.ToString());
                        item.SubItems.Add(data.DataLength.ToString());
                        item.SubItems.Add(data.DataString);
                    }
                }
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.lvwProperties = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colId = new System.Windows.Forms.ColumnHeader();
            this.colDataType = new System.Windows.Forms.ColumnHeader();
            this.colDataLength = new System.Windows.Forms.ColumnHeader();
            this.colValue = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(673, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen});
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
            // ofdFile
            // 
            this.ofdFile.Filter = "Picture files|*.bmp;*.jpg;*.gif;*.png;*.tif|Bitmaps|*.bmp|PNG files|*.png|JPEG fi" +
                "les|*.jpg|All Files|*.*";
            // 
            // lvwProperties
            // 
            this.lvwProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colId,
            this.colDataType,
            this.colDataLength,
            this.colValue});
            this.lvwProperties.FullRowSelect = true;
            this.lvwProperties.Location = new System.Drawing.Point(12, 27);
            this.lvwProperties.Name = "lvwProperties";
            this.lvwProperties.Size = new System.Drawing.Size(649, 222);
            this.lvwProperties.TabIndex = 1;
            this.lvwProperties.UseCompatibleStateImageBehavior = false;
            this.lvwProperties.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Property";
            this.colName.Width = 160;
            // 
            // colId
            // 
            this.colId.Text = "ID";
            this.colId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colDataType
            // 
            this.colDataType.Text = "Data Type";
            this.colDataType.Width = 170;
            // 
            // colDataLength
            // 
            this.colDataLength.Text = "Data Length";
            this.colDataLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDataLength.Width = 78;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colValue.Width = 150;
            // 
            // howto_list_exif_properties_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 261);
            this.Controls.Add(this.lvwProperties);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_list_exif_properties_Form1";
            this.Text = "howto_list_exif_properties";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.ListView lvwProperties;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colDataType;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.ColumnHeader colDataLength;
    }
}

