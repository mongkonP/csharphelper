using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;
using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_time_long_switch_Form1:Form
  { 


        public howto_time_long_switch_Form1()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in Controls)
            {
                if ((ctl is TextBox) && (ctl != numTrialsTextBox))
                    ctl.Text = "";
            }
            Cursor = Cursors.WaitCursor;
            Refresh();

            int num_trials = int.Parse(numTrialsTextBox.Text, NumberStyles.Any);
            RunTrials(10, num_trials, txtIf10, txtSwitch10, txtDiff10);
            RunTrials(20, num_trials, txtIf20, txtSwitch20, txtDiff20);
            RunTrials(30, num_trials, txtIf30, txtSwitch30, txtDiff30);
            RunTrials(40, num_trials, txtIf40, txtSwitch40, txtDiff40);
            RunTrials(50, num_trials, txtIf50, txtSwitch50, txtDiff50);

            Cursor = Cursors.Default;
        }

        // Run trials with a given number of values.
        Stopwatch Watch = new Stopwatch();
        Random Rand = new Random();
        private void RunTrials(int num_values, int num_trials, TextBox txtIf, TextBox txtSwitch, TextBox txtDiff)
        {
            Stopwatch watch = new Stopwatch();

            // if-then-else.
            Watch.Reset();
            Watch.Start();
            for (int trial = 0; trial < num_trials; trial++)
            {
                int result = -1;
                int value = Rand.Next(0, num_values);
                if (value == 0) result = 0;
                else if (value == 1) result = 1;
                else if (value == 2) result = 2;
                else if (value == 3) result = 3;
                else if (value == 4) result = 4;
                else if (value == 5) result = 5;
                else if (value == 6) result = 6;
                else if (value == 7) result = 7;
                else if (value == 8) result = 8;
                else if (value == 9) result = 9;
                else if (value == 10) result = 10;
                else if (value == 11) result = 11;
                else if (value == 12) result = 12;
                else if (value == 13) result = 13;
                else if (value == 14) result = 14;
                else if (value == 15) result = 15;
                else if (value == 16) result = 16;
                else if (value == 17) result = 17;
                else if (value == 18) result = 18;
                else if (value == 19) result = 19;
                else if (value == 20) result = 20;
                else if (value == 21) result = 21;
                else if (value == 22) result = 22;
                else if (value == 23) result = 23;
                else if (value == 24) result = 24;
                else if (value == 25) result = 25;
                else if (value == 26) result = 26;
                else if (value == 27) result = 27;
                else if (value == 28) result = 28;
                else if (value == 29) result = 29;
                else if (value == 30) result = 30;
                else if (value == 31) result = 31;
                else if (value == 32) result = 32;
                else if (value == 33) result = 33;
                else if (value == 34) result = 34;
                else if (value == 35) result = 35;
                else if (value == 36) result = 36;
                else if (value == 37) result = 37;
                else if (value == 38) result = 38;
                else if (value == 39) result = 39;
                else if (value == 40) result = 40;
                else if (value == 41) result = 41;
                else if (value == 42) result = 42;
                else if (value == 43) result = 43;
                else if (value == 44) result = 44;
                else if (value == 45) result = 45;
                else if (value == 46) result = 46;
                else if (value == 47) result = 47;
                else if (value == 48) result = 48;
                else if (value == 49) result = 49;
                value = result;
            }
            Watch.Stop();
            double if_seconds = Watch.Elapsed.TotalSeconds;
            txtIf.Text = if_seconds.ToString("0.0000");
            txtIf.Refresh();

            // if-then-else.
            Watch.Reset();
            Watch.Start();
            for (int trial = 0; trial < num_trials; trial++)
            {
                int result = -1;
                int value = Rand.Next(0, num_values);
                switch (value)
                {
                    case 0: result = 0; break;
                    case 1: result = 1; break;
                    case 2: result = 2; break;
                    case 3: result = 3; break;
                    case 4: result = 4; break;
                    case 5: result = 5; break;
                    case 6: result = 6; break;
                    case 7: result = 7; break;
                    case 8: result = 8; break;
                    case 9: result = 9; break;
                    case 10: result = 10; break;
                    case 11: result = 11; break;
                    case 12: result = 12; break;
                    case 13: result = 13; break;
                    case 14: result = 14; break;
                    case 15: result = 15; break;
                    case 16: result = 16; break;
                    case 17: result = 17; break;
                    case 18: result = 18; break;
                    case 19: result = 19; break;
                    case 20: result = 20; break;
                    case 21: result = 21; break;
                    case 22: result = 22; break;
                    case 23: result = 23; break;
                    case 24: result = 24; break;
                    case 25: result = 25; break;
                    case 26: result = 26; break;
                    case 27: result = 27; break;
                    case 28: result = 28; break;
                    case 29: result = 29; break;
                    case 30: result = 30; break;
                    case 31: result = 31; break;
                    case 32: result = 32; break;
                    case 33: result = 33; break;
                    case 34: result = 34; break;
                    case 35: result = 35; break;
                    case 36: result = 36; break;
                    case 37: result = 37; break;
                    case 38: result = 38; break;
                    case 39: result = 39; break;
                    case 40: result = 40; break;
                    case 41: result = 41; break;
                    case 42: result = 42; break;
                    case 43: result = 43; break;
                    case 44: result = 44; break;
                    case 45: result = 45; break;
                    case 46: result = 46; break;
                    case 47: result = 47; break;
                    case 48: result = 48; break;
                    case 49: result = 49; break;
                }
                value = result;
            }
            Watch.Stop();
            double switch_seconds = Watch.Elapsed.TotalSeconds;
            txtSwitch.Text = switch_seconds.ToString("0.0000");
            txtSwitch.Refresh();

            double diff = 100.0 * (if_seconds - switch_seconds) / if_seconds;
            txtDiff.Text = diff.ToString("0.0000");
            txtDiff.Refresh();
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
            this.label1 = new System.Windows.Forms.Label();
            this.numTrialsTextBox = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.txtIf10 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSwitch10 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSwitch20 = new System.Windows.Forms.TextBox();
            this.txtIf20 = new System.Windows.Forms.TextBox();
            this.txtSwitch30 = new System.Windows.Forms.TextBox();
            this.txtIf30 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiff30 = new System.Windows.Forms.TextBox();
            this.txtDiff20 = new System.Windows.Forms.TextBox();
            this.txtDiff10 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiff50 = new System.Windows.Forms.TextBox();
            this.txtDiff40 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSwitch50 = new System.Windows.Forms.TextBox();
            this.txtIf50 = new System.Windows.Forms.TextBox();
            this.txtSwitch40 = new System.Windows.Forms.TextBox();
            this.txtIf40 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Trials:";
            // 
            // numTrialsTextBox
            // 
            this.numTrialsTextBox.Location = new System.Drawing.Point(76, 14);
            this.numTrialsTextBox.Name = "numTrialsTextBox";
            this.numTrialsTextBox.Size = new System.Drawing.Size(100, 20);
            this.numTrialsTextBox.TabIndex = 1;
            this.numTrialsTextBox.Text = "10,000,000";
            this.numTrialsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(182, 12);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // txtIf10
            // 
            this.txtIf10.Location = new System.Drawing.Point(76, 69);
            this.txtIf10.Name = "txtIf10";
            this.txtIf10.ReadOnly = true;
            this.txtIf10.Size = new System.Drawing.Size(100, 20);
            this.txtIf10.TabIndex = 4;
            this.txtIf10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "if-else:";
            // 
            // txtSwitch10
            // 
            this.txtSwitch10.Location = new System.Drawing.Point(76, 95);
            this.txtSwitch10.Name = "txtSwitch10";
            this.txtSwitch10.ReadOnly = true;
            this.txtSwitch10.Size = new System.Drawing.Size(100, 20);
            this.txtSwitch10.TabIndex = 6;
            this.txtSwitch10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "switch:";
            // 
            // txtSwitch20
            // 
            this.txtSwitch20.Location = new System.Drawing.Point(182, 95);
            this.txtSwitch20.Name = "txtSwitch20";
            this.txtSwitch20.ReadOnly = true;
            this.txtSwitch20.Size = new System.Drawing.Size(100, 20);
            this.txtSwitch20.TabIndex = 8;
            this.txtSwitch20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIf20
            // 
            this.txtIf20.Location = new System.Drawing.Point(182, 69);
            this.txtIf20.Name = "txtIf20";
            this.txtIf20.ReadOnly = true;
            this.txtIf20.Size = new System.Drawing.Size(100, 20);
            this.txtIf20.TabIndex = 7;
            this.txtIf20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSwitch30
            // 
            this.txtSwitch30.Location = new System.Drawing.Point(288, 95);
            this.txtSwitch30.Name = "txtSwitch30";
            this.txtSwitch30.ReadOnly = true;
            this.txtSwitch30.Size = new System.Drawing.Size(100, 20);
            this.txtSwitch30.TabIndex = 10;
            this.txtSwitch30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIf30
            // 
            this.txtIf30.Location = new System.Drawing.Point(288, 69);
            this.txtIf30.Name = "txtIf30";
            this.txtIf30.ReadOnly = true;
            this.txtIf30.Size = new System.Drawing.Size(100, 20);
            this.txtIf30.TabIndex = 9;
            this.txtIf30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(76, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "10 Values";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(182, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "20 Values";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(288, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "30 Values";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDiff30
            // 
            this.txtDiff30.Location = new System.Drawing.Point(288, 121);
            this.txtDiff30.Name = "txtDiff30";
            this.txtDiff30.ReadOnly = true;
            this.txtDiff30.Size = new System.Drawing.Size(100, 20);
            this.txtDiff30.TabIndex = 17;
            this.txtDiff30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiff20
            // 
            this.txtDiff20.Location = new System.Drawing.Point(182, 121);
            this.txtDiff20.Name = "txtDiff20";
            this.txtDiff20.ReadOnly = true;
            this.txtDiff20.Size = new System.Drawing.Size(100, 20);
            this.txtDiff20.TabIndex = 16;
            this.txtDiff20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiff10
            // 
            this.txtDiff10.Location = new System.Drawing.Point(76, 121);
            this.txtDiff10.Name = "txtDiff10";
            this.txtDiff10.ReadOnly = true;
            this.txtDiff10.Size = new System.Drawing.Size(100, 20);
            this.txtDiff10.TabIndex = 15;
            this.txtDiff10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "% Diff:";
            // 
            // txtDiff50
            // 
            this.txtDiff50.Location = new System.Drawing.Point(500, 121);
            this.txtDiff50.Name = "txtDiff50";
            this.txtDiff50.ReadOnly = true;
            this.txtDiff50.Size = new System.Drawing.Size(100, 20);
            this.txtDiff50.TabIndex = 25;
            this.txtDiff50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiff40
            // 
            this.txtDiff40.Location = new System.Drawing.Point(394, 121);
            this.txtDiff40.Name = "txtDiff40";
            this.txtDiff40.ReadOnly = true;
            this.txtDiff40.Size = new System.Drawing.Size(100, 20);
            this.txtDiff40.TabIndex = 24;
            this.txtDiff40.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(500, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "50 Values";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(394, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "40 Values";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSwitch50
            // 
            this.txtSwitch50.Location = new System.Drawing.Point(500, 95);
            this.txtSwitch50.Name = "txtSwitch50";
            this.txtSwitch50.ReadOnly = true;
            this.txtSwitch50.Size = new System.Drawing.Size(100, 20);
            this.txtSwitch50.TabIndex = 21;
            this.txtSwitch50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIf50
            // 
            this.txtIf50.Location = new System.Drawing.Point(500, 69);
            this.txtIf50.Name = "txtIf50";
            this.txtIf50.ReadOnly = true;
            this.txtIf50.Size = new System.Drawing.Size(100, 20);
            this.txtIf50.TabIndex = 20;
            this.txtIf50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSwitch40
            // 
            this.txtSwitch40.Location = new System.Drawing.Point(394, 95);
            this.txtSwitch40.Name = "txtSwitch40";
            this.txtSwitch40.ReadOnly = true;
            this.txtSwitch40.Size = new System.Drawing.Size(100, 20);
            this.txtSwitch40.TabIndex = 19;
            this.txtSwitch40.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIf40
            // 
            this.txtIf40.Location = new System.Drawing.Point(394, 69);
            this.txtIf40.Name = "txtIf40";
            this.txtIf40.ReadOnly = true;
            this.txtIf40.Size = new System.Drawing.Size(100, 20);
            this.txtIf40.TabIndex = 18;
            this.txtIf40.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_time_long_switch_Form1
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 154);
            this.Controls.Add(this.txtDiff50);
            this.Controls.Add(this.txtDiff40);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSwitch50);
            this.Controls.Add(this.txtIf50);
            this.Controls.Add(this.txtSwitch40);
            this.Controls.Add(this.txtIf40);
            this.Controls.Add(this.txtDiff30);
            this.Controls.Add(this.txtDiff20);
            this.Controls.Add(this.txtDiff10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSwitch30);
            this.Controls.Add(this.txtIf30);
            this.Controls.Add(this.txtSwitch20);
            this.Controls.Add(this.txtIf20);
            this.Controls.Add(this.txtSwitch10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIf10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.numTrialsTextBox);
            this.Controls.Add(this.label1);
            this.Name = "howto_time_long_switch_Form1";
            this.Text = "howto_time_long_switch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numTrialsTextBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox txtIf10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSwitch10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSwitch20;
        private System.Windows.Forms.TextBox txtIf20;
        private System.Windows.Forms.TextBox txtSwitch30;
        private System.Windows.Forms.TextBox txtIf30;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiff30;
        private System.Windows.Forms.TextBox txtDiff20;
        private System.Windows.Forms.TextBox txtDiff10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiff50;
        private System.Windows.Forms.TextBox txtDiff40;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSwitch50;
        private System.Windows.Forms.TextBox txtIf50;
        private System.Windows.Forms.TextBox txtSwitch40;
        private System.Windows.Forms.TextBox txtIf40;
    }
}

