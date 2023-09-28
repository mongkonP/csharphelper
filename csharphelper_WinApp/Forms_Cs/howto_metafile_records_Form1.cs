using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

// Set the "Copy to Output Directory" property for
// the image files to "Copy if Newer."

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_metafile_records_Form1:Form
  { 


        public howto_metafile_records_Form1()
        {
            InitializeComponent();
        }

        // Keep the metafile loaded.
        private Metafile TheMetafile;

        // A Graphics object used to draw on the current bitmap.
        private Graphics TheGraphics;

        // The index of the last record we drew.
        private int LastRecord;

        private void howto_metafile_records_Form1_Load(object sender, EventArgs e)
        {
            clbRecords.CheckOnClick = true;
            picResult.SizeMode = PictureBoxSizeMode.Zoom;

            // Load the metafile.
            TheMetafile = (Metafile)Metafile.FromFile("Volleyball.wmf");
            
            // Use any Graphics object to enumerate the metafile records.
            using (Graphics gr = this.CreateGraphics())
            {
                gr.EnumerateMetafile(TheMetafile, new PointF(0, 0), ListRecordCallback);
            }

            // Initially check all records.
            for (int i = 0; i < clbRecords.Items.Count; i++)
                clbRecords.SetItemChecked(i, true);

            // Display the initial result.
            DisplayRecords();
        }

        // Add a record to the metafile record ListBox.
        private bool ListRecordCallback(EmfPlusRecordType record_type, int flags,
            int data_size, IntPtr data, PlayRecordCallback callback_data)
        {
            clbRecords.Items.Add(record_type.ToString());
            return true;
        }

        // Redisplay the metafile's currently selected records.
        private void clbRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayRecords();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbRecords.Items.Count; i++)
                clbRecords.SetItemChecked(i, true);
            DisplayRecords();
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbRecords.Items.Count; i++)
                clbRecords.SetItemChecked(i, false);
            DisplayRecords();
        }

        // Draw the checked metafile records.
        private void DisplayRecords()
        {
            // Make a bitmap to hold the result.
            int wid = TheMetafile.Width;
            int hgt = TheMetafile.Height;
            Bitmap bm = new Bitmap(wid, hgt);

            // Start at the first record.
            LastRecord = -1;

            // Draw the selected records on the bitmap.
            using (TheGraphics = Graphics.FromImage(bm))
            {
                Rectangle dest = new Rectangle(0, 0, wid, hgt);
                TheGraphics.EnumerateMetafile(
                    TheMetafile, dest, DrawRecordCallback);
            }

            // Display the result.
            picResult.Image = bm;
        }

        // Draw a record on TheGraphics.
        private bool DrawRecordCallback(EmfPlusRecordType record_type, int flags,
            int data_size, IntPtr data, PlayRecordCallback callback_data)
        {
            // Consider the next record.
            LastRecord++;

            // If this record is not selected, skip it.
            if (!clbRecords.GetItemChecked(LastRecord))
            {
                Console.WriteLine("Skipping " + LastRecord +
                    ": " + record_type.ToString());
                return true;
            }

            // Display this record.
            byte[] data_array = null;
            if (!data.Equals(IntPtr.Zero))
            {
                // Copy the unmanaged record data into a managed
                // byte buffer that we can pass to PlayRecord.
                data_array = new byte[data_size];
                Marshal.Copy(data, data_array, 0, data_size);
            }

            // Play the record.
            TheMetafile.PlayRecord(record_type, flags, data_size, data_array);

            // Continue the enumeration.
            return true;
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
            this.clbRecords = new System.Windows.Forms.CheckedListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // clbRecords
            // 
            this.clbRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbRecords.FormattingEnabled = true;
            this.clbRecords.IntegralHeight = false;
            this.clbRecords.Location = new System.Drawing.Point(5, 65);
            this.clbRecords.Name = "clbRecords";
            this.clbRecords.Size = new System.Drawing.Size(178, 244);
            this.clbRecords.TabIndex = 0;
            this.clbRecords.SelectedIndexChanged += new System.EventHandler(this.clbRecords_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.picResult);
            this.splitContainer1.Size = new System.Drawing.Size(458, 314);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnCheckAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.clbRecords, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnUncheckAll, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(188, 314);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCheckAll.Location = new System.Drawing.Point(56, 5);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(75, 23);
            this.btnCheckAll.TabIndex = 1;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUncheckAll.Location = new System.Drawing.Point(56, 35);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(75, 23);
            this.btnUncheckAll.TabIndex = 2;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.UseVisualStyleBackColor = true;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // picResult
            // 
            this.picResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picResult.Location = new System.Drawing.Point(0, 0);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(266, 314);
            this.picResult.TabIndex = 0;
            this.picResult.TabStop = false;
            // 
            // howto_metafile_records_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 314);
            this.Controls.Add(this.splitContainer1);
            this.Name = "howto_metafile_records_Form1";
            this.Text = "howto_metafile_records";
            this.Load += new System.EventHandler(this.howto_metafile_records_Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbRecords;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnUncheckAll;
        private System.Windows.Forms.PictureBox picResult;
    }
}

