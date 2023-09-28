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
     public partial class howto_set_listbox_textbox_tabs_Form1:Form
  { 


        public howto_set_listbox_textbox_tabs_Form1()
        {
            InitializeComponent();
        }

        private void howto_set_listbox_textbox_tabs_Form1_Load(object sender, EventArgs e)
        {
            // Set the ListBox tabs.
            SetListBoxTabs(lstCars, new int[] { 120, 170, 220 });
            SetListBoxTabs(lstCars, new int[] { 120, 170, 220 });
            
            // Set the TextBox tabs.
            SetTextBoxTabs(txtCars, new int[] { 120, 170, 220 });

            // Make some data.
            // Source: http://www.thesupercars.org/fastest-cars/fastest-cars-in-the-world-top-10-list.
            AddData("SSC Ultimate Aero", 257, 1183, 654400);
            AddData("Bugatti Veyron", 253, 1001, 1700000);
            AddData("Saleen S7 Twin-Turbo", 248, 750, 555000);
            AddData("Koenigsegg CCX", 245, 806, 545568);
            AddData("McLaren F1", 240, 637, 970000);
            AddData("Ferrari Enzo", 217, 660, 670000);
            AddData("Jaguar XJ220", 217, 542, 650000);
            AddData("Pagani Zonda F", 215, 650, 667321);
            AddData("Lamborghini Murcielago LP640", 211, 640, 430000);
            AddData("Porsche Carrera GT", 205, 612, 440000);
        }

        // Add some data to all three controls.
        private void AddData(string name, int mph, int hp, decimal price)
        {
            // Build a tab-delimited string.
            string txt = name + "\t" + mph.ToString() + " mph\t" +
                hp.ToString() + " hp\t" + price.ToString("C");

            // Display in the ListBox and first TextBox.
            lstCars.Items.Add(txt);
            txtCars.Text += txt + "\r\n";

            // Display formatted.
            txtFormattedCars.Text +=
                string.Format("{0,-30}{1,7} mph{2,7} hp{3,15:C}\r\n",
                name, mph, hp, price);
        }

        // Set tab stops inside a ListBox.
        private void SetListBoxTabs(ListBox lst, IEnumerable<int> tabs)
        {
            // Make sure the control will use them.
            lst.UseTabStops = true;
            lst.UseCustomTabOffsets = true;

            // Get the control's tab offset collection.
            ListBox.IntegerCollection offsets = lstCars.CustomTabOffsets;

            // Define the tabs.
            foreach (int tab in tabs)
            {
                offsets.Add(tab);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, Int32 wParam, int[] lParam);
        private const uint EM_SETTABSTOPS = 0xCB;

        // Set tab stops inside a TextBox.
        private void SetTextBoxTabs(TextBox txt, int[] tabs)
        {
            SendMessage(txt.Handle, EM_SETTABSTOPS, tabs.Length, tabs);
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
            this.lstCars = new System.Windows.Forms.ListBox();
            this.txtCars = new System.Windows.Forms.TextBox();
            this.txtFormattedCars = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstCars
            // 
            this.lstCars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCars.FormattingEnabled = true;
            this.lstCars.Location = new System.Drawing.Point(12, 12);
            this.lstCars.Name = "lstCars";
            this.lstCars.Size = new System.Drawing.Size(507, 147);
            this.lstCars.TabIndex = 0;
            // 
            // txtCars
            // 
            this.txtCars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCars.Location = new System.Drawing.Point(12, 165);
            this.txtCars.Multiline = true;
            this.txtCars.Name = "txtCars";
            this.txtCars.Size = new System.Drawing.Size(507, 147);
            this.txtCars.TabIndex = 1;
            // 
            // txtFormattedCars
            // 
            this.txtFormattedCars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFormattedCars.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormattedCars.Location = new System.Drawing.Point(12, 318);
            this.txtFormattedCars.Multiline = true;
            this.txtFormattedCars.Name = "txtFormattedCars";
            this.txtFormattedCars.Size = new System.Drawing.Size(507, 169);
            this.txtFormattedCars.TabIndex = 2;
            // 
            // howto_set_listbox_textbox_tabs_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 499);
            this.Controls.Add(this.txtFormattedCars);
            this.Controls.Add(this.txtCars);
            this.Controls.Add(this.lstCars);
            this.Name = "howto_set_listbox_textbox_tabs_Form1";
            this.Text = "howto_set_listbox_textbox_tabs";
            this.Load += new System.EventHandler(this.howto_set_listbox_textbox_tabs_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCars;
        private System.Windows.Forms.TextBox txtCars;
        private System.Windows.Forms.TextBox txtFormattedCars;
    }
}

