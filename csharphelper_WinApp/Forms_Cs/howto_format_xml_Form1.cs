using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Xml;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_format_xml_Form1:Form
  { 


        public howto_format_xml_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            // Make the XML document.
            XmlDocument xml_document = new XmlDocument();

            // Make the root element.
            XmlElement employees_element = xml_document.CreateElement("Employees");
            xml_document.AppendChild(employees_element);

            // Make some Employee elements.
            MakeEmployee(employees_element, "Albert", "Anders", 11111);
            MakeEmployee(employees_element, "Betty", "Beach", 22222);
            MakeEmployee(employees_element, "Chuck", "Cinder", 33333);

            // Format the XML text.
            StringWriter string_writer = new StringWriter();
            XmlTextWriter xml_text_writer = new XmlTextWriter(string_writer);
            xml_text_writer.Formatting = Formatting.Indented;
            xml_document.WriteTo(xml_text_writer);

            // Display the result.
            txtResult.Text = string_writer.ToString();
        }

        // Add an Employee node to the document.
        private void MakeEmployee(XmlElement parent,
            String first_name, String last_name, int emp_id)
        {
            // Make the Employee element.
            XmlNode employee_element = parent.OwnerDocument.CreateElement("Employee");
            parent.AppendChild(employee_element);

            // Add the FirstName, LastName, and EmployeeId elements.
            XmlNode first_name_element = parent.OwnerDocument.CreateElement("FirstName");
            first_name_element.InnerText = first_name;
            employee_element.AppendChild(first_name_element);

            XmlNode last_name_element = parent.OwnerDocument.CreateElement("LastName");
            last_name_element.InnerText = last_name;
            employee_element.AppendChild(last_name_element);

            XmlNode employee_id_element = parent.OwnerDocument.CreateElement("EmployeeId");
            employee_id_element.InnerText = emp_id.ToString();
            employee_element.AppendChild(employee_id_element);
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
            this.btnGo = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(12, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(12, 41);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(260, 251);
            this.txtResult.TabIndex = 3;
            // 
            // howto_format_xml_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 304);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtResult);
            this.Name = "howto_format_xml_Form1";
            this.Text = "howto_format_xml";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtResult;
    }
}

