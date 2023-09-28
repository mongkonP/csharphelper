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
     public partial class howto_add_delegates_Form1:Form
  { 


        public howto_add_delegates_Form1()
        {
            InitializeComponent();
        }

        // A delegate that represents a method that adds something to the ListBox.
        private delegate void AddToListDelegate();

        // Specific methods that match the delegate.
        private void MethodA()
        {
            lstResults.Items.Add("    This is MethodA");
        }
        private void MethodB()
        {
            lstResults.Items.Add("    This is MethodB");
        }

        // Define and use three delegates.
        private void howto_add_delegates_Form1_Load(object sender, EventArgs e)
        {
            // Define delegate variables.
            AddToListDelegate A = MethodA;
            AddToListDelegate B = MethodB;
            AddToListDelegate C = A + B;

            // Use the delegates.
            lstResults.Items.Add("Calling A:");
            A();
            lstResults.Items.Add("Calling B:");
            B();
            lstResults.Items.Add("Calling C:");
            C();
            lstResults.Items.Add("Calling C - A:");
            (C - A)();
            lstResults.Items.Add("Calling C -= A:");
            C -= A;
            C();
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
            this.lstResults = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(12, 13);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(260, 160);
            this.lstResults.TabIndex = 1;
            // 
            // howto_add_delegates_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 187);
            this.Controls.Add(this.lstResults);
            this.Name = "howto_add_delegates_Form1";
            this.Text = "howto_add_delegates";
            this.Load += new System.EventHandler(this.howto_add_delegates_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstResults;
    }
}

