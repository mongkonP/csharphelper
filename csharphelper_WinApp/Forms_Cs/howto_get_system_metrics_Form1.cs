using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_system_metrics_Form1:Form
  { 


        #region System Metrics Declarations
        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(SystemMetric smIndex);
        public enum SystemMetric
        {
            SM_CXSCREEN = 0,  // 0x00
            SM_CYSCREEN = 1,  // 0x01
            SM_CXVSCROLL = 2,  // 0x02
            SM_CYHSCROLL = 3,  // 0x03
            SM_CYCAPTION = 4,  // 0x04
            SM_CXBORDER = 5,  // 0x05
            SM_CYBORDER = 6,  // 0x06
            SM_CXDLGFRAME = 7,  // 0x07
            //SM_CXFIXEDFRAME = 7,  // 0x07
            SM_CYDLGFRAME = 8,  // 0x08
            //SM_CYFIXEDFRAME = 8,  // 0x08
            SM_CYVTHUMB = 9,  // 0x09
            SM_CXHTHUMB = 10, // 0x0A
            SM_CXICON = 11, // 0x0B
            SM_CYICON = 12, // 0x0C
            SM_CXCURSOR = 13, // 0x0D
            SM_CYCURSOR = 14, // 0x0E
            SM_CYMENU = 15, // 0x0F
            SM_CXFULLSCREEN = 16, // 0x10
            SM_CYFULLSCREEN = 17, // 0x11
            SM_CYKANJIWINDOW = 18, // 0x12
            SM_MOUSEPRESENT = 19, // 0x13
            SM_CYVSCROLL = 20, // 0x14
            SM_CXHSCROLL = 21, // 0x15
            SM_DEBUG = 22, // 0x16
            SM_SWAPBUTTON = 23, // 0x17
            SM_CXMIN = 28, // 0x1C
            SM_CYMIN = 29, // 0x1D
            SM_CXSIZE = 30, // 0x1E
            SM_CYSIZE = 31, // 0x1F
            //SM_CXSIZEFRAME = 32, // 0x20
            SM_CXFRAME = 32, // 0x20
            //SM_CYSIZEFRAME = 33, // 0x21
            SM_CYFRAME = 33, // 0x21
            SM_CXMINTRACK = 34, // 0x22
            SM_CYMINTRACK = 35, // 0x23
            SM_CXDOUBLECLK = 36, // 0x24
            SM_CYDOUBLECLK = 37, // 0x25
            SM_CXICONSPACING = 38, // 0x26
            SM_CYICONSPACING = 39, // 0x27
            SM_MENUDROPALIGNMENT = 40, // 0x28
            SM_PENWINDOWS = 41, // 0x29
            SM_DBCSENABLED = 42, // 0x2A
            SM_CMOUSEBUTTONS = 43, // 0x2B
            SM_SECURE = 44, // 0x2C
            SM_CXEDGE = 45, // 0x2D
            SM_CYEDGE = 46, // 0x2E
            SM_CXMINSPACING = 47, // 0x2F
            SM_CYMINSPACING = 48, // 0x30
            SM_CXSMICON = 49, // 0x31
            SM_CYSMICON = 50, // 0x32
            SM_CYSMCAPTION = 51, // 0x33
            SM_CXSMSIZE = 52, // 0x34
            SM_CYSMSIZE = 53, // 0x35
            SM_CXMENUSIZE = 54, // 0x36
            SM_CYMENUSIZE = 55, // 0x37
            SM_ARRANGE = 56, // 0x38
            SM_CXMINIMIZED = 57, // 0x39
            SM_CYMINIMIZED = 58, // 0x3A
            SM_CXMAXTRACK = 59, // 0x3B
            SM_CYMAXTRACK = 60, // 0x3C
            SM_CXMAXIMIZED = 61, // 0x3D
            SM_CYMAXIMIZED = 62, // 0x3E
            SM_NETWORK = 63, // 0x3F
            SM_CLEANBOOT = 67, // 0x43
            SM_CXDRAG = 68, // 0x44
            SM_CYDRAG = 69, // 0x45
            SM_SHOWSOUNDS = 70, // 0x46
            SM_CXMENUCHECK = 71, // 0x47
            SM_CYMENUCHECK = 72, // 0x48
            SM_SLOWMACHINE = 73, // 0x49
            SM_MIDEASTENABLED = 74, // 0x4A
            SM_MOUSEWHEELPRESENT = 75, // 0x4B
            SM_XVIRTUALSCREEN = 76, // 0x4C
            SM_YVIRTUALSCREEN = 77, // 0x4D
            SM_CXVIRTUALSCREEN = 78, // 0x4E
            SM_CYVIRTUALSCREEN = 79, // 0x4F
            SM_CMONITORS = 80, // 0x50
            SM_SAMEDISPLAYFORMAT = 81, // 0x51
            SM_IMMENABLED = 82, // 0x52
            SM_CXFOCUSBORDER = 83, // 0x53
            SM_CYFOCUSBORDER = 84, // 0x54
            SM_TABLETPC = 86, // 0x56
            SM_MEDIACENTER = 87, // 0x57
            SM_STARTER = 88, // 0x58
            SM_SERVERR2 = 89, // 0x59
            SM_MOUSEHORIZONTALWHEELPRESENT = 91, // 0x5B
            SM_CXPADDEDBORDER = 92, // 0x5C
            SM_DIGITIZER = 94, // 0x5E
            SM_MAXIMUMTOUCHES = 95, // 0x5F

            SM_REMOTESESSION = 0x1000, // 0x1000
            SM_SHUTTINGDOWN = 0x2000, // 0x2000
            SM_REMOTECONTROL = 0x2001, // 0x2001
        }
        #endregion System Metrics Declarations

        public howto_get_system_metrics_Form1()
        {
            InitializeComponent();
        }

        // Display some useful metrics.
        private void howto_get_system_metrics_Form1_Load(object sender, EventArgs e)
        {
            AddValue(SystemMetric.SM_CXSCREEN);
            AddValue(SystemMetric.SM_CYSCREEN);
            AddValue(SystemMetric.SM_CXVSCROLL);
            AddValue(SystemMetric.SM_CYHSCROLL);
            AddValue(SystemMetric.SM_CYCAPTION);
            AddValue(SystemMetric.SM_CXBORDER);
            AddValue(SystemMetric.SM_CYBORDER);
            AddValue(SystemMetric.SM_CXDLGFRAME);
            AddValue(SystemMetric.SM_CYDLGFRAME);
            AddValue(SystemMetric.SM_CYVTHUMB);
            AddValue(SystemMetric.SM_CXHTHUMB);
            AddValue(SystemMetric.SM_CXICON);
            AddValue(SystemMetric.SM_CYICON);
            AddValue(SystemMetric.SM_CXCURSOR);
            AddValue(SystemMetric.SM_CYCURSOR);
            AddValue(SystemMetric.SM_CYMENU);
            AddValue(SystemMetric.SM_CXFULLSCREEN);
            AddValue(SystemMetric.SM_CYFULLSCREEN);
            AddValue(SystemMetric.SM_CYKANJIWINDOW);
            AddValue(SystemMetric.SM_MOUSEPRESENT);
            AddValue(SystemMetric.SM_CYVSCROLL);
            AddValue(SystemMetric.SM_CXHSCROLL);
            AddValue(SystemMetric.SM_DEBUG);
            AddValue(SystemMetric.SM_SWAPBUTTON);
            AddValue(SystemMetric.SM_CXMIN);
            AddValue(SystemMetric.SM_CYMIN);
            AddValue(SystemMetric.SM_CXSIZE);
            AddValue(SystemMetric.SM_CYSIZE);
            AddValue(SystemMetric.SM_CXFRAME);
            AddValue(SystemMetric.SM_CYFRAME);
            AddValue(SystemMetric.SM_CXMINTRACK);
            AddValue(SystemMetric.SM_CYMINTRACK);
            AddValue(SystemMetric.SM_CXDOUBLECLK);
            AddValue(SystemMetric.SM_CYDOUBLECLK);
            AddValue(SystemMetric.SM_CXICONSPACING);
            AddValue(SystemMetric.SM_CYICONSPACING);
            AddValue(SystemMetric.SM_MENUDROPALIGNMENT);
            AddValue(SystemMetric.SM_PENWINDOWS);
            AddValue(SystemMetric.SM_DBCSENABLED);
            AddValue(SystemMetric.SM_CMOUSEBUTTONS);
            AddValue(SystemMetric.SM_SECURE);
            AddValue(SystemMetric.SM_CXEDGE);
            AddValue(SystemMetric.SM_CYEDGE);
            AddValue(SystemMetric.SM_CXMINSPACING);
            AddValue(SystemMetric.SM_CYMINSPACING);
            AddValue(SystemMetric.SM_CXSMICON);
            AddValue(SystemMetric.SM_CYSMICON);
            AddValue(SystemMetric.SM_CYSMCAPTION);
            AddValue(SystemMetric.SM_CXSMSIZE);
            AddValue(SystemMetric.SM_CYSMSIZE);
            AddValue(SystemMetric.SM_CXMENUSIZE);
            AddValue(SystemMetric.SM_CYMENUSIZE);
            AddValue(SystemMetric.SM_ARRANGE);
            AddValue(SystemMetric.SM_CXMINIMIZED);
            AddValue(SystemMetric.SM_CYMINIMIZED);
            AddValue(SystemMetric.SM_CXMAXTRACK);
            AddValue(SystemMetric.SM_CYMAXTRACK);
            AddValue(SystemMetric.SM_CXMAXIMIZED);
            AddValue(SystemMetric.SM_CYMAXIMIZED);
            AddValue(SystemMetric.SM_NETWORK);
            AddValue(SystemMetric.SM_CLEANBOOT);
            AddValue(SystemMetric.SM_CXDRAG);
            AddValue(SystemMetric.SM_CYDRAG);
            AddValue(SystemMetric.SM_SHOWSOUNDS);
            AddValue(SystemMetric.SM_CXMENUCHECK);
            AddValue(SystemMetric.SM_CYMENUCHECK);
            AddValue(SystemMetric.SM_SLOWMACHINE);
            AddValue(SystemMetric.SM_MIDEASTENABLED);
            AddValue(SystemMetric.SM_MOUSEWHEELPRESENT);
            AddValue(SystemMetric.SM_XVIRTUALSCREEN);
            AddValue(SystemMetric.SM_YVIRTUALSCREEN);
            AddValue(SystemMetric.SM_CXVIRTUALSCREEN);
            AddValue(SystemMetric.SM_CYVIRTUALSCREEN);
            AddValue(SystemMetric.SM_CMONITORS);
            AddValue(SystemMetric.SM_SAMEDISPLAYFORMAT);
            AddValue(SystemMetric.SM_IMMENABLED);
            AddValue(SystemMetric.SM_CXFOCUSBORDER);
            AddValue(SystemMetric.SM_CYFOCUSBORDER);
            AddValue(SystemMetric.SM_TABLETPC);
            AddValue(SystemMetric.SM_MEDIACENTER);
            AddValue(SystemMetric.SM_STARTER);
            AddValue(SystemMetric.SM_SERVERR2);
            AddValue(SystemMetric.SM_MOUSEHORIZONTALWHEELPRESENT);
            AddValue(SystemMetric.SM_CXPADDEDBORDER);
            AddValue(SystemMetric.SM_DIGITIZER);
            AddValue(SystemMetric.SM_MAXIMUMTOUCHES);

            AddValue(SystemMetric.SM_REMOTESESSION);
            AddValue(SystemMetric.SM_SHUTTINGDOWN);
            AddValue(SystemMetric.SM_REMOTECONTROL);
        }

        // Add a value to the ListView.
        private void AddValue(SystemMetric metric)
        {
            ListViewItem item = lvwMetrics.Items.Add(metric.ToString());
            item.SubItems.Add(GetSystemMetrics(metric).ToString());
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
            this.lvwMetrics = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwMetrics
            // 
            this.lvwMetrics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMetrics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwMetrics.FullRowSelect = true;
            this.lvwMetrics.Location = new System.Drawing.Point(12, 12);
            this.lvwMetrics.Name = "lvwMetrics";
            this.lvwMetrics.Size = new System.Drawing.Size(300, 237);
            this.lvwMetrics.TabIndex = 1;
            this.lvwMetrics.UseCompatibleStateImageBehavior = false;
            this.lvwMetrics.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Metric";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 70;
            // 
            // howto_get_system_metrics_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 261);
            this.Controls.Add(this.lvwMetrics);
            this.Name = "howto_get_system_metrics_Form1";
            this.Text = "howto_get_system_metrics";
            this.Load += new System.EventHandler(this.howto_get_system_metrics_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwMetrics;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

