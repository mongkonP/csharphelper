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
     public partial class howto_hashsets_Form1:Form
  { 


        public howto_hashsets_Form1()
        {
            InitializeComponent();
        }

        // Make some sets and perform operations on them.
        private void howto_hashsets_Form1_Load(object sender, EventArgs e)
        {
            HashSet<string> owns_a_car = new HashSet<string>();
            HashSet<string> owns_a_bike = new HashSet<string>();

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
            HashSet<string> owns_both = new HashSet<string>(owns_a_car);
            owns_both.IntersectWith(owns_a_bike);
            txtOwnsBoth.Text = string.Join(", ", owns_both.ToArray());

            // Union.
            HashSet<string> owns_either = new HashSet<string>(owns_a_car);
            owns_either.UnionWith(owns_a_bike);
            txtOwnsEither.Text = string.Join(", ", owns_either.ToArray());

            // Xor.
            HashSet<string> owns_one = new HashSet<string>(owns_a_car);
            owns_one.SymmetricExceptWith(owns_a_bike);
            txtOwnsOne.Text = string.Join(", ", owns_one.ToArray());
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
            this.txtOwnsACar.Location = new System.Drawing.Point(107, 12);
            this.txtOwnsACar.Name = "txtOwnsACar";
            this.txtOwnsACar.Size = new System.Drawing.Size(190, 20);
            this.txtOwnsACar.TabIndex = 7;
            // 
            // txtOwnsABike
            // 
            this.txtOwnsABike.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwnsABike.Location = new System.Drawing.Point(107, 38);
            this.txtOwnsABike.Name = "txtOwnsABike";
            this.txtOwnsABike.Size = new System.Drawing.Size(190, 20);
            this.txtOwnsABike.TabIndex = 8;
            // 
            // txtOwnsBoth
            // 
            this.txtOwnsBoth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwnsBoth.Location = new System.Drawing.Point(107, 90);
            this.txtOwnsBoth.Name = "txtOwnsBoth";
            this.txtOwnsBoth.Size = new System.Drawing.Size(190, 20);
            this.txtOwnsBoth.TabIndex = 10;
            // 
            // txtOwnsEither
            // 
            this.txtOwnsEither.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwnsEither.Location = new System.Drawing.Point(107, 64);
            this.txtOwnsEither.Name = "txtOwnsEither";
            this.txtOwnsEither.Size = new System.Drawing.Size(190, 20);
            this.txtOwnsEither.TabIndex = 9;
            // 
            // txtOwnsOne
            // 
            this.txtOwnsOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwnsOne.Location = new System.Drawing.Point(107, 116);
            this.txtOwnsOne.Name = "txtOwnsOne";
            this.txtOwnsOne.Size = new System.Drawing.Size(190, 20);
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
            // howto_hashsets_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 150);
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
            this.Name = "howto_hashsets_Form1";
            this.Text = "howto_hashsets";
            this.Load += new System.EventHandler(this.howto_hashsets_Form1_Load);
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
    }
}

