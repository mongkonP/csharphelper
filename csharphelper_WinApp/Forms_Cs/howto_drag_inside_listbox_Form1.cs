using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_drag_inside_listbox;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_drag_inside_listbox_Form1:Form
  { 


        public howto_drag_inside_listbox_Form1()
        {
            InitializeComponent();
        }

        private void howto_drag_inside_listbox_Form1_Load(object sender, EventArgs e)
        {
            lstAnimals.AllowDrop = true;
        }

        // On right mouse down, start the drag.
        private void lst_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox lst = sender as ListBox;

            // Only use the right mouse button.
            if (e.Button != MouseButtons.Right) return;

            // Find the item under the mouse.
            int index = lst.IndexFromPoint(e.Location);
            lst.SelectedIndex = index;
            if (index < 0) return;

            // Drag the item.
            DragItem drag_item = new DragItem(lst, index, lst.Items[index]);
            lst.DoDragDrop(drag_item, DragDropEffects.Move);
        }

        // See if we should allow this kind of drag.
        private void lst_DragEnter(object sender, DragEventArgs e)
        {
            ListBox lst = sender as ListBox;

            // Allow a Move for DragItem objects that are
            // dragged to the control that started the drag.
            if (!e.Data.GetDataPresent(typeof(DragItem)))
            {
                // Not a DragItem. Don't allow it.
                e.Effect = DragDropEffects.None;
            }
            else if ((e.AllowedEffect & DragDropEffects.Move) == 0)
            {
                // Not a Move. Do not allow it.
                e.Effect = DragDropEffects.None;
            }
            else
            {
                // Get the DragItem.
                DragItem drag_item = (DragItem)e.Data.GetData(typeof(DragItem));

                // Verify that this is the control that started the drag.
                if (drag_item.Client != lst)
                {
                    // Not the congtrol that started the drag. Do not allow it.
                    e.Effect = DragDropEffects.None;
                }
                else
                {
                    // Allow it.
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        // Select the item under the mouse during a drag.
        private void lst_DragOver(object sender, DragEventArgs e)
        {
            // Do nothing if the drag is not allowed.
            if (e.Effect != DragDropEffects.Move) return;

            ListBox lst = sender as ListBox;

            // Select the item at this screen location.
            lst.SelectedIndex =
                lst.IndexFromScreenPoint(new Point(e.X, e.Y));
        }

        // Drop the item here.
        private void lst_DragDrop(object sender, DragEventArgs e)
        {
            ListBox lst = sender as ListBox;

            // Get the ListBox item data.
            DragItem drag_item = (DragItem)e.Data.GetData(typeof(DragItem));

            // Get the index of the item at this position.
            int new_index =
                lst.IndexFromScreenPoint(new Point(e.X, e.Y));

            // If the item was dropped after all
            // of the items, move it to the end.
            if (new_index == -1) new_index = lst.Items.Count - 1;

            // Remove the item from its original position.
            lst.Items.RemoveAt(drag_item.Index);

            // Insert the item in its new position.
            lst.Items.Insert(new_index, drag_item.Item);

            // Select the item.
            lst.SelectedIndex = new_index;
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
            this.lstAnimals = new System.Windows.Forms.ListBox();
            this.lstFoods = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstAnimals
            // 
            this.lstAnimals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAnimals.FormattingEnabled = true;
            this.lstAnimals.IntegralHeight = false;
            this.lstAnimals.Items.AddRange(new object[] {
            "Aardvark",
            "Binturong",
            "Cuttlefish",
            "Dugong",
            "Emu",
            "Frigatebird",
            "Gharial",
            "Hare",
            "Indri",
            "Jackal",
            "Kiwi",
            "Liger",
            "Mandrill",
            "Numbat",
            "Okapi",
            "Platypus",
            "Quetzal",
            "Rhinoceros",
            "Serval",
            "Toucan",
            "Uakari",
            "Vulture",
            "Warthog",
            "Xolmis",
            "Yak",
            "Zonkey"});
            this.lstAnimals.Location = new System.Drawing.Point(3, 23);
            this.lstAnimals.Name = "lstAnimals";
            this.lstAnimals.Size = new System.Drawing.Size(139, 211);
            this.lstAnimals.TabIndex = 0;
            this.lstAnimals.DragOver += new System.Windows.Forms.DragEventHandler(this.lst_DragOver);
            this.lstAnimals.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.lstAnimals.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDown);
            this.lstAnimals.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_DragEnter);
            // 
            // lstFoods
            // 
            this.lstFoods.AllowDrop = true;
            this.lstFoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFoods.FormattingEnabled = true;
            this.lstFoods.IntegralHeight = false;
            this.lstFoods.Items.AddRange(new object[] {
            "Apple",
            "Banana",
            "Carrot",
            "Daikon Radish",
            "Eggplant",
            "Fig",
            "Grape",
            "Honeydew",
            "Ice  Cream",
            "Jicama,",
            "Kiwi",
            "Lemon",
            "Mushroom",
            "Nectarine",
            "Orange",
            "Pea",
            "Quince",
            "Raspberry",
            "Spinach",
            "Tangerine",
            "Ugli Fruit",
            "Vermicelli",
            "Walnuts",
            "Xigua",
            "Yam",
            "Zucchini"});
            this.lstFoods.Location = new System.Drawing.Point(148, 23);
            this.lstFoods.Name = "lstFoods";
            this.lstFoods.Size = new System.Drawing.Size(139, 211);
            this.lstFoods.TabIndex = 1;
            this.lstFoods.DragOver += new System.Windows.Forms.DragEventHandler(this.lst_DragOver);
            this.lstFoods.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.lstFoods.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDown);
            this.lstFoods.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_DragEnter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstAnimals, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstFoods, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 237);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGreen;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Animals";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGreen;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(148, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Foods";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_drag_inside_listbox_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_drag_inside_listbox_Form1";
            this.Text = "howto_drag_inside_listbox";
            this.Load += new System.EventHandler(this.howto_drag_inside_listbox_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstAnimals;
        private System.Windows.Forms.ListBox lstFoods;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

