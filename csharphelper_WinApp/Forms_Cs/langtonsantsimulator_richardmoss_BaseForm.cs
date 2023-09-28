using System;
using System.Drawing;
using System.Windows.Forms;

 

using LangtonsAntSimulator_RichardMoss;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class langtonsantsimulator_richardmoss_BaseForm:Form
  { 


  #region  Public Constructors  

    public langtonsantsimulator_richardmoss_BaseForm()
    {
      InitializeComponent();
    }

  #endregion  Public Constructors  

  #region  Protected Overridden Methods  

    protected override void OnLoad(EventArgs e)
    {
      if (!this.DesignMode)
        this.Font = SystemFonts.DialogFont;

      base.OnLoad(e);
    }

  #endregion  Protected Overridden Methods  
  

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
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Text = "langtonsantsimulator_richardmoss_BaseForm";
    }

    #endregion
  }
}