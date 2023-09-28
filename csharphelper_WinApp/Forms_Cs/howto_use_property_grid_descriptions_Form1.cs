using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_use_property_grid_descriptions;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_use_property_grid_descriptions_Form1:Form
  { 


        public howto_use_property_grid_descriptions_Form1()
        {
            InitializeComponent();
        }

        private void howto_use_property_grid_descriptions_Form1_Load(object sender, EventArgs e)
        {
            // Make some people.
            Person[] people =
            {
                new Person() {FirstName="Ann", LastName="Archer", Street="101 Ash Ave", City="Ann Arbor", State="MI", Zip="12345", Email="Ann@anywhere.com", Phone="703-287-3798"}, 
                new Person() {FirstName="Ben", LastName="Best", Street="231 Beach Blvd", City="Boulder", State="CO", Zip="24361", Email="Ben@bestplace.com", Phone="209-783-2918"}, 
                new Person() {FirstName="Cindy", LastName="Carter", Street="3783 Cherry Ct", City="Cedar Rapids", State="IA", Zip="36268", Email="CindyCarter@TheCarters.com", Phone="404-329-0182"}, 
            };

            // Display them in a ListBox.
            lstPeople.DataSource = people;
        }

        // Display this person's properties in the PropertyGrid.
        private void lstPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset the DisplayMember to make
            // the ListBox refresh its list.
            lstPeople.DisplayMember = "FirstName";
            lstPeople.DisplayMember = null;

            // Display the selected Person in the PropertyGrid.
            pgdPeople.SelectedObject = lstPeople.SelectedItem;
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
            this.pgdPeople = new System.Windows.Forms.PropertyGrid();
            this.lstPeople = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // pgdPeople
            // 
            this.pgdPeople.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdPeople.Location = new System.Drawing.Point(136, 0);
            this.pgdPeople.Name = "pgdPeople";
            this.pgdPeople.Size = new System.Drawing.Size(283, 264);
            this.pgdPeople.TabIndex = 3;
            // 
            // lstPeople
            // 
            this.lstPeople.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstPeople.FormattingEnabled = true;
            this.lstPeople.Location = new System.Drawing.Point(0, 0);
            this.lstPeople.Name = "lstPeople";
            this.lstPeople.Size = new System.Drawing.Size(136, 264);
            this.lstPeople.TabIndex = 2;
            this.lstPeople.SelectedIndexChanged += new System.EventHandler(this.lstPeople_SelectedIndexChanged);
            // 
            // howto_use_property_grid_descriptions_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 264);
            this.Controls.Add(this.pgdPeople);
            this.Controls.Add(this.lstPeople);
            this.Name = "howto_use_property_grid_descriptions_Form1";
            this.Text = "howto_use_property_grid_descriptions";
            this.Load += new System.EventHandler(this.howto_use_property_grid_descriptions_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgdPeople;
        private System.Windows.Forms.ListBox lstPeople;
    }
}

