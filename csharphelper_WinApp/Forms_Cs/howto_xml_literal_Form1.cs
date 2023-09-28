using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml.Linq;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_xml_literal_Form1:Form
  { 


        public howto_xml_literal_Form1()
        {
            InitializeComponent();
        }

        private void howto_xml_literal_Form1_Load(object sender, EventArgs e)
        {
            // Read the XElement.
            XElement xelement = XElement.Parse(
@"<employees>
    <employee firstname=""Terry"" lastname=""Pratchett""/>
    <employee firstname='Glen' lastname='Cook'/>
    <employee firstname='Tom' lastname='Holt'/>
    <employee>
      <firstname>Rod</firstname>
      <lastname>Stephens</lastname>
    </employee>
  </employees>
");

            // Display the nodes.
            foreach (XNode node in xelement.Nodes())
                lstNodes.Items.Add(node.ToString());
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
            this.lstNodes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstNodes
            // 
            this.lstNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNodes.FormattingEnabled = true;
            this.lstNodes.Location = new System.Drawing.Point(12, 13);
            this.lstNodes.Name = "lstNodes";
            this.lstNodes.Size = new System.Drawing.Size(437, 95);
            this.lstNodes.TabIndex = 1;
            // 
            // howto_xml_literal_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 120);
            this.Controls.Add(this.lstNodes);
            this.Name = "howto_xml_literal_Form1";
            this.Text = "howto_xml_literal";
            this.Load += new System.EventHandler(this.howto_xml_literal_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstNodes;
    }
}

