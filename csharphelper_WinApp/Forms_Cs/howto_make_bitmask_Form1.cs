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
     public partial class howto_make_bitmask_Form1:Form
  { 


        public howto_make_bitmask_Form1()
        {
            InitializeComponent();
        }

        private enum NormalEnum
        {
            Value1 = 1,
            Value2 = 2,
            Value3 = 4,
            Value4 = 8,
            Value5 = 16,
            Value3and5 = Value3 | Value5,
            OddValuesMask = Value1 | Value3 | Value5,
        }

        [Flags]
        private enum BitmaskEnum
        {
            Value1 = 1,
            Value2 = 2,
            Value3 = 4,
            Value4 = 8,
            Value5 = 16,
            Value3and5 = Value3 | Value5,
            OddValuesMask = Value1 | Value3 | Value5,
        }

        private void howto_make_bitmask_Form1_Load(object sender, EventArgs e)
        {
            NormalEnum normal_value = NormalEnum.Value1 | NormalEnum.Value2;
            BitmaskEnum bitmask_value = BitmaskEnum.Value1 | BitmaskEnum.Value2;

            txtValues.Text =
                NormalEnum.Value1 + " = " + (int)NormalEnum.Value1 + "\r\n" +
                NormalEnum.Value2 + " = " + (int)NormalEnum.Value2 + "\r\n" +
                NormalEnum.Value3 + " = " + (int)NormalEnum.Value3 + "\r\n" +
                NormalEnum.Value4 + " = " + (int)NormalEnum.Value4 + "\r\n" +
                NormalEnum.Value5 + " = " + (int)NormalEnum.Value5 + "\r\n" +
                NormalEnum.Value3and5 + " = " + (int)NormalEnum.Value3and5 + "\r\n" +
                "\r\n" +
                BitmaskEnum.Value1 + " = " + (int)BitmaskEnum.Value1 + "\r\n" +
                BitmaskEnum.Value2 + " = " + (int)BitmaskEnum.Value2 + "\r\n" +
                BitmaskEnum.Value3 + " = " + (int)BitmaskEnum.Value3 + "\r\n" +
                BitmaskEnum.Value4 + " = " + (int)BitmaskEnum.Value4 + "\r\n" +
                BitmaskEnum.Value5 + " = " + (int)BitmaskEnum.Value5 + "\r\n" +
                BitmaskEnum.Value3and5 + " = " + (int)BitmaskEnum.Value3and5 + "\r\n" +
                "\r\n" +
                "normal_enum = " + normal_value.ToString() + "\r\n" +
                "bitmask_enum = " + bitmask_value.ToString();
            txtValues.Select(0, 0);
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
            this.txtValues = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtValues
            // 
            this.txtValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValues.Location = new System.Drawing.Point(0, 0);
            this.txtValues.Multiline = true;
            this.txtValues.Name = "txtValues";
            this.txtValues.Size = new System.Drawing.Size(294, 221);
            this.txtValues.TabIndex = 1;
            // 
            // howto_make_bitmask_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 221);
            this.Controls.Add(this.txtValues);
            this.Name = "howto_make_bitmask_Form1";
            this.Text = "howto_make_bitmask";
            this.Load += new System.EventHandler(this.howto_make_bitmask_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValues;
    }
}

