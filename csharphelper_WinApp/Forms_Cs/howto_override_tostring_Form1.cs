using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_override_tostring;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_override_tostring_Form1:Form
  { 


        public howto_override_tostring_Form1()
        {
            InitializeComponent();
        }

        // Create and display a list of Person objects.
        private void howto_override_tostring_Form1_Load(object sender, EventArgs e)
        {
            Person[] people =
            {
                new Person() { FirstName="Simon", LastName="Green" },
                new Person() { FirstName="Terry", LastName="Pratchett" },
                new Person() { FirstName="Eowin", LastName="Colfer" },
            };
            lstPeople.DataSource = people;

            Person2[] people2 =
            {
                new Person2() { FirstName="Simon", LastName="Green" },
                new Person2() { FirstName="Terry", LastName="Pratchett" },
                new Person2() { FirstName="Eowin", LastName="Colfer" },
            };
            lstPeople2.DataSource = people2;
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
            this.lstPeople = new System.Windows.Forms.ListBox();
            this.lstPeople2 = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPeople
            // 
            this.lstPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPeople.FormattingEnabled = true;
            this.lstPeople.IntegralHeight = false;
            this.lstPeople.Location = new System.Drawing.Point(3, 3);
            this.lstPeople.Name = "lstPeople";
            this.lstPeople.Size = new System.Drawing.Size(174, 81);
            this.lstPeople.TabIndex = 0;
            // 
            // lstPeople2
            // 
            this.lstPeople2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPeople2.FormattingEnabled = true;
            this.lstPeople2.IntegralHeight = false;
            this.lstPeople2.Location = new System.Drawing.Point(183, 3);
            this.lstPeople2.Name = "lstPeople2";
            this.lstPeople2.Size = new System.Drawing.Size(174, 81);
            this.lstPeople2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lstPeople2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstPeople, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 87);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // howto_override_tostring_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_override_tostring_Form1";
            this.Text = "howto_override_tostring";
            this.Load += new System.EventHandler(this.howto_override_tostring_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstPeople;
        private System.Windows.Forms.ListBox lstPeople2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

