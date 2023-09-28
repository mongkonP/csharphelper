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
     public partial class howto_expander_list_Form1:Form
  { 


        public howto_expander_list_Form1()
        {
            InitializeComponent();
        }

        // The state of an expanding or collapsing panel.
        private enum ExpandState
        {
            Expanded,
            Expanding,
            Collapsing,
            Collapsed,
        }

        // The expanding panels' current states.
        private ExpandState[] ExpandStates;

        // The Panels to expand and collapse.
        private Panel[] ExpandPanels;

        // The expand/collapse buttons.
        private Button[] ExpandButtons;

        // Initialize.
        private void howto_expander_list_Form1_Load(object sender, EventArgs e)
        {
            // Select a state.
            cboState1.SelectedIndex = 0;

            // Initialize the arrays.
            ExpandStates = new ExpandState[]
            {
                ExpandState.Expanded,
                ExpandState.Expanded,
                ExpandState.Expanded,
            };
            ExpandPanels = new Panel[]
            {
                panAddress1,
                panAddress2,
                panImage,
            };
            ExpandButtons = new Button[]
            {
                btnExpand1,
                btnExpand2,
                btnExpand3,
            };

            // Set expander button Tag properties to give indexes
            // into these arrays and display expanded images.
            for (int i = 0; i < ExpandButtons.Length; i++)
            {
                ExpandButtons[i].Tag = i;
                ExpandButtons[i].Image = Properties.Resources.expander_up;
            }
        }

        // Start expanding.
        private void btnExpander_Click(object sender, EventArgs e)
        {
            // Get the button.
            Button btn = sender as Button;
            int index = (int)btn.Tag;

            // Get this panel's current expand
            //  state and set its new state.
            ExpandState old_state = ExpandStates[index];
            if ((old_state == ExpandState.Collapsed) ||
                (old_state == ExpandState.Collapsing))
            {
                // Was collapsed/collapsing. Start expanding.
                ExpandStates[index] = ExpandState.Expanding;
                ExpandButtons[index].Image = Properties.Resources.expander_up;
            }
            else
            {
                // Was expanded/expanding. Start collapsing.
                ExpandStates[index] = ExpandState.Collapsing;
                ExpandButtons[index].Image = Properties.Resources.expander_down;
            }

            // Make sure the timer is enabled.
            tmrExpand.Enabled = true;
        }

        // The number of pixels expanded per timer Tick.
        private const int ExpansionPerTick = 7;

        // Expand or collapse any panels that need it.
        private void tmrExpand_Tick(object sender, EventArgs e)
        {
            // Determines whether we need more adjustments.
            bool not_done = false;

            for (int i = 0; i < ExpandPanels.Length; i++)
            {
                // See if this panel needs adjustment.
                if (ExpandStates[i] == ExpandState.Expanding)
                {
                    // Expand.
                    Panel pan = ExpandPanels[i];
                    int new_height = pan.Height + ExpansionPerTick;
                    if (new_height >= pan.MaximumSize.Height)
                    {
                        // This one is done.
                        new_height = pan.MaximumSize.Height;
                    }
                    else
                    {
                        // This one is not done.
                        not_done = true;
                    }

                    // Set the new height.
                    pan.Height = new_height;
                }
                else if (ExpandStates[i] == ExpandState.Collapsing)
                {
                    // Collapse.
                    Panel pan = ExpandPanels[i];
                    int new_height = pan.Height - ExpansionPerTick;
                    if (new_height <= pan.MinimumSize.Height)
                    {
                        // This one is done.
                        new_height = pan.MinimumSize.Height;
                    }
                    else
                    {
                        // This one is not done.
                        not_done = true;
                    }

                    // Set the new height.
                    pan.Height = new_height;
                }
            }

            // If we are done, disable the timer.
            tmrExpand.Enabled = not_done;
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
            this.components = new System.ComponentModel.Container();
            this.cboState2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panAddress2 = new System.Windows.Forms.Panel();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExpand3 = new System.Windows.Forms.Button();
            this.panImage = new System.Windows.Forms.Panel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboState1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExpand2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.panAddress1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExpand1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.tmrExpand = new System.Windows.Forms.Timer(this.components);
            this.panAddress2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.panel2.SuspendLayout();
            this.panAddress1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboState2
            // 
            this.cboState2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState2.FormattingEnabled = true;
            this.cboState2.Items.AddRange(new object[] {
            "AZ",
            "CT",
            "VT",
            "NH",
            "WA",
            "CO",
            "UT",
            "NM"});
            this.cboState2.Location = new System.Drawing.Point(70, 107);
            this.cboState2.Name = "cboState2";
            this.cboState2.Size = new System.Drawing.Size(44, 21);
            this.cboState2.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "ZIP:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(174, 107);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(79, 20);
            this.textBox6.TabIndex = 9;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(70, 81);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(183, 20);
            this.textBox7.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "State:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "City:";
            // 
            // panAddress2
            // 
            this.panAddress2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panAddress2.Controls.Add(this.cboState2);
            this.panAddress2.Controls.Add(this.label7);
            this.panAddress2.Controls.Add(this.textBox6);
            this.panAddress2.Controls.Add(this.label8);
            this.panAddress2.Controls.Add(this.textBox7);
            this.panAddress2.Controls.Add(this.label9);
            this.panAddress2.Controls.Add(this.textBox8);
            this.panAddress2.Controls.Add(this.label10);
            this.panAddress2.Controls.Add(this.textBox9);
            this.panAddress2.Controls.Add(this.label11);
            this.panAddress2.Controls.Add(this.textBox10);
            this.panAddress2.Controls.Add(this.label12);
            this.panAddress2.Location = new System.Drawing.Point(3, 201);
            this.panAddress2.MaximumSize = new System.Drawing.Size(260, 136);
            this.panAddress2.MinimumSize = new System.Drawing.Size(260, 5);
            this.panAddress2.Name = "panAddress2";
            this.panAddress2.Size = new System.Drawing.Size(260, 134);
            this.panAddress2.TabIndex = 2;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(70, 55);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(183, 20);
            this.textBox8.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Street:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(70, 29);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(183, 20);
            this.textBox9.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Last Name:";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(70, 3);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(183, 20);
            this.textBox10.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "First Name:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(30, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Picture";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.btnExpand3);
            this.panel3.Location = new System.Drawing.Point(3, 341);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 23);
            this.panel3.TabIndex = 3;
            // 
            // btnExpand3
            // 
            this.btnExpand3.Image = Properties.Resources.expander_down;
            this.btnExpand3.Location = new System.Drawing.Point(0, 0);
            this.btnExpand3.Name = "btnExpand3";
            this.btnExpand3.Size = new System.Drawing.Size(24, 22);
            this.btnExpand3.TabIndex = 0;
            this.btnExpand3.UseVisualStyleBackColor = true;
            this.btnExpand3.Click += new System.EventHandler(this.btnExpander_Click);
            // 
            // panImage
            // 
            this.panImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panImage.Controls.Add(this.picImage);
            this.panImage.Location = new System.Drawing.Point(3, 370);
            this.panImage.MaximumSize = new System.Drawing.Size(260, 118);
            this.panImage.MinimumSize = new System.Drawing.Size(260, 5);
            this.panImage.Name = "panImage";
            this.panImage.Size = new System.Drawing.Size(260, 118);
            this.panImage.TabIndex = 5;
            // 
            // picImage
            // 
            this.picImage.Image = Properties.Resources.Rod001;
            this.picImage.Location = new System.Drawing.Point(2, 2);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(104, 115);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 5;
            this.picImage.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(30, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Secondary Contact";
            // 
            // cboState1
            // 
            this.cboState1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState1.FormattingEnabled = true;
            this.cboState1.Items.AddRange(new object[] {
            "AZ",
            "CT",
            "VT",
            "NH",
            "WA",
            "CO",
            "UT",
            "NM"});
            this.cboState1.Location = new System.Drawing.Point(70, 107);
            this.cboState1.Name = "cboState1";
            this.cboState1.Size = new System.Drawing.Size(44, 21);
            this.cboState1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.btnExpand2);
            this.panel2.Location = new System.Drawing.Point(3, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 23);
            this.panel2.TabIndex = 1;
            // 
            // btnExpand2
            // 
            this.btnExpand2.Image = Properties.Resources.expander_down;
            this.btnExpand2.Location = new System.Drawing.Point(0, 0);
            this.btnExpand2.Name = "btnExpand2";
            this.btnExpand2.Size = new System.Drawing.Size(24, 22);
            this.btnExpand2.TabIndex = 0;
            this.btnExpand2.UseVisualStyleBackColor = true;
            this.btnExpand2.Click += new System.EventHandler(this.btnExpander_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "ZIP:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(174, 107);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(79, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "54321";
            // 
            // panAddress1
            // 
            this.panAddress1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panAddress1.Controls.Add(this.cboState1);
            this.panAddress1.Controls.Add(this.label6);
            this.panAddress1.Controls.Add(this.textBox5);
            this.panAddress1.Controls.Add(this.label5);
            this.panAddress1.Controls.Add(this.textBox3);
            this.panAddress1.Controls.Add(this.label3);
            this.panAddress1.Controls.Add(this.textBox4);
            this.panAddress1.Controls.Add(this.label4);
            this.panAddress1.Controls.Add(this.textBox2);
            this.panAddress1.Controls.Add(this.label2);
            this.panAddress1.Controls.Add(this.textBox1);
            this.panAddress1.Controls.Add(this.label1);
            this.panAddress1.Location = new System.Drawing.Point(3, 32);
            this.panAddress1.MaximumSize = new System.Drawing.Size(260, 136);
            this.panAddress1.MinimumSize = new System.Drawing.Size(260, 5);
            this.panAddress1.Name = "panAddress1";
            this.panAddress1.Size = new System.Drawing.Size(260, 134);
            this.panAddress1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "State:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(70, 81);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(183, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Programmeria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "City:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(70, 55);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(183, 20);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "1337 Leet St";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Street:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(70, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(183, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "Stephens";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Rod";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panAddress1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panAddress2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panImage);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(14, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(268, 490);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExpand1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 23);
            this.panel1.TabIndex = 0;
            // 
            // btnExpand1
            // 
            this.btnExpand1.Image = Properties.Resources.expander_down;
            this.btnExpand1.Location = new System.Drawing.Point(0, 0);
            this.btnExpand1.Name = "btnExpand1";
            this.btnExpand1.Size = new System.Drawing.Size(24, 22);
            this.btnExpand1.TabIndex = 0;
            this.btnExpand1.UseVisualStyleBackColor = true;
            this.btnExpand1.Click += new System.EventHandler(this.btnExpander_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(30, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Primary Contact";
            // 
            // tmrExpand
            // 
            this.tmrExpand.Interval = 10;
            this.tmrExpand.Tick += new System.EventHandler(this.tmrExpand_Tick);
            // 
            // howto_expander_list_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 514);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "howto_expander_list_Form1";
            this.Text = "howto_expander_list";
            this.Load += new System.EventHandler(this.howto_expander_list_Form1_Load);
            this.panAddress2.ResumeLayout(false);
            this.panAddress2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panImage.ResumeLayout(false);
            this.panImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panAddress1.ResumeLayout(false);
            this.panAddress1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboState2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panAddress2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExpand3;
        private System.Windows.Forms.Panel panImage;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboState1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExpand2;
        private System.Windows.Forms.Button btnExpand1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Panel panAddress1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer tmrExpand;
    }
}

