using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Globalization;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_make_exif_enum_Form1:Form
  { 


        public howto_make_exif_enum_Form1()
        {
            InitializeComponent();
        }

        // Holds an EXIF property value's name and ID.
        private Dictionary<short, string> Ids;

        // Process the enum data.
        private void btnProcess_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            Ids = new Dictionary<short, string>();

            // Process the ID data files.
            // https://msdn.microsoft.com/de-de/library/ms534416.aspx
            ProcessIdFile("data_microsoft.txt", new char[] { ' ' }, 0, 2);

            // http://www.awaresystems.be/imaging/tiff/tifftags/privateifd/exif.html
            ProcessIdFile("data_aware_systems.txt", new char[] { '\t' }, 1, 2);

            // http://www.exiv2.org/tags.html
            ProcessIdFile("data_exiv2.txt", new char[] { '\t' }, 0, 3);

            // Sort the values by ID.
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<short, string> pair
                in Ids.OrderBy(x => x.Key.ToString("x4")))
            {
                // Add this value to the result.
                string id_string = pair.Key.ToString("x4");
                string id_name = pair.Value.Replace('.', '_');
                sb.AppendLine("            " +
                    id_name + " = 0x" + id_string + ",");
            }

            // Save the resulting enum in a file.
            string result = "        public enum ExifPropertyTypes\n";
            result += "        {\n";
            result += sb.ToString();
            result += "        }\n";
            File.WriteAllText("exif_property_ids.txt", result);
        }

        // Process values from a delimited data file.
        private void ProcessIdFile(string filename,
            char[] delimiters, int id_field, int name_field)
        {
            // Get the data from the file.
            string[] data = File.ReadAllLines(filename);
            int num_used = 0;
            int num_unused = 0;
            foreach (string line in data)
            {
                string[] fields = line.Split(delimiters,
                    StringSplitOptions.RemoveEmptyEntries);

                if (fields.Length > 0)
                {
                    string id_string = fields[id_field].ToLower().Replace("0x", "");
                    short property_id = short.Parse(
                        id_string, NumberStyles.HexNumber);
                    if (Ids.ContainsKey(property_id))
                        num_unused++;
                    else
                    {
                        num_used++;
                        string property_name = fields[name_field];
                        Ids.Add(property_id, property_name);
                    }
                }
            }
            txtStatus.AppendText(filename + '\n');
            txtStatus.AppendText("    # Used: " + num_used + '\n');
            txtStatus.AppendText("    # Unused: " + num_unused + '\n');
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
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnProcess.Location = new System.Drawing.Point(117, 12);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(12, 41);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(285, 138);
            this.txtStatus.TabIndex = 1;
            // 
            // howto_make_exif_enum_Form1
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 191);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnProcess);
            this.Name = "howto_make_exif_enum_Form1";
            this.Text = "howto_make_exif_enum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtStatus;
    }
}

