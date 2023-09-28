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
     public partial class howto_auto_complete_Form1:Form
  { 


        public howto_auto_complete_Form1()
        {
            InitializeComponent();
        }

        private void howto_auto_complete_Form1_Load(object sender, EventArgs e)
        {
            // Make the collection of day names.
            AutoCompleteStringCollection day_source =
                new AutoCompleteStringCollection();
            day_source.AddRange(Enum.GetNames(typeof(DayOfWeek)));

            // Prepare the TextBox.
            PrepareTextBox(txtAppend, day_source, AutoCompleteMode.Append);
            PrepareTextBox(txtSuggest, day_source, AutoCompleteMode.Suggest);
            PrepareTextBox(txtSuggestAppend, day_source, AutoCompleteMode.SuggestAppend);
        }

        // Prepare a TextBox for auto-completion.
        private void PrepareTextBox(TextBox txt, 
            AutoCompleteStringCollection source, AutoCompleteMode mode)
        {
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt.AutoCompleteCustomSource = source;
            txt.AutoCompleteMode = mode;
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
            this.txtNone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAppend = new System.Windows.Forms.TextBox();
            this.txtSuggest = new System.Windows.Forms.TextBox();
            this.txtSuggestAppend = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Day of Week:";
            // 
            // txtNone
            // 
            this.txtNone.Location = new System.Drawing.Point(138, 36);
            this.txtNone.Name = "txtNone";
            this.txtNone.Size = new System.Drawing.Size(100, 20);
            this.txtNone.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Append:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Suggest:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "SuggestAppend:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "None:";
            // 
            // txtAppend
            // 
            this.txtAppend.Location = new System.Drawing.Point(138, 62);
            this.txtAppend.Name = "txtAppend";
            this.txtAppend.Size = new System.Drawing.Size(100, 20);
            this.txtAppend.TabIndex = 6;
            // 
            // txtSuggest
            // 
            this.txtSuggest.Location = new System.Drawing.Point(138, 88);
            this.txtSuggest.Name = "txtSuggest";
            this.txtSuggest.Size = new System.Drawing.Size(100, 20);
            this.txtSuggest.TabIndex = 7;
            // 
            // txtSuggestAppend
            // 
            this.txtSuggestAppend.Location = new System.Drawing.Point(138, 114);
            this.txtSuggestAppend.Name = "txtSuggestAppend";
            this.txtSuggestAppend.Size = new System.Drawing.Size(100, 20);
            this.txtSuggestAppend.TabIndex = 8;
            // 
            // howto_auto_complete_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 148);
            this.Controls.Add(this.txtSuggestAppend);
            this.Controls.Add(this.txtSuggest);
            this.Controls.Add(this.txtAppend);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNone);
            this.Controls.Add(this.label1);
            this.Name = "howto_auto_complete_Form1";
            this.Text = "howto_auto_complete";
            this.Load += new System.EventHandler(this.howto_auto_complete_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAppend;
        private System.Windows.Forms.TextBox txtSuggest;
        private System.Windows.Forms.TextBox txtSuggestAppend;
    }
}

