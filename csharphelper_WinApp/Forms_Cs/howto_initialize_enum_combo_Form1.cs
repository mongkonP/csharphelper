using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;

 

using howto_initialize_enum_combo;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_initialize_enum_combo_Form1:Form
  { 


        public howto_initialize_enum_combo_Form1()
        {
            InitializeComponent();
        }

        // The list of user types.
        private enum UserTypes
        {
            SalesAndShippingClerk,
            ShiftSupervisor,
            StoreManager
        }

        // Initialize the cboUserType ComboBox.
        private void howto_initialize_enum_combo_Form1_Load(object sender, EventArgs e)
        {
            foreach (string user_type in Enum.GetNames(typeof(UserTypes)))
            {
                cboUserType.Items.Add(user_type.ToProperCase());
            }
        }

        // Get the selected user type.
        private void cboUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Convert the ComboBox's text into the Pascal cased name.
            string type_name = cboUserType.Text.ToPascalCase();

            // Convert the name into a UserTypes value.
            UserTypes user_type = (UserTypes)Enum.Parse(typeof(UserTypes), type_name);

            // Prove it worked.
            switch (user_type)
            {
                case UserTypes.SalesAndShippingClerk:
                    lblSelectedType.Text = "You selected sales && shipping clerk.";
                    break;
                case UserTypes.ShiftSupervisor:
                    lblSelectedType.Text = "You selected shift supervisor.";
                    break;
                case UserTypes.StoreManager:
                    lblSelectedType.Text = "You selected store manager.";
                    break;
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
            this.cboUserType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectedType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboUserType
            // 
            this.cboUserType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserType.FormattingEnabled = true;
            this.cboUserType.Location = new System.Drawing.Point(77, 12);
            this.cboUserType.Name = "cboUserType";
            this.cboUserType.Size = new System.Drawing.Size(245, 21);
            this.cboUserType.TabIndex = 3;
            this.cboUserType.SelectedIndexChanged += new System.EventHandler(this.cboUserType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Type:";
            // 
            // lblSelectedType
            // 
            this.lblSelectedType.AutoSize = true;
            this.lblSelectedType.Location = new System.Drawing.Point(12, 65);
            this.lblSelectedType.Name = "lblSelectedType";
            this.lblSelectedType.Size = new System.Drawing.Size(0, 13);
            this.lblSelectedType.TabIndex = 4;
            // 
            // howto_initialize_enum_combo_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.lblSelectedType);
            this.Controls.Add(this.cboUserType);
            this.Controls.Add(this.label1);
            this.Name = "howto_initialize_enum_combo_Form1";
            this.Text = "howto_initialize_enum_combo";
            this.Load += new System.EventHandler(this.howto_initialize_enum_combo_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboUserType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedType;
    }
}

