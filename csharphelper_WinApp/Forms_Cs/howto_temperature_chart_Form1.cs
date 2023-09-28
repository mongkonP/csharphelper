using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;
using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_temperature_chart_Form1:Form
  { 


        public howto_temperature_chart_Form1()
        {
            InitializeComponent();
        }

        private void pdocChart_PrintPage(object sender, PrintPageEventArgs e)
        {
            const float font_size = 12;
            const float dy = font_size * 1.5f;
            float x0 = e.MarginBounds.Left + 0.5f * 100;
            float x1 = x0 + 0.75f * 100;
            float y = e.MarginBounds.Top;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            using (Font font = new Font("Times New Roman", font_size))
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;

                    e.Graphics.DrawString("Celsius", font, Brushes.Blue, x0, y, sf);
                    e.Graphics.DrawString("Fahrenheit", font, Brushes.Blue, x1, y, sf);
                    y += dy;

                    for (int celsius = 60; celsius <= 250; celsius += 5)
                    {
                        float fahrenheit = celsius * 9f / 5f + 32;
                        e.Graphics.DrawString(celsius.ToString(),
                            font, Brushes.Black, x0, y, sf);
                        e.Graphics.DrawString(fahrenheit.ToString("0"),
                            font, Brushes.Black, x1, y, sf);
                        y += dy;
                    }

                    y = e.MarginBounds.Top;
                    float x2 = x1 + 1.2f * 100;
                    float x3 = x2 + 0.75f * 100;
                    e.Graphics.DrawString("Fahrenheit", font, Brushes.Blue, x2, y, sf);
                    e.Graphics.DrawString("Celsius", font, Brushes.Blue, x3, y, sf);
                    y += dy;

                    for (int fahrenheit = 140; fahrenheit <= 500; fahrenheit += 10)
                    {
                        float celsius = (fahrenheit - 32) * 5f / 9f;
                        e.Graphics.DrawString(fahrenheit.ToString(),
                            font, Brushes.Black, x2, y, sf);
                        e.Graphics.DrawString(celsius.ToString("0"),
                            font, Brushes.Black, x3, y, sf);
                        y += dy;
                    }
                }
            }
        }

        private void btnCreateChart_Click(object sender, EventArgs e)
        {
            ppdChart.ShowDialog();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_temperature_chart_Form1));
            this.btnCreateChart = new System.Windows.Forms.Button();
            this.pdocChart = new System.Drawing.Printing.PrintDocument();
            this.ppdChart = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // btnCreateChart
            // 
            this.btnCreateChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreateChart.Location = new System.Drawing.Point(120, 34);
            this.btnCreateChart.Name = "btnCreateChart";
            this.btnCreateChart.Size = new System.Drawing.Size(75, 23);
            this.btnCreateChart.TabIndex = 0;
            this.btnCreateChart.Text = "Create Chart";
            this.btnCreateChart.UseVisualStyleBackColor = true;
            this.btnCreateChart.Click += new System.EventHandler(this.btnCreateChart_Click);
            // 
            // pdocChart
            // 
            this.pdocChart.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocChart_PrintPage);
            // 
            // ppdChart
            // 
            this.ppdChart.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdChart.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdChart.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdChart.Document = this.pdocChart;
            this.ppdChart.Enabled = true;
            this.ppdChart.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdChart.Icon")));
            this.ppdChart.Name = "ppdChart";
            this.ppdChart.Visible = false;
            // 
            // howto_temperature_chart_Form1
            // 
            this.AcceptButton = this.btnCreateChart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 91);
            this.Controls.Add(this.btnCreateChart);
            this.Name = "howto_temperature_chart_Form1";
            this.Text = "howto_temperature_chart";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateChart;
        private System.Drawing.Printing.PrintDocument pdocChart;
        private System.Windows.Forms.PrintPreviewDialog ppdChart;
    }
}

