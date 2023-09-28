using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_treenode_descendants;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_treenode_descendants_Form1:Form
  { 


        public howto_treenode_descendants_Form1()
        {
            InitializeComponent();
        }

        private void howto_treenode_descendants_Form1_Load(object sender, EventArgs e)
        {
            trvMeals.ExpandAll();
        }

        // List the checked TreeNodes.
        private void btnShowChecked_Click(object sender, EventArgs e)
        {
            string results = "";
            foreach (TreeNode node in trvMeals.Descendants())
            {
                if (node.Checked) results += node.Text + "\n";
            }
            MessageBox.Show(results);
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Eggs");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Toast");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Bacon");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Juice");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Breakfast", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Tuna Sandwich");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Milk");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Chips");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Hot Dog");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Lunch", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Lasagna");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Bread");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Wine");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Ice Cream");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Cake");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Brownie");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Dessert", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Salad");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Rice");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Dinner", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode17,
            treeNode18,
            treeNode19});
            this.btnShowChecked = new System.Windows.Forms.Button();
            this.trvMeals = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnShowChecked
            // 
            this.btnShowChecked.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShowChecked.Location = new System.Drawing.Point(118, 226);
            this.btnShowChecked.Name = "btnShowChecked";
            this.btnShowChecked.Size = new System.Drawing.Size(99, 23);
            this.btnShowChecked.TabIndex = 10;
            this.btnShowChecked.Text = "Show Checked";
            this.btnShowChecked.UseVisualStyleBackColor = true;
            this.btnShowChecked.Click += new System.EventHandler(this.btnShowChecked_Click);
            // 
            // trvMeals
            // 
            this.trvMeals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvMeals.CheckBoxes = true;
            this.trvMeals.FullRowSelect = true;
            this.trvMeals.Location = new System.Drawing.Point(12, 12);
            this.trvMeals.Name = "trvMeals";
            treeNode1.Name = "";
            treeNode1.Text = "Eggs";
            treeNode2.Name = "";
            treeNode2.Text = "Toast";
            treeNode3.Name = "";
            treeNode3.Text = "Bacon";
            treeNode4.Name = "";
            treeNode4.Text = "Juice";
            treeNode5.Name = "";
            treeNode5.Text = "Breakfast";
            treeNode6.Name = "";
            treeNode6.Text = "Tuna Sandwich";
            treeNode7.Name = "";
            treeNode7.Text = "Milk";
            treeNode8.Name = "";
            treeNode8.Text = "Chips";
            treeNode9.Name = "";
            treeNode9.Text = "Hot Dog";
            treeNode10.Name = "";
            treeNode10.Text = "Lunch";
            treeNode11.Name = "";
            treeNode11.Text = "Lasagna";
            treeNode12.Name = "";
            treeNode12.Text = "Bread";
            treeNode13.Name = "";
            treeNode13.Text = "Wine";
            treeNode14.Name = "";
            treeNode14.Text = "Ice Cream";
            treeNode15.Name = "";
            treeNode15.Text = "Cake";
            treeNode16.Name = "";
            treeNode16.Text = "Brownie";
            treeNode17.Name = "";
            treeNode17.Text = "Dessert";
            treeNode18.Name = "";
            treeNode18.Text = "Salad";
            treeNode19.Name = "";
            treeNode19.Text = "Rice";
            treeNode20.Name = "";
            treeNode20.Text = "Dinner";
            this.trvMeals.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode10,
            treeNode20});
            this.trvMeals.Size = new System.Drawing.Size(310, 208);
            this.trvMeals.TabIndex = 9;
            // 
            // howto_treenode_descendants_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.btnShowChecked);
            this.Controls.Add(this.trvMeals);
            this.Name = "howto_treenode_descendants_Form1";
            this.Text = "howto_treenode_descendants";
            this.Load += new System.EventHandler(this.howto_treenode_descendants_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowChecked;
        internal System.Windows.Forms.TreeView trvMeals;
    }
}

