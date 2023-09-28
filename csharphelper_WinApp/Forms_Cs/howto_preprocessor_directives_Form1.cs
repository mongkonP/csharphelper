#define DEBUG_LEVEL_1

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
     public partial class howto_preprocessor_directives_Form1:Form
  { 


        public howto_preprocessor_directives_Form1()
        {
            InitializeComponent();
        }

        private void howto_preprocessor_directives_Form1_Load(object sender, EventArgs e)
        {
            // Use a value #defined in this file.
#if DEBUG_LEVEL_1
            txtDebugLevel.Text = "1";
#elif DEBUG_LEVEL_2
            txtDebugLevel.Text = "2";
#else
            txtDebugLevel.Text = "Other";
#endif

            // Use a value defined by Project > Properties >
            // Build > Conditional Compilation Symbols.
#if TEST
            txtATest.Text = "Yes";
#else
            txtATest.Text = "No";
#endif
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDebugLevel = new System.Windows.Forms.TextBox();
            this.txtATest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Debug Level:";
            // 
            // txtDebugLevel
            // 
            this.txtDebugLevel.Location = new System.Drawing.Point(89, 12);
            this.txtDebugLevel.Name = "txtDebugLevel";
            this.txtDebugLevel.Size = new System.Drawing.Size(44, 20);
            this.txtDebugLevel.TabIndex = 1;
            this.txtDebugLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtATest
            // 
            this.txtATest.Location = new System.Drawing.Point(89, 38);
            this.txtATest.Name = "txtATest";
            this.txtATest.Size = new System.Drawing.Size(44, 20);
            this.txtATest.TabIndex = 3;
            this.txtATest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "A Test?";
            // 
            // howto_preprocessor_directives_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 76);
            this.Controls.Add(this.txtATest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDebugLevel);
            this.Controls.Add(this.label1);
            this.Name = "howto_preprocessor_directives_Form1";
            this.Text = "howto_preprocessor_directives";
            this.Load += new System.EventHandler(this.howto_preprocessor_directives_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDebugLevel;
        private System.Windows.Forms.TextBox txtATest;
        private System.Windows.Forms.Label label2;
    }
}

