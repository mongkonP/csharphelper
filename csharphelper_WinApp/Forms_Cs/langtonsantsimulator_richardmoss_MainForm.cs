using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using LangtonsAntSimulator_RichardMoss;
namespace csharphelper_WinApp.Forms_Cs
{

  // http://blog.csharphelper.com/2011/02/26/contest-langtons-ant-simulation.aspx

  public partial class langtonsantsimulator_richardmoss_MainForm : langtonsantsimulator_richardmoss_BaseForm, ISimulationHost
  {
    #region  Private Member Declarations

    private int _pauseOnMoveNumber;
    private ISimulation _simulation;
    private string _simulationFileName;
    private readonly string _textPattern = "{2} - {0} [{1}]";

    #endregion  Private Member Declarations

    #region  Public Constructors

    public langtonsantsimulator_richardmoss_MainForm()
    {
      InitializeComponent();
    }

    #endregion  Public Constructors

    #region  Protected Overridden Methods

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        this.ClearSimulation();

        if (components != null)
          components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void ClearSimulation()
    {
      if (_simulation != null)
        _simulation.Stop(); // Clean up
    }

    #endregion  Protected Overridden Methods

    #region  Event Handlers

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (langtonsantsimulator_richardmoss_AboutDialog dialog = new  langtonsantsimulator_richardmoss_AboutDialog())
        dialog.ShowDialog(this);
    }

    private void actorsComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (actorsComboBox.SelectedIndex >= 0 && actorsComboBox.SelectedIndex < actorsComboBox.Items.Count)
        actorViewer.Actor = _simulation.Actors[actorsComboBox.SelectedIndex];
      else
        actorViewer.Actor = null;
    }

    private void addAntToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (langtonsantsimulator_richardmoss_AddAntsDialog dialog = new  langtonsantsimulator_richardmoss_AddAntsDialog(_simulation))
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
          this.InitializeActorsPane();
      }
    }

    private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SetColors(new ColorParameters()
      {
        ActorColor = Color.Red,
        TaggedBlockColor = Color.Black,
        UntaggedBlockColor = Color.White
      });
    }

    private void coloursToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (langtonsantsimulator_richardmoss_ColorsDialog dialog = new  langtonsantsimulator_richardmoss_ColorsDialog(new ColorParameters()
      {
        ActorColor = simulationPanel.ActorColor,
        TaggedBlockColor = simulationPanel.TaggedColor,
        UntaggedBlockColor = simulationPanel.UntaggedColor
      }))
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
          this.SetColors(dialog.GetColorParameters());
      }
    }

    private void delayToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (langtonsantsimulator_richardmoss_DelayDialog dialog = new  langtonsantsimulator_richardmoss_DelayDialog(_simulation))
        dialog.ShowDialog(this);
    }

    private void drawOutputToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _simulation.ShowOutput = !_simulation.ShowOutput;
      this.UpdateOutputIndicators();
    }

    private void earthyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SetColors(new ColorParameters()
      {
        ActorColor = Color.Firebrick,
        TaggedBlockColor = Color.DarkKhaki,
        UntaggedBlockColor = Color.DarkOliveGreen
      });
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void exportImageToolStripMenuItem_Click(object sender, EventArgs e)
    {
      bool isPausedRequired;

      isPausedRequired = !_simulation.IsPaused;
      if (isPausedRequired)
        _simulation.Pause();

      if (saveImageFileDialog.ShowDialog(this) == DialogResult.OK)
      {
        try
        {
          this.SetStatus("Exporting image...");
          simulationPanel.SimulationOutput.Save(saveImageFileDialog.FileName, ImageFormat.Png);
          MessageBox.Show("Image export complete.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Failed to export image. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        finally
        {
          this.SetStatus(string.Empty);
        }
      }

      if (isPausedRequired)
        _simulation.Start();
    }

    private void langtonsantsimulator_richardmoss_MainForm_Load(object sender, EventArgs e)
    {
      this.Font = SystemFonts.DialogFont;
      this.InitializeSimulation(new SimulationStartParameters());
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (langtonsantsimulator_richardmoss_NewSimulationDialog dialog = new  langtonsantsimulator_richardmoss_NewSimulationDialog())
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
          this.InitializeSimulation(dialog.GetStartParameters());
      }
    }

    private void nextMoveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _simulation.NextMove();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.FileOpen(string.Empty);
    }

    private void pauseOnMoveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (langtonsantsimulator_richardmoss_PauseOnMoveDialog dialog = new  langtonsantsimulator_richardmoss_PauseOnMoveDialog() { MoveNumber = _pauseOnMoveNumber })
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
          _pauseOnMoveNumber = dialog.MoveNumber;
      }
    }

    private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (_simulation.IsPaused)
        _simulation.Start();
      else
        _simulation.Pause();
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.FileSave(string.Empty);
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.FileSave(_simulationFileName);
    }

    private void startToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _simulation.Start();
    }

    private void stopToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _simulation.Stop();
    }

    #endregion  Event Handlers

    #region  Private Methods

    private void FileOpen(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        openSimulationFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

        if (openSimulationFileDialog.ShowDialog(this) == DialogResult.OK)
          fileName = openSimulationFileDialog.FileName;
      }

      if (!string.IsNullOrEmpty(fileName))
      {
        this.ClearSimulation();
        _simulation = new LangtonsAntSimulation(this);

        try
        {
          this.SetStatus("Loading simulation...");
          _simulation.Load(fileName);
          _simulationFileName = fileName;

          this.InitializeSimulation(_simulation);
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Failed to open simulation. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        finally
        {
          this.SetStatus(string.Empty);
        }
      }
    }

    private void FileSave(string fileName)
    {
      bool isPausedRequired;

      isPausedRequired = !_simulation.IsPaused;
      if (isPausedRequired)
        _simulation.Pause();

      if (string.IsNullOrEmpty(fileName))
      {
        saveSimulationFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
        saveSimulationFileDialog.FileName = _simulationFileName;

        if (saveSimulationFileDialog.ShowDialog(this) == DialogResult.OK)
          fileName = saveSimulationFileDialog.FileName;
      }

      if (!string.IsNullOrEmpty(fileName))
      {
        try
        {
          this.SetStatus("Saving simulation...");
          _simulation.Save(fileName);
          _simulationFileName = fileName;
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Failed to save simulation. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        finally
        {
          this.SetStatus(string.Empty);
        }
      }

      if (isPausedRequired)
        _simulation.Start();
    }

    private void InitializeActorsPane()
    {
      actorsComboBox.Items.Clear();
      for (int i = 0; i < _simulation.Actors.Count(); i++)
        actorsComboBox.Items.Add(string.Format("Ant {0}", i + 1));

      if (actorsComboBox.Items.Count != 0)
        actorsComboBox.SelectedIndex = 0;
    }

    private void InitializeSimulation(SimulationStartParameters simulationStartParameters)
    {
      List<IActor> actors;

      _simulationFileName = string.Empty;

      // destroy the old simulation or it will keep running with unintended consque
      this.ClearSimulation();

      _simulation = new LangtonsAntSimulation(this);
      _simulation.Speed = simulationStartParameters.Delay;

      actors = new List<IActor>();
      for (int i = 0; i < simulationStartParameters.InitialActors; i++)
        actors.Add(new Ant());
      _simulation.Actors = actors.ToArray();

      this.InitializeSimulation(_simulation);

      _simulation.Start();
      if (simulationStartParameters.StartPaused)
        _simulation.Pause();
    }

    private void InitializeSimulation(ISimulation _simulation)
    {
      simulationPanel.Simulation = _simulation;
      actorViewer.Simulation = _simulation;
      this.InitializeActorsPane();
      this.UpdateStatusPanel();
      this.UpdateText(_simulation.IsPaused ? "Paused" : "Running");
    }

    private void SetColors(ColorParameters colorParameters)
    {
      simulationPanel.ActorColor = colorParameters.ActorColor;
      simulationPanel.TaggedColor = colorParameters.TaggedBlockColor;
      simulationPanel.UntaggedColor = colorParameters.UntaggedBlockColor;

      simulationPanel.RedrawSimulation(); // need a full redraw if changing colors
      simulationPanel.Invalidate();
    }

    private void SetStatus(string text)
    {
      statusToolStripStatusLabel.Text = text;
      Application.DoEvents(); // force the status to appear
    }

    private void UpdateOutputIndicators()
    {
      drawOutputToolStripMenuItem.Checked = _simulation.ShowOutput;
      simulationPanel.Invalidate(); // force a repaint
    }

    private void UpdateStatusPanel()
    {
      // show the simulation status
      sizeToolStripStatusLabel.Text = string.Format("Arena: W:{0}, H:{1}", _simulation.Region.Width, _simulation.Region.Height);
      moveToolStripStatusLabel.Text = string.Format("Move: {0}", _simulation.Move);
    }

    private void UpdateText(string action)
    {
      this.Text = string.Format(_textPattern, Application.ProductName, action, string.IsNullOrEmpty(_simulationFileName) ? "Untitled" : Path.GetFileName(_simulationFileName));
    }

    private void UpdateUi()
    {
      // menu items
      startToolStripMenuItem.Enabled = !_simulation.IsRunning;
      stopToolStripMenuItem.Enabled = _simulation.IsRunning;
      pauseToolStripMenuItem.Enabled = _simulation.IsRunning;
      pauseToolStripMenuItem.Checked = _simulation.IsPaused;
      nextMoveToolStripMenuItem.Enabled = _simulation.IsPaused;

      // toolbar buttons
      startSimulationToolStripButton.Enabled = !_simulation.IsRunning;
      stopSimulationToolStripButton.Enabled = _simulation.IsRunning;
      pauseSimulationToolStripButton.Enabled = _simulation.IsRunning;
      pauseSimulationToolStripButton.Checked = _simulation.IsPaused;
      nextMoveToolStripButton.Enabled = _simulation.IsPaused;
    }

    #endregion  Private Methods



    #region ISimulationHost Members

    void ISimulationHost.OnStart()
    {
      this.UpdateText("Running");
      this.UpdateUi();
    }

    void ISimulationHost.OnStop()
    {
      this.UpdateText("Stopped");
      this.UpdateUi();
    }

    void ISimulationHost.OnPause()
    {
      this.UpdateText("Paused");
      this.UpdateUi();
    }

    void ISimulationHost.OnResume()
    {
      ((ISimulationHost)this).OnStart();
    }

    void ISimulationHost.OnNextMove()
    {
      //System.Diagnostics.Debug.WriteLine("{0} Move {1}", DateTime.Now, _simulation.Move);

      this.UpdateStatusPanel();

      if (_simulation.ShowOutput || _simulation.IsPaused)
      {
        // redraw changed squares
        simulationPanel.UpdateActors();

        // show new information on the selected actor
        actorViewer.UpdateUi();
      }

      // auto pause
      if (_pauseOnMoveNumber > 0 && _simulation.Move == _pauseOnMoveNumber)
      {
        _simulation.Pause();
        _simulation.ShowOutput = true;
        this.UpdateOutputIndicators();
        simulationPanel.RecreateCanvas();

        MessageBox.Show(string.Format("Automatically paused due to reaching move {0}", _pauseOnMoveNumber), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    #endregion
  

/// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;


    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(langtonsantsimulator_richardmoss_MainForm));
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.nextMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
      this.delayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
      this.drawOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
      this.addAntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.blackAndWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.earthyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
      this.coloursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.exportImageToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.startSimulationToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.stopSimulationToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.pauseSimulationToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.nextMoveToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.addAntToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.moveToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.sizeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.saveImageFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.viewSplitContainer = new System.Windows.Forms.SplitContainer();
      this.simulationPanel = new  langtonsantsimulator_richardmoss_SimulationPanel(this.components);
      this.actorViewer = new  langtonsantsimulator_richardmoss_ActorViewer();
      this.actorsComboBox = new System.Windows.Forms.ComboBox();
      this.saveSimulationFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.openSimulationFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
      this.pauseOnMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip.SuspendLayout();
      this.toolStrip.SuspendLayout();
      this.statusStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.viewSplitContainer)).BeginInit();
      this.viewSplitContainer.Panel1.SuspendLayout();
      this.viewSplitContainer.Panel2.SuspendLayout();
      this.viewSplitContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.simulationToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(804, 24);
      this.menuStrip.TabIndex = 0;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exportImageToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
      this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
      this.newToolStripMenuItem.Text = "&New...";
      this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
      this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
      this.openToolStripMenuItem.Text = "&Open...";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
      this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
      this.saveToolStripMenuItem.Text = "&Save";
      this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
      this.saveAsToolStripMenuItem.Text = "Save &As...";
      this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(189, 6);
      // 
      // exportImageToolStripMenuItem
      // 
      this.exportImageToolStripMenuItem.Image = Properties.Resources.image_export;
      this.exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
      this.exportImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
      this.exportImageToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
      this.exportImageToolStripMenuItem.Text = "&Export Image...";
      this.exportImageToolStripMenuItem.Click += new System.EventHandler(this.exportImageToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(189, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // simulationToolStripMenuItem
      // 
      this.simulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.toolStripMenuItem3,
            this.nextMoveToolStripMenuItem,
            this.toolStripMenuItem4,
            this.delayToolStripMenuItem,
            this.toolStripMenuItem5,
            this.drawOutputToolStripMenuItem,
            this.toolStripMenuItem6,
            this.addAntToolStripMenuItem});
      this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
      this.simulationToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
      this.simulationToolStripMenuItem.Text = "&Simulation";
      // 
      // startToolStripMenuItem
      // 
      this.startToolStripMenuItem.Image = Properties.Resources.control;
      this.startToolStripMenuItem.Name = "startToolStripMenuItem";
      this.startToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.startToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
      this.startToolStripMenuItem.Text = "&Start";
      this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
      // 
      // stopToolStripMenuItem
      // 
      this.stopToolStripMenuItem.Image = Properties.Resources.stop;
      this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
      this.stopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F6)));
      this.stopToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
      this.stopToolStripMenuItem.Text = "S&top";
      this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
      // 
      // pauseToolStripMenuItem
      // 
      this.pauseToolStripMenuItem.Image = Properties.Resources.pause;
      this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
      this.pauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.pauseToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
      this.pauseToolStripMenuItem.Text = "&Pause";
      this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 6);
      // 
      // nextMoveToolStripMenuItem
      // 
      this.nextMoveToolStripMenuItem.Image = Properties.Resources.control_skip;
      this.nextMoveToolStripMenuItem.Name = "nextMoveToolStripMenuItem";
      this.nextMoveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
      this.nextMoveToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
      this.nextMoveToolStripMenuItem.Text = "&Next Move";
      this.nextMoveToolStripMenuItem.Click += new System.EventHandler(this.nextMoveToolStripMenuItem_Click);
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 6);
      // 
      // delayToolStripMenuItem
      // 
      this.delayToolStripMenuItem.Name = "delayToolStripMenuItem";
      this.delayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
      this.delayToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
      this.delayToolStripMenuItem.Text = "&Delay...";
      this.delayToolStripMenuItem.Click += new System.EventHandler(this.delayToolStripMenuItem_Click);
      // 
      // toolStripMenuItem5
      // 
      this.toolStripMenuItem5.Name = "toolStripMenuItem5";
      this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 6);
      // 
      // drawOutputToolStripMenuItem
      // 
      this.drawOutputToolStripMenuItem.Checked = true;
      this.drawOutputToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.drawOutputToolStripMenuItem.Name = "drawOutputToolStripMenuItem";
      this.drawOutputToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
      this.drawOutputToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
      this.drawOutputToolStripMenuItem.Text = "D&raw Output";
      this.drawOutputToolStripMenuItem.Click += new System.EventHandler(this.drawOutputToolStripMenuItem_Click);
      // 
      // toolStripMenuItem6
      // 
      this.toolStripMenuItem6.Name = "toolStripMenuItem6";
      this.toolStripMenuItem6.Size = new System.Drawing.Size(180, 6);
      // 
      // addAntToolStripMenuItem
      // 
      this.addAntToolStripMenuItem.Image = Properties.Resources.bug__plus;
      this.addAntToolStripMenuItem.Name = "addAntToolStripMenuItem";
      this.addAntToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
      this.addAntToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
      this.addAntToolStripMenuItem.Text = "&Add Ants...";
      this.addAntToolStripMenuItem.Click += new System.EventHandler(this.addAntToolStripMenuItem_Click);
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackAndWhiteToolStripMenuItem,
            this.earthyToolStripMenuItem,
            this.toolStripMenuItem7,
            this.coloursToolStripMenuItem,
            this.toolStripMenuItem8,
            this.pauseOnMoveToolStripMenuItem});
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
      this.optionsToolStripMenuItem.Text = "&Options";
      // 
      // blackAndWhiteToolStripMenuItem
      // 
      this.blackAndWhiteToolStripMenuItem.Name = "blackAndWhiteToolStripMenuItem";
      this.blackAndWhiteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
      this.blackAndWhiteToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
      this.blackAndWhiteToolStripMenuItem.Text = "&Black and White";
      this.blackAndWhiteToolStripMenuItem.Click += new System.EventHandler(this.blackAndWhiteToolStripMenuItem_Click);
      // 
      // earthyToolStripMenuItem
      // 
      this.earthyToolStripMenuItem.Name = "earthyToolStripMenuItem";
      this.earthyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
      this.earthyToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
      this.earthyToolStripMenuItem.Text = "&Earthy";
      this.earthyToolStripMenuItem.Click += new System.EventHandler(this.earthyToolStripMenuItem_Click);
      // 
      // toolStripMenuItem7
      // 
      this.toolStripMenuItem7.Name = "toolStripMenuItem7";
      this.toolStripMenuItem7.Size = new System.Drawing.Size(196, 6);
      // 
      // coloursToolStripMenuItem
      // 
      this.coloursToolStripMenuItem.Name = "coloursToolStripMenuItem";
      this.coloursToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
      this.coloursToolStripMenuItem.Text = "More &Colors...";
      this.coloursToolStripMenuItem.Click += new System.EventHandler(this.coloursToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.aboutToolStripMenuItem.Text = "&About...";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // toolStrip
      // 
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator4,
            this.exportImageToolStripButton,
            this.toolStripSeparator2,
            this.startSimulationToolStripButton,
            this.stopSimulationToolStripButton,
            this.pauseSimulationToolStripButton,
            this.toolStripSeparator1,
            this.nextMoveToolStripButton,
            this.toolStripSeparator3,
            this.addAntToolStripButton});
      this.toolStrip.Location = new System.Drawing.Point(0, 24);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(804, 25);
      this.toolStrip.TabIndex = 1;
      // 
      // newToolStripButton
      // 
      this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
      this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.newToolStripButton.Name = "newToolStripButton";
      this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.newToolStripButton.Text = "&New";
      this.newToolStripButton.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
      // 
      // openToolStripButton
      // 
      this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
      this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripButton.Name = "openToolStripButton";
      this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.openToolStripButton.Text = "&Open";
      this.openToolStripButton.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
      // 
      // saveToolStripButton
      // 
      this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
      this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveToolStripButton.Name = "saveToolStripButton";
      this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.saveToolStripButton.Text = "&Save";
      this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
      // 
      // exportImageToolStripButton
      // 
      this.exportImageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.exportImageToolStripButton.Image = Properties.Resources.image_export;
      this.exportImageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.exportImageToolStripButton.Name = "exportImageToolStripButton";
      this.exportImageToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.exportImageToolStripButton.Text = "Export Image";
      this.exportImageToolStripButton.Click += new System.EventHandler(this.exportImageToolStripMenuItem_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // startSimulationToolStripButton
      // 
      this.startSimulationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.startSimulationToolStripButton.Image = Properties.Resources.control;
      this.startSimulationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.startSimulationToolStripButton.Name = "startSimulationToolStripButton";
      this.startSimulationToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.startSimulationToolStripButton.Text = "Start Simulation";
      this.startSimulationToolStripButton.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
      // 
      // stopSimulationToolStripButton
      // 
      this.stopSimulationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.stopSimulationToolStripButton.Image = Properties.Resources.stop;
      this.stopSimulationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.stopSimulationToolStripButton.Name = "stopSimulationToolStripButton";
      this.stopSimulationToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.stopSimulationToolStripButton.Text = "Stop Simulation";
      this.stopSimulationToolStripButton.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
      // 
      // pauseSimulationToolStripButton
      // 
      this.pauseSimulationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.pauseSimulationToolStripButton.Image = Properties.Resources.pause;
      this.pauseSimulationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.pauseSimulationToolStripButton.Name = "pauseSimulationToolStripButton";
      this.pauseSimulationToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.pauseSimulationToolStripButton.Text = "Pause Simulation";
      this.pauseSimulationToolStripButton.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // nextMoveToolStripButton
      // 
      this.nextMoveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.nextMoveToolStripButton.Image = Properties.Resources.control_skip;
      this.nextMoveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.nextMoveToolStripButton.Name = "nextMoveToolStripButton";
      this.nextMoveToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.nextMoveToolStripButton.Text = "Next Move";
      this.nextMoveToolStripButton.Click += new System.EventHandler(this.nextMoveToolStripMenuItem_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // addAntToolStripButton
      // 
      this.addAntToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.addAntToolStripButton.Image = Properties.Resources.bug__plus;
      this.addAntToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.addAntToolStripButton.Name = "addAntToolStripButton";
      this.addAntToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.addAntToolStripButton.Text = "Add Ants";
      this.addAntToolStripButton.Click += new System.EventHandler(this.addAntToolStripMenuItem_Click);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.moveToolStripStatusLabel,
            this.sizeToolStripStatusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 478);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(804, 24);
      this.statusStrip.TabIndex = 3;
      // 
      // statusToolStripStatusLabel
      // 
      this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
      this.statusToolStripStatusLabel.Size = new System.Drawing.Size(700, 19);
      this.statusToolStripStatusLabel.Spring = true;
      this.statusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // moveToolStripStatusLabel
      // 
      this.moveToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                  | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                  | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
      this.moveToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
      this.moveToolStripStatusLabel.Name = "moveToolStripStatusLabel";
      this.moveToolStripStatusLabel.Size = new System.Drawing.Size(44, 19);
      this.moveToolStripStatusLabel.Text = "Move:";
      // 
      // sizeToolStripStatusLabel
      // 
      this.sizeToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                  | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                  | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
      this.sizeToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
      this.sizeToolStripStatusLabel.Name = "sizeToolStripStatusLabel";
      this.sizeToolStripStatusLabel.Size = new System.Drawing.Size(45, 19);
      this.sizeToolStripStatusLabel.Text = "Arena:";
      // 
      // saveImageFileDialog
      // 
      this.saveImageFileDialog.DefaultExt = "png";
      this.saveImageFileDialog.Filter = "Portable Network Graphics (*.png)|*.png|All Files (*.*)|*.*";
      // 
      // viewSplitContainer
      // 
      this.viewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.viewSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.viewSplitContainer.Location = new System.Drawing.Point(0, 49);
      this.viewSplitContainer.Name = "viewSplitContainer";
      // 
      // viewSplitContainer.Panel1
      // 
      this.viewSplitContainer.Panel1.Controls.Add(this.simulationPanel);
      // 
      // viewSplitContainer.Panel2
      // 
      this.viewSplitContainer.Panel2.Controls.Add(this.actorViewer);
      this.viewSplitContainer.Panel2.Controls.Add(this.actorsComboBox);
      this.viewSplitContainer.Size = new System.Drawing.Size(804, 429);
      this.viewSplitContainer.SplitterDistance = 604;
      this.viewSplitContainer.TabIndex = 2;
      // 
      // simulationPanel
      // 
      this.simulationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.simulationPanel.Location = new System.Drawing.Point(0, 0);
      this.simulationPanel.Name = "simulationPanel";
      this.simulationPanel.Size = new System.Drawing.Size(604, 429);
      this.simulationPanel.TabIndex = 0;
      // 
      // actorViewer
      // 
      this.actorViewer.Actor = null;
      this.actorViewer.Location = new System.Drawing.Point(3, 30);
      this.actorViewer.Name = "actorViewer";
      this.actorViewer.Simulation = null;
      this.actorViewer.Size = new System.Drawing.Size(190, 396);
      this.actorViewer.TabIndex = 1;
      // 
      // actorsComboBox
      // 
      this.actorsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.actorsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.actorsComboBox.FormattingEnabled = true;
      this.actorsComboBox.Location = new System.Drawing.Point(3, 3);
      this.actorsComboBox.Name = "actorsComboBox";
      this.actorsComboBox.Size = new System.Drawing.Size(190, 21);
      this.actorsComboBox.TabIndex = 0;
      this.actorsComboBox.SelectedIndexChanged += new System.EventHandler(this.actorsComboBox_SelectedIndexChanged);
      // 
      // saveSimulationFileDialog
      // 
      this.saveSimulationFileDialog.DefaultExt = "ant";
      this.saveSimulationFileDialog.Filter = "Simulation Files (*.ant)|*.ant|All Files (*.*)|*.*";
      this.saveSimulationFileDialog.Title = "Save Simulation As";
      // 
      // openSimulationFileDialog
      // 
      this.openSimulationFileDialog.DefaultExt = "ant";
      this.openSimulationFileDialog.Filter = "Simulation Files (*.ant)|*.ant|All Files (*.*)|*.*";
      this.openSimulationFileDialog.Title = "Open Simulation";
      // 
      // toolStripMenuItem8
      // 
      this.toolStripMenuItem8.Name = "toolStripMenuItem8";
      this.toolStripMenuItem8.Size = new System.Drawing.Size(196, 6);
      // 
      // pauseOnMoveToolStripMenuItem
      // 
      this.pauseOnMoveToolStripMenuItem.Name = "pauseOnMoveToolStripMenuItem";
      this.pauseOnMoveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
      this.pauseOnMoveToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
      this.pauseOnMoveToolStripMenuItem.Text = "&Pause On Move...";
      this.pauseOnMoveToolStripMenuItem.Click += new System.EventHandler(this.pauseOnMoveToolStripMenuItem_Click);
      // 
      // langtonsantsimulator_richardmoss_MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(804, 502);
      this.Controls.Add(this.viewSplitContainer);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.toolStrip);
      this.Controls.Add(this.menuStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip;
      this.Name = "langtonsantsimulator_richardmoss_MainForm";
      this.Text = "Langton\'s Ant Simulator";
      this.Load += new System.EventHandler(this.langtonsantsimulator_richardmoss_MainForm_Load);
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.viewSplitContainer.Panel1.ResumeLayout(false);
      this.viewSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.viewSplitContainer)).EndInit();
      this.viewSplitContainer.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton newToolStripButton;
    private System.Windows.Forms.ToolStripButton openToolStripButton;
    private System.Windows.Forms.ToolStripButton saveToolStripButton;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
    private System.Windows.Forms.ToolStripButton startSimulationToolStripButton;
    private System.Windows.Forms.ToolStripButton stopSimulationToolStripButton;
    private System.Windows.Forms.ToolStripButton pauseSimulationToolStripButton;
    private System.Windows.Forms.ToolStripStatusLabel sizeToolStripStatusLabel;
    private System.Windows.Forms.ToolStripMenuItem delayToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel moveToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
    private System.Windows.Forms.ToolStripMenuItem drawOutputToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem nextMoveToolStripMenuItem;
    private System.Windows.Forms.ToolStripButton nextMoveToolStripButton;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem exportImageToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
    private System.Windows.Forms.SaveFileDialog saveImageFileDialog;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
    private System.Windows.Forms.ToolStripMenuItem addAntToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton addAntToolStripButton;
    private System.Windows.Forms.SplitContainer viewSplitContainer;
    private langtonsantsimulator_richardmoss_SimulationPanel simulationPanel;
    private System.Windows.Forms.ComboBox actorsComboBox;
    private langtonsantsimulator_richardmoss_ActorViewer actorViewer;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripButton exportImageToolStripButton;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem coloursToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
    private System.Windows.Forms.ToolStripMenuItem blackAndWhiteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem earthyToolStripMenuItem;
    private System.Windows.Forms.SaveFileDialog saveSimulationFileDialog;
    private System.Windows.Forms.OpenFileDialog openSimulationFileDialog;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
    private System.Windows.Forms.ToolStripMenuItem pauseOnMoveToolStripMenuItem;
  }
}

