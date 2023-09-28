using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

 

using howto_password_tracker;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_password_tracker_Form1:Form
  { 


        public howto_password_tracker_Form1()
        {
            InitializeComponent();
        }

        private string MasterPassword = "";
        private string MasterDate = "";

        private void howto_password_tracker_Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            // Restore form positions and data.
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Get the master password.
            if (InputBox("Master Password", "", out MasterPassword) == DialogResult.Cancel)
            {
                Close();
                return;
            }

            // See if we have any data yet.
            string crypt_master = SettingStuff.GetSetting(SettingStuff.APP_NAME, "Passwords", "Master", "");
            if (crypt_master.Length == 0)
            {
                // This is the first time. Record the master password change date.
                MasterDate = DateTime.Now.ToString();
            }
            else
            {
                // Verify that the user entered the correct master password.
                string salt_master = SettingStuff.GetSetting(SettingStuff.APP_NAME, "Passwords", "MasterSalt", "");
                string plain_master = Crypto.DecryptFromString(crypt_master, MasterPassword, salt_master);
                if (plain_master != MasterPassword)
                {
                    MessageBox.Show("Incorrect master password", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MasterPassword = "";
                    Close();
                    return;
                }

                string crypt_masterdate = SettingStuff.GetSetting(SettingStuff.APP_NAME, "Passwords", "MasterDate", DateTime.Now.ToString());
                MasterDate = Crypto.DecryptFromString(crypt_masterdate, MasterPassword, salt_master);
            }

            // Load the password data.
            for (int i = 0; ; i++)
            {
                // Get the next password's name, username, and value.
                string crypt_name = SettingStuff.GetSetting(SettingStuff.APP_NAME,
                    "Passwords", "PasswordName" + i.ToString(), "");
                if (crypt_name.Length == 0) break;
                string crypt_uaername = SettingStuff.GetSetting(SettingStuff.APP_NAME,
                    "Passwords", "PasswordUsername" + i.ToString(), "");
                string crypt_value = SettingStuff.GetSetting(SettingStuff.APP_NAME,
                    "Passwords", "PasswordValue" + i.ToString(), "");
                string salt = SettingStuff.GetSetting(SettingStuff.APP_NAME,
                    "Passwords", "PasswordSalt" + i.ToString(), "");
                string crypt_date = SettingStuff.GetSetting(SettingStuff.APP_NAME,
                    "Passwords", "PasswordDate" + i.ToString(), "");

                // Decrypt the name, username, password, and date.
                string plain_name = Crypto.DecryptFromString(
                    crypt_name, MasterPassword, salt);
                string plain_username = Crypto.DecryptFromString(
                    crypt_uaername, MasterPassword, salt);
                string plain_value = Crypto.DecryptFromString(
                    crypt_value, MasterPassword, salt);
                string plain_date = Crypto.DecryptFromString(
                    crypt_date, MasterPassword, salt);

                // Display the result.
                dgvPasswords.Rows.Add(new Object[] { plain_name,
                    plain_username, plain_value, plain_date, null, null});
            }

            // Restore the form and grid settings.
            SettingStuff.RestoreFormPosition(this, SettingStuff.APP_NAME, "MainForm");
            SettingStuff.RestoreDgvSettings(this.dgvPasswords, SettingStuff.APP_NAME, "MainDgv");
        }

        // Prompt the user for a simple text value.
        private DialogResult InputBox(string prompt, string default_value, out string result)
        {
            howto_password_tracker_frmInputBox dlg = new  howto_password_tracker_frmInputBox();
            dlg.Text = prompt;
            dlg.lblPrompt.Text = prompt;
            dlg.txtValue.Text = default_value;

            DialogResult dialog_result = dlg.ShowDialog();
            
            result = dlg.txtValue.Text;
            return dialog_result;
        }

        // Save form positions and data.
        private void howto_password_tracker_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvPasswords.EndEdit();
            SaveSettings();
        }

        private void SaveSettings()
        {
            // If we didn't get a valid master password, don't save anything.
            if (MasterPassword.Length == 0) return;

            // Save the form positions.
            SettingStuff.SaveFormPosition(this, SettingStuff.APP_NAME, "MainForm");
            SettingStuff.SaveDgvSettings(this.dgvPasswords, SettingStuff.APP_NAME, "MainDgv");

            // Save the encrypted passwords.
            SettingStuff.SaveSetting(SettingStuff.APP_NAME, "Passwords", "Test", "Value"); // Just so there's something to delete.
            SettingStuff.DeleteSettingSection(SettingStuff.APP_NAME, "Passwords");

            string salt_master = Crypto.RandomSalt();
            string crypt_master = Crypto.EncryptToString(MasterPassword, MasterPassword, salt_master);
            string crypt_masterdate = Crypto.EncryptToString(MasterDate, MasterPassword, salt_master);
            SettingStuff.SaveSetting(SettingStuff.APP_NAME, "Passwords", "Master", crypt_master);
            SettingStuff.SaveSetting(SettingStuff.APP_NAME, "Passwords", "MasterSalt", salt_master);
            SettingStuff.SaveSetting(SettingStuff.APP_NAME, "Passwords", "MasterDate", crypt_masterdate);

            // Save the password data.
            int i = 0;
            foreach (DataGridViewRow row in dgvPasswords.Rows)
            {
                // Get the next password's name, value, and date.
                string plain_name = (string)row.Cells["colName"].Value;
                string plain_username = (string)row.Cells["colUsername"].Value;
                string plain_value = (string)row.Cells["colPassword"].Value;
                string plain_date = (string)row.Cells["colChangedDate"].Value;
                if (plain_name == null) plain_name = "";
                if (plain_username == null) plain_name = "";
                if (plain_value == null) plain_value = "";
                if (plain_date == null) plain_date = "";
                if ((plain_name.Length == 0) || (plain_username.Length == 0) ||
                    (plain_value.Length == 0) || (plain_date.Length == 0))
                {
                    row.Cells["colName"].Value = "";
                    row.Cells["colUsername"].Value = "";
                    row.Cells["colPassword"].Value = "";
                    row.Cells["colChangedDate"].Value = "";
                }
                else
                {
                    // Encrypt.
                    string salt = Crypto.RandomSalt();
                    string crypt_name = Crypto.EncryptToString(plain_name, MasterPassword, salt);
                    string crypt_username = Crypto.EncryptToString(plain_username, MasterPassword, salt);
                    string crypt_value = Crypto.EncryptToString(plain_value, MasterPassword, salt);
                    string crypt_date = Crypto.EncryptToString(plain_date, MasterPassword, salt);

                    // Save the values.
                    SettingStuff.SaveSetting(SettingStuff.APP_NAME, "Passwords", "PasswordName" + i.ToString(), crypt_name);
                    SettingStuff.SaveSetting(SettingStuff.APP_NAME, "Passwords", "PasswordUsername" + i.ToString(), crypt_username);
                    SettingStuff.SaveSetting(SettingStuff.APP_NAME, "Passwords", "PasswordValue" + i.ToString(), crypt_value);
                    SettingStuff.SaveSetting(SettingStuff.APP_NAME, "Passwords", "PasswordDate" + i.ToString(), crypt_date);
                    SettingStuff.SaveSetting(SettingStuff.APP_NAME, "Passwords", "PasswordSalt" + i.ToString(), salt);
                    i++;
                }
            }
        }

        // Let the user change settings.
        private void mnuFileChangeMasterPassword_Click(object sender, EventArgs e)
        {
            howto_password_tracker_frmChangeMaster frm = new  howto_password_tracker_frmChangeMaster();
            frm.txtDataFile.Text = MasterPassword;
            frm.lblLastChanged.Text = "Master Password last changed " + MasterDate;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Save the new master password.
                MasterPassword = frm.txtDataFile.Text;
                MasterDate = DateTime.Now.ToString();

                // Re-encrypt the passwords.
                SaveSettings();

                MessageBox.Show("Master password changed. Values saved.", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Copy a password to the clipboard or make a new password.
        private void dgvPasswords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPasswords.Columns[e.ColumnIndex].Name == "colCopy")
            {
                // Copy to clipboard.
                Clipboard.Clear();
                Clipboard.SetText(dgvPasswords.Rows[e.RowIndex].Cells["colPassword"].Value.ToString());
                System.Media.SystemSounds.Beep.Play();
            }
            if (dgvPasswords.Columns[e.ColumnIndex].Name == "colNew")
            {
                // Make a new password.
                howto_password_tracker_frmNewPassword frm = new  howto_password_tracker_frmNewPassword();
                if (dgvPasswords.Rows[e.RowIndex].Cells["colPassword"].Value != null)
                    frm.txtPassword.Text = dgvPasswords.Rows[e.RowIndex].Cells["colPassword"].Value.ToString();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvPasswords.Rows[e.RowIndex].Cells["colPassword"].Value = frm.txtPassword.Text;
                    dgvPasswords.Rows[e.RowIndex].Cells["colChangedDate"].Value = DateTime.Now.ToString();
                }
            }
        }

        // If this is a password, set the new changed date.
        private void dgvPasswords_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPasswords.Columns[e.ColumnIndex].Name == "colPassword")
            {
                dgvPasswords.Rows[e.RowIndex].Cells["colChangedDate"].Value = DateTime.Now.ToString();
            }
        }

        // Look for Ctrl+V and Ctrl+C.
        private void howto_password_tracker_Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.C)
                {
                    // Copy the current cell to the clipboard.
                    string text = dgvPasswords.CurrentCell.Value.ToString();
                    if (text.Length > 0)
                    {
                        Clipboard.Clear();
                        Clipboard.SetText(text);
                        System.Media.SystemSounds.Beep.Play();
                    }
                }
                else if (e.KeyCode == Keys.V)
                {
                    // Paste into the current cell.
                    if (!Clipboard.ContainsText())
                    {
                        System.Media.SystemSounds.Beep.Play();
                    }
                    else
                    {
                        dgvPasswords.CurrentCell.Value = Clipboard.GetText();
                    }
                }
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
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvPasswords = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChangedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCopy = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colNew = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileChangeMasterPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswords)).BeginInit();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPasswords
            // 
            this.dgvPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPasswords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasswords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colUsername,
            this.colPassword,
            this.colChangedDate,
            this.colCopy,
            this.colNew});
            this.dgvPasswords.Location = new System.Drawing.Point(1, 25);
            this.dgvPasswords.Name = "dgvPasswords";
            this.dgvPasswords.Size = new System.Drawing.Size(479, 321);
            this.dgvPasswords.TabIndex = 14;
            this.dgvPasswords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPasswords_CellContentClick);
            this.dgvPasswords.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPasswords_CellEndEdit);
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 150;
            // 
            // colUsername
            // 
            this.colUsername.HeaderText = "Username";
            this.colUsername.Name = "colUsername";
            // 
            // colPassword
            // 
            this.colPassword.HeaderText = "Password";
            this.colPassword.Name = "colPassword";
            this.colPassword.Width = 150;
            // 
            // colChangedDate
            // 
            this.colChangedDate.HeaderText = "Changed Date";
            this.colChangedDate.Name = "colChangedDate";
            this.colChangedDate.ReadOnly = true;
            this.colChangedDate.Width = 150;
            // 
            // colCopy
            // 
            this.colCopy.HeaderText = "Copy";
            this.colCopy.Name = "colCopy";
            this.colCopy.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCopy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCopy.Width = 40;
            // 
            // colNew
            // 
            this.colNew.HeaderText = "New";
            this.colNew.Name = "colNew";
            this.colNew.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNew.Width = 40;
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(481, 24);
            this.MenuStrip1.TabIndex = 13;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileChangeMasterPassword,
            this.ToolStripMenuItem1,
            this.mnuFileExit});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileChangeMasterPassword
            // 
            this.mnuFileChangeMasterPassword.Name = "mnuFileChangeMasterPassword";
            this.mnuFileChangeMasterPassword.Size = new System.Drawing.Size(207, 22);
            this.mnuFileChangeMasterPassword.Text = "Change Master Password";
            this.mnuFileChangeMasterPassword.Click += new System.EventHandler(this.mnuFileChangeMasterPassword_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(204, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(207, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // howto_password_tracker_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 347);
            this.Controls.Add(this.dgvPasswords);
            this.Controls.Add(this.MenuStrip1);
            this.KeyPreview = true;
            this.Name = "howto_password_tracker_Form1";
            this.Text = "PasswordTracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_password_tracker_Form1_FormClosing);
            this.Load += new System.EventHandler(this.howto_password_tracker_Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.howto_password_tracker_Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswords)).EndInit();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.DataGridView dgvPasswords;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileChangeMasterPassword;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChangedDate;
        private System.Windows.Forms.DataGridViewButtonColumn colCopy;
        private System.Windows.Forms.DataGridViewButtonColumn colNew;
    }
}

