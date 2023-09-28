using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_add_items_to_combobox;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_add_items_to_combobox_Form1:Form
  { 


        public howto_add_items_to_combobox_Form1()
        {
            InitializeComponent();
        }

        // Load saved ComboBox entries.
        private void howto_add_items_to_combobox_Form1_Load(object sender, EventArgs e)
        {
            // Save the current ComboBox items.
            for (int i = 0; ; i++)
            {
                string animal = RegistryTools.GetSetting(
                    "howto_add_items_to_combobox",
                    "Animals", "Animal" + i.ToString(), "").ToString();
                if (animal == "") break;
                cboAnimal.Items.Add(animal);
            }

            // If we have any choices, select the first.
            if (cboAnimal.Items.Count > 0) cboAnimal.SelectedIndex = 0;
        }

        // Save the current ComboBox choices.
        private void howto_add_items_to_combobox_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Delete previous settings.
            RegistryTools.DeleteSettings("howto_add_items_to_combobox", "Animals");

            // Save the current ComboBox items.
            for (int i = 0; i < cboAnimal.Items.Count; i++)
            {
                RegistryTools.SaveSetting("howto_add_items_to_combobox",
                    "Animals", "Animal" + i.ToString(), cboAnimal.Items[i]);
            }
        }

        // Display the animal selected.
        private void btnOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You selected " + cboAnimal.Text);
        }

        // When focus leaves the control, update its item list.
        private void cboAnimal_Leave(object sender, EventArgs e)
        {
            UpdateCombo(cboAnimal);
        }

        // If the ComboBox's current choice isn't in its list, add it.
        private void UpdateCombo(ComboBox cbo)
        {
            // See if the item is in the list.
            string new_text = cbo.Text;
            foreach (object value in cbo.Items)
            {
                // If the item is already in the list, we're done.
                if (new_text == value.ToString()) return;
            }

            // If we got this far, it's not in the list so add it.
            cbo.Items.Add(new_text);
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
            this.cboAnimal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboAnimal
            // 
            this.cboAnimal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAnimal.FormattingEnabled = true;
            this.cboAnimal.Location = new System.Drawing.Point(59, 14);
            this.cboAnimal.Name = "cboAnimal";
            this.cboAnimal.Size = new System.Drawing.Size(219, 21);
            this.cboAnimal.TabIndex = 0;
            this.cboAnimal.Leave += new System.EventHandler(this.cboAnimal_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Animal:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(284, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // howto_add_items_to_combobox_Form1
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 64);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAnimal);
            this.Name = "howto_add_items_to_combobox_Form1";
            this.Text = "howto_add_items_to_combobox";
            this.Load += new System.EventHandler(this.howto_add_items_to_combobox_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_add_items_to_combobox_Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAnimal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
    }
}

