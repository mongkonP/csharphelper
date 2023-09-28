using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_end_cap_base_inset_Form1:Form
  { 


        public howto_end_cap_base_inset_Form1()
        {
            InitializeComponent();
        }

        private void howto_end_cap_base_inset_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen the_pen = new Pen(Color.Blue, 5))
            {
                // Make a GraphicsPath to define the start cap.
                using (GraphicsPath start_path = new GraphicsPath())
                {
                    start_path.AddEllipse(-2, -2, 4, 4);

                    // Make the start cap.
                    using (CustomLineCap start_cap = new CustomLineCap(null, start_path))
                    {
                        // Make a GraphicsPath to define the end cap.
                        using (GraphicsPath end_path = new GraphicsPath())
                        {
                            end_path.AddEllipse(-0.5f, -0.5f, 1, 1);

                            // Make the end cap.
                            using (CustomLineCap end_cap = new CustomLineCap(end_path, null))
                            {
                                the_pen.CustomStartCap = start_cap;
                                the_pen.CustomEndCap = end_cap;

                                // Draw some lines without base insets.
                                the_pen.Color = Color.Green;
                                e.Graphics.DrawLine(the_pen, 20, 20, 125, 60);
                                the_pen.Color = Color.Orange;
                                e.Graphics.DrawLine(the_pen, 125, 60, 210, 30);
                                the_pen.Color = Color.Blue;
                                e.Graphics.DrawLine(the_pen, 210, 30, 300, 70);

                                // Translate and draw with insets.
                                e.Graphics.TranslateTransform(0, 50);
                                start_cap.BaseInset = 2;
                                end_cap.BaseInset = 2;
                                the_pen.CustomStartCap = start_cap;
                                the_pen.CustomEndCap = end_cap;

                                the_pen.Color = Color.Green;
                                e.Graphics.DrawLine(the_pen, 20, 20, 125, 60);
                                the_pen.Color = Color.Orange;
                                e.Graphics.DrawLine(the_pen, 125, 60, 210, 30);
                                the_pen.Color = Color.Blue;
                                e.Graphics.DrawLine(the_pen, 210, 30, 300, 70);
                            }
                        }
                    }
                }
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
            // howto_end_cap_base_inset_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 141);
            this.Name = "howto_end_cap_base_inset_Form1";
            this.Text = "howto_end_cap_base_inset";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_end_cap_base_inset_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

