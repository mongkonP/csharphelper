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
     public partial class howto_radio_toolstrip_buttons_Form1:Form
  { 


        public howto_radio_toolstrip_buttons_Form1()
        {
            InitializeComponent();
        }

        // Arrays of exclusive tools.
        private ToolStripButton[] ShapeTools, ColorTools;

        // Initialize the exclusive tool arrays.
        private void howto_radio_toolstrip_buttons_Form1_Load(object sender, EventArgs e)
        {
            // Prepare the shape tools.
            ShapeTools = new ToolStripButton[]
            {
                toolArrow,
                toolPolygon,
                toolCircle,
                toolDiamond
            };
            foreach (ToolStripButton btn in ShapeTools)
            {
                btn.Click += toolShape_Click;
            }

            // Prepare the color tools.
            ColorTools = new ToolStripButton[]
            {
                toolRed,
                toolBlue,
                toolYellow,
                toolLime
            };
            foreach (ToolStripButton btn in ColorTools)
            {
                btn.Click += toolColor_Click;
            }
        }

        // Allow only one shape selection at a time.
        private void toolShape_Click(object sender, EventArgs e)
        {
            SelectToolStripButton(sender as ToolStripButton, ShapeTools);
        }

        // Allow only one color selection at a time.
        private void toolColor_Click(object sender, EventArgs e)
        {
            SelectToolStripButton(sender as ToolStripButton, ColorTools);
        }

        // Select the indicated button and deselect the others.
        private void SelectToolStripButton(ToolStripButton selected_button, ToolStripButton[] buttons)
        {
            foreach (ToolStripButton test_button in buttons)
            {
                test_button.Checked = (test_button == selected_button);
            }
        }

        // Tool event handlers.
        private void tool_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            Console.WriteLine(btn.Text);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_radio_toolstrip_buttons_Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolArrow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPolygon = new System.Windows.Forms.ToolStripButton();
            this.toolCircle = new System.Windows.Forms.ToolStripButton();
            this.toolDiamond = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolRed = new System.Windows.Forms.ToolStripButton();
            this.toolBlue = new System.Windows.Forms.ToolStripButton();
            this.toolYellow = new System.Windows.Forms.ToolStripButton();
            this.toolLime = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolArrow,
            this.toolStripSeparator1,
            this.toolPolygon,
            this.toolCircle,
            this.toolDiamond,
            this.toolStripSeparator2,
            this.toolRed,
            this.toolBlue,
            this.toolYellow,
            this.toolLime});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(347, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolArrow
            // 
            this.toolArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolArrow.Image = ((System.Drawing.Image)(resources.GetObject("toolArrow.Image")));
            this.toolArrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolArrow.Name = "toolArrow";
            this.toolArrow.Size = new System.Drawing.Size(23, 22);
            this.toolArrow.Text = "Select";
            this.toolArrow.ToolTipText = "Select";
            this.toolArrow.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolPolygon
            // 
            this.toolPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPolygon.Image = ((System.Drawing.Image)(resources.GetObject("toolPolygon.Image")));
            this.toolPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPolygon.Name = "toolPolygon";
            this.toolPolygon.Size = new System.Drawing.Size(23, 22);
            this.toolPolygon.Text = "Polygon";
            this.toolPolygon.ToolTipText = "Polygon";
            this.toolPolygon.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolCircle
            // 
            this.toolCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCircle.Image = ((System.Drawing.Image)(resources.GetObject("toolCircle.Image")));
            this.toolCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCircle.Name = "toolCircle";
            this.toolCircle.Size = new System.Drawing.Size(23, 22);
            this.toolCircle.Text = "Circle";
            this.toolCircle.ToolTipText = "Circle";
            this.toolCircle.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolDiamond
            // 
            this.toolDiamond.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDiamond.Image = ((System.Drawing.Image)(resources.GetObject("toolDiamond.Image")));
            this.toolDiamond.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDiamond.Name = "toolDiamond";
            this.toolDiamond.Size = new System.Drawing.Size(23, 22);
            this.toolDiamond.Text = "Diamond";
            this.toolDiamond.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolRed
            // 
            this.toolRed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRed.Image = ((System.Drawing.Image)(resources.GetObject("toolRed.Image")));
            this.toolRed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRed.Name = "toolRed";
            this.toolRed.Size = new System.Drawing.Size(23, 22);
            this.toolRed.Text = "Red";
            this.toolRed.ToolTipText = "Red";
            this.toolRed.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolBlue
            // 
            this.toolBlue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBlue.Image = ((System.Drawing.Image)(resources.GetObject("toolBlue.Image")));
            this.toolBlue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBlue.Name = "toolBlue";
            this.toolBlue.Size = new System.Drawing.Size(23, 22);
            this.toolBlue.Text = "Blue";
            this.toolBlue.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolYellow
            // 
            this.toolYellow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolYellow.Image = ((System.Drawing.Image)(resources.GetObject("toolYellow.Image")));
            this.toolYellow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolYellow.Name = "toolYellow";
            this.toolYellow.Size = new System.Drawing.Size(23, 22);
            this.toolYellow.Text = "Yellow";
            this.toolYellow.ToolTipText = "Yellow";
            this.toolYellow.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolLime
            // 
            this.toolLime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLime.Image = ((System.Drawing.Image)(resources.GetObject("toolLime.Image")));
            this.toolLime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLime.Name = "toolLime";
            this.toolLime.Size = new System.Drawing.Size(23, 22);
            this.toolLime.Text = "Lime";
            this.toolLime.Click += new System.EventHandler(this.tool_Click);
            // 
            // howto_radio_toolstrip_buttons_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 114);
            this.Controls.Add(this.toolStrip1);
            this.Name = "howto_radio_toolstrip_buttons_Form1";
            this.Text = "howto_radio_toolstrip_buttons";
            this.Load += new System.EventHandler(this.howto_radio_toolstrip_buttons_Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolArrow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolPolygon;
        private System.Windows.Forms.ToolStripButton toolCircle;
        private System.Windows.Forms.ToolStripButton toolDiamond;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolRed;
        private System.Windows.Forms.ToolStripButton toolBlue;
        private System.Windows.Forms.ToolStripButton toolYellow;
        private System.Windows.Forms.ToolStripButton toolLime;
    }
}

