using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_ownerdraw_image_and_text;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_ownerdraw_image_and_text_Form1:Form
  { 


        public howto_ownerdraw_image_and_text_Form1()
        {
            InitializeComponent();
        }

        private void howto_ownerdraw_image_and_text_Form1_Load(object sender, EventArgs e)
        {
            // Make a font for the item text.
            Font font = new Font("Times New Roman", 14);

            // Make image and text data.
            ImageAndText[] planets =
            {
                new ImageAndText(Properties.Resources.Mercury,
                    "Name: Mercury" + '\n' +
                    "Distance: 0.31-0.47" + '\n' +
                    "Distance: 0.31-0.47" + '\n' +
                    "Mass: 0.06" + '\n' +
                    "Diameter: 0.382" + '\n' +
                    "Year: 0.24" + '\n' +
                    "Day: 58.64",
                    font),
                new ImageAndText(Properties.Resources.Venus,
                    "Name: Venus" + '\n' +
                    "Distance: 0.72" + '\n' +
                    "Mass: 0.82" + '\n' +
                    "Diameter: 0.949" + '\n' +
                    "Year: 0.62" + '\n' +
                    "Day: -243.02",
                    font),
                new ImageAndText(Properties.Resources.Earth,
                    "Name: Earth" + '\n' +
                    "Distance: 1" + '\n' +
                    "Mass: 1" + '\n' +
                    "Diameter: 1" + '\n' +
                    "Year: 1" + '\n' +
                    "Day: 1",
                    font),
                new ImageAndText(Properties.Resources.Mars,
                    "Name: Mars" + '\n' +
                    "Distance: 1.52" + '\n' +
                    "Mass: 0.11" + '\n' +
                    "Diameter: 0.532" + '\n' +
                    "Year: 1.88" + '\n' +
                    "Day: 1.03",
                    font),
                new ImageAndText(Properties.Resources.Jupiter,
                    "Name: Jupiter" + '\n' +
                    "Distance: 5.2" + '\n' +
                    "Mass: 317.8" + '\n' +
                    "Diameter: 11.209" + '\n' +
                    "Year: 11.86" + '\n' +
                    "Day: 0.41",
                    font),
                new ImageAndText(Properties.Resources.Saturn,
                    "Name: Saturn" + '\n' +
                    "Distance: 9.54" + '\n' +
                    "Mass: 95.2" + '\n' +
                    "Diameter: 9.449" + '\n' +
                    "Year: 29.46" + '\n' +
                    "Day: 0.43",
                    font),
                new ImageAndText(Properties.Resources.Uranus,
                    "Name: Uranus" + '\n' +
                    "Distance: 19.22" + '\n' +
                    "Mass: 14.6" + '\n' +
                    "Diameter: 4.007" + '\n' +
                    "Year: 84.01" + '\n' +
                    "Day: −0.72",
                    font),
                new ImageAndText(Properties.Resources.Neptune,
                    "Name: Neptune" + '\n' +
                    "Distance: 30.06" + '\n' +
                    "Mass: 17.2" + '\n' +
                    "Diameter: 3.883" + '\n' +
                    "Year: 164.8" + '\n' +
                    "Day: 0.67",
                    font),
            };

            cboPlanets.DisplayImagesAndText(planets);
            cboPlanets.SelectedIndex = 0;
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
            this.cboPlanets = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboPlanets
            // 
            this.cboPlanets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPlanets.DropDownHeight = 400;
            this.cboPlanets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlanets.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPlanets.FormattingEnabled = true;
            this.cboPlanets.IntegralHeight = false;
            this.cboPlanets.Location = new System.Drawing.Point(12, 12);
            this.cboPlanets.Name = "cboPlanets";
            this.cboPlanets.Size = new System.Drawing.Size(346, 54);
            this.cboPlanets.TabIndex = 1;
            // 
            // howto_ownerdraw_image_and_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 261);
            this.Controls.Add(this.cboPlanets);
            this.Name = "howto_ownerdraw_image_and_text_Form1";
            this.Text = "howto_ownerdraw_image_and_text";
            this.Load += new System.EventHandler(this.howto_ownerdraw_image_and_text_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPlanets;
    }
}

