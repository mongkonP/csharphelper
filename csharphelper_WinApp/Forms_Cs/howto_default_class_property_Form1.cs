using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_default_class_property;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_default_class_property_Form1:Form
  { 


        public howto_default_class_property_Form1()
        {
            InitializeComponent();
        }

        private void howto_default_class_property_Form1_Load(object sender, EventArgs e)
        {
            // Make a dictionary.
            DictionaryWithDefault<string, string> dict =
                new DictionaryWithDefault<string, string>("<Missing>");

            // Add some items to the dictionary.
            dict["Ann"] = "Archer";
            dict["Chuck"] = "Cider";
            dict["Dora"] = "Deevers";

            // Display some values.
            lstNames.Items.Add("Ann" + " " + dict["Ann"]);
            lstNames.Items.Add("Ben" + " " + dict["Ben"]);
            lstNames.Items.Add("Chuck" + " " + dict["Chuck"]);
            lstNames.Items.Add("Dora" + " " + dict["Dora"]);
            lstNames.Items.Add("Ed" + " " + dict["Ed"]);
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
            this.lstNames = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstNames
            // 
            this.lstNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNames.FormattingEnabled = true;
            this.lstNames.Location = new System.Drawing.Point(12, 12);
            this.lstNames.Name = "lstNames";
            this.lstNames.Size = new System.Drawing.Size(318, 82);
            this.lstNames.TabIndex = 0;
            // 
            // howto_default_class_property_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 108);
            this.Controls.Add(this.lstNames);
            this.Name = "howto_default_class_property_Form1";
            this.Text = "howto_default_class_property";
            this.Load += new System.EventHandler(this.howto_default_class_property_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstNames;
    }
}

