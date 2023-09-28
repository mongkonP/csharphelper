using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_force_garbage_collection;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_force_garbage_collection_Form1:Form
  { 


        public howto_force_garbage_collection_Form1()
        {
            InitializeComponent();
        }

        // Create a Person.
        private void btnCreatePerson_Click(object sender, EventArgs e)
        {
            Person person = new Person();
        }

        // Force garbage collection.
        private void btnCollect_Click(object sender, EventArgs e)
        {
            GC.Collect();
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
            this.btnCreatePerson = new System.Windows.Forms.Button();
            this.btnCollect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreatePerson
            // 
            this.btnCreatePerson.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreatePerson.Location = new System.Drawing.Point(47, 44);
            this.btnCreatePerson.Name = "btnCreatePerson";
            this.btnCreatePerson.Size = new System.Drawing.Size(104, 23);
            this.btnCreatePerson.TabIndex = 0;
            this.btnCreatePerson.Text = "Create Person";
            this.btnCreatePerson.UseVisualStyleBackColor = true;
            this.btnCreatePerson.Click += new System.EventHandler(this.btnCreatePerson_Click);
            // 
            // btnCollect
            // 
            this.btnCollect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCollect.Location = new System.Drawing.Point(234, 44);
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Size = new System.Drawing.Size(104, 23);
            this.btnCollect.TabIndex = 2;
            this.btnCollect.Text = "Collect";
            this.btnCollect.UseVisualStyleBackColor = true;
            this.btnCollect.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // howto_force_garbage_collection_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.btnCollect);
            this.Controls.Add(this.btnCreatePerson);
            this.Name = "howto_force_garbage_collection_Form1";
            this.Text = "howto_force_garbage_collection";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreatePerson;
        private System.Windows.Forms.Button btnCollect;
    }
}

