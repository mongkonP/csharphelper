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
     public partial class howto_drag_drop_with_feedback_Form1:Form
  { 


        public howto_drag_drop_with_feedback_Form1()
        {
            InitializeComponent();
        }

        // Start a copy or move drag of text.
        private void lblDragSource_MouseDown(object sender, MouseEventArgs e)
        {
            // Start the drag if it's the right mouse button.
            if (e.Button == MouseButtons.Right)
            {
                if (lblDragSource.DoDragDrop("Here's some text!",
                    DragDropEffects.Copy | DragDropEffects.Move)
                        == DragDropEffects.Move)
                {
                    // The recipient moved the text.
                    // Remove it from here.
                    lblDragSource.Text = "";
                }
            }
        }

        // Indicate that we can accept a move or copy of text.
        private void lblDropTarget_DragEnter(object sender, DragEventArgs e)
        {
            // See if this is a copy and the data includes text.
            if (e.Data.GetDataPresent(DataFormats.Text) &&
                ((e.AllowedEffect & DragDropEffects.Copy) != 0 ||
                 (e.AllowedEffect & DragDropEffects.Move) != 0))
            {
                // Allow this.
                e.Effect = DragDropEffects.Copy | DragDropEffects.Move;

                // Display a highlighted background.
                lblDropTarget.BackColor = Color.LightYellow;
            }
            else
            {
                // Don't allow any other drop.
                e.Effect = DragDropEffects.None;
            }
        }

        // Check the key state. Allow copy if Shift is pressed.
        private void lblDropTarget_DragOver(object sender, DragEventArgs e)
        {
            const int KEY_SHIFT = 4;
            
            if ((e.KeyState & KEY_SHIFT) != 0)
            {
                // Shift is pressed. Allow move.
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                // Shift is not pressed. Allow copy.
                e.Effect = DragDropEffects.Copy;
            }
        }

        // Remove the background color highlight.
        private void lblDropTarget_DragLeave(object sender, EventArgs e)
        {
            lblDropTarget.BackColor = SystemColors.Control;
        }

        // Accept the drop.
        private void lblDropTarget_DragDrop(object sender, DragEventArgs e)
        {
            // Accept the data.
            lblDropTarget.Text = (string)e.Data.GetData(DataFormats.Text);
            lblDropTarget.BackColor = SystemColors.Control;
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
            this.lblDropTarget = new System.Windows.Forms.Label();
            this.lblDragSource = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDropTarget
            // 
            this.lblDropTarget.AllowDrop = true;
            this.lblDropTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDropTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDropTarget.Location = new System.Drawing.Point(192, 10);
            this.lblDropTarget.Name = "lblDropTarget";
            this.lblDropTarget.Size = new System.Drawing.Size(154, 108);
            this.lblDropTarget.TabIndex = 5;
            this.lblDropTarget.Text = "Drop Target";
            this.lblDropTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDropTarget.DragOver += new System.Windows.Forms.DragEventHandler(this.lblDropTarget_DragOver);
            this.lblDropTarget.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblDropTarget_DragDrop);
            this.lblDropTarget.DragLeave += new System.EventHandler(this.lblDropTarget_DragLeave);
            this.lblDropTarget.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblDropTarget_DragEnter);
            // 
            // lblDragSource
            // 
            this.lblDragSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDragSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDragSource.Location = new System.Drawing.Point(13, 10);
            this.lblDragSource.Name = "lblDragSource";
            this.lblDragSource.Size = new System.Drawing.Size(153, 108);
            this.lblDragSource.TabIndex = 4;
            this.lblDragSource.Text = "Drag Source";
            this.lblDragSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDragSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDragSource_MouseDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblDropTarget, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDragSource, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(359, 128);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // howto_drag_drop_with_feedback_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 128);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_drag_drop_with_feedback_Form1";
            this.Text = "howto_drag_drop_with_feedback";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDropTarget;
        private System.Windows.Forms.Label lblDragSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

