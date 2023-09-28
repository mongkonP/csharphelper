using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_cast_arrays;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_cast_arrays_Form1:Form
  { 


        public howto_cast_arrays_Form1()
        {
            InitializeComponent();
        }

        private void howto_cast_arrays_Form1_Load(object sender, EventArgs e)
        {
            // Make an array of Employees.
            Employee[] employees =
            {
                new Employee("Terry", "Pratchett", 1001),
                new Employee("Christopher", "Moore", 1003),
                new Employee("Jasper", "Fforde", 1002),
                new Employee("Tom", "Holt", 1004),
            };
            foreach (Employee employee in employees)
                lstInitial.Items.Add(employee.GetName());

            // Cast the array into an array of Person.
            Person[] persons = (Person[])employees;
            foreach (Person person in persons)
                lstPersons.Items.Add(person.GetName());

            // Modify the Person objects.
            foreach (Person person in persons)
                person.FirstName = "* " + person.FirstName;

            // Display the modified Person[] array.
            foreach (Person person in persons)
                lstModifiedPersons.Items.Add(person.GetName());

            // Display the modified Employee[] array.
            foreach (Employee employee in employees)
                lstModifiedEmployees.Items.Add(employee.GetName());
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
            this.lstModifiedEmployees = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstModifiedPersons = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstPersons = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstInitial = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstModifiedEmployees
            // 
            this.lstModifiedEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstModifiedEmployees.FormattingEnabled = true;
            this.lstModifiedEmployees.Location = new System.Drawing.Point(12, 340);
            this.lstModifiedEmployees.Name = "lstModifiedEmployees";
            this.lstModifiedEmployees.Size = new System.Drawing.Size(260, 69);
            this.lstModifiedEmployees.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Modified Employee[ ]";
            // 
            // lstModifiedPersons
            // 
            this.lstModifiedPersons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstModifiedPersons.FormattingEnabled = true;
            this.lstModifiedPersons.Location = new System.Drawing.Point(12, 236);
            this.lstModifiedPersons.Name = "lstModifiedPersons";
            this.lstModifiedPersons.Size = new System.Drawing.Size(260, 69);
            this.lstModifiedPersons.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Modified Person[ ]";
            // 
            // lstPersons
            // 
            this.lstPersons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPersons.FormattingEnabled = true;
            this.lstPersons.Location = new System.Drawing.Point(12, 132);
            this.lstPersons.Name = "lstPersons";
            this.lstPersons.Size = new System.Drawing.Size(260, 69);
            this.lstPersons.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cast to Person[ ]";
            // 
            // lstInitial
            // 
            this.lstInitial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInitial.FormattingEnabled = true;
            this.lstInitial.Location = new System.Drawing.Point(12, 28);
            this.lstInitial.Name = "lstInitial";
            this.lstInitial.Size = new System.Drawing.Size(260, 69);
            this.lstInitial.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Initial Employee[ ]";
            // 
            // howto_cast_arrays_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 420);
            this.Controls.Add(this.lstModifiedEmployees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstModifiedPersons);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstPersons);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstInitial);
            this.Controls.Add(this.label1);
            this.Name = "howto_cast_arrays_Form1";
            this.Text = "howto_cast_arrays";
            this.Load += new System.EventHandler(this.howto_cast_arrays_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstModifiedEmployees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstModifiedPersons;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstPersons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstInitial;
        private System.Windows.Forms.Label label1;
    }
}

