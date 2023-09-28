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
     public partial class howto_find_idisposable_classes_Form1:Form
  { 


        public howto_find_idisposable_classes_Form1()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            lblNumClasses.Text = "";
            lstClasses.Items.Clear();
            Cursor = Cursors.WaitCursor;
            Refresh();

            // List the loaded assemblies.
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine(assembly.GetName().Name);
            int num_assemblies = AppDomain.CurrentDomain.GetAssemblies().Length;
            Console.WriteLine(num_assemblies.ToString() + " assemblies");

            // Get the type entered.
            string type_name = txtType.Text.ToLower();
            var type_query =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where (type.Name.ToLower() == type_name)
                select type;
            Type target_type = type_query.FirstOrDefault();

            if (target_type != null)
            {
                // Get classes that are assignable to the target type.
                var classes =
                    from assembly in AppDomain.CurrentDomain.GetAssemblies()
                    from type in assembly.GetTypes()
                    where target_type.IsAssignableFrom(type)
                    select type;

                // Display the classes.
                foreach (Type type in classes)
                {
                    lstClasses.Items.Add(type.Name);
                }
            }

            // Display the number of classes.
            lblNumClasses.Text = lstClasses.Items.Count.ToString() + " classes";
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
            this.lblNumClasses = new System.Windows.Forms.Label();
            this.lstClasses = new System.Windows.Forms.ListBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNumClasses
            // 
            this.lblNumClasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumClasses.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumClasses.Location = new System.Drawing.Point(11, 228);
            this.lblNumClasses.Name = "lblNumClasses";
            this.lblNumClasses.Size = new System.Drawing.Size(335, 23);
            this.lblNumClasses.TabIndex = 9;
            this.lblNumClasses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstClasses
            // 
            this.lstClasses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstClasses.FormattingEnabled = true;
            this.lstClasses.IntegralHeight = false;
            this.lstClasses.Location = new System.Drawing.Point(14, 40);
            this.lstClasses.Name = "lstClasses";
            this.lstClasses.Size = new System.Drawing.Size(332, 183);
            this.lstClasses.Sorted = true;
            this.lstClasses.TabIndex = 8;
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtType.Location = new System.Drawing.Point(54, 13);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(211, 20);
            this.txtType.TabIndex = 5;
            this.txtType.Text = "IDisposable";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Type:";
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(271, 11);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // howto_find_idisposable_classes_Form1
            // 
            this.AcceptButton = this.btnFind;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 261);
            this.Controls.Add(this.lblNumClasses);
            this.Controls.Add(this.lstClasses);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFind);
            this.Name = "howto_find_idisposable_classes_Form1";
            this.Text = "howto_find_idisposable_classes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumClasses;
        private System.Windows.Forms.ListBox lstClasses;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFind;
    }
}

