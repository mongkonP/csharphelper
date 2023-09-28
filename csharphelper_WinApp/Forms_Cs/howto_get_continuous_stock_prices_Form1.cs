using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Net;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_continuous_stock_prices_Form1:Form
  { 


        public howto_get_continuous_stock_prices_Form1()
        {
            InitializeComponent();
        }

        // The stock symbols.
        private List<string> Symbols = null;

        // The price data.
        private List<List<PointF>> Prices = null;

        // The maximum number of prices per stock.
        private const int MaxNumPrices = 60;

        // Reset the data and start the timer.
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (btnGo.Text == "Go")
            {
                // Start.
                btnGo.Text = "Stop";
                btnGo.Refresh();

                // Make room for the stock symbols and prices.
                string[] symbols_text = txtSymbols.Text.Split(',');
                Symbols = new List<string>();
                Prices = new List<List<PointF>>();
                for (int i = 0; i < symbols_text.Length; i++)
                {
                    Symbols.Add(symbols_text[i].Trim());
                    Prices.Add(new List<PointF>());
                }

                // Get the initial prices.
                ShowLatestPrices();

                // Start the timer.
                tmrCheckPrices.Enabled = true;
            }
            else
            {
                // Stop.
                btnGo.Text = "Go";
                tmrCheckPrices.Enabled = false;
            }
        }

        // Draw the graph.
        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph(e.Graphics);
        }

        // Draw the graph.
        private void DrawGraph(Graphics gr)
        {
            gr.Clear(Color.White);
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            if (Prices == null) return;
            if (Prices[0].Count < 2) return;

            // Find the maximum price.
            const float min_price = 0;
            float max_price = 50;     // Use at least 50.
            if (Prices[0].Count > 0)
            {
                foreach (List<PointF> pts in Prices)
                {
                    float maxy = pts.Max(pt => pt.Y);
                    if (max_price < maxy) max_price = maxy;
                }
            }
            max_price *= 1.1f;

            // Scale.
            RectangleF rect = new RectangleF(
                0, min_price, MaxNumPrices, max_price);
            int wid = picGraph.ClientSize.Width;
            int hgt = picGraph.ClientSize.Height;
            PointF[] points = 
            { 
                new PointF(0, hgt), 
                new PointF(wid, hgt), 
                new PointF(0, 0) 
            };
            gr.Transform = new Matrix(rect, points);

            // Draw the grid lines.
            Matrix inverse = gr.Transform.Clone();
            inverse.Invert();
            using (StringFormat string_format = new StringFormat())
            {
                using (Pen thin_pen = new Pen(Color.Gray, 0))
                {
                    for (int y = 0; y <= max_price; y += 10)
                    {
                        gr.DrawLine(thin_pen, 0, y, MaxNumPrices, y);
                    }
                    for (int x = 0; x < MaxNumPrices; x++)
                    {
                        gr.DrawLine(thin_pen, x, min_price, x, min_price + 2);
                    }
                }
            }
            
            // Draw the graphs.
            Color[] colors = { Color.Black, Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Purple };
            for (int i = 0; i < Prices.Count; i++)
            {
                Color clr = colors[i % colors.Length];
                using (Pen thin_pen = new Pen(clr, 0))
                {
                    // Plot the prices.
                    gr.DrawLines(thin_pen, Prices[i].ToArray());

                    // Draw the symbol's name.
                    DrawSymbolName(gr, Symbols[i], Prices[i][0].Y, clr);
                }
            }
        }

        // Draw the text at the specified location.
        private void DrawSymbolName(Graphics gr, string txt, float y, Color clr)
        {
            // See where the point is in PictureBox coordinates.
            Matrix old_transformation = gr.Transform;
            PointF[] pt = { new PointF(0, y) };
            gr.Transform.TransformPoints(pt);

            // Reset the transformation.
            gr.ResetTransform();

            // Draw the text.
            using (Font small_font = new Font("Arial", 8))
            {
                using (SolidBrush br = new SolidBrush(clr))
                {
                    gr.DrawString(txt, small_font, br, 0, pt[0].Y);
                }
            }

            // Restore the original transformation.
            gr.Transform = old_transformation;
        }

        // Get the latest prices and then redraw the graph.
        private void tmrCheckPrices_Tick(object sender, EventArgs e)
        {
            ShowLatestPrices();
        }

        // Get the latest prices and then redraw the graph.
        private void ShowLatestPrices()
        {
            // Get the latest prices.
            List<float> current_prices = GetStockPrices(Symbols);

            // Add these prices to the old ones.
            for (int i = 0; i < Prices.Count; i++)
            {
                Prices[i].Add(new PointF(Prices[i].Count, current_prices[i]));
                Console.Write(current_prices[i].ToString() + " ");  // Debugging.
            }
            Console.WriteLine("");  // Debugging.

            // If we have more than MaxNumPrices values, remove the oldest.
            if (Prices[0].Count > MaxNumPrices)
            {
                List<List<PointF>> new_price_lists = new List<List<PointF>>();
                foreach (List<PointF> old_price_list in Prices)
                {
                    // Copy all but the first point into the new list,
                    // decrementing X.
                    List<PointF> new_price_list = new List<PointF>();
                    for (int i = 1; i < old_price_list.Count; i++)
                    {
                        new_price_list.Add(new PointF(
                            old_price_list[i].X - 1,
                            old_price_list[i].Y));
                    }
                    new_price_lists.Add(new_price_list);
                }

                // Save the new lists.
                Prices = new_price_lists;
            }

            // Redraw the graph.
            picGraph.Refresh();
        }

        // Get the latest stock prices.
        private List<float> GetStockPrices(List<string> symbols)
        {
            // Build the URL.
            string symbol_text = string.Join("+", symbols.ToArray());
            string url =
                "http://download.finance.yahoo.com/d/quotes.csv?s=" +
                symbol_text + "&f=sl1d1t1c1";

            // Get the stock data.
            try
            {
                // Get the web response.
                string result = GetWebResponse(url);

                // Pull out the current prices.
                string[] lines = result.Split(
                    new char[] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);

                List<float> prices = new List<float>();
                foreach (string line in lines)
                    prices.Add(float.Parse(line.Split(',')[1]));

                return prices;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Read Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // If we get this far, we failed.
            return null;
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
            this.components = new System.ComponentModel.Container();
            this.txtSymbols = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.tmrCheckPrices = new System.Windows.Forms.Timer(this.components);
            this.picGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSymbols
            // 
            this.txtSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSymbols.Location = new System.Drawing.Point(12, 14);
            this.txtSymbols.Name = "txtSymbols";
            this.txtSymbols.Size = new System.Drawing.Size(268, 20);
            this.txtSymbols.TabIndex = 5;
            this.txtSymbols.Text = "MCI, DIS, COKE, PEP";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(286, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 9;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tmrCheckPrices
            // 
            this.tmrCheckPrices.Interval = 60000;
            this.tmrCheckPrices.Tick += new System.EventHandler(this.tmrCheckPrices_Tick);
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(12, 41);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(349, 211);
            this.picGraph.TabIndex = 10;
            this.picGraph.TabStop = false;
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // howto_get_continuous_stock_prices_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 264);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtSymbols);
            this.Name = "howto_get_continuous_stock_prices_Form1";
            this.Text = "howto_get_continuous_stock_prices";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSymbols;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Timer tmrCheckPrices;
        private System.Windows.Forms.PictureBox picGraph;
    }
}

