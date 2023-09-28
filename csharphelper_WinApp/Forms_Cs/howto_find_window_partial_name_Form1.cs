using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_find_window_partial_name;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_find_window_partial_name_Form1:Form
  { 


        public howto_find_window_partial_name_Form1()
        {
            InitializeComponent();
        }

        // Size and position the target window.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Find the target window.
            IntPtr handle;
            string title;
            DesktopWindowsStuff.FindWindowTitleMatch(
                txtAppTitle.Text, out handle, out title);
            if (handle == IntPtr.Zero)
            {
                MessageBox.Show("Not matching window",
                    "No Match", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            // Restore the window.
            DesktopWindowsStuff.SetWindowPlacement(handle,
                DesktopWindowsStuff.ShowWindowCommands.Restore);

            // Size and position the window.
            int width = int.Parse(txtWidth.Text);
            int height = int.Parse(txtHeight.Text);
            int x = int.Parse(txtX.Text);
            int y = int.Parse(txtY.Text);
            DesktopWindowsStuff.SetWindowPosition(
                handle, x, y, width, height);
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
            this.btnGo = new System.Windows.Forms.Button();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAppTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(297, 76);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 32;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(70, 115);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(71, 20);
            this.txtY.TabIndex = 31;
            this.txtY.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Y:";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(70, 89);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(71, 20);
            this.txtX.TabIndex = 29;
            this.txtX.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "X:";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(70, 63);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(71, 20);
            this.txtHeight.TabIndex = 27;
            this.txtHeight.Text = "400";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Height:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(70, 37);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(71, 20);
            this.txtWidth.TabIndex = 25;
            this.txtWidth.Text = "300";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Width:";
            // 
            // txtAppTitle
            // 
            this.txtAppTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppTitle.Location = new System.Drawing.Point(70, 11);
            this.txtAppTitle.Name = "txtAppTitle";
            this.txtAppTitle.Size = new System.Drawing.Size(302, 20);
            this.txtAppTitle.TabIndex = 23;
            this.txtAppTitle.Text = "WordPad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "App Title:";
            // 
            // howto_find_window_partial_name_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 146);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAppTitle);
            this.Controls.Add(this.label1);
            this.Name = "howto_find_window_partial_name_Form1";
            this.Text = "howto_find_window_partial_name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAppTitle;
        private System.Windows.Forms.Label label1;
    }
}

