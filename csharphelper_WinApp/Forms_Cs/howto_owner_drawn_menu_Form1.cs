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
     public partial class howto_owner_drawn_menu_Form1:Form
  { 


        public howto_owner_drawn_menu_Form1()
        {
            InitializeComponent();
        }

        private const string FONT_NAME = "Times New Roman";
        private const float FONT_SIZE = 12;
        private const FontStyle FONT_STYLE = FontStyle.Bold;
        private const string MENU_CAPTION = "Say Hi";

        // Tell Windows how big to make the menu item.
        private void mnuFileSayHi_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // Create the font we will use to draw the text.
            using (Font menu_font = new Font(
                FONT_NAME, FONT_SIZE, FONT_STYLE))
            {
                // See how big the text will be.
                SizeF text_size =
                    e.Graphics.MeasureString(MENU_CAPTION, menu_font);

                // Set the necessary size.
                e.ItemHeight = (int)text_size.Height;
                e.ItemWidth = (int)text_size.Width;
            }
        }

        // Draw the menu item.
        private void mnuFileSayHi_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Create the font we will use to draw the text.
            using (Font menu_font = new Font(
                FONT_NAME, FONT_SIZE, FONT_STYLE))
            {
                // See if the mouse is over the menu item.
                if ((e.State & DrawItemState.Selected) != DrawItemState.None)
                {
                    // The mouse is over the item.
                    // Draw a shaded background.
                    using (Brush menu_brush =
                        new LinearGradientBrush(
                            e.Bounds, Color.Red,Color.Black,90))
                    {
                        e.Graphics.FillRectangle(menu_brush, e.Bounds);
                    }

                    // Draw the text.
                    e.Graphics.DrawString(MENU_CAPTION, menu_font,
                        System.Drawing.Brushes.AliceBlue,
                        e.Bounds.X, e.Bounds.Y);
                } 
                else 
                {
                    // The mouse is not over the item.
                    // Erase the background.
                    e.Graphics.FillRectangle(
                        System.Drawing.Brushes.LightGray,
                        e.Bounds.X, e.Bounds.Y,
                        e.Bounds.Width, e.Bounds.Height);

                    // Draw the text.
                    e.Graphics.DrawString(MENU_CAPTION, menu_font,
                        System.Drawing.Brushes.Black,
                        e.Bounds.X, e.Bounds.Y);
                }
            }
        }

        // Say hi.
        private void mnuFileSayHi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi");
        }

        // Exit.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuFileSayHi = new System.Windows.Forms.MenuItem();
            this.mnuFileExit = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem1});
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 0;
            this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFileSayHi,
            this.mnuFileExit});
            this.MenuItem1.Text = "&File";
            // 
            // mnuFileSayHi
            // 
            this.mnuFileSayHi.Index = 0;
            this.mnuFileSayHi.OwnerDraw = true;
            this.mnuFileSayHi.Text = "SayHi";
            this.mnuFileSayHi.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.mnuFileSayHi_DrawItem);
            this.mnuFileSayHi.Click += new System.EventHandler(this.mnuFileSayHi_Click);
            this.mnuFileSayHi.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.mnuFileSayHi_MeasureItem);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Index = 1;
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // howto_owner_drawn_menu_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 90);
            this.Menu = this.mnuMain;
            this.Name = "howto_owner_drawn_menu_Form1";
            this.Text = "howto_owner_drawn_menu";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.MainMenu mnuMain;
        internal System.Windows.Forms.MenuItem MenuItem1;
        internal System.Windows.Forms.MenuItem mnuFileSayHi;
        internal System.Windows.Forms.MenuItem mnuFileExit;
    }
}

