using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_implicit_interface;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_implicit_interface_Form1:Form
  { 


        public howto_implicit_interface_Form1()
        {
            InitializeComponent();
        }

        private void howto_implicit_interface_Form1_Load(object sender, EventArgs e)
        {
            // Make some Persons.
            Person person1 = new Person();
            Person person2 = new Person();
            int result;

            // Allowed.
            result = person1.CompareTo(person2);

            // Allowed.
            result = ((IComparable<Person>)person1).CompareTo(person2);

            // Allowed.
            IComparable<Person> comparable = (IComparable<Person>)person1;
            result = comparable.CompareTo(person2);

            // Fails at run time.
            //IComparable comparable2 = (IComparable)person1;
            //result = comparable2.CompareTo(person2);

            // Sort some Persons.
            Person[] people =
            {
                new Person() { FirstName = "Dan", LastName = "Deevers"},
                new Person() { FirstName = "Bob", LastName = "Baker"},
                new Person() { FirstName = "Cat", LastName = "Carter"},
                new Person() { FirstName = "Ann", LastName = "Archer"},
            };
            Array.Sort(people);
            lstPeople.DataSource = people;
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
            this.lstPeople = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstPeople
            // 
            this.lstPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPeople.FormattingEnabled = true;
            this.lstPeople.IntegralHeight = false;
            this.lstPeople.Location = new System.Drawing.Point(12, 12);
            this.lstPeople.Name = "lstPeople";
            this.lstPeople.Size = new System.Drawing.Size(310, 87);
            this.lstPeople.TabIndex = 1;
            // 
            // howto_implicit_interface_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.lstPeople);
            this.Name = "howto_implicit_interface_Form1";
            this.Text = "howto_implicit_interface";
            this.Load += new System.EventHandler(this.howto_implicit_interface_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstPeople;
    }
}

