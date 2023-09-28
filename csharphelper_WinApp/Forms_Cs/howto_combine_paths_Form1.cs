using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_combine_paths_Form1:Form
  { 


        public howto_combine_paths_Form1()
        {
            InitializeComponent();
        }

        // Use the startup path for Path 1.
        private void howto_combine_paths_Form1_Load(object sender, EventArgs e)
        {
            txtPath1.Text = Application.StartupPath;
        }

        // Combine the paths.
        private void btnCombine_Click(object sender, EventArgs e)
        {
            txtResult.Text = Path.GetFullPath(
                Path.Combine(txtPath1.Text, txtPath2.Text));

            Console.WriteLine(Path.GetFullPath(
                Path.Combine(Application.StartupPath, "../..")));
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
            this.txtPath1 = new System.Windows.Forms.TextBox();
            this.txtPath2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCombine = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path 1:";
            // 
            // txtPath1
            // 
            this.txtPath1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath1.Location = new System.Drawing.Point(59, 12);
            this.txtPath1.Name = "txtPath1";
            this.txtPath1.Size = new System.Drawing.Size(444, 20);
            this.txtPath1.TabIndex = 1;
            // 
            // txtPath2
            // 
            this.txtPath2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath2.Location = new System.Drawing.Point(59, 38);
            this.txtPath2.Name = "txtPath2";
            this.txtPath2.Size = new System.Drawing.Size(444, 20);
            this.txtPath2.TabIndex = 3;
            this.txtPath2.Text = "..\\..\\test.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Path 2:";
            // 
            // btnCombine
            // 
            this.btnCombine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCombine.Location = new System.Drawing.Point(220, 64);
            this.btnCombine.Name = "btnCombine";
            this.btnCombine.Size = new System.Drawing.Size(75, 23);
            this.btnCombine.TabIndex = 4;
            this.btnCombine.Text = "Combine";
            this.btnCombine.UseVisualStyleBackColor = true;
            this.btnCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(59, 103);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(444, 20);
            this.txtResult.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result:";
            // 
            // howto_combine_paths_Form1
            // 
            this.AcceptButton = this.btnCombine;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 138);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCombine);
            this.Controls.Add(this.txtPath2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPath1);
            this.Controls.Add(this.label1);
            this.Name = "howto_combine_paths_Form1";
            this.Text = "howto_combine_paths";
            this.Load += new System.EventHandler(this.howto_combine_paths_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath1;
        private System.Windows.Forms.TextBox txtPath2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCombine;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label3;
    }
}

