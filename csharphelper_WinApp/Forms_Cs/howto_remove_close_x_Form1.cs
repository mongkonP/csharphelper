using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_remove_close_x_Form1:Form
  { 


        public howto_remove_close_x_Form1()
        {
            InitializeComponent();
        }

        // Declare User32 constants and methods.
        private const int MF_BYPOSITION = 0x400;

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);

        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        // Remove the X button.
        private void howto_remove_close_x_Form1_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int num_menu_items = GetMenuItemCount(hMenu);

            //for (int i = num_menu_items - 1; i >= 0; i--)
            //{
            //    RemoveMenu(hMenu, i, MF_BYPOSITION);
            //}
            RemoveMenu(hMenu, num_menu_items - 1, MF_BYPOSITION);
            RemoveMenu(hMenu, num_menu_items - 2, MF_BYPOSITION);
        }

        // Close.
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Location = new System.Drawing.Point(115, 74);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // howto_remove_close_x_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 171);
            this.Controls.Add(this.btnClose);
            this.Name = "howto_remove_close_x_Form1";
            this.Text = "howto_remove_close_x";
            this.Load += new System.EventHandler(this.howto_remove_close_x_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
    }
}

