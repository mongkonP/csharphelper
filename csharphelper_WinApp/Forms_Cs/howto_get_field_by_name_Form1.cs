using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_field_by_name_Form1:Form
  { 


        public howto_get_field_by_name_Form1()
        {
            InitializeComponent();
        }

        // Some form-level values.
        private string private_value1 = "This is private value 1";
        private string private_value2 = "This is private value 2";
        public string public_value1 = "This is public string value 1";
        public string public_value2 = "This is public string value 2";
        public string[] array1 = { "A", "B", "C" };
        public string[] array2 = { "1", "2", "3" };

        // Display the selected field's value.
        private void cboFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            FieldInfo field_info = this.GetType().GetField(cboFields.Text,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (field_info == null)
            {
                lblValue.Text = "<not found>";
            }
            else if (field_info.FieldType.IsArray)
            {
                // Join the array values into a string.
                string[] values = (string[])field_info.GetValue(this);
                lblValue.Text = string.Join(",", values);
            }
            else
            {
                // Just convert it into a string.
                lblValue.Text = field_info.GetValue(this).ToString();
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
            this.cboFields = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboFields
            // 
            this.cboFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFields.FormattingEnabled = true;
            this.cboFields.Items.AddRange(new object[] {
            "private_value1",
            "private_value2",
            "public_value1",
            "public_value2",
            "array1",
            "array2"});
            this.cboFields.Location = new System.Drawing.Point(58, 13);
            this.cboFields.Name = "cboFields";
            this.cboFields.Size = new System.Drawing.Size(264, 21);
            this.cboFields.TabIndex = 11;
            this.cboFields.SelectedIndexChanged += new System.EventHandler(this.cboFields_SelectedIndexChanged);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(55, 45);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(0, 13);
            this.lblValue.TabIndex = 10;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 45);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(37, 13);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Value:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(32, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Field:";
            // 
            // howto_get_field_by_name_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 71);
            this.Controls.Add(this.cboFields);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "howto_get_field_by_name_Form1";
            this.Text = "howto_get_field_by_name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cboFields;
        internal System.Windows.Forms.Label lblValue;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}

