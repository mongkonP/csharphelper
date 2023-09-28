using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_enum_values_Form1:Form
  { 


        public howto_list_enum_values_Form1()
        {
            InitializeComponent();
        }

        // Display the names of the HatchStyle values.
        private void howto_list_enum_values_Form1_Load(object sender, EventArgs e)
        {
            List<HatchStyle> hatch_styles = GetEnumValues<HatchStyle>();
            foreach (HatchStyle hatch_style in hatch_styles)
            {
                lstHatchStyles.Items.Add(hatch_style.ToString());
            }
        }

        // Return a list of an enumerated type's values.
        private List<T> GetEnumValues<T>()
        {
            // Get the type's Type information.
            Type t_type = typeof(T);

            // Enumerate the Enum's fields.
            FieldInfo[] field_infos = t_type.GetFields();

            // Loop over the fields.
            List<T> results = new List<T>();
            foreach (FieldInfo field_info in field_infos)
            {
                // See if this is a literal value (set at compile time).
                if (field_info.IsLiteral)
                {
                    // Add it.
                    T value = (T)field_info.GetValue(null);
                    results.Add(value);
                }
            }

            return results;
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
            this.lstHatchStyles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstHatchStyles
            // 
            this.lstHatchStyles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHatchStyles.FormattingEnabled = true;
            this.lstHatchStyles.IntegralHeight = false;
            this.lstHatchStyles.Location = new System.Drawing.Point(12, 12);
            this.lstHatchStyles.MultiColumn = true;
            this.lstHatchStyles.Name = "lstHatchStyles";
            this.lstHatchStyles.Size = new System.Drawing.Size(484, 205);
            this.lstHatchStyles.TabIndex = 0;
            // 
            // howto_list_enum_values_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 229);
            this.Controls.Add(this.lstHatchStyles);
            this.Name = "howto_list_enum_values_Form1";
            this.Text = "howto_list_enum_values";
            this.Load += new System.EventHandler(this.howto_list_enum_values_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstHatchStyles;
    }
}

