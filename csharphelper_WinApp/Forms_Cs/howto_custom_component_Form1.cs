using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_custom_component;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_custom_component_Form1:Form
  { 


        public howto_custom_component_Form1()
        {
            InitializeComponent();
        }

        private void btnSayHi_Click(object sender, EventArgs e)
        {
            smiler1.SayHi();
            myComponent1.SayHello();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_custom_component_Form1));
            this.btnSayHi = new System.Windows.Forms.Button();
            this.smiler1 = new Smiler();
            this.myComponent1 = new howto_custom_component.MyComponent();
            this.SuspendLayout();
            // 
            // btnSayHi
            // 
            this.btnSayHi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSayHi.Location = new System.Drawing.Point(74, 12);
            this.btnSayHi.Name = "btnSayHi";
            this.btnSayHi.Size = new System.Drawing.Size(75, 23);
            this.btnSayHi.TabIndex = 1;
            this.btnSayHi.Text = "Say Hi";
            this.btnSayHi.UseVisualStyleBackColor = true;
            this.btnSayHi.Click += new System.EventHandler(this.btnSayHi_Click);
            // 
            // smiler1
            // 
            this.smiler1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.smiler1.AutoSize = true;
            this.smiler1.BackColor = System.Drawing.Color.Transparent;
            this.smiler1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("smiler1.BackgroundImage")));
            this.smiler1.Location = new System.Drawing.Point(95, 55);
            this.smiler1.Name = "smiler1";
            this.smiler1.Size = new System.Drawing.Size(32, 32);
            this.smiler1.TabIndex = 2;
            // 
            // howto_custom_component_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 159);
            this.Controls.Add(this.smiler1);
            this.Controls.Add(this.btnSayHi);
            this.Name = "howto_custom_component_Form1";
            this.Text = "howto_custom_component";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSayHi;
        private Smiler smiler1;
        private MyComponent myComponent1;

    }
}

