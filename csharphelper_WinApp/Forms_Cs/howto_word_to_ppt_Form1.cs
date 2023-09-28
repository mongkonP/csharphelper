using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Open the Add References dialog and on the .NET tab add references to:
//      Microsoft.Office.Interop.PowerPoint
//      Microsoft.Office.Interop.Word
//      Office
using Word = Microsoft.Office.Interop.Word;
using Ppt = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_word_to_ppt_Form1:Form
  { 


        public howto_word_to_ppt_Form1()
        {
            InitializeComponent();
        }

        // Initialize the file names.
        private void howto_word_to_ppt_Form1_Load(object sender, EventArgs e)
        {
            string path = System.Windows.Forms.Application.StartupPath;
            txtWordFile.Text = path + @"\Test.docx";
            txtPowerPointFile.Text = path + @"\Test.ppt";
        }

        // Create the PowerPoint presentation.
        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Get the information we need from the Word file.
                string title;
                List<string> headings;
                GetWordData(txtWordFile.Text, txtTitleStyle.Text,
                    txtHeadingStyle.Text,
                    out title, out headings);

                if (title == "")
                {
                    MessageBox.Show("Could not find title style '" + txtTitleStyle.Text + "'");
                    return;
                }
                if (headings.Count == 0)
                {
                    MessageBox.Show("Could not find heading style '" + txtHeadingStyle.Text + "'");
                    return;
                }

                // Create the PowerPoint presentation.
                CreatePpt(txtPowerPointFile.Text, title, headings);

                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Get the necessary information from the Word document.
        private void GetWordData(string file_name,
            string title_style, string heading_style,
            out string title, out List<string> headings)
        {
            // Load the Word document.
            // Get the Word application object.
            Word._Application word_app = new Word.ApplicationClass();

            object save_changes = false;
            object missing = System.Reflection.Missing.Value;

            try
            {
                // Make Word visible (optional).
                word_app.Visible = false;

                // Open the file.
                object filename = file_name;
                object confirm_conversions = false;
                object read_only = true;
                object add_to_recent_files = false;
                object format = 0;

                Word._Document word_doc =
                    word_app.Documents.Open(ref filename, ref confirm_conversions,
                        ref read_only, ref add_to_recent_files,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref format, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing);

                try
                {
                    // Get the title.
                    object style_name_obj = txtTitleStyle.Text;
                    WordFindWordWithStyle(word_doc, word_app, style_name_obj, out title);
                    Console.WriteLine("Title: " + title);

                    // Get the headings.
                    style_name_obj = txtHeadingStyle.Text;
                    headings = new List<string>();

                    // Repeat until we find a match before the previous one.
                    int last_pos = -1;
                    for (; ; )
                    {
                        string heading;
                        int pos = WordFindWordWithStyle(word_doc, word_app, style_name_obj, out heading);
                        if ((pos == 0) || (pos < last_pos)) break;

                        last_pos = pos;
                        headings.Add(heading);
                        Console.WriteLine("Section: " + pos + ": " + heading);
                    }
                }
                catch
                {
                    // Rethrow the exception.
                    throw;
                }
                finally
                {
                    // Close the document without prompting.
                    word_doc.Close(ref save_changes, ref missing, ref missing);
                }
            }
            catch
            {
                // Rethrow the exception.
                throw;
            }
            finally
            {
                word_app.Quit(ref save_changes, ref missing, ref missing);
            }
        }

        // Find an occurrence of a style in a Word document.
        // If the style isn't found, set text = "" and return 0.
        private int WordFindWordWithStyle(Word._Document word_doc,
            Word._Application word_app, object style_name, out string text)
        {
            word_app.Selection.Find.ClearFormatting();
            object style;
            try
            {
                style = word_doc.Styles.get_Item(ref style_name);
            }
            catch
            {
                text = "";
                return 0;
            }
            word_app.Selection.Find.set_Style(ref style);

            object blank_text = "";
            object false_obj = false;
            object true_obj = true;
            object wrap_obj = Word.WdFindWrap.wdFindContinue;
            object missing = System.Reflection.Missing.Value;
            word_app.Selection.Find.Execute(ref blank_text,
                ref false_obj, ref false_obj, ref false_obj,
                ref false_obj, ref false_obj, ref true_obj,
                ref wrap_obj, ref true_obj, ref missing,
                ref missing, ref false_obj, ref false_obj,
                ref false_obj, ref false_obj);

            text = word_app.Selection.Text.Trim();
            return word_app.Selection.Start;
        }

        // Create the PowerPoint presentation.
        private void CreatePpt(string file_name,
            string title, List<string> headings)
        {
            // Get the PowerPoint application object.
            Ppt._Application ppt_app = new Ppt.ApplicationClass();

            try
            {
                // Create the presentation.
                Ppt.Presentation ppt_pres =
                    ppt_app.Presentations.Add(MsoTriState.msoFalse);
                try
                {
                    // Create the title slide.
                    Ppt.Slide title_slide =
                        ppt_pres.Slides.Add(1, PpSlideLayout.ppLayoutTitleOnly);
                    title_slide.Shapes[1].TextFrame.TextRange.Text = title;

                    // Keep track of the other slides so we can make an agenda.
                    string agenda = "";

                    // Create other slides.
                    int slide_num = 1;
                    foreach (string heading in headings)
                    {
                        slide_num++;
                        Ppt.Slide heading_slide = ppt_pres.Slides.Add(
                            slide_num, PpSlideLayout.ppLayoutText);
                        heading_slide.Shapes[1].TextFrame.TextRange.Text = heading;

                        agenda += '\n' + heading;
                    }

                    // Create the agenda.
                    if (agenda.Length > 0)
                    {
                        // Remove the initial \n.
                        agenda = agenda.Substring(1);

                        // Create the agenda slide.
                        Ppt.Slide agenda_slide = ppt_pres.Slides.Add(
                            2, PpSlideLayout.ppLayoutText);
                        agenda_slide.Shapes[1].TextFrame.TextRange.Text = "Agenda";
                        agenda_slide.Shapes[2].TextFrame.TextRange.Text = agenda;

                        // Make each line in the agenda text be a hyperlink to the
                        // corresponding section page.
                        for (int i = 1; i < slide_num; i++)
                        {
                            // Page number (the current slide number) is the section
                            // number plus 2 (for the title slide and the agenda).
                            int page_number = i + 2;

                            // Set the SubAddress.
                            // (Address gives the file or URL. We don't use Address
                            // so the destination is within this document.
                            // SubAddress gives the location within the file.
                            // In this case, that's the slide number.)
                            agenda_slide.Shapes[2].TextFrame.TextRange.Lines(i, i).
                                ActionSettings[PpMouseActivation.ppMouseClick].
                                Hyperlink.SubAddress = page_number.ToString();
                        }
                    }

                    // Save the presentation.
                    ppt_pres.SaveAs(file_name,
                        PpSaveAsFileType.ppSaveAsPresentation,
                        MsoTriState.msoFalse);
                }
                catch
                {
                    // Rethrow the exception.
                    throw;
                }
                finally
                {
                    // Close.
                    ppt_pres.Close();
                }
            }
            catch
            {
                // Rethrow the exception.
                throw;
            }
            finally
            {
                ppt_app.Quit();
            }
        }

        private void btnPickWordFile_Click(object sender, EventArgs e)
        {
            ofdWordFile.FileName = txtWordFile.Text;
            if (ofdWordFile.ShowDialog() == DialogResult.OK)
                txtWordFile.Text = ofdWordFile.FileName;
        }

        private void btnPickPptFile_Click(object sender, EventArgs e)
        {
            sfdPptFile.FileName = txtPowerPointFile.Text;
            if (sfdPptFile.ShowDialog() == DialogResult.OK)
                txtPowerPointFile.Text = sfdPptFile.FileName;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_word_to_ppt_Form1));
            this.txtHeadingStyle = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPickPptFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPowerPointFile = new System.Windows.Forms.TextBox();
            this.txtTitleStyle = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sfdPptFile = new System.Windows.Forms.SaveFileDialog();
            this.btnPickWordFile = new System.Windows.Forms.Button();
            this.ofdWordFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWordFile = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHeadingStyle
            // 
            this.txtHeadingStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeadingStyle.Location = new System.Drawing.Point(115, 71);
            this.txtHeadingStyle.Name = "txtHeadingStyle";
            this.txtHeadingStyle.Size = new System.Drawing.Size(417, 20);
            this.txtHeadingStyle.TabIndex = 2;
            this.txtHeadingStyle.Text = "Heading 2";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(259, 170);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 15;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Title Style:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnPickPptFile);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPowerPointFile);
            this.groupBox2.Location = new System.Drawing.Point(38, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 46);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "            PowerPoint";
            // 
            // btnPickPptFile
            // 
            this.btnPickPptFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickPptFile.Image = ((System.Drawing.Image)(resources.GetObject("btnPickPptFile.Image")));
            this.btnPickPptFile.Location = new System.Drawing.Point(509, 17);
            this.btnPickPptFile.Name = "btnPickPptFile";
            this.btnPickPptFile.Size = new System.Drawing.Size(23, 23);
            this.btnPickPptFile.TabIndex = 5;
            this.btnPickPptFile.TabStop = false;
            this.btnPickPptFile.UseVisualStyleBackColor = true;
            this.btnPickPptFile.Click += new System.EventHandler(this.btnPickPptFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File:";
            // 
            // txtPowerPointFile
            // 
            this.txtPowerPointFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPowerPointFile.Location = new System.Drawing.Point(115, 19);
            this.txtPowerPointFile.Name = "txtPowerPointFile";
            this.txtPowerPointFile.Size = new System.Drawing.Size(388, 20);
            this.txtPowerPointFile.TabIndex = 0;
            this.txtPowerPointFile.Text = "Test.ppt";
            // 
            // txtTitleStyle
            // 
            this.txtTitleStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitleStyle.Location = new System.Drawing.Point(115, 45);
            this.txtTitleStyle.Name = "txtTitleStyle";
            this.txtTitleStyle.Size = new System.Drawing.Size(417, 20);
            this.txtTitleStyle.TabIndex = 1;
            this.txtTitleStyle.Text = "Heading 1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 116);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // sfdPptFile
            // 
            this.sfdPptFile.DefaultExt = "ppt";
            this.sfdPptFile.Filter = "PowerPoint Documents|*.ppt|All files|*.*";
            // 
            // btnPickWordFile
            // 
            this.btnPickWordFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickWordFile.Image = ((System.Drawing.Image)(resources.GetObject("btnPickWordFile.Image")));
            this.btnPickWordFile.Location = new System.Drawing.Point(509, 17);
            this.btnPickWordFile.Name = "btnPickWordFile";
            this.btnPickWordFile.Size = new System.Drawing.Size(23, 23);
            this.btnPickWordFile.TabIndex = 9;
            this.btnPickWordFile.TabStop = false;
            this.btnPickWordFile.UseVisualStyleBackColor = true;
            this.btnPickWordFile.Click += new System.EventHandler(this.btnPickWordFile_Click);
            // 
            // ofdWordFile
            // 
            this.ofdWordFile.DefaultExt = "docx";
            this.ofdWordFile.FileName = "openFileDialog1";
            this.ofdWordFile.Filter = "Word Documents|*.doc;*.docx|All files|*.*";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnPickWordFile);
            this.groupBox1.Controls.Add(this.txtHeadingStyle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTitleStyle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtWordFile);
            this.groupBox1.Location = new System.Drawing.Point(38, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 98);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "            Word";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Heading Style:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // txtWordFile
            // 
            this.txtWordFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWordFile.Location = new System.Drawing.Point(115, 19);
            this.txtWordFile.Name = "txtWordFile";
            this.txtWordFile.Size = new System.Drawing.Size(388, 20);
            this.txtWordFile.TabIndex = 0;
            this.txtWordFile.Text = "Test.docx";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // howto_word_to_ppt_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 204);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "howto_word_to_ppt_Form1";
            this.Text = "howto_word_to_ppt";
            this.Load += new System.EventHandler(this.howto_word_to_ppt_Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtHeadingStyle;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPickPptFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPowerPointFile;
        private System.Windows.Forms.TextBox txtTitleStyle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog sfdPptFile;
        private System.Windows.Forms.Button btnPickWordFile;
        private System.Windows.Forms.OpenFileDialog ofdWordFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWordFile;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

