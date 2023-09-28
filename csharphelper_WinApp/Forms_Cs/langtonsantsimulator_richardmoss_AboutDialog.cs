using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

 

using LangtonsAntSimulator_RichardMoss;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class langtonsantsimulator_richardmoss_AboutDialog:langtonsantsimulator_richardmoss_BaseForm
  { 


  #region  Public Constructors  

    public langtonsantsimulator_richardmoss_AboutDialog()
    {
      InitializeComponent();
    }

  #endregion  Public Constructors  

  #region  Protected Overridden Methods  

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      Assembly assembly;
      FileVersionInfo versionInfo;

      assembly = typeof(Program).Assembly;
      versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

      productNameLabel.Text = versionInfo.ProductName;
      productVersionLabel.Text = string.Format("Version {0}", versionInfo.FileVersion);
      copyrightLabel.Text = versionInfo.LegalCopyright;
      this.Text = string.Format(this.Text, versionInfo.ProductName);

      productNameLabel.Font = new Font(this.Font, FontStyle.Bold);
      productVersionLabel.Font = new Font(this.Font, FontStyle.Bold);
    }

  #endregion  Protected Overridden Methods  

  #region  Event Handlers  

    private void antLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.RunUrl("http://www.iconarchive.com/show/animal-icons-by-martin-berube/ant-icon.html");
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void cyotekLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.RunUrl("http://cyotek.com");
    }

    private void iconsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.RunUrl("http://p.yusukekamiyamane.com/");
    }

  #endregion  Event Handlers  

  #region  Private Methods  

    private void RunUrl(string url)
    {
      try
      {
        Process.Start(url);
      }
      catch (Exception)
      {
        MessageBox.Show(string.Format("Fail to start '{0}'", url), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

  #endregion  Private Methods  
  

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
      this.closeButton = new System.Windows.Forms.Button();
      this.antLinkLabel = new System.Windows.Forms.LinkLabel();
      this.cyotekLinkLabel = new System.Windows.Forms.LinkLabel();
      this.copyrightLabel = new System.Windows.Forms.Label();
      this.productNameLabel = new System.Windows.Forms.Label();
      this.productVersionLabel = new System.Windows.Forms.Label();
      this.iconsLinkLabel = new System.Windows.Forms.LinkLabel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // closeButton
      // 
      this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.closeButton.Location = new System.Drawing.Point(484, 149);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(75, 23);
      this.closeButton.TabIndex = 6;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
      // 
      // antLinkLabel
      // 
      this.antLinkLabel.AutoSize = true;
      this.antLinkLabel.LinkArea = new System.Windows.Forms.LinkArea(21, 13);
      this.antLinkLabel.Location = new System.Drawing.Point(146, 123);
      this.antLinkLabel.Name = "antLinkLabel";
      this.antLinkLabel.Size = new System.Drawing.Size(279, 17);
      this.antLinkLabel.TabIndex = 4;
      this.antLinkLabel.TabStop = true;
      this.antLinkLabel.Text = "Ant icon copyright © Martin Berube. All rights reserved.";
      this.antLinkLabel.UseCompatibleTextRendering = true;
      this.antLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.antLinkLabel_LinkClicked);
      // 
      // cyotekLinkLabel
      // 
      this.cyotekLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cyotekLinkLabel.AutoSize = true;
      this.cyotekLinkLabel.Location = new System.Drawing.Point(9, 154);
      this.cyotekLinkLabel.Name = "cyotekLinkLabel";
      this.cyotekLinkLabel.Size = new System.Drawing.Size(62, 13);
      this.cyotekLinkLabel.TabIndex = 5;
      this.cyotekLinkLabel.TabStop = true;
      this.cyotekLinkLabel.Text = "cyotek.com";
      this.cyotekLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cyotekLinkLabel_LinkClicked);
      // 
      // copyrightLabel
      // 
      this.copyrightLabel.AutoSize = true;
      this.copyrightLabel.Location = new System.Drawing.Point(146, 47);
      this.copyrightLabel.Name = "copyrightLabel";
      this.copyrightLabel.Size = new System.Drawing.Size(35, 13);
      this.copyrightLabel.TabIndex = 2;
      this.copyrightLabel.Text = "label3";
      // 
      // productNameLabel
      // 
      this.productNameLabel.AutoSize = true;
      this.productNameLabel.Location = new System.Drawing.Point(146, 12);
      this.productNameLabel.Name = "productNameLabel";
      this.productNameLabel.Size = new System.Drawing.Size(35, 13);
      this.productNameLabel.TabIndex = 0;
      this.productNameLabel.Text = "label2";
      // 
      // productVersionLabel
      // 
      this.productVersionLabel.AutoSize = true;
      this.productVersionLabel.Location = new System.Drawing.Point(146, 25);
      this.productVersionLabel.Name = "productVersionLabel";
      this.productVersionLabel.Size = new System.Drawing.Size(35, 13);
      this.productVersionLabel.TabIndex = 1;
      this.productVersionLabel.Text = "label1";
      // 
      // iconsLinkLabel
      // 
      this.iconsLinkLabel.AutoSize = true;
      this.iconsLinkLabel.LinkArea = new System.Windows.Forms.LinkArea(27, 17);
      this.iconsLinkLabel.Location = new System.Drawing.Point(146, 106);
      this.iconsLinkLabel.Name = "iconsLinkLabel";
      this.iconsLinkLabel.Size = new System.Drawing.Size(353, 17);
      this.iconsLinkLabel.TabIndex = 3;
      this.iconsLinkLabel.TabStop = true;
      this.iconsLinkLabel.Text = "Some icons are copyright © Yusuke Kamiyamane. All rights reserved.";
      this.iconsLinkLabel.UseCompatibleTextRendering = true;
      this.iconsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iconsLinkLabel_LinkClicked);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = Properties.Resources.ant_icon;
      this.pictureBox1.Location = new System.Drawing.Point(12, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(128, 128);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 7;
      this.pictureBox1.TabStop = false;
      // 
      // langtonsantsimulator_richardmoss_AboutDialog
      // 
      this.AcceptButton = this.closeButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.closeButton;
      this.ClientSize = new System.Drawing.Size(571, 184);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.antLinkLabel);
      this.Controls.Add(this.cyotekLinkLabel);
      this.Controls.Add(this.copyrightLabel);
      this.Controls.Add(this.productNameLabel);
      this.Controls.Add(this.productVersionLabel);
      this.Controls.Add(this.iconsLinkLabel);
      this.Controls.Add(this.closeButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "langtonsantsimulator_richardmoss_AboutDialog";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About {0}";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.LinkLabel iconsLinkLabel;
    private System.Windows.Forms.Label productVersionLabel;
    private System.Windows.Forms.Label productNameLabel;
    private System.Windows.Forms.Label copyrightLabel;
    private System.Windows.Forms.LinkLabel cyotekLinkLabel;
    private System.Windows.Forms.LinkLabel antLinkLabel;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}