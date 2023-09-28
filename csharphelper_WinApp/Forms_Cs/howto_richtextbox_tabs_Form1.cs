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
     public partial class howto_richtextbox_tabs_Form1:Form
  { 


        public howto_richtextbox_tabs_Form1()
        {
            InitializeComponent();
        }

        // Set the tabs and enter some text.
        private void howto_richtextbox_tabs_Form1_Load(object sender, EventArgs e)
        {
            rchItems.SelectionTabs = new int[] { 80, 160, 240 };
            rchItems.AcceptsTab = true;

            rchItems.Text =
                "Breakfast\tLunch\tDinner\n" +
                "Coffee\tSoda\tWine\n" +
                "Bagel\tSandwich\tSalad\n" +
                "Fruit\tChips\tTofuburger\n" +
                "\tCookie\tVeggies";
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
            this.rchItems = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rchItems
            // 
            this.rchItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchItems.Location = new System.Drawing.Point(12, 12);
            this.rchItems.Name = "rchItems";
            this.rchItems.Size = new System.Drawing.Size(278, 86);
            this.rchItems.TabIndex = 0;
            this.rchItems.Text = "";
            // 
            // howto_richtextbox_tabs_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 110);
            this.Controls.Add(this.rchItems);
            this.Name = "howto_richtextbox_tabs_Form1";
            this.Text = "howto_richtextbox_tabs";
            this.Load += new System.EventHandler(this.howto_richtextbox_tabs_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchItems;
    }
}

