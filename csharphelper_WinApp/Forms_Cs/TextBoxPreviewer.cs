using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using System.Windows.Forms;

namespace howto_preview_textbox_extender_provider
{
    [ProvideProperty("ProvidePreview", "TextBox")]
    public partial class TextBoxPreviewer : Component, IExtenderProvider
    {
        public TextBoxPreviewer()
        {
            InitializeComponent();

            MakeContextMenu();
        }
        
        public TextBoxPreviewer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            MakeContextMenu();
        }

        #region IExtenderProvider Members

        // We can extend TextBoxes only.
        public bool CanExtend(object extendee)
        {
            return (extendee is TextBox);
        }

        // The list of our clients.
        private List<TextBox> Clients = new List<TextBox>();

        // Implement the ProvidePreview extension property.
        // Return this client's ProvidePreview value.
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool GetProvidePreview(TextBox client)
        {
            // Return true if the client is in the Clients list.
            return Clients.Contains(client);
        }

        // Set this control's ProvidePreview value.
        [Category("Behavior")]
        [DefaultValue(false)]
        public void SetProvidePreview(TextBox client, bool provide_preview)
        {
            if (provide_preview)
            {
                // Add the client to the list.
                if (!Clients.Contains(client))
                {
                    // Add the client to the list of clients.
                    Clients.Add(client);

                    // Add event handlers.
                    client.KeyDown += txt_KeyDown;
                    client.KeyPress += txt_KeyPress;

                    // Attach the ContextMenuStrip.
                    client.ContextMenuStrip = ctxTextBox;
                }
            }
            else
            {
                // Remove the client from the list.
                if (Clients.Contains(client))
                {
                    // Remove the client from the list of clients.
                    Clients.Remove(client);

                    // Remove event handlers.
                    client.KeyDown -= txt_KeyDown;
                    client.KeyPress -= txt_KeyPress;

                    // Detach the ContextMenuStrip.
                    client.ContextMenuStrip = null;
                }
            }
        }

        #endregion IExtenderProvider Members

        #region Preview Code

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
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Do nothing for special characters.
            if ((e.KeyChar < ' ') || (e.KeyChar > '~')) return;

            // See if the change is valid.
            e.Handled = ShouldCancelTextBoxEvent(
                txt, EditType.NewCharacter, e.KeyChar, false);
        }

        // Handle Ctrl+A, Ctrl+X, Ctrl+V, Shift+Insert,
        // Shift+Delete, Delete, and Backspace.
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Look for the necessary key combinations.
            bool cancel_event;
            if (e.Control && (e.KeyCode == Keys.A))
            {
                // Handle this one just for convenience.
                txt.Select(0, txt.Text.Length);
                cancel_event = true;
            }
            else if (e.Control && (e.KeyCode == Keys.X))
            {
                cancel_event = ShouldCancelTextBoxEvent(txt, EditType.Cut, ' ', false);
            }
            else if (e.Control && (e.KeyCode == Keys.V))
            {
                cancel_event = ShouldCancelTextBoxEvent(txt, EditType.Paste, ' ', false);
            }
            else if (e.Shift && (e.KeyCode == Keys.Insert))
            {
                cancel_event = ShouldCancelTextBoxEvent(txt, EditType.Paste, ' ', false);
            }
            else if (e.Shift && (e.KeyCode == Keys.Delete))
            {
                cancel_event = ShouldCancelTextBoxEvent(txt, EditType.Cut, ' ', false);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                cancel_event = ShouldCancelTextBoxEvent(txt, EditType.Delete, ' ', false);
            }
            else if (e.KeyCode == Keys.Back)
            {
                cancel_event = ShouldCancelTextBoxEvent(txt, EditType.Backspace, ' ', false);
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

        // The event we raise when the TextBox's value is about to change.
        public delegate void TextChangingDelegate(TextBox text_box, string new_text, ref bool cancel);
        public event TextChangingDelegate TextChanging;

        // Compose the TextBox's new value and raise the TextChanging event to see if it is valid.
        //
        // If the change is invalid, return true to indicate the event should be canceled.
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
            string new_value = GetNewTextBoxValue(txt, edit_type, new_char, out selection_start);

            // Raise the TextChanging event to see if the value is valid.
            bool cancel = false;
            TextChanging(txt, new_value, ref cancel);

            if (cancel)
            {
                // The new value is invalid. Discard it.
                // (Let the main program decide whether to beep.)
                return true;
            }
            else
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

        #endregion Preview Code

        #region Context Menu Code

        // This extender's context menu.
        private ContextMenuStrip ctxTextBox;
        private ToolStripMenuItem ctxUndo, ctxCopy, ctxCut, ctxPaste, ctxDelete;
        private ToolStripSeparator ctxSeparator;

        // Make the context menu.
        private void MakeContextMenu()
        {
            this.ctxTextBox = new ContextMenuStrip();
            this.ctxUndo = new ToolStripMenuItem();
            this.ctxSeparator = new ToolStripSeparator();
            this.ctxCopy = new ToolStripMenuItem();
            this.ctxCut = new ToolStripMenuItem();
            this.ctxPaste = new ToolStripMenuItem();
            this.ctxDelete = new ToolStripMenuItem();

            ctxTextBox.Opening += ctxTextBox_Opening;
            this.ctxTextBox.Name = "ctxTextBox";
            this.ctxTextBox.Size = new System.Drawing.Size(108, 120);
            this.ctxTextBox.Items.AddRange(new ToolStripItem[] 
                {
                    this.ctxUndo,
                    this.ctxSeparator,
                    this.ctxCopy,
                    this.ctxCut,
                    this.ctxPaste,
                    this.ctxDelete
                });
            this.ctxUndo.Text = "Undo";
            this.ctxUndo.Click += ctxUndo_Click;
            this.ctxCopy.Text = "Copy";
            this.ctxCopy.Click += ctxCopy_Click;
            this.ctxCut.Text = "Cut";
            this.ctxCut.Click += ctxCut_Click;
            this.ctxPaste.Text = "Paste";
            this.ctxPaste.Click += ctxPaste_Click;
            this.ctxDelete.Text = "Delete";
            this.ctxDelete.Click += ctxDelete_Click;
        }

        // Enable appropriate context menu items.
        private void ctxTextBox_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip ctx = sender as ContextMenuStrip;
            TextBox txt = ctx.SourceControl as TextBox;

            // Undo is enabled if the TextBox has something it can undo.
            ctxUndo.Enabled = txt.CanUndo;

            // Copy and Cut are enabled if anything is selected.
            ctxCopy.Enabled = (txt.SelectionLength > 0);
            ctxCut.Enabled = (txt.SelectionLength > 0);

            // Delete is enabled if anything is selected or there
            // is a character after the insertion point to delete.
            ctxDelete.Enabled =
                ((txt.SelectionLength > 0) ||
                 (txt.SelectionStart < txt.Text.Length));

            // Paste is enabled if the clipboard contains text.
            ctxPaste.Enabled = Clipboard.ContainsText();
        }

        // Make context menu items to do the
        // same work as the control characters.
        private void ctxUndo_Click(object sender, EventArgs e)
        {
            TextBox txt = ctxTextBox.SourceControl as TextBox;
            txt.Undo();
        }
        private void ctxCopy_Click(object sender, EventArgs e)
        {
            TextBox txt = ctxTextBox.SourceControl as TextBox;
            Clipboard.Clear();
            Clipboard.SetText(txt.SelectedText);
        }
        private void ctxCut_Click(object sender, EventArgs e)
        {
            TextBox txt = ctxTextBox.SourceControl as TextBox;
            ShouldCancelTextBoxEvent(txt, EditType.Cut, ' ', true);
        }
        private void ctxPaste_Click(object sender, EventArgs e)
        {
            TextBox txt = ctxTextBox.SourceControl as TextBox;
            ShouldCancelTextBoxEvent(txt, EditType.Paste, ' ', true);
        }
        private void ctxDelete_Click(object sender, EventArgs e)
        {
            TextBox txt = ctxTextBox.SourceControl as TextBox;
            ShouldCancelTextBoxEvent(txt, EditType.Delete, ' ', true);
        }

        #endregion Context Menu Code

    

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
    }
}
