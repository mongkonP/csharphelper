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
     public partial class howto_codedom_evaluate_numeric_expressions_Form1:Form
  { 


        public howto_codedom_evaluate_numeric_expressions_Form1()
        {
            InitializeComponent();
        }

        // Evaluate the expression.
        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            // Turn the equation into a function.
            string function_text =
                "public static class Evaluator" +
                "{" +
                "    public static double Evaluate(double x, double y)" +
                "    {" +
                "        return " + txtExpression.Text + ";" +
                "    }" +
                "}";

            // Compile the function.
            CodeDomProvider code_provider = CodeDomProvider.CreateProvider("C#");

            // Generate a non-executable assembly in memory.
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;

            // Compile the code.
            CompilerResults results =
                code_provider.CompileAssemblyFromSource(parameters, function_text);

            // If there are errors, display them.
            if (results.Errors.Count > 0)
            {
                string msg = "Error compiling the expression.";
                foreach (CompilerError compiler_error in results.Errors)
                {
                    msg += "\n" + compiler_error.ErrorText;
                }
                MessageBox.Show(msg, "Expression Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Get the Evaluator class type.
                Type evaluator_type = results.CompiledAssembly.GetType("Evaluator");

                // Get a MethodInfo object describing the Evaluate method.
                MethodInfo method_info = evaluator_type.GetMethod("Evaluate");

                // Make the parameter list.
                object[] method_params = new object[]
                {
                    double.Parse(txtX.Text),
                    double.Parse(txtY.Text)
                };

                // Execute the method.
                double expression_result =
                    (double)method_info.Invoke(null, method_params);

                // Display the returned result.
                txtResult.Text = expression_result.ToString();
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(70, 120);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(76, 20);
            this.txtResult.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Result:";
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Location = new System.Drawing.Point(154, 90);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(75, 23);
            this.btnEvaluate.TabIndex = 15;
            this.btnEvaluate.Text = "Evaluate";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(70, 63);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(76, 20);
            this.txtY.TabIndex = 14;
            this.txtY.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "y:";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(70, 37);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(76, 20);
            this.txtX.TabIndex = 12;
            this.txtX.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "x:";
            // 
            // txtExpression
            // 
            this.txtExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpression.Location = new System.Drawing.Point(70, 11);
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(211, 20);
            this.txtExpression.TabIndex = 10;
            this.txtExpression.Text = "2 * x + 4 * y + x * y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Equation:";
            // 
            // howto_codedom_evaluate_numeric_expressions_Form1
            // 
            this.AcceptButton = this.btnEvaluate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 150);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEvaluate);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExpression);
            this.Controls.Add(this.label1);
            this.Name = "howto_codedom_evaluate_numeric_expressions_Form1";
            this.Text = "howto_codedom_evaluate_numeric_expressions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExpression;
        private System.Windows.Forms.Label label1;
    }
}

