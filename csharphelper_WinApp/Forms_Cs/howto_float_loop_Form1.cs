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
     public partial class howto_float_loop_Form1:Form
  { 


        public howto_float_loop_Form1()
        {
            InitializeComponent();
        }

        private void howto_float_loop_Form1_Load(object sender, EventArgs e)
        {
            // Control the loop using a float.
            for (float f = 0; f <= 1f; f += 0.1f)
            {
                lstFloatLoop.Items.Add(f);
            }

            // Control the loop using an int and a float.
            float value = 0f;
            for (int i = 0; i < 11; i++)
            {
                lstIntLoop.Items.Add(value);
                value += 0.1f;
            }

            // Control the loop using an int and a double.
            double dvalue = 0.0;
            for (int i = 0; i < 11; i++)
            {
                lstDoubleLoop.Items.Add(dvalue);
                dvalue += 0.1;
            }

            // Control the loop using an int, calculating the values.
            for (int i = 0; i < 11; i++)
            {
                lstIntLoop2.Items.Add(i * 0.1);
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
            this.lstFloatLoop = new System.Windows.Forms.ListBox();
            this.lstIntLoop = new System.Windows.Forms.ListBox();
            this.lstIntLoop2 = new System.Windows.Forms.ListBox();
            this.lstDoubleLoop = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFloatLoop
            // 
            this.lstFloatLoop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFloatLoop.FormattingEnabled = true;
            this.lstFloatLoop.IntegralHeight = false;
            this.lstFloatLoop.Location = new System.Drawing.Point(3, 23);
            this.lstFloatLoop.Name = "lstFloatLoop";
            this.lstFloatLoop.Size = new System.Drawing.Size(121, 159);
            this.lstFloatLoop.TabIndex = 0;
            // 
            // lstIntLoop
            // 
            this.lstIntLoop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstIntLoop.FormattingEnabled = true;
            this.lstIntLoop.IntegralHeight = false;
            this.lstIntLoop.Location = new System.Drawing.Point(130, 23);
            this.lstIntLoop.Name = "lstIntLoop";
            this.lstIntLoop.Size = new System.Drawing.Size(121, 159);
            this.lstIntLoop.TabIndex = 1;
            // 
            // lstIntLoop2
            // 
            this.lstIntLoop2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstIntLoop2.FormattingEnabled = true;
            this.lstIntLoop2.IntegralHeight = false;
            this.lstIntLoop2.Location = new System.Drawing.Point(384, 23);
            this.lstIntLoop2.Name = "lstIntLoop2";
            this.lstIntLoop2.Size = new System.Drawing.Size(122, 159);
            this.lstIntLoop2.TabIndex = 2;
            // 
            // lstDoubleLoop
            // 
            this.lstDoubleLoop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDoubleLoop.FormattingEnabled = true;
            this.lstDoubleLoop.IntegralHeight = false;
            this.lstDoubleLoop.Location = new System.Drawing.Point(257, 23);
            this.lstDoubleLoop.Name = "lstDoubleLoop";
            this.lstDoubleLoop.Size = new System.Drawing.Size(121, 159);
            this.lstDoubleLoop.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "float";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(130, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "int/float";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(257, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "int/double";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(384, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "int/calculate";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lstFloatLoop, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstIntLoop2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstIntLoop, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstDoubleLoop, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 185);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // howto_float_loop_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 209);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_float_loop_Form1";
            this.Text = "howto_float_loop";
            this.Load += new System.EventHandler(this.howto_float_loop_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstFloatLoop;
        private System.Windows.Forms.ListBox lstIntLoop;
        private System.Windows.Forms.ListBox lstIntLoop2;
        private System.Windows.Forms.ListBox lstDoubleLoop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

