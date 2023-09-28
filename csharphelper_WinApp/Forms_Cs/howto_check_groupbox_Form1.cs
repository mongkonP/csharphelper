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
     public partial class howto_check_groupbox_Form1:Form
  { 


        public howto_check_groupbox_Form1()
        {
            InitializeComponent();
        }

        private void chkBreakfast_CheckedChanged(object sender, EventArgs e)
        {
            ManageCheckGroupBox(chkBreakfast, grpBreakfast);
        }

        private void chkLunch_CheckedChanged(object sender, EventArgs e)
        {
            ManageCheckGroupBox(chkLunch, grpLunch);
        }
        
        private void ManageCheckGroupBox(CheckBox chk, GroupBox grp)
        {
            // Make sure the CheckBox isn't in the GroupBox.
            // This will only happen the first time.
            if (chk.Parent == grp)
            {
                // Reparent the CheckBox so it's not in the GroupBox.
                grp.Parent.Controls.Add(chk);

                // Adjust the CheckBox's location.
                chk.Location = new Point(
                    chk.Left + grp.Left,
                    chk.Top + grp.Top);

                // Move the CheckBox to the top of the stacking order.
                chk.BringToFront();
            }

            // Enable or disable the GroupBox.
            grp.Enabled = chk.Checked;
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
            this.grpBreakfast = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.chkBreakfast = new System.Windows.Forms.CheckBox();
            this.grpLunch = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.chkLunch = new System.Windows.Forms.CheckBox();
            this.grpBreakfast.SuspendLayout();
            this.grpLunch.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBreakfast
            // 
            this.grpBreakfast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBreakfast.Controls.Add(this.radioButton3);
            this.grpBreakfast.Controls.Add(this.radioButton2);
            this.grpBreakfast.Controls.Add(this.radioButton1);
            this.grpBreakfast.Controls.Add(this.chkBreakfast);
            this.grpBreakfast.Location = new System.Drawing.Point(12, 12);
            this.grpBreakfast.Name = "grpBreakfast";
            this.grpBreakfast.Size = new System.Drawing.Size(278, 103);
            this.grpBreakfast.TabIndex = 0;
            this.grpBreakfast.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(25, 69);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(59, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Pickles";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(25, 46);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(73, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Pancakes";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(25, 23);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Toast";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // chkBreakfast
            // 
            this.chkBreakfast.AutoSize = true;
            this.chkBreakfast.Checked = true;
            this.chkBreakfast.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBreakfast.Location = new System.Drawing.Point(6, 0);
            this.chkBreakfast.Name = "chkBreakfast";
            this.chkBreakfast.Size = new System.Drawing.Size(71, 17);
            this.chkBreakfast.TabIndex = 0;
            this.chkBreakfast.Text = "Breakfast";
            this.chkBreakfast.UseVisualStyleBackColor = true;
            this.chkBreakfast.CheckedChanged += new System.EventHandler(this.chkBreakfast_CheckedChanged);
            // 
            // grpLunch
            // 
            this.grpLunch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLunch.Controls.Add(this.radioButton4);
            this.grpLunch.Controls.Add(this.radioButton5);
            this.grpLunch.Controls.Add(this.radioButton6);
            this.grpLunch.Controls.Add(this.chkLunch);
            this.grpLunch.Location = new System.Drawing.Point(12, 121);
            this.grpLunch.Name = "grpLunch";
            this.grpLunch.Size = new System.Drawing.Size(278, 103);
            this.grpLunch.TabIndex = 4;
            this.grpLunch.TabStop = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(25, 69);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(92, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Rack of Lamb";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(25, 46);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(50, 17);
            this.radioButton5.TabIndex = 2;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Soup";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(25, 23);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(72, 17);
            this.radioButton6.TabIndex = 1;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Sandwich";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // chkLunch
            // 
            this.chkLunch.AutoSize = true;
            this.chkLunch.Checked = true;
            this.chkLunch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLunch.Location = new System.Drawing.Point(6, 0);
            this.chkLunch.Name = "chkLunch";
            this.chkLunch.Size = new System.Drawing.Size(56, 17);
            this.chkLunch.TabIndex = 0;
            this.chkLunch.Text = "Lunch";
            this.chkLunch.UseVisualStyleBackColor = true;
            this.chkLunch.CheckedChanged += new System.EventHandler(this.chkLunch_CheckedChanged);
            // 
            // howto_check_groupbox_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 234);
            this.Controls.Add(this.grpLunch);
            this.Controls.Add(this.grpBreakfast);
            this.Name = "howto_check_groupbox_Form1";
            this.Text = "howto_check_groupbox";
            this.grpBreakfast.ResumeLayout(false);
            this.grpBreakfast.PerformLayout();
            this.grpLunch.ResumeLayout(false);
            this.grpLunch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBreakfast;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox chkBreakfast;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox grpLunch;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.CheckBox chkLunch;
    }
}

