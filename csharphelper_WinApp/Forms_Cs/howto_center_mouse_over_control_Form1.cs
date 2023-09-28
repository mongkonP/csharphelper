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
     public partial class howto_center_mouse_over_control_Form1:Form
  { 


        public howto_center_mouse_over_control_Form1()
        {
            InitializeComponent();
        }

        // Move the mouse over the other control.
        private void btnOverThere1_Click(object sender, EventArgs e)
        {
            CenterMouseOverControl(btnOverThere2);
        }
        private void btnOverThere2_Click(object sender, EventArgs e)
        {
            CenterMouseOverControl(btnOverThere1);
        }

        // Center the mouse over a control.
        private void CenterMouseOverControl(Control ctl)
        {
            // See where to put the mouse.
            Point target = new Point(
                (ctl.Left + ctl.Right) / 2,
                (ctl.Top + ctl.Bottom) / 2);

            // Convert to screen coordinates.
            Point screen_coords = ctl.Parent.PointToScreen(target);

            Cursor.Position = screen_coords;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOverThere1 = new System.Windows.Forms.Button();
            this.btnOverThere2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOverThere1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 72);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Left Group";
            // 
            // btnOverThere1
            // 
            this.btnOverThere1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOverThere1.Location = new System.Drawing.Point(32, 31);
            this.btnOverThere1.Name = "btnOverThere1";
            this.btnOverThere1.Size = new System.Drawing.Size(75, 23);
            this.btnOverThere1.TabIndex = 0;
            this.btnOverThere1.Text = "Over There";
            this.btnOverThere1.UseVisualStyleBackColor = true;
            this.btnOverThere1.Click += new System.EventHandler(this.btnOverThere1_Click);
            // 
            // btnOverThere2
            // 
            this.btnOverThere2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOverThere2.Location = new System.Drawing.Point(31, 31);
            this.btnOverThere2.Name = "btnOverThere2";
            this.btnOverThere2.Size = new System.Drawing.Size(75, 23);
            this.btnOverThere2.TabIndex = 0;
            this.btnOverThere2.Text = "Over There";
            this.btnOverThere2.UseVisualStyleBackColor = true;
            this.btnOverThere2.Click += new System.EventHandler(this.btnOverThere2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOverThere2);
            this.groupBox2.Location = new System.Drawing.Point(157, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 72);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Right Group";
            // 
            // howto_center_mouse_over_control_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 96);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "howto_center_mouse_over_control_Form1";
            this.Text = "howto_center_mouse_over_control";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOverThere1;
        private System.Windows.Forms.Button btnOverThere2;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

