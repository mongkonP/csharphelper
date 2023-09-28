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
     public partial class howto_context_sensitive_accept_button_Form1:Form
  { 


        public howto_context_sensitive_accept_button_Form1()
        {
            InitializeComponent();
        }

        // Used to make random values.
        Random Rand = new Random(1111);

        // The hash table.
        private int[] HashTable;
        private int TableSize = 0;
        private int MinValue = 0;
        private int MaxValue = 0;
        private int NumUsed = 0;

        // The special value marking empty spots.
        private const int Empty = int.MinValue;

        // Make the hash table.
        private void createButton_Click(object sender, EventArgs e)
        {
            try
            {
                TableSize = int.Parse(sizeTextBox.Text);
                HashTable = new int[TableSize];
                for (int i = 0; i < TableSize; i++) HashTable[i] = Empty;

                ShowStatistics();

                loadTableGroupBox.Enabled = true;
                createFindGroupBox.Enabled = true;
                statisticsGroupBox.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Make some items.
        private void makeItemsButton_Click(object sender, EventArgs e)
        {
            try
            {
                int numItems = int.Parse(numItemsTextBox.Text);
                MinValue = int.Parse(minTextBox.Text);
                MaxValue = int.Parse(maxTextBox.Text);
                int itemsAdded = 0;
                int index;
                while (itemsAdded < numItems)
                {
                    try
                    {
                        AddItem(Rand.Next(MinValue, MaxValue + 1), out index);
                        itemsAdded++;
                    }
                    catch (ArgumentException)
                    {
                        // Duplicate value. Try again.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ShowStatistics();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            int probes;
            try
            {
                int key = int.Parse(itemTextBox.Text);
                int index;
                probes = AddItem(key, out index);
                MessageBox.Show("Item added. Index: " + index +
                    ", Probes: " + probes);

                ShowStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Find the indicated item.
        private void findButton_Click(object sender, EventArgs e)
        {
            try
            {
                int key = int.Parse(itemTextBox.Text);
                int index;
                int probes = FindItem(key, out index);
                MessageBox.Show("Index: " + index + ", Probes: " + probes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Display the table's contents and statistics.
        private void ShowStatistics()
        {
            // Display the items in the table.
            string text = "";
            for (int i = 0; i < TableSize; i++)
            {
                if (HashTable[i] == Empty)
                {
                    text += string.Format("{0,4} ", "---");
                }
                else
                {
                    text += string.Format("{0,4} ", HashTable[i]);
                }
                if ((i + 1) % 10 == 0)
                    text = text.Substring(0, text.Length - 1) +
                        Environment.NewLine;
            }
            tableTextBox.Text = text;
            tableTextBox.Select(0, 0);

            // Percent full.
            float pct = 100f * NumUsed / TableSize;
            fillPercentTextBox.Text = pct.ToString("0.00");

            // Check probe sequences.
            int total = 0;
            int index;
            int maxProbes = 0;
            for (int i = MinValue; i <= MaxValue; i++)
            {
                int probes = FindItem(i, out index);
                total += probes;
                if (maxProbes < probes) maxProbes = probes;
            }
            longestTextBox.Text = maxProbes.ToString();
            float ave = total / (MaxValue - MinValue + 1f);
            averageTextBox.Text = ave.ToString("0.00");
        }

        // Add an item to the hash table.
        // Return the length of the probe sequence.
        // Throw an exception if the table is full
        // or the item is already in the table.
        private int AddItem(int key, out int index)
        {
            int probe = key % TableSize;
            int stride = 1;
            for (int probes = 1; probes <= TableSize; probes++)
            {
                // See if this spot is empty.
                if (HashTable[probe] == Empty)
                {
                    // Put the value here.
                    HashTable[probe] = key;
                    index = probe;
                    NumUsed++;
                    return probes;
                }

                // See if the target key is here.
                if (HashTable[probe] == key)
                    throw new ArgumentException(
                        "This key is already in the hash table. Index: " +
                        probe + ", Probes: " + probes);

                // Try a new probe.
                probe = (probe + stride) % TableSize;
            }

            throw new IndexOutOfRangeException("The hash table is full");
        }

        // Find an item in the hash table.
        // Set index to its location or -1 if the item isn't present.
        // Return the length of the probe sequence.
        private int FindItem(int key, out int index)
        {
            int probe = key % TableSize;
            int stride = 1;
            for (int probes = 1; probes <= TableSize; probes++)
            {
                // See if this spot is empty.
                if (HashTable[probe] == Empty)
                {
                    // The key isn't in the table.
                    index = -1;
                    return probes;
                }

                // See if the key is here.
                if (HashTable[probe] == key)
                {
                    // We found the key.
                    index = probe;
                    return probes;
                }

                // Try the next probe.
                probe = (probe + stride) % TableSize;
            }

            // The key isn't in the table (and the table is full).
            index = -1;
            return TableSize;
        }

        private void createGroupBox_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = createButton;
        }

        private void loadTableGroupBox_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = makeItemsButton;
        }

        private void createFindGroupBox_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = findButton;
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
            this.insertButton = new System.Windows.Forms.Button();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itemTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.createGroupBox = new System.Windows.Forms.GroupBox();
            this.createButton = new System.Windows.Forms.Button();
            this.sizeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numItemsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.makeItemsButton = new System.Windows.Forms.Button();
            this.fillPercentTextBox = new System.Windows.Forms.TextBox();
            this.loadTableGroupBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.statisticsGroupBox = new System.Windows.Forms.GroupBox();
            this.averageTextBox = new System.Windows.Forms.TextBox();
            this.longestTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.findButton = new System.Windows.Forms.Button();
            this.createFindGroupBox = new System.Windows.Forms.GroupBox();
            this.createGroupBox.SuspendLayout();
            this.loadTableGroupBox.SuspendLayout();
            this.statisticsGroupBox.SuspendLayout();
            this.createFindGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(110, 48);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 2;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // maxTextBox
            // 
            this.maxTextBox.Location = new System.Drawing.Point(69, 45);
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.Size = new System.Drawing.Size(37, 20);
            this.maxTextBox.TabIndex = 1;
            this.maxTextBox.Text = "999";
            this.maxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // minTextBox
            // 
            this.minTextBox.Location = new System.Drawing.Point(69, 19);
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.Size = new System.Drawing.Size(37, 20);
            this.minTextBox.TabIndex = 0;
            this.minTextBox.Text = "100";
            this.minTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Item:";
            // 
            // itemTextBox
            // 
            this.itemTextBox.Location = new System.Drawing.Point(67, 34);
            this.itemTextBox.Name = "itemTextBox";
            this.itemTextBox.Size = new System.Drawing.Size(37, 20);
            this.itemTextBox.TabIndex = 0;
            this.itemTextBox.Text = "123";
            this.itemTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Max:";
            // 
            // tableTextBox
            // 
            this.tableTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.tableTextBox.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableTextBox.Location = new System.Drawing.Point(218, 12);
            this.tableTextBox.Multiline = true;
            this.tableTextBox.Name = "tableTextBox";
            this.tableTextBox.ReadOnly = true;
            this.tableTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tableTextBox.Size = new System.Drawing.Size(384, 347);
            this.tableTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Min:";
            // 
            // createGroupBox
            // 
            this.createGroupBox.Controls.Add(this.createButton);
            this.createGroupBox.Controls.Add(this.sizeTextBox);
            this.createGroupBox.Controls.Add(this.label1);
            this.createGroupBox.Location = new System.Drawing.Point(12, 12);
            this.createGroupBox.Name = "createGroupBox";
            this.createGroupBox.Size = new System.Drawing.Size(200, 48);
            this.createGroupBox.TabIndex = 5;
            this.createGroupBox.TabStop = false;
            this.createGroupBox.Text = "Hash Table";
            this.createGroupBox.Enter += new System.EventHandler(this.createGroupBox_Enter);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(112, 18);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // sizeTextBox
            // 
            this.sizeTextBox.Location = new System.Drawing.Point(69, 21);
            this.sizeTextBox.Name = "sizeTextBox";
            this.sizeTextBox.Size = new System.Drawing.Size(37, 20);
            this.sizeTextBox.TabIndex = 0;
            this.sizeTextBox.Text = "101";
            this.sizeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Size:";
            // 
            // numItemsTextBox
            // 
            this.numItemsTextBox.Location = new System.Drawing.Point(69, 71);
            this.numItemsTextBox.Name = "numItemsTextBox";
            this.numItemsTextBox.Size = new System.Drawing.Size(37, 20);
            this.numItemsTextBox.TabIndex = 2;
            this.numItemsTextBox.Text = "80";
            this.numItemsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "# Items:";
            // 
            // makeItemsButton
            // 
            this.makeItemsButton.Location = new System.Drawing.Point(112, 43);
            this.makeItemsButton.Name = "makeItemsButton";
            this.makeItemsButton.Size = new System.Drawing.Size(75, 23);
            this.makeItemsButton.TabIndex = 3;
            this.makeItemsButton.Text = "Make Items";
            this.makeItemsButton.UseVisualStyleBackColor = true;
            this.makeItemsButton.Click += new System.EventHandler(this.makeItemsButton_Click);
            // 
            // fillPercentTextBox
            // 
            this.fillPercentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fillPercentTextBox.Location = new System.Drawing.Point(93, 22);
            this.fillPercentTextBox.Name = "fillPercentTextBox";
            this.fillPercentTextBox.ReadOnly = true;
            this.fillPercentTextBox.Size = new System.Drawing.Size(92, 20);
            this.fillPercentTextBox.TabIndex = 0;
            this.fillPercentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // loadTableGroupBox
            // 
            this.loadTableGroupBox.Controls.Add(this.maxTextBox);
            this.loadTableGroupBox.Controls.Add(this.label5);
            this.loadTableGroupBox.Controls.Add(this.minTextBox);
            this.loadTableGroupBox.Controls.Add(this.label4);
            this.loadTableGroupBox.Controls.Add(this.numItemsTextBox);
            this.loadTableGroupBox.Controls.Add(this.label2);
            this.loadTableGroupBox.Controls.Add(this.makeItemsButton);
            this.loadTableGroupBox.Enabled = false;
            this.loadTableGroupBox.Location = new System.Drawing.Point(12, 66);
            this.loadTableGroupBox.Name = "loadTableGroupBox";
            this.loadTableGroupBox.Size = new System.Drawing.Size(200, 99);
            this.loadTableGroupBox.TabIndex = 6;
            this.loadTableGroupBox.TabStop = false;
            this.loadTableGroupBox.Text = "Load Table";
            this.loadTableGroupBox.Enter += new System.EventHandler(this.loadTableGroupBox_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Fill %";
            // 
            // statisticsGroupBox
            // 
            this.statisticsGroupBox.Controls.Add(this.fillPercentTextBox);
            this.statisticsGroupBox.Controls.Add(this.label8);
            this.statisticsGroupBox.Controls.Add(this.averageTextBox);
            this.statisticsGroupBox.Controls.Add(this.longestTextBox);
            this.statisticsGroupBox.Controls.Add(this.label7);
            this.statisticsGroupBox.Controls.Add(this.label6);
            this.statisticsGroupBox.Enabled = false;
            this.statisticsGroupBox.Location = new System.Drawing.Point(14, 255);
            this.statisticsGroupBox.Name = "statisticsGroupBox";
            this.statisticsGroupBox.Size = new System.Drawing.Size(198, 104);
            this.statisticsGroupBox.TabIndex = 8;
            this.statisticsGroupBox.TabStop = false;
            this.statisticsGroupBox.Text = "Statistics";
            // 
            // averageTextBox
            // 
            this.averageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.averageTextBox.Location = new System.Drawing.Point(93, 74);
            this.averageTextBox.Name = "averageTextBox";
            this.averageTextBox.ReadOnly = true;
            this.averageTextBox.Size = new System.Drawing.Size(92, 20);
            this.averageTextBox.TabIndex = 2;
            this.averageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // longestTextBox
            // 
            this.longestTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.longestTextBox.Location = new System.Drawing.Point(93, 48);
            this.longestTextBox.Name = "longestTextBox";
            this.longestTextBox.ReadOnly = true;
            this.longestTextBox.Size = new System.Drawing.Size(92, 20);
            this.longestTextBox.TabIndex = 1;
            this.longestTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Ave Probe:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Max Probe:";
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(110, 19);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 1;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // createFindGroupBox
            // 
            this.createFindGroupBox.Controls.Add(this.insertButton);
            this.createFindGroupBox.Controls.Add(this.label3);
            this.createFindGroupBox.Controls.Add(this.itemTextBox);
            this.createFindGroupBox.Controls.Add(this.findButton);
            this.createFindGroupBox.Enabled = false;
            this.createFindGroupBox.Location = new System.Drawing.Point(14, 171);
            this.createFindGroupBox.Name = "createFindGroupBox";
            this.createFindGroupBox.Size = new System.Drawing.Size(198, 78);
            this.createFindGroupBox.TabIndex = 7;
            this.createFindGroupBox.TabStop = false;
            this.createFindGroupBox.Text = "Create/Find";
            this.createFindGroupBox.Enter += new System.EventHandler(this.createFindGroupBox_Enter);
            // 
            // howto_context_sensitive_accept_button_Form1
            // 
            this.AcceptButton = this.createButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 371);
            this.Controls.Add(this.tableTextBox);
            this.Controls.Add(this.createGroupBox);
            this.Controls.Add(this.loadTableGroupBox);
            this.Controls.Add(this.statisticsGroupBox);
            this.Controls.Add(this.createFindGroupBox);
            this.Name = "howto_context_sensitive_accept_button_Form1";
            this.Text = "howto_context_sensitive_accept_button";
            this.createGroupBox.ResumeLayout(false);
            this.createGroupBox.PerformLayout();
            this.loadTableGroupBox.ResumeLayout(false);
            this.loadTableGroupBox.PerformLayout();
            this.statisticsGroupBox.ResumeLayout(false);
            this.statisticsGroupBox.PerformLayout();
            this.createFindGroupBox.ResumeLayout(false);
            this.createFindGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.TextBox maxTextBox;
        private System.Windows.Forms.TextBox minTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox itemTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tableTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox createGroupBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.TextBox sizeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numItemsTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button makeItemsButton;
        private System.Windows.Forms.TextBox fillPercentTextBox;
        private System.Windows.Forms.GroupBox loadTableGroupBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox statisticsGroupBox;
        private System.Windows.Forms.TextBox averageTextBox;
        private System.Windows.Forms.TextBox longestTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.GroupBox createFindGroupBox;
    }
}

