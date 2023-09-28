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
     public partial class howto_exit_case_statements_Form1:Form
  { 


        public howto_exit_case_statements_Form1()
        {
            InitializeComponent();
        }

        private void howto_exit_case_statements_Form1_Load(object sender, EventArgs e)
        {
            string result = "";
            int control = 1;
            switch (control)
            {
                case 1:
                case 2:
                    result = "One or two";
                    break;
                case 3:
                    result = "Three";
                    for (; ; ) ;
                case 4:
                    result = "Four";
                    while (true) ;
                case 5:
                    result = "Five";
                    return;
                case 6:
                    result = "Six";
                    throw new ArgumentException();
                case 7:     // This one isn't allowed.
                    result = "Seven";
                    /* while (control == 7)
                     {
                     }*/
                    return;
            }
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
            // howto_exit_case_statements_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "howto_exit_case_statements_Form1";
            this.Text = "howto_exit_case_statements";
            this.Load += new System.EventHandler(this.howto_exit_case_statements_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

