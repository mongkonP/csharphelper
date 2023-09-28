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
     public partial class howto_tristate_checkbox_Form1:Form
  { 


        public howto_tristate_checkbox_Form1()
        {
            InitializeComponent();
        }

        // Make lunch indeterminate.
        private void howto_tristate_checkbox_Form1_Load(object sender, EventArgs e)
        {
            chkLunch.CheckState = CheckState.Indeterminate;
        }

        // Display the CheckBox's current state.
        private void chkMeal_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            lstState.Items.Add(chk.Text + ": " + chk.CheckState);
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
            this.chkBreakfast = new System.Windows.Forms.CheckBox();
            this.chkLunch = new System.Windows.Forms.CheckBox();
            this.chkDinner = new System.Windows.Forms.CheckBox();
            this.lstState = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // chkBreakfast
            // 
            this.chkBreakfast.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkBreakfast.AutoSize = true;
            this.chkBreakfast.Checked = true;
            this.chkBreakfast.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBreakfast.Location = new System.Drawing.Point(41, 12);
            this.chkBreakfast.Name = "chkBreakfast";
            this.chkBreakfast.Size = new System.Drawing.Size(71, 17);
            this.chkBreakfast.TabIndex = 0;
            this.chkBreakfast.Text = "Breakfast";
            this.chkBreakfast.ThreeState = true;
            this.chkBreakfast.UseVisualStyleBackColor = true;
            this.chkBreakfast.CheckStateChanged += new System.EventHandler(this.chkMeal_CheckStateChanged);
            // 
            // chkLunch
            // 
            this.chkLunch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkLunch.AutoSize = true;
            this.chkLunch.Location = new System.Drawing.Point(131, 12);
            this.chkLunch.Name = "chkLunch";
            this.chkLunch.Size = new System.Drawing.Size(56, 17);
            this.chkLunch.TabIndex = 1;
            this.chkLunch.Text = "Lunch";
            this.chkLunch.ThreeState = true;
            this.chkLunch.UseVisualStyleBackColor = true;
            this.chkLunch.CheckStateChanged += new System.EventHandler(this.chkMeal_CheckStateChanged);
            // 
            // chkDinner
            // 
            this.chkDinner.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkDinner.AutoSize = true;
            this.chkDinner.Location = new System.Drawing.Point(206, 12);
            this.chkDinner.Name = "chkDinner";
            this.chkDinner.Size = new System.Drawing.Size(57, 17);
            this.chkDinner.TabIndex = 2;
            this.chkDinner.Text = "Dinner";
            this.chkDinner.ThreeState = true;
            this.chkDinner.UseVisualStyleBackColor = true;
            this.chkDinner.CheckStateChanged += new System.EventHandler(this.chkMeal_CheckStateChanged);
            // 
            // lstState
            // 
            this.lstState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstState.FormattingEnabled = true;
            this.lstState.IntegralHeight = false;
            this.lstState.Location = new System.Drawing.Point(12, 35);
            this.lstState.Name = "lstState";
            this.lstState.Size = new System.Drawing.Size(280, 74);
            this.lstState.TabIndex = 3;
            // 
            // howto_tristate_checkbox_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 121);
            this.Controls.Add(this.lstState);
            this.Controls.Add(this.chkDinner);
            this.Controls.Add(this.chkLunch);
            this.Controls.Add(this.chkBreakfast);
            this.Name = "howto_tristate_checkbox_Form1";
            this.Text = "howto_tristate_checkbox";
            this.Load += new System.EventHandler(this.howto_tristate_checkbox_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBreakfast;
        private System.Windows.Forms.CheckBox chkLunch;
        private System.Windows.Forms.CheckBox chkDinner;
        private System.Windows.Forms.ListBox lstState;
    }
}

