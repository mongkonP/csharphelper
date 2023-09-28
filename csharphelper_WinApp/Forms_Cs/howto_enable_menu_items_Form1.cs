using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_enable_menu_items_Form1:Form
  { 


        public howto_enable_menu_items_Form1()
        {
            InitializeComponent();
        }

        private void howto_enable_menu_items_Form1_Load(object sender, EventArgs e)
        {
            cboState.Text = "AZ";
        }

        // Enable and disable items as appropriate.
        private void mnuEdit_DropDownOpening(object sender, EventArgs e)
        {
            EnableMenuItems();
        }
        private void ctxEdit_Opening(object sender, CancelEventArgs e)
        {
            EnableMenuItems();
        }

        private void EnableMenuItems()
        {
            if (ActiveControl is TextBox)
            {
                TextBox txt = ActiveControl as TextBox;
                mnuEditCopy.Enabled = (txt.SelectionLength > 0);
                mnuEditCut.Enabled = (txt.SelectionLength > 0);
                mnuEditPaste.Enabled = Clipboard.ContainsText();
            }
            else
            {
                // Disable all commands.
                mnuEditCopy.Enabled = false;
                mnuEditCut.Enabled = false;
                mnuEditPaste.Enabled = false;
            }

            ctxCopy.Enabled = mnuEditCopy.Enabled;
            ctxCut.Enabled = mnuEditCut.Enabled;
            ctxPaste.Enabled = mnuEditPaste.Enabled;
        }

        // Copy from the currently active TextBox.
        private void mnuEditCopy_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBox)
            {
                TextBox txt = ActiveControl as TextBox;
                txt.Copy();
            }
        }

        // Cut from the currently active TextBox.
        private void mnuEditCut_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBox)
            {
                TextBox txt = ActiveControl as TextBox;
                txt.Cut();
            }
        }

        // Cut into the currently active TextBox.
        private void mnuEditPaste_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBox)
            {
                TextBox txt = ActiveControl as TextBox;
                txt.Paste();
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
            this.cboState = new System.Windows.Forms.ComboBox();
            this.mnuEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.ctxEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCut = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ctxEdit.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Items.AddRange(new object[] {
            "AZ",
            "CA",
            "CO",
            "WY"});
            this.cboState.Location = new System.Drawing.Point(79, 117);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(56, 21);
            this.cboState.TabIndex = 3;
            // 
            // mnuEditCut
            // 
            this.mnuEditCut.Name = "mnuEditCut";
            this.mnuEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuEditCut.Size = new System.Drawing.Size(152, 22);
            this.mnuEditCut.Text = "Cu&t";
            this.mnuEditCut.Click += new System.EventHandler(this.mnuEditCut_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "ZIP:";
            // 
            // txtZip
            // 
            this.txtZip.ContextMenuStrip = this.ctxEdit;
            this.txtZip.Location = new System.Drawing.Point(79, 143);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(56, 20);
            this.txtZip.TabIndex = 4;
            this.txtZip.Text = "87654";
            // 
            // ctxEdit
            // 
            this.ctxEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxCopy,
            this.ctxCut,
            this.ctxPaste});
            this.ctxEdit.Name = "ctxEdit";
            this.ctxEdit.Size = new System.Drawing.Size(145, 70);
            this.ctxEdit.Opening += new System.ComponentModel.CancelEventHandler(this.ctxEdit_Opening);
            // 
            // ctxCopy
            // 
            this.ctxCopy.Name = "ctxCopy";
            this.ctxCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ctxCopy.Size = new System.Drawing.Size(144, 22);
            this.ctxCopy.Text = "&Copy";
            // 
            // ctxCut
            // 
            this.ctxCut.Name = "ctxCut";
            this.ctxCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ctxCut.Size = new System.Drawing.Size(144, 22);
            this.ctxCut.Text = "Cu&t";
            // 
            // ctxPaste
            // 
            this.ctxPaste.Name = "ctxPaste";
            this.ctxPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.ctxPaste.Size = new System.Drawing.Size(144, 22);
            this.ctxPaste.Text = "&Paste";
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditCopy,
            this.mnuEditCut,
            this.mnuEditPaste});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            this.mnuEdit.DropDownOpening += new System.EventHandler(this.mnuEdit_DropDownOpening);
            // 
            // mnuEditCopy
            // 
            this.mnuEditCopy.Name = "mnuEditCopy";
            this.mnuEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuEditCopy.Size = new System.Drawing.Size(152, 22);
            this.mnuEditCopy.Text = "&Copy";
            this.mnuEditCopy.Click += new System.EventHandler(this.mnuEditCopy_Click);
            // 
            // mnuEditPaste
            // 
            this.mnuEditPaste.Name = "mnuEditPaste";
            this.mnuEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuEditPaste.Size = new System.Drawing.Size(152, 22);
            this.mnuEditPaste.Text = "&Paste";
            this.mnuEditPaste.Click += new System.EventHandler(this.mnuEditPaste_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "State:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.ContextMenuStrip = this.ctxEdit;
            this.txtCity.Location = new System.Drawing.Point(79, 91);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(243, 20);
            this.txtCity.TabIndex = 2;
            this.txtCity.Text = "Freedonia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Last Name:";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.ContextMenuStrip = this.ctxEdit;
            this.txtLastName.Location = new System.Drawing.Point(79, 65);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(243, 20);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.Text = "Firefly";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.ContextMenuStrip = this.ctxEdit;
            this.txtFirstName.Location = new System.Drawing.Point(79, 39);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(243, 20);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Text = "Rufus";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(334, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // howto_enable_menu_items_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 176);
            this.Controls.Add(this.cboState);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_enable_menu_items_Form1";
            this.Text = "howto_enable_menu_items";
            this.Load += new System.EventHandler(this.howto_enable_menu_items_Form1_Load);
            this.ctxEdit.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.ContextMenuStrip ctxEdit;
        private System.Windows.Forms.ToolStripMenuItem ctxCopy;
        private System.Windows.Forms.ToolStripMenuItem ctxCut;
        private System.Windows.Forms.ToolStripMenuItem ctxPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuEditPaste;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

