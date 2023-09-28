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
     public partial class howto_limited_selections_Form1:Form
  { 


        public howto_limited_selections_Form1()
        {
            InitializeComponent();
        }

        // The selected CheckBoxes.
        private int NumAllowedOptions = 2;
        private List<CheckBox> Selections = new List<CheckBox>();

        // Make sure we don't have too many options selected.
        private void chkOption_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Checked)
            {
                // Add this selection.
                Selections.Add(chk);

                // Make sure we don't have too many.
                if (Selections.Count > NumAllowedOptions)
                {
                    // Remove the oldest selection.
                    Selections[0].Checked = false;
                }
            }
            else
            {
                // Remove this selection.
                Selections.Remove(chk);
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
            this.chkCruiseControl = new System.Windows.Forms.CheckBox();
            this.chkRemoteKeylessEntry = new System.Windows.Forms.CheckBox();
            this.chkAirConditioning = new System.Windows.Forms.CheckBox();
            this.chkPowerWindows = new System.Windows.Forms.CheckBox();
            this.chkLaserCannon = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkCruiseControl
            // 
            this.chkCruiseControl.AutoSize = true;
            this.chkCruiseControl.Location = new System.Drawing.Point(28, 28);
            this.chkCruiseControl.Name = "chkCruiseControl";
            this.chkCruiseControl.Size = new System.Drawing.Size(91, 17);
            this.chkCruiseControl.TabIndex = 0;
            this.chkCruiseControl.Text = "Cruise Control";
            this.chkCruiseControl.UseVisualStyleBackColor = true;
            this.chkCruiseControl.CheckedChanged += new System.EventHandler(this.chkOption_CheckedChanged);
            // 
            // chkRemoteKeylessEntry
            // 
            this.chkRemoteKeylessEntry.AutoSize = true;
            this.chkRemoteKeylessEntry.Location = new System.Drawing.Point(28, 51);
            this.chkRemoteKeylessEntry.Name = "chkRemoteKeylessEntry";
            this.chkRemoteKeylessEntry.Size = new System.Drawing.Size(129, 17);
            this.chkRemoteKeylessEntry.TabIndex = 1;
            this.chkRemoteKeylessEntry.Text = "Remote Keyless Entry";
            this.chkRemoteKeylessEntry.UseVisualStyleBackColor = true;
            this.chkRemoteKeylessEntry.CheckedChanged += new System.EventHandler(this.chkOption_CheckedChanged);
            // 
            // chkAirConditioning
            // 
            this.chkAirConditioning.AutoSize = true;
            this.chkAirConditioning.Location = new System.Drawing.Point(28, 74);
            this.chkAirConditioning.Name = "chkAirConditioning";
            this.chkAirConditioning.Size = new System.Drawing.Size(99, 17);
            this.chkAirConditioning.TabIndex = 2;
            this.chkAirConditioning.Text = "Air Conditioning";
            this.chkAirConditioning.UseVisualStyleBackColor = true;
            this.chkAirConditioning.CheckedChanged += new System.EventHandler(this.chkOption_CheckedChanged);
            // 
            // chkPowerWindows
            // 
            this.chkPowerWindows.AutoSize = true;
            this.chkPowerWindows.Location = new System.Drawing.Point(28, 97);
            this.chkPowerWindows.Name = "chkPowerWindows";
            this.chkPowerWindows.Size = new System.Drawing.Size(103, 17);
            this.chkPowerWindows.TabIndex = 3;
            this.chkPowerWindows.Text = "Power Windows";
            this.chkPowerWindows.UseVisualStyleBackColor = true;
            this.chkPowerWindows.CheckedChanged += new System.EventHandler(this.chkOption_CheckedChanged);
            // 
            // chkLaserCannon
            // 
            this.chkLaserCannon.AutoSize = true;
            this.chkLaserCannon.Location = new System.Drawing.Point(28, 120);
            this.chkLaserCannon.Name = "chkLaserCannon";
            this.chkLaserCannon.Size = new System.Drawing.Size(92, 17);
            this.chkLaserCannon.TabIndex = 4;
            this.chkLaserCannon.Text = "Laser Cannon";
            this.chkLaserCannon.UseVisualStyleBackColor = true;
            this.chkLaserCannon.CheckedChanged += new System.EventHandler(this.chkOption_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkRemoteKeylessEntry);
            this.groupBox1.Controls.Add(this.chkLaserCannon);
            this.groupBox1.Controls.Add(this.chkCruiseControl);
            this.groupBox1.Controls.Add(this.chkPowerWindows);
            this.groupBox1.Controls.Add(this.chkAirConditioning);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 147);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pick 2 Options";
            // 
            // howto_limited_selections_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 171);
            this.Controls.Add(this.groupBox1);
            this.Name = "howto_limited_selections_Form1";
            this.Text = "howto_limited_selections";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCruiseControl;
        private System.Windows.Forms.CheckBox chkRemoteKeylessEntry;
        private System.Windows.Forms.CheckBox chkAirConditioning;
        private System.Windows.Forms.CheckBox chkPowerWindows;
        private System.Windows.Forms.CheckBox chkLaserCannon;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

