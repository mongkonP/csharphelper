using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_eula_once;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_eula_once_Form1:Form
  { 


        public howto_eula_once_Form1()
        {
            InitializeComponent();
        }

        private void howto_eula_once_Form1_Load(object sender, EventArgs e)
        {
            // See if the user has already accepted the EULA.
            if (RegistryTools.GetSetting(
                "howto_eula_once", "EulaIsAccepted", "False").ToString()
                    != "True")
            {
                // Display the EULA.
                howto_eula_once_EulaForm frm = new  howto_eula_once_EulaForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Remember that the user accepted the EULA.
                    RegistryTools.SaveSetting(
                        "howto_eula_once", "EulaIsAccepted", "True");                
                }
                else
                {
                    // The user declined. Close the program.
                    this.Close();
                    return;
                }
            }

            // Perform other initialization stuff.

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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 145);
            this.label1.TabIndex = 0;
            this.label1.Text = "Congratulations! You can now use the program!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_eula_once_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 145);
            this.Controls.Add(this.label1);
            this.Name = "howto_eula_once_Form1";
            this.Text = "howto_eula_once";
            this.Load += new System.EventHandler(this.howto_eula_once_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}

