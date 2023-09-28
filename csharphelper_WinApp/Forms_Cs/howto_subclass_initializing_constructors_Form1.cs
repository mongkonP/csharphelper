using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_subclass_initializing_constructors;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_subclass_initializing_constructors_Form1:Form
  { 


        public howto_subclass_initializing_constructors_Form1()
        {
            InitializeComponent();
        }

        private void howto_subclass_initializing_constructors_Form1_Load(object sender, EventArgs e)
        {
            // Create a Person.
            Person person = new Person("Rod", "Stephens",
                "1337 Leet St", "Hacker", "HI", "01234");

            // Create an Employee.
            Employee employee = new Employee("Rod", "Stephens",
                "1337 Leet St", "Hacker", "HI", "01234", "MS-17");
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
            this.SuspendLayout();
            // 
            // howto_subclass_initializing_constructors_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 121);
            this.Name = "howto_subclass_initializing_constructors_Form1";
            this.Text = "howto_subclass_initializing_constructors";
            this.Load += new System.EventHandler(this.howto_subclass_initializing_constructors_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

