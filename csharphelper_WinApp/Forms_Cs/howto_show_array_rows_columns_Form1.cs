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
     public partial class howto_show_array_rows_columns_Form1:Form
  { 


        public howto_show_array_rows_columns_Form1()
        {
            InitializeComponent();
        }

        private void howto_show_array_rows_columns_Form1_Load(object sender, EventArgs e)
        {
            string[, ,] values =
            {
                {
                    { "(0, 0, 0)", "(0, 0, 1)", "(0, 0, 2)", "(0, 0, 3)", },
                    { "(0, 1, 0)", "(0, 1, 1)", "(0, 1, 2)", "(0, 1, 3)", },
                },
                {
                    { "(1, 1, 0)", "(1, 1, 1)", "(1, 1, 2)", "(1, 0, 3)", },
                    { "(1, 1, 0)", "(1, 1, 1)", "(1, 1, 2)", "(1, 1, 3)", },
                },
                {
                    { "(2, 1, 0)", "(2, 1, 1)", "(2, 1, 2)", "(2, 0, 3)", },
                    { "(2, 1, 0)", "(2, 1, 1)", "(2, 1, 2)", "(2, 1, 3)", },
                },
            };

            // Display the values.
            txtValues.Text = GetArrayValueString(values);
            txtValues.Select(0, 0);
        }

        // Return a string showing the array's values.
        private string GetArrayValueString(Array array)
        {
            string result = "";

            // Get the array's rank (number of dimensions).
            int rank = array.GetType().GetArrayRank();

            // Get the upper bounds for the array's dimensions.
            int[] counts = new int[rank];
            for (int i = 0; i < rank; i++)
            {
                counts[i] = array.GetUpperBound(i) + 1;
            }

            // Make an array to show the current indices.
            int[] indices = new int[rank];

            // Recursively list the items at the first dimension.
            result = ListItemsForDimension(array, counts, indices, 0);

            // Replace the very last , with a ;.
            int last_comma_pos = result.LastIndexOf(",");
            result = result.Substring(0, last_comma_pos) + ";\r\n";

            return result;
        }

        // Recursively list the items for the indicated dimension.
        private string ListItemsForDimension(Array array, int[] counts, int[] indices, int dimension)
        {
            string indent = new string(' ', dimension * 4);

            // See if this is the innermost dimension.
            if (dimension == counts.Length - 1)
            {
                string result = indent + "{ ";

                // Loop over the indices for this dimension.
                for (int i = 0; i < counts[dimension]; i++)
                {
                    // Set the index for this item.
                    indices[dimension] = i;

                    // Get the item's value.
                    result += "\"" + array.GetValue(indices).ToString() + "\", ";
                }

                result += "},\r\n";
                return result;
            }
            else
            {
                string result = indent + "{\r\n";

                // Loop over the indices for this dimension.
                for (int i = 0; i < counts[dimension]; i++)
                {
                    // Set the index for this item.
                    indices[dimension] = i;

                    // Recursively list the sub-items.
                    result += ListItemsForDimension(array, counts, indices, dimension + 1);
                }

                result += indent + "},\r\n";
                return result;
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
            this.txtValues.Size = new System.Drawing.Size(330, 217);
            this.txtValues.TabIndex = 1;
            // 
            // howto_show_array_rows_columns_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 241);
            this.Controls.Add(this.txtValues);
            this.Name = "howto_show_array_rows_columns_Form1";
            this.Text = "howto_show_array_rows_columns";
            this.Load += new System.EventHandler(this.howto_show_array_rows_columns_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValues;
    }
}

