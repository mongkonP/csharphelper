using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_make_ordinal_date;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_make_ordinal_date_Form1:Form
  { 


        public howto_make_ordinal_date_Form1()
        {
            InitializeComponent();
        }

        // Display an initial date.
        private void howto_make_ordinal_date_Form1_Load(object sender, EventArgs e)
        {
            txtDate.Text = "8/20/2020";
        }

        // Display the date in an ordinal format.
        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            // Parse the date and display it in ordinal format.
            try
            {
                DateTime value = DateTime.Parse(txtDate.Text);
                txtResult.Text = value.ToOrdinal();
            }
            catch
            {
                txtResult.Clear();
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtResult.Location = new System.Drawing.Point(106, 38);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(123, 20);
            this.txtResult.TabIndex = 5;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDate
            // 
            this.txtDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDate.Location = new System.Drawing.Point(150, 12);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(73, 20);
            this.txtDate.TabIndex = 4;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date:";
            // 
            // howto_make_ordinal_date_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 71);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label1);
            this.Name = "howto_make_ordinal_date_Form1";
            this.Text = "howto_make_ordinal_date";
            this.Load += new System.EventHandler(this.howto_make_ordinal_date_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label1;
    }
}

