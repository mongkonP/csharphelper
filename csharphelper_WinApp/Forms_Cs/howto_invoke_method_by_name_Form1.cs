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
     public partial class howto_invoke_method_by_name_Form1:Form
  { 


        public howto_invoke_method_by_name_Form1()
        {
            InitializeComponent();
        }

        // Invoke the method.
        private void btnInvoke_Click(object sender, EventArgs e)
        {
            try
            {
                Type this_type = this.GetType();
                MethodInfo method_info = this_type.GetMethod(txtMethodName.Text);
                method_info.Invoke(this, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // The public methods to invoke.
        public void Method1()
        {
            MessageBox.Show("This is Method 1");
        }
        public void Method2()
        {
            MessageBox.Show("This is Method 2");
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
            this.txtMethodName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInvoke = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMethodName
            // 
            this.txtMethodName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMethodName.Location = new System.Drawing.Point(95, 12);
            this.txtMethodName.Name = "txtMethodName";
            this.txtMethodName.Size = new System.Drawing.Size(241, 20);
            this.txtMethodName.TabIndex = 8;
            this.txtMethodName.Text = "Method1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Method Name:";
            // 
            // btnInvoke
            // 
            this.btnInvoke.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnInvoke.Location = new System.Drawing.Point(137, 51);
            this.btnInvoke.Name = "btnInvoke";
            this.btnInvoke.Size = new System.Drawing.Size(75, 23);
            this.btnInvoke.TabIndex = 6;
            this.btnInvoke.Text = "Invoke";
            this.btnInvoke.UseVisualStyleBackColor = true;
            this.btnInvoke.Click += new System.EventHandler(this.btnInvoke_Click);
            // 
            // howto_invoke_method_by_name_Form1
            // 
            this.AcceptButton = this.btnInvoke;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 90);
            this.Controls.Add(this.txtMethodName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInvoke);
            this.Name = "howto_invoke_method_by_name_Form1";
            this.Text = "howto_invoke_method_by_name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMethodName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInvoke;
    }
}

