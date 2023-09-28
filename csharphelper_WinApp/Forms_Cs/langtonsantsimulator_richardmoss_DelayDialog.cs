using System;
using System.Windows.Forms;

 

using LangtonsAntSimulator_RichardMoss;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class langtonsantsimulator_richardmoss_DelayDialog:langtonsantsimulator_richardmoss_BaseForm
  { 


  #region  Private Member Declarations  

    private ISimulation _simulation;

  #endregion  Private Member Declarations  

  #region  Public Constructors  

    public langtonsantsimulator_richardmoss_DelayDialog()
    {
      InitializeComponent();
    }

    public langtonsantsimulator_richardmoss_DelayDialog(ISimulation simulation)
      : this()
    {
      _simulation = simulation;
    }

  #endregion  Public Constructors  

  #region  Protected Overridden Methods  

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (_simulation != null)
        delayNumericUpDown.Value = _simulation.Speed;
    }

  #endregion  Protected Overridden Methods  

  #region  Event Handlers  

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      if (delayNumericUpDown.Value < 1 || delayNumericUpDown.Value > delayNumericUpDown.Maximum)
      {
        MessageBox.Show("Please enter a valid delay.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        delayNumericUpDown.Focus();
        this.DialogResult = DialogResult.None;
      }
      else
      {
        _simulation.Speed = (int)delayNumericUpDown.Value;
        this.DialogResult = DialogResult.OK;
      }
    }

  #endregion  Event Handlers  
  

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
      this.delayNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.delayNumericUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(335, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Enter the delay, in milliseconds, between each move in the simulation.";
      // 
      // delayNumericUpDown
      // 
      this.delayNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.delayNumericUpDown.Location = new System.Drawing.Point(12, 50);
      this.delayNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.delayNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.delayNumericUpDown.Name = "delayNumericUpDown";
      this.delayNumericUpDown.Size = new System.Drawing.Size(120, 20);
      this.delayNumericUpDown.TabIndex = 2;
      this.delayNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(232, 97);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 3;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(313, 97);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 4;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 34);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(37, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "&Delay:";
      // 
      // Setlangtonsantsimulator_richardmoss_DelayDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(400, 132);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.delayNumericUpDown);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Setlangtonsantsimulator_richardmoss_DelayDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Configure Delay";
      ((System.ComponentModel.ISupportInitialize)(this.delayNumericUpDown)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown delayNumericUpDown;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Label label2;
  }
}