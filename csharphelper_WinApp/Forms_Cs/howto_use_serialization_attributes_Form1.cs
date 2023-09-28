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

 

using howto_use_serialization_attributes;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_use_serialization_attributes_Form1:Form
  { 


        public howto_use_serialization_attributes_Form1()
        {
            InitializeComponent();
        }

        // Make a Person and serialize it.
        private void btnSerialize_Click(object sender, EventArgs e)
        {
            Person.ContactMethods preferred_method;
            switch (cboContactMethod.Text)
            {
                case "Post":
                    preferred_method = Person.ContactMethods.Post;
                    break;
                case "Phone":
                    preferred_method = Person.ContactMethods.Phone;
                    break;
                default:
                    preferred_method = Person.ContactMethods.Email;
                    break;
            }

            Person person = new Person(
                txtFirstName.Text,
                txtLastName.Text,
                txtStreet.Text,
                txtCity.Text,
                txtState.Text,
                txtZip.Text,
                txtPhone1.Text,
                txtPhone2.Text,
                txtEmail1.Text,
                txtEmail2.Text,
                preferred_method
            );

            XmlSerializer xml_serializer = new XmlSerializer(typeof(Person));
            using (StringWriter string_writer = new StringWriter())
            {
                xml_serializer.Serialize(string_writer, person);
                txtSerialization.Text = string_writer.ToString();
            }

            txtFirstName.Clear();
            txtLastName.Clear();
            txtStreet.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtZip.Clear();
            txtPhone1.Clear();
            txtPhone2.Clear();
            txtEmail1.Clear();
            txtEmail2.Clear();
            cboContactMethod.SelectedIndex = -1;
        }

        // Deserialize the Person.
        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            XmlSerializer xml_serializer = new XmlSerializer(typeof(Person));
            using (StringReader string_reader = new StringReader(txtSerialization.Text))
            {
                Person person = (Person)xml_serializer.Deserialize(string_reader);

                txtFirstName.Text = person.FirstName;
                txtLastName.Text = person.LastName;
                txtStreet.Text = person.Street;
                txtCity.Text = person.City;
                txtState.Text = person.Street;
                txtZip.Text = person.Zip;
                txtPhone1.Text = person.Phones[0];
                txtPhone2.Text = person.Phones[1];
                txtEmail1.Text = person.Emails[0];
                txtEmail2.Text = person.Emails[1];
                cboContactMethod.Text = person.PreferredMethod.ToString();
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
            this.Label11 = new System.Windows.Forms.Label();
            this.cboContactMethod = new System.Windows.Forms.ComboBox();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.txtEmail1 = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
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
            // Label11
            // 
            this.Label11.Location = new System.Drawing.Point(8, 247);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(72, 16);
            this.Label11.TabIndex = 88;
            this.Label11.Text = "Method:";
            // 
            // cboContactMethod
            // 
            this.cboContactMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContactMethod.Items.AddRange(new object[] {
            "Post",
            "Phone",
            "Email"});
            this.cboContactMethod.Location = new System.Drawing.Point(80, 247);
            this.cboContactMethod.Name = "cboContactMethod";
            this.cboContactMethod.Size = new System.Drawing.Size(128, 21);
            this.cboContactMethod.TabIndex = 87;
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(80, 175);
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(128, 20);
            this.txtPhone2.TabIndex = 71;
            this.txtPhone2.Text = "999-888-7777";
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(8, 175);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(72, 16);
            this.Label8.TabIndex = 86;
            this.Label8.Text = "Phone 2:";
            // 
            // txtEmail2
            // 
            this.txtEmail2.Location = new System.Drawing.Point(80, 223);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(128, 20);
            this.txtEmail2.TabIndex = 73;
            this.txtEmail2.Text = "email2@nowhere.com";
            // 
            // txtEmail1
            // 
            this.txtEmail1.Location = new System.Drawing.Point(80, 199);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(128, 20);
            this.txtEmail1.TabIndex = 72;
            this.txtEmail1.Text = "email1@nowhere.com";
            // 
            // Label9
            // 
            this.Label9.Location = new System.Drawing.Point(8, 223);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(72, 16);
            this.Label9.TabIndex = 85;
            this.Label9.Text = "Email 2:";
            // 
            // Label10
            // 
            this.Label10.Location = new System.Drawing.Point(8, 199);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(72, 16);
            this.Label10.TabIndex = 84;
            this.Label10.Text = "Email 1:";
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(80, 151);
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(128, 20);
            this.txtPhone1.TabIndex = 70;
            this.txtPhone1.Text = "987-654-3210";
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(8, 151);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(72, 16);
            this.Label7.TabIndex = 83;
            this.Label7.Text = "Phone 1:";
            // 
            // btnDeserialize
            // 
            this.btnDeserialize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeserialize.Location = new System.Drawing.Point(216, 148);
            this.btnDeserialize.Name = "btnDeserialize";
            this.btnDeserialize.Size = new System.Drawing.Size(75, 23);
            this.btnDeserialize.TabIndex = 75;
            this.btnDeserialize.Text = "Deserialize";
            this.btnDeserialize.Click += new System.EventHandler(this.btnDeserialize_Click);
            // 
            // txtSerialization
            // 
            this.txtSerialization.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerialization.Location = new System.Drawing.Point(304, 7);
            this.txtSerialization.Multiline = true;
            this.txtSerialization.Name = "txtSerialization";
            this.txtSerialization.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSerialization.Size = new System.Drawing.Size(384, 272);
            this.txtSerialization.TabIndex = 76;
            // 
            // btnSerialize
            // 
            this.btnSerialize.Location = new System.Drawing.Point(216, 116);
            this.btnSerialize.Name = "btnSerialize";
            this.btnSerialize.Size = new System.Drawing.Size(75, 23);
            this.btnSerialize.TabIndex = 74;
            this.btnSerialize.Text = "Serialize";
            this.btnSerialize.Click += new System.EventHandler(this.btnSerialize_Click);
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(80, 127);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(128, 20);
            this.txtZip.TabIndex = 69;
            this.txtZip.Text = "12345";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(80, 103);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(128, 20);
            this.txtState.TabIndex = 68;
            this.txtState.Text = "CA";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(80, 79);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(128, 20);
            this.txtCity.TabIndex = 67;
            this.txtCity.Text = "Bugsville";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(80, 55);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(128, 20);
            this.txtStreet.TabIndex = 66;
            this.txtStreet.Text = "1337 Leet St";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(80, 31);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(128, 20);
            this.txtLastName.TabIndex = 65;
            this.txtLastName.Text = "Moose";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(80, 7);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(128, 20);
            this.txtFirstName.TabIndex = 64;
            this.txtFirstName.Text = "Mickey";
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(8, 127);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(72, 16);
            this.Label6.TabIndex = 82;
            this.Label6.Text = "ZIP:";
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(8, 103);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(72, 16);
            this.Label5.TabIndex = 81;
            this.Label5.Text = "State:";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(8, 79);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(72, 16);
            this.Label3.TabIndex = 80;
            this.Label3.Text = "City:";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(8, 55);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(72, 16);
            this.Label4.TabIndex = 79;
            this.Label4.Text = "Street:";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 31);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(72, 16);
            this.Label2.TabIndex = 78;
            this.Label2.Text = "Last Name:";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(72, 16);
            this.Label1.TabIndex = 77;
            this.Label1.Text = "First Name:";
            // 
            // howto_use_serialization_attributes_Form1
            // 
            this.AcceptButton = this.btnSerialize;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDeserialize;
            this.ClientSize = new System.Drawing.Size(696, 286);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.cboContactMethod);
            this.Controls.Add(this.txtPhone2);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.txtEmail2);
            this.Controls.Add(this.txtEmail1);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.txtPhone1);
            this.Controls.Add(this.Label7);
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
            this.Name = "howto_use_serialization_attributes_Form1";
            this.Text = "howto_use_serialization_attributes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.ComboBox cboContactMethod;
        internal System.Windows.Forms.TextBox txtPhone2;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtEmail2;
        internal System.Windows.Forms.TextBox txtEmail1;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtPhone1;
        internal System.Windows.Forms.Label Label7;
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

