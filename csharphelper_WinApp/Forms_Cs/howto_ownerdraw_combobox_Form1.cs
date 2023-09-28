using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_ownerdraw_combobox;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_ownerdraw_combobox_Form1:Form
  { 


        public howto_ownerdraw_combobox_Form1()
        {
            InitializeComponent();
        }

        // Add colors and pictures to the ComboBoxes.
        private void howto_ownerdraw_combobox_Form1_Load(object sender, EventArgs e)
        {
            // Colors.
            Color[] colors =
            {
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Green,
                Color.Blue,
                Color.Indigo,
                Color.Purple,
            };
            cboColor.DisplayColorSamples(colors);
            cboColor.SelectedIndex = 0;

            // Faces.
            Image[] images = 
            {
                Properties.Resources.face1,
                Properties.Resources.face2,
                Properties.Resources.face3,
                Properties.Resources.face4,
            };
            cboFace.DisplayImages(images);
            cboFace.SelectedIndex = 0;
            cboFace.DropDownHeight = 200;
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
            this.cboFace = new System.Windows.Forms.ComboBox();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboFace
            // 
            this.cboFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFace.Font = new System.Drawing.Font("Arial", 16F);
            this.cboFace.FormattingEnabled = true;
            this.cboFace.Location = new System.Drawing.Point(151, 12);
            this.cboFace.Name = "cboFace";
            this.cboFace.Size = new System.Drawing.Size(121, 32);
            this.cboFace.TabIndex = 3;
            // 
            // cboColor
            // 
            this.cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColor.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(12, 12);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(121, 32);
            this.cboColor.TabIndex = 2;
            // 
            // howto_ownerdraw_combobox_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cboFace);
            this.Controls.Add(this.cboColor);
            this.Name = "howto_ownerdraw_combobox_Form1";
            this.Text = "howto_ownerdraw_combobox";
            this.Load += new System.EventHandler(this.howto_ownerdraw_combobox_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboFace;
        private System.Windows.Forms.ComboBox cboColor;
    }
}

