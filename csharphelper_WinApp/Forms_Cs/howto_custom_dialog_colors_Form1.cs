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
     public partial class howto_custom_dialog_colors_Form1:Form
  { 


        public howto_custom_dialog_colors_Form1()
        {
            InitializeComponent();
        }

        // Initialize the dialog.
        private void howto_custom_dialog_colors_Form1_Load(object sender, EventArgs e)
        {
            // Use light custom colors for the background dialog.
            int[] bg_colors = {
                0xFFFFFF, 0xFFC0C0, 0xFFE0C0, 0xFFFFC0, 0xC0FFC0,
                0xC0FFFF, 0xC0C0FF, 0xFFC0FF, 0xE0E0E0, 0xFF8080,
                0xFFC080, 0xFFFF80, 0x80FF80, 0x80FFFF, 0x8080FF,
                0xFF80FF
            };
            dlgBgColor.CustomColors = bg_colors;

            // Use dark custom colors for the foreground dialog.
            int[] fg_colors = {
                0x808080, 0xFF0000, 0xFF8000, 0xFFFF00, 0x00FF00,
                0x00FFFF, 0x0000FF, 0xFF00FF, 0x000000, 0xC00000,
                0x804000, 0xC0C000, 0x008000, 0x00C0C0, 0x0000C0,
                0x800080 };
            dlgFgColor.CustomColors = fg_colors;

            // Make the background dialog open with the custom colors displayed.
            dlgBgColor.FullOpen = true;
            dlgFgColor.FullOpen = false;
        }

        // Let the user select a foreground color.
        private void btnFgColor_Click(object sender, EventArgs e)
        {
            // Initialize the dialog's selected color.
            dlgFgColor.Color = this.ForeColor;

            // Display the dialog and check the result.
            if (dlgFgColor.ShowDialog() == DialogResult.OK)
            {
                this.ForeColor = dlgFgColor.Color;
            }
        }

        // Let the user select a background color.
        private void btnBgColor_Click(object sender, EventArgs e)
        {
            // Initialize the dialog's selected color.
            dlgBgColor.Color = this.BackColor;

            // Display the dialog and check the result.
            if (dlgBgColor.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = dlgBgColor.Color;
                btnBgColor.BackColor = dlgBgColor.Color;
                btnFgColor.BackColor = dlgBgColor.Color;
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
            this.btnFgColor = new System.Windows.Forms.Button();
            this.btnBgColor = new System.Windows.Forms.Button();
            this.dlgBgColor = new System.Windows.Forms.ColorDialog();
            this.dlgFgColor = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFgColor
            // 
            this.btnFgColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFgColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFgColor.Location = new System.Drawing.Point(156, 12);
            this.btnFgColor.Name = "btnFgColor";
            this.btnFgColor.Size = new System.Drawing.Size(108, 23);
            this.btnFgColor.TabIndex = 1;
            this.btnFgColor.Text = "Foreground Color";
            this.btnFgColor.UseVisualStyleBackColor = true;
            this.btnFgColor.Click += new System.EventHandler(this.btnFgColor_Click);
            // 
            // btnBgColor
            // 
            this.btnBgColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBgColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBgColor.Location = new System.Drawing.Point(21, 12);
            this.btnBgColor.Name = "btnBgColor";
            this.btnBgColor.Size = new System.Drawing.Size(108, 23);
            this.btnBgColor.TabIndex = 0;
            this.btnBgColor.Text = "Background Color";
            this.btnBgColor.UseVisualStyleBackColor = true;
            this.btnBgColor.Click += new System.EventHandler(this.btnBgColor_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 79);
            this.label1.TabIndex = 2;
            this.label1.Text = "This example displays foreground and background color dialogs that contain custom" +
                " colors.";
            // 
            // howto_custom_dialog_colors_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 144);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBgColor);
            this.Controls.Add(this.btnFgColor);
            this.Name = "howto_custom_dialog_colors_Form1";
            this.Text = "howto_custom_dialog_colors";
            this.Load += new System.EventHandler(this.howto_custom_dialog_colors_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFgColor;
        private System.Windows.Forms.Button btnBgColor;
        private System.Windows.Forms.ColorDialog dlgBgColor;
        private System.Windows.Forms.ColorDialog dlgFgColor;
        private System.Windows.Forms.Label label1;
    }
}

