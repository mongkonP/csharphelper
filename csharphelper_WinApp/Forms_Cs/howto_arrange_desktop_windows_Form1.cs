using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_arrange_desktop_windows;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_arrange_desktop_windows_Form1:Form
  { 


        public howto_arrange_desktop_windows_Form1()
        {
            InitializeComponent();
        }

        private void howto_arrange_desktop_windows_Form1_Load(object sender, EventArgs e)
        {
            ShowDesktopWindows();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowDesktopWindows();
        }

        // Display a window's title, saving its handle.
        private struct WindowInfo
        {
            public string Title;
            public IntPtr Handle;

            public WindowInfo(string title, IntPtr handle)
            {
                Title = title;
                Handle = handle;
            }

            // Display the title.
            public override string ToString()
            {
                return Title;
            }
        }

        // Display a list of the desktop windows' titles.
        private void ShowDesktopWindows()
        {
            List<IntPtr> handles;
            List<string> titles;
            DesktopWindowsStuff.GetDesktopWindowHandlesAndTitles(out handles, out titles);

            // Display the window titles.
            lstWindows.Items.Clear();
            for (int i = 0; i < titles.Count; i++)
            {
                Console.WriteLine(titles[i]);
                lstWindows.Items.Add(new WindowInfo(titles[i], handles[i]));
            }
        }

        // Arrange the selected controls.
        private void btnArrange_Click(object sender, EventArgs e)
        {
            if (lstWindows.SelectedItems.Count == 0) return;

            // Get the form's location and dimensions.
            int screen_top = Screen.PrimaryScreen.WorkingArea.Top;
            int screen_left = Screen.PrimaryScreen.WorkingArea.Left;
            int screen_width = Screen.PrimaryScreen.WorkingArea.Width;
            int screen_height = Screen.PrimaryScreen.WorkingArea.Height;

            // See how big the windows should be.
            int window_width = (int)(screen_width / nudCols.Value);
            int window_height = (int)(screen_height / nudRows.Value);

            // Position the windows.
            int window_num = 0;
            int y = screen_top;
            for (int row = 0; row < nudRows.Value; row++)
            {
                int x = screen_left;
                for (int col = 0; col < nudCols.Value; col++)
                {
                    // Restore the window.
                    WindowInfo window_info =
                        (WindowInfo)lstWindows.SelectedItems[window_num];
                    DesktopWindowsStuff.SetWindowPlacement(
                        window_info.Handle,
                        DesktopWindowsStuff.ShowWindowCommands.Restore);

                    // Position window window_num;
                    DesktopWindowsStuff.SetWindowPos(window_info.Handle,
                        x, y, window_width, window_height);

                    // If that was the last window, return.
                    if (++window_num >= lstWindows.SelectedItems.Count) return;
                    x += window_width;
                }
                y += window_height;
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
            this.btnArrange = new System.Windows.Forms.Button();
            this.nudCols = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lstWindows = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            this.SuspendLayout();
            // 
            // btnArrange
            // 
            this.btnArrange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnArrange.Location = new System.Drawing.Point(192, 234);
            this.btnArrange.Name = "btnArrange";
            this.btnArrange.Size = new System.Drawing.Size(75, 23);
            this.btnArrange.TabIndex = 20;
            this.btnArrange.Text = "Arrange";
            this.btnArrange.UseVisualStyleBackColor = true;
            this.btnArrange.Click += new System.EventHandler(this.btnArrange_Click);
            // 
            // nudCols
            // 
            this.nudCols.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudCols.Location = new System.Drawing.Point(138, 237);
            this.nudCols.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudCols.Name = "nudCols";
            this.nudCols.Size = new System.Drawing.Size(35, 20);
            this.nudCols.TabIndex = 19;
            this.nudCols.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Cols:";
            // 
            // nudRows
            // 
            this.nudRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudRows.Location = new System.Drawing.Point(50, 237);
            this.nudRows.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(35, 20);
            this.nudRows.TabIndex = 17;
            this.nudRows.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Rows:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Image = Properties.Resources.Refresh;
            this.btnRefresh.Location = new System.Drawing.Point(316, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(29, 23);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lstWindows
            // 
            this.lstWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWindows.FormattingEnabled = true;
            this.lstWindows.IntegralHeight = false;
            this.lstWindows.Location = new System.Drawing.Point(7, 17);
            this.lstWindows.Name = "lstWindows";
            this.lstWindows.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstWindows.Size = new System.Drawing.Size(329, 211);
            this.lstWindows.Sorted = true;
            this.lstWindows.TabIndex = 15;
            // 
            // howto_arrange_desktop_windows_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 264);
            this.Controls.Add(this.btnArrange);
            this.Controls.Add(this.nudCols);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstWindows);
            this.Name = "howto_arrange_desktop_windows_Form1";
            this.Text = "howto_arrange_desktop_windows";
            this.Load += new System.EventHandler(this.howto_arrange_desktop_windows_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnArrange;
        private System.Windows.Forms.NumericUpDown nudCols;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListBox lstWindows;
    }
}

