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
     public partial class howto_count_word_letters_Form1:Form
  { 


        public howto_count_word_letters_Form1()
        {
            InitializeComponent();
        }

        // Find and display the words and counts.
        private void howto_count_word_letters_Form1_Load(object sender, EventArgs e)
        {
            string[] words = {
                "Alabama",
                "Alaska",
                "American Samoa",
                "Arizona",
                "Arkansas",
                "California",
                "Colorado",
                "Connecticut",
                "Delaware",
                "District of Columbia",
                "Florida",
                "Georgia",
                "Guam",
                "Hawaii",
                "Idaho",
                "Illinois",
                "Indiana",
                "Iowa",
                "Kansas",
                "Kentucky",
                "Louisiana",
                "Maine",
                "Maryland",
                "Massachusetts",
                "Michigan",
                "Minnesota",
                "Mississippi",
                "Missouri",
                "Montana",
                "Nebraska",
                "Nevada",
                "New Hampshire",
                "New Jersey",
                "New Mexico",
                "New York",
                "North Carolina",
                "North Dakota",
                "Northern Marianas Islands ",
                "Ohio",
                "Oklahoma",
                "Oregon",
                "Pennsylvania",
                "Puerto Rico",
                "Rhode Island",
                "South Carolina",
                "South Dakota",
                "Tennessee",
                "Texas",
                "Utah",
                "Vermont",
                "Virginia ",
                "Virgin Islands ",
                "Washington",
                "West Virginia",
                "Wisconsin",
                "Wyoming"
            };

            // Get a list holding each word's unique letter count and name.
            var count_query =
                from string word in words
                orderby word.ToCharArray().Distinct().Count()
                select word.ToCharArray().Distinct().Count() + ", " + word;
            lstLetterCounts.DataSource = count_query.ToArray();
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
            this.lstLetterCounts = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstLetterCounts
            // 
            this.lstLetterCounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLetterCounts.FormattingEnabled = true;
            this.lstLetterCounts.IntegralHeight = false;
            this.lstLetterCounts.Location = new System.Drawing.Point(0, 0);
            this.lstLetterCounts.Name = "lstLetterCounts";
            this.lstLetterCounts.Size = new System.Drawing.Size(319, 191);
            this.lstLetterCounts.TabIndex = 1;
            // 
            // howto_count_word_letters_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 191);
            this.Controls.Add(this.lstLetterCounts);
            this.Name = "howto_count_word_letters_Form1";
            this.Text = "howto_count_word_letters";
            this.Load += new System.EventHandler(this.howto_count_word_letters_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstLetterCounts;
    }
}

