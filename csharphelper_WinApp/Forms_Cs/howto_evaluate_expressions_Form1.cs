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
     public partial class howto_evaluate_expressions_Form1:Form
  { 


        public howto_evaluate_expressions_Form1()
        {
            InitializeComponent();
        }

        // Stores user-entered primitives like X = 10.
        private Dictionary<string, string> Primatives;

        private enum Precedence
        {
            None = 11,
            Unary = 10,     // Not actually used.
            Power = 9,      // We use ^ to mean exponentiation.
            Times = 8,
            Div = 7,
            Modulus = 6,
            Plus = 5,
        }

        // Evaluate the expression entered by the user.
        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            // Store the primitives.
            Primatives = new Dictionary<string,string>();

            if (txtName1.Text.Trim().Length > 0)
                Primatives.Add(txtName1.Text.Trim(), txtValue1.Text.Trim());
            if (txtValue2.Text.Trim().Length > 0)
                Primatives.Add(txtName2.Text.Trim(), txtValue2.Text.Trim());
            if (txtValue3.Text.Trim().Length > 0)
                Primatives.Add(txtName3.Text.Trim(), txtValue3.Text.Trim());
            if (txtValue4.Text.Trim().Length > 0)
                Primatives.Add(txtName4.Text.Trim(), txtValue4.Text.Trim());

            // Get the expression.
            string expr = txtExpression.Text;

            // Evaluate the expression.
            txtResult.Text = "";
            try
            {
                txtResult.Text = EvaluateExpression(expr).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Evaluate the expression.
        private double EvaluateExpression(string expression)
        {
            int best_pos = 0;
            int parens = 0;

            // Remove all spaces.
            string expr = expression.Replace(" ", "");
            int expr_len = expr.Length;
            if (expr_len == 0) return 0;

            // If we find + or - now, then it's a unary operator.
            bool is_unary = true;

            // So far we have nothing.
            Precedence best_prec = Precedence.None;

            // Find the operator with the lowest precedence.
            // Look for places where there are no open
            // parentheses.
            for (int pos = 0; pos < expr_len; pos++)
            {
                // Examine the next character.
                string ch = expr.Substring(pos, 1);

                // Assume we will not find an operator. In
                // that case, the next operator will not
                // be unary.
                bool next_unary = false;

                if (ch == " ")
                {
                    // Just skip spaces. We keep them here
                    // to make the error messages easier to
                }
                else if (ch == "(")
                {
                    // Increase the open parentheses count.
                    parens += 1;

                    // A + or - after "(" is unary.
                    next_unary = true;
                }
                else if (ch == ")")
                {
                    // Decrease the open parentheses count.
                    parens -= 1;

                    // An operator after ")" is not unary.
                    next_unary = false;

                    // If parens < 0, too many )'s.
                    if (parens < 0)
                        throw new FormatException(
                            "Too many close parentheses in '" +
                            expression + "'");
                    }
                else if (parens == 0)
                {
                    // See if this is an operator.
                    if ((ch == "^") || (ch == "*") ||
                        (ch == "/") || (ch == "\\") ||
                        (ch == "%") || (ch == "+") ||
                        (ch == "-"))
                    {
                        // An operator after an operator
                        // is unary.
                        next_unary = true;

                        // See if this operator has higher
                        // precedence than the current one.
                        switch (ch)
                        {
                            case "^":
                                if (best_prec >= Precedence.Power)
                                {
                                    best_prec = Precedence.Power;
                                    best_pos = pos;
                                }
                                break;

                            case "*":
                            case "/":
                                if (best_prec >= Precedence.Times)
                                {
                                    best_prec = Precedence.Times;
                                    best_pos = pos;
                                }
                                break;

                            case "%":
                                if (best_prec >= Precedence.Modulus)
                                {
                                    best_prec = Precedence.Modulus;
                                    best_pos = pos;
                                }
                                break;

                            case "+":
                            case "-":
                                // Ignore unary operators
                                // for now.
                                if ((!is_unary) &&
                                    best_prec >= Precedence.Plus)
                                {
                                    best_prec = Precedence.Plus;
                                    best_pos = pos;
                                }
                                break;
                        } // End switch (ch)
                    } // End if this is an operator.
                } // else if (parens == 0)

                is_unary = next_unary;
            } // for (int pos = 0; pos < expr_len; pos++)

            // If the parentheses count is not zero,
            // there's a ) missing.
            if (parens != 0)
            {
                throw new FormatException(
                    "Missing close parenthesis in '" +
                    expression + "'");
            }

            // Hopefully we have the operator.
            if (best_prec < Precedence.None)
            {
                string lexpr = expr.Substring(0, best_pos);
                string rexpr = expr.Substring(best_pos + 1);
                switch (expr.Substring(best_pos, 1))
                {
                    case "^":
                        return Math.Pow(
                            EvaluateExpression(lexpr),
                            EvaluateExpression(rexpr));
                    case "*":
                        return
                            EvaluateExpression(lexpr) *
                            EvaluateExpression(rexpr);
                    case "/":
                        return
                            EvaluateExpression(lexpr) /
                            EvaluateExpression(rexpr);
                    case "%":
                        return
                            EvaluateExpression(lexpr) %
                            EvaluateExpression(rexpr);
                    case "+":
                        return
                            EvaluateExpression(lexpr) +
                            EvaluateExpression(rexpr);
                    case "-":
                        return
                            EvaluateExpression(lexpr) -
                            EvaluateExpression(rexpr);
                }
            }

            // if we do not yet have an operator, there
            // are several possibilities:
            //
            // 1. expr is (expr2) for some expr2.
            // 2. expr is -expr2 or +expr2 for some expr2.
            // 3. expr is Fun(expr2) for a function Fun.
            // 4. expr is a primitive.
            // 5. It's a literal like "3.14159".

            // Look for (expr2).
            if (expr.StartsWith("(") && expr.EndsWith(")"))
            {
                // Remove the parentheses.
                return EvaluateExpression(expr.Substring(1, expr_len - 2));
            }

            // Look for -expr2.
            if (expr.StartsWith("-"))
            {
                return -EvaluateExpression(expr.Substring(1));
            }

            // Look for +expr2.
            if (expr.StartsWith("+"))
            {
                return EvaluateExpression(expr.Substring(1));
            }

            // Look for Fun(expr2).
            if (expr_len > 5 && expr.EndsWith(")"))
            {
                // Find the first (.
                int paren_pos = expr.IndexOf("(");
                if (paren_pos > 0)
                {
                    // See what the function is.
                    string lexpr = expr.Substring(0, paren_pos);
                    string rexpr = expr.Substring(paren_pos + 1, expr_len - paren_pos - 2);
                    switch (lexpr.ToLower())
                    {
                        case "sin":
                            return Math.Sin(EvaluateExpression(rexpr));
                        case "cos":
                            return Math.Cos(EvaluateExpression(rexpr));
                        case "tan":
                            return Math.Tan(EvaluateExpression(rexpr));
                        case "sqrt":
                            return Math.Sqrt(EvaluateExpression(rexpr));
                        case "factorial":
                            return Factorial(EvaluateExpression(rexpr));
                        // Add other functions (including
                        // program-defined functions) here.
                    }
                }
            }

            // See if it's a primitive.
            if (Primatives.ContainsKey(expr))
            {
                // Return the corresponding value,
                // converted into a Double.
                try
                {
                    // Try to convert the expression into a value.
                    return double.Parse(Primatives[expr]);
                }
                catch (Exception)
                {
                    throw new FormatException(
                        "Primative '" + expr +
                        "' has value '" +
                        Primatives[expr] +
                        "' which is not a Double.");
                }
            }

            // It must be a literal like "2.71828".
            try
            {
                // Try to convert the expression into a Double.
                return double.Parse(expr);
            }
            catch (Exception)
            {
                throw new FormatException(
                    "Error evaluating '" + expression +
                    "' as a constant.");
            }
        }

        // Return the factorial of the expression.
        private double Factorial(double value)
        {
            // Make sure the value is an integer.
            if ((long)value != value)
            {
                throw new ArgumentException(
                    "Parameter to Factorial function must be an integer in Factorial(" +
                    value.ToString() + ")");
            }

            double result = 1;
            for (int i=2; i <= value; i++)
            {
                result *= i;
            }
            return result;
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
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtValue4 = new System.Windows.Forms.TextBox();
            this.txtName4 = new System.Windows.Forms.TextBox();
            this.txtValue3 = new System.Windows.Forms.TextBox();
            this.txtName3 = new System.Windows.Forms.TextBox();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtValue1 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtName1 = new System.Windows.Forms.TextBox();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEvaluate.Location = new System.Drawing.Point(128, 198);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(72, 24);
            this.btnEvaluate.TabIndex = 15;
            this.btnEvaluate.Text = "Evaluate";
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(6, 246);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(313, 20);
            this.txtResult.TabIndex = 14;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(6, 230);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(72, 16);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "Result";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.txtValue4);
            this.GroupBox1.Controls.Add(this.txtName4);
            this.GroupBox1.Controls.Add(this.txtValue3);
            this.GroupBox1.Controls.Add(this.txtName3);
            this.GroupBox1.Controls.Add(this.txtValue2);
            this.GroupBox1.Controls.Add(this.txtName2);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtValue1);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtName1);
            this.GroupBox1.Location = new System.Drawing.Point(6, 54);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(312, 136);
            this.GroupBox1.TabIndex = 12;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Primatives";
            // 
            // txtValue4
            // 
            this.txtValue4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtValue4.Location = new System.Drawing.Point(164, 104);
            this.txtValue4.Name = "txtValue4";
            this.txtValue4.Size = new System.Drawing.Size(120, 20);
            this.txtValue4.TabIndex = 8;
            // 
            // txtName4
            // 
            this.txtName4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtName4.Location = new System.Drawing.Point(36, 104);
            this.txtName4.Name = "txtName4";
            this.txtName4.Size = new System.Drawing.Size(120, 20);
            this.txtName4.TabIndex = 7;
            // 
            // txtValue3
            // 
            this.txtValue3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtValue3.Location = new System.Drawing.Point(164, 80);
            this.txtValue3.Name = "txtValue3";
            this.txtValue3.Size = new System.Drawing.Size(120, 20);
            this.txtValue3.TabIndex = 6;
            // 
            // txtName3
            // 
            this.txtName3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtName3.Location = new System.Drawing.Point(36, 80);
            this.txtName3.Name = "txtName3";
            this.txtName3.Size = new System.Drawing.Size(120, 20);
            this.txtName3.TabIndex = 5;
            // 
            // txtValue2
            // 
            this.txtValue2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtValue2.Location = new System.Drawing.Point(164, 56);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(120, 20);
            this.txtValue2.TabIndex = 4;
            // 
            // txtName2
            // 
            this.txtName2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtName2.Location = new System.Drawing.Point(36, 56);
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(120, 20);
            this.txtName2.TabIndex = 3;
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label3.Location = new System.Drawing.Point(164, 16);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(72, 16);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Value";
            // 
            // txtValue1
            // 
            this.txtValue1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtValue1.Location = new System.Drawing.Point(164, 32);
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.Size = new System.Drawing.Size(120, 20);
            this.txtValue1.TabIndex = 2;
            this.txtValue1.Text = "3.14159265";
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label2.Location = new System.Drawing.Point(36, 16);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(72, 16);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Name";
            // 
            // txtName1
            // 
            this.txtName1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtName1.Location = new System.Drawing.Point(36, 32);
            this.txtName1.Name = "txtName1";
            this.txtName1.Size = new System.Drawing.Size(120, 20);
            this.txtName1.TabIndex = 1;
            this.txtName1.Text = "Pi";
            // 
            // txtExpression
            // 
            this.txtExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpression.Location = new System.Drawing.Point(6, 22);
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(313, 20);
            this.txtExpression.TabIndex = 10;
            this.txtExpression.Text = "Cos(Pi/4)^2";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(6, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(72, 16);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Expression";
            // 
            // howto_evaluate_expressions_Form1
            // 
            this.AcceptButton = this.btnEvaluate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 273);
            this.Controls.Add(this.btnEvaluate);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.txtExpression);
            this.Controls.Add(this.Label1);
            this.Name = "howto_evaluate_expressions_Form1";
            this.Text = "howto_evaluate_expressions";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnEvaluate;
        internal System.Windows.Forms.TextBox txtResult;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtValue4;
        internal System.Windows.Forms.TextBox txtName4;
        internal System.Windows.Forms.TextBox txtValue3;
        internal System.Windows.Forms.TextBox txtName3;
        internal System.Windows.Forms.TextBox txtValue2;
        internal System.Windows.Forms.TextBox txtName2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtValue1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtName1;
        internal System.Windows.Forms.TextBox txtExpression;
        internal System.Windows.Forms.Label Label1;
    }
}

