using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_show_own_code_Form1:Form
  { 


        public howto_show_own_code_Form1()
        {
            InitializeComponent();
        }

        private void howto_show_own_code_Form1_Load(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            byte[] bytes = File.ReadAllBytes(Application.ExecutablePath);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                string value = Convert.ToString(bytes[i], 2);
                value = value.PadLeft(8, '0');
                sb.Append(value + ' ');
            }
            txtResult.Text = sb.ToString();

            //byte[] bytes = File.ReadAllBytes(Application.ExecutablePath);
            //string[] strings = Array.ConvertAll(bytes,
            //    b => Convert.ToString(b, 2).PadLeft(8, '0'));
            //txtResult.Text = string.Join(" ", strings);

            //var query =
            //    from byte b in File.ReadAllBytes(Application.ExecutablePath)
            //    select Convert.ToString(b, 2).PadLeft(8, '0');
            //txtResult.Text = string.Join(" ", query.ToArray());

            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalSeconds.ToString("0.0000") + " seconds");
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(12, 12);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(360, 187);
            this.txtResult.TabIndex = 0;
            // 
            // howto_show_own_code_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.txtResult);
            this.Name = "howto_show_own_code_Form1";
            this.Text = "howto_show_own_code";
            this.Load += new System.EventHandler(this.howto_show_own_code_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
    }
}

