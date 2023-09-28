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
     public partial class howto_loop_over_array_Form1:Form
  { 


        public howto_loop_over_array_Form1()
        {
            InitializeComponent();
        }

        private void howto_loop_over_array_Form1_Load(object sender, EventArgs e)
        {
            // List a one-dimensional array's values.
            string[] values1 = { "0", "1", "2", "3", "4" };
            string txt = "";
            for (int i = 0; i < values1.Length; i++)
            {
                txt += " " + values1[i];
            }
            if (txt.Length > 0) txt = txt.Substring(1);
            txtValues1.Text = txt;
            txtValues1.Select(0, 0);

            // List a two-dimensional array's values.
            string[,] values2 =
            { 
                { "(0, 0)", "(0, 1)", "(0, 2)", "(0, 3)", "(0, 4)" },
                { "(1, 0)", "(1, 1)", "(1, 2)", "(1, 3)", "(1, 4)" },
                { "(2, 0)", "(2, 1)", "(2, 2)", "(2, 3)", "(2, 4)" }
            };
            txt = "";
            for (int i = 0; i <= values2.GetUpperBound(0); i++)
            {
                string line = "";
                for (int j = 0; j <= values2.GetUpperBound(1); j++)
                {
                    line += " " + values2[i, j];
                }
                if (line.Length > 0) line = line.Substring(1);
                txt += Environment.NewLine + line;
            }
            if (txt.Length > 0) txt = txt.Substring(Environment.NewLine.Length);
            txtValues2.Text = txt;
            txtValues2.Select(0, 0);
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
            this.txtValues2 = new System.Windows.Forms.TextBox();
            this.txtValues1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtValues2
            // 
            this.txtValues2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValues2.Location = new System.Drawing.Point(16, 47);
            this.txtValues2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValues2.Multiline = true;
            this.txtValues2.Name = "txtValues2";
            this.txtValues2.ReadOnly = true;
            this.txtValues2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtValues2.Size = new System.Drawing.Size(293, 90);
            this.txtValues2.TabIndex = 3;
            // 
            // txtValues1
            // 
            this.txtValues1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValues1.Location = new System.Drawing.Point(16, 15);
            this.txtValues1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValues1.Name = "txtValues1";
            this.txtValues1.ReadOnly = true;
            this.txtValues1.Size = new System.Drawing.Size(293, 23);
            this.txtValues1.TabIndex = 2;
            // 
            // howto_loop_over_array_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 153);
            this.Controls.Add(this.txtValues2);
            this.Controls.Add(this.txtValues1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "howto_loop_over_array_Form1";
            this.Text = "howto_loop_over_array";
            this.Load += new System.EventHandler(this.howto_loop_over_array_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValues2;
        private System.Windows.Forms.TextBox txtValues1;
    }
}

