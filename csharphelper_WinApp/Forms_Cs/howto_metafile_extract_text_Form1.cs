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
     public partial class howto_metafile_extract_text_Form1:Form
  { 


        public howto_metafile_extract_text_Form1()
        {
            InitializeComponent();
        }

        // Initialize the metafile name.
        private void howto_metafile_extract_text_Form1_Load(object sender, EventArgs e)
        {
            txtFileName.Text = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\..\\Epitrochoid.wmf"));
        }

        // Enumerate the metafile records and look for text.
        private void btnGetStrings_Click(object sender, EventArgs e)
        {
            lstStrings.Items.Clear();
            try
            {
                // Open the metafile.
                Metafile mf = new Metafile(txtFileName.Text);

                // Enumerate the records.
                Graphics gr = this.CreateGraphics();
                gr.EnumerateMetafile(
                    mf, new PointF(0, 0),
                    RecordCallback);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Look for string records.
        private bool RecordCallback(EmfPlusRecordType record_type, int flags,
            int data_size, IntPtr data, PlayRecordCallback callback_data)
        {
            // See if it is text.
            if (record_type == EmfPlusRecordType.DrawString)
            {
                // Copy the unmanaged record data.
                byte[] data_array = null;
                data_array = new byte[data_size];
                Marshal.Copy(data, data_array, 0, data_size);

                // See how many characters are in the string.
                int num_chars = BitConverter.ToInt32(data_array, 8);

                // Get the characters.
                string txt = Encoding.Unicode.GetString(data_array, 28, 2 * num_chars);

                lstStrings.Items.Add(txt);
            }

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
            this.lstStrings = new System.Windows.Forms.ListBox();
            this.btnGetStrings = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstStrings
            // 
            this.lstStrings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStrings.IntegralHeight = false;
            this.lstStrings.Location = new System.Drawing.Point(15, 39);
            this.lstStrings.Name = "lstStrings";
            this.lstStrings.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstStrings.Size = new System.Drawing.Size(307, 66);
            this.lstStrings.TabIndex = 13;
            // 
            // btnGetStrings
            // 
            this.btnGetStrings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetStrings.Location = new System.Drawing.Point(250, 11);
            this.btnGetStrings.Name = "btnGetStrings";
            this.btnGetStrings.Size = new System.Drawing.Size(72, 23);
            this.btnGetStrings.TabIndex = 12;
            this.btnGetStrings.Text = "Get Strings";
            this.btnGetStrings.Click += new System.EventHandler(this.btnGetStrings_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(44, 13);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(200, 20);
            this.txtFileName.TabIndex = 11;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(26, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "File:";
            // 
            // howto_metafile_extract_text_Form1
            // 
            this.AcceptButton = this.btnGetStrings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 116);
            this.Controls.Add(this.lstStrings);
            this.Controls.Add(this.btnGetStrings);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.Label1);
            this.Name = "howto_metafile_extract_text_Form1";
            this.Text = "howto_metafile_extract_text";
            this.Load += new System.EventHandler(this.howto_metafile_extract_text_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListBox lstStrings;
        internal System.Windows.Forms.Button btnGetStrings;
        internal System.Windows.Forms.TextBox txtFileName;
        internal System.Windows.Forms.Label Label1;
    }
}

