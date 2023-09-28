using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.CodeDom.Compiler;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_supported_languages_Form1:Form
  { 


        public howto_list_supported_languages_Form1()
        {
            InitializeComponent();
        }

        // List compiler supported languages.
        private void howto_list_supported_languages_Form1_Load(object sender, EventArgs e)
        {
            string txt = "";

            // Loop through information about all compilers.
            CompilerInfo[] compiler_infos = CodeDomProvider.GetAllCompilerInfo();
            foreach (CompilerInfo info in compiler_infos)
            {
                if (info.IsCodeDomProviderTypeValid)
                {
                    // Get information about this compiler.
                    CodeDomProvider provider = info.CreateProvider();
                    txt += "Provider: " + provider.ToString() + "\r\n";

                    // List supported extensions.
                    string extensions = "";
                    string default_extension = provider.FileExtension;
                    if (default_extension[0] != '.')
                        default_extension = '.' + default_extension;
                    foreach (string extension in info.GetExtensions())
                    {
                        extensions += ", " + extension;
                        if (extension == default_extension) extensions += " (default)";
                    }
                    if (extensions.Length > 0) extensions = extensions.Substring(2);
                    txt += "  Extensions: " + extensions + "\r\n";

                    // List supported languages.
                    string languages = "";
                    string default_language =
                        CodeDomProvider.GetLanguageFromExtension(default_extension);
                    foreach (string language in info.GetLanguages())
                    {
                        languages += ", " + language;
                        if (language == default_language) languages += " (default)";
                    }
                    if (languages.Length > 0) languages = languages.Substring(2);
                    txt += "  Languages: " + languages + "\r\n";

                    // Get the compiler settings for this provider.
                    CompilerParameters parameters = info.CreateDefaultCompilerParameters();
                    txt += "  Options: " + parameters.CompilerOptions + "\r\n";
                    txt += "  Warning Level: " + parameters.WarningLevel + "\r\n";
                }
            }

            // Display the results.
            txtInfo.Text = txt;
            txtInfo.Select(0, 0);
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
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(12, 12);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfo.Size = new System.Drawing.Size(360, 287);
            this.txtInfo.TabIndex = 1;
            // 
            // howto_list_supported_languages_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.txtInfo);
            this.Name = "howto_list_supported_languages_Form1";
            this.Text = "howto_list_supported_languages";
            this.Load += new System.EventHandler(this.howto_list_supported_languages_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInfo;
    }
}

