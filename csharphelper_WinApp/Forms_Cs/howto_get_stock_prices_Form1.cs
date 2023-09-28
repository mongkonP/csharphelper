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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_stock_prices_Form1:Form
  { 


        public howto_get_stock_prices_Form1()
        {
            InitializeComponent();
        }

        // Get the stock prices.
        private void btnGetPrices_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // Build the URL.
            string url = "";
            if (txtSymbol1.Text != "") url += txtSymbol1.Text + "+";
            if (txtSymbol2.Text != "") url += txtSymbol2.Text + "+";
            if (txtSymbol3.Text != "") url += txtSymbol3.Text + "+";
            if (txtSymbol4.Text != "") url += txtSymbol4.Text + "+";
            if (url != "")
            {
                // Remove the trailing plus sign.
                url = url.Substring(0, url.Length - 1);

                // Prepend the base URL.
                const string base_url =
                    "http://download.finance.yahoo.com/d/quotes.csv?s=@&f=sl1d1t1c1";
                url = base_url.Replace("@", url);

                // Get the response.
                try
                {
                    // Get the web response.
                    string result = GetWebResponse(url);
                    Console.WriteLine(result.Replace("\\r\\n", "\r\n"));

                    // Pull out the current prices.
                    string[] lines = result.Split(
                        new char[] { '\r', '\n' },
                        StringSplitOptions.RemoveEmptyEntries);
                    txtPrice1.Text = FormatCurrency(lines[0].Split(',')[1]);
                    txtPrice2.Text = FormatCurrency(lines[1].Split(',')[1]);
                    txtPrice3.Text = FormatCurrency(lines[2].Split(',')[1]);
                    txtPrice4.Text = FormatCurrency(lines[3].Split(',')[1]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Read Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            this.Cursor = Cursors.Default;
        }

        // Return a number formatted as currency or
        // a blank string if the text isn't a number.
        private string FormatCurrency(string text)
        {
            decimal value;
            if (decimal.TryParse(text, out value)) return value.ToString("C3");
            return "";
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSymbol1 = new System.Windows.Forms.TextBox();
            this.txtSymbol2 = new System.Windows.Forms.TextBox();
            this.txtSymbol4 = new System.Windows.Forms.TextBox();
            this.txtSymbol3 = new System.Windows.Forms.TextBox();
            this.btnGetPrices = new System.Windows.Forms.Button();
            this.txtPrice4 = new System.Windows.Forms.TextBox();
            this.txtPrice3 = new System.Windows.Forms.TextBox();
            this.txtPrice2 = new System.Windows.Forms.TextBox();
            this.txtPrice1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Symbol";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSymbol1
            // 
            this.txtSymbol1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSymbol1.Location = new System.Drawing.Point(32, 25);
            this.txtSymbol1.Name = "txtSymbol1";
            this.txtSymbol1.Size = new System.Drawing.Size(54, 20);
            this.txtSymbol1.TabIndex = 1;
            this.txtSymbol1.Text = "DIS";
            // 
            // txtSymbol2
            // 
            this.txtSymbol2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSymbol2.Location = new System.Drawing.Point(32, 51);
            this.txtSymbol2.Name = "txtSymbol2";
            this.txtSymbol2.Size = new System.Drawing.Size(54, 20);
            this.txtSymbol2.TabIndex = 2;
            this.txtSymbol2.Text = "DIS.L";
            // 
            // txtSymbol4
            // 
            this.txtSymbol4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSymbol4.Location = new System.Drawing.Point(32, 103);
            this.txtSymbol4.Name = "txtSymbol4";
            this.txtSymbol4.Size = new System.Drawing.Size(54, 20);
            this.txtSymbol4.TabIndex = 4;
            this.txtSymbol4.Text = "DIS.HK";
            // 
            // txtSymbol3
            // 
            this.txtSymbol3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSymbol3.Location = new System.Drawing.Point(32, 77);
            this.txtSymbol3.Name = "txtSymbol3";
            this.txtSymbol3.Size = new System.Drawing.Size(54, 20);
            this.txtSymbol3.TabIndex = 3;
            this.txtSymbol3.Text = "DIS.MI";
            // 
            // btnGetPrices
            // 
            this.btnGetPrices.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGetPrices.Location = new System.Drawing.Point(107, 56);
            this.btnGetPrices.Name = "btnGetPrices";
            this.btnGetPrices.Size = new System.Drawing.Size(75, 23);
            this.btnGetPrices.TabIndex = 5;
            this.btnGetPrices.Text = "Get Prices";
            this.btnGetPrices.UseVisualStyleBackColor = true;
            this.btnGetPrices.Click += new System.EventHandler(this.btnGetPrices_Click);
            // 
            // txtPrice4
            // 
            this.txtPrice4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPrice4.Location = new System.Drawing.Point(203, 103);
            this.txtPrice4.Name = "txtPrice4";
            this.txtPrice4.ReadOnly = true;
            this.txtPrice4.Size = new System.Drawing.Size(54, 20);
            this.txtPrice4.TabIndex = 10;
            this.txtPrice4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrice3
            // 
            this.txtPrice3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPrice3.Location = new System.Drawing.Point(203, 77);
            this.txtPrice3.Name = "txtPrice3";
            this.txtPrice3.ReadOnly = true;
            this.txtPrice3.Size = new System.Drawing.Size(54, 20);
            this.txtPrice3.TabIndex = 9;
            this.txtPrice3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrice2
            // 
            this.txtPrice2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPrice2.Location = new System.Drawing.Point(203, 51);
            this.txtPrice2.Name = "txtPrice2";
            this.txtPrice2.ReadOnly = true;
            this.txtPrice2.Size = new System.Drawing.Size(54, 20);
            this.txtPrice2.TabIndex = 8;
            this.txtPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrice1
            // 
            this.txtPrice1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPrice1.Location = new System.Drawing.Point(203, 25);
            this.txtPrice1.Name = "txtPrice1";
            this.txtPrice1.ReadOnly = true;
            this.txtPrice1.Size = new System.Drawing.Size(54, 20);
            this.txtPrice1.TabIndex = 7;
            this.txtPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Location = new System.Drawing.Point(203, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Prices";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_get_stock_prices_Form1
            // 
            this.AcceptButton = this.btnGetPrices;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 135);
            this.Controls.Add(this.txtPrice4);
            this.Controls.Add(this.txtPrice3);
            this.Controls.Add(this.txtPrice2);
            this.Controls.Add(this.txtPrice1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGetPrices);
            this.Controls.Add(this.txtSymbol4);
            this.Controls.Add(this.txtSymbol3);
            this.Controls.Add(this.txtSymbol2);
            this.Controls.Add(this.txtSymbol1);
            this.Controls.Add(this.label1);
            this.Name = "howto_get_stock_prices_Form1";
            this.Text = "howto_get_stock_prices";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSymbol1;
        private System.Windows.Forms.TextBox txtSymbol2;
        private System.Windows.Forms.TextBox txtSymbol4;
        private System.Windows.Forms.TextBox txtSymbol3;
        private System.Windows.Forms.Button btnGetPrices;
        private System.Windows.Forms.TextBox txtPrice4;
        private System.Windows.Forms.TextBox txtPrice3;
        private System.Windows.Forms.TextBox txtPrice2;
        private System.Windows.Forms.TextBox txtPrice1;
        private System.Windows.Forms.Label label2;
    }
}

