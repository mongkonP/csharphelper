using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_use_system_colors_Form1:Form
  { 


        public howto_use_system_colors_Form1()
        {
            InitializeComponent();
        }

        // List the system colors.
        private void howto_use_system_colors_Form1_Paint(object sender, PaintEventArgs e)
        {
            int y = 10;
            
            // Enumerate the SystemColors class's static Color properties.
            Type type = typeof(SystemColors);
            foreach (PropertyInfo field_info in type.GetProperties())
            {
                DrawColorSample(e.Graphics, ref y,
                    (Color)field_info.GetValue(null, null),
                    field_info.Name);                
            }

            // Size to fit.
            this.ClientSize = new Size(this.ClientSize.Width, y + 10);
        }

        // Display a color sample.
        private void DrawColorSample(Graphics gr, ref int y, Color clr, string clr_name)
        {
            using (SolidBrush br = new SolidBrush(clr))
            {
                gr.FillRectangle(br, 10, y, 90, 10);
            }
            gr.DrawRectangle(Pens.Black, 10, y, 90, 10);
            gr.DrawString(clr_name, this.Font, Brushes.Black, 110, y);
            y += 15;
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
            // howto_use_system_colors_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 264);
            this.Name = "howto_use_system_colors_Form1";
            this.Text = "howto_use_system_colors";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_use_system_colors_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

