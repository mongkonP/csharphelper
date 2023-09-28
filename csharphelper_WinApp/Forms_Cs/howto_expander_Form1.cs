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
     public partial class howto_expander_Form1:Form
  { 


        public howto_expander_Form1()
        {
            InitializeComponent();
        }

        private void howto_expander_Form1_Load(object sender, EventArgs e)
        {
            // Select a state.
            cboState.SelectedIndex = 0;
        }

        // The expander's current state.
        private bool Expanded = false;

        // Start expanding.
        private void btnExpander_Click(object sender, EventArgs e)
        {
            if (Expanded)
            {
                btnExpander.Image = Properties.Resources.expander_down;
                tmrCollapse.Enabled = true;
                tmrExpand.Enabled = false;
            }
            else
            {
                btnExpander.Image = Properties.Resources.expander_up;
                tmrExpand.Enabled = true;
                tmrCollapse.Enabled = false;
            }
            Expanded = !Expanded;
        }

        // The number of pixels expanded per timer Tick.
        private const int ExpansionPerTick = 7;

        // Make the expander panel bigger.
        private void tmrExpand_Tick(object sender, EventArgs e)
        {
            int new_height = panAddress.Height + ExpansionPerTick;
            if (new_height >= panAddress.MaximumSize.Height)
            {
                tmrExpand.Enabled = false;
                new_height = panAddress.MaximumSize.Height;
            }

            panAddress.Height = new_height;
        }

        // Make the expander panel smaller.
        private void tmrCollapse_Tick(object sender, EventArgs e)
        {
            int new_height = panAddress.Height - ExpansionPerTick;
            if (new_height <= panAddress.MinimumSize.Height)
            {
                tmrCollapse.Enabled = false;
                new_height = panAddress.MinimumSize.Height;
            }

            panAddress.Height = new_height;
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
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.tmrCollapse = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panAddress = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExpander = new System.Windows.Forms.Button();
            this.tmrExpand = new System.Windows.Forms.Timer(this.components);
            this.panAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "ZIP:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(174, 107);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(79, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "54321";
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Items.AddRange(new object[] {
            "AZ",
            "CT",
            "VT",
            "NH",
            "WA",
            "CO",
            "UT",
            "NM"});
            this.cboState.Location = new System.Drawing.Point(70, 107);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(44, 21);
            this.cboState.TabIndex = 13;
            // 
            // tmrCollapse
            // 
            this.tmrCollapse.Interval = 10;
            this.tmrCollapse.Tick += new System.EventHandler(this.tmrCollapse_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "State:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(70, 81);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(183, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Programmeria";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(70, 55);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(183, 20);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "1337 Leet St";
            // 
            // panAddress
            // 
            this.panAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panAddress.Controls.Add(this.cboState);
            this.panAddress.Controls.Add(this.label6);
            this.panAddress.Controls.Add(this.textBox5);
            this.panAddress.Controls.Add(this.label5);
            this.panAddress.Controls.Add(this.textBox3);
            this.panAddress.Controls.Add(this.label3);
            this.panAddress.Controls.Add(this.textBox4);
            this.panAddress.Controls.Add(this.label4);
            this.panAddress.Controls.Add(this.textBox2);
            this.panAddress.Controls.Add(this.label2);
            this.panAddress.Controls.Add(this.textBox1);
            this.panAddress.Controls.Add(this.label1);
            this.panAddress.Location = new System.Drawing.Point(12, 40);
            this.panAddress.MaximumSize = new System.Drawing.Size(260, 136);
            this.panAddress.MinimumSize = new System.Drawing.Size(260, 5);
            this.panAddress.Name = "panAddress";
            this.panAddress.Size = new System.Drawing.Size(260, 5);
            this.panAddress.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "City:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Street:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(70, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(183, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "Stephens";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Rod";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // btnExpander
            // 
            this.btnExpander.Image = Properties.Resources.expander_down;
            this.btnExpander.Location = new System.Drawing.Point(12, 12);
            this.btnExpander.Name = "btnExpander";
            this.btnExpander.Size = new System.Drawing.Size(24, 24);
            this.btnExpander.TabIndex = 2;
            this.btnExpander.UseVisualStyleBackColor = true;
            this.btnExpander.Click += new System.EventHandler(this.btnExpander_Click);
            // 
            // tmrExpand
            // 
            this.tmrExpand.Interval = 10;
            this.tmrExpand.Tick += new System.EventHandler(this.tmrExpand_Tick);
            // 
            // howto_expander_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 185);
            this.Controls.Add(this.panAddress);
            this.Controls.Add(this.btnExpander);
            this.Name = "howto_expander_Form1";
            this.Text = "howto_expander";
            this.Load += new System.EventHandler(this.howto_expander_Form1_Load);
            this.panAddress.ResumeLayout(false);
            this.panAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Timer tmrCollapse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Panel panAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExpander;
        private System.Windows.Forms.Timer tmrExpand;
    }
}

