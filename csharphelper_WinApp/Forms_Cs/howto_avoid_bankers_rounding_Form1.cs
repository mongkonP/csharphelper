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
     public partial class howto_avoid_bankers_rounding_Form1:Form
  { 


        public howto_avoid_bankers_rounding_Form1()
        {
            InitializeComponent();
        }

        // Display some values.
        private void howto_avoid_bankers_rounding_Form1_Load(object sender, EventArgs e)
        {
            double[] values = { -0.5, -1.5, -2.5, -3.5, -4.5, 0.5, 1.5, 2.5, 3.5, 4.5, 1.05, 1.15, 1.25, 1.35, 1.45 };
            int[] digits = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 };
            for (int i = 0; i < values.Length; i++)
            {
                ListViewItem item = lvwNumbers.Items.Add(values[i].ToString());
                item.SubItems.Add(Math.Round(values[i], digits[i]).ToString());
                item.SubItems.Add(Math.Round(values[i], digits[i],
                    MidpointRounding.AwayFromZero).ToString());
            }
            lvwNumbers.Columns[0].Width = -2;
            lvwNumbers.Columns[1].Width = -2;
            lvwNumbers.Columns[2].Width = -2;
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
            this.lvwNumbers = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwNumbers
            // 
            this.lvwNumbers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwNumbers.Location = new System.Drawing.Point(0, 0);
            this.lvwNumbers.Name = "lvwNumbers";
            this.lvwNumbers.Size = new System.Drawing.Size(284, 287);
            this.lvwNumbers.TabIndex = 1;
            this.lvwNumbers.UseCompatibleStateImageBehavior = false;
            this.lvwNumbers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Number";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Round to Even";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Away from 0";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            // 
            // howto_avoid_bankers_rounding_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 287);
            this.Controls.Add(this.lvwNumbers);
            this.Name = "howto_avoid_bankers_rounding_Form1";
            this.Text = "howto_avoid_bankers_rounding";
            this.Load += new System.EventHandler(this.howto_avoid_bankers_rounding_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwNumbers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}

