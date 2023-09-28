using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_newtons_method_fractal;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_newtons_method_fractal_RootsForm:Form
  { 


        public howto_newtons_method_fractal_RootsForm()
        {
            InitializeComponent();
        }

        // Get and set the Power value.
        public int Roots
        {
            get
            {
                return int.Parse(txtNumRoots.Text);
            }
            set
            {
                txtNumRoots.Text = value.ToString();
            }
        }

        // Close the form if the value is a double.
        private void btnOk_Click(object sender, EventArgs e)
        {
            int roots;
            if (int.TryParse(txtNumRoots.Text, out roots))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please enter an integer");
                txtNumRoots.SelectAll();
                txtNumRoots.Focus();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumRoots = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Roots:";
            // 
            // txtNumRoots
            // 
            this.txtNumRoots.Location = new System.Drawing.Point(66, 12);
            this.txtNumRoots.Name = "txtNumRoots";
            this.txtNumRoots.Size = new System.Drawing.Size(62, 20);
            this.txtNumRoots.TabIndex = 0;
            this.txtNumRoots.Text = "2";
            this.txtNumRoots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(153, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(153, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // howto_newtons_method_fractal_RootsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(240, 79);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNumRoots);
            this.Controls.Add(this.label1);
            this.Name = "howto_newtons_method_fractal_RootsForm";
            this.Text = "howto_newtons_method_fractal_RootsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumRoots;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}