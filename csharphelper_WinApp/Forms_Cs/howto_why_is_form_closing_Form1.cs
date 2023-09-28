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
     public partial class howto_why_is_form_closing_Form1:Form
  { 


        public howto_why_is_form_closing_Form1()
        {
            InitializeComponent();
        }

        // Tell the user why the form is closing.
        private void howto_why_is_form_closing_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show(e.CloseReason.ToString());
        }

        // Close the form.
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Invoke the application's Exit method.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Display the form as a dialog.
        private howto_why_is_form_closing_Form1 MyParent;
        private void btnDialog_Click(object sender, EventArgs e)
        {
            howto_why_is_form_closing_Form1 dlg = new howto_why_is_form_closing_Form1();
            dlg.btnClose.Visible = false;
            dlg.btnExit.Visible = false;
            dlg.btnDialog.Visible = false;
            dlg.btnCloseParent.Visible = true;

            dlg.MyParent = this;
            dlg.ShowDialog(this);
        }

        // Close the parent form.
        private void btnCloseParent_Click(object sender, EventArgs e)
        {
            MyParent.Close();
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDialog = new System.Windows.Forms.Button();
            this.btnCloseParent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Location = new System.Drawing.Point(38, 46);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Location = new System.Drawing.Point(129, 46);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDialog
            // 
            this.btnDialog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDialog.Location = new System.Drawing.Point(220, 46);
            this.btnDialog.Name = "btnDialog";
            this.btnDialog.Size = new System.Drawing.Size(75, 23);
            this.btnDialog.TabIndex = 2;
            this.btnDialog.Text = "Dialog";
            this.btnDialog.UseVisualStyleBackColor = true;
            this.btnDialog.Click += new System.EventHandler(this.btnDialog_Click);
            // 
            // btnCloseParent
            // 
            this.btnCloseParent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCloseParent.Location = new System.Drawing.Point(129, 46);
            this.btnCloseParent.Name = "btnCloseParent";
            this.btnCloseParent.Size = new System.Drawing.Size(75, 23);
            this.btnCloseParent.TabIndex = 3;
            this.btnCloseParent.Text = "Close Parent";
            this.btnCloseParent.UseVisualStyleBackColor = true;
            this.btnCloseParent.Visible = false;
            this.btnCloseParent.Click += new System.EventHandler(this.btnCloseParent_Click);
            // 
            // howto_why_is_form_closing_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 114);
            this.Controls.Add(this.btnCloseParent);
            this.Controls.Add(this.btnDialog);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClose);
            this.Name = "howto_why_is_form_closing_Form1";
            this.Text = "howto_why_is_form_closing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_why_is_form_closing_Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDialog;
        private System.Windows.Forms.Button btnCloseParent;
    }
}

