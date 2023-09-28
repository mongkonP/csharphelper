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
     public partial class howto_tab_accelerators_Form1:Form
  { 


        public howto_tab_accelerators_Form1()
        {
            InitializeComponent();
        }

        private void howto_tab_accelerators_Form1_Load(object sender, EventArgs e)
        {
            // We will draw the tabs.
            tabMenu.DrawMode = TabDrawMode.OwnerDrawFixed;

            // Look for Alt+B, Alt+L, and Alt+D.
            this.KeyPreview = true;
        }

        // Draw a tab.
        private void tabMenu_DrawItem(object sender, DrawItemEventArgs e)
        {
            // We draw in the TabRect rather than on e.Bounds
            // so the text doesn't move when the tab is selected.
            Rectangle tab_rect = tabMenu.GetTabRect(e.Index);
            tab_rect.Height += 3;

            // Draw the background.
            // Pick an appropriate background color.
            Brush bg_brush;
            if (e.State == DrawItemState.Selected)
            {
                bg_brush = new SolidBrush(Color.White);
            }
            else
            {
                bg_brush = new LinearGradientBrush(
                    tab_rect,
                    Color.White,
                    SystemColors.ControlDark,
                    LinearGradientMode.Vertical);
            }

            // Fill the background.
            e.Graphics.FillRectangle(bg_brush, tab_rect);
            bg_brush.Dispose();

            // If selected, draw the focus rectangle.
            if (e.State == DrawItemState.Selected) e.DrawFocusRectangle();

            // Draw the text.
            // Move the text area a bit.
            tab_rect.X += 3;
            tab_rect.Width -= 3;

            using (StringFormat string_format = new StringFormat())
            {
                // Draw the tab's text.
                string_format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
                string_format.Alignment = StringAlignment.Near;
                string_format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(
                    tabMenu.TabPages[e.Index].Text,
                    tabMenu.Font,
                    Brushes.Black,
                    tab_rect,
                    string_format);
            }

            // Note: Don't Dispose the stock pens and brushes.
        }

        // Look for Alt+B, Alt+L, and Alt+D.
        private void howto_tab_accelerators_Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.B:
                        tabMenu.Focus();
                        tabMenu.SelectedTab = tabPageBreakfast;
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.L:
                        tabMenu.Focus();
                        tabMenu.SelectedTab = tabPageLunch;
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D:
                        tabMenu.Focus();
                        tabMenu.SelectedTab = tabPageDinner;
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                }
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.tabPageBreakfast = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageLunch = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageDinner = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.tabPageBreakfast.SuspendLayout();
            this.tabPageLunch.SuspendLayout();
            this.tabPageDinner.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 119);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(335, 100);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(327, 74);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Breakfast";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Place controls for ordering breakfast here.";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(327, 74);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Lunch";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Place controls for ordering lunch here.";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(327, 74);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Dinner";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Place controls for ordering dinner here.";
            // 
            // tabMenu
            // 
            this.tabMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMenu.Controls.Add(this.tabPageBreakfast);
            this.tabMenu.Controls.Add(this.tabPageLunch);
            this.tabMenu.Controls.Add(this.tabPageDinner);
            this.tabMenu.Location = new System.Drawing.Point(12, 13);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(335, 100);
            this.tabMenu.TabIndex = 1;
            this.tabMenu.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabMenu_DrawItem);
            // 
            // tabPageBreakfast
            // 
            this.tabPageBreakfast.Controls.Add(this.label1);
            this.tabPageBreakfast.Location = new System.Drawing.Point(4, 22);
            this.tabPageBreakfast.Name = "tabPageBreakfast";
            this.tabPageBreakfast.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBreakfast.Size = new System.Drawing.Size(327, 74);
            this.tabPageBreakfast.TabIndex = 0;
            this.tabPageBreakfast.Text = "&Breakfast";
            this.tabPageBreakfast.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Place controls for ordering breakfast here.";
            // 
            // tabPageLunch
            // 
            this.tabPageLunch.Controls.Add(this.label3);
            this.tabPageLunch.Location = new System.Drawing.Point(4, 22);
            this.tabPageLunch.Name = "tabPageLunch";
            this.tabPageLunch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLunch.Size = new System.Drawing.Size(327, 74);
            this.tabPageLunch.TabIndex = 1;
            this.tabPageLunch.Text = "&Lunch";
            this.tabPageLunch.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Place controls for ordering lunch here.";
            // 
            // tabPageDinner
            // 
            this.tabPageDinner.Controls.Add(this.label5);
            this.tabPageDinner.Location = new System.Drawing.Point(4, 22);
            this.tabPageDinner.Name = "tabPageDinner";
            this.tabPageDinner.Size = new System.Drawing.Size(327, 74);
            this.tabPageDinner.TabIndex = 2;
            this.tabPageDinner.Text = "&Dinner";
            this.tabPageDinner.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Place controls for ordering dinner here.";
            // 
            // howto_tab_accelerators_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 232);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tabMenu);
            this.Name = "howto_tab_accelerators_Form1";
            this.Text = "howto_tab_accelerators";
            this.Load += new System.EventHandler(this.howto_tab_accelerators_Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.howto_tab_accelerators_Form1_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabMenu.ResumeLayout(false);
            this.tabPageBreakfast.ResumeLayout(false);
            this.tabPageBreakfast.PerformLayout();
            this.tabPageLunch.ResumeLayout(false);
            this.tabPageLunch.PerformLayout();
            this.tabPageDinner.ResumeLayout(false);
            this.tabPageDinner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage tabPageBreakfast;
        private System.Windows.Forms.TabPage tabPageLunch;
        private System.Windows.Forms.TabPage tabPageDinner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}

