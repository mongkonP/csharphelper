#region Copyright
/*
 * Copyright (c) 2011 Gregory L. Ables
 */
#endregion

using System;
using System.Windows.Forms;

 

using LangtonsAnt;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class langtonsant_frmNew:Form
  { 


        public int GridSize;
        public GridStyle GridStyle;

        public langtonsant_frmNew()
        {
            InitializeComponent();
            this.cboBoxGridType.DataSource = Enum.GetValues(typeof(GridStyle));
            this.numUpDnGridSize.Value = 4;
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.GridStyle = (GridStyle)cboBoxGridType.SelectedItem;
            this.GridSize = (int)numUpDnGridSize.Value;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void numUpDnGridSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.numUpDnGridSize.Value < 4)
            {
                this.numUpDnGridSize.Value = 4;
            }
            if (this.numUpDnGridSize.Value > 10)
            {
                this.numUpDnGridSize.Value = 10;
            }
        }
    

#region Copyright
/*
 * Copyright (c) 2011 Gregory L. Ables
 */
#endregion

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
        private void InitializeComponent()
        {
            this.cboBoxGridType = new System.Windows.Forms.ComboBox();
            this.numUpDnGridSize = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnGridSize)).BeginInit();
            this.SuspendLayout();
            //
            // cboBoxGridType
            //
            this.cboBoxGridType.FormattingEnabled = true;
            this.cboBoxGridType.Location = new System.Drawing.Point(24, 23);
            this.cboBoxGridType.Name = "cboBoxGridType";
            this.cboBoxGridType.Size = new System.Drawing.Size(121, 21);
            this.cboBoxGridType.TabIndex = 0;
            //
            // numUpDnGridSize
            //
            this.numUpDnGridSize.Location = new System.Drawing.Point(164, 24);
            this.numUpDnGridSize.Name = "numUpDnGridSize";
            this.numUpDnGridSize.Size = new System.Drawing.Size(40, 20);
            this.numUpDnGridSize.TabIndex = 1;
            this.numUpDnGridSize.ValueChanged += new System.EventHandler(this.numUpDnGridSize_ValueChanged);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(149, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnOkay
            //
            this.btnOkay.Location = new System.Drawing.Point(90, 62);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(55, 23);
            this.btnOkay.TabIndex = 3;
            this.btnOkay.Text = "Okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            //
            // langtonsant_frmNew
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 109);
            this.ControlBox = false;
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numUpDnGridSize);
            this.Controls.Add(this.cboBoxGridType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "langtonsant_frmNew";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Simulation";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnGridSize)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.ComboBox cboBoxGridType;
        private System.Windows.Forms.NumericUpDown numUpDnGridSize;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOkay;
    }
}