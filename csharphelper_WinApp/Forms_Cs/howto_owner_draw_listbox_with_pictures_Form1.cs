using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_owner_draw_listbox_with_pictures;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_owner_draw_listbox_with_pictures_Form1:Form
  { 


        public howto_owner_draw_listbox_with_pictures_Form1()
        {
            InitializeComponent();
        }

        private const int ItemMargin = 5;
        private const float PictureHeight = 100f;

        // Create some objects.
        private void howto_owner_draw_listbox_with_pictures_Form1_Load(object sender, EventArgs e)
        {
            // Make the LIstBox owner drawn.
            lstPlanets.DrawMode = DrawMode.OwnerDrawVariable;

            lstPlanets.Items.Add(new Planet("Mercury", Properties.Resources.Mercury, "Distance: 0.39 AU, Radius: 0.38, Mass: 0.05, Day: 59 days, Year: 88 days"));
            lstPlanets.Items.Add(new Planet("Venus", Properties.Resources.Venus, "Distance: 0.72 AU, Radius: 0.95, Mass: 0.89, Day: 243 days, Year: 224 days"));
            lstPlanets.Items.Add(new Planet("Earth", Properties.Resources.Earth, "Distance: 1 AU, Radius: 1, Mass: 1, Day: 1 day, Year: 365 days"));
            lstPlanets.Items.Add(new Planet("Mars", Properties.Resources.Mars, "Distance: 1.5 AU, Radius: 0.53, Mass: 0.11, Day: 1.026 days, Year: 687 days"));
            lstPlanets.Items.Add(new Planet("Jupiter", Properties.Resources.Jupiter, "Distance: 5.2 AU, Radius: 11, Mass: 318, Day: 0.411 days, Year: 11.8 years"));
            lstPlanets.Items.Add(new Planet("Saturn", Properties.Resources.Saturn, "Distance: 9.5 AU, Radius: 9, Mass: 95, Day: 0.43 days, Year: 29.5 years"));
            lstPlanets.Items.Add(new Planet("Uranus", Properties.Resources.Uranus, "Distance: 19.2 AU, Radius: 4, Mass: 17, Day: 0.75 days, Year: 84 years"));
            lstPlanets.Items.Add(new Planet("Neptune", Properties.Resources.Neptune, "Distance: 30.1 AU, Radius: 4, Mass: 17, Day: 0.8 days, Year: 165 years"));
            lstPlanets.Items.Add(new Planet("Pluto", Properties.Resources.Pluto, "Distance: 39.5 AU, Radius: 0.18, Mass: 0.002, Day: 0.27 days, Year: 248 years"));
        }

        // Return enough space for the item.
        private void lstPlanets_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)(PictureHeight + 2 * ItemMargin);
        }

        // Draw the item.
        private void lstPlanets_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Get the ListBox and the item.
            ListBox lst = sender as ListBox;
            Planet planet = (Planet)lst.Items[e.Index];

            // Draw the background.
            e.DrawBackground();

            // Draw the picture.
            float scale = PictureHeight / planet.Picture.Height;
            RectangleF source_rect = new RectangleF(
                0, 0, planet.Picture.Width, planet.Picture.Height);
            float picture_width = scale * planet.Picture.Width;
            RectangleF dest_rect = new RectangleF(
                e.Bounds.Left + ItemMargin, e.Bounds.Top + ItemMargin,
                picture_width, PictureHeight);
            e.Graphics.DrawImage(planet.Picture, dest_rect, source_rect, GraphicsUnit.Pixel);

            // See if the item is selected.
            Brush br;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                br = SystemBrushes.HighlightText;
            else
                br = new SolidBrush(e.ForeColor);

            // Find the area in which to put the text.
            float x = e.Bounds.Left + picture_width + 3 * ItemMargin;
            float y = e.Bounds.Top + ItemMargin;
            float width = e.Bounds.Right - ItemMargin - x;
            float height = e.Bounds.Bottom - ItemMargin - y;
            RectangleF layout_rect = new RectangleF(x, y, width, height);

            // Draw the text.
            string txt = planet.Name + '\n' + planet.Stats;
            e.Graphics.DrawString(txt, this.Font, br, layout_rect);

            // Outline the text.
            e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(layout_rect));

            // Draw the focus rectangle if appropriate.
            e.DrawFocusRectangle();
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
            this.lstPlanets = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstPlanets
            // 
            this.lstPlanets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPlanets.FormattingEnabled = true;
            this.lstPlanets.Location = new System.Drawing.Point(12, 12);
            this.lstPlanets.Name = "lstPlanets";
            this.lstPlanets.Size = new System.Drawing.Size(392, 264);
            this.lstPlanets.TabIndex = 0;
            this.lstPlanets.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstPlanets_DrawItem);
            this.lstPlanets.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstPlanets_MeasureItem);
            // 
            // howto_owner_draw_listbox_with_pictures_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 290);
            this.Controls.Add(this.lstPlanets);
            this.Name = "howto_owner_draw_listbox_with_pictures_Form1";
            this.Text = "howto_owner_draw_listbox_with_pictures";
            this.Load += new System.EventHandler(this.howto_owner_draw_listbox_with_pictures_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstPlanets;
    }
}

