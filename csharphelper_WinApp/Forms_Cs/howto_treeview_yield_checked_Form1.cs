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
     public partial class howto_treeview_yield_checked_Form1:Form
  { 


        public howto_treeview_yield_checked_Form1()
        {
            InitializeComponent();
        }

        private void howto_treeview_yield_checked_Form1_Load(object sender, EventArgs e)
        {
            trvMeals.ExpandAll();
        }

        // List the checked TreeNodes.
        private void btnShowChecked_Click(object sender, EventArgs e)
        {
            string results = "";
            foreach (TreeNode node in CheckedNodes(trvMeals))
                results += node.Text + "\n";
            MessageBox.Show(results);
        }

        // Return a list of the checked TreeView nodes.
        private IEnumerable<TreeNode> CheckedNodes(TreeView trv)
        {
            return CheckedNodes(trv.Nodes);
        }

        // Return a list of the TreeNodes that are checked.
        private IEnumerable<TreeNode> CheckedNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Yield this node.
                if (node.Checked) yield return node;

                // Yield the checked descendants of this node.
                foreach (TreeNode checked_child in CheckedNodes(node.Nodes))
                    yield return checked_child;
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
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Eggs");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Toast");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Bacon");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Juice");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Breakfast", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Tuna Sandwich");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Milk");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Chips");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Hot Dog");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Lunch", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29});
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Lasagna");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Bread");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Wine");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Ice Cream");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Cake");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Brownie");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Dessert", new System.Windows.Forms.TreeNode[] {
            treeNode34,
            treeNode35,
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Salad");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Rice");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Dinner", new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode37,
            treeNode38,
            treeNode39});
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
            this.btnShowChecked.TabIndex = 6;
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
            treeNode21.Name = "";
            treeNode21.Text = "Eggs";
            treeNode22.Name = "";
            treeNode22.Text = "Toast";
            treeNode23.Name = "";
            treeNode23.Text = "Bacon";
            treeNode24.Name = "";
            treeNode24.Text = "Juice";
            treeNode25.Name = "";
            treeNode25.Text = "Breakfast";
            treeNode26.Name = "";
            treeNode26.Text = "Tuna Sandwich";
            treeNode27.Name = "";
            treeNode27.Text = "Milk";
            treeNode28.Name = "";
            treeNode28.Text = "Chips";
            treeNode29.Name = "";
            treeNode29.Text = "Hot Dog";
            treeNode30.Name = "";
            treeNode30.Text = "Lunch";
            treeNode31.Name = "";
            treeNode31.Text = "Lasagna";
            treeNode32.Name = "";
            treeNode32.Text = "Bread";
            treeNode33.Name = "";
            treeNode33.Text = "Wine";
            treeNode34.Name = "";
            treeNode34.Text = "Ice Cream";
            treeNode35.Name = "";
            treeNode35.Text = "Cake";
            treeNode36.Name = "";
            treeNode36.Text = "Brownie";
            treeNode37.Name = "";
            treeNode37.Text = "Dessert";
            treeNode38.Name = "";
            treeNode38.Text = "Salad";
            treeNode39.Name = "";
            treeNode39.Text = "Rice";
            treeNode40.Name = "";
            treeNode40.Text = "Dinner";
            this.trvMeals.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode30,
            treeNode40});
            this.trvMeals.Size = new System.Drawing.Size(310, 208);
            this.trvMeals.TabIndex = 5;
            // 
            // howto_treeview_yield_checked_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.btnShowChecked);
            this.Controls.Add(this.trvMeals);
            this.Name = "howto_treeview_yield_checked_Form1";
            this.Text = "howto_treeview_yield_checked";
            this.Load += new System.EventHandler(this.howto_treeview_yield_checked_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowChecked;
        internal System.Windows.Forms.TreeView trvMeals;
    }
}

