using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_sort_arrays;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_sort_arrays_Form1:Form
  { 


        public howto_sort_arrays_Form1()
        {
            InitializeComponent();
        }

        private void howto_sort_arrays_Form1_Load(object sender, EventArgs e)
        {
            DisplayNumbers();
            DisplayPeople();
            DisplayPeopleLastNameFirst();
        }

        private void DisplayNumbers()
        {
            // Make an array of random numbers.
            Random rand = new Random();
            int[] numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(10, 99);
            }

            // Display the numbers unsorted.
            for (int i = 0; i < numbers.Length; i++)
            {
                lstNumbers.Items.Add(numbers[i]);
            }

            // Sort the numbers.
            Array.Sort(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                lstSortedNumbers.Items.Add(numbers[i]);
            }
        }

        private void DisplayPeople()
        {
            Person[] people =
            {
                new Person() { FirstName="Ben", LastName="Holbrook"},
                new Person() { FirstName="Fred", LastName="Gill"},
                new Person() { FirstName="Ginny", LastName="Franklin"},
                new Person() { FirstName="Cindy", LastName="Carter"},
                new Person() { FirstName="Ann", LastName="Baker"},
                new Person() { FirstName="Jeff", LastName="Ivanova"},
                new Person() { FirstName="Irma", LastName="Archer"},
                new Person() { FirstName="Dan", LastName="Jerico"},
                new Person() { FirstName="Hal", LastName="Evans"},
                new Person() { FirstName="Edwina", LastName="Dolf"},
            };

            // Display the people unsorted.
            for (int i = 0; i < people.Length; i++)
            {
                lstPeople.Items.Add(people[i]);
            }

            // Sort the people.
            Array.Sort(people);
            for (int i = 0; i < people.Length; i++)
            {
                lstSortedPeople.Items.Add(people[i]);
            }
        }

        private void DisplayPeopleLastNameFirst()
        {
            Person[] people =
            {
                new Person() { FirstName="Ben", LastName="Holbrook"},
                new Person() { FirstName="Fred", LastName="Gill"},
                new Person() { FirstName="Ginny", LastName="Franklin"},
                new Person() { FirstName="Cindy", LastName="Carter"},
                new Person() { FirstName="Ann", LastName="Baker"},
                new Person() { FirstName="Jeff", LastName="Ivanova"},
                new Person() { FirstName="Irma", LastName="Archer"},
                new Person() { FirstName="Dan", LastName="Jerico"},
                new Person() { FirstName="Hal", LastName="Evans"},
                new Person() { FirstName="Edwina", LastName="Dolf"},
            };

            // Display the people unsorted.
            for (int i = 0; i < people.Length; i++)
            {
                lstLastNameFirst.Items.Add(people[i]);
            }

            // Sort the people.
            PersonComparer comparer = new PersonComparer();
            Array.Sort(people, comparer);
            for (int i = 0; i < people.Length; i++)
            {
                lstSortedLastNameFirst.Items.Add(people[i]);
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
            this.lstNumbers = new System.Windows.Forms.ListBox();
            this.lstPeople = new System.Windows.Forms.ListBox();
            this.lstLastNameFirst = new System.Windows.Forms.ListBox();
            this.lstSortedLastNameFirst = new System.Windows.Forms.ListBox();
            this.lstSortedPeople = new System.Windows.Forms.ListBox();
            this.lstSortedNumbers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstNumbers
            // 
            this.lstNumbers.FormattingEnabled = true;
            this.lstNumbers.IntegralHeight = false;
            this.lstNumbers.Location = new System.Drawing.Point(12, 12);
            this.lstNumbers.Name = "lstNumbers";
            this.lstNumbers.Size = new System.Drawing.Size(61, 134);
            this.lstNumbers.TabIndex = 0;
            // 
            // lstPeople
            // 
            this.lstPeople.FormattingEnabled = true;
            this.lstPeople.IntegralHeight = false;
            this.lstPeople.Location = new System.Drawing.Point(79, 12);
            this.lstPeople.Name = "lstPeople";
            this.lstPeople.Size = new System.Drawing.Size(93, 134);
            this.lstPeople.TabIndex = 1;
            // 
            // lstLastNameFirst
            // 
            this.lstLastNameFirst.FormattingEnabled = true;
            this.lstLastNameFirst.IntegralHeight = false;
            this.lstLastNameFirst.Location = new System.Drawing.Point(178, 12);
            this.lstLastNameFirst.Name = "lstLastNameFirst";
            this.lstLastNameFirst.Size = new System.Drawing.Size(93, 134);
            this.lstLastNameFirst.TabIndex = 2;
            // 
            // lstSortedLastNameFirst
            // 
            this.lstSortedLastNameFirst.FormattingEnabled = true;
            this.lstSortedLastNameFirst.IntegralHeight = false;
            this.lstSortedLastNameFirst.Location = new System.Drawing.Point(178, 152);
            this.lstSortedLastNameFirst.Name = "lstSortedLastNameFirst";
            this.lstSortedLastNameFirst.Size = new System.Drawing.Size(93, 134);
            this.lstSortedLastNameFirst.TabIndex = 5;
            // 
            // lstSortedPeople
            // 
            this.lstSortedPeople.FormattingEnabled = true;
            this.lstSortedPeople.IntegralHeight = false;
            this.lstSortedPeople.Location = new System.Drawing.Point(79, 152);
            this.lstSortedPeople.Name = "lstSortedPeople";
            this.lstSortedPeople.Size = new System.Drawing.Size(93, 134);
            this.lstSortedPeople.TabIndex = 4;
            // 
            // lstSortedNumbers
            // 
            this.lstSortedNumbers.FormattingEnabled = true;
            this.lstSortedNumbers.IntegralHeight = false;
            this.lstSortedNumbers.Location = new System.Drawing.Point(12, 152);
            this.lstSortedNumbers.Name = "lstSortedNumbers";
            this.lstSortedNumbers.Size = new System.Drawing.Size(61, 134);
            this.lstSortedNumbers.TabIndex = 3;
            // 
            // howto_sort_arrays_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 294);
            this.Controls.Add(this.lstSortedLastNameFirst);
            this.Controls.Add(this.lstSortedPeople);
            this.Controls.Add(this.lstSortedNumbers);
            this.Controls.Add(this.lstLastNameFirst);
            this.Controls.Add(this.lstPeople);
            this.Controls.Add(this.lstNumbers);
            this.Name = "howto_sort_arrays_Form1";
            this.Text = "howto_sort_arrays";
            this.Load += new System.EventHandler(this.howto_sort_arrays_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstNumbers;
        private System.Windows.Forms.ListBox lstPeople;
        private System.Windows.Forms.ListBox lstLastNameFirst;
        private System.Windows.Forms.ListBox lstSortedLastNameFirst;
        private System.Windows.Forms.ListBox lstSortedPeople;
        private System.Windows.Forms.ListBox lstSortedNumbers;
    }
}

