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
     public partial class howto_array_of_controls_Form1:Form
  { 


        public howto_array_of_controls_Form1()
        {
            InitializeComponent();
        }

        // Arrays of controls.
        private CheckBox[] BreakfastControls, LunchControls, DinnerControls;

        // Initialize the arrays of controls.
        private void howto_array_of_controls_Form1_Load(object sender, EventArgs e)
        {
            BreakfastControls = new CheckBox[] { chkCereal, chkToast, chkOrangeJuice };
            LunchControls = new CheckBox[] { chkSandwhich, chkChips, chkSoda };
            DinnerControls = new CheckBox[] { chkSalad, chkTofuburger, chkWine };
        }

        // Reset the breakfast controls.
        private void btnResetBreakfast_Click(object sender, EventArgs e)
        {
            foreach (CheckBox chk in BreakfastControls)
            {
                chk.Checked = false;
            }
        }

        // Reset the lunch controls.
        private void btnResetLunch_Click(object sender, EventArgs e)
        {
            foreach (CheckBox chk in LunchControls)
            {
                chk.Checked = false;
            }
        }

        // Reset the dinner controls.
        private void btnResetDinner_Click(object sender, EventArgs e)
        {
            foreach (CheckBox chk in DinnerControls)
            {
                chk.Checked = false;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkOrangeJuice = new System.Windows.Forms.CheckBox();
            this.chkToast = new System.Windows.Forms.CheckBox();
            this.chkCereal = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSoda = new System.Windows.Forms.CheckBox();
            this.chkChips = new System.Windows.Forms.CheckBox();
            this.chkSandwhich = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkWine = new System.Windows.Forms.CheckBox();
            this.chkTofuburger = new System.Windows.Forms.CheckBox();
            this.chkSalad = new System.Windows.Forms.CheckBox();
            this.btnResetBreakfast = new System.Windows.Forms.Button();
            this.btnResetLunch = new System.Windows.Forms.Button();
            this.btnResetDinner = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnResetBreakfast);
            this.groupBox1.Controls.Add(this.chkOrangeJuice);
            this.groupBox1.Controls.Add(this.chkToast);
            this.groupBox1.Controls.Add(this.chkCereal);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Breakfast";
            // 
            // chkOrangeJuice
            // 
            this.chkOrangeJuice.AutoSize = true;
            this.chkOrangeJuice.Location = new System.Drawing.Point(23, 65);
            this.chkOrangeJuice.Name = "chkOrangeJuice";
            this.chkOrangeJuice.Size = new System.Drawing.Size(89, 17);
            this.chkOrangeJuice.TabIndex = 2;
            this.chkOrangeJuice.Text = "Orange Juice";
            this.chkOrangeJuice.UseVisualStyleBackColor = true;
            // 
            // chkToast
            // 
            this.chkToast.AutoSize = true;
            this.chkToast.Location = new System.Drawing.Point(23, 42);
            this.chkToast.Name = "chkToast";
            this.chkToast.Size = new System.Drawing.Size(53, 17);
            this.chkToast.TabIndex = 1;
            this.chkToast.Text = "Toast";
            this.chkToast.UseVisualStyleBackColor = true;
            // 
            // chkCereal
            // 
            this.chkCereal.AutoSize = true;
            this.chkCereal.Location = new System.Drawing.Point(23, 19);
            this.chkCereal.Name = "chkCereal";
            this.chkCereal.Size = new System.Drawing.Size(56, 17);
            this.chkCereal.TabIndex = 0;
            this.chkCereal.Text = "Cereal";
            this.chkCereal.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnResetLunch);
            this.groupBox2.Controls.Add(this.chkSoda);
            this.groupBox2.Controls.Add(this.chkChips);
            this.groupBox2.Controls.Add(this.chkSandwhich);
            this.groupBox2.Location = new System.Drawing.Point(148, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lunch";
            // 
            // chkSoda
            // 
            this.chkSoda.AutoSize = true;
            this.chkSoda.Location = new System.Drawing.Point(21, 65);
            this.chkSoda.Name = "chkSoda";
            this.chkSoda.Size = new System.Drawing.Size(51, 17);
            this.chkSoda.TabIndex = 5;
            this.chkSoda.Text = "Soda";
            this.chkSoda.UseVisualStyleBackColor = true;
            // 
            // chkChips
            // 
            this.chkChips.AutoSize = true;
            this.chkChips.Location = new System.Drawing.Point(21, 42);
            this.chkChips.Name = "chkChips";
            this.chkChips.Size = new System.Drawing.Size(52, 17);
            this.chkChips.TabIndex = 4;
            this.chkChips.Text = "Chips";
            this.chkChips.UseVisualStyleBackColor = true;
            // 
            // chkSandwhich
            // 
            this.chkSandwhich.AutoSize = true;
            this.chkSandwhich.Location = new System.Drawing.Point(21, 19);
            this.chkSandwhich.Name = "chkSandwhich";
            this.chkSandwhich.Size = new System.Drawing.Size(73, 17);
            this.chkSandwhich.TabIndex = 3;
            this.chkSandwhich.Text = "Sandwich";
            this.chkSandwhich.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnResetDinner);
            this.groupBox3.Controls.Add(this.chkWine);
            this.groupBox3.Controls.Add(this.chkTofuburger);
            this.groupBox3.Controls.Add(this.chkSalad);
            this.groupBox3.Location = new System.Drawing.Point(284, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(130, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dinner";
            // 
            // chkWine
            // 
            this.chkWine.AutoSize = true;
            this.chkWine.Location = new System.Drawing.Point(21, 65);
            this.chkWine.Name = "chkWine";
            this.chkWine.Size = new System.Drawing.Size(51, 17);
            this.chkWine.TabIndex = 5;
            this.chkWine.Text = "Wine";
            this.chkWine.UseVisualStyleBackColor = true;
            // 
            // chkTofuburger
            // 
            this.chkTofuburger.AutoSize = true;
            this.chkTofuburger.Location = new System.Drawing.Point(21, 42);
            this.chkTofuburger.Name = "chkTofuburger";
            this.chkTofuburger.Size = new System.Drawing.Size(78, 17);
            this.chkTofuburger.TabIndex = 4;
            this.chkTofuburger.Text = "Tofuburger";
            this.chkTofuburger.UseVisualStyleBackColor = true;
            // 
            // chkSalad
            // 
            this.chkSalad.AutoSize = true;
            this.chkSalad.Location = new System.Drawing.Point(21, 19);
            this.chkSalad.Name = "chkSalad";
            this.chkSalad.Size = new System.Drawing.Size(53, 17);
            this.chkSalad.TabIndex = 3;
            this.chkSalad.Text = "Salad";
            this.chkSalad.UseVisualStyleBackColor = true;
            // 
            // btnResetBreakfast
            // 
            this.btnResetBreakfast.Image = Properties.Resources.Repeat;
            this.btnResetBreakfast.Location = new System.Drawing.Point(108, 13);
            this.btnResetBreakfast.Name = "btnResetBreakfast";
            this.btnResetBreakfast.Size = new System.Drawing.Size(22, 23);
            this.btnResetBreakfast.TabIndex = 6;
            this.btnResetBreakfast.UseVisualStyleBackColor = true;
            this.btnResetBreakfast.Click += new System.EventHandler(this.btnResetBreakfast_Click);
            // 
            // btnResetLunch
            // 
            this.btnResetLunch.Image = Properties.Resources.Repeat;
            this.btnResetLunch.Location = new System.Drawing.Point(102, 13);
            this.btnResetLunch.Name = "btnResetLunch";
            this.btnResetLunch.Size = new System.Drawing.Size(22, 23);
            this.btnResetLunch.TabIndex = 7;
            this.btnResetLunch.UseVisualStyleBackColor = true;
            this.btnResetLunch.Click += new System.EventHandler(this.btnResetLunch_Click);
            // 
            // btnResetDinner
            // 
            this.btnResetDinner.Image = Properties.Resources.Repeat;
            this.btnResetDinner.Location = new System.Drawing.Point(102, 13);
            this.btnResetDinner.Name = "btnResetDinner";
            this.btnResetDinner.Size = new System.Drawing.Size(22, 23);
            this.btnResetDinner.TabIndex = 8;
            this.btnResetDinner.UseVisualStyleBackColor = true;
            this.btnResetDinner.Click += new System.EventHandler(this.btnResetDinner_Click);
            // 
            // howto_array_of_controls_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 124);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "howto_array_of_controls_Form1";
            this.Text = "howto_array_of_controls";
            this.Load += new System.EventHandler(this.howto_array_of_controls_Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkOrangeJuice;
        private System.Windows.Forms.CheckBox chkToast;
        private System.Windows.Forms.CheckBox chkCereal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSoda;
        private System.Windows.Forms.CheckBox chkChips;
        private System.Windows.Forms.CheckBox chkSandwhich;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkWine;
        private System.Windows.Forms.CheckBox chkTofuburger;
        private System.Windows.Forms.CheckBox chkSalad;
        private System.Windows.Forms.Button btnResetBreakfast;
        private System.Windows.Forms.Button btnResetLunch;
        private System.Windows.Forms.Button btnResetDinner;
    }
}

