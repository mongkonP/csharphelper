using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_custom_component;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class Smiler:UserControl
  { 


        public Smiler()
        {
            InitializeComponent();
        }

        // Size the control to fit its background image.
        private void howto_custom_component_Smiler_Resize(object sender, EventArgs e)
        {
            Size = BackgroundImage.Size;
        }

        // Hide the control at runtime.
        private void howto_custom_component_Smiler_Load(object sender, EventArgs e)
        {
            if (!DesignMode) Visible = false;
        }

        public void SayHi()
        {
            MessageBox.Show("Hi", "howto_custom_component_Smiler", MessageBoxButtons.OK);
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // howto_custom_component_Smiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = Properties.Resources.Smiley;
            this.Name = "howto_custom_component_Smiler";
            this.Size = new System.Drawing.Size(32, 32);
            this.Load += new System.EventHandler(this.howto_custom_component_Smiler_Load);
            this.Resize += new System.EventHandler(this.howto_custom_component_Smiler_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
