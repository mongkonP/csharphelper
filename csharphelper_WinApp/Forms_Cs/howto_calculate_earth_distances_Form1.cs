using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

 

using howto_calculate_earth_distances;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_calculate_earth_distances_Form1:Form
  { 


        public howto_calculate_earth_distances_Form1()
        {
            InitializeComponent();
        }

        // Some test values:
        //     Mumbai to Canberra           6238.51
        //     Beijing to Berlin            4667.81
        //     San Diego to Los Angeles      111.57
        //     San Diego to San Francisco    458.17
        //     Los Angeles to San Francisco  347.16

        // Locations of known cities.
        private CityData[] Cities =
        {
            new CityData("Rome 	41°48′N 12°36′E"),
            new CityData("Tokyo 	35°40′N 139°45′E"),
            new CityData("Mexico City 	19°24′N 99°09′W"),
            new CityData("London 	51°30′N 0°10′W"),
            new CityData("New York City 	40°43′N 74°00′W"),
            new CityData("Los Angeles 	34°03′N 118°15′W"),
            new CityData("Canberra 	35°17′S 149°08′E"),
            new CityData("Berlin 	52°32′N 13°25′E"),
            new CityData("Rome 	41°48′N 12°36′E"),
            new CityData("Cairo 	30°03′N 31°15′E"),
            new CityData("Beijing 	39°55′N 116°26′E"),
            new CityData("Moscow 	55°45′N 37°42′E"),
            new CityData("Rio de Janeiro 	22°54′S 43°14′W"),
            new CityData("Mumbai 	18°56′N 74°35′E"),
            new CityData("San Diego 	32°42′N 117°10′W"),
            new CityData("San Francisco 	37°47′N 122°26′W"),
        };

        // Load the list of cities.
        private void howto_calculate_earth_distances_Form1_Load(object sender, EventArgs e)
        {
            var city_query =
                from CityData city_data in Cities
                orderby city_data.Name
                select city_data.Name;
            cboCityFrom.DataSource = city_query.ToArray();
            cboCityTo.DataSource = city_query.ToArray();
            cboCityTo.SelectedIndex = 1;
        }

        // Display the latitude and longitude for the selected city.
        private void cboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Find the selected city.
            var city_query =
                from CityData city_data in Cities
                where (city_data.Name == cboCityFrom.Text)
                select city_data;

            // Display the latitude and longitude.
            CityData city = city_query.First();
            txtLatitudeFrom.Text = city.Latitude.ToString("0.0000");
            txtLongitudeFrom.Text = city.Longitude.ToString("0.0000");
        }
        private void cboCityTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Find the selected city.
            var city_query =
                from CityData city_data in Cities
                where (city_data.Name == cboCityTo.Text)
                select city_data;

            // Display the latitude and longitude.
            CityData city = city_query.First();
            txtLatitudeTo.Text = city.Latitude.ToString("0.0000");
            txtLongitudeTo.Text = city.Longitude.ToString("0.0000");
        }

        // Calculate the distances.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Get the entered latitudes and longitudes.
            double lat_from = double.Parse(txtLatitudeFrom.Text);
            if (lat_from < 0) lat_from += 360;

            double lon_from = double.Parse(txtLongitudeFrom.Text);
            if (lon_from < 0) lon_from += 360;

            double lat_to = double.Parse(txtLatitudeTo.Text);
            if (lat_to < 0) lat_to += 360;

            double lon_to = double.Parse(txtLongitudeTo.Text);
            if (lon_to < 0) lon_to += 360;

            // Calculate the differences in latitude and longitude.
            double dlat = Math.Abs(lat_from - lat_to);
            if (dlat > 180) dlat = 360 - dlat;

            double dlon = Math.Abs(lon_from - lon_to);
            if (dlon > 180) dlon = 360 - dlon;

            // Flat Earth.
            txtMethod1.Text = FlatEarth(lat_from, lon_from,
                lat_to, lon_to).ToString("0.0000");

            // Haversine.
            txtMethod2.Text = Haversine(lat_from, lon_from,
                lat_to, lon_to).ToString("0.0000");
        }

        // Methods for calculating distances.
        private const double EarthRadius = 3958.756;
        private double FlatEarth(double lat1, double lon1, double lat2, double lon2)
        {
            // Calculate the differences in latitude and longitude.
            double dlat = Math.Abs(lat1 - lat2);
            if (dlat > 180) dlat = 360 - dlat;

            double dlon = Math.Abs(lon1 - lon2);
            if (dlon > 180) dlon = 360 - dlon;

            double x = 69.1 * dlat;
            double y = 53.0 * dlon;
            return Math.Sqrt(x * x + y * y);
        }

        private double Haversine(double lat1, double lon1, double lat2, double lon2)
        {
            double dlat = DegreesToRadians(lat2 - lat1);
            double dlon = DegreesToRadians(lon2 - lon1);
            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                Math.Cos(DegreesToRadians(lat1)) *
                Math.Cos(DegreesToRadians(lat2)) *
                Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
            return 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)) * EarthRadius;
        }

        // Convert degrees into radians.
        private double DegreesToRadians(double degrees)
        {
            return degrees / 180 * Math.PI;
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
            this.txtLatitudeFrom = new System.Windows.Forms.TextBox();
            this.txtLongitudeFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCityFrom = new System.Windows.Forms.ComboBox();
            this.txtMethod2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMethod1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCityTo = new System.Windows.Forms.ComboBox();
            this.txtLongitudeTo = new System.Windows.Forms.TextBox();
            this.txtLatitudeTo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Latitude:";
            // 
            // txtLatitudeFrom
            // 
            this.txtLatitudeFrom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLatitudeFrom.Location = new System.Drawing.Point(105, 60);
            this.txtLatitudeFrom.Name = "txtLatitudeFrom";
            this.txtLatitudeFrom.Size = new System.Drawing.Size(100, 20);
            this.txtLatitudeFrom.TabIndex = 2;
            this.txtLatitudeFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLongitudeFrom
            // 
            this.txtLongitudeFrom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLongitudeFrom.Location = new System.Drawing.Point(105, 86);
            this.txtLongitudeFrom.Name = "txtLongitudeFrom";
            this.txtLongitudeFrom.Size = new System.Drawing.Size(100, 20);
            this.txtLongitudeFrom.TabIndex = 3;
            this.txtLongitudeFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Longitude:";
            // 
            // cboCityFrom
            // 
            this.cboCityFrom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboCityFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCityFrom.FormattingEnabled = true;
            this.cboCityFrom.Location = new System.Drawing.Point(105, 33);
            this.cboCityFrom.Name = "cboCityFrom";
            this.cboCityFrom.Size = new System.Drawing.Size(100, 21);
            this.cboCityFrom.TabIndex = 0;
            this.cboCityFrom.SelectedIndexChanged += new System.EventHandler(this.cboCity_SelectedIndexChanged);
            // 
            // txtMethod2
            // 
            this.txtMethod2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMethod2.Location = new System.Drawing.Point(105, 167);
            this.txtMethod2.Name = "txtMethod2";
            this.txtMethod2.Size = new System.Drawing.Size(100, 20);
            this.txtMethod2.TabIndex = 8;
            this.txtMethod2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Haversine:";
            // 
            // txtMethod1
            // 
            this.txtMethod1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMethod1.Location = new System.Drawing.Point(105, 141);
            this.txtMethod1.Name = "txtMethod1";
            this.txtMethod1.Size = new System.Drawing.Size(100, 20);
            this.txtMethod1.TabIndex = 7;
            this.txtMethod1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Flat Earth:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCalculate.Location = new System.Drawing.Point(175, 112);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.Location = new System.Drawing.Point(105, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "From:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.Location = new System.Drawing.Point(225, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 21);
            this.label6.TabIndex = 14;
            this.label6.Text = "To:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboCityTo
            // 
            this.cboCityTo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboCityTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCityTo.FormattingEnabled = true;
            this.cboCityTo.Location = new System.Drawing.Point(225, 33);
            this.cboCityTo.Name = "cboCityTo";
            this.cboCityTo.Size = new System.Drawing.Size(100, 21);
            this.cboCityTo.TabIndex = 1;
            this.cboCityTo.SelectedIndexChanged += new System.EventHandler(this.cboCityTo_SelectedIndexChanged);
            // 
            // txtLongitudeTo
            // 
            this.txtLongitudeTo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLongitudeTo.Location = new System.Drawing.Point(225, 86);
            this.txtLongitudeTo.Name = "txtLongitudeTo";
            this.txtLongitudeTo.Size = new System.Drawing.Size(100, 20);
            this.txtLongitudeTo.TabIndex = 5;
            this.txtLongitudeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLatitudeTo
            // 
            this.txtLatitudeTo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLatitudeTo.Location = new System.Drawing.Point(225, 60);
            this.txtLatitudeTo.Name = "txtLatitudeTo";
            this.txtLatitudeTo.Size = new System.Drawing.Size(100, 20);
            this.txtLatitudeTo.TabIndex = 4;
            this.txtLatitudeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_calculate_earth_distances_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 201);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCityTo);
            this.Controls.Add(this.txtLongitudeTo);
            this.Controls.Add(this.txtLatitudeTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtMethod2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMethod1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCityFrom);
            this.Controls.Add(this.txtLongitudeFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLatitudeFrom);
            this.Controls.Add(this.label1);
            this.Name = "howto_calculate_earth_distances_Form1";
            this.Text = "howto_calculate_earth_distances";
            this.Load += new System.EventHandler(this.howto_calculate_earth_distances_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLatitudeFrom;
        private System.Windows.Forms.TextBox txtLongitudeFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCityFrom;
        private System.Windows.Forms.TextBox txtMethod2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMethod1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCityTo;
        private System.Windows.Forms.TextBox txtLongitudeTo;
        private System.Windows.Forms.TextBox txtLatitudeTo;
    }
}

