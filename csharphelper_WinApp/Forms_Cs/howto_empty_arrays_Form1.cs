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
     public partial class howto_empty_arrays_Form1:Form
  { 


        public howto_empty_arrays_Form1()
        {
            InitializeComponent();
        }

        // Declare an array and try to use its properties.
        private void btnDeclare_Click(object sender, EventArgs e)
        {
            int[] values = null;
            try
            {
                // This fails.
                for (int i = 0; i < values.Length; i++)
                {
                    MessageBox.Show("Value[" + i + "]: " + values[i]);
                }
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Declare an array and initialize it to an empty array.
        private void btnDeclareAndInitialize_Click(object sender, EventArgs e)
        {
            int[] values = new int[0];
            try
            {
                for (int i = 0; i < values.Length; i++)
                {
                    MessageBox.Show("Value[" + i + "]: " + values[i]);
                }
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            this.btnDeclare = new System.Windows.Forms.Button();
            this.btnDeclareAndInitialize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeclare
            // 
            this.btnDeclare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeclare.Location = new System.Drawing.Point(75, 14);
            this.btnDeclare.Name = "btnDeclare";
            this.btnDeclare.Size = new System.Drawing.Size(135, 23);
            this.btnDeclare.TabIndex = 0;
            this.btnDeclare.Text = "Declare";
            this.btnDeclare.UseVisualStyleBackColor = true;
            this.btnDeclare.Click += new System.EventHandler(this.btnDeclare_Click);
            // 
            // btnDeclareAndInitialize
            // 
            this.btnDeclareAndInitialize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeclareAndInitialize.Location = new System.Drawing.Point(75, 43);
            this.btnDeclareAndInitialize.Name = "btnDeclareAndInitialize";
            this.btnDeclareAndInitialize.Size = new System.Drawing.Size(135, 23);
            this.btnDeclareAndInitialize.TabIndex = 1;
            this.btnDeclareAndInitialize.Text = "Declare and Initialize";
            this.btnDeclareAndInitialize.UseVisualStyleBackColor = true;
            this.btnDeclareAndInitialize.Click += new System.EventHandler(this.btnDeclareAndInitialize_Click);
            // 
            // howto_empty_arrays_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 81);
            this.Controls.Add(this.btnDeclareAndInitialize);
            this.Controls.Add(this.btnDeclare);
            this.Name = "howto_empty_arrays_Form1";
            this.Text = "howto_empty_arrays";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeclare;
        private System.Windows.Forms.Button btnDeclareAndInitialize;
    }
}

