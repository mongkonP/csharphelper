using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_hashset_operators;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_hashset_operators_Form1:Form
  { 


        public howto_hashset_operators_Form1()
        {
            InitializeComponent();
        }

        // Make some sets and perform operations on them.
        private void howto_hashset_operators_Form1_Load(object sender, EventArgs e)
        {
            Set<string> owns_a_car = new Set<string>();
            Set<string> owns_a_bike = new Set<string>();

            owns_a_bike.Add("Alice");
            owns_a_bike.Add("Bob");
            owns_a_bike.Add("Fred");
            owns_a_bike.Add("Dan");

            owns_a_car.Add("Cindy");
            owns_a_car.Add("Dan");
            owns_a_car.Add("Emma");
            owns_a_car.Add("Bob");
            owns_a_car.Add("Fred");

            txtOwnsABike.Text = string.Join(", ", owns_a_bike.ToArray());
            txtOwnsACar.Text = string.Join(", ", owns_a_car.ToArray());

            // Intersection.
            Set<string> owns_both = owns_a_car & owns_a_bike;
            txtOwnsBoth.Text = string.Join(", ", owns_both.ToArray());

            // Union.
            Set<string> owns_either = owns_a_car | owns_a_bike;
            txtOwnsEither.Text = string.Join(", ", owns_either.ToArray());

            // Xor.
            Set<string> owns_one = owns_a_car ^ owns_a_bike;
            txtOwnsOne.Text = string.Join(", ", owns_one.ToArray());

            // Subset.
            Set<string> set1 = new Set<string>();
            set1.Add("Cindy");
            set1.Add("Dan");
            txtSubset.Text = (set1 < owns_a_car).ToString();

            // Superset.
            Set<string> set2 = new Set<string>();
            set2.Add("Alice");
            set2.Add("Bob");
            set2.Add("Fred");
            set2.Add("Dan");
            set2.Add("Gina");
            txtSuperset.Text = (set2 > owns_a_bike).ToString();

            txtContainsAlice.Text = (owns_a_car > "Alice").ToString();
            txtContainsCindy.Text = (owns_a_car > "Cindy").ToString();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOwnsACar = new System.Windows.Forms.TextBox();
            this.txtOwnsABike = new System.Windows.Forms.TextBox();
            this.txtOwnsBoth = new System.Windows.Forms.TextBox();
            this.txtOwnsEither = new System.Windows.Forms.TextBox();
            this.txtOwnsOne = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSuperset = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubset = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContainsCindy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContainsAlice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Owns a car:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Owns a bike:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Owns both (And):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Owns either (Or):";
            // 
            // txtOwnsACar
            // 
            this.txtOwnsACar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwnsACar.Location = new System.Drawing.Point(165, 12);
            this.txtOwnsACar.Name = "txtOwnsACar";
            this.txtOwnsACar.Size = new System.Drawing.Size(185, 20);
            this.txtOwnsACar.TabIndex = 7;
            // 
            // txtOwnsABike
            // 
            this.txtOwnsABike.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwnsABike.Location = new System.Drawing.Point(165, 38);
            this.txtOwnsABike.Name = "txtOwnsABike";
            this.txtOwnsABike.Size = new System.Drawing.Size(185, 20);
            this.txtOwnsABike.TabIndex = 8;
            // 
            // txtOwnsBoth
            // 
            this.txtOwnsBoth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwnsBoth.Location = new System.Drawing.Point(165, 90);
            this.txtOwnsBoth.Name = "txtOwnsBoth";
            this.txtOwnsBoth.Size = new System.Drawing.Size(185, 20);
            this.txtOwnsBoth.TabIndex = 10;
            // 
            // txtOwnsEither
            // 
            this.txtOwnsEither.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwnsEither.Location = new System.Drawing.Point(165, 64);
            this.txtOwnsEither.Name = "txtOwnsEither";
            this.txtOwnsEither.Size = new System.Drawing.Size(185, 20);
            this.txtOwnsEither.TabIndex = 9;
            // 
            // txtOwnsOne
            // 
            this.txtOwnsOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwnsOne.Location = new System.Drawing.Point(165, 116);
            this.txtOwnsOne.Name = "txtOwnsOne";
            this.txtOwnsOne.Size = new System.Drawing.Size(185, 20);
            this.txtOwnsOne.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Owns one (Xor):";
            // 
            // txtSuperset
            // 
            this.txtSuperset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSuperset.Location = new System.Drawing.Point(165, 189);
            this.txtSuperset.Name = "txtSuperset";
            this.txtSuperset.Size = new System.Drawing.Size(185, 20);
            this.txtSuperset.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 32);
            this.label4.TabIndex = 15;
            this.label4.Text = "{Alice, Bob, Fred, Dan, Gina} > Owns a bike";
            // 
            // txtSubset
            // 
            this.txtSubset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubset.Location = new System.Drawing.Point(165, 145);
            this.txtSubset.Name = "txtSubset";
            this.txtSubset.Size = new System.Drawing.Size(185, 20);
            this.txtSubset.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "{Cindy, Dan} < Owns a car:";
            // 
            // txtContainsCindy
            // 
            this.txtContainsCindy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContainsCindy.Location = new System.Drawing.Point(165, 253);
            this.txtContainsCindy.Name = "txtContainsCindy";
            this.txtContainsCindy.Size = new System.Drawing.Size(185, 20);
            this.txtContainsCindy.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Owns a car Contains Cindy:";
            // 
            // txtContainsAlice
            // 
            this.txtContainsAlice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContainsAlice.Location = new System.Drawing.Point(165, 227);
            this.txtContainsAlice.Name = "txtContainsAlice";
            this.txtContainsAlice.Size = new System.Drawing.Size(185, 20);
            this.txtContainsAlice.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Owns a car Contains Alice:";
            // 
            // howto_hashset_operators_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 287);
            this.Controls.Add(this.txtContainsCindy);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtContainsAlice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSuperset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSubset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOwnsOne);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOwnsBoth);
            this.Controls.Add(this.txtOwnsEither);
            this.Controls.Add(this.txtOwnsABike);
            this.Controls.Add(this.txtOwnsACar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "howto_hashset_operators_Form1";
            this.Text = "howto_hashset_operators";
            this.Load += new System.EventHandler(this.howto_hashset_operators_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOwnsACar;
        private System.Windows.Forms.TextBox txtOwnsABike;
        private System.Windows.Forms.TextBox txtOwnsBoth;
        private System.Windows.Forms.TextBox txtOwnsEither;
        private System.Windows.Forms.TextBox txtOwnsOne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSuperset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtContainsCindy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtContainsAlice;
        private System.Windows.Forms.Label label9;
    }
}

