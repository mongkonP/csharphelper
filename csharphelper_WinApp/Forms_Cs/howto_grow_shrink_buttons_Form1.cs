using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Media;

// Pop sound file by Mike Koenig, courtesy of SoundBible.com
//      http://soundbible.com/533-Pop-Cork.html

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_grow_shrink_buttons_Form1:Form
  { 


        public howto_grow_shrink_buttons_Form1()
        {
            InitializeComponent();
        }

        // The sound effect.
        private SoundPlayer PopPlayer =
            new SoundPlayer(Properties.Resources.Pop);

        // The small and large button sizes.
        private Size SmallSize, LargeSize;
        private Font SmallFont, LargeFont;

        // Set the small and large sizes.
        private void howto_grow_shrink_buttons_Form1_Load(object sender, EventArgs e)
        {
            SmallSize = btnOpen.Size;
            LargeSize = new Size(
                (int)(1.5 * btnOpen.Size.Width),
                (int)(1.5 * btnOpen.Size.Height));

            SmallFont = btnOpen.Font;
            LargeFont = new Font(
                SmallFont.FontFamily,
                SmallFont.Size * 1.5f,
                FontStyle.Bold);
        }

        // Enlarge the button.
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Size = LargeSize;
            btn.Font = LargeFont;

            // Play the pop sound.
            PopPlayer.Play();
        }

        // Shrink the button.
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Size = SmallSize;
            btn.Font = SmallFont;
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(3, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(60, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnOpen.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(69, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(60, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnNew.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(135, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnSave.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(201, 3);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(60, 23);
            this.btnSaveAs.TabIndex = 3;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnSaveAs.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnOpen);
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnSaveAs);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(324, 43);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // howto_grow_shrink_buttons_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 111);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "howto_grow_shrink_buttons_Form1";
            this.Text = "howto_grow_shrink_buttons";
            this.Load += new System.EventHandler(this.howto_grow_shrink_buttons_Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

