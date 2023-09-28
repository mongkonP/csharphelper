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
     public partial class howto_modal_contextmenu_ModalMenuForm:Form
  { 


        public howto_modal_contextmenu_ModalMenuForm()
        {
            InitializeComponent();
        }

        // Return the color selected in the ListBox.
        public Color SelectedColor
        {
            get
            {
                if (lstItems.SelectedItem == null) return SystemColors.Control;
                string color_name = lstItems.SelectedItem.ToString().Replace(" ", "");
                return Color.FromName(color_name);
            }
        }

        // Get the form ready.
        private void howto_modal_contextmenu_ModalMenuForm_Load(object sender, EventArgs e)
        {
            // Make the ListBox owner-drawn.
            lstItems.DrawMode = DrawMode.OwnerDrawVariable;

            // Set form properties.
            this.FormBorderStyle = FormBorderStyle.None;
            this.KeyPreview = true;

            // Make the form fit the ListBox.
            this.ClientSize = lstItems.Size;
        }

        // Close the dialog if the user presses Escape or Enter.
        private void howto_modal_contextmenu_ModalMenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            // If the user pressed Escape, return DialogResult.Cancel.
            if (e.KeyCode == Keys.Escape) DialogResult = DialogResult.Cancel;

            // If the user pressed Escape, return
            // DialogResult.OK if a color is selected.
            if (e.KeyCode == Keys.Enter)
            {
                if (lstItems.SelectedIndex < 0) DialogResult = DialogResult.Cancel;
                else DialogResult = DialogResult.OK;
            }
        }

        // Calculate the size of an item.
        private int ItemMargin = 5;
        private void lstItems_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // Get the ListBox and the item.
            ListBox lst = sender as ListBox;
            string txt = lst.Items[e.Index].ToString();

            // Measure the string.
            SizeF txt_size = e.Graphics.MeasureString(txt, this.Font);

            // Set the required size.
            e.ItemHeight = (int)txt_size.Height + 2 * ItemMargin;
            e.ItemWidth = (int)txt_size.Width;
        }

        // Draw the item.
        private void lstItems_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Get the ListBox and the item.
            ListBox lst = sender as ListBox;
            string txt = lst.Items[e.Index].ToString();

            // Draw the background.
            e.DrawBackground();

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

            // Don't draw the focus rectangle for
            // this example because the user cannot use
            // the arrow keys to change the selection.
            //// Draw the focus rectangle if appropriate.
            //e.DrawFocusRectangle();
        }

        // Select the ListBox item under the mouse.
        private void lstItems_MouseMove(object sender, MouseEventArgs e)
        {
            int index = lstItems.IndexFromPoint(e.Location);
            if (lstItems.SelectedIndex != index) lstItems.SelectedIndex = index;
        }

        // If the form isn't closing, deselect the ListBox item.
        private void lstItems_MouseLeave(object sender, EventArgs e)
        {
            // If the form is closing, leave the selection alone.
            if (DialogResult != DialogResult.None) return;
            if (lstItems.SelectedIndex != -1) lstItems.SelectedIndex = -1;
        }

        private void lstItems_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex < 0) DialogResult = DialogResult.Cancel;
            else DialogResult = DialogResult.OK;
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
            this.lstItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstItems.FormattingEnabled = true;
            this.lstItems.IntegralHeight = false;
            this.lstItems.Items.AddRange(new object[] {
            "Pink",
            "Light Green",
            "Light Blue"});
            this.lstItems.Location = new System.Drawing.Point(0, 0);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(96, 75);
            this.lstItems.TabIndex = 0;
            this.lstItems.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstItems_DrawItem);
            this.lstItems.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstItems_MeasureItem);
            this.lstItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstItems_MouseMove);
            this.lstItems.MouseLeave += new System.EventHandler(this.lstItems_MouseLeave);
            this.lstItems.Click += new System.EventHandler(this.lstItems_Click);
            // 
            // howto_modal_contextmenu_ModalMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(110, 110);
            this.Controls.Add(this.lstItems);
            this.Name = "howto_modal_contextmenu_ModalMenuForm";
            this.Text = "howto_modal_contextmenu_ModalMenuForm";
            this.Load += new System.EventHandler(this.howto_modal_contextmenu_ModalMenuForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.howto_modal_contextmenu_ModalMenuForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstItems;


    }
}