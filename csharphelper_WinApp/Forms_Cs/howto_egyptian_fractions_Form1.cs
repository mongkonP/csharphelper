using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_egyptian_fractions;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_egyptian_fractions_Form1:Form
  { 


        public howto_egyptian_fractions_Form1()
        {
            InitializeComponent();
        }

        // Calculate the Eqgyptian fraction representation
        // for the original fraction.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get the fraction (and make it positive).
            Fraction frac = new Fraction(txtFraction.Text);
            if (frac < 0) frac = -frac;

            // Get the Egyptian fraction.
            List<Fraction> fractions = GetEgyptianFraction(frac);

            // Display the result as a string
            string result = "";
            foreach (Fraction unit_fraction in fractions)
            {
                result = result + unit_fraction.ToString() + " + ";
            }
            if (result.Length > 0) result = result.Substring(0, result.Length - 3);

            txtResult.Text = result;
        }

        // Return a string representation of the Egyptian fraction.
        private List<Fraction> GetEgyptianFraction(Fraction frac)
        {
            List<Fraction> result = new List<Fraction>();

            // Remove any whole number part.
            int whole_part = (int)(frac.Numerator / frac.Denominator);
            if (whole_part > 0)
            {
                result.Add(whole_part);
                frac = frac - whole_part;
            }

            // Pull out unit fractions.
            long denom = 2;
            while (frac > 0)
            {
                // Make the unit fraction smaller until it fits.
                Fraction unit_fraction = new Fraction(1, denom);
                while (unit_fraction > frac)
                {
                    denom++;
                    unit_fraction = new Fraction(1, denom);
                }

                // Remove the unit fraction.
                result.Add(unit_fraction);
                frac -= unit_fraction;
                denom++;
            }

            return result;
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
            this.txtFraction = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fraction:";
            // 
            // txtFraction
            // 
            this.txtFraction.Location = new System.Drawing.Point(67, 14);
            this.txtFraction.Name = "txtFraction";
            this.txtFraction.Size = new System.Drawing.Size(65, 20);
            this.txtFraction.TabIndex = 1;
            this.txtFraction.Text = "3/7";
            this.txtFraction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(247, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(12, 49);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(310, 20);
            this.txtResult.TabIndex = 3;
            // 
            // howto_egyptian_fractions_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 86);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtFraction);
            this.Controls.Add(this.label1);
            this.Name = "howto_egyptian_fractions_Form1";
            this.Text = "howto_egyptian_fractions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFraction;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtResult;
    }
}

