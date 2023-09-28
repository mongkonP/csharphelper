using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_randomize_pick_extension;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_randomize_pick_extension_Form1:Form
  { 


        public howto_randomize_pick_extension_Form1()
        {
            InitializeComponent();
        }

        // The values from which to pick randomly.
        private string[] ArrayValues =
        {
            "Ape",
            "Bear",
            "Cat",
            "Dog",
            "Elf",
            "Frog",
            "Giraffe",
        };
        private List<string> ListValues;

        // Initialize the list from the array.
        private void howto_randomize_pick_extension_Form1_Load(object sender, EventArgs e)
        {
            ListValues = new List<string>();
            foreach (string value in ArrayValues)
                ListValues.Add(value);

            lstItems.DataSource = ArrayValues;
        }

        // Pick a random value.
        private void btnPick_Click(object sender, EventArgs e)
        {
            txtFromArray.Text = ArrayValues.RandomElement();
            txtFromList.Text = ListValues.RandomElement();
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
            this.btnPick = new System.Windows.Forms.Button();
            this.txtFromArray = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFromList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnPick
            // 
            this.btnPick.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPick.Location = new System.Drawing.Point(141, 62);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(75, 23);
            this.btnPick.TabIndex = 1;
            this.btnPick.Text = "Pick";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // txtFromArray
            // 
            this.txtFromArray.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFromArray.Location = new System.Drawing.Point(295, 50);
            this.txtFromArray.Name = "txtFromArray";
            this.txtFromArray.ReadOnly = true;
            this.txtFromArray.Size = new System.Drawing.Size(67, 20);
            this.txtFromArray.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From Array:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "From List:";
            // 
            // txtFromList
            // 
            this.txtFromList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFromList.Location = new System.Drawing.Point(295, 76);
            this.txtFromList.Name = "txtFromList";
            this.txtFromList.ReadOnly = true;
            this.txtFromList.Size = new System.Drawing.Size(67, 20);
            this.txtFromList.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Items:";
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstItems.FormattingEnabled = true;
            this.lstItems.IntegralHeight = false;
            this.lstItems.Location = new System.Drawing.Point(15, 25);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(120, 109);
            this.lstItems.TabIndex = 0;
            // 
            // howto_randomize_pick_extension_Form1
            // 
            this.AcceptButton = this.btnPick;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 146);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFromList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFromArray);
            this.Controls.Add(this.btnPick);
            this.Name = "howto_randomize_pick_extension_Form1";
            this.Text = "howto_randomize_pick_extension";
            this.Load += new System.EventHandler(this.howto_randomize_pick_extension_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.TextBox txtFromArray;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFromList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstItems;
    }
}

