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
     public partial class howto_obsolete_attribute_Form1:Form
  { 


        public howto_obsolete_attribute_Form1()
        {
            InitializeComponent();
        }

        private void howto_obsolete_attribute_Form1_Load(object sender, EventArgs e)
        {
           /* Allowed();
            Disallowed();*/
        }

        [Obsolete("This method will soon be discontinued. Use the new version instead.", false)]
        private void Allowed()
        {
        }

        [Obsolete("This method is no longer allowed. Use the new version instead.", true)]
        private void Disallowed()
        {
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
            this.SuspendLayout();
            // 
            // howto_obsolete_attribute_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Name = "howto_obsolete_attribute_Form1";
            this.Text = "howto_obsolete_attribute";
            this.Load += new System.EventHandler(this.howto_obsolete_attribute_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

