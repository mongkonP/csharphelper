using System.Linq;
using System.Windows.Forms;

 

using LangtonsAntSimulator_RichardMoss;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class langtonsantsimulator_richardmoss_ActorViewer:UserControl
  { 


  #region  Private Member Declarations  

    private IActor _actor;
    private ISimulation _simulation;

  #endregion  Private Member Declarations  

  #region  Public Constructors  

    public langtonsantsimulator_richardmoss_ActorViewer()
    {
      InitializeComponent();
    }

  #endregion  Public Constructors  

  #region  Public Methods  

    public void UpdateUi()
    {
      string location;
      string facing;
      string nextMove;

              location = string.Empty;
        facing = string.Empty;
        nextMove = string.Empty;

      if (this.Simulation != null && this.Actor != null)
      {
        LangtonsAntSimulation simulation;
        IBlock currentBlock;
        Direction nextFacing;

        location = string.Format("X:{0}, Y:{1}", this.Actor.Location.X, this.Actor.Location.Y);
        currentBlock = this.Simulation.Blocks.FirstOrDefault(b => b.Location == this.Actor.Location);

        if (currentBlock != null)
        {
          facing = string.Format("{0} ({1})", this.Actor.Facing.ToString(), currentBlock.IsTagged ? "Black" : "White");

          simulation = (LangtonsAntSimulation)this.Simulation;
          nextFacing = simulation.GetNextFacing(currentBlock, this.Actor.Facing);
          nextMove = nextFacing.ToString();
        }
      }

      locationTextBox.Text = location;
      facingTextBox.Text = facing;
      nextMoveTextBox.Text = nextMove;
    }

  #endregion  Public Methods  

  #region  Public Properties  

    public IActor Actor
    {
      get { return _actor; }
      set
      {
        _actor = value;
        this.UpdateUi();
      }
    }

    public ISimulation Simulation
    {
      get { return _simulation; }
      set
      {
        _simulation = value;
        this.UpdateUi();
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.locationTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.facingTextBox = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.nextMoveTextBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 6);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(51, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Location:";
      // 
      // locationTextBox
      // 
      this.locationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.locationTextBox.Location = new System.Drawing.Point(70, 3);
      this.locationTextBox.Name = "locationTextBox";
      this.locationTextBox.ReadOnly = true;
      this.locationTextBox.Size = new System.Drawing.Size(173, 20);
      this.locationTextBox.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(42, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Facing:";
      // 
      // facingTextBox
      // 
      this.facingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.facingTextBox.Location = new System.Drawing.Point(70, 29);
      this.facingTextBox.Name = "facingTextBox";
      this.facingTextBox.ReadOnly = true;
      this.facingTextBox.Size = new System.Drawing.Size(173, 20);
      this.facingTextBox.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(2, 58);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(62, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Next Move:";
      // 
      // nextMoveTextBox
      // 
      this.nextMoveTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.nextMoveTextBox.Location = new System.Drawing.Point(70, 55);
      this.nextMoveTextBox.Name = "nextMoveTextBox";
      this.nextMoveTextBox.ReadOnly = true;
      this.nextMoveTextBox.Size = new System.Drawing.Size(173, 20);
      this.nextMoveTextBox.TabIndex = 5;
      // 
      // langtonsantsimulator_richardmoss_ActorViewer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.nextMoveTextBox);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.facingTextBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.locationTextBox);
      this.Controls.Add(this.label1);
      this.Name = "langtonsantsimulator_richardmoss_ActorViewer";
      this.Size = new System.Drawing.Size(246, 224);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox locationTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox facingTextBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox nextMoveTextBox;
  }
}
