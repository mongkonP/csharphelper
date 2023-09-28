using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

using howto_nonzero_lower_bounds_class;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_nonzero_lower_bounds_class_Form1:Form
  { 


        public howto_nonzero_lower_bounds_class_Form1()
        {
            InitializeComponent();
        }

        private void howto_nonzero_lower_bounds_class_Form1_Load(object sender, EventArgs e)
        {
            // Make a three-dimensional array data[11..12, 21..23, 31..35].
            BoundsArray<int> data = new BoundsArray<int>(11, 12, 21, 23, 31, 35);

            // Make some data.
            for (int d = 11; d <= 12; d++)
            {
                for (int r = 21; r <= 23; r++)
                {
                    for (int c = 31; c <= 35; c++)
                    {
                        data[d, r, c] = d * 10000 + r * 100 + c;
                    }
                }
            }

            // Get the data back.
            string txt = "";
            for (int d = 11; d <= 12; d++)
            {
                for (int r = 21; r <= 23; r++)
                {
                    for (int c = 31; c <= 35; c++)
                    {
                        // Display the value.
                        txt += string.Format("{0,-2}{1,-2}{2,-2}: {3,-6}\r\n",
                            d, r, c, data[d, r, c]);

                        // Check the value.
                        Debug.Assert(data[d, r, c] == d * 10000 + r * 100 + c);
                    }
                }
            }
            txtData.Text = txt;
            txtData.Select(0, 0);
        }

        // Compare the BoundsArray and Array classes.
        private void btnGo_Click(object sender, EventArgs e)
        {
            int num_trials = int.Parse(txtNumTrials.Text);
            DateTime start_time, stop_time;
            TimeSpan elapsed;
            lblArray.Text = "";
            lblBoundsArray.Text = "";
            lblPlain.Text = "";
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // Array size constants.
            const int xmin = 1001, num_x = 50, xmax = xmin + num_x - 1;
            const int ymin = 2001, num_y = 50, ymax = ymin + num_y - 1;
            const int zmin = 2001, num_z = 50, zmax = zmin + num_z - 1;

            // Use the Array class.
            Array array_class = Array.CreateInstance(
                typeof(int),
                new int[] { num_x, num_y, num_z },
                new int[] { xmin, ymin, zmin });
            start_time = DateTime.Now;
            for (int trial = 0; trial < num_trials; trial++)
            {
                for (int x = xmin; x <= xmax; x++)
                {
                    for (int y = ymin; y <= ymax; y++)
                    {
                        for (int z = zmin; z <= zmax; z++)
                        {
                            int value = x + y + z;
                            array_class.SetValue(value, x, y, z);
                            value = (int)array_class.GetValue(x, y, z);
                        }
                    }
                }
            }
            stop_time = DateTime.Now;
            elapsed = stop_time - start_time;
            lblArray.Text = elapsed.TotalSeconds.ToString("0.00") + " seconds";
            lblArray.Refresh();

            // Use the BoundsArray class.
            BoundsArray<int> bounds_array = 
                new BoundsArray<int>(xmin, xmax, ymin, ymax, zmin, zmax);
            start_time = DateTime.Now;
            for (int trial = 0; trial < num_trials; trial++)
            {
                for (int x = xmin; x <= xmax; x++)
                {
                    for (int y = ymin; y <= ymax; y++)
                    {
                        for (int z = zmin; z <= zmax; z++)
                        {
                            int value = x + y + z;
                            bounds_array[x, y, z] = value;
                            value = bounds_array[x, y, z];
                        }
                    }
                }
            }
            stop_time = DateTime.Now;
            elapsed = stop_time - start_time;
            lblBoundsArray.Text = elapsed.TotalSeconds.ToString("0.00") + " seconds";
            lblBoundsArray.Refresh();

            // Plain array.
            int[, ,] plain_array = new int[num_x, num_y, num_z];
            start_time = DateTime.Now;
            for (int trial = 0; trial < num_trials; trial++)
            {
                for (int x = 0; x < num_x; x++)
                {
                    for (int y = 0; y < num_y; y++)
                    {
                        for (int z = 0; z < num_z; z++)
                        {
                            int value = x + y + z;
                            plain_array[x, y, z] = value;
                            value = plain_array[x, y, z];
                        }
                    }
                }
            }
            stop_time = DateTime.Now;
            elapsed = stop_time - start_time;
            lblPlain.Text = elapsed.TotalSeconds.ToString("0.00") + " seconds";
            lblPlain.Refresh();

            this.Cursor = Cursors.Default;
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
            this.txtData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblArray = new System.Windows.Forms.Label();
            this.lblBoundsArray = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPlain = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Location = new System.Drawing.Point(12, 12);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtData.Size = new System.Drawing.Size(346, 164);
            this.txtData.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "# Trials:";
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNumTrials.Location = new System.Drawing.Point(63, 184);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(53, 20);
            this.txtNumTrials.TabIndex = 0;
            this.txtNumTrials.Text = "100";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGo.Location = new System.Drawing.Point(141, 182);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Array Class:";
            // 
            // lblArray
            // 
            this.lblArray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblArray.AutoSize = true;
            this.lblArray.Location = new System.Drawing.Point(116, 232);
            this.lblArray.Name = "lblArray";
            this.lblArray.Size = new System.Drawing.Size(0, 13);
            this.lblArray.TabIndex = 5;
            // 
            // lblBoundsArray
            // 
            this.lblBoundsArray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBoundsArray.AutoSize = true;
            this.lblBoundsArray.Location = new System.Drawing.Point(116, 258);
            this.lblBoundsArray.Name = "lblBoundsArray";
            this.lblBoundsArray.Size = new System.Drawing.Size(0, 13);
            this.lblBoundsArray.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "BoundsArray Class:";
            // 
            // lblPlain
            // 
            this.lblPlain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlain.AutoSize = true;
            this.lblPlain.Location = new System.Drawing.Point(116, 284);
            this.lblPlain.Name = "lblPlain";
            this.lblPlain.Size = new System.Drawing.Size(0, 13);
            this.lblPlain.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Plain Array:";
            // 
            // howto_nonzero_lower_bounds_class_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 313);
            this.Controls.Add(this.lblPlain);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblBoundsArray);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblArray);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtData);
            this.Name = "howto_nonzero_lower_bounds_class_Form1";
            this.Text = "howto_nonzero_lower_bounds_class";
            this.Load += new System.EventHandler(this.howto_nonzero_lower_bounds_class_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblArray;
        private System.Windows.Forms.Label lblBoundsArray;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPlain;
        private System.Windows.Forms.Label label5;
    }
}

