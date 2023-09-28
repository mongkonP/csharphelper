using System;
using System.Windows.Forms;

using System.Globalization;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_first_day_of_week_name_Form1:Form
  { 


        public howto_get_first_day_of_week_name_Form1()
        {
            InitializeComponent();
        }

        private void howto_get_first_day_of_week_name_Form1_Load(object sender, EventArgs e)
        {
            lblResult.Text = "The first day of the week is " +
                CultureInfo.CurrentCulture.DateTimeFormat.DayNames[0];
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
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(0, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(384, 61);
            this.lblResult.TabIndex = 1;
            this.lblResult.Text = "The first day of the week is";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_get_first_day_of_week_name_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 61);
            this.Controls.Add(this.lblResult);
            this.Name = "howto_get_first_day_of_week_name_Form1";
            this.Text = "howto_get_first_day_of_week_name";
            this.Load += new System.EventHandler(this.howto_get_first_day_of_week_name_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
    }
}

