using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_font_preview2;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_font_preview2_Form1:Form
  { 


        public howto_font_preview2_Form1()
        {
            InitializeComponent();
        }

        // At design time, set the dialog's ShowApply
        // property to true.

        // Display the dialog.
        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            // Save the original font.
            Font original_font = this.Font;

            // Initialize the dialog.
            fdFont.Font = this.Font;

            // Display the dialog and check the result.
            if (fdFont.ShowDialog() == DialogResult.OK)
            {
                // Apply the selected font.
                if (!this.Font.ValueEquals(fdFont.Font))
                    this.Font = fdFont.Font;
            }
            else
            {
                // Restore the original font.
                if (!this.Font.ValueEquals(original_font))
                    this.Font = original_font;
            }
        }

        // Apply the font.
        private void fdFont_Apply(object sender, EventArgs e)
        {
            this.Font = fdFont.Font;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectFont = new System.Windows.Forms.Button();
            this.fdFont = new System.Windows.Forms.FontDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instructions";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click the button to display the font selection dialog. On the dialog, click Apply" +
                " to see the form using that font.";
            // 
            // btnSelectFont
            // 
            this.btnSelectFont.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectFont.Location = new System.Drawing.Point(122, 108);
            this.btnSelectFont.Name = "btnSelectFont";
            this.btnSelectFont.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFont.TabIndex = 3;
            this.btnSelectFont.Text = "Select Font";
            this.btnSelectFont.UseVisualStyleBackColor = true;
            this.btnSelectFont.Click += new System.EventHandler(this.btnSelectFont_Click);
            // 
            // fdFont
            // 
            this.fdFont.ShowApply = true;
            this.fdFont.Apply += new System.EventHandler(this.fdFont_Apply);
            // 
            // howto_font_preview2_Form1
            // 
            this.AcceptButton = this.btnSelectFont;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 149);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSelectFont);
            this.Name = "howto_font_preview2_Form1";
            this.Text = "howto_font_preview2";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectFont;
        private System.Windows.Forms.FontDialog fdFont;
    }
}

