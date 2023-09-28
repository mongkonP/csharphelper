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
     public partial class howto_modal_contextmenu_Form1:Form
  { 


        public howto_modal_contextmenu_Form1()
        {
            InitializeComponent();
        }

        // Display the "modal context menu."
        private void btnModalMenu_Click(object sender, EventArgs e)
        {
            // Create and initialize the dialog.
            howto_modal_contextmenu_ModalMenuForm dlg = new  howto_modal_contextmenu_ModalMenuForm();
            Point pt = new Point(btnModalMenu.Right, btnModalMenu.Bottom);
            PositionDialog(dlg, pt);

            // Display the dialog.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = dlg.SelectedColor;
            }
        }

        // Position the dialog over the indicated point in this form's coordinates.
        private void PositionDialog(Form dlg, Point location)
        {
            // Translate into screen coordinates.
            Point pt = this.PointToScreen(location);
            Screen screen = Screen.FromControl(dlg);

            // Adjust if this is at an edge of the screen.
            if (pt.X < screen.WorkingArea.X)
                pt.X = screen.WorkingArea.X;
            if (pt.Y < screen.WorkingArea.Y)
                pt.Y = screen.WorkingArea.Y;
            if (pt.X > screen.WorkingArea.Right - dlg.Width)
                pt.X = screen.WorkingArea.Right - dlg.Width;
            if (pt.Y > screen.WorkingArea.Bottom - dlg.Height)
                pt.Y = screen.WorkingArea.Bottom - dlg.Height;

            // Position the dialog.
            dlg.StartPosition = FormStartPosition.Manual;
            dlg.Location = pt;
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
            this.btnModalMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnModalMenu
            // 
            this.btnModalMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnModalMenu.Location = new System.Drawing.Point(130, 62);
            this.btnModalMenu.Name = "btnModalMenu";
            this.btnModalMenu.Size = new System.Drawing.Size(75, 23);
            this.btnModalMenu.TabIndex = 0;
            this.btnModalMenu.Text = "Modal Menu";
            this.btnModalMenu.UseVisualStyleBackColor = true;
            this.btnModalMenu.Click += new System.EventHandler(this.btnModalMenu_Click);
            // 
            // howto_modal_contextmenu_Form1
            // 
            this.AcceptButton = this.btnModalMenu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(334, 146);
            this.Controls.Add(this.btnModalMenu);
            this.Name = "howto_modal_contextmenu_Form1";
            this.Text = "howto_modal_contextmenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModalMenu;
    }
}

