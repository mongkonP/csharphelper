using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Globalization;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_change_locale_at_runtime_Form1:Form
  { 


        public howto_change_locale_at_runtime_Form1()
        {
            InitializeComponent();
        }

        // Set the form's culture.
        private void SetCulture(string culture)
        {
            // Make the CultureInfo.
            CultureInfo culture_info = new CultureInfo(culture);

            // Make a ComponentResourceManager.
            ComponentResourceManager component_resource_manager
                = new ComponentResourceManager(this.GetType());

            // Apply resources to the form.
            component_resource_manager.ApplyResources(
                this, "$this", culture_info);

            // Apply resources to the form's controls.
            foreach (Control ctl in this.Controls)
            {
                component_resource_manager.ApplyResources(
                    ctl, ctl.Name, culture_info);
            }
        }

        private void radEnglish_Click(object sender, EventArgs e)
        {
            SetCulture("en-US");
        }

        private void radGerman_Click(object sender, EventArgs e)
        {
            SetCulture("de-DE");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_change_locale_at_runtime_Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radEnglish = new System.Windows.Forms.RadioButton();
            this.radGerman = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            resources.ApplyResources(this.radioButton4, "radioButton4");
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            resources.ApplyResources(this.radioButton5, "radioButton5");
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            resources.ApplyResources(this.radioButton6, "radioButton6");
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            resources.ApplyResources(this.radioButton7, "radioButton7");
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radEnglish
            // 
            resources.ApplyResources(this.radEnglish, "radEnglish");
            this.radEnglish.Checked = true;
            this.radEnglish.Name = "radEnglish";
            this.radEnglish.TabStop = true;
            this.radEnglish.UseVisualStyleBackColor = true;
            this.radEnglish.Click += new System.EventHandler(this.radEnglish_Click);
            // 
            // radGerman
            // 
            resources.ApplyResources(this.radGerman, "radGerman");
            this.radGerman.Name = "radGerman";
            this.radGerman.UseVisualStyleBackColor = true;
            this.radGerman.Click += new System.EventHandler(this.radGerman_Click);
            // 
            // howto_change_locale_at_runtime_Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radGerman);
            this.Controls.Add(this.radEnglish);
            this.Controls.Add(this.radioButton5);
            this.Controls.Add(this.radioButton6);
            this.Controls.Add(this.radioButton7);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Name = "howto_change_locale_at_runtime_Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radEnglish;
        private System.Windows.Forms.RadioButton radGerman;
    }
}

