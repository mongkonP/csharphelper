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
     public partial class howto_demonstrate_finally_Form1:Form
  { 


        public howto_demonstrate_finally_Form1()
        {
            InitializeComponent();
        }

        // Run normally without errors.
        // Produces:    Statement
        //              Finally
        private void btnNormal_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();
            try
            {
                // No error here.
                lstResults.Items.Add("Statement");
            }
            catch (Exception ex)
            {
                lstResults.Items.Add("Error: " + ex.Message);
            }
            finally
            {
                lstResults.Items.Add("Finally");
            }
        }

        // Use a break statement.
        // Produces:    Statement
        //              About to break
        //              Finally
        private void btnBreak_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            for (; ; )
            {
                try
                {
                    // No error here.
                    lstResults.Items.Add("Statement");

                    // Break.
                    lstResults.Items.Add("About to break");
                    break;

                    // The compiler knows that the following code is unreachable.
                    lstResults.Items.Add("Never gets here");
                }
                catch (Exception ex)
                {
                    lstResults.Items.Add("Error: " + ex.Message);
                }
                finally
                {
                    lstResults.Items.Add("Finally");
                }
            }
        }

        // Use a continue statement.
        // Produces:    Statement
        //              About to continue
        //              Finally
        private void btnContinue_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            do
            {
                try
                {
                    // No error here.
                    lstResults.Items.Add("Statement");

                    // Continue.
                    lstResults.Items.Add("About to continue");
                    continue;

                    // The compiler knows that the following code is unreachable.
                    lstResults.Items.Add("Never gets here");
                }
                catch (Exception ex)
                {
                    lstResults.Items.Add("Error: " + ex.Message);
                }
                finally
                {
                    lstResults.Items.Add("Finally");
                }

                lstResults.Items.Add("Never gets here");
            } while (false);
        }

        // Throw an error.
        // Produces:    Statement
        //              Error: Specified argument was out of the range of valid values.
        //              Finally
        private void btnError_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            try
            {
                lstResults.Items.Add("Statement");

                // Throw an error.
                throw new ArgumentOutOfRangeException();

                // The compiler knows that the following code is unreachable.
                lstResults.Items.Add("Never gets here");
            }
            catch (Exception ex)
            {
                lstResults.Items.Add("Error: " + ex.Message);
            }
            finally
            {
                lstResults.Items.Add("Finally");
            }
        }

        // Return.
        // Produces:    Statement
        //              Finally
        private void btnReturn_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            try
            {
                lstResults.Items.Add("Statement");

                // Return.
                return;

                // The compiler knows that the following code is unreachable.
                lstResults.Items.Add("Never gets here");
            }
            catch (Exception ex)
            {
                lstResults.Items.Add("Error: " + ex.Message);
            }
            finally
            {
                lstResults.Items.Add("Finally");
            }
        }

        // Throw an error and then another in the catch block.
        // Produces:    Statement
        //              Error: Specified argument was out of the range of valid values.
        //              Nested Error: Specified argument was out of the range of valid values.
        //              Nested Finally
        //              Finally
        private void btn2Errors_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            try
            {
                lstResults.Items.Add("Statement");

                // Throw an error.
                throw new ArgumentOutOfRangeException();

                // The compiler knows that the following code is unreachable.
                lstResults.Items.Add("Never gets here");
            }
            catch (Exception ex)
            {
                lstResults.Items.Add("Error: " + ex.Message);

                // Throw another error.
                try
                {
                    throw new ArgumentOutOfRangeException();

                    // The compiler knows that the following code is unreachable.
                    lstResults.Items.Add("Never gets here");
                }
                catch (Exception inner_ex)
                {
                    lstResults.Items.Add("Nested Error: " + inner_ex.Message);
                }
                finally
                {
                    lstResults.Items.Add("Nested Finally");
                }
            }
            finally
            {
                lstResults.Items.Add("Finally");
            }
        }

        // Throw an error and return from within the catch block.
        // Produces:    Statement
        //              Error: Specified argument was out of the range of valid values.
        //              Finally
        private void btnErrorReturn_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            try
            {
                lstResults.Items.Add("Statement");

                // Throw an error.
                throw new ArgumentOutOfRangeException();

                // The compiler knows that the following code is unreachable.
                lstResults.Items.Add("Never gets here");
            }
            catch (Exception ex)
            {
                lstResults.Items.Add("Error: " + ex.Message);

                // Return.
                return;

                // The compiler knows that the following code is unreachable.
                lstResults.Items.Add("Never gets here");
            }
            finally
            {
                lstResults.Items.Add("Finally");
            }
        }

        // Use Application.Exit to end the application.
        // This closes the window so this method displays
        // output in the console window.
        // Produces:    Statement
        //              The code actually gets here!
        //              Finally
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Statement");

                // Exit.
                Application.Exit();

                Console.WriteLine("The code actually gets here!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // The code does get here but the window
                // goes away so you can't see messages there.
                Console.WriteLine("Finally");
            }
        }

        // Use Environment.Exit to end the application.
        // This closes the window so this method displays
        // output in the console window.
        // Produces:    Statement
        private void btnEnvExit_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Statement");

                // Exit.
                Environment.Exit(0);

                Console.WriteLine("The code actually gets here!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // The code does get here but the window
                // goes away so you can't see messages there.
                Console.WriteLine("Finally");
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
            this.btnEnvExit = new System.Windows.Forms.Button();
            this.btnErrorReturn = new System.Windows.Forms.Button();
            this.btn2Errors = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnError = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnBreak = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.btnNormal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnvExit
            // 
            this.btnEnvExit.Location = new System.Drawing.Point(93, 71);
            this.btnEnvExit.Name = "btnEnvExit";
            this.btnEnvExit.Size = new System.Drawing.Size(75, 23);
            this.btnEnvExit.TabIndex = 19;
            this.btnEnvExit.Text = "Env.Exit";
            this.btnEnvExit.UseVisualStyleBackColor = true;
            this.btnEnvExit.Click += new System.EventHandler(this.btnEnvExit_Click);
            // 
            // btnErrorReturn
            // 
            this.btnErrorReturn.Location = new System.Drawing.Point(255, 42);
            this.btnErrorReturn.Name = "btnErrorReturn";
            this.btnErrorReturn.Size = new System.Drawing.Size(75, 23);
            this.btnErrorReturn.TabIndex = 17;
            this.btnErrorReturn.Text = "Err && Return";
            this.btnErrorReturn.UseVisualStyleBackColor = true;
            this.btnErrorReturn.Click += new System.EventHandler(this.btnErrorReturn_Click);
            // 
            // btn2Errors
            // 
            this.btn2Errors.Location = new System.Drawing.Point(174, 42);
            this.btn2Errors.Name = "btn2Errors";
            this.btn2Errors.Size = new System.Drawing.Size(75, 23);
            this.btn2Errors.TabIndex = 16;
            this.btn2Errors.Text = "2 Errors";
            this.btn2Errors.UseVisualStyleBackColor = true;
            this.btn2Errors.Click += new System.EventHandler(this.btn2Errors_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 71);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "App Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(93, 42);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 14;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnError
            // 
            this.btnError.Location = new System.Drawing.Point(12, 42);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(75, 23);
            this.btnError.TabIndex = 13;
            this.btnError.Text = "Error";
            this.btnError.UseVisualStyleBackColor = true;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(174, 13);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 12;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnBreak
            // 
            this.btnBreak.Location = new System.Drawing.Point(93, 13);
            this.btnBreak.Name = "btnBreak";
            this.btnBreak.Size = new System.Drawing.Size(75, 23);
            this.btnBreak.TabIndex = 11;
            this.btnBreak.Text = "Break";
            this.btnBreak.UseVisualStyleBackColor = true;
            this.btnBreak.Click += new System.EventHandler(this.btnBreak_Click);
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.IntegralHeight = false;
            this.lstResults.Location = new System.Drawing.Point(12, 100);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(319, 69);
            this.lstResults.TabIndex = 18;
            // 
            // btnNormal
            // 
            this.btnNormal.Location = new System.Drawing.Point(12, 13);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(75, 23);
            this.btnNormal.TabIndex = 10;
            this.btnNormal.Text = "Normal";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // howto_demonstrate_finally_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 181);
            this.Controls.Add(this.btnEnvExit);
            this.Controls.Add(this.btnErrorReturn);
            this.Controls.Add(this.btn2Errors);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnError);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnBreak);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnNormal);
            this.Name = "howto_demonstrate_finally_Form1";
            this.Text = "howto_demonstrate_finally";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnvExit;
        private System.Windows.Forms.Button btnErrorReturn;
        private System.Windows.Forms.Button btn2Errors;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnBreak;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Button btnNormal;
    }
}

