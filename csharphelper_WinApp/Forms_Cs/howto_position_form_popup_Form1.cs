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
     public partial class howto_position_form_popup_Form1:Form
  { 


        public howto_position_form_popup_Form1()
        {
            InitializeComponent();
        }

        // Position a new instance of this form
        // just to the right and below the button.
        private void btnShowForm_Click(object sender, EventArgs e)
        {
            // Get the location in this form's coordinate system.
            Point form_pt = new Point(
                btnShowForm.Left + btnShowForm.Width / 2,
                btnShowForm.Top + btnShowForm.Height / 2);

            // Translate into the screen coordinate system.
            Point screen_pt = this.PointToScreen(form_pt);

            // Create the new form.
            howto_position_form_popup_Form1 frm = new howto_position_form_popup_Form1();

            // Make sure the form will be completely on the screen.
            Screen screen = Screen.FromControl(this);
            if (screen_pt.X < 0) screen_pt.X = 0;
            if (screen_pt.Y < 0) screen_pt.Y = 0;
            if (screen_pt.X > screen.WorkingArea.Right - frm.Width)
                screen_pt.X = screen.WorkingArea.Right - frm.Width;
            if (screen_pt.Y > screen.WorkingArea.Bottom - frm.Height)
                screen_pt.Y = screen.WorkingArea.Bottom - frm.Height;

            // Position the new form.
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = screen_pt;
            frm.Show();
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
            this.btnShowForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowForm
            // 
            this.btnShowForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShowForm.Location = new System.Drawing.Point(130, 44);
            this.btnShowForm.Name = "btnShowForm";
            this.btnShowForm.Size = new System.Drawing.Size(75, 23);
            this.btnShowForm.TabIndex = 1;
            this.btnShowForm.Text = "Show Form";
            this.btnShowForm.UseVisualStyleBackColor = true;
            this.btnShowForm.Click += new System.EventHandler(this.btnShowForm_Click);
            // 
            // howto_position_form_popup_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.btnShowForm);
            this.Name = "howto_position_form_popup_Form1";
            this.Text = "howto_position_form_popup";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowForm;
    }
}

