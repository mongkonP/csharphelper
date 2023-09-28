using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

// Added a bitmap resource named happy to the program.

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_owner_drawn_tooltip_Form1:Form
  { 


        public howto_owner_drawn_tooltip_Form1()
        {
            InitializeComponent();
        }

        // Set a multi-line tooltip in code.
        private void howto_owner_drawn_tooltip_Form1_Load(object sender, EventArgs e)
        {
            tipButtons.SetToolTip(btnWhatever,
                "Whatever...\nWhatever...\nWhatever...");
        }

        private const int Margin = 10;

        // Set the tooltip's bounds.
        private void tipButtons_Popup(object sender, PopupEventArgs e)
        {
            int image_wid = 2 * Margin +
                Properties.Resources.happy.Width;
            int image_hgt = 2 * Margin +
                Properties.Resources.happy.Height;

            int wid = e.ToolTipSize.Width + 2 * Margin + image_wid;
            int hgt = e.ToolTipSize.Height;
            if (hgt < image_hgt) hgt = image_hgt;

            e.ToolTipSize = new Size(wid, hgt);
        }

        // Draw the tooltip.
        private void tipButtons_Draw(object sender, DrawToolTipEventArgs e)
        {
            // Draw the background and border.
            e.DrawBackground();
            e.DrawBorder();

            // Draw the image.
            e.Graphics.DrawImage(Properties.Resources.happy, Margin, Margin);

            // Draw the text.
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;

                int image_wid = 2 * Margin +
                    Properties.Resources.happy.Width;

                Rectangle rect = new Rectangle(
                    image_wid, 0,
                    e.Bounds.Width - image_wid, e.Bounds.Height);
                e.Graphics.DrawString(
                    e.ToolTipText, e.Font, Brushes.Green, rect, sf);
            }
        }

        private void btnClickMe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked!", "Clicked", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDontClick_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Just kidding!", "Kidding", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnWhatever_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Whatever...", "Whatever", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.tipButtons = new System.Windows.Forms.ToolTip(this.components);
            this.btnDontClick = new System.Windows.Forms.Button();
            this.btnClickMe = new System.Windows.Forms.Button();
            this.btnWhatever = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tipButtons
            // 
            this.tipButtons.OwnerDraw = true;
            this.tipButtons.Popup += new System.Windows.Forms.PopupEventHandler(this.tipButtons_Popup);
            this.tipButtons.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.tipButtons_Draw);
            // 
            // btnDontClick
            // 
            this.btnDontClick.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDontClick.Location = new System.Drawing.Point(130, 12);
            this.btnDontClick.Name = "btnDontClick";
            this.btnDontClick.Size = new System.Drawing.Size(75, 23);
            this.btnDontClick.TabIndex = 4;
            this.btnDontClick.Text = "Don\'t Click";
            this.tipButtons.SetToolTip(this.btnDontClick, "Don\'t click this button or you will suffer dire consequences! Trust me, you don\'t" +
                    " even want to know what the dire consequences are they\'re so bad. I mean really," +
                    " really, really bad. Really.");
            this.btnDontClick.UseVisualStyleBackColor = true;
            this.btnDontClick.Click += new System.EventHandler(this.btnDontClick_Click);
            // 
            // btnClickMe
            // 
            this.btnClickMe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClickMe.Location = new System.Drawing.Point(37, 12);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(75, 23);
            this.btnClickMe.TabIndex = 3;
            this.btnClickMe.Text = "Click Me";
            this.tipButtons.SetToolTip(this.btnClickMe, "You can safely click this button.");
            this.btnClickMe.UseVisualStyleBackColor = true;
            this.btnClickMe.Click += new System.EventHandler(this.btnClickMe_Click);
            // 
            // btnWhatever
            // 
            this.btnWhatever.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnWhatever.Location = new System.Drawing.Point(222, 12);
            this.btnWhatever.Name = "btnWhatever";
            this.btnWhatever.Size = new System.Drawing.Size(75, 23);
            this.btnWhatever.TabIndex = 5;
            this.btnWhatever.Text = "Whatever";
            this.btnWhatever.UseVisualStyleBackColor = true;
            this.btnWhatever.Click += new System.EventHandler(this.btnWhatever_Click);
            // 
            // howto_owner_drawn_tooltip_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.btnWhatever);
            this.Controls.Add(this.btnDontClick);
            this.Controls.Add(this.btnClickMe);
            this.Name = "howto_owner_drawn_tooltip_Form1";
            this.Text = "howto_owner_drawn_tooltip";
            this.Load += new System.EventHandler(this.howto_owner_drawn_tooltip_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolTip tipButtons;
        internal System.Windows.Forms.Button btnWhatever;
        internal System.Windows.Forms.Button btnDontClick;
        internal System.Windows.Forms.Button btnClickMe;
    }
}

