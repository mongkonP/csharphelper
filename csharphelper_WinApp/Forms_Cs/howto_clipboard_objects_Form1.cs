using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_clipboard_objects;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_clipboard_objects_Form1:Form
  { 


        public howto_clipboard_objects_Form1()
        {
            InitializeComponent();
        }

        // Copy a Person to the Clipboard.
        private void btnCopy_Click(object sender, EventArgs e)
        {
            Person person = new Person() { FirstName = txtFirstName.Text, LastName = txtLastName.Text };
            Clipboard.SetDataObject(person);
        }

        // Paste the person from the Clipboard.
        private void btnPaste_Click(object sender, EventArgs e)
        {
            IDataObject data_object = Clipboard.GetDataObject();
            if (data_object.GetDataPresent("howto_clipboard_objects.Person"))
            {
                Person person = (Person)data_object.GetData("howto_clipboard_objects.Person");
                txtDropFirstName.Text = person.FirstName;
                txtDropLastName.Text = person.LastName;
            }
            else
            {
                txtDropFirstName.Clear();
                txtDropLastName.Clear();
            }
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
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtDropLastName = new System.Windows.Forms.TextBox();
            this.txtDropFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.Location = new System.Drawing.Point(236, 112);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(56, 24);
            this.btnPaste.TabIndex = 41;
            this.btnPaste.Text = "Paste";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(236, 8);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(56, 24);
            this.btnCopy.TabIndex = 40;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtDropLastName
            // 
            this.txtDropLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDropLastName.Location = new System.Drawing.Point(80, 136);
            this.txtDropLastName.Name = "txtDropLastName";
            this.txtDropLastName.Size = new System.Drawing.Size(140, 20);
            this.txtDropLastName.TabIndex = 39;
            // 
            // txtDropFirstName
            // 
            this.txtDropFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDropFirstName.Location = new System.Drawing.Point(80, 112);
            this.txtDropFirstName.Name = "txtDropFirstName";
            this.txtDropFirstName.Size = new System.Drawing.Size(140, 20);
            this.txtDropFirstName.TabIndex = 38;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(80, 32);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(140, 20);
            this.txtLastName.TabIndex = 35;
            this.txtLastName.Text = "Stephens";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Location = new System.Drawing.Point(80, 8);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(140, 20);
            this.txtFirstName.TabIndex = 34;
            this.txtFirstName.Text = "Rod";
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(8, 136);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(72, 16);
            this.Label5.TabIndex = 37;
            this.Label5.Text = "Last Name";
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(8, 112);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(72, 16);
            this.Label6.TabIndex = 36;
            this.Label6.Text = "First Name";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(72, 16);
            this.Label2.TabIndex = 33;
            this.Label2.Text = "Last Name";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(72, 16);
            this.Label1.TabIndex = 32;
            this.Label1.Text = "First Name";
            // 
            // howto_clipboard_objects_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 164);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtDropLastName);
            this.Controls.Add(this.txtDropFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "howto_clipboard_objects_Form1";
            this.Text = "howto_clipboard_objects";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnPaste;
        internal System.Windows.Forms.Button btnCopy;
        internal System.Windows.Forms.TextBox txtDropLastName;
        internal System.Windows.Forms.TextBox txtDropFirstName;
        internal System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}

