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
     public partial class howto_two_forms_Form1:Form
  { 


        public howto_two_forms_Form1()
        {
            InitializeComponent();
        }

        // A variable that refers to the instance of Form2.
        private howto_two_forms_Form2 TheForm2;

        // Initialize the form variables.
        private void howto_two_forms_Form1_Load(object sender, EventArgs e)
        {
            // Make the Form2.
            TheForm2 = new  howto_two_forms_Form2();

            // Initialize the Form2's variable.
            TheForm2.TheForm1 = this;

            // Make both forms stay on top.
            this.TopMost = true;
            TheForm2.TopMost = true;
        }

        // Switch to the Form2.
        private void btnForm2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheForm2.Show();
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
            this.btnForm2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForm2
            // 
            this.btnForm2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnForm2.Location = new System.Drawing.Point(92, 40);
            this.btnForm2.Name = "btnForm2";
            this.btnForm2.Size = new System.Drawing.Size(100, 30);
            this.btnForm2.TabIndex = 0;
            this.btnForm2.Text = "Show Form 2";
            this.btnForm2.UseVisualStyleBackColor = true;
            this.btnForm2.Click += new System.EventHandler(this.btnForm2_Click);
            // 
            // howto_two_forms_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.btnForm2);
            this.Name = "howto_two_forms_Form1";
            this.Text = "howto_two_forms";
            this.Load += new System.EventHandler(this.howto_two_forms_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnForm2;
    }
}

