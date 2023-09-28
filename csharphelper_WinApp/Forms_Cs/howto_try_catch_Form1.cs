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
     public partial class howto_try_catch_Form1:Form
  { 


        public howto_try_catch_Form1()
        {
            InitializeComponent();
        }

        // Perform the calculation.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Clear the result (in case the calculation fails).
            txtResult.Clear();

            try
            {
                // Perform the operations that might fail.
                int x = int.Parse(txtX.Text);
                int y = int.Parse(txtY.Text);
                float result = x / y;
                txtResult.Text = result.ToString();
            }
            catch (FormatException)
            {
                // A formatting error occurred.
                // Report the error to the user.
                MessageBox.Show(
                    "The input values must be integers.",
                    "Invalid Input Values",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Some other error occurred.
                // Report the error to the user.
                MessageBox.Show(ex.Message, "Calculation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Record the kind of exception class so we can catch it specifically.
                Console.WriteLine(ex.GetType().Name);
            }
            finally
            {
                MessageBox.Show("Done", "Done", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(105, 49);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X:";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(54, 12);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(62, 20);
            this.txtX.TabIndex = 2;
            this.txtX.Text = "ten";
            this.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(191, 12);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(62, 20);
            this.txtY.TabIndex = 4;
            this.txtY.Text = "0";
            this.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y:";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(98, 91);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(124, 20);
            this.txtResult.TabIndex = 6;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "X/Y:";
            // 
            // howto_try_catch_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 128);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalculate);
            this.Name = "howto_try_catch_Form1";
            this.Text = "howto_try_catch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label3;
    }
}

