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

 

using howto_thumbnail_web_table;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_thumbnail_web_table_Form1:Form
  { 


        public howto_thumbnail_web_table_Form1()
        {
            InitializeComponent();
        }

        // Select default directories.
        private void howto_thumbnail_web_table_Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir_info;
            dir_info = new DirectoryInfo(
                Path.Combine(Application.StartupPath, "..\\..\\Input"));
            txtInputDir.Text = dir_info.FullName;

            dir_info = new DirectoryInfo(
                Path.Combine(Application.StartupPath, "..\\..\\Output"));
            txtOutputDir.Text = dir_info.FullName;
        }

        // Let the user select the input directory.
        private void btnPickInputDirectory_Click(object sender, EventArgs e)
        {
            fbdDirectory.SelectedPath = txtInputDir.Text;
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                txtInputDir.Text = fbdDirectory.SelectedPath;
            }
        }

        // Let the user select the output directory.
        private void btnPickOutputDirectory_Click(object sender, EventArgs e)
        {
            fbdDirectory.SelectedPath = txtOutputDir.Text;
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                txtOutputDir.Text = fbdDirectory.SelectedPath;
            }
        }

        // Make the web page and thumbnails.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get inputs.
            string input_dir = txtInputDir.Text;
            if (!input_dir.EndsWith("\\")) input_dir += "\\";
            string output_dir = txtOutputDir.Text;
            if (!output_dir.EndsWith("\\")) output_dir += "\\";
            string url_prefix = txtUrlPrefix.Text;
            if ((url_prefix.Length > 0) && (!url_prefix.EndsWith("/"))) url_prefix += "/";
            int thumb_width = int.Parse(txtThumbWidth.Text);
            int thumb_height = int.Parse(txtThumbHeight.Text);

            // Do the work.
            MakeWebPage(input_dir, output_dir, url_prefix,
                txtWebPage.Text, thumb_width, thumb_height);
        }

        // Make the web page and thumbnails.
        private void MakeWebPage(string input_dir, string output_dir, string url_prefix, string web_page, int thumb_width, int thumb_height)
        {
            // Open the HTML file.
            string html_filename = output_dir + web_page;
            using (StreamWriter html_file = new StreamWriter(html_filename))
            {
                // Start the table.
                html_file.WriteLine("<table width=\"100%\" border=\"1\">");

                // Start the table's first row.
                html_file.WriteLine("  <tr>");

                // Keep track of the number of images in a row.
                const int thumbs_per_row = 4;
                int thumbs_this_row = 0;

                // Make a list of the image files.
                List<string> files =
                    FindFiles(input_dir, "*.bmp;*.gif;*.jpg;*.png;*.tif", false);

                // Process the files.
                foreach (string image_filename in files)
                {
                    // Copy the file to the destination directory.
                    FileInfo image_fileinfo = new FileInfo(image_filename);
                    string dest_filename = output_dir + image_fileinfo.Name;
                    File.Copy(image_filename, dest_filename, true);

                    // Get the image.
                    using (Bitmap bm = new Bitmap(image_filename))
                    {
                        // Get the original size.
                        Rectangle src_rect =
                            new Rectangle(0, 0, bm.Width, bm.Height);

                        // Shrink the image.
                        double scale = Math.Min(
                            (double)thumb_width / bm.Width,
                            (double)thumb_height / bm.Height);
                        int shrunk_width = (int)(bm.Width * scale);
                        int shrunk_height = (int)(bm.Height * scale);
                        Rectangle dest_rect =
                            new Rectangle(0, 0, shrunk_width, shrunk_height);

                        using (Bitmap thumbnail = new Bitmap(shrunk_width, shrunk_height))
                        {
                            // Copy the image at reduced scale.
                            using (Graphics gr = Graphics.FromImage(thumbnail))
                            {
                                gr.DrawImage(bm, dest_rect, src_rect, GraphicsUnit.Pixel);
                            }

                            // Save the thumbnail image.
                            string thumb_filename =
                                dest_filename.Substring(0,
                                    dest_filename.Length - image_fileinfo.Extension.Length) +
                                "_thumb.png";
                            thumbnail.Save(thumb_filename, ImageFormat.Png);

                            // Add the thumbnail image to the HTML page.
                            FileInfo thumb_fileinfo = new FileInfo(thumb_filename);

                            // See if we need to start a new row.
                            if (++thumbs_this_row > thumbs_per_row)
                            {
                                thumbs_this_row = 1;
                                html_file.WriteLine("  </tr>");
                                html_file.WriteLine("  <tr>");
                            }

                            // Add the thumbnail, the file's name, and its size.
                            html_file.WriteLine("    <td align=\"center\">");
                            html_file.WriteLine("      " +
                                "<a href=\"" + url_prefix + image_fileinfo.Name + "\">" +
                                "<img src=\"" + url_prefix + thumb_fileinfo.Name + "\">" +
                                "</a>");
                            html_file.WriteLine("      <br>");
                            html_file.WriteLine("      " + image_fileinfo.Name);
                            html_file.WriteLine("      <br>");
                            html_file.WriteLine("      (" +
                                image_fileinfo.Length.ToFileSizeApi() + ")");
                            html_file.WriteLine("    </td>");
                        } // using (Bitmap thumbnail = new Bitmap(shrunk_width, shrunk_height))
                    } // using (Bitmap bm = new Bitmap(image_file))
                } // foreach (string image_file in files)

                // End the table's final row and the table.
                html_file.WriteLine("  </tr>");
                html_file.WriteLine("</table>");

                // Close the HTML file.
                html_file.Close();

                MessageBox.Show("Processed " + files.Count + " images.");
            } // using (StreamWriter html_file = new StreamWriter(html_filename))
        } // MakeWebPage

        // Search for files matching the patterns.
        private List<string> FindFiles(string dir_name, string patterns, bool search_subdirectories)
        {
            // Make the result list.
            List<string> files = new List<string>();

            // Get the patterns.
            string[] pattern_array = patterns.Split(';');

            // Search.
            SearchOption search_option = SearchOption.TopDirectoryOnly;
            if (search_subdirectories) search_option = SearchOption.AllDirectories;
            foreach (string pattern in pattern_array)
            {
                foreach (string filename in Directory.GetFiles(dir_name, pattern, search_option))
                {
                    if (!files.Contains(filename)) files.Add(filename);
                }
            }

            // Sort.
            files.Sort();

            // Return the result.
            return files;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_thumbnail_web_table_Form1));
            this.txtUrlPrefix = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtThumbHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtThumbWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtWebPage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.btnPickOutputDirectory = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPickInputDirectory = new System.Windows.Forms.Button();
            this.txtInputDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUrlPrefix
            // 
            this.txtUrlPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrlPrefix.Location = new System.Drawing.Point(105, 91);
            this.txtUrlPrefix.Name = "txtUrlPrefix";
            this.txtUrlPrefix.Size = new System.Drawing.Size(238, 20);
            this.txtUrlPrefix.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "URL Prefix:";
            // 
            // txtThumbHeight
            // 
            this.txtThumbHeight.Location = new System.Drawing.Point(105, 144);
            this.txtThumbHeight.Name = "txtThumbHeight";
            this.txtThumbHeight.Size = new System.Drawing.Size(75, 20);
            this.txtThumbHeight.TabIndex = 26;
            this.txtThumbHeight.Text = "100";
            this.txtThumbHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Thumb Height:";
            // 
            // txtThumbWidth
            // 
            this.txtThumbWidth.Location = new System.Drawing.Point(105, 117);
            this.txtThumbWidth.Name = "txtThumbWidth";
            this.txtThumbWidth.Size = new System.Drawing.Size(75, 20);
            this.txtThumbWidth.TabIndex = 25;
            this.txtThumbWidth.Text = "100";
            this.txtThumbWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Thumb Width:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(215, 129);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 28;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtWebPage
            // 
            this.txtWebPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebPage.Location = new System.Drawing.Point(105, 65);
            this.txtWebPage.Name = "txtWebPage";
            this.txtWebPage.Size = new System.Drawing.Size(238, 20);
            this.txtWebPage.TabIndex = 23;
            this.txtWebPage.Text = "Pictures.html";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Web Page:";
            // 
            // btnPickOutputDirectory
            // 
            this.btnPickOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickOutputDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickOutputDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnPickOutputDirectory.Image")));
            this.btnPickOutputDirectory.Location = new System.Drawing.Point(349, 36);
            this.btnPickOutputDirectory.Name = "btnPickOutputDirectory";
            this.btnPickOutputDirectory.Size = new System.Drawing.Size(23, 23);
            this.btnPickOutputDirectory.TabIndex = 22;
            this.btnPickOutputDirectory.UseVisualStyleBackColor = true;
            this.btnPickOutputDirectory.Click += new System.EventHandler(this.btnPickOutputDirectory_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputDir.Location = new System.Drawing.Point(105, 38);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(238, 20);
            this.txtOutputDir.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Output Directory:";
            // 
            // btnPickInputDirectory
            // 
            this.btnPickInputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickInputDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickInputDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnPickInputDirectory.Image")));
            this.btnPickInputDirectory.Location = new System.Drawing.Point(349, 10);
            this.btnPickInputDirectory.Name = "btnPickInputDirectory";
            this.btnPickInputDirectory.Size = new System.Drawing.Size(23, 23);
            this.btnPickInputDirectory.TabIndex = 20;
            this.btnPickInputDirectory.UseVisualStyleBackColor = true;
            this.btnPickInputDirectory.Click += new System.EventHandler(this.btnPickInputDirectory_Click);
            // 
            // txtInputDir
            // 
            this.txtInputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputDir.Location = new System.Drawing.Point(105, 12);
            this.txtInputDir.Name = "txtInputDir";
            this.txtInputDir.Size = new System.Drawing.Size(238, 20);
            this.txtInputDir.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Input Directory:";
            // 
            // howto_thumbnail_web_table_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 175);
            this.Controls.Add(this.txtUrlPrefix);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtThumbHeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtThumbWidth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtWebPage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPickOutputDirectory);
            this.Controls.Add(this.txtOutputDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPickInputDirectory);
            this.Controls.Add(this.txtInputDir);
            this.Controls.Add(this.label1);
            this.Name = "howto_thumbnail_web_table_Form1";
            this.Text = "howto_thumbnail_web_table";
            this.Load += new System.EventHandler(this.howto_thumbnail_web_table_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrlPrefix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtThumbHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtThumbWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtWebPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.Button btnPickOutputDirectory;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPickInputDirectory;
        private System.Windows.Forms.TextBox txtInputDir;
        private System.Windows.Forms.Label label1;
    }
}

