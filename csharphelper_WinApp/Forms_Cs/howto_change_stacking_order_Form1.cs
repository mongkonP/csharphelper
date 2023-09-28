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
     public partial class howto_change_stacking_order_Form1:Form
  { 


        public howto_change_stacking_order_Form1()
        {
            InitializeComponent();
        }

        private void btnToTop_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BringToFront();
        }

        private void btnToBottom_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.SendToBack();
        }

        private void btnSecondToTop_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Parent.Controls.SetChildIndex(btn, 1);
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
            this.btnToTop2 = new System.Windows.Forms.Button();
            this.btnToBottom1 = new System.Windows.Forms.Button();
            this.btnToTop1 = new System.Windows.Forms.Button();
            this.btnToBottom2 = new System.Windows.Forms.Button();
            this.btnSecondToTop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnToTop2
            // 
            this.btnToTop2.Location = new System.Drawing.Point(26, 19);
            this.btnToTop2.Name = "btnToTop2";
            this.btnToTop2.Size = new System.Drawing.Size(100, 62);
            this.btnToTop2.TabIndex = 0;
            this.btnToTop2.Text = "To Top";
            this.btnToTop2.UseVisualStyleBackColor = true;
            this.btnToTop2.Click += new System.EventHandler(this.btnToTop_Click);
            // 
            // btnToBottom1
            // 
            this.btnToBottom1.Location = new System.Drawing.Point(55, 62);
            this.btnToBottom1.Name = "btnToBottom1";
            this.btnToBottom1.Size = new System.Drawing.Size(100, 75);
            this.btnToBottom1.TabIndex = 1;
            this.btnToBottom1.Text = "To Bottom";
            this.btnToBottom1.UseVisualStyleBackColor = true;
            this.btnToBottom1.Click += new System.EventHandler(this.btnToBottom_Click);
            // 
            // btnToTop1
            // 
            this.btnToTop1.Location = new System.Drawing.Point(102, 12);
            this.btnToTop1.Name = "btnToTop1";
            this.btnToTop1.Size = new System.Drawing.Size(100, 57);
            this.btnToTop1.TabIndex = 2;
            this.btnToTop1.Text = "To Top";
            this.btnToTop1.UseVisualStyleBackColor = true;
            this.btnToTop1.Click += new System.EventHandler(this.btnToTop_Click);
            // 
            // btnToBottom2
            // 
            this.btnToBottom2.Location = new System.Drawing.Point(144, 53);
            this.btnToBottom2.Name = "btnToBottom2";
            this.btnToBottom2.Size = new System.Drawing.Size(100, 100);
            this.btnToBottom2.TabIndex = 3;
            this.btnToBottom2.Text = "To Bottom";
            this.btnToBottom2.UseVisualStyleBackColor = true;
            this.btnToBottom2.Click += new System.EventHandler(this.btnToBottom_Click);
            // 
            // btnSecondToTop
            // 
            this.btnSecondToTop.Location = new System.Drawing.Point(3, 62);
            this.btnSecondToTop.Name = "btnSecondToTop";
            this.btnSecondToTop.Size = new System.Drawing.Size(340, 23);
            this.btnSecondToTop.TabIndex = 4;
            this.btnSecondToTop.Text = "Second To Top";
            this.btnSecondToTop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSecondToTop.UseVisualStyleBackColor = true;
            this.btnSecondToTop.Click += new System.EventHandler(this.btnSecondToTop_Click);
            // 
            // howto_change_stacking_order_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 180);
            this.Controls.Add(this.btnSecondToTop);
            this.Controls.Add(this.btnToBottom2);
            this.Controls.Add(this.btnToTop1);
            this.Controls.Add(this.btnToBottom1);
            this.Controls.Add(this.btnToTop2);
            this.Name = "howto_change_stacking_order_Form1";
            this.Text = "howto_change_stacking_order";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnToTop2;
        private System.Windows.Forms.Button btnToBottom1;
        private System.Windows.Forms.Button btnToTop1;
        private System.Windows.Forms.Button btnToBottom2;
        private System.Windows.Forms.Button btnSecondToTop;
    }
}

