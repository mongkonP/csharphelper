using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_assign_people_to_groups;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_assign_people_to_groups_Form1:Form
  { 


        public howto_assign_people_to_groups_Form1()
        {
            InitializeComponent();
        }

        // Assign the people to groups.
        private void btnAssign_Click(object sender, EventArgs e)
        {
            // Get the names into an array.
            int numPeople = lstPeople.Items.Count;
            string[] names = new string[numPeople];
            lstPeople.Items.CopyTo(names, 0);

            // Randomize.
            Randomizer.Randomize<string>(names);

            // Divide the names into groups.
            int numGroups = int.Parse(txtNumGroups.Text);
            lstResult.Items.Clear();
            int groupNum = 0;
            for (int i = 0; i < numPeople; i++)
            {
                lstResult.Items.Add(groupNum.ToString() +
                    "    " + names[i]);
                groupNum = ++groupNum % numGroups;
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
            this.lstPeople = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumGroups = new System.Windows.Forms.TextBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstPeople
            // 
            this.lstPeople.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPeople.FormattingEnabled = true;
            this.lstPeople.Items.AddRange(new object[] {
            "Allie Postell",
            "Carmella Armwood",
            "Christian Urbanski",
            "Darryl Bjerke",
            "Darryl Ellenwood",
            "Eve Brightwell",
            "Eve Claborn",
            "Guy Lucena",
            "Harriett Southward",
            "Julio Fasano",
            "Kurt Fabiano",
            "Lance Ensey",
            "Loraine Bibbins",
            "Louisa Vandemark",
            "Max Carra",
            "Nannie Patchett",
            "Noemi Nilles",
            "Pearlie Bartleson",
            "Tabatha Lagrone",
            "Wyer Johnson"});
            this.lstPeople.Location = new System.Drawing.Point(12, 12);
            this.lstPeople.Name = "lstPeople";
            this.lstPeople.Size = new System.Drawing.Size(121, 277);
            this.lstPeople.Sorted = true;
            this.lstPeople.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "# Groups:";
            // 
            // txtNumGroups
            // 
            this.txtNumGroups.Location = new System.Drawing.Point(207, 12);
            this.txtNumGroups.Name = "txtNumGroups";
            this.txtNumGroups.Size = new System.Drawing.Size(59, 20);
            this.txtNumGroups.TabIndex = 2;
            this.txtNumGroups.Text = "4";
            this.txtNumGroups.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(169, 53);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.TabIndex = 3;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // lstResult
            // 
            this.lstResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstResult.FormattingEnabled = true;
            this.lstResult.Items.AddRange(new object[] {
            "Allie Postell",
            "Carmella Armwood",
            "Christian Urbanski",
            "Darryl Bjerke",
            "Darryl Ellenwood",
            "Eve Brightwell",
            "Eve Claborn",
            "Guy Lucena",
            "Harriett Southward",
            "Julio Fasano",
            "Kurt Fabiano",
            "Lance Ensey",
            "Loraine Bibbins",
            "Louisa Vandemark",
            "Max Carra",
            "Nannie Patchett",
            "Noemi Nilles",
            "Pearlie Bartleson",
            "Tabatha Lagrone",
            "Wyer Johnson"});
            this.lstResult.Location = new System.Drawing.Point(282, 12);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(121, 277);
            this.lstResult.Sorted = true;
            this.lstResult.TabIndex = 4;
            // 
            // howto_assign_people_to_groups_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 305);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.txtNumGroups);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstPeople);
            this.Name = "howto_assign_people_to_groups_Form1";
            this.Text = "howto_assign_people_to_groups";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPeople;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumGroups;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.ListBox lstResult;
    }
}

