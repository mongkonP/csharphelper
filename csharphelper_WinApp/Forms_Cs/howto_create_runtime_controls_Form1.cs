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
     public partial class howto_create_runtime_controls_Form1:Form
  { 


        public howto_create_runtime_controls_Form1()
        {
            InitializeComponent();
        }

        private int X1 = 12;
        private int Y1 = 41;

        // Create a new button on the form.
        private void btnCreateButton_Click(object sender, EventArgs e)
        {
            // Make a new button similar to the old one.
            Button btn = new Button();
            btn.Text = btnCreateButton.Text;
            btn.Size = btnCreateButton.Size;
            btn.Left = X1;
            btn.Top = Y1;
            Y1 += btn.Height + 6;

            // Add this event handler to the button.
            btn.Click += btnCreateButton_Click;

            // Place the button on the form.
            btn.Parent = this;
        }

        private int X2 = 21;
        private int Y2 = 48;

        // Create a new button inside the GroupBox.
        private void btnCreateGroupButton_Click(object sender, EventArgs e)
        {
            // Make a new button similar to the old one.
            Button btn = new Button();
            btn.Text = btnCreateGroupButton.Text;
            btn.Size = btnCreateGroupButton.Size;
            btn.Left = X2;
            btn.Top = Y2;
            Y2 += btn.Height + 6;

            // Add this event handler to the button.
            btn.Click += btnCreateGroupButton_Click;

            // Place the button inside the GroupBox.
            btn.Parent = grpMoreButtons;
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
            this.btnCreateButton = new System.Windows.Forms.Button();
            this.grpMoreButtons = new System.Windows.Forms.GroupBox();
            this.btnCreateGroupButton = new System.Windows.Forms.Button();
            this.grpMoreButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateButton
            // 
            this.btnCreateButton.Location = new System.Drawing.Point(28, 12);
            this.btnCreateButton.Name = "btnCreateButton";
            this.btnCreateButton.Size = new System.Drawing.Size(90, 23);
            this.btnCreateButton.TabIndex = 0;
            this.btnCreateButton.Text = "Create Button";
            this.btnCreateButton.UseVisualStyleBackColor = true;
            this.btnCreateButton.Click += new System.EventHandler(this.btnCreateButton_Click);
            // 
            // grpMoreButtons
            // 
            this.grpMoreButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grpMoreButtons.Controls.Add(this.btnCreateGroupButton);
            this.grpMoreButtons.Location = new System.Drawing.Point(158, 12);
            this.grpMoreButtons.Name = "grpMoreButtons";
            this.grpMoreButtons.Size = new System.Drawing.Size(158, 240);
            this.grpMoreButtons.TabIndex = 1;
            this.grpMoreButtons.TabStop = false;
            this.grpMoreButtons.Text = "More Buttons";
            // 
            // btnCreateGroupButton
            // 
            this.btnCreateGroupButton.Location = new System.Drawing.Point(21, 19);
            this.btnCreateGroupButton.Name = "btnCreateGroupButton";
            this.btnCreateGroupButton.Size = new System.Drawing.Size(116, 23);
            this.btnCreateGroupButton.TabIndex = 1;
            this.btnCreateGroupButton.Text = "Create Group Button";
            this.btnCreateGroupButton.UseVisualStyleBackColor = true;
            this.btnCreateGroupButton.Click += new System.EventHandler(this.btnCreateGroupButton_Click);
            // 
            // howto_create_runtime_controls_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 264);
            this.Controls.Add(this.grpMoreButtons);
            this.Controls.Add(this.btnCreateButton);
            this.Name = "howto_create_runtime_controls_Form1";
            this.Text = "howto_create_runtime_controls";
            this.grpMoreButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateButton;
        private System.Windows.Forms.GroupBox grpMoreButtons;
        private System.Windows.Forms.Button btnCreateGroupButton;
    }
}

