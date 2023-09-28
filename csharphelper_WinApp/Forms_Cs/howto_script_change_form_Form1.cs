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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_script_change_form_Form1:Form
  { 


        public howto_script_change_form_Form1()
        {
            InitializeComponent();
        }

        // Deselect the code.
        private void howto_script_change_form_Form1_Load(object sender, EventArgs e)
        {
            txtCode.Select(0, 0);
        }

        // Compile and execute the code.
        private void btnRun_Click(object sender, EventArgs e)
        {
            txtResults.Clear();
            CodeDomProvider code_provider = CodeDomProvider.CreateProvider("C#");

            // Generate a non-executable assembly in memory.
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;

            // Add references used by the code.
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add(Assembly.GetEntryAssembly().Location);

            // Compile the code.
            CompilerResults results =
                code_provider.CompileAssemblyFromSource(parameters, txtCode.Text);

            // If there are errors, display them.
            if (results.Errors.Count > 0)
            {
                foreach (CompilerError compiler_error in results.Errors)
                {
                    txtResults.AppendText(
                        "Line: " + compiler_error.Line + ", " +
                        "Error Number: " + compiler_error.ErrorNumber + ", " +
                        compiler_error.ErrorText + "\n");
                }
            }
            else
            {
                // There were no errors.
                txtResults.Text = "Success!";

                // Get the compiled method and execute it.
                foreach (Type a_type in results.CompiledAssembly.GetTypes())
                {
                    if (!a_type.IsClass) continue;
                    if (a_type.IsNotPublic) continue;

                    // Get a MethodInfo object describing the SayHi method.
                    MethodInfo method_info = a_type.GetMethod("ModifyForm");
                    if (method_info != null)
                    {
                        // Make the parameter list.
                        object[] method_params = new object[] { this };

                        // Execute the method.
                        try
                        {
                            method_info.Invoke(null, method_params);

                            // Display a success message.
                            MessageBox.Show("OK");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + '\n' +
                                ex.InnerException.Message + '\n' +
                                ex.InnerException.StackTrace);
                        }
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
            this.btnRun = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRun.Location = new System.Drawing.Point(145, 155);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(12, 184);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(340, 65);
            this.txtResults.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(12, 12);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(340, 137);
            this.txtCode.TabIndex = 0;
            this.txtCode.Text = "using howto_script_change_form;\r\n\r\npublic static class MyScriptClass\r\n{\r\n    publ" +
                "ic static void ModifyForm(howto_script_change_form_Form1 form)\r\n    {\r\n        form.btnRun.Left = 0;\r\n   " +
                " }\r\n}";
            // 
            // howto_script_change_form_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 261);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.txtCode);
            this.Name = "howto_script_change_form_Form1";
            this.Text = "howto_script_change_form";
            this.Load += new System.EventHandler(this.howto_script_change_form_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.Button btnRun;
    }
}

