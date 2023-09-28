using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_loaded_assemblies_Form1:Form
  { 


        public howto_list_loaded_assemblies_Form1()
        {
            InitializeComponent();
        }

        private void howto_list_loaded_assemblies_Form1_Load(object sender, EventArgs e)
        {
            ListAssemblies();
        }
        private void btnListAssemblies_Click(object sender, EventArgs e)
        {
            ListAssemblies();
        }

        // List the assemblies.
        private void ListAssemblies()
        {
            lblNumAssemblies.Text = "";
            lstAssemblies.Items.Clear();
            Cursor = Cursors.WaitCursor;
            Refresh();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                lstAssemblies.Items.Add(assembly.GetName().Name);

            // Display the number of assemblies.
            lblNumAssemblies.Text = lstAssemblies.Items.Count.ToString() + " assemblies";
            Cursor = Cursors.Default;
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
            this.lblNumAssemblies = new System.Windows.Forms.Label();
            this.lstAssemblies = new System.Windows.Forms.ListBox();
            this.btnListAssemblies = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNumAssemblies
            // 
            this.lblNumAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumAssemblies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumAssemblies.Location = new System.Drawing.Point(12, 179);
            this.lblNumAssemblies.Name = "lblNumAssemblies";
            this.lblNumAssemblies.Size = new System.Drawing.Size(310, 23);
            this.lblNumAssemblies.TabIndex = 8;
            this.lblNumAssemblies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstAssemblies
            // 
            this.lstAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAssemblies.FormattingEnabled = true;
            this.lstAssemblies.IntegralHeight = false;
            this.lstAssemblies.Location = new System.Drawing.Point(12, 60);
            this.lstAssemblies.Name = "lstAssemblies";
            this.lstAssemblies.Size = new System.Drawing.Size(310, 116);
            this.lstAssemblies.TabIndex = 7;
            // 
            // btnListAssemblies
            // 
            this.btnListAssemblies.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnListAssemblies.Location = new System.Drawing.Point(130, 12);
            this.btnListAssemblies.Name = "btnListAssemblies";
            this.btnListAssemblies.Size = new System.Drawing.Size(75, 42);
            this.btnListAssemblies.TabIndex = 6;
            this.btnListAssemblies.Text = "List Assemblies";
            this.btnListAssemblies.UseVisualStyleBackColor = true;
            this.btnListAssemblies.Click += new System.EventHandler(this.btnListAssemblies_Click);
            // 
            // howto_list_loaded_assemblies_Form1
            // 
            this.AcceptButton = this.btnListAssemblies;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 211);
            this.Controls.Add(this.lblNumAssemblies);
            this.Controls.Add(this.lstAssemblies);
            this.Controls.Add(this.btnListAssemblies);
            this.Name = "howto_list_loaded_assemblies_Form1";
            this.Text = "howto_list_loaded_assemblies";
            this.Load += new System.EventHandler(this.howto_list_loaded_assemblies_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumAssemblies;
        private System.Windows.Forms.ListBox lstAssemblies;
        private System.Windows.Forms.Button btnListAssemblies;
    }
}

