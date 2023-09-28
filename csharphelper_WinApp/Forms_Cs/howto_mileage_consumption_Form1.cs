using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// See http://en.wikipedia.org/wiki/Fuel_efficiency

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_mileage_consumption_Form1:Form
  { 


        public howto_mileage_consumption_Form1()
        {
            InitializeComponent();
        }

        // Conversion factors.
        private const float miles_per_km = 0.621371192f;
        private const float us_gallons_per_liter = 0.264172052637296f;
        private const float uk_gallons_per_liter = 0.2199692483f;

        // Calculate the mileage statistics.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Get the inputs.
            float miles = float.Parse(txtDistance.Text);
            float gallons = float.Parse(txtFuel.Text);

            // Convert to miles and US gallons.
            if (radKilometers.Checked) miles *= miles_per_km;
            if (radUkGallons.Checked)
            {
                gallons *= us_gallons_per_liter / uk_gallons_per_liter;
            }
            else if (radKilometers.Checked)
            {
                gallons *= us_gallons_per_liter;
            }

            // Calculate performance values.
            float us_mpg = miles / gallons;
            float us_gal_per_100_miles = 100 / us_mpg;

            // US values.
            txtUsMpg.Text = us_mpg.ToString("0.00");
            txtUsGalPer100Miles.Text = us_gal_per_100_miles.ToString("0.00");

            // UK values.
            float uk_gals = gallons * uk_gallons_per_liter / us_gallons_per_liter;
            float uk_mpg = miles / uk_gals;
            float uk_gal_per_100_miles = 100 / uk_mpg;
            txtUkMpg.Text = uk_mpg.ToString("0.00");
            txtUkGalPer100Miles.Text = uk_gal_per_100_miles.ToString("0.00");

            // Metric values.
            float liters = gallons / us_gallons_per_liter;
            float kilometers = miles / miles_per_km;
            float km_per_liter = kilometers / liters;
            float l_per_100_km = 100 / km_per_liter;
            txtKpl.Text = km_per_liter.ToString("0.00");
            txtLiterPer100km.Text = l_per_100_km.ToString("0.00");
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtUkGalPer100Miles = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUkMpg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtKpl = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLiterPer100km = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUsGalPer100Miles = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsMpg = new System.Windows.Forms.TextBox();
            this.radGallons = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radKilometers = new System.Windows.Forms.RadioButton();
            this.radMiles = new System.Windows.Forms.RadioButton();
            this.txtFuel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radLiters = new System.Windows.Forms.RadioButton();
            this.radUkGallons = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Gal/100 miles";
            // 
            // txtUkGalPer100Miles
            // 
            this.txtUkGalPer100Miles.Location = new System.Drawing.Point(98, 39);
            this.txtUkGalPer100Miles.Name = "txtUkGalPer100Miles";
            this.txtUkGalPer100Miles.ReadOnly = true;
            this.txtUkGalPer100Miles.Size = new System.Drawing.Size(51, 20);
            this.txtUkGalPer100Miles.TabIndex = 11;
            this.txtUkGalPer100Miles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtUkGalPer100Miles);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtUkMpg);
            this.groupBox2.Location = new System.Drawing.Point(178, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 70);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "British";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "MPG";
            // 
            // txtUkMpg
            // 
            this.txtUkMpg.Location = new System.Drawing.Point(97, 13);
            this.txtUkMpg.Name = "txtUkMpg";
            this.txtUkMpg.ReadOnly = true;
            this.txtUkMpg.Size = new System.Drawing.Size(51, 20);
            this.txtUkMpg.TabIndex = 9;
            this.txtUkMpg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Gal/100 miles";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCalculate.Location = new System.Drawing.Point(218, 75);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 27;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "km/liter";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtKpl);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtLiterPer100km);
            this.groupBox3.Location = new System.Drawing.Point(341, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 70);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Metric";
            // 
            // txtKpl
            // 
            this.txtKpl.Location = new System.Drawing.Point(97, 39);
            this.txtKpl.Name = "txtKpl";
            this.txtKpl.ReadOnly = true;
            this.txtKpl.Size = new System.Drawing.Size(51, 20);
            this.txtKpl.TabIndex = 11;
            this.txtKpl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Liters/100 km";
            // 
            // txtLiterPer100km
            // 
            this.txtLiterPer100km.Location = new System.Drawing.Point(96, 13);
            this.txtLiterPer100km.Name = "txtLiterPer100km";
            this.txtLiterPer100km.ReadOnly = true;
            this.txtLiterPer100km.Size = new System.Drawing.Size(51, 20);
            this.txtLiterPer100km.TabIndex = 9;
            this.txtLiterPer100km.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtUsGalPer100Miles);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUsMpg);
            this.groupBox1.Location = new System.Drawing.Point(15, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 70);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "American";
            // 
            // txtUsGalPer100Miles
            // 
            this.txtUsGalPer100Miles.Location = new System.Drawing.Point(96, 39);
            this.txtUsGalPer100Miles.Name = "txtUsGalPer100Miles";
            this.txtUsGalPer100Miles.ReadOnly = true;
            this.txtUsGalPer100Miles.Size = new System.Drawing.Size(51, 20);
            this.txtUsGalPer100Miles.TabIndex = 11;
            this.txtUsGalPer100Miles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "MPG";
            // 
            // txtUsMpg
            // 
            this.txtUsMpg.Location = new System.Drawing.Point(97, 13);
            this.txtUsMpg.Name = "txtUsMpg";
            this.txtUsMpg.ReadOnly = true;
            this.txtUsMpg.Size = new System.Drawing.Size(51, 20);
            this.txtUsMpg.TabIndex = 9;
            this.txtUsMpg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radGallons
            // 
            this.radGallons.AutoSize = true;
            this.radGallons.Checked = true;
            this.radGallons.Location = new System.Drawing.Point(0, 0);
            this.radGallons.Name = "radGallons";
            this.radGallons.Size = new System.Drawing.Size(78, 17);
            this.radGallons.TabIndex = 0;
            this.radGallons.TabStop = true;
            this.radGallons.Text = "US Gallons";
            this.radGallons.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radKilometers);
            this.panel1.Controls.Add(this.radMiles);
            this.panel1.Location = new System.Drawing.Point(144, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 20);
            this.panel1.TabIndex = 25;
            // 
            // radKilometers
            // 
            this.radKilometers.AutoSize = true;
            this.radKilometers.Location = new System.Drawing.Point(94, 0);
            this.radKilometers.Name = "radKilometers";
            this.radKilometers.Size = new System.Drawing.Size(73, 17);
            this.radKilometers.TabIndex = 1;
            this.radKilometers.Text = "Kilometers";
            this.radKilometers.UseVisualStyleBackColor = true;
            // 
            // radMiles
            // 
            this.radMiles.AutoSize = true;
            this.radMiles.Checked = true;
            this.radMiles.Location = new System.Drawing.Point(0, 0);
            this.radMiles.Name = "radMiles";
            this.radMiles.Size = new System.Drawing.Size(49, 17);
            this.radMiles.TabIndex = 0;
            this.radMiles.TabStop = true;
            this.radMiles.Text = "Miles";
            this.radMiles.UseVisualStyleBackColor = true;
            // 
            // txtFuel
            // 
            this.txtFuel.Location = new System.Drawing.Point(70, 38);
            this.txtFuel.Name = "txtFuel";
            this.txtFuel.Size = new System.Drawing.Size(51, 20);
            this.txtFuel.TabIndex = 24;
            this.txtFuel.Text = "2.2";
            this.txtFuel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Fuel:";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(70, 12);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(51, 20);
            this.txtDistance.TabIndex = 22;
            this.txtDistance.Text = "100";
            this.txtDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Distance:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radLiters);
            this.panel2.Controls.Add(this.radUkGallons);
            this.panel2.Controls.Add(this.radGallons);
            this.panel2.Location = new System.Drawing.Point(144, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 20);
            this.panel2.TabIndex = 26;
            // 
            // radLiters
            // 
            this.radLiters.AutoSize = true;
            this.radLiters.Location = new System.Drawing.Point(191, 0);
            this.radLiters.Name = "radLiters";
            this.radLiters.Size = new System.Drawing.Size(50, 17);
            this.radLiters.TabIndex = 2;
            this.radLiters.Text = "Liters";
            this.radLiters.UseVisualStyleBackColor = true;
            // 
            // radUkGallons
            // 
            this.radUkGallons.AutoSize = true;
            this.radUkGallons.Location = new System.Drawing.Point(94, 0);
            this.radUkGallons.Name = "radUkGallons";
            this.radUkGallons.Size = new System.Drawing.Size(78, 17);
            this.radUkGallons.TabIndex = 1;
            this.radUkGallons.Text = "UK Gallons";
            this.radUkGallons.UseVisualStyleBackColor = true;
            // 
            // howto_mileage_consumption_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 200);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtFuel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Name = "howto_mileage_consumption_Form1";
            this.Text = "howto_mileage_consumption";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUkGalPer100Miles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUkMpg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtKpl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLiterPer100km;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUsGalPer100Miles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsMpg;
        private System.Windows.Forms.RadioButton radGallons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radKilometers;
        private System.Windows.Forms.RadioButton radMiles;
        private System.Windows.Forms.TextBox txtFuel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radLiters;
        private System.Windows.Forms.RadioButton radUkGallons;
    }
}

