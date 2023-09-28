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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_graph_dji_history_Form1:Form
  { 


        // Structure to hold price data.
        private struct PriceData
        {
            public DateTime Date;
            public float Price;
            public PriceData(DateTime new_Date, float new_Price)
            {
                Date = new_Date;
                Price = new_Price;
            }
        };

        public howto_graph_dji_history_Form1()
        {
            InitializeComponent();
        }

        // Draw the graph.
        private void howto_graph_dji_history_Form1_Load(object sender, EventArgs e)
        {
            DrawGraph();
        }

        // Draw the graph.
        private void picRefresh_Click(object sender, EventArgs e)
        {
            DrawGraph();
        }

        // Draw the graph.
        private void DrawGraph()
        {
            this.Cursor = Cursors.WaitCursor;

            // Load the data.
            List<PriceData> price_data = GetDjiPrices();

            // Graph it.
            DrawGraph(price_data);

            this.Cursor = Cursors.Default;
        }

        // Get the historical prices.
        private List<PriceData> GetDjiPrices()
        {
            // Get the data by lines.
            string[] lines = File.ReadAllLines("DjiPrices.csv");

            // See which header fields contains Date and Adj Close.
            string[] fields = lines[0].Split(',');
            int date_field = -1, close_field = -1;
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].ToLower() == "adj close")
                    close_field = i;
                else if (fields[i].ToLower() == "date")
                    date_field = i;
            }

            // Process the lines, skipping the header.
            List<PriceData> price_data = new List<PriceData>();
            for (int i = 1; i < lines.Length; i++)
            {
                fields = lines[i].Split(',');
                price_data.Add(new PriceData(
                    DateTime.Parse(fields[date_field]),
                    float.Parse(fields[close_field])));
            }

            // Reverse so the data is in historical order.
            price_data.Reverse();
            return price_data;
        }

        // Draw the graph.
        private void DrawGraph(List<PriceData> price_data)
        {
            // Make the bitmap.
            Bitmap bm = new Bitmap(
                picGraph.ClientSize.Width,
                picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Get the largest price.
                var max_query = from PriceData data in price_data select data.Price;
                float max_price = max_query.Max() + 500;

                // Scale and translate the graph.
                float scale_x = picGraph.ClientSize.Width / (float)price_data.Count;
                float scale_y = -picGraph.ClientSize.Height / max_price;
                gr.ScaleTransform(scale_x, scale_y);
                gr.TranslateTransform(
                    0,
                    picGraph.ClientSize.Height,
                    System.Drawing.Drawing2D.MatrixOrder.Append);

                using (Pen thin_pen = new Pen(Color.Gray, 0))
                {
                    // Draw the horizontal grid lines.
                    for (int y = 0; y <= max_price; y += 1000)
                    {
                        // Draw the line.
                        gr.DrawLine(thin_pen, 0, y, price_data.Count, y);

                        // Draw the value.
                        if (y > 0)
                            DrawTextAt(gr, y.ToString("C"), 10, y, Color.Blue,
                                StringAlignment.Near, StringAlignment.Far);
                    }

                    // Draw the vertical grid lines.
                    using (StringFormat string_format = new StringFormat())
                    {
                        string_format.Alignment = StringAlignment.Center;
                        string_format.LineAlignment = StringAlignment.Center;
                        int last_year = 0;
                        for (int i = 0; i < price_data.Count; i++)
                        {
                            // See if this is the start of a new year.
                            if (price_data[i].Date.Year > last_year)
                            {
                                last_year = price_data[i].Date.Year;

                                // Draw a line for the year.
                                gr.DrawLine(thin_pen, i, 0, i, 750);

                                // Draw the year number.
                                DrawTextAt(gr, last_year.ToString(), i, 0, Color.Blue,
                                    StringAlignment.Center, StringAlignment.Far);
                            }
                        }
                    }
                }

                // Draw the prices. Make the data points.
                PointF[] points = new PointF[price_data.Count];
                for (int i = 0; i < price_data.Count; i++)
                {
                    points[i] = new PointF(i, price_data[i].Price);
                }

                // Draw the points.
                using (Pen thin_pen = new Pen(Color.Black, 0))
                {
                    gr.DrawLines(thin_pen, points);
                }
            }

            // Display the result.
            picGraph.Image = bm;
        }

        // Draw the text at the specified location.
        private void DrawTextAt(Graphics gr, string txt, float x, float y, Color clr, StringAlignment alignment, StringAlignment line_alignment)
        {
            // See where the point is in PictureBox coordinates.
            Matrix old_transformation = gr.Transform;
            PointF[] pt = { new PointF(x, y) };
            gr.Transform.TransformPoints(pt);

            // Reset the transformation.
            gr.ResetTransform();

            // Draw the text.
            using (Font small_font = new Font("Arial", 8))
            {
                using (SolidBrush br = new SolidBrush(clr))
                {
                    using (StringFormat string_format = new StringFormat())
                    {
                        string_format.Alignment = alignment;
                        string_format.LineAlignment = line_alignment;
                        gr.DrawString(txt, small_font, br, pt[0].X, pt[0].Y, string_format);
                    }
                }
            }

            // Restore the original transformation.
            gr.Transform = old_transformation;
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
            this.picRefresh = new System.Windows.Forms.PictureBox();
            this.picGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // picRefresh
            // 
            this.picRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRefresh.Image = Properties.Resources.ResetButton;
            this.picRefresh.Location = new System.Drawing.Point(726, 0);
            this.picRefresh.Name = "picRefresh";
            this.picRefresh.Size = new System.Drawing.Size(17, 14);
            this.picRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRefresh.TabIndex = 7;
            this.picRefresh.TabStop = false;
            this.picRefresh.Click += new System.EventHandler(this.picRefresh_Click);
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(12, 12);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(719, 360);
            this.picGraph.TabIndex = 6;
            this.picGraph.TabStop = false;
            // 
            // howto_graph_dji_history_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 384);
            this.Controls.Add(this.picRefresh);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_graph_dji_history_Form1";
            this.Text = "howto_graph_dji_history";
            this.Load += new System.EventHandler(this.howto_graph_dji_history_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picRefresh;
        private System.Windows.Forms.PictureBox picGraph;
    }
}

