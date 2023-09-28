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
     public partial class howto_preview_textbox_float_Form1:Form
  { 


        public howto_preview_textbox_float_Form1()
        {
            InitializeComponent();
        }

        // Attach the TextBox's ContextMenuStrip.
        private void howto_preview_textbox_float_Form1_Load(object sender, EventArgs e)
        {
            txtFloat.ContextMenuStrip = ctxTextBox;
        }

        // Possible change types for the TextBox's value.
        private enum EditType
        {
            NewCharacter,
            Cut,
            Paste,
            Delete,
            Backspace,
        }

        // Handle normal characters.
        private void txtFloat_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Do nothing for special characters.
            if ((e.KeyChar < ' ') || (e.KeyChar > '~')) return;

            // See if the change is valid.
            e.Handled = ShouldCancelTextBoxEvent(
                txtFloat, EditType.NewCharacter, e.KeyChar, false);
        }

        // Handle Ctrl+A, Ctrl+X, Ctrl+V, Shift+Insert,
        // Shift+Delete, Delete, and Backspace.
        private void txtFloat_KeyDown(object sender, KeyEventArgs e)
        {
            // Look for the necessary key combinations.
            bool cancel_event;
            if (e.Control && (e.KeyCode == Keys.A))
            {
                // Handle this one just for convenience.
                txtFloat.Select(0, txtFloat.Text.Length);
                cancel_event = true;
            }
            else if (e.Control && (e.KeyCode == Keys.X))
            {
                cancel_event = ShouldCancelTextBoxEvent(txtFloat, EditType.Cut, ' ', false);
            }
            else if (e.Control && (e.KeyCode == Keys.V))
            {
                cancel_event = ShouldCancelTextBoxEvent(txtFloat, EditType.Paste, ' ', false);
            }
            else if (e.Shift && (e.KeyCode == Keys.Insert))
            {
                cancel_event = ShouldCancelTextBoxEvent(txtFloat, EditType.Paste, ' ', false);
            }
            else if (e.Shift && (e.KeyCode == Keys.Delete))
            {
                cancel_event = ShouldCancelTextBoxEvent(txtFloat, EditType.Cut, ' ', false);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                cancel_event = ShouldCancelTextBoxEvent(txtFloat, EditType.Delete, ' ', false);
            }
            else if (e.KeyCode == Keys.Back)
            {
                cancel_event = ShouldCancelTextBoxEvent(txtFloat, EditType.Backspace, ' ', false);
            }
            else
            {
                // We didn't handle the event.
                // Let the event proceed normally.
                cancel_event = false;
            }

            // If we handled it, stop the event.
            if (cancel_event)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Return true if the value is a valid integer.
        private bool ValueIsValid(string text_value)
        {
            // Do not allow spaces.
            if (text_value.Contains(' ')) return false;

            // Allow a blank value.
            if (text_value.Length == 0) return true;

            // If the text doesn't end in a digit, add a digit
            // to see if it is a valid prefix of a float.
            if (!char.IsDigit(text_value, text_value.Length - 1))
                text_value += "0";

            // See if the text parses.
            float test_value;
            return float.TryParse(text_value, out test_value);
        }

        // Compose the TextBox's new value and call ValueIsValid to see if it is valid.
        //
        // If the change is invalid, beep and return true to indicate the event should be canceled.
        //
        // If the change is valid and assign_value is true, assign the value to the TextBox and
        // then return true to indicate that the event is no longer needed.
        //
        // If the change is valid and assign_value is false,
        // then return false to indicate that the event still needs to be handled.
        private bool ShouldCancelTextBoxEvent(TextBox txt, EditType edit_type, char new_char, bool assign_value)
        {
            // Get the new value.
            int selection_start;
            string new_value = GetNewTextBoxValue(txtFloat, edit_type, new_char, out selection_start);

            // See if it's a valid value.
            if (ValueIsValid(new_value))
            {
                // It's okay. Accept it.
                if (assign_value)
                {
                    txt.Text = new_value;
                    txt.Select(selection_start, 0);
                    return true;
                }
                return false;
            }
            else
            {
                // The new value is invalid. Complain.
                System.Media.SystemSounds.Beep.Play();
                return true;
            }
        }

        // Return the value that the TextBox will have if this change is allowed.
        private string GetNewTextBoxValue(TextBox txt, EditType edit_type, char new_char, out int selection_start)
        {
            // Get the pieces of the current text.
            selection_start = txt.SelectionStart;
            string current_text = txt.Text;
            string left_text = current_text.Substring(0, selection_start);
            string selected_text = txt.SelectedText;
            string right_text = current_text.Substring(selection_start + txt.SelectionLength);

            // Compose the result.
            string result = "";
            switch (edit_type)
            {
                case EditType.NewCharacter:
                    result = left_text + new_char + right_text;
                    selection_start++;
                    break;
                case EditType.Cut:
                    result = left_text + right_text;
                    if (txt.SelectionLength > 0)
                    {
                        Clipboard.Clear();
                        Clipboard.SetText(selected_text);
                    }
                    break;
                case EditType.Paste:
                    if (Clipboard.ContainsText())
                    {
                        selected_text = Clipboard.GetText();
                        selection_start += selected_text.Length;
                    }
                    result = left_text + selected_text + right_text;
                    break;
                case EditType.Delete:
                    if (selected_text.Length == 0)
                    {
                        // Remove the following character.
                        if (right_text.Length > 0)
                            right_text = right_text.Substring(1);
                    }
                    else
                    {
                        // Remove the selected text.
                        selected_text = "";
                    }
                    result = left_text + selected_text + right_text;
                    break;
                case EditType.Backspace:
                    if (selected_text.Length == 0)
                    {
                        // Remove the previous character.
                        if (left_text.Length > 0)
                        {
                            left_text = left_text.Substring(0, selection_start - 1);
                            selection_start--;
                        }
                    }
                    else
                    {
                        // Remove the selected text.
                        selected_text = "";
                    }
                    result = left_text + selected_text + right_text;
                    break;
            }

            // Return the result.
            return result;
        }

        // Enable appropriate context menu items.
        private void ctxTextBox_Opening(object sender, CancelEventArgs e)
        {
            ctxUndo.Enabled = txtFloat.CanUndo;

            // Copy and Cut are enabled if anything is selected.
            ctxCopy.Enabled = (txtFloat.SelectionLength > 0);
            ctxCut.Enabled = (txtFloat.SelectionLength > 0);

            // Delete is enabled if anything is selected or there
            // is a character after the insertion point to delete.
            ctxDelete.Enabled =
                ((txtFloat.SelectionLength > 0) ||
                 (txtFloat.SelectionStart < txtFloat.Text.Length));

            // Paste is enabled if the clipboard contains text.
            ctxPaste.Enabled = Clipboard.ContainsText();
        }

        // Make context menu items to do the
        // same work as the control characters.
        private void ctxUndo_Click(object sender, EventArgs e)
        {
            txtFloat.Undo();
        }
        private void ctxCopy_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(txtFloat.SelectedText);
        }
        private void ctxCut_Click(object sender, EventArgs e)
        {
            ShouldCancelTextBoxEvent(txtFloat, EditType.Cut, ' ', true);
        }
        private void ctxPaste_Click(object sender, EventArgs e)
        {
            ShouldCancelTextBoxEvent(txtFloat, EditType.Paste, ' ', true);
        }
        private void ctxDelete_Click(object sender, EventArgs e)
        {
            ShouldCancelTextBoxEvent(txtFloat, EditType.Delete, ' ', true);
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
            this.ctxCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFloat = new System.Windows.Forms.TextBox();
            this.ctxCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.ctxTextBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ctxTextBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctxCopy
            // 
            this.ctxCopy.Name = "ctxCopy";
            this.ctxCopy.Size = new System.Drawing.Size(107, 22);
            this.ctxCopy.Text = "Copy";
            this.ctxCopy.Click += new System.EventHandler(this.ctxCopy_Click);
            // 
            // txtFloat
            // 
            this.txtFloat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFloat.Location = new System.Drawing.Point(178, 38);
            this.txtFloat.Name = "txtFloat";
            this.txtFloat.Size = new System.Drawing.Size(100, 20);
            this.txtFloat.TabIndex = 9;
            this.txtFloat.Text = "-1.2e+34";
            this.txtFloat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFloat_KeyDown);
            this.txtFloat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFloat_KeyPress);
            // 
            // ctxCut
            // 
            this.ctxCut.Name = "ctxCut";
            this.ctxCut.Size = new System.Drawing.Size(107, 22);
            this.ctxCut.Text = "Cut";
            this.ctxCut.Click += new System.EventHandler(this.ctxCut_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(104, 6);
            // 
            // ctxPaste
            // 
            this.ctxPaste.Name = "ctxPaste";
            this.ctxPaste.Size = new System.Drawing.Size(107, 22);
            this.ctxPaste.Text = "Paste";
            this.ctxPaste.Click += new System.EventHandler(this.ctxPaste_Click);
            // 
            // ctxUndo
            // 
            this.ctxUndo.Name = "ctxUndo";
            this.ctxUndo.Size = new System.Drawing.Size(107, 22);
            this.ctxUndo.Text = "Undo";
            this.ctxUndo.Click += new System.EventHandler(this.ctxUndo_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Float Only Here:";
            // 
            // ctxTextBox
            // 
            this.ctxTextBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxUndo,
            this.toolStripMenuItem1,
            this.ctxCopy,
            this.ctxCut,
            this.ctxPaste,
            this.ctxDelete});
            this.ctxTextBox.Name = "ctxTextBox";
            this.ctxTextBox.Size = new System.Drawing.Size(108, 120);
            this.ctxTextBox.Opening += new System.ComponentModel.CancelEventHandler(this.ctxTextBox_Opening);
            // 
            // ctxDelete
            // 
            this.ctxDelete.Name = "ctxDelete";
            this.ctxDelete.Size = new System.Drawing.Size(107, 22);
            this.ctxDelete.Text = "Delete";
            this.ctxDelete.Click += new System.EventHandler(this.ctxDelete_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Write Anything Here:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.Location = new System.Drawing.Point(178, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "ABC777";
            // 
            // howto_preview_textbox_float_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 71);
            this.Controls.Add(this.txtFloat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Name = "howto_preview_textbox_float_Form1";
            this.Text = "howto_preview_textbox_float";
            this.Load += new System.EventHandler(this.howto_preview_textbox_float_Form1_Load);
            this.ctxTextBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem ctxCopy;
        private System.Windows.Forms.TextBox txtFloat;
        private System.Windows.Forms.ToolStripMenuItem ctxCut;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ctxPaste;
        private System.Windows.Forms.ToolStripMenuItem ctxUndo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip ctxTextBox;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

