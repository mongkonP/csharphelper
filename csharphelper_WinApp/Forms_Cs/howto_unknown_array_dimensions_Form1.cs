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
     public partial class howto_unknown_array_dimensions_Form1:Form
  { 


        public howto_unknown_array_dimensions_Form1()
        {
            InitializeComponent();
        }

        private void howto_unknown_array_dimensions_Form1_Load(object sender, EventArgs e)
        {
            // List the values in an array of unknown dimensions.
            string[, ,] values3 =
            {
                {
                    { "(0, 0, 0)", "(0, 0, 1)" },
                    { "(0, 1, 0)", "(0, 1, 1)" },
                    { "(0, 2, 0)", "(0, 2, 1)" },
                },
                {
                    { "(1, 0, 0)", "(1, 0, 1)" },
                    { "(1, 1, 0)", "(1, 1, 1)" },
                    { "(1, 2, 0)", "(1, 2, 1)" },
                },
                {
                    { "(2, 0, 0)", "(2, 0, 1)" },
                    { "(2, 1, 0)", "(2, 1, 1)" },
                    { "(2, 2, 0)", "(2, 2, 1)" },
                },
                {
                    { "(3, 0, 0)", "(3, 0, 1)" },
                    { "(3, 1, 0)", "(3, 1, 1)" },
                    { "(3, 2, 0)", "(3, 2, 1)" },
                },
            };
            txtValues.Text = ArrayTextValue(values3);
            txtValues.Select(0, 0);
        }

        // Return a string holding the values in
        // an array of unknown dimension.
        private string ArrayTextValue(Array values)
        {
            // Make an array to hold indices.
            int num_dimensions = values.Rank;
            int[] indices = new int[num_dimensions];

            // Get and display the array's textual representation.
            return GetArrayTextValues(values, 0, indices, 0);
        }

        // Recursively return a string representation of the
        // values in an array from the given position onward.
        private string GetArrayTextValues(Array values, int indent, int[] indices, int dimension_num)
        {
            string spaces = new string(' ', indent);
            string txt = spaces + "{";

            // Loop through the values at this index.
            int max_index = values.GetUpperBound(dimension_num);
            for (int i = 0; i <= max_index; i++)
            {
                indices[dimension_num] = i;

                // See if this is the next to last dimension.
                if (dimension_num == values.Rank - 2)
                {
                    // This is the next to last dimension. Return the value.
                    txt += Environment.NewLine + spaces + "    { " +
                        GetArrayInnermostData(values, indices) + " }";
                }
                else
                {
                    // This is not the last dimension. Recurse.
                    txt += Environment.NewLine +
                        GetArrayTextValues(values, indent + 4, indices, dimension_num + 1);
                }
            }

            txt += Environment.NewLine + spaces + "}";
            return txt;
        }

        // Return the innermost row of data separated by spaces.
        private string GetArrayInnermostData(Array values, int[] indices)
        {
            string txt = "";

            // Get the index of the last dimension.
            int dimension_num = values.Rank - 1;

            // Conatenate the values.
            int max_index = values.GetUpperBound(dimension_num);
            for (int i = 0; i <= max_index; i++)
            {
                indices[dimension_num] = i;
                txt += " " + values.GetValue(indices).ToString();
            }

            txt = txt.Substring(1);
            return txt;
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
            this.txtValues = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtValues
            // 
            this.txtValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValues.Location = new System.Drawing.Point(12, 12);
            this.txtValues.Multiline = true;
            this.txtValues.Name = "txtValues";
            this.txtValues.ReadOnly = true;
            this.txtValues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtValues.Size = new System.Drawing.Size(210, 297);
            this.txtValues.TabIndex = 4;
            // 
            // howto_unknown_array_dimensions_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 321);
            this.Controls.Add(this.txtValues);
            this.Name = "howto_unknown_array_dimensions_Form1";
            this.Text = "howto_unknown_array_dimensions";
            this.Load += new System.EventHandler(this.howto_unknown_array_dimensions_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValues;
    }
}

