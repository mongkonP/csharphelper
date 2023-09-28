using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_stable_appointments;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_stable_appointments_Form1:Form
  { 


        public howto_stable_appointments_Form1()
        {
            InitializeComponent();
        }


        // Make some random preferences.
        private void howto_stable_appointments_Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();

            string txt = "";
            int pref = 0;
            for (int i = 1; i <= Person.DEFAULT_NUM_PEOPLE; i++)
            {
                txt += (char)((int)'A' + i - 1) + " ";

                for (int j = 1; j <= Person.NUM_PREFERENCES; j++)
                {
                    pref = (pref + rnd.Next(1, Person.NUM_CHOICES - j + 1)) % Person.NUM_CHOICES;
                    txt += pref + " ";
                }
                txt = txt + "\r\n";
            }

            txtPreferences.Text = txt;
            txtPreferences.Select(0, 0);
        }

        // Make assignments
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get the Persons' preferences.
            string txt = txtPreferences.Text;
            while (txt.EndsWith("\r\n"))
            {
                txt = txt.Substring(0, txt.Length - "\r\n".Length);
            }
            txt = txt.Replace("\r\n", "\n");
            string[] lines = txt.Split('\n');
            int num_people = lines.Length;

            Person[] people = new Person[num_people];
            for (int i = 0; i < num_people; i++)
                people[i] = new Person(lines[i]);

            // Clear assignments.
            Person[] assigned_to = new Person[Person.NUM_CHOICES];
            for (int i = 0; i < Person.NUM_CHOICES; i++)
            {
                assigned_to[i] = null;
            }

            // Make initial choice assignments.
            for (int pref = 0; pref < Person.NUM_PREFERENCES; pref++)
            {
                // Try to assign this choice for Persons.
                foreach (Person per in people)
                {
                    // See if this Person has an assignment yet.
                    if (per.Assignment < 0)
                    {
                        // This Person is unassigned.
                        // See if this choice is available.
                        int desired_choice = per.Preferences[pref];
                        if (assigned_to[desired_choice] == null)
                        {
                            // Assign this Person.
                            assigned_to[desired_choice] = per;
                            per.Assignment = desired_choice;
                        }
                    }
                }
            }

            // Assign anyone without an assignment.
            foreach (Person per in people)
            {
                // See if this Person has an assignment yet.
                if (per.Assignment < 0)
                {
                    // This Person is unassigned.
                    // Find an available choice.
                    for (int i = 0; i < Person.NUM_CHOICES; i++)
                    {
                        if (assigned_to[i] == null)
                        {
                            // Assign this Person.
                            assigned_to[i] = per;
                            per.Assignment = i;
                            break;
                        }
                    }
                }
            }

            // Try to improve the assignments.
            bool had_improvement;
            do
            {
                had_improvement = false;

                // Look for profitable swaps.
                foreach (Person per in people)
                {
                    foreach (Person per2 in people)
                    {
                        int per2_assignment = per2.Assignment;
                        int per_assignment = per.Assignment;

                        // See if per and per2 should swap.
                        int old_cost = per.Value + per2.Value;
                        int new_cost =
                            per.ValueOf(per2_assignment) +
                            per2.ValueOf(per_assignment);
                        if (new_cost < old_cost)
                        {
                            // Make the swap.
                            per.Assignment = per2_assignment;
                            per2.Assignment = per_assignment;
                            assigned_to[per_assignment] = per2;
                            assigned_to[per2_assignment] = per;
                            had_improvement = true;
                        }
                    }
                }
            } while (had_improvement);

            // Display the results.
            txtAssignments.Text = AssignmentSummary(assigned_to, people);
        }

        // Display the assignments.
        private string AssignmentSummary(Person[] assigned_to, Person[] people)
        {
            int total = 0;
            string txt = "Assignments" + "\r\n";
            for (int i = 0; i < assigned_to.Length; i++)
            {
                if (assigned_to[i] == null)
                {
                    txt += i + ": Nothing" + "\r\n";
                    total = total + Person.DONT_WANT;
                }
                else
                {
                    txt = txt + i + ": " + assigned_to[i].AssignmentString() + "\r\n";
                    total = total + assigned_to[i].Value;
                }
            }
            txt = txt + "----------" + "\r\n";

            txt = txt + "People" + "\r\n";
            total = 0;
            for (int i = 0; i < people.Length; i++)
            {
                txt = txt + people[i].Name + " " + people[i].Assignment +
                    " (" + people[i].Value + ")\r\n";
                total = total + people[i].Value;
            }
            txt = txt + "Total Value: " + total + "\r\n";

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
            this.btnGo = new System.Windows.Forms.Button();
            this.txtAssignments = new System.Windows.Forms.TextBox();
            this.txtPreferences = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPreferences = new System.Windows.Forms.Label();
            this.lblAssignments = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(108, 23);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(44, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtAssignments
            // 
            this.txtAssignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAssignments.Location = new System.Drawing.Point(158, 23);
            this.txtAssignments.Multiline = true;
            this.txtAssignments.Name = "txtAssignments";
            this.txtAssignments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAssignments.Size = new System.Drawing.Size(99, 164);
            this.txtAssignments.TabIndex = 2;
            // 
            // txtPreferences
            // 
            this.txtPreferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreferences.Location = new System.Drawing.Point(3, 23);
            this.txtPreferences.Multiline = true;
            this.txtPreferences.Name = "txtPreferences";
            this.txtPreferences.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPreferences.Size = new System.Drawing.Size(99, 164);
            this.txtPreferences.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnGo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAssignments, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPreferences, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPreferences, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAssignments, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 190);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // lblPreferences
            // 
            this.lblPreferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreferences.Location = new System.Drawing.Point(3, 0);
            this.lblPreferences.Name = "lblPreferences";
            this.lblPreferences.Size = new System.Drawing.Size(99, 20);
            this.lblPreferences.TabIndex = 5;
            this.lblPreferences.Text = "Preferences";
            this.lblPreferences.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAssignments
            // 
            this.lblAssignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAssignments.Location = new System.Drawing.Point(158, 0);
            this.lblAssignments.Name = "lblAssignments";
            this.lblAssignments.Size = new System.Drawing.Size(99, 20);
            this.lblAssignments.TabIndex = 7;
            this.lblAssignments.Text = "Assignments";
            this.lblAssignments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_stable_appointments_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 214);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_stable_appointments_Form1";
            this.Text = "howto_stable_appointments";
            this.Load += new System.EventHandler(this.howto_stable_appointments_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtAssignments;
        internal System.Windows.Forms.TextBox txtPreferences;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.Label lblPreferences;
        internal System.Windows.Forms.Label lblAssignments;
    }
}

