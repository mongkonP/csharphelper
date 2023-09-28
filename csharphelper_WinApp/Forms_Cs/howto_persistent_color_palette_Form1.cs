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
     public partial class howto_persistent_color_palette_Form1:Form
  { 


        public howto_persistent_color_palette_Form1()
        {
            InitializeComponent();
        }

        // The size used for each color patch.
        const int PatchWidth = 16, PatchHeight = 16;
        const int PatchMargin = 2;
        const int NumRows = 6, NumCols = 8;

        // Initialize the colors.
        private void howto_persistent_color_palette_Form1_Load(object sender, EventArgs e)
        {
            // Make the PictureBox the right size.
            picPalette.ClientSize =
                new Size(
                    NumCols * PatchWidth + (NumCols - 1) * PatchMargin,
                    NumRows * PatchHeight + (NumRows - 1) * PatchMargin);
            picPalette.Left = ClientSize.Width - picPalette.Width - picPalette.Top;

            // Load the saved colors.
            LoadColors();
        }

        // Load the colors.
        private void LoadColors()
        {
            if ((Properties.Settings.Default.Argbs == null) ||
                (Properties.Settings.Default.Argbs.Length == 0))
            {
                // Use default colors.
                Properties.Settings.Default.Argbs = DefaultColors();
            }
        }

        // Save the current colors.
        private void howto_persistent_color_palette_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveColors();
        }

        // Save the current colors.
        private void SaveColors()
        {
            Properties.Settings.Default.Save();
        }

        // Display the colors.
        private void picPalette_Paint(object sender, PaintEventArgs e)
        {
            int max_x = PatchWidth * NumCols;
            int x = 0, y = 0;
            foreach (int argb in Properties.Settings.Default.Argbs)
            {
                Color color = Color.FromArgb(argb);
                using (SolidBrush br = new SolidBrush(color))
                {
                    e.Graphics.FillRectangle(br, x, y,
                        PatchWidth, PatchHeight);
                }
                x += PatchWidth + PatchMargin;
                if (x > max_x)
                {
                    x = 0;
                    y += PatchHeight + PatchMargin;
                }
            }
        }

        // Set some default colors.
        private int[] DefaultColors()
        {
            Color[] colors =
            {
                Color.White,
                Color.FromArgb(255, 255, 192, 192),
                Color.FromArgb(255, 255, 224, 192),
                Color.FromArgb(255, 255, 255, 192),
                Color.FromArgb(255, 192, 255, 192),
                Color.FromArgb(255, 192, 255, 255),
                Color.FromArgb(255, 192, 192, 255),
                Color.FromArgb(255, 255, 192, 255),

                Color.FromArgb(255, 224, 224, 224),
                Color.FromArgb(255, 255, 128, 128),
                Color.FromArgb(255, 255, 192, 128),
                Color.FromArgb(255, 255, 255, 128),
                Color.FromArgb(255, 128, 255, 128),
                Color.FromArgb(255, 128, 255, 255),
                Color.FromArgb(255, 128, 128, 255),
                Color.FromArgb(255, 255, 128, 255),

                Color.FromArgb(255, 192, 192, 192),
                Color.Red,
                Color.FromArgb(255, 255, 128, 0),
                Color.Yellow,
                Color.FromArgb(255, 0, 192, 0),
                Color.Cyan,
                Color.Blue,
                Color.FromArgb(255, 255, 0, 255),

                Color.Gray,
                Color.FromArgb(255, 192, 0, 0),
                Color.FromArgb(255, 192, 64, 0),
                Color.FromArgb(255, 192, 192, 0),
                Color.Green,
                Color.FromArgb(255, 0, 192, 192),
                Color.FromArgb(255, 0, 0, 192),
                Color.FromArgb(255, 192, 0, 192),

                Color.FromArgb(255, 64, 64, 64),
                Color.FromArgb(255, 128, 0, 0),
                Color.FromArgb(255, 128, 64, 0),
                Color.FromArgb(255, 128, 128, 0),
                Color.FromArgb(255, 0, 128, 0),
                Color.FromArgb(255, 0, 128, 128),
                Color.FromArgb(255, 0, 0, 128),
                Color.FromArgb(255, 128, 0, 128),

                Color.Black,
                Color.FromArgb(255, 64, 0, 0),
                Color.FromArgb(255, 96, 32, 0),
                Color.FromArgb(255, 64, 64, 0),
                Color.FromArgb(255, 0, 64, 0),
                Color.FromArgb(255, 0, 64, 64),
                Color.FromArgb(255, 0, 0, 64),
                Color.FromArgb(255, 64, 0, 64),
            };

            int[] argbs = new int[colors.Length];
            for (int i = 0; i < colors.Length; i++)
                argbs[i] = colors[i].ToArgb();
            return argbs;
        }

        // Let the user select a color.
        private void picPalette_MouseClick(object sender, MouseEventArgs e)
        {
            // See which color was clicked.
            int row = (int)(e.Y / (PatchHeight + PatchMargin));
            int col = (int)(e.X / (PatchWidth + PatchMargin));
            int index = row * NumCols + col;

            // Let the user pick a color.
            cdColor.Color = Color.FromArgb(
                Properties.Settings.Default.Argbs[index]);
            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                // The user clicked OK. Save the selected color.
                Properties.Settings.Default.Argbs[index] =
                    cdColor.Color.ToArgb();
                picPalette.Refresh();
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
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.picPalette = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPalette)).BeginInit();
            this.SuspendLayout();
            // 
            // picPalette
            // 
            this.picPalette.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPalette.Location = new System.Drawing.Point(103, 16);
            this.picPalette.Name = "picPalette";
            this.picPalette.Size = new System.Drawing.Size(128, 128);
            this.picPalette.TabIndex = 2;
            this.picPalette.TabStop = false;
            this.picPalette.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picPalette_MouseClick);
            this.picPalette.Paint += new System.Windows.Forms.PaintEventHandler(this.picPalette_Paint);
            // 
            // howto_persistent_color_palette_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Controls.Add(this.picPalette);
            this.Name = "howto_persistent_color_palette_Form1";
            this.Text = "howto_persistent_color_palette";
            this.Load += new System.EventHandler(this.howto_persistent_color_palette_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_persistent_color_palette_Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picPalette)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.PictureBox picPalette;
    }
}

