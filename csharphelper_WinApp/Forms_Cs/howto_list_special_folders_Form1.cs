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
     public partial class howto_list_special_folders_Form1:Form
  { 


        public howto_list_special_folders_Form1()
        {
            InitializeComponent();
        }

        // List the folder types.
        private void howto_list_special_folders_Form1_Load(object sender, EventArgs e)
        {
            foreach (Environment.SpecialFolder folder_type
                in Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                DescribeFolder(folder_type);
            }
            txtFolders.Select(0, 0);
        }

        // Add a folder's information to the txtFolders TextBox.
        private void DescribeFolder(Environment.SpecialFolder folder_type)
        {
            txtFolders.AppendText(
                String.Format("{0,-25}", folder_type.ToString()) +
                Environment.GetFolderPath(folder_type) + "\r\n");
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
            this.txtFolders = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFolders
            // 
            this.txtFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFolders.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolders.Location = new System.Drawing.Point(0, 0);
            this.txtFolders.Multiline = true;
            this.txtFolders.Name = "txtFolders";
            this.txtFolders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFolders.Size = new System.Drawing.Size(725, 344);
            this.txtFolders.TabIndex = 2;
            // 
            // howto_list_special_folders_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 344);
            this.Controls.Add(this.txtFolders);
            this.Name = "howto_list_special_folders_Form1";
            this.Text = "howto_list_special_folders";
            this.Load += new System.EventHandler(this.howto_list_special_folders_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtFolders;
    }
}

