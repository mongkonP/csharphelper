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
     public partial class howto_use_tooltips_Form1:Form
  { 


        public howto_use_tooltips_Form1()
        {
            InitializeComponent();
        }

        // Add tooltips to the buttons.
        private void btnAddTips_Click(object sender, EventArgs e)
        {
            tipAddress.SetToolTip(btnAddTips, "Click to add tooltips to the buttons.");
            tipAddress.SetToolTip(btnRemoveTips, "Click to remove tooltips from the buttons.");
        }

        // Remove tooltips from the buttons.
        private void btnRemoveTips_Click(object sender, EventArgs e)
        {
            tipAddress.SetToolTip(btnAddTips, "");
            tipAddress.SetToolTip(btnRemoveTips, "");
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
            this.components = new System.ComponentModel.Container();
            this.btnRemoveTips = new System.Windows.Forms.Button();
            this.btnAddTips = new System.Windows.Forms.Button();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tipAddress = new System.Windows.Forms.ToolTip(this.components);
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRemoveTips
            // 
            this.btnRemoveTips.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRemoveTips.Location = new System.Drawing.Point(159, 180);
            this.btnRemoveTips.Name = "btnRemoveTips";
            this.btnRemoveTips.Size = new System.Drawing.Size(92, 23);
            this.btnRemoveTips.TabIndex = 41;
            this.btnRemoveTips.Text = "Remove Tips";
            this.btnRemoveTips.UseVisualStyleBackColor = true;
            this.btnRemoveTips.Click += new System.EventHandler(this.btnRemoveTips_Click);
            // 
            // btnAddTips
            // 
            this.btnAddTips.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddTips.Location = new System.Drawing.Point(33, 180);
            this.btnAddTips.Name = "btnAddTips";
            this.btnAddTips.Size = new System.Drawing.Size(92, 23);
            this.btnAddTips.TabIndex = 40;
            this.btnAddTips.Text = "Add Tips";
            this.btnAddTips.UseVisualStyleBackColor = true;
            this.btnAddTips.Click += new System.EventHandler(this.btnAddTips_Click);
            // 
            // txtStreet
            // 
            this.txtStreet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet.Location = new System.Drawing.Point(84, 65);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(188, 20);
            this.txtStreet.TabIndex = 33;
            this.tipAddress.SetToolTip(this.txtStreet, "Enter the customer\'s street address including apartment or suite number.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Street:";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(84, 39);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(188, 20);
            this.txtLastName.TabIndex = 31;
            this.tipAddress.SetToolTip(this.txtLastName, "Enter the customer\'s last or family name.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Location = new System.Drawing.Point(84, 13);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(188, 20);
            this.txtFirstName.TabIndex = 29;
            this.tipAddress.SetToolTip(this.txtFirstName, "Enter the customer\'s first or given name.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "First Name:";
            // 
            // txtZip
            // 
            this.txtZip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZip.Location = new System.Drawing.Point(84, 143);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(188, 20);
            this.txtZip.TabIndex = 39;
            this.tipAddress.SetToolTip(this.txtZip, "Enter the customer\'s ZIP code or postal code.");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "ZIP:";
            // 
            // txtState
            // 
            this.txtState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtState.Location = new System.Drawing.Point(84, 117);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(188, 20);
            this.txtState.TabIndex = 37;
            this.tipAddress.SetToolTip(this.txtState, "Enter the customer\'s state of residence.");
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.Location = new System.Drawing.Point(84, 91);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(188, 20);
            this.txtCity.TabIndex = 35;
            this.tipAddress.SetToolTip(this.txtCity, "Enter the customer\'s city.");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "State:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "City:";
            // 
            // howto_use_tooltips_Form1
            // 
            this.AcceptButton = this.btnAddTips;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnRemoveTips;
            this.ClientSize = new System.Drawing.Size(284, 216);
            this.Controls.Add(this.btnRemoveTips);
            this.Controls.Add(this.btnAddTips);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label3);
            this.Name = "howto_use_tooltips_Form1";
            this.Text = "howto_use_tooltips";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveTips;
        private System.Windows.Forms.Button btnAddTips;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.ToolTip tipAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
    }
}

