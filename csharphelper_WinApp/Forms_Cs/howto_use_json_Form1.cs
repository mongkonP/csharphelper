using System;
using System.Collections.Generic;
using System.Windows.Forms;

 

using howto_use_json;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_use_json_Form1:Form
  { 


        public howto_use_json_Form1()
        {
            InitializeComponent();
        }

        private void howto_use_json_Form1_Load(object sender, EventArgs e)
        {
            // Make an object to serialize.
            Customer cust = new Customer()
            {
                Name = "Rod Stephens",
                Street = "1337 Leet St",
                City = "Bugsville",
                State = "CA",
                Zip = "98765",
                PhoneNumbers = new Dictionary<string, string>()
                {
                    {"Home", "111-222-3333"},
                    {"Cell", "222-333-4444"},
                    {"Work", "333-444-5555"},
                },
                EmailAddresses = new List<string>()
                {
                    "somewhere@someplace.com",
                    "nowhere@noplace.com",
                    "root@everywhere.org",
                },
            };
            cust.Orders = new Order[3];
            cust.Orders[0] = new Order()
            {
                Description = "Pencils, dozen",
                Quantity = 10,
                Price = 1.13m
            };
            cust.Orders[1] = new Order()
            {
                Description = "Notepad",
                Quantity = 3,
                Price = 0.99m
            };
            cust.Orders[2] = new Order()
            {
                Description = "Cookies",
                Quantity = 1,
                Price = 3.75m
            };

            // Display the serialization.
            string serialization = cust.ToJson();
            txtJson.Text = serialization;
            txtJson.Select(0, 0);
            
            // Deserialize.
            Customer new_cust = Customer.FromJson(serialization);
            txtProperties.Text = new_cust.ToString();
            txtProperties.Select(0, 0);
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
            this.txtProperties = new System.Windows.Forms.TextBox();
            this.txtJson = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProperties
            // 
            this.txtProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProperties.Location = new System.Drawing.Point(222, 23);
            this.txtProperties.Multiline = true;
            this.txtProperties.Name = "txtProperties";
            this.txtProperties.Size = new System.Drawing.Size(214, 222);
            this.txtProperties.TabIndex = 4;
            // 
            // txtJson
            // 
            this.txtJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJson.Location = new System.Drawing.Point(3, 23);
            this.txtJson.Multiline = true;
            this.txtJson.Name = "txtJson";
            this.txtJson.Size = new System.Drawing.Size(213, 222);
            this.txtJson.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtProperties, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtJson, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(439, 248);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "JSON:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Properties:";
            // 
            // howto_use_json_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 258);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_use_json_Form1";
            this.Text = "howto_use_json";
            this.Load += new System.EventHandler(this.howto_use_json_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtProperties;
        private System.Windows.Forms.TextBox txtJson;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

