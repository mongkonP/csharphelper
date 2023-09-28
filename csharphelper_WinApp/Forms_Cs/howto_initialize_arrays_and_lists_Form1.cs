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
     public partial class howto_initialize_arrays_and_lists_Form1:Form
  { 


        public howto_initialize_arrays_and_lists_Form1()
        {
            InitializeComponent();
        }

        // Initialize some arrays and lists.
        private void howto_initialize_arrays_and_lists_Form1_Load(object sender, EventArgs e)
        {
            // Arrays implement IEnumerable so this syntax works.
            string[] fruits = 
            { 
                "Apple", 
                "Banana", 
                "Cherry" 
            };
            lstFruits.DataSource = fruits;

            // Lists implement IEnumerable so this syntax works.
            List<string> cookies = new List<string>() 
            { 
                "Chocolate Chip", 
                "Snickerdoodle", 
                "Peanut Butter" 
            };
            lstCookies.DataSource = cookies;

            // Classes such as Person don't implement IEnumerable
            // so you cannot simply list the property values inside
            // brackets. Instead use this syntax.
            Person[] people = 
            {
                new Person() { FirstName="Simon", LastName="Green" },
                new Person() { FirstName="Terry", LastName="Pratchett" },
                new Person() { FirstName="Eowin", LastName="Colfer" },
            };
            lstPeople.DataSource = people;
        }
    

    // A simple Person class.
       private  class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

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
            this.lstPeople = new System.Windows.Forms.ListBox();
            this.lstCookies = new System.Windows.Forms.ListBox();
            this.lstFruits = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstPeople
            // 
            this.lstPeople.FormattingEnabled = true;
            this.lstPeople.IntegralHeight = false;
            this.lstPeople.Location = new System.Drawing.Point(264, 14);
            this.lstPeople.Name = "lstPeople";
            this.lstPeople.Size = new System.Drawing.Size(120, 95);
            this.lstPeople.TabIndex = 5;
            // 
            // lstCookies
            // 
            this.lstCookies.FormattingEnabled = true;
            this.lstCookies.IntegralHeight = false;
            this.lstCookies.Location = new System.Drawing.Point(138, 14);
            this.lstCookies.Name = "lstCookies";
            this.lstCookies.Size = new System.Drawing.Size(120, 95);
            this.lstCookies.TabIndex = 4;
            // 
            // lstFruits
            // 
            this.lstFruits.FormattingEnabled = true;
            this.lstFruits.IntegralHeight = false;
            this.lstFruits.Location = new System.Drawing.Point(12, 14);
            this.lstFruits.Name = "lstFruits";
            this.lstFruits.Size = new System.Drawing.Size(120, 95);
            this.lstFruits.TabIndex = 3;
            // 
            // howto_initialize_arrays_and_lists_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 123);
            this.Controls.Add(this.lstPeople);
            this.Controls.Add(this.lstCookies);
            this.Controls.Add(this.lstFruits);
            this.Name = "howto_initialize_arrays_and_lists_Form1";
            this.Text = "howto_initialize_arrays_and_lists";
            this.Load += new System.EventHandler(this.howto_initialize_arrays_and_lists_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstPeople;
        private System.Windows.Forms.ListBox lstCookies;
        private System.Windows.Forms.ListBox lstFruits;
    }
}

