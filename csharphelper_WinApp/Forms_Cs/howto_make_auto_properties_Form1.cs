using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_make_auto_properties_Form1:Form
  { 


        public howto_make_auto_properties_Form1()
        {
            InitializeComponent();
        }

        // Make some Persons and display them in the ListBox.
        private void howto_make_auto_properties_Form1_Load(object sender, EventArgs e)
        {
            Person[] people = new Person[3];
            people[0] = new Person("Jethro", "Tull");
            people[1] = new Person("Pink", "Floyd");
            people[2] = new Person("Lynyrd", "Skynyrd");

            lstBands.DataSource = people;
        }
    

    // A simple Person class.
    private class Person
    {
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
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
            this.lstBands = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstBands
            // 
            this.lstBands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBands.FormattingEnabled = true;
            this.lstBands.IntegralHeight = false;
            this.lstBands.Location = new System.Drawing.Point(12, 12);
            this.lstBands.Name = "lstBands";
            this.lstBands.Size = new System.Drawing.Size(330, 95);
            this.lstBands.TabIndex = 1;
            // 
            // howto_make_auto_properties_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 121);
            this.Controls.Add(this.lstBands);
            this.Name = "howto_make_auto_properties_Form1";
            this.Text = "howto_make_auto_properties";
            this.Load += new System.EventHandler(this.howto_make_auto_properties_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBands;
    }
}

