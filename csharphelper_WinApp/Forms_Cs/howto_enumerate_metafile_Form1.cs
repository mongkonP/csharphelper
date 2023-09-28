using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_enumerate_metafile_Form1:Form
  { 


        public howto_enumerate_metafile_Form1()
        {
            InitializeComponent();
        }

        private int NextRecordNumber;
        private Metafile TheMetafile;

        // Initialize the metafile name.
        private void howto_enumerate_metafile_Form1_Load(object sender, EventArgs e)
        {
            txtFileName.Text = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\..\\Epitrochoid.wmf"));
        }

        // Disable the Draw button until the user lists the metafile records.
        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            btnDraw.Enabled = false;
        }

        // Enumerate the metafile to list its records.
        private void btnEnumerate_Click(object sender, EventArgs e)
        {
            // Clear the record list.
            lstRecords.Items.Clear();

            // Clear the PictureBox.
            Bitmap bm = new Bitmap(picResults.ClientSize.Width,
                picResults.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(picResults.BackColor);
                picResults.Image = bm;
            }

            // Enumerate the metafile records.
            try
            {
                Metafile mf = new Metafile(txtFileName.Text);

                this.CreateGraphics().EnumerateMetafile(
                    mf, new PointF(0, 0),
                    ListRecords);

                btnDraw.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Add this record to the list.
        private bool ListRecords(EmfPlusRecordType record_type, int flags,
            int data_size, IntPtr data, PlayRecordCallback callback_data)
        {
            lstRecords.Items.Add(record_type.ToString());
            return true;
        }

        // Enumerate the metafile records, drawing those
        // that are NOT selected in the list.
        private void btnDraw_Click(object sender, EventArgs e)
        {
            // Start with the first record.
            NextRecordNumber = 0;

            // Make a Bitmap and Graphics to display the results.
            Bitmap bm = new Bitmap(picResults.ClientSize.Width,
                picResults.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(picResults.BackColor);

                try
                {
                    // Open the metafile.
                    TheMetafile = new Metafile(txtFileName.Text);

                    // Enumerate the records.
                    gr.EnumerateMetafile(
                        TheMetafile, new PointF(0, 0),
                        DrawRecords);

                    // Display the results.
                    picResults.Image = bm;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Draw the record if it is not selected in the list.
        private bool DrawRecords(EmfPlusRecordType record_type, int flags,
            int data_size, IntPtr data, PlayRecordCallback callback_data)
        {
            // See if this record is selected.
            if (lstRecords.SelectedIndices.Contains(NextRecordNumber))
            {
                Console.WriteLine("Skipping " + record_type.ToString());
                NextRecordNumber++;
                return true;
            }
            NextRecordNumber++;

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
            this.picResults = new System.Windows.Forms.PictureBox();
            this.lstRecords = new System.Windows.Forms.ListBox();
            this.btnEnumerate = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picResults)).BeginInit();
            this.SuspendLayout();
            // 
            // picResults
            // 
            this.picResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picResults.Location = new System.Drawing.Point(163, 40);
            this.picResults.Name = "picResults";
            this.picResults.Size = new System.Drawing.Size(375, 282);
            this.picResults.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picResults.TabIndex = 16;
            this.picResults.TabStop = false;
            // 
            // lstRecords
            // 
            this.lstRecords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstRecords.IntegralHeight = false;
            this.lstRecords.Location = new System.Drawing.Point(13, 39);
            this.lstRecords.Name = "lstRecords";
            this.lstRecords.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstRecords.Size = new System.Drawing.Size(144, 283);
            this.lstRecords.TabIndex = 15;
            // 
            // btnEnumerate
            // 
            this.btnEnumerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnumerate.Location = new System.Drawing.Point(388, 10);
            this.btnEnumerate.Name = "btnEnumerate";
            this.btnEnumerate.Size = new System.Drawing.Size(72, 23);
            this.btnEnumerate.TabIndex = 14;
            this.btnEnumerate.Text = "Enumerate";
            this.btnEnumerate.Click += new System.EventHandler(this.btnEnumerate_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(42, 13);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(340, 20);
            this.txtFileName.TabIndex = 12;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(26, 13);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "File:";
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDraw.Enabled = false;
            this.btnDraw.Location = new System.Drawing.Point(466, 11);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(72, 23);
            this.btnDraw.TabIndex = 13;
            this.btnDraw.Text = "Draw";
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // howto_enumerate_metafile_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 333);
            this.Controls.Add(this.picResults);
            this.Controls.Add(this.lstRecords);
            this.Controls.Add(this.btnEnumerate);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnDraw);
            this.Name = "howto_enumerate_metafile_Form1";
            this.Text = "howto_enumerate_metafile";
            this.Load += new System.EventHandler(this.howto_enumerate_metafile_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picResults;
        internal System.Windows.Forms.ListBox lstRecords;
        internal System.Windows.Forms.Button btnEnumerate;
        internal System.Windows.Forms.TextBox txtFileName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnDraw;
    }
}

