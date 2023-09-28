// #define TEST

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_conditional_attribute_Form1:Form
  { 


        public howto_conditional_attribute_Form1()
        {
            InitializeComponent();
        }

        private void howto_conditional_attribute_Form1_Load(object sender, EventArgs e)
        {
            Test();
        }

        // This routine is callable if either DEBUG or TEST are
        // defined constants. Open the Project menu, select Properties,
        // click the Build tab, and enter DIAG or TEST in the
        // "Conditional compilation constants" box.
        [Conditional("DIAG")]
        [Conditional("TEST")]
        private void Test()
        {
            MessageBox.Show("Test");
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
            // howto_conditional_attribute_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Name = "howto_conditional_attribute_Form1";
            this.Text = "howto_conditional_attribute";
            this.Load += new System.EventHandler(this.howto_conditional_attribute_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

