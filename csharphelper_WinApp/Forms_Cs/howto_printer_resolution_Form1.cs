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
     public partial class howto_printer_resolution_Form1:Form
  { 


        public howto_printer_resolution_Form1()
        {
            InitializeComponent();
        }

        // List the available printers.
        private void howto_printer_resolution_Form1_Load(object sender, EventArgs e)
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
                cboPrinter.Items.Add(printer);
        }

        // Print.
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Select the printer.
            pdocSmiley.PrinterSettings.PrinterName = cboPrinter.Text;

            // Pick the selected resolution.
            pdocSmiley.DefaultPageSettings.PrinterResolution =
                pdocSmiley.DefaultPageSettings.PrinterSettings.
                    PrinterResolutions[cboResolution.SelectedIndex];

            // Print.
            pdocSmiley.Print();
        }

        // Draw the smiley face.
        private void pdocSmiley_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.TranslateTransform(1, 1);
            e.Graphics.ScaleTransform(100, 100,
                System.Drawing.Drawing2D.MatrixOrder.Append);
            e.Graphics.TranslateTransform(
                e.MarginBounds.X,
                e.MarginBounds.Y,
                System.Drawing.Drawing2D.MatrixOrder.Append);
            DrawSmiley(e.Graphics);
        }

        // Draw a smiley face in the area (-1, -1)-(1, 1).
        private void DrawSmiley(Graphics gr)
        {
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                gr.FillEllipse(Brushes.Yellow, -1, -1, 2, 2);
                gr.DrawEllipse(thin_pen, -1, -1, 2, 2);

                gr.FillEllipse(Brushes.LightGreen, -0.5F, -0.5F, 0.3F, 0.5F);
                gr.DrawEllipse(thin_pen, -0.5F, -0.5F, 0.3F, 0.5F);
                gr.FillEllipse(Brushes.Black, -0.4F, -0.4F, 0.2F, 0.3F);

                gr.FillEllipse(Brushes.LightGreen, 0.2F, -0.5F, 0.3F, 0.5F);
                gr.DrawEllipse(thin_pen, 0.2F, -0.5F, 0.3F, 0.5F);
                gr.FillEllipse(Brushes.Black, 0.3F, -0.4F, 0.2F, 0.3F);

                gr.FillEllipse(Brushes.LightBlue, -0.2F, -0.1F, 0.4F, 0.6F);
                gr.DrawEllipse(thin_pen, -0.2F, -0.1F, 0.4F, 0.6F);

                gr.DrawArc(thin_pen, -0.75F, -0.75F, 1.5F, 1.5F, 20, 120);
            }
        }

        // Display this printer's available resolutions.
        private void cboPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Select the printer.
            pdocSmiley.PrinterSettings.PrinterName = cboPrinter.Text;

            // Display the available resolutions.
            cboResolution.Items.Clear();
            foreach (PrinterResolution resolution in
                pdocSmiley.DefaultPageSettings.PrinterSettings.PrinterResolutions)
            {
                cboResolution.Items.Add(resolution.ToString());
            }

            // Enable the Print button if a printer and resolution are selected.
            btnPrint.Enabled = (
                (cboPrinter.SelectedIndex > -1) &&
                (cboResolution.SelectedIndex > -1));
        }

        // Enable the Print button if a printer and resolution are selected.
        private void cboResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = (
                (cboPrinter.SelectedIndex > -1) &&
                (cboResolution.SelectedIndex > -1));
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.cboPrinter = new System.Windows.Forms.ComboBox();
            this.pdocSmiley = new System.Drawing.Printing.PrintDocument();
            this.cboResolution = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(129, 77);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cboPrinter
            // 
            this.cboPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinter.FormattingEnabled = true;
            this.cboPrinter.Location = new System.Drawing.Point(12, 12);
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.Size = new System.Drawing.Size(309, 21);
            this.cboPrinter.TabIndex = 2;
            this.cboPrinter.SelectedIndexChanged += new System.EventHandler(this.cboPrinter_SelectedIndexChanged);
            // 
            // pdocSmiley
            // 
            this.pdocSmiley.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocSmiley_PrintPage);
            // 
            // cboResolution
            // 
            this.cboResolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResolution.FormattingEnabled = true;
            this.cboResolution.Location = new System.Drawing.Point(12, 39);
            this.cboResolution.Name = "cboResolution";
            this.cboResolution.Size = new System.Drawing.Size(309, 21);
            this.cboResolution.TabIndex = 4;
            this.cboResolution.SelectedIndexChanged += new System.EventHandler(this.cboResolution_SelectedIndexChanged);
            // 
            // howto_printer_resolution_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 112);
            this.Controls.Add(this.cboResolution);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cboPrinter);
            this.Name = "howto_printer_resolution_Form1";
            this.Text = "howto_printer_resolution";
            this.Load += new System.EventHandler(this.howto_printer_resolution_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cboPrinter;
        private System.Drawing.Printing.PrintDocument pdocSmiley;
        private System.Windows.Forms.ComboBox cboResolution;
    }
}

