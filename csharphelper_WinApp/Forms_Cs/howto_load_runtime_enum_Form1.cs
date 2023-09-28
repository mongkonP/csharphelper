using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.CodeDom.Compiler;
using System.Reflection;
using System.IO;

 

using howto_load_runtime_enum;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_load_runtime_enum_Form1:Form
  { 


        public howto_load_runtime_enum_Form1()
        {
            InitializeComponent();
        }

        // Load and compile an enum file.
        private void mnuFileOpenEnumFile_Click(object sender, EventArgs e)
        {
            if (ofdEnum.ShowDialog() != DialogResult.OK) return;

            trvEnums.Nodes.Clear();

            // Use the C# DOM provider.
            CodeDomProvider code_provider =
                CodeDomProvider.CreateProvider("C#");

            // Generate a non-executable assembly in memory.
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;

            // Get information about this assembly.
            // (So the enum can use attributes defined
            // in Attributes.cs.)
            string exe_name = Assembly.GetEntryAssembly().Location;
            parameters.ReferencedAssemblies.Add(exe_name);

            // Load the enum file's text placed
            // inside our namespace.
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("namespace howto_load_runtime_enum");
            sb.AppendLine("{");
            sb.AppendLine(File.ReadAllText(ofdEnum.FileName));
            sb.AppendLine("}");

            // Compile the code.
            CompilerResults results =
                code_provider.CompileAssemblyFromSource(parameters,
                    sb.ToString());

            // If there are errors, display them.
            if (results.Errors.Count > 0)
            {
                trvEnums.Nodes.Add("Error compiling the expression.");
                foreach (CompilerError compiler_error in results.Errors)
                {
                    trvEnums.Nodes.Add(compiler_error.ErrorText);
                }
                return;
            }

            // See what enumerations there are.
            foreach (Type type in results.CompiledAssembly.GetTypes())
            {
                // Only consider types that are enums.
                if (type.IsEnum)
                {
                    // Add a TreeView root node for the enum.
                    TreeNode enum_node = trvEnums.Nodes.Add(type.Name);

                    // Enumerate the Enum's fields (values).
                    FieldInfo[] enum_value_infos = type.GetFields();

                    // Loop over the enum's values.
                    foreach (FieldInfo value_info in enum_value_infos)
                    {
                        // See if this is a literal value (set at compile time).
                        if (value_info.IsLiteral)
                        {
                            // Add it to the Enum's root node.
                            TreeNode value_node =
                                enum_node.Nodes.Add(
                                    value_info.Name + " = " +
                                    ((int)value_info.GetValue(null)).ToString());

                            // Loop through the value's attributes.
                            foreach (Attribute attr in value_info.GetCustomAttributes(false))
                            {
                                // Start with the attribute's name.
                                string attr_text = attr.GetType().Name + "(";

                                // Add the attribute's fields.
                                foreach (FieldInfo field_info in attr.GetType().GetFields())
                                {
                                    attr_text +=
                                        field_info.Name + " = " +
                                        field_info.GetValue(attr).ToString() +
                                        ", ";
                                }

                                // If we have fields, remove the trailing ", ".
                                if (attr_text.Length > 0)
                                    attr_text = attr_text.Substring(0, attr_text.Length - 2);
                                attr_text += ")";

                                // Add this to the TreeView.
                                value_node.Nodes.Add(attr_text);
                            }
                        }
                    }
                }
            }
            trvEnums.ExpandAll();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
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
            this.trvEnums = new System.Windows.Forms.TreeView();
            this.ofdEnum = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpenEnumFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvEnums
            // 
            this.trvEnums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvEnums.Location = new System.Drawing.Point(12, 27);
            this.trvEnums.Name = "trvEnums";
            this.trvEnums.Size = new System.Drawing.Size(340, 347);
            this.trvEnums.TabIndex = 3;
            // 
            // ofdEnum
            // 
            this.ofdEnum.Filter = "C# Code Files|*.cs|All Files|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(364, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpenEnumFile,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileOpenEnumFile
            // 
            this.mnuFileOpenEnumFile.Name = "mnuFileOpenEnumFile";
            this.mnuFileOpenEnumFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpenEnumFile.Size = new System.Drawing.Size(210, 22);
            this.mnuFileOpenEnumFile.Text = "&Open Enum File...";
            this.mnuFileOpenEnumFile.Click += new System.EventHandler(this.mnuFileOpenEnumFile_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(167, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // howto_load_runtime_enum_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 386);
            this.Controls.Add(this.trvEnums);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_load_runtime_enum_Form1";
            this.Text = "howto_load_runtime_enum";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvEnums;
        private System.Windows.Forms.OpenFileDialog ofdEnum;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpenEnumFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
    }
}

