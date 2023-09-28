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
     public partial class howto_tool_buttons_Form1:Form
  { 


        public howto_tool_buttons_Form1()
        {
            InitializeComponent();
        }

        // Display all of the images in the Buttons folder.
        private void howto_tool_buttons_Form1_Load(object sender, EventArgs e)
        {
            const int wid = 32;
            const int hgt = 32;
            const int margin = 3;
            int x = margin;
            int y = margin;
            const int num_columns = 10;
            const int xmax = num_columns * (wid + margin);

            // Find the images.
            foreach (string filename in Directory.GetFiles("Buttons", "*.png"))
            {
                // Make a new Button.
                Button btn = new Button();
                btn.Parent = this;
                btn.Image = new Bitmap(filename);
                btn.Size = new Size(32, 32);
                btn.Location = new Point(x, y);
                x += wid + margin;
                if (x > xmax)
                {
                    x = margin;
                    y += hgt + margin;
                }

                FileInfo file_info = new FileInfo(filename);
                tipButton.SetToolTip(btn, file_info.Name);
            }

            // Size the form to fit.
            this.ClientSize = new Size(
                xmax + margin,
                y + hgt + margin);
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
            this.components = new System.ComponentModel.Container();
            this.tipButton = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // howto_tool_buttons_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 261);
            this.Name = "howto_tool_buttons_Form1";
            this.Text = "howto_tool_buttons";
            this.Load += new System.EventHandler(this.howto_tool_buttons_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipButton;
    }
}

