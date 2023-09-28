using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_icloneable_person;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_icloneable_person_Form1:Form
  { 


        public howto_icloneable_person_Form1()
        {
            InitializeComponent();
        }

        private Person person1, person2, person3;
        private void howto_icloneable_person_Form1_Load(object sender, EventArgs e)
        {
            // Make a Person.
            person1 = new Person()
            {
                FirstName = "Ann",
                LastName = "Archer",
                Address = new StreetAddress() { Street = "101 Ash Ave", City = "Ann Arbor", State = "MI", Zip = "12345" },
                Email = "Ann@anywhere.com",
                Phone = "703-287-3798"
            };

            // Make shallow and deep clones.
            person2 = person1.Clone(Person.CloneType.Shallow);
            person3 = person1.Clone(Person.CloneType.Deep);

            // Display the objects.
            propPerson.SelectedObject = person1;
            propShallowClone.SelectedObject = person2;
            propDeepClone.SelectedObject = person3;

            propPerson.ExpandAllGridItems();
            propShallowClone.ExpandAllGridItems();
            propDeepClone.ExpandAllGridItems();
        }

        // A property value changed. Refresh all of the PropertyGrids.
        private void propGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            propPerson.Refresh();
            propShallowClone.Refresh();
            propDeepClone.Refresh();
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
            this.label3 = new System.Windows.Forms.Label();
            this.propDeepClone = new System.Windows.Forms.PropertyGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.propShallowClone = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.propPerson = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(414, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "Deep Clone";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // propDeepClone
            // 
            this.propDeepClone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.propDeepClone.Location = new System.Drawing.Point(417, 35);
            this.propDeepClone.Name = "propDeepClone";
            this.propDeepClone.Size = new System.Drawing.Size(196, 271);
            this.propDeepClone.TabIndex = 16;
            this.propDeepClone.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propGrid_PropertyValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(212, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Shallow Clone";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // propShallowClone
            // 
            this.propShallowClone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.propShallowClone.Location = new System.Drawing.Point(215, 35);
            this.propShallowClone.Name = "propShallowClone";
            this.propShallowClone.Size = new System.Drawing.Size(196, 271);
            this.propShallowClone.TabIndex = 14;
            this.propShallowClone.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propGrid_PropertyValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Person";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // propPerson
            // 
            this.propPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.propPerson.Location = new System.Drawing.Point(13, 35);
            this.propPerson.Name = "propPerson";
            this.propPerson.Size = new System.Drawing.Size(196, 271);
            this.propPerson.TabIndex = 12;
            this.propPerson.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propGrid_PropertyValueChanged);
            // 
            // howto_icloneable_person_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 316);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.propDeepClone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.propShallowClone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.propPerson);
            this.Name = "howto_icloneable_person_Form1";
            this.Text = "howto_icloneable_person";
            this.Load += new System.EventHandler(this.howto_icloneable_person_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PropertyGrid propDeepClone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PropertyGrid propShallowClone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PropertyGrid propPerson;
    }
}

