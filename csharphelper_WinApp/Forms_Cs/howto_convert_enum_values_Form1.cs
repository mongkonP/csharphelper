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
     public partial class howto_convert_enum_values_Form1:Form
  { 


        public howto_convert_enum_values_Form1()
        {
            InitializeComponent();
        }

        // The enumerated type.
        private enum MealType
        {
            Breakfast,
            Brunch,
            Lunch,
            Luncheon = Lunch,
            Tiffin = Lunch,
            Tea,
            Nuncheon = Tea,
            Dinner,
            Supper
        }

        // Convert values to and from strings.
        private void howto_convert_enum_values_Form1_Load(object sender, EventArgs e)
        {
            foreach (string value in Enum.GetNames(typeof(MealType)))
            {
                // Get the enumeration's value.
                MealType meal = (MealType)Enum.Parse(typeof(MealType), value);

                // Display the values.
                lstStringValues.Items.Add((int)meal + "\t" + value);
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
            this.lstStringValues = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstStringValues
            // 
            this.lstStringValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStringValues.FormattingEnabled = true;
            this.lstStringValues.Location = new System.Drawing.Point(0, 0);
            this.lstStringValues.Name = "lstStringValues";
            this.lstStringValues.Size = new System.Drawing.Size(335, 134);
            this.lstStringValues.TabIndex = 0;
            // 
            // howto_convert_enum_values_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 135);
            this.Controls.Add(this.lstStringValues);
            this.Name = "howto_convert_enum_values_Form1";
            this.Text = "howto_convert_enum_values";
            this.Load += new System.EventHandler(this.howto_convert_enum_values_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstStringValues;
    }
}

