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
     public partial class howto_reuse_event_handler_Form1:Form
  { 


        public howto_reuse_event_handler_Form1()
        {
            InitializeComponent();
        }

        // The user clicked one of the buttons.
        private void btnChoice_Click(object sender, EventArgs e)
        {
            // Get the sender as a Button.
            Button btn = sender as Button;

            // Do something with the Button.
            switch (btn.Text)
            {
                case "Yes":
                    MessageBox.Show("You clicked Yes");
                    break;
                case "No":
                    MessageBox.Show("You clicked No. You're so negative!");
                    break;
                case "Maybe":
                    MessageBox.Show("You clicked Maybe. A bit undecided?");
                    break;
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
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnMaybe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnYes.Location = new System.Drawing.Point(38, 12);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnChoice_Click);
            // 
            // btnNo
            // 
            this.btnNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNo.Location = new System.Drawing.Point(130, 12);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnChoice_Click);
            // 
            // btnMaybe
            // 
            this.btnMaybe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMaybe.Location = new System.Drawing.Point(222, 12);
            this.btnMaybe.Name = "btnMaybe";
            this.btnMaybe.Size = new System.Drawing.Size(75, 23);
            this.btnMaybe.TabIndex = 2;
            this.btnMaybe.Text = "Maybe";
            this.btnMaybe.UseVisualStyleBackColor = true;
            this.btnMaybe.Click += new System.EventHandler(this.btnChoice_Click);
            // 
            // howto_reuse_event_handler_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.btnMaybe);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Name = "howto_reuse_event_handler_Form1";
            this.Text = "howto_reuse_event_handler";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnMaybe;
    }
}

