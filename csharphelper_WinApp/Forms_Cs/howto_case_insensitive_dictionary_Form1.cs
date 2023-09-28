using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_case_insensitive_dictionary_Form1:Form
  { 


        public howto_case_insensitive_dictionary_Form1()
        {
            InitializeComponent();
        }

        // Compare case-insensitive dictionaries.
        private void btnGo_Click(object sender, EventArgs e)
        {
            txtCaseInsensitive.Clear();
            txtToLower.Clear();
            int num_items = int.Parse(txtNumItems.Text);
            Dictionary<string, string> dict;
            string key, value;
            Refresh();

            // Case-insensitive dictionary.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            dict =
                new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

            // Add items.
            for (int i = 0; i < num_items; i++)
            {
                key = "Key " + i.ToString();
                value = "Value " + i.ToString();
                if (!dict.ContainsKey(key)) dict.Add(key, value);
            }

            // Add duplicate items with different case.
            for (int i = 0; i < num_items; i++)
            {
                key = "key " + i.ToString();
                value = "value " + i.ToString();
                if (!dict.ContainsKey(key)) dict.Add(key, value);
            }

            // Find items.
            for (int i = 0; i < num_items; i++)
            {
                key = "Key " + i.ToString();
                if (dict.ContainsKey(key)) value = dict[key];
            }

            // Look for missing items.
            for (int i = 0; i < num_items; i++)
            {
                key = "Missing " + i.ToString();
                if (dict.ContainsKey(key)) value = dict[key];
            }

            watch.Stop();
            txtCaseInsensitive.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " sec";
            txtCaseInsensitive.Refresh();

            // Dictionary using ToLower.
            watch.Reset();
            watch.Start();
            dict = new Dictionary<string, string>();

            // Add items.
            for (int i = 0; i < num_items; i++)
            {
                key = "Key " + i.ToString();
                key = key.ToLower();
                value = "Value " + i.ToString();
                if (!dict.ContainsKey(key)) dict.Add(key, value);
            }

            // Add duplicate items with different case.
            for (int i = 0; i < num_items; i++)
            {
                key = "key " + i.ToString();
                key = key.ToLower();
                value = "value " + i.ToString();
                if (!dict.ContainsKey(key)) dict.Add(key, value);
            }

            // Find items.
            for (int i = 0; i < num_items; i++)
            {
                key = "Key " + i.ToString();
                key = key.ToLower();
                if (dict.ContainsKey(key)) value = dict[key];
            }

            // Look for missing items.
            for (int i = 0; i < num_items; i++)
            {
                key = "Missing " + i.ToString();
                key = key.ToLower();
                if (dict.ContainsKey(key)) value = dict[key];
            }

            watch.Stop();
            txtToLower.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " sec";
            txtToLower.Refresh();
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
            this.txtToLower = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCaseInsensitive = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNumItems = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtToLower
            // 
            this.txtToLower.Location = new System.Drawing.Point(104, 79);
            this.txtToLower.Name = "txtToLower";
            this.txtToLower.ReadOnly = true;
            this.txtToLower.Size = new System.Drawing.Size(100, 20);
            this.txtToLower.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "ToLower:";
            // 
            // txtCaseInsensitive
            // 
            this.txtCaseInsensitive.Location = new System.Drawing.Point(104, 53);
            this.txtCaseInsensitive.Name = "txtCaseInsensitive";
            this.txtCaseInsensitive.ReadOnly = true;
            this.txtCaseInsensitive.Size = new System.Drawing.Size(100, 20);
            this.txtCaseInsensitive.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Case-insensitive:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(268, 11);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 9;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNumItems
            // 
            this.txtNumItems.Location = new System.Drawing.Point(104, 13);
            this.txtNumItems.Name = "txtNumItems";
            this.txtNumItems.Size = new System.Drawing.Size(100, 20);
            this.txtNumItems.TabIndex = 8;
            this.txtNumItems.Text = "100000";
            this.txtNumItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "# Items:";
            // 
            // howto_case_insensitive_dictionary_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 111);
            this.Controls.Add(this.txtToLower);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCaseInsensitive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumItems);
            this.Controls.Add(this.label1);
            this.Name = "howto_case_insensitive_dictionary_Form1";
            this.Text = "howto_case_insensitive_dictionary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtToLower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCaseInsensitive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtNumItems;
        private System.Windows.Forms.Label label1;
    }
}

