using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_print_files_Form1:Form
  { 


        public howto_print_files_Form1()
        {
            InitializeComponent();
        }

        // Populate the list of printers.
        private void howto_print_files_Form1_Load(object sender, EventArgs e)
        {
            // Find all of the installed printers.
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cboPrinter.Items.Add(printer);
            }

            // Find and select the default printer.
            try
            {
                PrinterSettings settings = new PrinterSettings();
                cboPrinter.Text = settings.PrinterName;
            }
            catch
            {
            }

            // Start in the project directory.
            string file_path = Application.StartupPath;
            if (file_path.EndsWith(@"\bin\Debug"))
                file_path = file_path.Substring(0, file_path.Length - 10);
            if (file_path.EndsWith(@"\bin\Release"))
                file_path = file_path.Substring(0, file_path.Length - 12);
            if (!file_path.EndsWith(@"\")) file_path += @"\";
            txtDirectory.Text = file_path;

            // Check items when the user clicks on them.
            clbFiles.CheckOnClick = true;
        }

        // Let the user select the start directory.
        private void btnSelectDirectory_Click(object sender, EventArgs e)
        {
            fbdPath.SelectedPath = txtDirectory.Text;
            if (fbdPath.ShowDialog() == DialogResult.OK)
                txtDirectory.Text = fbdPath.SelectedPath;
        }

        // List matching files.
        private void btnListFiles_Click(object sender, EventArgs e)
        {
            clbFiles.Items.Clear();
            try
            {
                // See if we should search subdirectories.
                SearchOption search_option = SearchOption.TopDirectoryOnly;
                if (chkIncludeSubdirectories.Checked)
                    search_option = SearchOption.AllDirectories;

                // Search for files matching the pattern.
                DirectoryInfo dir_info = new DirectoryInfo(txtDirectory.Text);
                foreach (FileInfo file_info in dir_info.GetFiles(
                    txtPattern.Text, search_option))
                {
                    int index = clbFiles.Items.Add(file_info.FullName);
                    clbFiles.SetItemChecked(index, true);
                }
                lblNumFiles.Text = clbFiles.Items.Count + " files, " +
                    clbFiles.Items.Count + " selected";
                btnPrint.Enabled = clbFiles.CheckedIndices.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Disable the Print button.
        private void txtDirectory_TextChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
        }

        // Update the number of files selected.
        private void clstFiles_ItemCheck(object sender, ItemCheckEventArgs e)
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
            lblNumFiles.Text = clbFiles.Items.Count + " items, " +
                num_checked + " selected";

            // Enable the Print button if appropriate.
            btnPrint.Enabled = num_checked > 0;
        }

        // Print the selected files.
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Select the desired printer.
            pdocFile.PrinterSettings.PrinterName = cboPrinter.Text;

            // Print the checked files.
            foreach (string filename in clbFiles.CheckedItems)
            {
                Console.WriteLine("Printing: " + filename);

                // Get the file's name without the path.
                FileInfo file_into = new FileInfo(filename);
                string short_name = file_into.Name;

                // Set the PrintDocument's name for use by the printer queue.
                pdocFile.DocumentName = short_name;

                // Read the file's contents.
                try
                {
                    FileContents = File.ReadAllText(filename).Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file " + filename +
                        ".\n" + ex.Message);
                    return;
                }

                // Print.
                pdocFile.Print();
            }

            MessageBox.Show("Spooled " + clbFiles.CheckedItems.Count +
                " files for printing.");
        }

        // The text contained in the file that we are printing.
        private string FileContents;

        // Print a page of the text file.
        private void pdocTextFile_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Make a font for printing.
            using (Font font = new Font("Courier New", 10))
            {
                // Make a StringFormat to align text normally.
                using (StringFormat string_format = new StringFormat())
                {
                    // See how much of the remaining text will fit.
                    SizeF layout_area = new SizeF(
                        e.MarginBounds.Width, e.MarginBounds.Height);
                    int chars_fitted, lines_filled;
                    e.Graphics.MeasureString(FileContents, font,
                        layout_area, string_format,
                        out chars_fitted, out lines_filled);

                    // Print as much as will fit.
                    e.Graphics.DrawString(
                        FileContents.Substring(0, chars_fitted),
                        font, Brushes.Black, e.MarginBounds,
                        string_format);

                    // Remove the printed text from the string.
                    FileContents = FileContents.Substring(chars_fitted).Trim();
                }
            }

            // See if we are done.
            e.HasMorePages = FileContents.Length > 0;
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
            this.lblNumFiles = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.fbdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.chkIncludeSubdirectories = new System.Windows.Forms.CheckBox();
            this.btnSelectDirectory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPrinter = new System.Windows.Forms.ComboBox();
            this.pdocFile = new System.Drawing.Printing.PrintDocument();
            this.clbFiles = new System.Windows.Forms.CheckedListBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnListFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNumFiles
            // 
            this.lblNumFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumFiles.Location = new System.Drawing.Point(15, 270);
            this.lblNumFiles.Name = "lblNumFiles";
            this.lblNumFiles.Size = new System.Drawing.Size(257, 19);
            this.lblNumFiles.TabIndex = 31;
            this.lblNumFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 39);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(170, 20);
            this.txtDirectory.TabIndex = 21;
            this.txtDirectory.TextChanged += new System.EventHandler(this.txtDirectory_TextChanged);
            // 
            // chkIncludeSubdirectories
            // 
            this.chkIncludeSubdirectories.AutoSize = true;
            this.chkIncludeSubdirectories.Location = new System.Drawing.Point(70, 91);
            this.chkIncludeSubdirectories.Name = "chkIncludeSubdirectories";
            this.chkIncludeSubdirectories.Size = new System.Drawing.Size(131, 17);
            this.chkIncludeSubdirectories.TabIndex = 30;
            this.chkIncludeSubdirectories.Text = "Include Subdirectories";
            this.chkIncludeSubdirectories.UseVisualStyleBackColor = true;
            // 
            // btnSelectDirectory
            // 
            this.btnSelectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDirectory.Image = Properties.Resources.Ellipsis;
            this.btnSelectDirectory.Location = new System.Drawing.Point(246, 37);
            this.btnSelectDirectory.Name = "btnSelectDirectory";
            this.btnSelectDirectory.Size = new System.Drawing.Size(26, 23);
            this.btnSelectDirectory.TabIndex = 29;
            this.btnSelectDirectory.TabStop = false;
            this.btnSelectDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Directory;";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Printer:";
            // 
            // cboPrinter
            // 
            this.cboPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinter.FormattingEnabled = true;
            this.cboPrinter.Location = new System.Drawing.Point(70, 12);
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.Size = new System.Drawing.Size(202, 21);
            this.cboPrinter.TabIndex = 20;
            // 
            // pdocFile
            // 
            this.pdocFile.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocTextFile_PrintPage);
            // 
            // clbFiles
            // 
            this.clbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbFiles.FormattingEnabled = true;
            this.clbFiles.HorizontalScrollbar = true;
            this.clbFiles.Location = new System.Drawing.Point(15, 143);
            this.clbFiles.Name = "clbFiles";
            this.clbFiles.Size = new System.Drawing.Size(257, 124);
            this.clbFiles.TabIndex = 24;
            this.clbFiles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clstFiles_ItemCheck);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(105, 292);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 25;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtPattern
            // 
            this.txtPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPattern.Location = new System.Drawing.Point(70, 65);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(202, 20);
            this.txtPattern.TabIndex = 22;
            this.txtPattern.Text = "*.cs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Pattern:";
            // 
            // btnListFiles
            // 
            this.btnListFiles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnListFiles.Location = new System.Drawing.Point(105, 114);
            this.btnListFiles.Name = "btnListFiles";
            this.btnListFiles.Size = new System.Drawing.Size(75, 23);
            this.btnListFiles.TabIndex = 23;
            this.btnListFiles.Text = "List Files";
            this.btnListFiles.UseVisualStyleBackColor = true;
            this.btnListFiles.Click += new System.EventHandler(this.btnListFiles_Click);
            // 
            // howto_print_files_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 327);
            this.Controls.Add(this.lblNumFiles);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.chkIncludeSubdirectories);
            this.Controls.Add(this.btnSelectDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboPrinter);
            this.Controls.Add(this.clbFiles);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnListFiles);
            this.Name = "howto_print_files_Form1";
            this.Text = "howto_print_files";
            this.Load += new System.EventHandler(this.howto_print_files_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumFiles;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.FolderBrowserDialog fbdPath;
        private System.Windows.Forms.CheckBox chkIncludeSubdirectories;
        private System.Windows.Forms.Button btnSelectDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPrinter;
        private System.Drawing.Printing.PrintDocument pdocFile;
        private System.Windows.Forms.CheckedListBox clbFiles;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnListFiles;
    }
}

