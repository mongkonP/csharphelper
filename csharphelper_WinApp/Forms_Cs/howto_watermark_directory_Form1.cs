using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

// Be sure to set these BackgroundWorker properties at design time:
//      WorkerReportsProgress = true
//      WorkerSupportsCancellation = true

 

using howto_watermark_directory;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_watermark_directory_Form1:Form
  { 


        public howto_watermark_directory_Form1()
        {
            InitializeComponent();
        }

        // The original watermark.
        private Bitmap Watermark;

        // Load the input and output directories.
        private void howto_watermark_directory_Form1_Load(object sender, EventArgs e)
        {
            txtInput.Text = Properties.Settings.Default.InputDirectory;
            txtOutput.Text = Properties.Settings.Default.OutputDirectory;
            Watermark = (Bitmap)picWatermark.Image;

            // Clear the file name label.
            lblFile.Text = "";
        }

        // Save the input and output directories.
        private void howto_watermark_directory_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.InputDirectory = txtInput.Text;
            Properties.Settings.Default.OutputDirectory = txtOutput.Text;
            Properties.Settings.Default.Save();
        }

        // Let the user pick a new watermark file.
        private void btnSelectWatermark_Click(object sender, EventArgs e)
        {
            btnSelectWatermark.Text = "";
            if (ofdWatermark.ShowDialog() == DialogResult.OK)
            {
                Watermark = new Bitmap(ofdWatermark.FileName);
                picWatermark.Image = Watermark;
            }
        }

        // Let the user select the input folder.
        private void btnInput_Click(object sender, EventArgs e)
        {
            fbdDirectory.SelectedPath = txtInput.Text;
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = fbdDirectory.SelectedPath;
            }
        }

        // Let the user select the output folder.
        private void btnOutput_Click(object sender, EventArgs e)
        {
            fbdDirectory.SelectedPath = txtOutput.Text;
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = fbdDirectory.SelectedPath;
            }
        }

        // Start or stop adding watermarks.
        private void btnProcessFiles_Click(object sender, EventArgs e)
        {
            if (btnProcessFiles.Text == "Process Files")
            {
                // Launch the BackgroundWorker.
                btnProcessFiles.Text = "Stop";
                Cursor = Cursors.WaitCursor;
                bwProcessImage.RunWorkerAsync();
            }
            else
            {
                // Stop.
                btnProcessFiles.Text = "Process Files";
                bwProcessImage.CancelAsync();
            }
        }

        // Save the file with the appropriate format.
        public void SaveImage(Image image, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    image.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    image.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    image.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    image.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    image.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    image.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
            }
        }

        // Set the image's opacity.
        private Bitmap SetOpacity(Bitmap input_bm, float opacity)
        {
            // Make the new bitmap.
            Bitmap output_bm = new Bitmap(
                input_bm.Width, input_bm.Height);

            // Make an associated Grpahics object.
            using (Graphics gr = Graphics.FromImage(output_bm))
            {
                // Make a ColorMatrix with the opacity.
                ColorMatrix color_matrix = new ColorMatrix();
                color_matrix.Matrix33 = opacity;

                // Make the ImageAttributes object.
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(color_matrix,
                    ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // Draw the input biitmap onto the Graphcis object.
                Rectangle rect = new Rectangle(0, 0,
                    output_bm.Width, output_bm.Height);

                gr.DrawImage(input_bm, rect,
                    0, 0, input_bm.Width, input_bm.Height,
                    GraphicsUnit.Pixel, attributes);
            }
            return output_bm;
        }

        // Add the watermark to the files in the background.
        private int NumProcessed = 0;
        private void bwProcessImage_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get parameters.
            int file_width = int.Parse(txtImageWidth.Text);
            int file_height = int.Parse(txtImageHeight.Text);
            int wm_width = int.Parse(txtWatermarkWidth.Text);
            int wm_height = int.Parse(txtWatermarkHeight.Text);
            int xmargin = int.Parse(txtMarginX.Text);
            int ymargin = int.Parse(txtMarginY.Text);
            float opacity = float.Parse(txtOpacity.Text);

            string output_path = txtOutput.Text;
            if (!output_path.EndsWith("\\")) output_path += "\\";

            // Adjust the watermark's opacity.
            Bitmap wm = SetOpacity(Watermark, opacity);

            // Get the watermark's input rectangle.
            RectangleF source_rect = new RectangleF(
                0, 0, wm.Width, wm.Height);

            // Loop through the files.
            NumProcessed = 0;
            FileInfo[] file_infos = null;
            try
            {
                DirectoryInfo input_dir_info = new DirectoryInfo(txtInput.Text);
                file_infos = input_dir_info.GetFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                e.Cancel = true;
                return;
            }

            foreach (FileInfo input_file_info in file_infos)
            {
                string filename = Path.Combine(output_path,
                    input_file_info.Name);

                Bitmap bm = null;
                try
                {
                    // Load the input file.
                    bm = new Bitmap(input_file_info.FullName);

                    // Get the scale.
                    float xscale = file_width / (float)bm.Width;
                    float yscale = file_height / (float)bm.Height;
                    float scale = Math.Min(xscale, yscale);

                    // Make a destination rectangle so the watermark
                    // has the desired size when the image is scaled.
                    RectangleF dest_rect = new RectangleF(
                        xmargin, ymargin,
                        wm_width / scale, wm_height / scale);

                    // Draw the watermark on the image.
                    using (Graphics gr = Graphics.FromImage(bm))
                    {
                        gr.InterpolationMode =
                            InterpolationMode.HighQualityBicubic;
                        gr.DrawImage(wm, dest_rect, source_rect,
                            GraphicsUnit.Pixel);
                    }

                    // Save the result.
                    SaveImage(bm, filename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Skipped {0}. {1}",
                        input_file_info.Name, ex.Message);
                }

                // Show progress.
                NumProcessed++;
                int percent_complete =
                    (100 * NumProcessed) / file_infos.Length;
                Progress progress = new Progress(bm, filename);
                bwProcessImage.ReportProgress(
                    percent_complete, progress);

                // See if we should cancel.
                if (bwProcessImage.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        // Update the progress bar.
        private void bwProcessImage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgFiles.Value = e.ProgressPercentage;
            Progress progress = (Progress)e.UserState;
            lblFile.Text = progress.Filename;
            picWatermark.Image = progress.Image;
            picWatermark.Refresh();
            Console.WriteLine("Saved file " + progress.Filename);
        }

        // Clean up.
        private void bwProcessImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            prgFiles.Value = 0;
            lblFile.Text = "";
            picWatermark.Image = Watermark;
            Cursor = Cursors.Default;
            MessageBox.Show("Processed " +
                NumProcessed.ToString() + " files");
            btnProcessFiles.Text = "Process Files";
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtImageWidth = new System.Windows.Forms.TextBox();
            this.txtImageHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWatermarkHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWatermarkWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ofdWatermark = new System.Windows.Forms.OpenFileDialog();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.btnProcessFiles = new System.Windows.Forms.Button();
            this.txtMarginY = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMarginX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtOpacity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bwProcessImage = new System.ComponentModel.BackgroundWorker();
            this.prgFiles = new System.Windows.Forms.ProgressBar();
            this.btnSelectWatermark = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.picWatermark = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWatermark)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Target Image Size:";
            // 
            // txtImageWidth
            // 
            this.txtImageWidth.Location = new System.Drawing.Point(137, 64);
            this.txtImageWidth.Name = "txtImageWidth";
            this.txtImageWidth.Size = new System.Drawing.Size(48, 20);
            this.txtImageWidth.TabIndex = 4;
            this.txtImageWidth.Text = "1600";
            this.txtImageWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImageHeight
            // 
            this.txtImageHeight.Location = new System.Drawing.Point(206, 64);
            this.txtImageHeight.Name = "txtImageHeight";
            this.txtImageHeight.Size = new System.Drawing.Size(48, 20);
            this.txtImageHeight.TabIndex = 5;
            this.txtImageHeight.Text = "900";
            this.txtImageHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "x";
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(137, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(298, 20);
            this.txtInput.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Input Directory:";
            // 
            // txtWatermarkHeight
            // 
            this.txtWatermarkHeight.Location = new System.Drawing.Point(206, 90);
            this.txtWatermarkHeight.Name = "txtWatermarkHeight";
            this.txtWatermarkHeight.Size = new System.Drawing.Size(48, 20);
            this.txtWatermarkHeight.TabIndex = 7;
            this.txtWatermarkHeight.Text = "200";
            this.txtWatermarkHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "x";
            // 
            // txtWatermarkWidth
            // 
            this.txtWatermarkWidth.Location = new System.Drawing.Point(137, 90);
            this.txtWatermarkWidth.Name = "txtWatermarkWidth";
            this.txtWatermarkWidth.Size = new System.Drawing.Size(48, 20);
            this.txtWatermarkWidth.TabIndex = 6;
            this.txtWatermarkWidth.Text = "200";
            this.txtWatermarkWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Target Watermark Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Watermark:";
            // 
            // ofdWatermark
            // 
            this.ofdWatermark.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(137, 38);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(298, 20);
            this.txtOutput.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Outout Directory:";
            // 
            // btnProcessFiles
            // 
            this.btnProcessFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessFiles.Location = new System.Drawing.Point(396, 64);
            this.btnProcessFiles.Name = "btnProcessFiles";
            this.btnProcessFiles.Size = new System.Drawing.Size(75, 46);
            this.btnProcessFiles.TabIndex = 8;
            this.btnProcessFiles.Text = "Process Files";
            this.btnProcessFiles.UseVisualStyleBackColor = true;
            this.btnProcessFiles.Click += new System.EventHandler(this.btnProcessFiles_Click);
            // 
            // txtMarginY
            // 
            this.txtMarginY.Location = new System.Drawing.Point(206, 116);
            this.txtMarginY.Name = "txtMarginY";
            this.txtMarginY.Size = new System.Drawing.Size(48, 20);
            this.txtMarginY.TabIndex = 18;
            this.txtMarginY.Text = "10";
            this.txtMarginY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(191, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "x";
            // 
            // txtMarginX
            // 
            this.txtMarginX.Location = new System.Drawing.Point(137, 116);
            this.txtMarginX.Name = "txtMarginX";
            this.txtMarginX.Size = new System.Drawing.Size(48, 20);
            this.txtMarginX.TabIndex = 17;
            this.txtMarginX.Text = "10";
            this.txtMarginX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Margin:";
            // 
            // lblFile
            // 
            this.lblFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 400);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(23, 13);
            this.lblFile.TabIndex = 21;
            this.lblFile.Text = "File";
            // 
            // txtOpacity
            // 
            this.txtOpacity.Location = new System.Drawing.Point(137, 142);
            this.txtOpacity.Name = "txtOpacity";
            this.txtOpacity.Size = new System.Drawing.Size(48, 20);
            this.txtOpacity.TabIndex = 22;
            this.txtOpacity.Text = "1.0";
            this.txtOpacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Opacity:";
            // 
            // bwProcessImage
            // 
            this.bwProcessImage.WorkerReportsProgress = true;
            this.bwProcessImage.WorkerSupportsCancellation = true;
            this.bwProcessImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwProcessImage_DoWork);
            this.bwProcessImage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwProcessImage_RunWorkerCompleted);
            this.bwProcessImage.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwProcessImage_ProgressChanged);
            // 
            // prgFiles
            // 
            this.prgFiles.Location = new System.Drawing.Point(15, 377);
            this.prgFiles.Name = "prgFiles";
            this.prgFiles.Size = new System.Drawing.Size(456, 20);
            this.prgFiles.TabIndex = 25;
            // 
            // btnSelectWatermark
            // 
            this.btnSelectWatermark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectWatermark.Image = Properties.Resources.EllipsisTransparent;
            this.btnSelectWatermark.Location = new System.Drawing.Point(80, 167);
            this.btnSelectWatermark.Name = "btnSelectWatermark";
            this.btnSelectWatermark.Size = new System.Drawing.Size(30, 20);
            this.btnSelectWatermark.TabIndex = 26;
            this.btnSelectWatermark.UseVisualStyleBackColor = true;
            this.btnSelectWatermark.Click += new System.EventHandler(this.btnSelectWatermark_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutput.Image = Properties.Resources.EllipsisTransparent;
            this.btnOutput.Location = new System.Drawing.Point(441, 38);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(30, 20);
            this.btnOutput.TabIndex = 3;
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnInput
            // 
            this.btnInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInput.Image = Properties.Resources.EllipsisTransparent;
            this.btnInput.Location = new System.Drawing.Point(441, 12);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(30, 20);
            this.btnInput.TabIndex = 1;
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // picWatermark
            // 
            this.picWatermark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picWatermark.BackColor = System.Drawing.Color.White;
            this.picWatermark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picWatermark.Image = Properties.Resources.logo;
            this.picWatermark.Location = new System.Drawing.Point(14, 193);
            this.picWatermark.Name = "picWatermark";
            this.picWatermark.Size = new System.Drawing.Size(457, 178);
            this.picWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWatermark.TabIndex = 15;
            this.picWatermark.TabStop = false;
            // 
            // howto_watermark_directory_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 422);
            this.Controls.Add(this.btnSelectWatermark);
            this.Controls.Add(this.prgFiles);
            this.Controls.Add(this.txtOpacity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtMarginY);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMarginX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnProcessFiles);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picWatermark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWatermarkHeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtWatermarkWidth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtImageHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtImageWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label3);
            this.MinimumSize = new System.Drawing.Size(400, 380);
            this.Name = "howto_watermark_directory_Form1";
            this.Text = "howto_watermark_directory";
            this.Load += new System.EventHandler(this.howto_watermark_directory_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_watermark_directory_Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picWatermark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImageWidth;
        private System.Windows.Forms.TextBox txtImageHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWatermarkHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWatermarkWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picWatermark;
        private System.Windows.Forms.OpenFileDialog ofdWatermark;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.Button btnProcessFiles;
        private System.Windows.Forms.TextBox txtMarginY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMarginX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtOpacity;
        private System.Windows.Forms.Label label10;
        private System.ComponentModel.BackgroundWorker bwProcessImage;
        private System.Windows.Forms.ProgressBar prgFiles;
        private System.Windows.Forms.Button btnSelectWatermark;
    }
}

