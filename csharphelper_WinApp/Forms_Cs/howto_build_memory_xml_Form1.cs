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
     public partial class howto_build_memory_xml_Form1:Form
  { 


        public howto_build_memory_xml_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            MemoryStream memory_stream = new MemoryStream();
            XmlTextWriter xml_text_writer  = 
                new XmlTextWriter(memory_stream, System.Text.Encoding.UTF8);

            // Use indentation to make the result look nice.
            xml_text_writer.Formatting = Formatting.Indented;
            xml_text_writer.Indentation = 4;

            // Write the XML declaration.
            xml_text_writer.WriteStartDocument(true);

            // Start the Employees node.
            xml_text_writer.WriteStartElement("Employees");

            // Write some Employee elements.
            MakeEmployee(xml_text_writer, "Albert", "Anders", 11111);
            MakeEmployee(xml_text_writer, "Betty", "Beach", 22222);
            MakeEmployee(xml_text_writer, "Chuck", "Cinder", 33333);

            // End the Employees node.
            xml_text_writer.WriteEndElement();

            // End the document.
            xml_text_writer.WriteEndDocument();
            xml_text_writer.Flush();

            // Use a StreamReader to display the result.
            StreamReader stream_reader = new StreamReader(memory_stream);

            memory_stream.Seek(0, SeekOrigin.Begin);
            txtResult.Text = stream_reader.ReadToEnd();
            txtResult.Select(0, 0);

            // Close the XmlTextWriter.
            xml_text_writer.Close();
        }

        // Add an Employee node to the document.
        private void MakeEmployee(XmlTextWriter xml_text_writer, 
            String first_name, String last_name, int emp_id)
        {
            // Start the Employee element.
            xml_text_writer.WriteStartElement("Employee");

            // Write the FirstName.
            xml_text_writer.WriteStartElement("FirstName");
            xml_text_writer.WriteString(first_name);
            xml_text_writer.WriteEndElement();

            // Write the LastName.
            xml_text_writer.WriteStartElement("LastName");
            xml_text_writer.WriteString(last_name);
            xml_text_writer.WriteEndElement();

            // Write the EmployeeId.
            xml_text_writer.WriteStartElement("EmployeeId");
            xml_text_writer.WriteString(emp_id.ToString());
            xml_text_writer.WriteEndElement();

            // Close the Employee element.
            xml_text_writer.WriteEndElement();
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(12, 41);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(299, 266);
            this.txtResult.TabIndex = 3;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(12, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // howto_build_memory_xml_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 319);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGo);
            this.Name = "howto_build_memory_xml_Form1";
            this.Text = "howto_build_memory_xml";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtResult;
        internal System.Windows.Forms.Button btnGo;
    }
}

