using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.IO;
using System.Drawing.Drawing2D;

// Useful URLs:
//      YQL developer console   https://developer.yahoo.com/yql/console/

 

using howto_graph_currency_rates;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_graph_currency_rates_Form1:Form
  { 


        public howto_graph_currency_rates_Form1()
        {
            InitializeComponent();
        }

        // Store the data.
        private List<PriceData> PriceList = new List<PriceData>();

        // The coordinate mappings.
        private Matrix WtoDMatrix, DtoWMatrix;

        // Set the dates to run from one month ago to today.
        private void howto_graph_currency_rates_Form1_Load(object sender, EventArgs e)
        {
            DateTime end_date = DateTime.Today.AddDays(-1);
            DateTime start_date = end_date.AddMonths(-1);
            txtStartDate.Text = start_date.ToString("yyyy-MM-dd");
            txtEndDate.Text = end_date.ToString("yyyy-MM-dd");
        }

        // Get the data and graph it.
        private void btnGraph_Click(object sender, EventArgs e)
        {
            // Compose the query URL.
            string base_url =
                "https://query.yahooapis.com/v1/public/yql?" +
                "q=@QUERY@" +
                "&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys" +
                "&format=xml";
            string query = "SELECT Date, Close " +
                "FROM yahoo.finance.historicaldata " +
                "WHERE symbol = '@CURRENCY@=X' " +
                "AND startDate = '@START@' " +
                "AND endDate = '@END@' " +
                "| sort(field='Date')";
            query = query.Replace("@CURRENCY@", txtCurrency.Text.Trim().ToUpper());
            query = query.Replace("@START@", txtStartDate.Text);
            query = query.Replace("@END@", txtEndDate.Text);

            string url = base_url.Replace("@QUERY@", query.UrlEncode());
            //Console.WriteLine(query);
            //Console.WriteLine(url);

            // Load the XML result.
            XmlDocument doc = new XmlDocument();
            doc.Load(url);

            // Get the data.
            PriceList = new List<PriceData>();
            XmlNode root = doc.DocumentElement;
            string xquery = "descendant::quote";
            foreach (XmlNode node in root.SelectNodes(xquery))
            {
                string date_text = node.SelectSingleNode("descendant::Date").InnerText;
                DateTime date = DateTime.Parse(date_text);

                string close_text = node.SelectSingleNode("descendant::Close").InnerText;
                decimal close = decimal.Parse(close_text);
                
                PriceList.Add(new PriceData(date, close));
            }

            //// Display the XML data.
            //Console.WriteLine(FormatXml(doc));

            //// Display the data as text.
            //foreach (PriceData data in PriceList)
            //{
            //    Console.WriteLine(
            //        data.Date.ToShortDateString() + "\t" +
            //        data.Price.ToString());
            //}

            // Graph the data.
            DrawGraph();
        }

        // Draw the graph.
        private Bitmap GraphBm = null;
        private void DrawGraph()
        {
            if (PriceList.Count < 1)
            {
                picGraph.Image = null;
                WtoDMatrix = null;
                DtoWMatrix = null;
                return;
            }

            int wid = picGraph.ClientSize.Width;
            int hgt = picGraph.ClientSize.Height;
            GraphBm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(GraphBm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.Clear(Color.White);

                // Scale the data to fit.
                int num_points = PriceList.Count;
                float min_price = (float)PriceList.Min(data => data.Price);
                float max_price = (float)PriceList.Max(data => data.Price);
                const int margin = 10;

                WtoDMatrix = MappingMatrix(
                    0, num_points - 1, min_price, max_price,
                    margin, wid - margin, margin, hgt - margin);
                gr.Transform = WtoDMatrix;

                DtoWMatrix = WtoDMatrix.Clone();
                DtoWMatrix.Invert();

                // Draw the graph.
                using (Pen pen = new Pen(Color.Black, 0))
                {
                    // Draw tic marks.
                    PointF[] pts = { new PointF(10, 10) };
                    DtoWMatrix.TransformVectors(pts);
                    float dy = pts[0].Y;
                    float dx = pts[0].X;

                    for (int x = 0; x < PriceList.Count; x++)
                    {
                        gr.DrawLine(pen, x, min_price, x, min_price + dy);
                    }
                    for (int y = (int)min_price; y <= (int)max_price; y++)
                    {
                        gr.DrawLine(pen, 0, y, dx, y);
                    }

                    // Get a small distance in world coordinates.
                    dx = Math.Abs(dx / 5);
                    dy = Math.Abs(dy / 5);

                    // Draw the data.
                    PointF[] points = new PointF[num_points];
                    for (int i = 0; i < num_points; i++)
                    {
                        float price = (float)PriceList[i].Price;
                        points[i] = new PointF(i, price);
                        gr.FillRectangle(Brushes.Red,
                            i - dx, price - dy, 2 * dx, 2 * dy);
                    }
                    pen.Color = Color.Blue;
                    gr.DrawLines(pen, points);
                }
            }

            // Display the result.
            picGraph.Image = GraphBm;
        }

        // Return nicely formatted XML.
        private string FormatXml(XmlDocument doc)
        {
            using (StringWriter string_writer = new StringWriter())
            {
                XmlTextWriter xml_text_writer = new XmlTextWriter(string_writer);
                xml_text_writer.Formatting = Formatting.Indented;
                doc.WriteTo(xml_text_writer);
                return string_writer.ToString();
            }
        }

        // Redraw the graph.
        private void howto_graph_currency_rates_Form1_Resize(object sender, EventArgs e)
        {
            DrawGraph();
        }

        // Return a mapping matrix.
        private Matrix MappingMatrix(
            float wxmin, float wxmax, float wymin, float wymax,
            float dxmin, float dxmax, float dymin, float dymax)
        {
            RectangleF rect = new RectangleF(
                wxmin, wymin,
                wxmax - wxmin, wymax - wymin);
            PointF[] points =
            {
                new PointF(dxmin, dymax),
                new PointF(dxmax, dymax),
                new PointF(dxmin, dymin),
            };
            return new Matrix(rect, points);
        }

        // Display the data in a tooltip.
        private int LastTipNum = -1;
        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (DtoWMatrix == null) return;

            // Get the point in world coordinates.
            PointF[] points = { new PointF(e.X, e.Y) };
            DtoWMatrix.TransformPoints(points);

            // Get the tip number.
            int tip_num = -1;
            if (points[0].X >= 0) tip_num = (int)points[0].X;
            if (tip_num >= PriceList.Count) tip_num = -1;

            if (LastTipNum == tip_num) return;
            LastTipNum = tip_num;
            //Console.WriteLine(LastTipNum);

            string tip = null;
            if (tip_num >= 0) tip = PriceList[tip_num].ToString();
            tipData.SetToolTip(picGraph, tip);
            ShowDatePriceLines();
        }

        // Draw date and price lines for the mouse position.
        private void ShowDatePriceLines()
        {
            if (LastTipNum < 0) return;

            Bitmap bm = (Bitmap)GraphBm.Clone();
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Transform = WtoDMatrix;
                PriceData data = PriceList[LastTipNum];
                using (Pen pen = new Pen(Color.Red, 0))
                {
                    gr.DrawLine(pen, LastTipNum, 0, LastTipNum, 100000);
                    float price = (float)data.Price;
                    gr.DrawLine(pen, 0, price, 100*PriceList.Count, price);
                }
            }

            picGraph.Image = bm;
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGraph = new System.Windows.Forms.Button();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.tipData = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Currency:";
            // 
            // txtCurrency
            // 
            this.txtCurrency.Location = new System.Drawing.Point(76, 12);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(75, 20);
            this.txtCurrency.TabIndex = 0;
            this.txtCurrency.Text = "JPY";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(76, 38);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(75, 20);
            this.txtStartDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Date:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(76, 64);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(75, 20);
            this.txtEndDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "End Date:";
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(176, 36);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 3;
            this.btnGraph.Text = "Graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(12, 90);
            this.picGraph.MinimumSize = new System.Drawing.Size(10, 10);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(322, 159);
            this.picGraph.TabIndex = 6;
            this.picGraph.TabStop = false;
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            // 
            // howto_graph_currency_rates_Form1
            // 
            this.AcceptButton = this.btnGraph;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 261);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.label1);
            this.Name = "howto_graph_currency_rates_Form1";
            this.Text = "howto_graph_currency_rates";
            this.Load += new System.EventHandler(this.howto_graph_currency_rates_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_graph_currency_rates_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.ToolTip tipData;

    }
}

