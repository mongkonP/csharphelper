using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// At design time:
//   Set the ImageList's ImageSize properties to the correct values:
//      imlSmallIcons.ImageSize = 32,32
//      imlLargeIcons.ImageSize = 64,64
//   Set the ImageList's ColorDepth properties to the correct values:
//      imlSmallIcons.ColorDepth = Depth32bit
//      imlLargeIcons.ColorDepth = Depth32bit
 

using howto_listview_icons;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_listview_icons_Form1:Form
  { 


        public howto_listview_icons_Form1()
        {
            InitializeComponent();
        }

        private void howto_listview_icons_Form1_Load(object sender, EventArgs e)
        {
            // Select the first style.
            cboStyle.SelectedIndex = 0;

            // Initialize the ListView.
            lvwBooks.SmallImageList = imlSmallIcons;
            lvwBooks.LargeImageList = imlLargeIcons;

            // Make the column headers.
            lvwBooks.MakeColumnHeaders(
                "Title", 230, HorizontalAlignment.Left,
                "URL", 220, HorizontalAlignment.Left,
                "ISBN", 130, HorizontalAlignment.Left,
                "Picture", 230, HorizontalAlignment.Left,
                "Pages", 50, HorizontalAlignment.Right,
                "Year", 60, HorizontalAlignment.Right);

            // Add data rows.
            lvwBooks.AddRow(0, "Ready-to-Run Visual Basic Algorithms", "http://www.vb-helper.com/vba.htm", "0-471-24268-3", "http://www.vb-helper.com/vba.jpg", "395", "1998");
            lvwBooks.AddRow(1, "Visual Basic Graphics Programming", "http://www.vb-helper.com/vbgp.htm", "0-472-35599-2", "http://www.vb-helper.com/vbgp.jpg", "712", "2000");
            lvwBooks.AddRow(2, "Advanced Visual Basic Techniques", "http://www.vb-helper.com/avbt.htm", "0-471-18881-6", "http://www.vb-helper.com/avbt.jpg", "440", "1997");
            lvwBooks.AddRow(3, "Custom Controls Library", "http://www.vb-helper.com/ccl.htm", "0-471-24267-5", "http://www.vb-helper.com/ccl.jpg", "684", "1998");
            lvwBooks.AddRow(4, "Ready-to-Run Delphi Algorithms", "http://www.vb-helper.com/da.htm", "0-471-25400-2", "http://www.vb-helper.com/da.jpg", "398", "1998");
            lvwBooks.AddRow(5, "Bug Proofing Visual Basic", "http://www.vb-helper.com/err.htm", "0-471-32351-9", "http://www.vb-helper.com/err.jpg", "397", "1999");
            lvwBooks.AddRow(6, "Ready-to-Run Visual Basic Code Library", "http://www.vb-helper.com/vbcl.htm", "0-471-33345-X", "http://www.vb-helper.com/vbcl.jpg", "424", "1999");
        }

        // Change the ListView's display style.
        private void cboStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboStyle.Text)
            {
                case "Large Icons":
                    lvwBooks.View = View.LargeIcon;
                    break;
                case "Small Icons":
                    lvwBooks.View = View.SmallIcon;
                    break;
                case "List":
                    lvwBooks.View = View.List;
                    break;
                case "Tile":
                    lvwBooks.View = View.Tile;
                    break;
                case "Details":
                    lvwBooks.View = View.Details;
                    break;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_listview_icons_Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.cboStyle = new System.Windows.Forms.ComboBox();
            this.imlSmallIcons = new System.Windows.Forms.ImageList(this.components);
            this.imlLargeIcons = new System.Windows.Forms.ImageList(this.components);
            this.lvwBooks = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "View:";
            // 
            // cboStyle
            // 
            this.cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStyle.FormattingEnabled = true;
            this.cboStyle.Items.AddRange(new object[] {
            "Large Icons",
            "Small Icons",
            "List",
            "Tile",
            "Details"});
            this.cboStyle.Location = new System.Drawing.Point(51, 12);
            this.cboStyle.Name = "cboStyle";
            this.cboStyle.Size = new System.Drawing.Size(121, 21);
            this.cboStyle.TabIndex = 11;
            this.cboStyle.SelectedIndexChanged += new System.EventHandler(this.cboStyle_SelectedIndexChanged);
            // 
            // imlSmallIcons
            // 
            this.imlSmallIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmallIcons.ImageStream")));
            this.imlSmallIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmallIcons.Images.SetKeyName(0, "1_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(1, "2_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(2, "3_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(3, "4_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(4, "5_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(5, "6_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(6, "7_32x32.png");
            // 
            // imlLargeIcons
            // 
            this.imlLargeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLargeIcons.ImageStream")));
            this.imlLargeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlLargeIcons.Images.SetKeyName(0, "1_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(1, "2_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(2, "3_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(3, "4_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(4, "5_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(5, "6_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(6, "7_64x64.png");
            // 
            // lvwBooks
            // 
            this.lvwBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBooks.Location = new System.Drawing.Point(12, 39);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(460, 210);
            this.lvwBooks.TabIndex = 12;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            // 
            // howto_listview_icons_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboStyle);
            this.Controls.Add(this.lvwBooks);
            this.Name = "howto_listview_icons_Form1";
            this.Text = "howto_listview_icons";
            this.Load += new System.EventHandler(this.howto_listview_icons_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStyle;
        internal System.Windows.Forms.ImageList imlSmallIcons;
        internal System.Windows.Forms.ImageList imlLargeIcons;
        private System.Windows.Forms.ListView lvwBooks;
    }
}

