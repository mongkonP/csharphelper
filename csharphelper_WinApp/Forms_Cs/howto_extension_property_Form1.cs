using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_extension_property;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_extension_property_Form1:Form
  { 


        public howto_extension_property_Form1()
        {
            InitializeComponent();
        }

        // Set the value for the txtName TextBox.
        private void btnSetValue_Click(object sender, EventArgs e)
        {
            txtName.SetValue(txtName.Text, txtValue.Text);
            txtValue.Clear();
        }

        // Get the value from the txtName TextBox.
        private void btnGetValue_Click(object sender, EventArgs e)
        {
            txtValue.Text = txtName.GetValue(txtName.Text, "<unknown>").ToString();
        }

        // Remove the value from the txtName TextBox.
        private void btnRemoveValue_Click(object sender, EventArgs e)
        {
            txtName.RemoveValue(txtName.Text);
            txtValue.Clear();
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
            this.btnRemoveValue = new System.Windows.Forms.Button();
            this.btnGetValue = new System.Windows.Forms.Button();
            this.btnSetValue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRemoveValue
            // 
            this.btnRemoveValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRemoveValue.Location = new System.Drawing.Point(210, 72);
            this.btnRemoveValue.Name = "btnRemoveValue";
            this.btnRemoveValue.Size = new System.Drawing.Size(91, 23);
            this.btnRemoveValue.TabIndex = 13;
            this.btnRemoveValue.Text = "Remove Value";
            this.btnRemoveValue.UseVisualStyleBackColor = true;
            this.btnRemoveValue.Click += new System.EventHandler(this.btnRemoveValue_Click);
            // 
            // btnGetValue
            // 
            this.btnGetValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGetValue.Location = new System.Drawing.Point(113, 72);
            this.btnGetValue.Name = "btnGetValue";
            this.btnGetValue.Size = new System.Drawing.Size(91, 23);
            this.btnGetValue.TabIndex = 12;
            this.btnGetValue.Text = "Get Value";
            this.btnGetValue.UseVisualStyleBackColor = true;
            this.btnGetValue.Click += new System.EventHandler(this.btnGetValue_Click);
            // 
            // btnSetValue
            // 
            this.btnSetValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSetValue.Location = new System.Drawing.Point(16, 72);
            this.btnSetValue.Name = "btnSetValue";
            this.btnSetValue.Size = new System.Drawing.Size(91, 23);
            this.btnSetValue.TabIndex = 11;
            this.btnSetValue.Text = "Set Value";
            this.btnSetValue.UseVisualStyleBackColor = true;
            this.btnSetValue.Click += new System.EventHandler(this.btnSetValue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Value:";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(98, 37);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(207, 20);
            this.txtValue.TabIndex = 9;
            this.txtValue.Text = "Test value.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Property Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(98, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 20);
            this.txtName.TabIndex = 7;
            this.txtName.Text = "Property1";
            // 
            // howto_extension_property_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 106);
            this.Controls.Add(this.btnRemoveValue);
            this.Controls.Add(this.btnGetValue);
            this.Controls.Add(this.btnSetValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "howto_extension_property_Form1";
            this.Text = "howto_extension_property";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveValue;
        private System.Windows.Forms.Button btnGetValue;
        private System.Windows.Forms.Button btnSetValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
    }
}

