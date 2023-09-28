using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

// Open the Add References dialog. On the COM tab, select
// "Microsoft Word 12.0 Object Library" (or whatever version you
// have installed on your system). 

using Word = Microsoft.Office.Interop.Word;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_make_word_document_Form1:Form
  { 


        public howto_make_word_document_Form1()
        {
            InitializeComponent();
        }

        // Make a Word document.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get the Word application object.
            Word._Application word_app = new Word.ApplicationClass();

            // Make Word visible (optional).
            word_app.Visible = true;

            // Create the Word document.
            object missing = Type.Missing;
            Word._Document word_doc = word_app.Documents.Add(ref missing, ref missing,
                ref missing, ref missing);

            // Create a header paragraph.
            Word.Paragraph para = word_doc.Paragraphs.Add(ref missing);
            para.Range.Text = "Chrysanthemum Curve";
            object style_name = "Heading 1";
            para.Range.set_Style(ref style_name);
            para.Range.InsertParagraphAfter();

            // Add more text.
            para.Range.Text = "To make a chrysanthemum curve, use the following " +
                "parametric equations as t goes from 0 to 21 * π to generate " +
                "points and then connect them.";
            para.Range.InsertParagraphAfter();

            // Save the current font and start using Courier New.
            string old_font = para.Range.Font.Name;
            para.Range.Font.Name = "Courier New";

            // Add the equations.
            para.Range.Text =
                "  r = 5 * (1 + Sin(11 * t / 5)) -\n" +
                "      4 * Sin(17 * t / 3) ^ 4 *\n" +
                "      Sin(2 * Cos(3 * t) - 28 * t) ^ 8\n" +
                "  x = r * Cos(t)\n" +
                "  y = r * Sin(t)";

            // Start a new paragraph and then switch back to the original font.
            para.Range.InsertParagraphAfter();
            para.Range.Font.Name = old_font;

            // Save the document.
            object filename = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\..")) +
                "\\test.doc";
            word_doc.SaveAs(ref filename, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing);

            // Close.
            object save_changes = false;
            word_doc.Close(ref save_changes, ref missing, ref missing);
            word_app.Quit(ref save_changes, ref missing, ref missing);

            MessageBox.Show("Done");
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
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGo.Location = new System.Drawing.Point(130, 31);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // howto_make_word_document_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 85);
            this.Controls.Add(this.btnGo);
            this.Name = "howto_make_word_document_Form1";
            this.Text = "howto_make_word_document";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
    }
}

