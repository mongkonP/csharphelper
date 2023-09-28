using System;
using System.Windows.Forms;

 

using LangtonsAntSimulator_RichardMoss;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class langtonsantsimulator_richardmoss_PauseOnMoveDialog:langtonsantsimulator_richardmoss_BaseForm
  { 


    #region  Public Constructors

    public langtonsantsimulator_richardmoss_PauseOnMoveDialog()
    {
      InitializeComponent();
    }

    #endregion  Public Constructors

    #region  Event Handlers

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      if (moveNumericUpDown.Value < 1 || moveNumericUpDown.Value > moveNumericUpDown.Maximum)
      {
        MessageBox.Show("Please enter a valid number.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        moveNumericUpDown.Focus();
        this.DialogResult = DialogResult.None;
      }
      else
      {
        this.DialogResult = DialogResult.OK;
      }
    }

    private void langtonsantsimulator_richardmoss_PauseOnMoveDialog_Load(object sender, EventArgs e)
    {
      moveNumericUpDown.Maximum = int.MaxValue;
    }

    #endregion  Event Handlers

    #region  Public Properties

    public int MoveNumber
    {
      get { return (int)moveNumericUpDown.Value; }
      set
      {
        if (value >= moveNumericUpDown.Minimum && value <= moveNumericUpDown.Maximum)
          moveNumericUpDown.Value = value;
      }
    }

    #endregion  Public Properties
  

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
      this.label1 = new System.Windows.Forms.Label();
      this.moveNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.moveNumericUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(336, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Enter the move number you wish the simulation to automatically pause";
      // 
      // moveNumericUpDown
      // 
      this.moveNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.moveNumericUpDown.Location = new System.Drawing.Point(12, 50);
      this.moveNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
      this.moveNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.moveNumericUpDown.Name = "moveNumericUpDown";
      this.moveNumericUpDown.Size = new System.Drawing.Size(120, 20);
      this.moveNumericUpDown.TabIndex = 2;
      this.moveNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(232, 105);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 6;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(313, 105);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 7;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 34);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(75, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "&Move number:";
      // 
      // langtonsantsimulator_richardmoss_PauseOnMoveDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(400, 140);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.moveNumericUpDown);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "langtonsantsimulator_richardmoss_PauseOnMoveDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Pause On Move";
      this.Load += new System.EventHandler(this.langtonsantsimulator_richardmoss_PauseOnMoveDialog_Load);
      ((System.ComponentModel.ISupportInitialize)(this.moveNumericUpDown)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown moveNumericUpDown;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Label label2;
  }
}