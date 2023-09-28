using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;

// Add the database and the cover images to the project
// and set their "Copy to Output Directory" properties
// to "Copy if Newer."

// IMPORTANT: Do not open the database in Access or it
// may erase all of the image data.

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_save_image_in_database_Form1:Form
  { 


        public howto_save_image_in_database_Form1()
        {
            InitializeComponent();
        }

        // The database connection.
        private OleDbConnection Conn;

        // Display a list of titles.
        private void howto_save_image_in_database_Form1_Load(object sender, EventArgs e)
        {
            // Compose the database file name.
            // This assumes it's in the executable's directory.
            string db_name = Application.StartupPath + "\\Books.mdb";

            // Connect to the database
            Conn = new OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + db_name + ";" +
                "Mode=Share Deny None");

            // Get the titles.
            OleDbCommand cmd = new OleDbCommand(
                "SELECT Title FROM Books ORDER BY Title",
                Conn);
            Conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lstTitles.Items.Add(reader["Title"].ToString());
            }
            reader.Close();
            Conn.Close();
        }

        // Display information about the selected title.
        private void lstTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTitles.SelectedIndex < 0) return;
            btnSetImage.Enabled = true;

            // Make a command object to get information about the title.
            string title = lstTitles.SelectedItem.ToString().Replace("'", "''");
            OleDbCommand cmd = new OleDbCommand(
                "SELECT * FROM Books WHERE Title='" +
                title + "'",
                Conn);

            // Execute the command.
            cmd.Connection = Conn;
            Conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();

            // Display the text data.
            txtURL.Text = reader["URL"].ToString();
            txtYear.Text = reader["Year"].ToString();
            txtISBN.Text = reader["ISBN"].ToString();
            txtPages.Text = reader["Pages"].ToString();

            // Display the cover image.
            if (reader["CoverImage"] is DBNull)
            {
                picCover.Image = null;
            }
            else
            {
                Bitmap bm = BytesToImage((byte[])reader["CoverImage"]);
                picCover.Image = bm;
            }

            // Clean up.
            reader.Close();
            Conn.Close();
        }

        // Set the image for this record.
        private void btnSetImage_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Display the image.
                    Bitmap bm = new Bitmap(ofdImage.FileName);
                    picCover.Image = bm;

                    // Set the image in the database.
                    // The CoverImage field has type OLE Object.
                    string title = lstTitles.SelectedItem.ToString().Replace("'", "''");
                    OleDbCommand cmd = new OleDbCommand(
                        "UPDATE Books SET CoverImage=@Image WHERE Title='" +
                        title + "'",
                        Conn);

                    // Create a byte array holding the image.
                    byte[] image_bytes = ImageToBytes(bm, ImageFormat.Png);

                    // Add the image as a parameter.
                    OleDbParameter param = new OleDbParameter();
                    param.OleDbType = OleDbType.Binary;
                    param.ParameterName = "Image";
                    param.Value = image_bytes;
                    cmd.Parameters.Add(param);

                    // Execute the command (with no return value).
                    cmd.Connection = Conn;
                    Conn.Open();
                    cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (Conn.State != ConnectionState.Closed) Conn.Close();
                }
            }
        }

        // Convert an image into a byte array.
        private byte[] ImageToBytes(Image image, ImageFormat format)
        {
            using (MemoryStream image_stream = new MemoryStream())
            {
                image.Save(image_stream, format);
                return image_stream.ToArray();
            }
        }

        // Convert a byte array into an image.
        private Bitmap BytesToImage(byte[] bytes)
        {
            using (MemoryStream image_stream = new MemoryStream(bytes))
            {
                Bitmap bm = new Bitmap(image_stream);
                image_stream.Close();
                return bm;
            }
        }

        // Load images for all of the records.
        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            string[] titles =
            {
                "Advanced Visual Basic Techniques",
                "Beginning Database Design Solutions",
                "Bug Proofing Visual Basic",
                "Custom Controls Library",
                "Microsoft Office Programming: A Guide for Experienced Developers",
                "Prototyping with Visual Basic",
                "Ready-to-Run Delphi Algorithms",
                "Ready-to-Run Visual Basic Algorithms, Second Edition",
                "Ready-to-Run Visual Basic Code Library",
                "Stephens' C# Programming with Visual Studio 2010 24-Hour Trainer",
                "Stephens' Visual Basic Programming 24-Hour Trainer",
                "Visual Basic .NET and XML",
                "Visual Basic .NET Database Programming",
                "Visual Basic 2005 Programmer's Reference",
                "Visual Basic 2010 Programmer's Reference",
                "Visual Basic Graphics Programming, Second Edition",
                "WPF Programmer's Reference",
            };
            string[] filenames =
            {
                @"Images\avbts.jpg",
                @"Images\db_design_s.jpg",
                @"Images\errs.jpg",
                @"Images\ccls.jpg",
                @"Images\offices.jpg",
                @"Images\protos.jpg",
                @"Images\das.jpg",
                @"Images\vbas.jpg",
                @"Images\vbcls.jpg",
                @"Images\24hour_t.jpg",
                @"Images\24hourvbs.jpg",
                @"Images\xmls.jpg",
                @"Images\vbdbs.jpg",
                @"Images\vb_prog_ref_1e_s.jpg",
                @"Images\vb_prog_ref_4e_s.png",
                @"Images\vbgp_1es.jpg",
                @"Images\wpf_prog_ref_t.png",
            };

            this.Cursor = Cursors.WaitCursor;

            string image_dir = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\..")) + "\\";

            // Load the images.
            for (int i = 0; i < titles.Length; i++)
            {
                LoadRecordImage(titles[i], image_dir + filenames[i]);
            }

            this.Cursor = Cursors.Default;
            MessageBox.Show("Loaded " + titles.Length + " images.");
        }

        // Load one record's picture.
        private void LoadRecordImage(string title, string filename)
        {
            try
            {
                // Get the image.
                Bitmap bm = new Bitmap(filename);

                // Set the image in the database.
                title = title.Replace("'", "''");
                OleDbCommand cmd = new OleDbCommand(
                    "UPDATE Books SET CoverImage=@Image WHERE Title='" +
                    title + "'",
                    Conn);

                // Create a byte array holding the image.
                byte[] image_bytes = ImageToBytes(bm, ImageFormat.Png);

                // Add the image as a parameter.
                OleDbParameter param = new OleDbParameter();
                param.OleDbType = OleDbType.Binary;
                param.ParameterName = "Image";
                param.Value = image_bytes;
                cmd.Parameters.Add(param);

                // Execute the command (with no return value).
                cmd.Connection = Conn;
                Conn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
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
            this.btnLoadAll = new System.Windows.Forms.Button();
            this.btnSetImage = new System.Windows.Forms.Button();
            this.picCover = new System.Windows.Forms.PictureBox();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstTitles = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Location = new System.Drawing.Point(94, 214);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(75, 23);
            this.btnLoadAll.TabIndex = 42;
            this.btnLoadAll.Text = "Load All";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // btnSetImage
            // 
            this.btnSetImage.Enabled = false;
            this.btnSetImage.Location = new System.Drawing.Point(12, 214);
            this.btnSetImage.Name = "btnSetImage";
            this.btnSetImage.Size = new System.Drawing.Size(75, 23);
            this.btnSetImage.TabIndex = 41;
            this.btnSetImage.Text = "Set Image";
            this.btnSetImage.UseVisualStyleBackColor = true;
            this.btnSetImage.Click += new System.EventHandler(this.btnSetImage_Click);
            // 
            // picCover
            // 
            this.picCover.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCover.Location = new System.Drawing.Point(175, 126);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(268, 111);
            this.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCover.TabIndex = 40;
            this.picCover.TabStop = false;
            // 
            // ofdImage
            // 
            this.ofdImage.FileName = "openFileDialog1";
            this.ofdImage.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            // 
            // txtPages
            // 
            this.txtPages.Location = new System.Drawing.Point(58, 178);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(111, 20);
            this.txtPages.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Pages:";
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(58, 152);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(111, 20);
            this.txtISBN.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "ISBN:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(58, 126);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(111, 20);
            this.txtYear.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Year:";
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(58, 100);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(385, 20);
            this.txtURL.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "URL:";
            // 
            // lstTitles
            // 
            this.lstTitles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTitles.FormattingEnabled = true;
            this.lstTitles.Location = new System.Drawing.Point(12, 12);
            this.lstTitles.Name = "lstTitles";
            this.lstTitles.Size = new System.Drawing.Size(431, 82);
            this.lstTitles.TabIndex = 31;
            this.lstTitles.SelectedIndexChanged += new System.EventHandler(this.lstTitles_SelectedIndexChanged);
            // 
            // howto_save_image_in_database_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 249);
            this.Controls.Add(this.btnLoadAll);
            this.Controls.Add(this.btnSetImage);
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstTitles);
            this.Name = "howto_save_image_in_database_Form1";
            this.Text = "howto_save_image_in_database";
            this.Load += new System.EventHandler(this.howto_save_image_in_database_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadAll;
        private System.Windows.Forms.Button btnSetImage;
        private System.Windows.Forms.PictureBox picCover;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstTitles;
    }
}

