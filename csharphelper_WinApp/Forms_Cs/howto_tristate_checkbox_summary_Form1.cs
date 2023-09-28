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
     public partial class howto_tristate_checkbox_summary_Form1:Form
  { 


        public howto_tristate_checkbox_summary_Form1()
        {
            InitializeComponent();
        }

        // True if we should ignore check change events.
        private bool IgnoreCheckChangeEvents = false;

        // Select or deselect all CheckBoxes.
        private void chkMeals_CheckStateChanged(object sender, EventArgs e)
        {
            if (IgnoreCheckChangeEvents) return;

            if (chkMeals.CheckState == CheckState.Indeterminate)
                chkMeals.CheckState = CheckState.Unchecked;

            CheckBox[] meal_boxes = { chkBreakfast, chkLunch, chkDinner };
            IgnoreCheckChangeEvents = true;
            foreach (CheckBox chk in meal_boxes)
                chk.Checked = chkMeals.Checked;
            IgnoreCheckChangeEvents = false;
        }

        // The user changed a meal type selection.
        // Update the chkMeals CheckBox.
        private void chkMealType_CheckedChanged(object sender, EventArgs e)
        {
            if (IgnoreCheckChangeEvents) return;

            // See how many meals are selected.
            int num_selected = 0;
            CheckBox[] meal_boxes = { chkBreakfast, chkLunch, chkDinner };
            foreach (CheckBox chk in meal_boxes)
                if (chk.Checked) num_selected++;

            // Set the chkMeals CheckBox appropriately.
            IgnoreCheckChangeEvents = true;
            if (num_selected == 3)
                chkMeals.CheckState = CheckState.Checked;
            else if (num_selected == 0)
                chkMeals.CheckState = CheckState.Unchecked;
            else
                chkMeals.CheckState = CheckState.Indeterminate;
            IgnoreCheckChangeEvents = false;
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
            this.chkMeals = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDinner = new System.Windows.Forms.CheckBox();
            this.chkLunch = new System.Windows.Forms.CheckBox();
            this.chkBreakfast = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkMeals
            // 
            this.chkMeals.AutoSize = true;
            this.chkMeals.Location = new System.Drawing.Point(6, 0);
            this.chkMeals.Name = "chkMeals";
            this.chkMeals.Size = new System.Drawing.Size(54, 17);
            this.chkMeals.TabIndex = 0;
            this.chkMeals.Text = "Meals";
            this.chkMeals.ThreeState = true;
            this.chkMeals.UseVisualStyleBackColor = true;
            this.chkMeals.CheckStateChanged += new System.EventHandler(this.chkMeals_CheckStateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkDinner);
            this.groupBox1.Controls.Add(this.chkLunch);
            this.groupBox1.Controls.Add(this.chkBreakfast);
            this.groupBox1.Controls.Add(this.chkMeals);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 102);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // chkDinner
            // 
            this.chkDinner.AutoSize = true;
            this.chkDinner.Location = new System.Drawing.Point(35, 69);
            this.chkDinner.Name = "chkDinner";
            this.chkDinner.Size = new System.Drawing.Size(57, 17);
            this.chkDinner.TabIndex = 3;
            this.chkDinner.Text = "Dinner";
            this.chkDinner.UseVisualStyleBackColor = true;
            this.chkDinner.CheckStateChanged += new System.EventHandler(this.chkMealType_CheckedChanged);
            // 
            // chkLunch
            // 
            this.chkLunch.AutoSize = true;
            this.chkLunch.Location = new System.Drawing.Point(35, 46);
            this.chkLunch.Name = "chkLunch";
            this.chkLunch.Size = new System.Drawing.Size(56, 17);
            this.chkLunch.TabIndex = 2;
            this.chkLunch.Text = "Lunch";
            this.chkLunch.UseVisualStyleBackColor = true;
            this.chkLunch.CheckStateChanged += new System.EventHandler(this.chkMealType_CheckedChanged);
            // 
            // chkBreakfast
            // 
            this.chkBreakfast.AutoSize = true;
            this.chkBreakfast.Location = new System.Drawing.Point(35, 23);
            this.chkBreakfast.Name = "chkBreakfast";
            this.chkBreakfast.Size = new System.Drawing.Size(71, 17);
            this.chkBreakfast.TabIndex = 1;
            this.chkBreakfast.Text = "Breakfast";
            this.chkBreakfast.UseVisualStyleBackColor = true;
            this.chkBreakfast.CheckStateChanged += new System.EventHandler(this.chkMealType_CheckedChanged);
            this.chkBreakfast.CheckedChanged += new System.EventHandler(this.chkMealType_CheckedChanged);
            // 
            // howto_tristate_checkbox_summary_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 124);
            this.Controls.Add(this.groupBox1);
            this.Name = "howto_tristate_checkbox_summary_Form1";
            this.Text = "howto_tristate_checkbox_summary";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMeals;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBreakfast;
        private System.Windows.Forms.CheckBox chkDinner;
        private System.Windows.Forms.CheckBox chkLunch;
    }
}

