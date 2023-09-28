using howto_preview_textbox_extender_provider;
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
     public partial class howto_preview_textbox_extender_provider_Form1:Form
  { 


        public howto_preview_textbox_extender_provider_Form1()
        {
            InitializeComponent();
        }

        // Validate a TextBox's new value.
        private void textBoxPreviewer1_TextChanging(TextBox text_box, string new_text, ref bool cancel)
        {
            // If the value is blank, just return and let it happen.
            if (new_text.Length == 0) return;

            // If the value doesn't end in a digit, add a 0.
            if (!char.IsDigit(new_text, new_text.Length - 1)) new_text += '0';

            // See which TextBox this is.
            if (text_box == txtInteger)
            {
                // Make sure this looks like an integer.
                int test_value;
                cancel = !int.TryParse(new_text, out test_value);
            }
            else
            {
                // Make sure this looks like a float.
                float test_value;
                cancel = !float.TryParse(new_text, out test_value);
            }

            // If we set cancel to true, beep.
            if (cancel) System.Media.SystemSounds.Beep.Play();
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInteger = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtFloat = new System.Windows.Forms.TextBox();
            this.textBoxPreviewer1 = new howto_preview_textbox_extender_provider.TextBoxPreviewer(this.components);
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Integer Only Here:";
            // 
            // txtInteger
            // 
            this.txtInteger.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtInteger.Location = new System.Drawing.Point(203, 66);
            this.txtInteger.Name = "txtInteger";
            this.textBoxPreviewer1.SetProvidePreview(this.txtInteger, true);
            this.txtInteger.Size = new System.Drawing.Size(100, 20);
            this.txtInteger.TabIndex = 18;
            this.txtInteger.Text = "123456";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Float Only Here:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Write Anything Here:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.Location = new System.Drawing.Point(203, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "ABC777";
            // 
            // txtFloat
            // 
            this.txtFloat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFloat.Location = new System.Drawing.Point(203, 40);
            this.txtFloat.Name = "txtFloat";
            this.textBoxPreviewer1.SetProvidePreview(this.txtFloat, true);
            this.txtFloat.Size = new System.Drawing.Size(100, 20);
            this.txtFloat.TabIndex = 15;
            this.txtFloat.Text = "-1.2e-3";
            // 
            // textBoxPreviewer1
            // 
            this.textBoxPreviewer1.TextChanging += new howto_preview_textbox_extender_provider.TextBoxPreviewer.TextChangingDelegate(this.textBoxPreviewer1_TextChanging);
            // 
            // howto_preview_textbox_extender_provider_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 101);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInteger);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtFloat);
            this.Name = "howto_preview_textbox_extender_provider_Form1";
            this.Text = "howto_preview_textbox_extender_provider";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInteger;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtFloat;
        private TextBoxPreviewer textBoxPreviewer1;
    }
}

