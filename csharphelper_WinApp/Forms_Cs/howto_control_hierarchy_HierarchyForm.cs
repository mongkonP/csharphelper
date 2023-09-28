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
     public partial class howto_control_hierarchy_HierarchyForm:Form
  { 


        public howto_control_hierarchy_HierarchyForm()
        {
            InitializeComponent();
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
            this.trvHierarchy = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // trvHierarchy
            // 
            this.trvHierarchy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvHierarchy.Location = new System.Drawing.Point(0, 0);
            this.trvHierarchy.Name = "trvHierarchy";
            this.trvHierarchy.Size = new System.Drawing.Size(284, 261);
            this.trvHierarchy.TabIndex = 0;
            // 
            // howto_control_hierarchy_HierarchyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.trvHierarchy);
            this.Name = "howto_control_hierarchy_HierarchyForm";
            this.Text = "howto_control_hierarchy_HierarchyForm";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView trvHierarchy;

    }
}