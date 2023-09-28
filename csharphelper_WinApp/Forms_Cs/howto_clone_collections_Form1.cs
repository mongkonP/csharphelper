using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_clone_collections;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_clone_collections_Form1:Form
  { 


        public howto_clone_collections_Form1()
        {
            InitializeComponent();
        }

        private void howto_clone_collections_Form1_Load(object sender, EventArgs e)
        {
            MakeArrays();
            MakeLists();
        }

        private void MakeArrays()
        {
            // Make some people.
            Person[] people =
            {
                new Person() {
                    FirstName="Ann", LastName="Archer", 
                    Address=new StreetAddress(){Street="101 Ash Ave", City="Ann Arbor", State="MI", Zip="12345"},
                    Email="Ann@anywhere.com", Phone="703-287-3798"}, 
                new Person() {
                    FirstName="Ben", LastName="Best", 
                    Address=new StreetAddress() {Street="231 Beach Blvd", City="Boulder", State="CO", Zip="24361"},
                    Email="Ben@bestplace.com", Phone="209-783-2918"}, 
                new Person() {
                    FirstName="Cindy", LastName="Carter", 
                    Address=new StreetAddress() {Street="3783 Cherry Ct", City="Cedar Rapids", State="IA", Zip="36268"},
                    Email="CindyCarter@TheCarters.com", Phone="404-329-0182"}, 
            };

            // Make a shallow copy.
            Person[] shallow_clone = people.ShallowClone();

            // Make a deep copy.
            Person[] deep_clone = people.DeepClone();

            // Change the first person in the original list.
            people[0].FirstName = "Mable";
            people[0].LastName = "Modified";

            // Display the arrays in ListBoxes.
            lstPeople.DataSource = people;
            lstShallow.DataSource = shallow_clone;
            lstDeep.DataSource = deep_clone;
        }

        private void MakeLists()
        {
            // Make some people.
            List<Person> people = new List<Person>()
            {
                new Person() {
                    FirstName="Ann", LastName="Archer", 
                    Address=new StreetAddress(){Street="101 Ash Ave", City="Ann Arbor", State="MI", Zip="12345"},
                    Email="Ann@anywhere.com", Phone="703-287-3798"}, 
                new Person() {
                    FirstName="Ben", LastName="Best", 
                    Address=new StreetAddress() {Street="231 Beach Blvd", City="Boulder", State="CO", Zip="24361"},
                    Email="Ben@bestplace.com", Phone="209-783-2918"}, 
                new Person() {
                    FirstName="Cindy", LastName="Carter", 
                    Address=new StreetAddress() {Street="3783 Cherry Ct", City="Cedar Rapids", State="IA", Zip="36268"},
                    Email="CindyCarter@TheCarters.com", Phone="404-329-0182"}, 
            };

            // Make a shallow copy.
            List<Person> shallow_clone = people.ShallowClone();

            // Make a deep copy.
            List<Person> deep_clone = people.DeepClone();

            // Change the first person in the original list.
            people[0].FirstName = "Mable";
            people[0].LastName = "Modified";

            // Display the arrays in ListBoxes.
            lstListPeople.DataSource = people;
            lstListShallow.DataSource = shallow_clone;
            lstListDeep.DataSource = deep_clone;
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstListDeep = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstListPeople = new System.Windows.Forms.ListBox();
            this.lstListShallow = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstPeople = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstDeep = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstShallow = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Deep Clone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Deep Clone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Original:";
            // 
            // lstListDeep
            // 
            this.lstListDeep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstListDeep.FormattingEnabled = true;
            this.lstListDeep.Location = new System.Drawing.Point(44, 174);
            this.lstListDeep.Name = "lstListDeep";
            this.lstListDeep.Size = new System.Drawing.Size(110, 43);
            this.lstListDeep.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstListPeople);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lstListDeep);
            this.groupBox2.Controls.Add(this.lstListShallow);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(184, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 227);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lists";
            // 
            // lstListPeople
            // 
            this.lstListPeople.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstListPeople.FormattingEnabled = true;
            this.lstListPeople.Location = new System.Drawing.Point(44, 32);
            this.lstListPeople.Name = "lstListPeople";
            this.lstListPeople.Size = new System.Drawing.Size(110, 43);
            this.lstListPeople.TabIndex = 0;
            // 
            // lstListShallow
            // 
            this.lstListShallow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstListShallow.FormattingEnabled = true;
            this.lstListShallow.Location = new System.Drawing.Point(44, 103);
            this.lstListShallow.Name = "lstListShallow";
            this.lstListShallow.Size = new System.Drawing.Size(110, 43);
            this.lstListShallow.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Shallow Clone:";
            // 
            // lstPeople
            // 
            this.lstPeople.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPeople.FormattingEnabled = true;
            this.lstPeople.Location = new System.Drawing.Point(44, 32);
            this.lstPeople.Name = "lstPeople";
            this.lstPeople.Size = new System.Drawing.Size(110, 43);
            this.lstPeople.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Original:";
            // 
            // lstDeep
            // 
            this.lstDeep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDeep.FormattingEnabled = true;
            this.lstDeep.Location = new System.Drawing.Point(44, 174);
            this.lstDeep.Name = "lstDeep";
            this.lstDeep.Size = new System.Drawing.Size(110, 43);
            this.lstDeep.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstPeople);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstDeep);
            this.groupBox1.Controls.Add(this.lstShallow);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 227);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arrays";
            // 
            // lstShallow
            // 
            this.lstShallow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstShallow.FormattingEnabled = true;
            this.lstShallow.Location = new System.Drawing.Point(44, 103);
            this.lstShallow.Name = "lstShallow";
            this.lstShallow.Size = new System.Drawing.Size(110, 43);
            this.lstShallow.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Shallow Clone:";
            // 
            // howto_clone_collections_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 249);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "howto_clone_collections_Form1";
            this.Text = "howto_clone_collections";
            this.Load += new System.EventHandler(this.howto_clone_collections_Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstListDeep;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstListPeople;
        private System.Windows.Forms.ListBox lstListShallow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstPeople;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstDeep;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstShallow;
        private System.Windows.Forms.Label label2;
    }
}

