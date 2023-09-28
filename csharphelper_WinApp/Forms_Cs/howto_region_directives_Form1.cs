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
     public partial class howto_region_directives_Form1:Form
  { 


        public howto_region_directives_Form1()
        {
            InitializeComponent();
        }

        private void howto_region_directives_Form1_Load(object sender, EventArgs e)
        {
            int a = 1;
            #region "Region1"
            a++;
            #region "Region2"
            a++;
            #endregion "Region1"
            a++;
            #endregion "Region2"
            a++;
        }

        #region "Region3"

        private void Test1()
        {
            int b = 0;
            b++;
        }

        private void Test2()
        {
            int b = 0;
        #endregion "Region3"
            b++;
        }

        private void Test3()
        {
            int b = 0;
            b++;
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
            // howto_region_directives_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "howto_region_directives_Form1";
            this.Text = "howto_region_directives";
            this.ResumeLayout(false);

        }

        #endregion
    }
}

