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
     public partial class howto_listbox_item_tooltips_Form1:Form
  { 


        public howto_listbox_item_tooltips_Form1()
        {
            InitializeComponent();
        }

        // Display a tooltip for the animal under the mouse.
        private void lstWeirdAnimals_MouseMove(object sender, MouseEventArgs e)
        {
            // See what item is under the mouse.
            int index = lstWeirdAnimals.IndexFromPoint(e.Location);

            // Just use the item's value for the tooltip.
            string tip = lstWeirdAnimals.Items[index].ToString();

            // Display the item's value as a tooltip.
            if (tipWeirdAnimals.GetToolTip(lstWeirdAnimals) != tip)
                tipWeirdAnimals.SetToolTip(lstWeirdAnimals, tip);
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
            this.lstWeirdAnimals = new System.Windows.Forms.ListBox();
            this.tipWeirdAnimals = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lstWeirdAnimals
            // 
            this.lstWeirdAnimals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWeirdAnimals.FormattingEnabled = true;
            this.lstWeirdAnimals.Items.AddRange(new object[] {
            "Axolotl",
            "Blobfish",
            "Leafy Seadragon",
            "Aye-aye",
            "Dumbo Octopus",
            "Pink Fairy Armadillo",
            "Axolotl",
            "Platypus",
            "Yeti Crab"});
            this.lstWeirdAnimals.Location = new System.Drawing.Point(12, 14);
            this.lstWeirdAnimals.Name = "lstWeirdAnimals";
            this.lstWeirdAnimals.Size = new System.Drawing.Size(310, 95);
            this.lstWeirdAnimals.TabIndex = 1;
            this.lstWeirdAnimals.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstWeirdAnimals_MouseMove);
            // 
            // howto_listbox_item_tooltips_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 122);
            this.Controls.Add(this.lstWeirdAnimals);
            this.Name = "howto_listbox_item_tooltips_Form1";
            this.Text = "howto_listbox_item_tooltips";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstWeirdAnimals;
        private System.Windows.Forms.ToolTip tipWeirdAnimals;
    }
}

