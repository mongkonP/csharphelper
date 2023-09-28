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
     public partial class howto_disable_warnings_Form1:Form
  { 


        /// <summary>
        /// Constructor.
        /// </summary>
        public howto_disable_warnings_Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method does something that should
        /// be documented with an XML comment.
        /// </summary>
        public void Method1()
        {
        }

        // This method doesn't need XML documentation.
#pragma warning disable 1591
        public void Method2()
#pragma warning restore 1591
        {
        }

        // This method doesn't have XML documentation but should.
        public void Method3()
        {
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
            this.SuspendLayout();
            // 
            // howto_disable_warnings_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "howto_disable_warnings_Form1";
            this.Text = "howto_disable_warnings";
            this.ResumeLayout(false);

        }

        #endregion
    }
}

