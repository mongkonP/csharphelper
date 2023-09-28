using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_great_circle_distance;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_great_circle_distance_Form1:Form
  { 


        public howto_great_circle_distance_Form1()
        {
            InitializeComponent();
        }

        private const string Deg = "°";

        private void howto_great_circle_distance_Form1_Load(object sender, EventArgs e)
        {
            LoadCities();

            // Pick some random cities.
            Random rand = new Random();
            cboCity1.SelectedIndex = rand.Next(cboCity1.Items.Count);
            cboCity2.SelectedIndex = rand.Next(cboCity2.Items.Count);
        }

        // Calculate the distance.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Parse the latitudes and longitudes.
            double lat1 = ParseLatLon(txtLat1.Text);
            double lon1 = ParseLatLon(txtLon1.Text);
            double lat2 = ParseLatLon(txtLat2.Text);
            double lon2 = ParseLatLon(txtLon2.Text);

            // Display the distance.
            double distance = GreatCircleDistance(lat1, lon1, lat2, lon2);
            lblDistance.Text = Math.Round(distance).ToString() + " km";
        }

        // Parse a latitude or longitude.
        private double ParseLatLon(string str)
        {
            str = str.ToUpper().Replace(Deg, " ").Replace("'", " ").Replace("\"", " ");
            str = str.Replace("S", " S").Replace("N", " N");
            str = str.Replace("E", " E").Replace("W", " W");
            char[] separators = {' '};
            string[] fields = str.Split(separators,
                StringSplitOptions.RemoveEmptyEntries);

            double result =             // Degrees.
                double.Parse(fields[0]);
            if (fields.Length > 2)      // Minutes.
                result += double.Parse(fields[1]) / 60;
            if (fields.Length > 3)      // Seconds.
                result += double.Parse(fields[2]) / 3600;
            if (str.Contains('S') || str.Contains('W')) result *= -1;
            return result;
        }

        // Calculate the great circle distance between two points.
        private double GreatCircleDistance(
            double lat1, double lon1, double lat2, double lon2)
        {
            const double radius = 6371; // Radius of the Earth in km.
            lat1 = DegreesToRadians(lat1);
            lon1 = DegreesToRadians(lon1);
            lat2 = DegreesToRadians(lat2);
            lon2 = DegreesToRadians(lon2);
            double d_lat = lat2 - lat1;
            double d_lon = lon2 - lon1;
            double h = Math.Sin(d_lat / 2) * Math.Sin(d_lat / 2) +
                Math.Cos(lat1) * Math.Cos(lat2) *
                Math.Sin(d_lon / 2) * Math.Sin(d_lon / 2);
            return 2 * radius * Math.Asin(Math.Sqrt(h));
        }

        // Convert the degrees into radians.
        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        // Load latitude and longitude data for major cities. Data from:
        // https://www.infoplease.com/world/world-geography/major-cities-latitude-longitude-and-corresponding-time-zones
        private void LoadCities()
        {
            string[] city_data = {
                "Aberdeen, Scotland;57;9 N;2;9 W",
                "Adelaide, Australia;34;55 S;138;36 E",
                "Algiers, Algeria;36;50 N;3;0 E",
                "Amsterdam, Netherlands;52;22 N;4;53 E",
                "Ankara, Turkey;39;55 N;32;55 E",
                "Asunción, Paraguay;25;15 S;57;40 W",
                "Athens, Greece;37;58 N;23;43 E",
                "Auckland, New Zealand;36;52 S;174;45 E",
                "Bangkok, Thailand;13;45 N;100;30 E",
                "Barcelona, Spain;41;23 N;2;9 E",
                "Beijing, China;39;55 N;116;25 E",
                "Belém, Brazil;1;28 S;48;29 W",
                "Belfast, Northern Ireland;54;37 N;5;56 W",
                "Belgrade, Serbia;44;52 N;20;32 E",
                "Berlin, Germany;52;30 N;13;25 E",
                "Birmingham, England;52;25 N;1;55 W",
                "Bogotá, Colombia;4;32 N;74;15 W",
                "Bombay, India;19;0 N;72;48 E",
                "Bordeaux, France;44;50 N;0;31 W",
                "Bremen, Germany;53;5 N;8;49 E",
                "Brisbane, Australia;27;29 S;153;8 E",
                "Bristol, England;51;28 N;2;35 W",
                "Brussels, Belgium;50;52 N;4;22 E",
                "Bucharest, Romania;44;25 N;26;7 E",
                "Budapest, Hungary;47;30 N;19;5 E",
                "Buenos Aires, Argentina;34;35 S;58;22 W",
                "Cairo, Egypt;30;2 N;31;21 E",
                "Calcutta, India;22;34 N;88;24 E",
                "Canton, China;23;7 N;113;15 E",
                "Cape Town, South Africa;33;55 S;18;22 E",
                "Caracas, Venezuela;10;28 N;67;2 W",
                "Cayenne, French Guiana;4;49 N;52;18 W",
                "Chihuahua, Mexico;28;37 N;106;5 W",
                "Chongqing, China;29;46 N;106;34 E",
                "Copenhagen, Denmark;55;40 N;12;34 E",
                "Córdoba, Argentina;31;28 S;64;10 W",
                "Dakar, Senegal;14;40 N;17;28 W",
                "Darwin, Australia;12;28 S;130;51 E",
                "Djibouti, Djibouti;11;30 N;43;3 E",
                "Dublin, Ireland;53;20 N;6;15 W",
                "Durban, South Africa;29;53 S;30;53 E",
                "Edinburgh, Scotland;55;55 N;3;10 W",
                "Frankfurt, Germany;50;7 N;8;41 E",
                "Georgetown, Guyana;6;45 N;58;15 W",
                "Glasgow, Scotland;55;50 N;4;15 W",
                "Guatemala City, Guatemala;14;37 N;90;31 W",
                "Guayaquil, Ecuador;2;10 S;79;56 W",
                "Hamburg, Germany;53;33 N;10;2 E",
                "Hammerfest, Norway;70;38 N;23;38 E",
                "Havana, Cuba;23;8 N;82;23 W",
                "Helsinki, Finland;60;10 N;25;0 E",
                "Hobart, Tasmania;42;52 S;147;19 E",
                "Hong Kong, China;22;20 N;114;11 E",
                "Iquique, Chile;20;10 S;70;7 W",
                "Irkutsk, Russia;52;30 N;104;20 E",
                "Jakarta, Indonesia;6;16 S;106;48 E",
                "Johannesburg, South Africa;26;12 S;28;4 E",
                "Kingston, Jamaica;17;59 N;76;49 W",
                "Kinshasa, Congo;4;18 S;15;17 E",
                "Kuala Lumpur, Malaysia;3;8 N;101;42 E",
                "La Paz, Bolivia;16;27 S;68;22 W",
                "Leeds, England;53;45 N;1;30 W",
                "Lima, Peru;12;0 S;77;2 W",
                "Lisbon, Portugal;38;44 N;9;9 W",
                "Liverpool, England;53;25 N;3;0 W",
                "London, England;51;32 N;0;5 W",
                "Lyons, France;45;45 N;4;50 E",
                "Madrid, Spain;40;26 N;3;42 W",
                "Manchester, England;53;30 N;2;15 W",
                "Manila, Philippines;14;35 N;120;57 E",
                "Marseilles, France;43;20 N;5;20 E",
                "Mazatlán, Mexico;23;12 N;106;25 W",
                "Mecca, Saudi Arabia;21;29 N;39;45 E",
                "Melbourne, Australia;37;47 S;144;58 E",
                "Mexico City, Mexico;19;26 N;99;7 W",
                "Milan, Italy;45;27 N;9;10 E",
                "Montevideo, Uruguay;34;53 S;56;10 W",
                "Moscow, Russia;55;45 N;37;36 E",
                "Munich, Germany;48;8 N;11;35 E",
                "Nagasaki, Japan;32;48 N;129;57 E",
                "Nagoya, Japan;35;7 N;136;56 E",
                "Nairobi, Kenya;1;25 S;36;55 E",
                "Nanjing (Nanking), China;32;3 N;118;53 E",
                "Naples, Italy;40;50 N;14;15 E",
                "New Delhi, India;28;35 N;77;12 E",
                "Newcastle-on-Tyne, England;54;58 N;1;37 W",
                "Odessa, Ukraine;46;27 N;30;48 E",
                "Osaka, Japan;34;32 N;135;30 E",
                "Oslo, Norway;59;57 N;10;42 E",
                "Panama City, Panama;8;58 N;79;32 W",
                "Paramaribo, Suriname;5;45 N;55;15 W",
                "Paris, France;48;48 N;2;20 E",
                "Perth, Australia;31;57 S;115;52 E",
                "Plymouth, England;50;25 N;4;5 W",
                "Port Moresby, Papua New Guinea;9;25 S;147;8 E",
                "Prague, Czech Republic;50;5 N;14;26 E",
                "Rangoon, Myanmar;16;50 N;96;0 E",
                "Reykjavík, Iceland;64;4 N;21;58 W",
                "Rio de Janeiro, Brazil;22;57 S;43;12 W",
                "Rome, Italy;41;54 N;12;27 E",
                "Salvador, Brazil;12;56 S;38;27 W",
                "Santiago, Chile;33;28 S;70;45 W",
                "St. Petersburg, Russia;59;56 N;30;18 E",
                "São Paulo, Brazil;23;31 S;46;31 W",
                "Shanghai, China;31;10 N;121;28 E",
                "Singapore, Singapore;1;14 N;103;55 E",
                "Sofia, Bulgaria;42;40 N;23;20 E",
                "Stockholm, Sweden;59;17 N;18;3 E",
                "Sydney, Australia;34;0 S;151;0 E",
                "Tananarive, Madagascar;18;50 S;47;33 E",
                "Teheran, Iran;35;45 N;51;45 E",
                "Tokyo, Japan;35;40 N;139;45 E",
                "Tripoli, Libya;32;57 N;13;12 E",
                "Venice, Italy;45;26 N;12;20 E",
                "Veracruz, Mexico;19;10 N;96;10 W",
                "Vienna, Austria;48;14 N;16;20 E",
                "Vladivostok, Russia;43;10 N;132;0 E",
                "Warsaw, Poland;52;14 N;21;0 E",
                "Wellington, New Zealand;41;17 S;174;47 E",
                "Zürich, Switzerland;47;21 N;8;31 E",
            };
            foreach (string line in city_data)
            {
                string[] fields = line.Split(';');

                fields[2] = fields[2].Replace(" ", "' ");
                string lat = fields[1] + " " + fields[2];
                fields[4] = fields[4].Replace(" ", "' ");
                string lon = fields[3] + " " + fields[4];

                cboCity1.Items.Add(new LatLon(fields[0], lat, lon));
                cboCity2.Items.Add(new LatLon(fields[0], lat, lon));
            }
        }

        // Fill in the latitude and longitude for this city.
        private void cboCity1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LatLon latlon = (LatLon)cboCity1.SelectedItem;
            txtLat1.Text = latlon.Lat;
            txtLon1.Text = latlon.Lon;
            lblDistance.Text = "";
        }
        private void cboCity2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LatLon latlon = (LatLon)cboCity2.SelectedItem;
            txtLat2.Text = latlon.Lat;
            txtLon2.Text = latlon.Lon;
            lblDistance.Text = "";
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtLat1 = new System.Windows.Forms.TextBox();
            this.txtLon1 = new System.Windows.Forms.TextBox();
            this.txtLon2 = new System.Windows.Forms.TextBox();
            this.txtLat2 = new System.Windows.Forms.TextBox();
            this.cboCity1 = new System.Windows.Forms.ComboBox();
            this.cboCity2 = new System.Windows.Forms.ComboBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Latitude:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Longitude:";
            // 
            // txtLat1
            // 
            this.txtLat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLat1.Location = new System.Drawing.Point(73, 28);
            this.txtLat1.Name = "txtLat1";
            this.txtLat1.Size = new System.Drawing.Size(138, 20);
            this.txtLat1.TabIndex = 2;
            this.txtLat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLon1
            // 
            this.txtLon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLon1.Location = new System.Drawing.Point(73, 53);
            this.txtLon1.Name = "txtLon1";
            this.txtLon1.Size = new System.Drawing.Size(138, 20);
            this.txtLon1.TabIndex = 4;
            this.txtLon1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLon2
            // 
            this.txtLon2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLon2.Location = new System.Drawing.Point(217, 53);
            this.txtLon2.Name = "txtLon2";
            this.txtLon2.Size = new System.Drawing.Size(138, 20);
            this.txtLon2.TabIndex = 5;
            this.txtLon2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLat2
            // 
            this.txtLat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLat2.Location = new System.Drawing.Point(217, 28);
            this.txtLat2.Name = "txtLat2";
            this.txtLat2.Size = new System.Drawing.Size(138, 20);
            this.txtLat2.TabIndex = 3;
            this.txtLat2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboCity1
            // 
            this.cboCity1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCity1.FormattingEnabled = true;
            this.cboCity1.Location = new System.Drawing.Point(73, 3);
            this.cboCity1.Name = "cboCity1";
            this.cboCity1.Size = new System.Drawing.Size(138, 21);
            this.cboCity1.TabIndex = 0;
            this.cboCity1.SelectedIndexChanged += new System.EventHandler(this.cboCity1_SelectedIndexChanged);
            // 
            // cboCity2
            // 
            this.cboCity2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCity2.FormattingEnabled = true;
            this.cboCity2.Location = new System.Drawing.Point(217, 3);
            this.cboCity2.Name = "cboCity2";
            this.cboCity2.Size = new System.Drawing.Size(138, 21);
            this.cboCity2.TabIndex = 1;
            this.cboCity2.SelectedIndexChanged += new System.EventHandler(this.cboCity2_SelectedIndexChanged);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnCalculate, 3);
            this.btnCalculate.Location = new System.Drawing.Point(141, 91);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cboCity2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboCity1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtLon2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtLat1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLon1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtLat2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCalculate, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDistance, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(358, 156);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Distance:";
            // 
            // lblDistance
            // 
            this.lblDistance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistance.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblDistance, 2);
            this.lblDistance.Location = new System.Drawing.Point(73, 137);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(0, 13);
            this.lblDistance.TabIndex = 10;
            // 
            // howto_great_circle_distance_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 181);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_great_circle_distance_Form1";
            this.Text = "howto_great_circle_distance";
            this.Load += new System.EventHandler(this.howto_great_circle_distance_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLat1;
        private System.Windows.Forms.TextBox txtLon1;
        private System.Windows.Forms.TextBox txtLon2;
        private System.Windows.Forms.TextBox txtLat2;
        private System.Windows.Forms.ComboBox cboCity1;
        private System.Windows.Forms.ComboBox cboCity2;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDistance;
    }
}

