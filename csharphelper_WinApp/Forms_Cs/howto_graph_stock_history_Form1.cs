using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_graph_stock_history_Form1:Form
  { 


        public howto_graph_stock_history_Form1()
        {
            InitializeComponent();
        }

        // The ticker symbols.
        List<string> Symbols = null;

        // The current prices.
        List<float>[] Prices = null;

        // Redraw the graph.
        private void picGraph_Resize(object sender, EventArgs e)
        {
            DrawGraph();
        }

        // Get the closing prices and graph them.
        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            // Get the ticker symbols.
            string[] symbols_text = txtSymbols.Text.Split(',');
            Symbols = new List<string>();
            for (int i = 0; i < symbols_text.Length; i++)
                Symbols.Add(symbols_text[i].Trim());

            // Get the data.
            Prices = new List<float>[Symbols.Count];
            for (int i = 0; i < Symbols.Count; i++)
                Prices[i] = GetStockPrices(Symbols[i]);

            // Graph it.
            DrawGraph();

            this.Cursor = Cursors.Default;
        }

        // Get the prices for this symbol.
        private List<float> GetStockPrices(string symbol)
        {
            // Compose the URL.
            string url = "http://www.google.com/finance/historical?output=csv&q=" + symbol;

            // Get the web response.
            string result = GetWebResponse(url);

            // Get the historical prices.
            string[] lines = result.Split(
                new char[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);
            List<float> prices = new List<float>();
            // Process the lines, skipping the header.
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                prices.Add(float.Parse(line.Split(',')[4]));
            }

            return prices;
        }

        // Get a web response.
        private string GetWebResponse(string url)
        {
            // Make a WebClient.
            WebClient web_client = new WebClient();

            // Get the indicated URL.
            Stream response = web_client.OpenRead(url);

            // Read the result.
            using (StreamReader stream_reader = new StreamReader(response))
            {
                // Get the results.
                string result = stream_reader.ReadToEnd();

                // Close the stream reader and its underlying stream.
                stream_reader.Close();

                // Return the result.
                return result;
            }
        }

        // Draw the graph.
        private void DrawGraph()
        {
            if (Prices == null) return;

            // Make the bitmap.
            Bitmap bm = new Bitmap(
                picGraph.ClientSize.Width,
                picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Get the largest prices.
                float max_price = 10;
                foreach (List<float> symbol_prices in Prices)
                {
                    float new_max = symbol_prices.Max();
                    if (max_price < new_max) max_price = new_max;
                }

                // Scale and translate the graph.
                float scale_x = -picGraph.ClientSize.Width / (float)Prices[0].Count;
                float scale_y = -picGraph.ClientSize.Height / max_price;
                gr.ScaleTransform(scale_x, scale_y);
                gr.TranslateTransform(
                    picGraph.ClientSize.Width,
                    picGraph.ClientSize.Height,
                    MatrixOrder.Append);

                // Draw the grid lines.
                using (StringFormat string_format = new StringFormat())
                {
                    using (Pen thin_pen = new Pen(Color.Gray, 0))
                    {
                        for (int y = 0; y <= max_price; y += 10)
                            gr.DrawLine(thin_pen, 0, y, Prices[0].Count, y);
                        for (int x = 0; x < Prices[0].Count; x += 7)
                            gr.DrawLine(thin_pen, x, 0, x, 2);
                    }
                }

                // Draw each symbol's prices.
                Color[] colors = { Color.Black, Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Purple };
                for (int symbol_num = 0; symbol_num < Prices.Length; symbol_num++)
                {
                    List<float> symbol_prices = Prices[symbol_num];

                    // Make the data points.
                    PointF[] points = new PointF[symbol_prices.Count];
                    for (int i = 0; i < symbol_prices.Count; i++)
                        points[i] = new PointF(i, symbol_prices[i]);

                    // Draw the points.
                    Color clr = colors[symbol_num % colors.Length];
                    using (Pen thin_pen = new Pen(clr, 0))
                    {
                        gr.DrawLines(thin_pen, points);
                    }

                    // Draw the symbol's name.
                    //DrawSymbolName(gr, Symbols[symbol_num],
                    //    0, symbol_prices[symbol_prices.Count - 1], clr);
                }

                // Draw the symbol names in the default coordinate system.
                gr.ResetTransform();
                float symbol_x = 0;
                float symbol_y = picGraph.ClientSize.Height;
                using (Font small_font = new Font("Arial", 8))
                {
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = StringAlignment.Far;
                        for (int symbol_num = 0; symbol_num < Prices.Length; symbol_num++)
                        {
                            Color clr = colors[symbol_num % colors.Length];
                            using (SolidBrush br = new SolidBrush(clr))
                            {
                                gr.DrawString(Symbols[symbol_num],
                                    small_font, br, symbol_x, symbol_y, sf);
                                symbol_x += 50;
                            }
                        }
                    }
                }
            }

            // Display the result.
            picGraph.Image = bm;
        }

        // Draw the text at the specified location.
        private void DrawSymbolName(Graphics gr, string txt, float x, float y, Color clr)
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
                    gr.DrawString(txt, small_font, br, pt[0]);
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
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtSymbols = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(12, 41);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(379, 211);
            this.picGraph.TabIndex = 7;
            this.picGraph.TabStop = false;
            this.picGraph.Resize += new System.EventHandler(this.picGraph_Resize);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(347, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(44, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtSymbols
            // 
            this.txtSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSymbols.Location = new System.Drawing.Point(67, 14);
            this.txtSymbols.Name = "txtSymbols";
            this.txtSymbols.Size = new System.Drawing.Size(274, 20);
            this.txtSymbols.TabIndex = 5;
            this.txtSymbols.Text = "MSFT, AAPL, YHOO, DIS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Symbols:";
            // 
            // howto_graph_stock_history_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 264);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtSymbols);
            this.Controls.Add(this.label1);
            this.Name = "howto_graph_stock_history_Form1";
            this.Text = "howto_graph_stock_history";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtSymbols;
        private System.Windows.Forms.Label label1;
    }
}

