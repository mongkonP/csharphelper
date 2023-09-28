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
     public partial class howto_generic_min_max_Form1:Form
  { 


        public howto_generic_min_max_Form1()
        {
            InitializeComponent();
        }

        private Random Rand = new Random();

        // Return the smallest of the values.
        private T Min<T>(params T[] values) where T : IComparable<T>
        {
            T min = values[0];
            for (int i = 1; i < values.Length; i++)
                if (values[i].CompareTo(min) < 0) min = values[i];
            return min;
        }

        // Return the largest of the values.
        private T Max<T>(params T[] values) where T : IComparable<T>
        {
            T max = values[0];
            for (int i = 1; i < values.Length; i++)
                if (values[i].CompareTo(max) > 0) max = values[i];
            return max;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            int A = Rand.Next(1, 100);
            int B = Rand.Next(1, 100);
            int C = Rand.Next(1, 100);
            int D = Rand.Next(1, 100);
            int E = Rand.Next(1, 100);

            txtValues.Text =
                A.ToString() + " " +
                B.ToString() + " " +
                C.ToString() + " " +
                D.ToString() + " " +
                E.ToString();
            txtMinimum.Text = Min(A, B, C, D, E).ToString();
            txtMaximum.Text = Max(A, B, C, D, E).ToString();
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
            this.btnGo = new System.Windows.Forms.Button();
            this.txtMaximum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMinimum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValues = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(125, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.goButton_Click);
            // 
            // txtMaximum
            // 
            this.txtMaximum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMaximum.Location = new System.Drawing.Point(142, 105);
            this.txtMaximum.Name = "txtMaximum";
            this.txtMaximum.ReadOnly = true;
            this.txtMaximum.Size = new System.Drawing.Size(100, 20);
            this.txtMaximum.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Maximum:";
            // 
            // txtMinimum
            // 
            this.txtMinimum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMinimum.Location = new System.Drawing.Point(142, 79);
            this.txtMinimum.Name = "txtMinimum";
            this.txtMinimum.ReadOnly = true;
            this.txtMinimum.Size = new System.Drawing.Size(100, 20);
            this.txtMinimum.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Minimum:";
            // 
            // txtValues
            // 
            this.txtValues.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtValues.Location = new System.Drawing.Point(142, 53);
            this.txtValues.Name = "txtValues";
            this.txtValues.ReadOnly = true;
            this.txtValues.Size = new System.Drawing.Size(100, 20);
            this.txtValues.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Values:";
            // 
            // howto_generic_min_max_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 141);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtMaximum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMinimum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValues);
            this.Controls.Add(this.label1);
            this.Name = "howto_generic_min_max_Form1";
            this.Text = "howto_generic_min_max";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtMaximum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMinimum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValues;
        private System.Windows.Forms.Label label1;
    }
}

