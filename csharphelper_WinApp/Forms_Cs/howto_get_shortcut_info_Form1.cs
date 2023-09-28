using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to the COM library "Microsoft Shell Controls and Automation."

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_shortcut_info_Form1:Form
  { 


        public howto_get_shortcut_info_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string name, descr, path, working_dir, args;

            string result =
                GetShortcutInfo(txtShortcut.Text, out name, out path, out descr, out working_dir, out args);

            if (result.Length > 0)
            {
                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtName.Text = name;
            txtDescription.Text = descr;
            txtPath.Text = path;
            txtWorkingDirectory.Text = working_dir;
            txtArguments.Text = args;
        }

        // Get information about this link.
        // Return an error message if there's a problem.
        private string GetShortcutInfo(string full_name, out string name, out string path, out string descr, out string working_dir, out string args)
        {
            name = "";
            path = "";
            descr = "";
            working_dir = "";
            args = "";
            try
            {
                // Make a Shell object.
                Shell32.Shell shell = new Shell32.Shell();

                // Get the shortcut's folder and name.
                string shortcut_path = full_name.Substring(0, full_name.LastIndexOf("\\"));
                string shortcut_name = full_name.Substring(full_name.LastIndexOf("\\") + 1);
                if (!shortcut_name.EndsWith(".lnk")) shortcut_name += ".lnk";

                // Get the shortcut's folder.
                Shell32.Folder shortcut_folder = shell.NameSpace(shortcut_path);

                // Get the shortcut's file.
                Shell32.FolderItem folder_item = shortcut_folder.Items().Item(shortcut_name);

                if (folder_item == null)
                    return "Cannot find shortcut file '" + full_name + "'";
                if (!folder_item.IsLink)
                    return "File '" + full_name + "' isn't a shortcut.";

                // Display the shortcut's information.
                Shell32.ShellLinkObject lnk = (Shell32.ShellLinkObject)folder_item.GetLink;
                name = folder_item.Name;
                descr = lnk.Description;
                path = lnk.Path;
                working_dir = lnk.WorkingDirectory;
                args = lnk.Arguments;
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
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
            this.txtArguments = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtWorkingDirectory = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtShortcut = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtArguments
            // 
            this.txtArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArguments.Location = new System.Drawing.Point(106, 172);
            this.txtArguments.Name = "txtArguments";
            this.txtArguments.Size = new System.Drawing.Size(272, 20);
            this.txtArguments.TabIndex = 38;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(10, 172);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(60, 13);
            this.Label6.TabIndex = 37;
            this.Label6.Text = "Arguments:";
            // 
            // txtWorkingDirectory
            // 
            this.txtWorkingDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkingDirectory.Location = new System.Drawing.Point(106, 148);
            this.txtWorkingDirectory.Name = "txtWorkingDirectory";
            this.txtWorkingDirectory.Size = new System.Drawing.Size(272, 20);
            this.txtWorkingDirectory.TabIndex = 36;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(10, 148);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(95, 13);
            this.Label4.TabIndex = 35;
            this.Label4.Text = "Working Directory:";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(106, 124);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(272, 20);
            this.txtPath.TabIndex = 34;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(10, 124);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(32, 13);
            this.Label5.TabIndex = 33;
            this.Label5.Text = "Path:";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(106, 100);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(272, 20);
            this.txtDescription.TabIndex = 32;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(10, 100);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(63, 13);
            this.Label3.TabIndex = 31;
            this.Label3.Text = "Description:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(106, 76);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(272, 20);
            this.txtName.TabIndex = 30;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(10, 76);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(38, 13);
            this.Label2.TabIndex = 29;
            this.Label2.Text = "Name:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(157, 44);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 28;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtShortcut
            // 
            this.txtShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortcut.Location = new System.Drawing.Point(106, 12);
            this.txtShortcut.Name = "txtShortcut";
            this.txtShortcut.Size = new System.Drawing.Size(272, 20);
            this.txtShortcut.TabIndex = 27;
            this.txtShortcut.Text = "C:\\Users\\Rod\\Desktop\\Signature";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(50, 13);
            this.Label1.TabIndex = 26;
            this.Label1.Text = "Shortcut:";
            // 
            // howto_get_shortcut_info_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 205);
            this.Controls.Add(this.txtArguments);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtWorkingDirectory);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtShortcut);
            this.Controls.Add(this.Label1);
            this.Name = "howto_get_shortcut_info_Form1";
            this.Text = "howto_get_shortcut_info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtArguments;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtWorkingDirectory;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtPath;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtDescription;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtShortcut;
        internal System.Windows.Forms.Label Label1;
    }
}

