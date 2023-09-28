using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_override_method;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_override_method_Form1:Form
  { 


        public howto_override_method_Form1()
        {
            InitializeComponent();
        }

        // Create an Person variable that refers to
        // an Person and call its ShowAddress method.
        private void btnPerson_Click(object sender, EventArgs e)
        {
            Person person = new Person("Rod", "Stephens",
                "1337 Leet St", "Hacker", "HI", "01234");
            person.ShowAddress();
        }

        // Create an Employee variable that refers to
        // an Employee and call its ShowAddress method.
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee("Rod", "Stephens",
                "1337 Leet St", "Hacker", "HI", "01234", "MS-17");
            employee.ShowAddress();
        }

        // Create a Person variable that refers to
        // an Employee and call its ShowAddress method.
        private void btnEmployeeAsPerson_Click(object sender, EventArgs e)
        {
            Person person = new Employee("Rod", "Stephens",
                "1337 Leet St", "Hacker", "HI", "01234", "MS-17");
            person.ShowAddress();
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
            this.btnPerson = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnEmployeeAsPerson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPerson
            // 
            this.btnPerson.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPerson.Location = new System.Drawing.Point(74, 25);
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(137, 23);
            this.btnPerson.TabIndex = 3;
            this.btnPerson.Text = "Person";
            this.btnPerson.UseVisualStyleBackColor = true;
            this.btnPerson.Click += new System.EventHandler(this.btnPerson_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEmployee.Location = new System.Drawing.Point(74, 54);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(137, 23);
            this.btnEmployee.TabIndex = 4;
            this.btnEmployee.Text = "Employee as Employee";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnEmployeeAsPerson
            // 
            this.btnEmployeeAsPerson.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEmployeeAsPerson.Location = new System.Drawing.Point(74, 83);
            this.btnEmployeeAsPerson.Name = "btnEmployeeAsPerson";
            this.btnEmployeeAsPerson.Size = new System.Drawing.Size(137, 23);
            this.btnEmployeeAsPerson.TabIndex = 5;
            this.btnEmployeeAsPerson.Text = "Employee as Person";
            this.btnEmployeeAsPerson.UseVisualStyleBackColor = true;
            this.btnEmployeeAsPerson.Click += new System.EventHandler(this.btnEmployeeAsPerson_Click);
            // 
            // howto_override_method_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.btnPerson);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.btnEmployeeAsPerson);
            this.Name = "howto_override_method_Form1";
            this.Text = "howto_override_method";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPerson;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnEmployeeAsPerson;
    }
}

