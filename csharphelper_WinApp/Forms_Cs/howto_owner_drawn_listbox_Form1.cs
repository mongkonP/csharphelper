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
     public partial class howto_owner_drawn_listbox_Form1:Form
  { 


        public howto_owner_drawn_listbox_Form1()
        {
            InitializeComponent();
        }

        // Make the ListBox owner drawn.
        private void howto_owner_drawn_listbox_Form1_Load(object sender, EventArgs e)
        {
            lstChoices.DrawMode = DrawMode.OwnerDrawVariable;

            // Create some items.
            lstChoices.Items.Add("Name: Mercury\nMass: 0.055 Earths\nYear: 87.9691 Earth days\nTemp: −183 °C to 427 °C");
            lstChoices.Items.Add("Name: Venus\nMass: 0.815 Earths\nYear: 243 Earth days");
            lstChoices.Items.Add("Name: Earth\nMass: 1.0 Earths\nYear: 365.256 Earth days");
            lstChoices.Items.Add("Name: Mars\nMass: 0.107 Earths\nYear: 686.971 Earth days");
        }

        // Calculate the size of an item.
        private int ItemMargin = 5;
        private void lstChoices_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // Get the ListBox and the item.
            ListBox lst = sender as ListBox;
            string txt = (string)lst.Items[e.Index];

            // Measure the string.
            SizeF txt_size = e.Graphics.MeasureString(txt, this.Font);

            // Set the required size.
            e.ItemHeight = (int)txt_size.Height + 2 * ItemMargin;
            e.ItemWidth = (int)txt_size.Width;
        }

        // Draw the item.
        private void lstChoices_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Get the ListBox and the item.
            ListBox lst = sender as ListBox;
            string txt = (string)lst.Items[e.Index];

            // Draw the background.
            e.DrawBackground();

            // See if the item is selected.
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                // Selected. Draw with the system highlight color.
                e.Graphics.DrawString(txt, this.Font,
                    SystemBrushes.HighlightText, e.Bounds.Left, e.Bounds.Top + ItemMargin);
            }
            else
            {
                // Not selected. Draw with ListBox's foreground color.
                using (SolidBrush br = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(txt, this.Font, br,
                        e.Bounds.Left, e.Bounds.Top + ItemMargin);
                }
            }

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
            this.lstChoices = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstChoices
            // 
            this.lstChoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstChoices.FormattingEnabled = true;
            this.lstChoices.Location = new System.Drawing.Point(12, 12);
            this.lstChoices.Name = "lstChoices";
            this.lstChoices.Size = new System.Drawing.Size(310, 238);
            this.lstChoices.TabIndex = 0;
            this.lstChoices.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstChoices_DrawItem);
            this.lstChoices.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstChoices_MeasureItem);
            // 
            // howto_owner_drawn_listbox_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 264);
            this.Controls.Add(this.lstChoices);
            this.Name = "howto_owner_drawn_listbox_Form1";
            this.Text = "howto_owner_drawn_listbox";
            this.Load += new System.EventHandler(this.howto_owner_drawn_listbox_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstChoices;
    }
}

