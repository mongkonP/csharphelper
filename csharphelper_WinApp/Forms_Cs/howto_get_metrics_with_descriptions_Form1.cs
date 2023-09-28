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
     public partial class howto_get_metrics_with_descriptions_Form1:Form
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

        public howto_get_metrics_with_descriptions_Form1()
        {
            InitializeComponent();
        }

        // Display some useful metrics.
        private void howto_get_metrics_with_descriptions_Form1_Load(object sender, EventArgs e)
        {
            lvwMetrics.ShowItemToolTips = true;

            AddValue(SystemMetric.SM_CXSCREEN, "Primary screen width.");
            AddValue(SystemMetric.SM_CYSCREEN, "Primary screen height.");
            AddValue(SystemMetric.SM_CXVSCROLL, "Width of vertical scroll bar.");
            AddValue(SystemMetric.SM_CYHSCROLL, "Height of horizontal scroll bar.");
            AddValue(SystemMetric.SM_CYCAPTION, "Height of caption area.");
            AddValue(SystemMetric.SM_CXBORDER, "Window border width.");
            AddValue(SystemMetric.SM_CYBORDER, "Window border height.");
            AddValue(SystemMetric.SM_CXDLGFRAME, "Thickness of frame around a window that has a caption but is not sizable. SM_CXFIXEDFRAME is the height of the horizontal border and SM_CYFIXEDFRAME is the width of the vertical border.");
            AddValue(SystemMetric.SM_CYDLGFRAME, "Thickness of frame around a window that has a caption but is not sizable. SM_CXFIXEDFRAME is the height of the horizontal border and SM_CYFIXEDFRAME is the width of the vertical border.");
            AddValue(SystemMetric.SM_CYVTHUMB, "Height of thumb box in a vertical scroll bar.");
            AddValue(SystemMetric.SM_CXHTHUMB, "Width of thumb box in a horizontal scroll bar.");
            AddValue(SystemMetric.SM_CXICON, "Default width of an icon.");
            AddValue(SystemMetric.SM_CYICON, "Default height of an icon.");
            AddValue(SystemMetric.SM_CXCURSOR, "The width of a cursor.");
            AddValue(SystemMetric.SM_CYCURSOR, "The height of a cursor.");
            AddValue(SystemMetric.SM_CYMENU, "Height of single-line menu bar.");
            AddValue(SystemMetric.SM_CXFULLSCREEN, "Width of client area for full-screen window.");
            AddValue(SystemMetric.SM_CYFULLSCREEN, "Height of client area for full-screen window.");
            AddValue(SystemMetric.SM_CYKANJIWINDOW, "For double-byte character set systems, height of the Kanji window.");
            AddValue(SystemMetric.SM_MOUSEPRESENT, "Nonzero if a mouse is installed, 0 if no mouse is installed.");
            AddValue(SystemMetric.SM_CYVSCROLL, "Height of arrow bitmap on a vertical scroll bar.");
            AddValue(SystemMetric.SM_CXHSCROLL, "Width of arrow bitmap on a horizontal scroll bar.");
            AddValue(SystemMetric.SM_DEBUG, "Nonzero if debug version of User.exe is installed; 0 otherwise.");
            AddValue(SystemMetric.SM_SWAPBUTTON, "Nonzero if left and right mouse buttons are reversed; 0 otherwise.");
            AddValue(SystemMetric.SM_CXMIN, "Minimum width of a window.");
            AddValue(SystemMetric.SM_CYMIN, "Minimum height of a window.");
            AddValue(SystemMetric.SM_CXSIZE, "Width of a button in a window's caption or title bar.");
            AddValue(SystemMetric.SM_CYSIZE, "Height of a button in a window's caption or title bar.");
            AddValue(SystemMetric.SM_CXFRAME, "Thickness of sizing border for resizable window. SM_CXSIZEFRAME = width of horizontal border. SM_CYSIZEFRAME = height of vertical border.");
            AddValue(SystemMetric.SM_CYFRAME, "Thickness of sizing border for resizable window. SM_CXSIZEFRAME = width of horizontal border. SM_CYSIZEFRAME = height of vertical border.");
            AddValue(SystemMetric.SM_CXMINTRACK, "Minimum tracking width of a window. The user cannot drag the window frame to a size smaller than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.");
            AddValue(SystemMetric.SM_CYMINTRACK, "Minimum tracking height of a window. The user cannot drag the window frame to a size smaller than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.");
            AddValue(SystemMetric.SM_CXDOUBLECLK, "Width of double-click rectangle. The second click must be within the rectangle.");
            AddValue(SystemMetric.SM_CYDOUBLECLK, "Height of double-click rectangle. The second click must be within the rectangle.");
            AddValue(SystemMetric.SM_CXICONSPACING, "Width of large icon view grid cell.");
            AddValue(SystemMetric.SM_CYICONSPACING, "Height of large icon view grid cell.");
            AddValue(SystemMetric.SM_MENUDROPALIGNMENT, "Nonzero if drop-down menus are right-aligned with the menu-bar item; zero if the menus are left-aligned.");
            AddValue(SystemMetric.SM_PENWINDOWS, "Nonzero if Microsoft Windows for Pen computing extensions are installed; zero otherwise.");
            AddValue(SystemMetric.SM_DBCSENABLED, "Nonzero if User32.dll supports DBCS; zero otherwise. (WinMe/95/98): Unicode.");
            AddValue(SystemMetric.SM_CMOUSEBUTTONS, "# mouse buttons.");
            AddValue(SystemMetric.SM_SECURE, "Nonzero if security is present; zero otherwise.");
            AddValue(SystemMetric.SM_CXEDGE, "Width of a 3-D border.");
            AddValue(SystemMetric.SM_CYEDGE, "Height of a 3-D border.");
            AddValue(SystemMetric.SM_CXMINSPACING, "Width of grid cell for minimized windows.");
            AddValue(SystemMetric.SM_CYMINSPACING, "Height of grid cell for minimized windows.");
            AddValue(SystemMetric.SM_CXSMICON, "Recommended width of small icon. Typically these appear in window captions and small icon view.");
            AddValue(SystemMetric.SM_CYSMICON, "Recommended height of small icon. Typically these appear in window captions and small icon view.");
            AddValue(SystemMetric.SM_CYSMCAPTION, "Height of small caption.");
            AddValue(SystemMetric.SM_CXSMSIZE, "Width of small caption buttons.");
            AddValue(SystemMetric.SM_CYSMSIZE, "Height of small caption buttons.");
            AddValue(SystemMetric.SM_CXMENUSIZE, "Width of menu bar buttons (e.g. child window close button in MDI).");
            AddValue(SystemMetric.SM_CYMENUSIZE, "Height of menu bar buttons (e.g. child window close button in MDI).");
            AddValue(SystemMetric.SM_ARRANGE, "How the system arranges minimized windows.");
            AddValue(SystemMetric.SM_CXMINIMIZED, "Width of a minimized window.");
            AddValue(SystemMetric.SM_CYMINIMIZED, "Height of a minimized window.");
            AddValue(SystemMetric.SM_CXMAXTRACK, "Default maximum width of window with caption and sizing borders.");
            AddValue(SystemMetric.SM_CYMAXTRACK, "Default maximum height of window with caption and sizing borders.");
            AddValue(SystemMetric.SM_CXMAXIMIZED, "Default width of maximized top-level window.");
            AddValue(SystemMetric.SM_CYMAXIMIZED, "Default height of maximized top-level window.");
            AddValue(SystemMetric.SM_NETWORK, "Least significant bit set if network is present; cleared otherwise.");
            AddValue(SystemMetric.SM_CLEANBOOT, "How the system started. 0=Normal, 1=Fail-safe, 2=Fail-safe w/network.");
            AddValue(SystemMetric.SM_CXDRAG, "Width of rectangle that begins a drag.");
            AddValue(SystemMetric.SM_CYDRAG, "Height of rectangle that begins a drag.");
            AddValue(SystemMetric.SM_SHOWSOUNDS, "Nonzero if user requires visual version of sounds; zero otherwise.");
            AddValue(SystemMetric.SM_CXMENUCHECK, "Width of default menu check mark bitmap.");
            AddValue(SystemMetric.SM_CYMENUCHECK, "Height of default menu check mark bitmap.");
            AddValue(SystemMetric.SM_SLOWMACHINE, "Nonzero if computer has slow processor; zero otherwise.");
            AddValue(SystemMetric.SM_MIDEASTENABLED, "Nonzero if system enabled for Hebrew and Arabic languages; zero otherwise.");
            AddValue(SystemMetric.SM_MOUSEWHEELPRESENT, "Nonzero if a mouse with a vertical scroll wheel is installed; otherwise 0.");
            AddValue(SystemMetric.SM_XVIRTUALSCREEN, "Coordinates for left side of virtual screen. The virtual screen is the bounding rectangle of all display monitors.");
            AddValue(SystemMetric.SM_YVIRTUALSCREEN, "Coordinates for top of virtual screen. The virtual screen is the bounding rectangle of all display monitors.");
            AddValue(SystemMetric.SM_CXVIRTUALSCREEN, "Width of the virtual screen. The virtual screen is the bounding rectangle of all display monitors.");
            AddValue(SystemMetric.SM_CYVIRTUALSCREEN, "Height of the virtual screen. The virtual screen is the bounding rectangle of all display monitors.");
            AddValue(SystemMetric.SM_CMONITORS, "# monitors.");
            AddValue(SystemMetric.SM_SAMEDISPLAYFORMAT, "Nonzero if all monitors have same color format; zero otherwise.");
            AddValue(SystemMetric.SM_IMMENABLED, "Nonzero if Input Method Manager/Input Method Editor features are enabled; zero otherwise.");
            AddValue(SystemMetric.SM_CXFOCUSBORDER, "Width of sides of focus rectangle drawn by DrawFocusRect.");
            AddValue(SystemMetric.SM_CYFOCUSBORDER, "Height of sides of focus rectangle drawn by DrawFocusRect.");
            AddValue(SystemMetric.SM_TABLETPC, "Nonzero if OS is Windows XP Tablet PC edition, or if OS is Windows Vista or Windows 7 and Tablet PC Input service is started; zero otherwise.");
            AddValue(SystemMetric.SM_MEDIACENTER, "Nonzero if OS is Windows XP, Media Center Edition; zero otherwise.");
            AddValue(SystemMetric.SM_STARTER, "Nonzero if OS is Windows 7 Starter Edition, Windows Vista Starter, or Windows XP Starter Edition; zero otherwise.");
            AddValue(SystemMetric.SM_SERVERR2, "Build number if OS is Windows Server 2003 R2; zero otherwise.");
            AddValue(SystemMetric.SM_MOUSEHORIZONTALWHEELPRESENT, "Nonzero if a mouse with a horizontal scroll wheel is installed; otherwise 0.");
            AddValue(SystemMetric.SM_CXPADDEDBORDER, "The amount of border padding for captioned windows.");
            AddValue(SystemMetric.SM_DIGITIZER, "Nonzero if OS is Windows 7 or Windows Server 2008 R2 and Tablet PC Input service is started; zero otherwise.");
            AddValue(SystemMetric.SM_MAXIMUMTOUCHES, "The aggregate maximum of the maximum number of contacts supported by every digitizer in the system.");

            AddValue(SystemMetric.SM_REMOTESESSION, "Nonzero if the calling process is associated with a Terminal Services client session; zero otherwise");
            AddValue(SystemMetric.SM_SHUTTINGDOWN, "Nonzero if the session is shutting down; zero otherwise.");
            AddValue(SystemMetric.SM_REMOTECONTROL, "Nonzero if the session is remotely controlled; zero otherwise.");
        }

        // Add a value to the ListView.
        private void AddValue(SystemMetric metric)
        {
            ListViewItem item = lvwMetrics.Items.Add(metric.ToString());
            item.SubItems.Add(GetSystemMetrics(metric).ToString());
        }
        private void AddValue(SystemMetric metric, string descr)
        {
            ListViewItem item = lvwMetrics.Items.Add(metric.ToString());
            item.SubItems.Add(GetSystemMetrics(metric).ToString());
            item.SubItems.Add(descr);
            item.ToolTipText = descr;
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
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lvwMetrics = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lvwMetrics
            // 
            this.lvwMetrics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMetrics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwMetrics.FullRowSelect = true;
            this.lvwMetrics.Location = new System.Drawing.Point(12, 12);
            this.lvwMetrics.Name = "lvwMetrics";
            this.lvwMetrics.Size = new System.Drawing.Size(385, 240);
            this.lvwMetrics.TabIndex = 2;
            this.lvwMetrics.UseCompatibleStateImageBehavior = false;
            this.lvwMetrics.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Metric";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Meaning";
            this.columnHeader3.Width = 178;
            // 
            // howto_get_metrics_with_descriptions_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 264);
            this.Controls.Add(this.lvwMetrics);
            this.Name = "howto_get_metrics_with_descriptions_Form1";
            this.Text = "howto_get_metrics_with_descriptions";
            this.Load += new System.EventHandler(this.howto_get_metrics_with_descriptions_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvwMetrics;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

