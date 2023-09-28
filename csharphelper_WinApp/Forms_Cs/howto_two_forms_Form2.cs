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
     public partial class howto_two_forms_Form2:Form
  { 


        public howto_two_forms_Form2()
        {
            InitializeComponent();
        }

        // A variable that refers to the instance of howto_two_forms_Form2.
        // Note that it's public.
        public howto_two_forms_Form1 TheForm1;

        // Switch to TheForm1.
        private void btnForm1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheForm1.Show();
        }

        private void howto_two_forms_Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Approach 1: Close the startup form.
            //TheForm1.Close();

            // Approach 2: Hide this form instead of closing it.
            this.Hide();
            TheForm1.Show();
            e.Cancel = true;
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
            this.btnForm1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForm1
            // 
            this.btnForm1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnForm1.Location = new System.Drawing.Point(92, 40);
            this.btnForm1.Name = "btnForm1";
            this.btnForm1.Size = new System.Drawing.Size(100, 30);
            this.btnForm1.TabIndex = 0;
            this.btnForm1.Text = "Show Form 1";
            this.btnForm1.UseVisualStyleBackColor = true;
            this.btnForm1.Click += new System.EventHandler(this.btnForm1_Click);
            // 
            // howto_two_forms_Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.btnForm1);
            this.Name = "howto_two_forms_Form2";
            this.Text = "howto_two_forms_Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_two_forms_Form2_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnForm1;
    }
}