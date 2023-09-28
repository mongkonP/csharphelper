using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_currency_rates_Form1:Form
  { 


        public howto_get_currency_rates_Form1()
        {
            InitializeComponent();
        }

        // Get the currency symbols.
        private void howto_get_currency_rates_Form1_Load(object sender, EventArgs e)
        {
            string url = "http://finance.yahoo.com/webservice/" +
                "v1/symbols/allcurrencies/quote?format=xml";
            try
            {
                // Load the data.
                XmlDocument doc = new XmlDocument();
                doc.Load(url);

                // Process the resource nodes.
                XmlNode root = doc.DocumentElement;
                string xquery = "descendant::resource[@classname='Quote']";
                foreach (XmlNode node in root.SelectNodes(xquery))
                {
                    const string name_query = "descendant::field[@name='name']";
                    const string price_query = "descendant::field[@name='price']";
                    string name = node.SelectSingleNode(name_query).InnerText;
                    string price = node.SelectSingleNode(price_query).InnerText;
                    decimal inverse = 1m / decimal.Parse(price);

                    ListViewItem item = lvwPrices.Items.Add(name);
                    item.SubItems.Add(price);
                    item.SubItems.Add(inverse.ToString("f6"));
                }

                // Sort.
                lvwPrices.Sorting = SortOrder.Ascending;
                lvwPrices.FullRowSelect = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Read Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            this.lvwPrices = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwPrices
            // 
            this.lvwPrices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPrices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwPrices.Location = new System.Drawing.Point(12, 12);
            this.lvwPrices.Name = "lvwPrices";
            this.lvwPrices.Size = new System.Drawing.Size(377, 237);
            this.lvwPrices.TabIndex = 0;
            this.lvwPrices.UseCompatibleStateImageBehavior = false;
            this.lvwPrices.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Price";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Inverse";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 100;
            // 
            // howto_get_currency_rates_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 261);
            this.Controls.Add(this.lvwPrices);
            this.Name = "howto_get_currency_rates_Form1";
            this.Text = "howto_get_currency_rates";
            this.Load += new System.EventHandler(this.howto_get_currency_rates_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwPrices;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

