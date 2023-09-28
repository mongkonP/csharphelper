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
     public partial class howto_remove_textbox_context_menu_Form1:Form
  { 


        public howto_remove_textbox_context_menu_Form1()
        {
            InitializeComponent();
        }

        // Copy from the currently active TextBox.
        private void ctxCopy_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBox)
            {
                TextBox txt = ActiveControl as TextBox;
                txt.Copy();
            }
        }

        // Cut from the currently active TextBox.
        private void ctxCut_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBox)
            {
                TextBox txt = ActiveControl as TextBox;
                txt.Cut();
            }
        }

        // Cut into the currently active TextBox.
        private void ctxPaste_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBox)
            {
                TextBox txt = ActiveControl as TextBox;
                txt.Paste();
            }
        }

        // Enable and disable items as appropriate.
        private void ctxEdit_Opening(object sender, CancelEventArgs e)
        {
            if (ActiveControl is TextBox)
            {
                TextBox txt = ActiveControl as TextBox;
                ctxCopy.Enabled = (txt.SelectionLength > 0);
                ctxCut.Enabled = (txt.SelectionLength > 0);
                ctxPaste.Enabled = Clipboard.ContainsText();
            }
            else
            {
                // Disable all commands.
                ctxCopy.Enabled = false;
                ctxCut.Enabled = false;
                ctxPaste.Enabled = false;
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
            this.ctxPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNewContextMenu = new System.Windows.Forms.TextBox();
            this.ctxEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCut = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNormal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoContextMenu = new System.Windows.Forms.TextBox();
            this.ctxEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctxPaste
            // 
            this.ctxPaste.Name = "ctxPaste";
            this.ctxPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.ctxPaste.Size = new System.Drawing.Size(152, 22);
            this.ctxPaste.Text = "&Paste";
            this.ctxPaste.Click += new System.EventHandler(this.ctxPaste_Click);
            // 
            // txtNewContextMenu
            // 
            this.txtNewContextMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewContextMenu.ContextMenuStrip = this.ctxEdit;
            this.txtNewContextMenu.Location = new System.Drawing.Point(119, 40);
            this.txtNewContextMenu.Name = "txtNewContextMenu";
            this.txtNewContextMenu.Size = new System.Drawing.Size(248, 20);
            this.txtNewContextMenu.TabIndex = 8;
            // 
            // ctxEdit
            // 
            this.ctxEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxCopy,
            this.ctxCut,
            this.ctxPaste});
            this.ctxEdit.Name = "contextMenuStrip1";
            this.ctxEdit.Size = new System.Drawing.Size(145, 70);
            this.ctxEdit.Opening += new System.ComponentModel.CancelEventHandler(this.ctxEdit_Opening);
            // 
            // ctxCopy
            // 
            this.ctxCopy.Name = "ctxCopy";
            this.ctxCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ctxCopy.Size = new System.Drawing.Size(152, 22);
            this.ctxCopy.Text = "&Copy";
            this.ctxCopy.Click += new System.EventHandler(this.ctxCopy_Click);
            // 
            // ctxCut
            // 
            this.ctxCut.Name = "ctxCut";
            this.ctxCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ctxCut.Size = new System.Drawing.Size(152, 22);
            this.ctxCut.Text = "Cu&t";
            this.ctxCut.Click += new System.EventHandler(this.ctxCut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "New Context Menu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "No Context Menu:";
            // 
            // txtNormal
            // 
            this.txtNormal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNormal.Location = new System.Drawing.Point(119, 14);
            this.txtNormal.Name = "txtNormal";
            this.txtNormal.Size = new System.Drawing.Size(248, 20);
            this.txtNormal.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Normal:";
            // 
            // txtNoContextMenu
            // 
            this.txtNoContextMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoContextMenu.Location = new System.Drawing.Point(119, 66);
            this.txtNoContextMenu.Name = "txtNoContextMenu";
            this.txtNoContextMenu.ShortcutsEnabled = false;
            this.txtNoContextMenu.Size = new System.Drawing.Size(248, 20);
            this.txtNoContextMenu.TabIndex = 10;
            // 
            // howto_remove_textbox_context_menu_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 96);
            this.Controls.Add(this.txtNoContextMenu);
            this.Controls.Add(this.txtNewContextMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNormal);
            this.Controls.Add(this.label1);
            this.Name = "howto_remove_textbox_context_menu_Form1";
            this.Text = "howto_remove_textbox_context_menu";
            this.ctxEdit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem ctxPaste;
        private System.Windows.Forms.TextBox txtNewContextMenu;
        private System.Windows.Forms.ContextMenuStrip ctxEdit;
        private System.Windows.Forms.ToolStripMenuItem ctxCopy;
        private System.Windows.Forms.ToolStripMenuItem ctxCut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNormal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoContextMenu;
    }
}

