using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_enum_values_easily_Form1:Form
  { 


        public howto_list_enum_values_easily_Form1()
        {
            InitializeComponent();
        }

        private void howto_list_enum_values_easily_Form1_Load(object sender, EventArgs e)
        {
            lstValues.DataSource = Enum.GetValues(typeof(HatchStyle));
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
            this.lstValues = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstValues
            // 
            this.lstValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstValues.FormattingEnabled = true;
            this.lstValues.IntegralHeight = false;
            this.lstValues.Location = new System.Drawing.Point(12, 12);
            this.lstValues.MultiColumn = true;
            this.lstValues.Name = "lstValues";
            this.lstValues.Size = new System.Drawing.Size(484, 205);
            this.lstValues.TabIndex = 0;
            // 
            // howto_list_enum_values_easily_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 229);
            this.Controls.Add(this.lstValues);
            this.Name = "howto_list_enum_values_easily_Form1";
            this.Text = "howto_list_enum_values_easily";
            this.Load += new System.EventHandler(this.howto_list_enum_values_easily_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstValues;
    }
}

