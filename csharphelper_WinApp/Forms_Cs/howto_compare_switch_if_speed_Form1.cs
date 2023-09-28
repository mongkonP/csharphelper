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
     public partial class howto_compare_switch_if_speed_Form1:Form
  { 


        public howto_compare_switch_if_speed_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get ready.
            txtIfThen.Clear();
            txtSwitch.Clear();
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            int iterations = int.Parse(txtIterations.Text);
            DateTime start_time;
            TimeSpan elapsed;

            // If then.
            start_time = DateTime.Now;
            for (int i = 1; i <= iterations; i++)
            {
                for (int num = 0; num < 50; num++)
                {
                    int value;
                    if (num == 0) { value = num; }
                    else if (num == 1) { value = num; }
                    else if (num == 2) { value = num; }
                    else if (num == 3) { value = num; }
                    else if (num == 4) { value = num; }
                    else if (num == 5) { value = num; }
                    else if (num == 6) { value = num; }
                    else if (num == 7) { value = num; }
                    else if (num == 8) { value = num; }
                    else if (num == 9) { value = num; }
                    else if (num == 10) { value = num; }
                    else if (num == 11) { value = num; }
                    else if (num == 12) { value = num; }
                    else if (num == 13) { value = num; }
                    else if (num == 14) { value = num; }
                    else if (num == 15) { value = num; }
                    else if (num == 16) { value = num; }
                    else if (num == 17) { value = num; }
                    else if (num == 18) { value = num; }
                    else if (num == 19) { value = num; }
                    else if (num == 20) { value = num; }
                    else if (num == 21) { value = num; }
                    else if (num == 22) { value = num; }
                    else if (num == 23) { value = num; }
                    else if (num == 24) { value = num; }
                    else if (num == 25) { value = num; }
                    else if (num == 26) { value = num; }
                    else if (num == 27) { value = num; }
                    else if (num == 28) { value = num; }
                    else if (num == 29) { value = num; }
                    else if (num == 30) { value = num; }
                    else if (num == 31) { value = num; }
                    else if (num == 32) { value = num; }
                    else if (num == 33) { value = num; }
                    else if (num == 34) { value = num; }
                    else if (num == 35) { value = num; }
                    else if (num == 36) { value = num; }
                    else if (num == 37) { value = num; }
                    else if (num == 38) { value = num; }
                    else if (num == 39) { value = num; }
                    else if (num == 40) { value = num; }
                    else if (num == 41) { value = num; }
                    else if (num == 42) { value = num; }
                    else if (num == 43) { value = num; }
                    else if (num == 44) { value = num; }
                    else if (num == 45) { value = num; }
                    else if (num == 46) { value = num; }
                    else if (num == 47) { value = num; }
                    else if (num == 48) { value = num; }
                    else if (num == 49) { value = num; }
                    else { value = num; }
                    if (value > 1000) Console.WriteLine(value);
                }
            }
            elapsed = DateTime.Now - start_time;
            txtIfThen.Text = elapsed.TotalSeconds.ToString() + " sec";
            txtIfThen.Refresh();

            // Switch.
            start_time = DateTime.Now;
            for (int i = 1; i <= iterations; i++)
            {
                for (int num = 0; num < 50; num++)
                {
                    int value;
                    switch (num)
                    {
                        case 0:
                            value = num; break;
                        case 1:
                            value = num; break;
                        case 2:
                            value = num; break;
                        case 3:
                            value = num; break;
                        case 4:
                            value = num; break;
                        case 5:
                            value = num; break;
                        case 6:
                            value = num; break;
                        case 7:
                            value = num; break;
                        case 8:
                            value = num; break;
                        case 9:
                            value = num; break;
                        case 10:
                            value = num; break;
                        case 11:
                            value = num; break;
                        case 12:
                            value = num; break;
                        case 13:
                            value = num; break;
                        case 14:
                            value = num; break;
                        case 15:
                            value = num; break;
                        case 16:
                            value = num; break;
                        case 17:
                            value = num; break;
                        case 18:
                            value = num; break;
                        case 19:
                            value = num; break;
                        case 20:
                            value = num; break;
                        case 21:
                            value = num; break;
                        case 22:
                            value = num; break;
                        case 23:
                            value = num; break;
                        case 24:
                            value = num; break;
                        case 25:
                            value = num; break;
                        case 26:
                            value = num; break;
                        case 27:
                            value = num; break;
                        case 28:
                            value = num; break;
                        case 29:
                            value = num; break;
                        case 30:
                            value = num; break;
                        case 31:
                            value = num; break;
                        case 32:
                            value = num; break;
                        case 33:
                            value = num; break;
                        case 34:
                            value = num; break;
                        case 35:
                            value = num; break;
                        case 36:
                            value = num; break;
                        case 37:
                            value = num; break;
                        case 38:
                            value = num; break;
                        case 39:
                            value = num; break;
                        case 40:
                            value = num; break;
                        case 41:
                            value = num; break;
                        case 42:
                            value = num; break;
                        case 43:
                            value = num; break;
                        case 44:
                            value = num; break;
                        case 45:
                            value = num; break;
                        case 46:
                            value = num; break;
                        case 47:
                            value = num; break;
                        case 48:
                            value = num; break;
                        case 49:
                            value = num; break;
                        default:
                            value = num; break;
                    }
                    if (value > 1000) Console.WriteLine(value);
                }
            }
            elapsed = DateTime.Now - start_time;
            txtSwitch.Text = elapsed.TotalSeconds.ToString() + " sec";
            txtSwitch.Refresh();

            Cursor = Cursors.Default;
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
            this.txtSwitch = new System.Windows.Forms.TextBox();
            this.txtIfThen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtIterations = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSwitch
            // 
            this.txtSwitch.Location = new System.Drawing.Point(120, 92);
            this.txtSwitch.Name = "txtSwitch";
            this.txtSwitch.ReadOnly = true;
            this.txtSwitch.Size = new System.Drawing.Size(59, 20);
            this.txtSwitch.TabIndex = 13;
            this.txtSwitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIfThen
            // 
            this.txtIfThen.Location = new System.Drawing.Point(120, 66);
            this.txtIfThen.Name = "txtIfThen";
            this.txtIfThen.ReadOnly = true;
            this.txtIfThen.Size = new System.Drawing.Size(59, 20);
            this.txtIfThen.TabIndex = 12;
            this.txtIfThen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "switch:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "if then:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(220, 10);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 9;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtIterations
            // 
            this.txtIterations.Location = new System.Drawing.Point(120, 12);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new System.Drawing.Size(59, 20);
            this.txtIterations.TabIndex = 8;
            this.txtIterations.Text = "1000000";
            this.txtIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Iterations:";
            // 
            // howto_compare_switch_if_speed_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 123);
            this.Controls.Add(this.txtSwitch);
            this.Controls.Add(this.txtIfThen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtIterations);
            this.Controls.Add(this.label1);
            this.Name = "howto_compare_switch_if_speed_Form1";
            this.Text = "howto_compare_switch_if_speed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSwitch;
        private System.Windows.Forms.TextBox txtIfThen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtIterations;
        private System.Windows.Forms.Label label1;
    }
}

