using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_remove_namespace;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_remove_namespace_Form1:Form
  { 


        public howto_remove_namespace_Form1()
        {
            InitializeComponent();
        }

        // Make some people.
        private void howto_remove_namespace_Form1_Load(object sender, EventArgs e)
        {
            Person1 rod = new Person1() { FirstName = "Rod", LastName = "Stephens" };
            txtPerson1.Text = rod.ToString();

            Person2 zaphod = new Person2() { FirstName = "Zaphod", LastName = "Beeblebrox" };
            txtPerson2.Text = zaphod.ToString();
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
            this.txtPerson2 = new System.Windows.Forms.TextBox();
            this.txtPerson1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPerson2
            // 
            this.txtPerson2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerson2.Location = new System.Drawing.Point(12, 41);
            this.txtPerson2.Name = "txtPerson2";
            this.txtPerson2.ReadOnly = true;
            this.txtPerson2.Size = new System.Drawing.Size(300, 20);
            this.txtPerson2.TabIndex = 3;
            // 
            // txtPerson1
            // 
            this.txtPerson1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerson1.Location = new System.Drawing.Point(12, 15);
            this.txtPerson1.Name = "txtPerson1";
            this.txtPerson1.ReadOnly = true;
            this.txtPerson1.Size = new System.Drawing.Size(300, 20);
            this.txtPerson1.TabIndex = 2;
            // 
            // howto_remove_namespace_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 76);
            this.Controls.Add(this.txtPerson2);
            this.Controls.Add(this.txtPerson1);
            this.Name = "howto_remove_namespace_Form1";
            this.Text = "howto_remove_namespace";
            this.Load += new System.EventHandler(this.howto_remove_namespace_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPerson2;
        private System.Windows.Forms.TextBox txtPerson1;
    }
}

