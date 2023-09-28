using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to System.Web.
using System.Web;
using System.Diagnostics;
using System.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_address_maps_Form1:Form
  { 


        public howto_address_maps_Form1()
        {
            InitializeComponent();
        }

        // Select default map types.
        private void howto_address_maps_Form1_Load(object sender, EventArgs e)
        {
            cboGoogle.SelectedIndex = 0;
        }

        // Display a Google map.
        private void btnGoogle_Click(object sender, EventArgs e)
        {
            // Get the Google maps URL with defult zoom.
            string url = GoogleMapUrl(txtAddress.Text, cboGoogle.Text, 0);

            // Display the URL in the default browser.
            Process.Start(url);
        }

        // Return a Google map URL.
        // The URL format is:
        //      http://maps.google.com/maps?q=QUERY&t=TYPE&z=ZOOM
        //  Where:
        //      QUERY is the query. If it begins with "loc:" then its latitude+longitude.
        //      TYPE is map type:
        //          m = Map
        //          k = Satellite
        //          h = Hybrid
        //          p = Terrain
        //          e = Google Earth
        //      ZOOM is the zoom level, usually 1 - 20.
        private string GoogleMapUrl(string query, string map_type, int zoom)
        {
            // Start with the base map URL.
            string url = "http://maps.google.com/maps?";

            // Add the query.
            url += "q=" + HttpUtility.UrlEncode(query, Encoding.UTF8);

            // Add the type.
            map_type = GoogleMapTypeCode(map_type);
            if (map_type != null) url += "&t=" + map_type;

            // Add the zoom level.
            if (zoom > 0) url += "&z=" + zoom.ToString();

            return url;
        }

        // Return a Google map type code.
        private string GoogleMapTypeCode(string map_type)
        {
            // Insert the proper type.
            switch (map_type)
            {
                case "Map":
                    return "m";
                case "Satellite":
                    return "k";
                case "Hybrid":
                    return "h";
                case "Terrain":
                    return "p";
                case "Google Earth":
                    return "e";
                default:
                    return null;
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
            this.cboGoogle = new System.Windows.Forms.ComboBox();
            this.btnGoogle = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboGoogle
            // 
            this.cboGoogle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboGoogle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGoogle.FormattingEnabled = true;
            this.cboGoogle.Items.AddRange(new object[] {
            "Map",
            "Satellite",
            "Hybrid",
            "Terrain",
            "Google Earth"});
            this.cboGoogle.Location = new System.Drawing.Point(88, 52);
            this.cboGoogle.Name = "cboGoogle";
            this.cboGoogle.Size = new System.Drawing.Size(115, 21);
            this.cboGoogle.TabIndex = 15;
            // 
            // btnGoogle
            // 
            this.btnGoogle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGoogle.Location = new System.Drawing.Point(209, 45);
            this.btnGoogle.Name = "btnGoogle";
            this.btnGoogle.Size = new System.Drawing.Size(88, 32);
            this.btnGoogle.TabIndex = 14;
            this.btnGoogle.Text = "Google";
            this.btnGoogle.UseVisualStyleBackColor = true;
            this.btnGoogle.Click += new System.EventHandler(this.btnGoogle_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(66, 12);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(306, 20);
            this.txtAddress.TabIndex = 13;
            this.txtAddress.Text = "1600 Pennsylvania Avenue; NW Washington, D.C. 20500";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(48, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Address:";
            // 
            // howto_address_maps_Form1
            // 
            this.AcceptButton = this.btnGoogle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 89);
            this.Controls.Add(this.cboGoogle);
            this.Controls.Add(this.btnGoogle);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.Label1);
            this.Name = "howto_address_maps_Form1";
            this.Text = "howto_address_maps";
            this.Load += new System.EventHandler(this.howto_address_maps_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cboGoogle;
        internal System.Windows.Forms.Button btnGoogle;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label Label1;
    }
}

