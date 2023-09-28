using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml.Serialization;
using System.IO;

 

using howto_serialize;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_serialize_Form1:Form
  { 


        public howto_serialize_Form1()
        {
            InitializeComponent();
        }

        // Create a Person, serialize it, and display the serialization.
        private void btnSerialize_Click(object sender, EventArgs e)
        {
            // Make a new Person.
            Person per = new Person(
                txtFirstName.Text,
                txtLastName.Text,
                txtStreet.Text,
                txtCity.Text,
                txtState.Text,
                txtZip.Text);

            // Make the XmlSerializer and StringWriter.
            XmlSerializer xml_serializer = new XmlSerializer(typeof(Person));
            using (StringWriter string_writer = new StringWriter())
            {
                // Serialize.
                xml_serializer.Serialize(string_writer, per);

                // Display the serialization.
                txtSerialization.Text = string_writer.ToString();
            }

            // Reset the TextBoxes.
            txtFirstName.Clear();
            txtLastName.Clear();
            txtStreet.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtZip.Clear();
        }

        // Deserialize a Person.
        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            // Deserialize the serialization.
            XmlSerializer xml_serializer = new XmlSerializer(typeof(Person));
            using (StringReader string_reader = new StringReader(txtSerialization.Text))
            {
                Person per = (Person)(xml_serializer.Deserialize(string_reader));

                // Display the Person's properties in the TextBoxes.
                txtFirstName.Text = per.FirstName;
                txtLastName.Text = per.LastName;
                txtStreet.Text = per.Street;
                txtCity.Text = per.City;
                txtState.Text = per.Street;
                txtZip.Text = per.Zip;
            }

            txtSerialization.Clear();
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
            this.btnDeserialize = new System.Windows.Forms.Button();
            this.txtSerialization = new System.Windows.Forms.TextBox();
            this.btnSerialize = new System.Windows.Forms.Button();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDeserialize
            // 
            this.btnDeserialize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeserialize.Location = new System.Drawing.Point(168, 87);
            this.btnDeserialize.Name = "btnDeserialize";
            this.btnDeserialize.Size = new System.Drawing.Size(75, 23);
            this.btnDeserialize.TabIndex = 44;
            this.btnDeserialize.Text = "Deserialize";
            this.btnDeserialize.Click += new System.EventHandler(this.btnDeserialize_Click);
            // 
            // txtSerialization
            // 
            this.txtSerialization.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerialization.Location = new System.Drawing.Point(249, 7);
            this.txtSerialization.Multiline = true;
            this.txtSerialization.Name = "txtSerialization";
            this.txtSerialization.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSerialization.Size = new System.Drawing.Size(342, 168);
            this.txtSerialization.TabIndex = 43;
            // 
            // btnSerialize
            // 
            this.btnSerialize.Location = new System.Drawing.Point(168, 55);
            this.btnSerialize.Name = "btnSerialize";
            this.btnSerialize.Size = new System.Drawing.Size(75, 23);
            this.btnSerialize.TabIndex = 42;
            this.btnSerialize.Text = "Serialize";
            this.btnSerialize.Click += new System.EventHandler(this.btnSerialize_Click);
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(80, 127);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(82, 20);
            this.txtZip.TabIndex = 41;
            this.txtZip.Text = "12345";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(80, 103);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(82, 20);
            this.txtState.TabIndex = 39;
            this.txtState.Text = "CA";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(80, 79);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(82, 20);
            this.txtCity.TabIndex = 37;
            this.txtCity.Text = "Bugsville";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(80, 55);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(82, 20);
            this.txtStreet.TabIndex = 35;
            this.txtStreet.Text = "1337 Leet St";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(80, 31);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(82, 20);
            this.txtLastName.TabIndex = 33;
            this.txtLastName.Text = "Moose";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(80, 7);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(82, 20);
            this.txtFirstName.TabIndex = 31;
            this.txtFirstName.Text = "Mickey";
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(8, 127);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(72, 16);
            this.Label6.TabIndex = 40;
            this.Label6.Text = "ZIP:";
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(8, 103);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(72, 16);
            this.Label5.TabIndex = 38;
            this.Label5.Text = "State:";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(8, 79);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(72, 16);
            this.Label3.TabIndex = 36;
            this.Label3.Text = "City:";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(8, 55);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(72, 16);
            this.Label4.TabIndex = 34;
            this.Label4.Text = "Street:";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 31);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(72, 16);
            this.Label2.TabIndex = 32;
            this.Label2.Text = "Last Name:";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(72, 16);
            this.Label1.TabIndex = 30;
            this.Label1.Text = "First Name:";
            // 
            // howto_serialize_Form1
            // 
            this.AcceptButton = this.btnSerialize;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDeserialize;
            this.ClientSize = new System.Drawing.Size(599, 182);
            this.Controls.Add(this.btnDeserialize);
            this.Controls.Add(this.txtSerialization);
            this.Controls.Add(this.btnSerialize);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "howto_serialize_Form1";
            this.Text = "howto_serialize";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnDeserialize;
        internal System.Windows.Forms.TextBox txtSerialization;
        internal System.Windows.Forms.Button btnSerialize;
        internal System.Windows.Forms.TextBox txtZip;
        internal System.Windows.Forms.TextBox txtState;
        internal System.Windows.Forms.TextBox txtCity;
        internal System.Windows.Forms.TextBox txtStreet;
        internal System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}

