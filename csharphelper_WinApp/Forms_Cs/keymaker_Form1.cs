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
     public partial class keymaker_Form1:Form
  { 


        public keymaker_Form1()
        {
            InitializeComponent();
        }

        // Make the key for this product number.
        private void btnMakeKey_Click(object sender, EventArgs e)
        {
            try
            {
                UInt32 program_id = UInt32.Parse(txtProgramId.Text);
                UInt32 product_number = UInt32.Parse(txtProductNumber.Text);
                UInt32 product_key = Encrypt(program_id, product_number);
                txtProductKey.Text = product_key.ToString();
            }
            catch (Exception ex)
            {
                txtProductKey.Clear();
                MessageBox.Show(ex.Message);
            }
        }

        // Simple encryption and decryption.
        private UInt32 Encrypt(UInt32 seed, UInt32 value)
        {
            Random rand = new Random((int)seed);
            return (value ^ (UInt32)(UInt32.MaxValue * rand.NextDouble()));
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
            this.txtProgramId = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnMakeKey = new System.Windows.Forms.Button();
            this.txtProductKey = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtProductNumber = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtProgramId
            // 
            this.txtProgramId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProgramId.Location = new System.Drawing.Point(134, 14);
            this.txtProgramId.Name = "txtProgramId";
            this.txtProgramId.Size = new System.Drawing.Size(152, 20);
            this.txtProgramId.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(14, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(60, 13);
            this.Label1.TabIndex = 19;
            this.Label1.Text = "Program ID";
            // 
            // btnMakeKey
            // 
            this.btnMakeKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMakeKey.Location = new System.Drawing.Point(112, 78);
            this.btnMakeKey.Name = "btnMakeKey";
            this.btnMakeKey.Size = new System.Drawing.Size(75, 23);
            this.btnMakeKey.TabIndex = 2;
            this.btnMakeKey.Text = "Make Key";
            this.btnMakeKey.UseVisualStyleBackColor = true;
            this.btnMakeKey.Click += new System.EventHandler(this.btnMakeKey_Click);
            // 
            // txtProductKey
            // 
            this.txtProductKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductKey.Location = new System.Drawing.Point(137, 118);
            this.txtProductKey.Name = "txtProductKey";
            this.txtProductKey.Size = new System.Drawing.Size(152, 20);
            this.txtProductKey.TabIndex = 3;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(17, 118);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(68, 13);
            this.Label3.TabIndex = 16;
            this.Label3.Text = "Product Key:";
            // 
            // txtProductNumber
            // 
            this.txtProductNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductNumber.Location = new System.Drawing.Point(134, 38);
            this.txtProductNumber.Name = "txtProductNumber";
            this.txtProductNumber.Size = new System.Drawing.Size(152, 20);
            this.txtProductNumber.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(14, 38);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(90, 13);
            this.Label2.TabIndex = 15;
            this.Label2.Text = "User\'s Product ID";
            // 
            // keymaker_Form1
            // 
            this.AcceptButton = this.btnMakeKey;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 153);
            this.Controls.Add(this.txtProgramId);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnMakeKey);
            this.Controls.Add(this.txtProductKey);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtProductNumber);
            this.Controls.Add(this.Label2);
            this.Name = "keymaker_Form1";
            this.Text = "KeyMaker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtProgramId;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnMakeKey;
        internal System.Windows.Forms.TextBox txtProductKey;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtProductNumber;
        internal System.Windows.Forms.Label Label2;
    }
}

