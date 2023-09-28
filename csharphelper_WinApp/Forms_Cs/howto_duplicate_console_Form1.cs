using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Based on the excellent reply by Servy at:
// https://stackoverflow.com/questions/18726852/redirecting-console-writeline-to-textbox

 

using howto_duplicate_console;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_duplicate_console_Form1:Form
  { 


        public howto_duplicate_console_Form1()
        {
            InitializeComponent();
        }

        // Install a new output TextWriter and the
        // Console window's default output writer.
        private void howto_duplicate_console_Form1_Load(object sender, EventArgs e)
        {            
            ListTextWriter list_writer = new ListTextWriter();
            list_writer.Add(new TextBoxWriter(txtConsole));
            list_writer.Add(new TextBoxWriter(lblConsole));
            list_writer.Add(Console.Out);

            Console.SetOut(list_writer);
        }

        // Write to the Console window.
        private void btnWrite_Click(object sender, EventArgs e)
        {
            Console.WriteLine(txtOutput.Text);
            txtOutput.Clear();
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
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblConsole = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtConsole.Location = new System.Drawing.Point(12, 67);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(146, 82);
            this.txtConsole.TabIndex = 7;
            this.txtConsole.WordWrap = false;
            // 
            // btnWrite
            // 
            this.btnWrite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnWrite.Location = new System.Drawing.Point(115, 38);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 6;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(60, 12);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(232, 20);
            this.txtOutput.TabIndex = 5;
            this.txtOutput.Text = "This is a test.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Output:";
            // 
            // lblConsole
            // 
            this.lblConsole.AutoSize = true;
            this.lblConsole.Location = new System.Drawing.Point(164, 67);
            this.lblConsole.Name = "lblConsole";
            this.lblConsole.Size = new System.Drawing.Size(0, 13);
            this.lblConsole.TabIndex = 8;
            // 
            // howto_duplicate_console_Form1
            // 
            this.AcceptButton = this.btnWrite;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 161);
            this.Controls.Add(this.lblConsole);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label1);
            this.Name = "howto_duplicate_console_Form1";
            this.Text = "howto_duplicate_console";
            this.Load += new System.EventHandler(this.howto_duplicate_console_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConsole;
    }
}

