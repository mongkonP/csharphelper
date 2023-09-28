using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using howto_list_ancestors;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_ancestors_Form1:Form
  { 


        public howto_list_ancestors_Form1()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            lblNumClasses.Text = "";
            lstClasses.Items.Clear();
            lstAncestors.Items.Clear();
            Cursor = Cursors.WaitCursor;
            Refresh();

            // List the loaded assemblies.
            foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine(assembly.GetName().Name);
            int num_assemblies = AppDomain.CurrentDomain.GetAssemblies().Length;
            Console.WriteLine(num_assemblies.ToString() + " assemblies");

            // Get the type entered.
            string type_name = txtType.Text.ToLower();
            var type_query =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where (type.Name.ToLower() == type_name)
                select type;
            Type target_type = type_query.FirstOrDefault();

            if (target_type != null)
            {
                // Get classes that are assignable to the target type.
                var classes =
                    from assembly in AppDomain.CurrentDomain.GetAssemblies()
                    from type in assembly.GetTypes()
                    where target_type.IsAssignableFrom(type)
                    select type;

                // Display the classes.
                foreach (Type type in classes)
                {
                    lstClasses.Items.Add(new TypeInfo(type));
                }
            }

            // Display the number of classes.
            lblNumClasses.Text = lstClasses.Items.Count.ToString() + " classes";
            Cursor = Cursors.Default;
        }

        // Display the ancestors of the selected class.
        private void lstClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAncestors.Items.Clear();
            if (lstClasses.SelectedIndex == -1) return;
            Cursor = Cursors.WaitCursor;
            Refresh();

            // Get the type.
            List<TypeInfo> types = new List<TypeInfo>();
            TypeInfo the_type = (TypeInfo)lstClasses.SelectedItem;
            types.Add(the_type);
            for (Type parent = the_type.TheType.BaseType;
                parent != null;
                parent = parent.BaseType)
            {
                types.Insert(0, new TypeInfo(parent));
            }
            for (int i = 0; i < types.Count; i++)
            {
                lstAncestors.Items.Add(new string(' ', i * 2) + types[i].TheType.Name);
            }

            Cursor = Cursors.Default;
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
            this.lblNumClasses = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstAncestors = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstClasses = new System.Windows.Forms.ListBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumClasses
            // 
            this.lblNumClasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumClasses.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumClasses.Location = new System.Drawing.Point(10, 221);
            this.lblNumClasses.Name = "lblNumClasses";
            this.lblNumClasses.Size = new System.Drawing.Size(356, 23);
            this.lblNumClasses.TabIndex = 15;
            this.lblNumClasses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Type:";
            // 
            // lstAncestors
            // 
            this.lstAncestors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAncestors.FormattingEnabled = true;
            this.lstAncestors.IntegralHeight = false;
            this.lstAncestors.Location = new System.Drawing.Point(179, 3);
            this.lstAncestors.Name = "lstAncestors";
            this.lstAncestors.Size = new System.Drawing.Size(171, 173);
            this.lstAncestors.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lstClasses, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstAncestors, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(353, 179);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // lstClasses
            // 
            this.lstClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstClasses.FormattingEnabled = true;
            this.lstClasses.IntegralHeight = false;
            this.lstClasses.Location = new System.Drawing.Point(3, 3);
            this.lstClasses.Name = "lstClasses";
            this.lstClasses.Size = new System.Drawing.Size(170, 173);
            this.lstClasses.Sorted = true;
            this.lstClasses.TabIndex = 2;
            this.lstClasses.SelectedIndexChanged += new System.EventHandler(this.lstClasses_SelectedIndexChanged);
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtType.Location = new System.Drawing.Point(53, 12);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(232, 20);
            this.txtType.TabIndex = 12;
            this.txtType.Text = "IDisposable";
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(291, 10);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 14;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // howto_list_ancestors_Form1
            // 
            this.AcceptButton = this.btnFind;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 255);
            this.Controls.Add(this.lblNumClasses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.btnFind);
            this.Name = "howto_list_ancestors_Form1";
            this.Text = "howto_list_ancestors";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumClasses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstAncestors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lstClasses;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Button btnFind;
    }
}

