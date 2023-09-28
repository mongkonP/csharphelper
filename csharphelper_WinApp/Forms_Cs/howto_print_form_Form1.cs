using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_print_form_Form1:Form
  { 


        public howto_print_form_Form1()
        {
            InitializeComponent();
        }

        private void btnForm_Click(object sender, EventArgs e)
        {
            ShowControlImage(this);
        }

        private void btnClientArea_Click(object sender, EventArgs e)
        {
            using (Bitmap bm = GetFormImageWithoutBorders(this))
            {
                PrintImage(bm);
            }
        }

        private void btnGroupBox_Click(object sender, EventArgs e)
        {
            ShowControlImage(groupBox1);
        }

        private void btnPage1_Click(object sender, EventArgs e)
        {
            int selected = tabControl1.SelectedIndex;
            tabControl1.SelectedIndex = 0;

            ShowControlImage(tabPage1);

            tabControl1.SelectedIndex = selected;
        }

        private void btnPage2_Click(object sender, EventArgs e)
        {
            int selected = tabControl1.SelectedIndex;
            tabControl1.SelectedIndex = 1;

            ShowControlImage(tabPage2);

            tabControl1.SelectedIndex = selected;
        }

        private void ShowControlImage(Control ctl)
        {
            using (Bitmap bm = GetControlImage(ctl))
            {
                PrintImage(bm);
            }
        }

        // Return a Bitmap holding an image of the control.
        private Bitmap GetControlImage(Control ctl)
        {
            Bitmap bm = new Bitmap(ctl.Width, ctl.Height);
            ctl.DrawToBitmap(bm, new Rectangle(0, 0, ctl.Width, ctl.Height));
            return bm;
        }

        // Return the form's image without its borders and decorations.
        private Bitmap GetFormImageWithoutBorders(Form frm)
        {
            // Get the form's whole image.
            using (Bitmap whole_form = GetControlImage(frm))
            {
                // See how far the form's upper left corner is
                // from the upper left corner of its client area.
                Point origin = frm.PointToScreen(new Point(0, 0));
                int dx = origin.X - frm.Left;
                int dy = origin.Y - frm.Top;

                // Copy the client area into a new Bitmap.
                int wid = frm.ClientSize.Width;
                int hgt = frm.ClientSize.Height;
                Bitmap bm = new Bitmap(wid, hgt);
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    gr.DrawImage(whole_form, 0, 0,
                        new Rectangle(dx, dy, wid, hgt),
                        GraphicsUnit.Pixel);
                }
                return bm;
            }
        }

        // Send the image to a PrintPreviewDialog.
        // (You could modify it to print directly.)
        private Image ImageToPrint;
        private void PrintImage(Image image)
        {
            // Save a reference to the image to print.
            ImageToPrint = image;

            // Display the dialog.
            ppdForm.ShowDialog();
        }

        // Print the page.
        private void pdocForm_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Center the image.
            int cx = e.MarginBounds.X + e.MarginBounds.Width / 2;
            int cy = e.MarginBounds.Y + e.MarginBounds.Height / 2;
            Rectangle rect = new Rectangle(
                cx - ImageToPrint.Width / 2, cy - ImageToPrint.Height / 2,
                ImageToPrint.Width, ImageToPrint.Height);

            e.Graphics.InterpolationMode = InterpolationMode.High;
            e.Graphics.DrawImage(ImageToPrint, rect);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_print_form_Form1));
            this.btnClientArea = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnGroupBox = new System.Windows.Forms.Button();
            this.btnForm = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pdocForm = new System.Drawing.Printing.PrintDocument();
            this.ppdForm = new System.Windows.Forms.PrintPreviewDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClientArea
            // 
            this.btnClientArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientArea.Location = new System.Drawing.Point(279, 41);
            this.btnClientArea.Name = "btnClientArea";
            this.btnClientArea.Size = new System.Drawing.Size(75, 23);
            this.btnClientArea.TabIndex = 7;
            this.btnClientArea.Text = "Client Area";
            this.btnClientArea.UseVisualStyleBackColor = true;
            this.btnClientArea.Click += new System.EventHandler(this.btnClientArea_Click);
            // 
            // btnPage2
            // 
            this.btnPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage2.Location = new System.Drawing.Point(279, 128);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(75, 23);
            this.btnPage2.TabIndex = 11;
            this.btnPage2.Text = "Page 2";
            this.btnPage2.UseVisualStyleBackColor = true;
            this.btnPage2.Click += new System.EventHandler(this.btnPage2_Click);
            // 
            // btnPage1
            // 
            this.btnPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage1.Location = new System.Drawing.Point(279, 99);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(75, 23);
            this.btnPage1.TabIndex = 9;
            this.btnPage1.Text = "Page 1";
            this.btnPage1.UseVisualStyleBackColor = true;
            this.btnPage1.Click += new System.EventHandler(this.btnPage1_Click);
            // 
            // btnGroupBox
            // 
            this.btnGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroupBox.Location = new System.Drawing.Point(279, 70);
            this.btnGroupBox.Name = "btnGroupBox";
            this.btnGroupBox.Size = new System.Drawing.Size(75, 23);
            this.btnGroupBox.TabIndex = 8;
            this.btnGroupBox.Text = "GroupBox";
            this.btnGroupBox.UseVisualStyleBackColor = true;
            this.btnGroupBox.Click += new System.EventHandler(this.btnGroupBox_Click);
            // 
            // btnForm
            // 
            this.btnForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForm.Location = new System.Drawing.Point(279, 12);
            this.btnForm.Name = "btnForm";
            this.btnForm.Size = new System.Drawing.Size(75, 23);
            this.btnForm.TabIndex = 5;
            this.btnForm.Text = "Form";
            this.btnForm.UseVisualStyleBackColor = true;
            this.btnForm.Click += new System.EventHandler(this.btnForm_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 157);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(342, 149);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(334, 123);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(77, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Page 1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(334, 123);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(77, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Page 2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 99);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(113, 67);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(85, 17);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(113, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(113, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(15, 68);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(80, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(15, 45);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(15, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pdocForm
            // 
            this.pdocForm.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocForm_PrintPage);
            // 
            // ppdForm
            // 
            this.ppdForm.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdForm.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdForm.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdForm.Document = this.pdocForm;
            this.ppdForm.Enabled = true;
            this.ppdForm.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdForm.Icon")));
            this.ppdForm.Name = "ppdForm";
            this.ppdForm.Visible = false;
            // 
            // howto_print_form_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 318);
            this.Controls.Add(this.btnClientArea);
            this.Controls.Add(this.btnPage2);
            this.Controls.Add(this.btnPage1);
            this.Controls.Add(this.btnGroupBox);
            this.Controls.Add(this.btnForm);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "howto_print_form_Form1";
            this.Text = "howto_print_form";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClientArea;
        private System.Windows.Forms.Button btnPage2;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.Button btnGroupBox;
        private System.Windows.Forms.Button btnForm;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Drawing.Printing.PrintDocument pdocForm;
        private System.Windows.Forms.PrintPreviewDialog ppdForm;
    }
}

