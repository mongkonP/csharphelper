using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_validate_fields2_Form1:Form
  { 


        public howto_validate_fields2_Form1()
        {
            InitializeComponent();
        }

        // Validate a required field. Return true if the field is valid.
        private bool ValidateRequiredField(ErrorProvider err, TextBox txt)
        {
            if (txt.Text.Length > 0)
            {
                // Clear the error.
                err.SetError(txt, "");
                return false;
            }
            else
            {
                // Set the error.
                err.SetError(txt, CamelCaseToWords(txt.Name) + " must not be blank.");
                return true;
            }
        }

        // Validate fields.
        private void txtRequiredField_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;
            ValidateRequiredField(errField, txt);
        }

        // Split a string in camelCase, removing the prefix.
        private string CamelCaseToWords(string input)
        {
            // Insert a space in front of each capital letter.
            string result = "";
            foreach (char ch in input.ToCharArray())
            {
                if (char.IsUpper(ch)) result += " ";
                result += ch;
            }

            // Find the first space and remove everything before it.
            return result.Substring(result.IndexOf(" ") + 1);
        }

        // Validate the ZIP code.
        private void txtZip_Validating(object sender, CancelEventArgs e)
        {
            ValidateZipCode(errField, txtZip);
        }

        // Validate the ZIP code.
        private void ValidateZipCode(ErrorProvider err, TextBox txt)
        {
            // Check for missing value.
            if (ValidateRequiredField(err, txt)) return;

            // Check for correct format.
            Regex regex = new Regex(@"^(\d{5}|\d{5}-\d{4})$");
            if (regex.IsMatch(txt.Text))
            {
                // Clear the error.
                errField.SetError(txt, "");
            }
            else
            {
                // Set the error.
                errField.SetError(txt, "ZIP code must have format ##### or #####-####.");
            }
        }

        // The user accepted the values.
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Validate all fields.
            ValidateRequiredField(errField, txtFirstName);
            ValidateRequiredField(errField, txtLastName);
            ValidateRequiredField(errField, txtStreet);
            ValidateRequiredField(errField, txtCity);
            ValidateRequiredField(errField, txtState);
            ValidateZipCode(errField, txtZip);

            // See if any field has an error message.
            foreach (Control ctl in Controls)
            {
                if (errField.GetError(ctl) != "")
                {
                    MessageBox.Show(errField.GetError(ctl));
                    return;
                }
            }

            MessageBox.Show("You entered:\n" +
                txtFirstName.Text + ' ' + txtLastName.Text + '\n' +
                txtStreet.Name + '\n' +
                txtCity.Name + '\t' + txtState.Text + '\t' + txtZip.Text);
        }

        // Close.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errField = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtState = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errField)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(191, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(110, 184);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 31;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtStreet
            // 
            this.txtStreet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet.Location = new System.Drawing.Point(85, 64);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(181, 20);
            this.txtStreet.TabIndex = 27;
            this.txtStreet.Validating += new System.ComponentModel.CancelEventHandler(this.txtRequiredField_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Street:";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(85, 38);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(181, 20);
            this.txtLastName.TabIndex = 26;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtRequiredField_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Location = new System.Drawing.Point(85, 12);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(181, 20);
            this.txtFirstName.TabIndex = 25;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtRequiredField_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "First Name:";
            // 
            // txtZip
            // 
            this.txtZip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZip.Location = new System.Drawing.Point(85, 142);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(181, 20);
            this.txtZip.TabIndex = 30;
            this.txtZip.Validating += new System.ComponentModel.CancelEventHandler(this.txtZip_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "ZIP:";
            // 
            // errField
            // 
            this.errField.ContainerControl = this;
            // 
            // txtState
            // 
            this.txtState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtState.Location = new System.Drawing.Point(85, 116);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(181, 20);
            this.txtState.TabIndex = 29;
            this.txtState.Validating += new System.ComponentModel.CancelEventHandler(this.txtRequiredField_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "State:";
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.Location = new System.Drawing.Point(85, 90);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(181, 20);
            this.txtCity.TabIndex = 28;
            this.txtCity.Validating += new System.ComponentModel.CancelEventHandler(this.txtRequiredField_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "City:";
            // 
            // howto_validate_fields2_Form1
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 219);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
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
            this.Name = "howto_validate_fields2_Form1";
            this.Text = "howto_validate_fields2";
            ((System.ComponentModel.ISupportInitialize)(this.errField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errField;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label3;
    }
}

