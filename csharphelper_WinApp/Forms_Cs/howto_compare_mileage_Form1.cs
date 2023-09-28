using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

 

using howto_compare_mileage;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_compare_mileage_Form1:Form
  { 


        public howto_compare_mileage_Form1()
        {
            InitializeComponent();
        }

        private class CarData
        {
            public string Name;
            public float CityMileage, HwyMileage, BaseCost;
            public CarData(string name, float city_mileage, float hwy_mileage, float base_cost)
            {
                Name = name;
                CityMileage = city_mileage;
                HwyMileage = hwy_mileage;
                BaseCost = base_cost;
            }
        }
        private List<CarData> Cars = new List<CarData>();

        // Initialize some data.
        private void howto_compare_mileage_Form1_Load(object sender, EventArgs e)
        {
            // Data from http://www.cars.com/go/advice/Story.jsp?section=fuel&story=mpgClass&subject=fuelList
            Cars.Add(new CarData("Honda Civic Hybrid", 50, 50, 24050));
            Cars.Add(new CarData("Toyota Prius", 51, 48, 23520));
            Cars.Add(new CarData("Smart For Two", 33, 41, 12490));
            Cars.Add(new CarData("Audi TT", 22, 31, 38300));
            Cars.Add(new CarData("Ford Fiesta", 29, 40, 13200));
            Cars.Add(new CarData("Toyota Yaris", 29, 36, 13155));
            Cars.Add(new CarData("Mini Cooper", 29, 37, 19400));
            Cars.Add(new CarData("Mini Cooper S", 22, 31, 23000));
            Cars.Add(new CarData("Mazda 2", 29, 35, 14180));
            Cars.Add(new CarData("Kia Rio", 28, 34, 12295));
            Cars.Add(new CarData("Nissan Versa", 28, 34, 9990));
            Cars.Add(new CarData("Nissan Sentra", 27, 34, 16060));
            Cars.Add(new CarData("Hyundai Sonata", 24, 35, 19395));
            Cars.Add(new CarData("Honda Accord", 23, 33, 21380));
            Cars.Add(new CarData("Nissan Juke", 27, 32, 19570));
            Cars.Add(new CarData("Kia Soul", 26, 31, 13300));
            Cars.Add(new CarData("Audi A6 Avant", 18, 26, 45200));
            Cars.Add(new CarData("Mercedes-Benz E350", 16, 23, 48850));
            Cars.Add(new CarData("Ford Ranger", 22, 27, 18160));
            Cars.Add(new CarData("Toyota Tacoma", 21, 25, 16365));
            Cars.Add(new CarData("Chevrolet Silverado", 15, 22, 21235));
            Cars.Add(new CarData("GMC Sierra", 15, 22, 21235));
            Cars.Add(new CarData("Honda Odyssey", 19, 28, 28075));
            Cars.Add(new CarData("Toyota Sienna", 19, 24, 25060));
            Cars.Add(new CarData("Kia Sedona", 18, 25, 24595));
            Cars.Add(new CarData("Mitsubishi Outlander", 25, 31, 21995));
            Cars.Add(new CarData("Chevrolet HHR", 22, 32, 18720));
            Cars.Add(new CarData("Chevrolet Equinox", 22, 32, 22995));
            Cars.Add(new CarData("GMC Terrain", 22, 32, 24500));
            Cars.Add(new CarData("Hyundai Tucson", 23, 31, 18895));

            CalculateTotalCosts();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateTotalCosts();
        }

        // Calculate total cost including fuel.
        private void CalculateTotalCosts()
        {
            try
            {
                // Calculate the costs.
                float city_miles = float.Parse(txtCityMiles.Text);
                float hwy_miles = float.Parse(txtHwyMiles.Text);
                float cost_per_gallon = float.Parse(txtCostPerGallon.Text,
                    NumberStyles.Any);
                lvwCars.Items.Clear();
                foreach (CarData car_data in Cars)
                {
                    ListViewItem car_item = lvwCars.Items.Add(car_data.Name);
                    car_item.SubItems.Add(car_data.BaseCost.ToString("C"));
                    car_item.SubItems.Add(car_data.CityMileage.ToString());
                    car_item.SubItems.Add(car_data.HwyMileage.ToString());
                    float total_cost =
                        car_data.BaseCost +
                        cost_per_gallon * city_miles / car_data.CityMileage +
                        cost_per_gallon * hwy_miles / car_data.HwyMileage;
                    car_item.SubItems.Add(total_cost.ToString("C"));
                }
            }
            catch
            {
            }
        }

        ColumnHeader SortingColumn = null;

        // Sort on this column.
        private void lvwCars_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lvwCars.Columns[e.Column];

            // Figure out the new sorting order.
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            // Create a comparer.
            lvwCars.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);

            // Sort.
            lvwCars.Sort();
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
            this.txtCostPerGallon = new System.Windows.Forms.TextBox();
            this.txtHwyMiles = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtCityMiles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.lvwCars = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCostPerGallon
            // 
            this.txtCostPerGallon.Location = new System.Drawing.Point(74, 66);
            this.txtCostPerGallon.Name = "txtCostPerGallon";
            this.txtCostPerGallon.Size = new System.Drawing.Size(69, 20);
            this.txtCostPerGallon.TabIndex = 15;
            this.txtCostPerGallon.Text = "$3.50";
            this.txtCostPerGallon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHwyMiles
            // 
            this.txtHwyMiles.Location = new System.Drawing.Point(74, 40);
            this.txtHwyMiles.Name = "txtHwyMiles";
            this.txtHwyMiles.Size = new System.Drawing.Size(69, 20);
            this.txtHwyMiles.TabIndex = 13;
            this.txtHwyMiles.Text = "50,000";
            this.txtHwyMiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Hwy Miles:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(383, 12);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 11;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtCityMiles
            // 
            this.txtCityMiles.Location = new System.Drawing.Point(74, 14);
            this.txtCityMiles.Name = "txtCityMiles";
            this.txtCityMiles.Size = new System.Drawing.Size(69, 20);
            this.txtCityMiles.TabIndex = 10;
            this.txtCityMiles.Text = "50,000";
            this.txtCityMiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "City Miles:";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Cost w/Fuel";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Hwy MPG";
            this.columnHeader4.Width = 91;
            // 
            // lvwCars
            // 
            this.lvwCars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvwCars.Location = new System.Drawing.Point(14, 92);
            this.lvwCars.Name = "lvwCars";
            this.lvwCars.Size = new System.Drawing.Size(512, 278);
            this.lvwCars.TabIndex = 8;
            this.lvwCars.UseCompatibleStateImageBehavior = false;
            this.lvwCars.View = System.Windows.Forms.View.Details;
            this.lvwCars.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwCars_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Car";
            this.columnHeader1.Width = 124;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cost";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 79;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "City MPG";
            this.columnHeader3.Width = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "$/Gal:";
            // 
            // howto_compare_mileage_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 382);
            this.Controls.Add(this.txtCostPerGallon);
            this.Controls.Add(this.txtHwyMiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtCityMiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwCars);
            this.Controls.Add(this.label3);
            this.Name = "howto_compare_mileage_Form1";
            this.Text = "howto_compare_mileage";
            this.Load += new System.EventHandler(this.howto_compare_mileage_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCostPerGallon;
        private System.Windows.Forms.TextBox txtHwyMiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtCityMiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lvwCars;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
    }
}

