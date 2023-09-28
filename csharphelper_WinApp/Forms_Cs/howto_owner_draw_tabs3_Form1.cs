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
     public partial class howto_owner_draw_tabs3_Form1:Form
  { 


        public howto_owner_draw_tabs3_Form1()
        {
            InitializeComponent();
        }

        // The size of the X in each tab's upper right corner.
        private int Xwid = 8;
        private const int tab_margin = 3;

        private void howto_owner_draw_tabs3_Form1_Load(object sender, EventArgs e)
        {
            // We will draw the tabs.
            tabMenu.DrawMode = TabDrawMode.OwnerDrawFixed;

            // SizeMode must be Fixed to change tab size.
            tabMenu.SizeMode = TabSizeMode.Fixed;

            // Set the size for the tabs.
            Size tab_size = tabMenu.ItemSize;
            tab_size.Width = 100;
            tab_size.Height += 6;
            tabMenu.ItemSize = tab_size;
        }

        // Draw a tab.
        private void tabMenu_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush txt_brush, box_brush;
            Pen box_pen;

            // We draw in the TabRect rather than on e.Bounds
            // so we can use TabRect later in MouseDown.
            Rectangle tab_rect = tabMenu.GetTabRect(e.Index);

            // Draw the background.
            // Pick appropriate pens and brushes.
            if (e.State == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.DarkOrange, tab_rect);
                e.DrawFocusRectangle();

                txt_brush = Brushes.Yellow;
                box_brush = Brushes.Silver;
                box_pen = Pens.DarkBlue;
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.PaleGreen, tab_rect);

                txt_brush = Brushes.DarkBlue;
                box_brush = Brushes.LightGray;
                box_pen = Pens.DarkBlue;
            }

            // Allow room for margins.
            RectangleF layout_rect = new RectangleF(
                tab_rect.Left + tab_margin,
                tab_rect.Y + tab_margin,
                tab_rect.Width - 2 * tab_margin,
                tab_rect.Height - 2 * tab_margin);
            using (StringFormat string_format = new StringFormat())
            {
                // Draw the tab # in the upper left corner.
                using (Font small_font = new Font(this.Font.FontFamily, 6, FontStyle.Bold))
                {
                    string_format.Alignment = StringAlignment.Near;
                    string_format.LineAlignment = StringAlignment.Near;
                    e.Graphics.DrawString(
                        e.Index.ToString(),
                        small_font,
                        txt_brush,
                        layout_rect,
                        string_format);
                }

                // Draw the tab's text centered.
                using (Font big_font = new Font(this.Font, FontStyle.Bold))
                {
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(
                        tabMenu.TabPages[e.Index].Text,
                        big_font,
                        txt_brush,
                        layout_rect,
                        string_format);
                }

                // Draw an X in the upper right corner.
                Rectangle rect = tabMenu.GetTabRect(e.Index);
                e.Graphics.FillRectangle(box_brush,
                    layout_rect.Right - Xwid,
                    layout_rect.Top,
                    Xwid,
                    Xwid);
                e.Graphics.DrawRectangle(box_pen,
                    layout_rect.Right - Xwid,
                    layout_rect.Top,
                    Xwid,
                    Xwid);
                e.Graphics.DrawLine(box_pen,
                    layout_rect.Right - Xwid,
                    layout_rect.Top,
                    layout_rect.Right,
                    layout_rect.Top + Xwid);
                e.Graphics.DrawLine(box_pen,
                    layout_rect.Right - Xwid,
                    layout_rect.Top + Xwid,
                    layout_rect.Right,
                    layout_rect.Top);
            }
        }

        // If the mouse is over an X, close the tab.
        private void tabMenu_MouseDown(object sender, MouseEventArgs e)
        {
            // See if this is over a tab.
            for (int i = 0; i < tabMenu.TabPages.Count; i++)
            {
                // Get the TabRect plus room for margins.
                Rectangle tab_rect = tabMenu.GetTabRect(i);
                RectangleF rect = new RectangleF(
                    tab_rect.Left + tab_margin,
                    tab_rect.Y + tab_margin,
                    tab_rect.Width - 2 * tab_margin,
                    tab_rect.Height - 2 * tab_margin);
                if (e.X >= rect.Right - Xwid &&
                    e.X <= rect.Right &&
                    e.Y >= rect.Top &&
                    e.Y <= rect.Top + Xwid)
                {
                    Console.WriteLine("Removing tab " + i);
                    tabMenu.TabPages.Remove(tabMenu.TabPages[i]);
                    return;
                }
            }
        }

        // Add a tab to the end of the TabControl.
        private void lblAddTab_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Adding a new tab");

            TabPage page = new TabPage("New");
            page.BackColor = Color.LightBlue;
            tabMenu.TabPages.Add(page);

            Label label = new Label();
            label.Location = new Point(0, 0);
            label.Text = "Tab number " + (tabMenu.TabPages.Count - 1);
            label.AutoSize = true;
            page.Controls.Add(label);
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
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAddTab = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabMenu.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMenu
            // 
            this.tabMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMenu.Controls.Add(this.tabPage1);
            this.tabMenu.Controls.Add(this.tabPage2);
            this.tabMenu.Controls.Add(this.tabPage3);
            this.tabMenu.Location = new System.Drawing.Point(12, 12);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(335, 140);
            this.tabMenu.TabIndex = 1;
            this.tabMenu.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabMenu_DrawItem);
            this.tabMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabMenu_MouseDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(327, 114);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Breakfast";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(327, 114);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lunch";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Place controls for ordering lunch here.";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(314, 114);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dinner";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Place controls for ordering dinner here.";
            // 
            // lblAddTab
            // 
            this.lblAddTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddTab.AutoSize = true;
            this.lblAddTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddTab.Location = new System.Drawing.Point(343, 1);
            this.lblAddTab.Name = "lblAddTab";
            this.lblAddTab.Size = new System.Drawing.Size(15, 15);
            this.lblAddTab.TabIndex = 2;
            this.lblAddTab.Text = "+";
            this.lblAddTab.Click += new System.EventHandler(this.lblAddTab_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Place controls for ordering breakfast here.";
            // 
            // howto_owner_draw_tabs3_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 164);
            this.Controls.Add(this.lblAddTab);
            this.Controls.Add(this.tabMenu);
            this.Name = "howto_owner_draw_tabs3_Form1";
            this.Text = "howto_owner_drawn_tabs";
            this.Load += new System.EventHandler(this.howto_owner_draw_tabs3_Form1_Load);
            this.tabMenu.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAddTab;
        private System.Windows.Forms.Label label4;
    }
}

