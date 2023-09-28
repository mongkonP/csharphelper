using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_oledb_providers_Form1:Form
  { 


        public howto_list_oledb_providers_Form1()
        {
            InitializeComponent();
        }

        private void howto_list_oledb_providers_Form1_Load(object sender, EventArgs e)
        {
            OleDbEnumerator enumerator = new OleDbEnumerator();
            dgvProviders.DataSource = enumerator.GetElements();
            foreach (DataGridViewColumn col in dgvProviders.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
            this.dgvProviders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProviders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProviders
            // 
            this.dgvProviders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProviders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProviders.Location = new System.Drawing.Point(12, 12);
            this.dgvProviders.Name = "dgvProviders";
            this.dgvProviders.Size = new System.Drawing.Size(735, 237);
            this.dgvProviders.TabIndex = 2;
            // 
            // howto_list_oledb_providers_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 261);
            this.Controls.Add(this.dgvProviders);
            this.Name = "howto_list_oledb_providers_Form1";
            this.Text = "howto_list_oledb_providers";
            this.Load += new System.EventHandler(this.howto_list_oledb_providers_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProviders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProviders;
    }
}

