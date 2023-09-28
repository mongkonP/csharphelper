using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_big_toolstrip_buttons_Form1:Form
  { 


        public howto_big_toolstrip_buttons_Form1()
        {
            InitializeComponent();
        }

        private ToolStripDropDownButton DiamondButton, SmileyButton;

        private void howto_big_toolstrip_buttons_Form1_Load(object sender, EventArgs e)
        {
            // Make all of the items. (Just to get it over with.)
            Image[] diamond_images =
            {
                Properties.Resources.diamond1,
                Properties.Resources.diamond2,
                Properties.Resources.diamond3,
            };
            string[] diamond_tips =
            {
                "Diamond 0",
                "Diamond 1",
                "Diamond 2",
            };
            int num_diamonds = diamond_images.Length;
            ToolStripButton[] diamond_btns = new ToolStripButton[num_diamonds];
            for (int i = 0; i < num_diamonds; i++)
            {
                ToolStripButton btn = new ToolStripButton(diamond_images[i]);
                btn.ImageScaling = ToolStripItemImageScaling.None;
                btn.ToolTipText = diamond_tips[i];
                btn.Tag = i;
                btn.Click += dropdownButton_Click;
                diamond_btns[i] = btn;
            }

            Image[] smiley_images =
            {
                Properties.Resources.Smiley1,
                Properties.Resources.smiley2,
                Properties.Resources.smiley3,
            };
            string[] smiley_tips =
            {
                "Smiley 0",
                "Smiley 1",
                "Smiley 2",
            };
            int num_smileys = smiley_images.Length;
            ToolStripButton[] smiley_btns = new ToolStripButton[num_smileys];
            for (int i = 0; i < num_smileys; i++)
            {
                ToolStripButton btn = new ToolStripButton(smiley_images[i]);
                btn.ImageScaling = ToolStripItemImageScaling.None;
                btn.ToolTipText = smiley_tips[i];
                btn.Tag = i;
                btn.Click += dropdownButton_Click;
                smiley_btns[i] = btn;
            }

            // Prepare the ToolStrip.
            toolStrip1.BackColor = Color.LightBlue;

            // Do the following to make all buttons have
            // the same desired image size.
            //toolStrip1.ImageScalingSize = new Size(50, 50);

            // Make the diamond dropdown button.
            DiamondButton = new ToolStripDropDownButton();
            toolStrip1.Items.Add(DiamondButton);
            DiamondButton.DropDownItems.AddRange(diamond_btns);
            DiamondButton.ImageScaling = ToolStripItemImageScaling.None;
            SelectItem(DiamondButton, diamond_btns[0]);

            // Make the smiley dropdown button.
            SmileyButton = new ToolStripDropDownButton();
            toolStrip1.Items.Add(SmileyButton);
            SmileyButton.DropDownItems.AddRange(smiley_btns);
            SmileyButton.ImageScaling = ToolStripItemImageScaling.None;
            SelectItem(SmileyButton, smiley_btns[0]);

            // Move the top of the Panel control below the ToolStrip.
            panel1.Top = toolStrip1.Bottom;
        }

        private void SelectItem(
            ToolStripDropDownButton parent,
            ToolStripButton item)
        {
            parent.Image = item.Image;
            parent.ToolTipText = item.ToolTipText;
            parent.Tag = item.Tag;
        }

        private void dropdownButton_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            ToolStripDropDownButton parent = btn.OwnerItem as ToolStripDropDownButton;
            SelectItem(parent, btn);
        }

        private void btnCheckValues_Click(object sender, EventArgs e)
        {
            txtDiamond.Text = DiamondButton.ToolTipText;
            txtSmiley.Text = SmileyButton.ToolTipText;
        }

        private void btnFlower_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Flower");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_big_toolstrip_buttons_Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiamond = new System.Windows.Forms.TextBox();
            this.btnCheckValues = new System.Windows.Forms.Button();
            this.txtSmiley = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFlower = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFlower});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 57);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Diamond:";
            // 
            // txtDiamond
            // 
            this.txtDiamond.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDiamond.Location = new System.Drawing.Point(121, 66);
            this.txtDiamond.Name = "txtDiamond";
            this.txtDiamond.Size = new System.Drawing.Size(100, 20);
            this.txtDiamond.TabIndex = 1;
            // 
            // btnCheckValues
            // 
            this.btnCheckValues.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCheckValues.Location = new System.Drawing.Point(97, 3);
            this.btnCheckValues.Name = "btnCheckValues";
            this.btnCheckValues.Size = new System.Drawing.Size(91, 31);
            this.btnCheckValues.TabIndex = 0;
            this.btnCheckValues.Text = "Check Values";
            this.btnCheckValues.UseVisualStyleBackColor = true;
            this.btnCheckValues.Click += new System.EventHandler(this.btnCheckValues_Click);
            // 
            // txtSmiley
            // 
            this.txtSmiley.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSmiley.Location = new System.Drawing.Point(121, 92);
            this.txtSmiley.Name = "txtSmiley";
            this.txtSmiley.Size = new System.Drawing.Size(100, 20);
            this.txtSmiley.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Smiley:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnCheckValues);
            this.panel1.Controls.Add(this.txtSmiley);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDiamond);
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 151);
            this.panel1.TabIndex = 5;
            // 
            // btnFlower
            // 
            this.btnFlower.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFlower.Image = ((System.Drawing.Image)(resources.GetObject("btnFlower.Image")));
            this.btnFlower.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFlower.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFlower.Name = "btnFlower";
            this.btnFlower.Size = new System.Drawing.Size(54, 54);
            this.btnFlower.Text = "toolStripButton1";
            this.btnFlower.Click += new System.EventHandler(this.btnFlower_Click);
            // 
            // howto_big_toolstrip_buttons_Form1
            // 
            this.AcceptButton = this.btnCheckValues;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "howto_big_toolstrip_buttons_Form1";
            this.Text = "howto_big_toolstrip_buttons";
            this.Load += new System.EventHandler(this.howto_big_toolstrip_buttons_Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiamond;
        private System.Windows.Forms.Button btnCheckValues;
        private System.Windows.Forms.TextBox txtSmiley;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton btnFlower;
    }
}

