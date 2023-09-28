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
     public partial class howto_compare_structs_Form1:Form
  { 


        public howto_compare_structs_Form1()
        {
            InitializeComponent();
        }

        private struct Person
        {
            public string FirstName, LastName;

            public static bool operator ==(Person per1, Person per2)
            {
                return per1.Equals(per2);
            }
            public static bool operator !=(Person per1, Person per2)
            {
                return !per1.Equals(per2);
            }

            //public override bool Equals(object obj)
            //{
            //    return base.Equals(obj);
            //}
            //public override int GetHashCode()
            //{
            //    return base.GetHashCode();
            //}
        };

        private struct Human
        {
            public string FirstName, LastName;
        };

        private void howto_compare_structs_Form1_Load(object sender, EventArgs e)
        {
            Person person1 = new Person() { FirstName = "Rod", LastName = "Stephens" };
            Person person2 = new Person() { FirstName = "Rod", LastName = "Stephens" };
            Person person3 = new Person() { FirstName = "Ann", LastName = "Archer" };
            Human human1 = new Human() { FirstName = "Rod", LastName = "Stephens" };
            Human human2 = new Human() { FirstName = "Rod", LastName = "Stephens" };

            // Use == for Persons.
            lstResults.Items.Add("person1 == person2: " + (person1 == person2).ToString());
            lstResults.Items.Add("person1 == person3: " + (person1 == person3).ToString());
            lstResults.Items.Add("person1 != person2: " + (person1 != person2).ToString());
            lstResults.Items.Add("person1 != person3: " + (person1 != person3).ToString());

            // Use == for Humans. This isn't allowed.
            //bool humans_equal = (human1 == human2);
            //lstResults.Items.Add("human1 == human2: " + humans_equal.ToString());
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
            this.lstResults = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.IntegralHeight = false;
            this.lstResults.Location = new System.Drawing.Point(12, 12);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(280, 76);
            this.lstResults.TabIndex = 0;
            // 
            // howto_compare_structs_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 100);
            this.Controls.Add(this.lstResults);
            this.Name = "howto_compare_structs_Form1";
            this.Text = "howto_compare_structs";
            this.Load += new System.EventHandler(this.howto_compare_structs_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstResults;

    }
}

