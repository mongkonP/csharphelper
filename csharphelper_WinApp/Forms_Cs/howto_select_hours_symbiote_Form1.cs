using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_select_hours_symbiote;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_select_hours_symbiote_Form1:Form
  { 


        public howto_select_hours_symbiote_Form1()
        {
            InitializeComponent();
        }

        // The symbiotes.
        private SelectHoursSymbiote Symbiote1, Symbiote2;

        private void howto_select_hours_symbiote_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;

            // Create the symbiotes.
            Symbiote1 = new SelectHoursSymbiote(picHours1);
            Symbiote1.HoursChanged += pic_HoursChanged;
            Symbiote1.HoursScrolled += pic_HoursChanged;
            Symbiote1.StartHour = 6;
            Symbiote1.StopHour = 14;

            Symbiote2 = new SelectHoursSymbiote(picHours2);
            Symbiote2.HoursChanged += pic_HoursChanged;
            Symbiote2.HoursScrolled += pic_HoursChanged;
            Symbiote2.StartHour = 9;
            Symbiote2.StopHour = 17;
        }

        // Show the times in the TextBoxes.
        private void pic_HoursChanged(object sender, EventArgs e)
        {
            SelectHoursSymbiote symbiote = sender as SelectHoursSymbiote;
            DateTime start_time = new DateTime(2000, 1, 1, symbiote.StartHour, 0, 0);
            DateTime stop_time = new DateTime(2000, 1, 1, symbiote.StopHour, 0, 0);

            string tip = start_time.ToShortTimeString() +
                " to " +
                stop_time.ToShortTimeString();
            if (tipHour.GetToolTip(symbiote.PictureBox) != tip)
                tipHour.SetToolTip(symbiote.PictureBox, tip);

            if (symbiote == Symbiote1)
            {
                txtStartTime1.Text = start_time.ToShortTimeString();
                txtStopTime1.Text = stop_time.ToShortTimeString();
            }
            else
            {
                txtStartTime2.Text = start_time.ToShortTimeString();
                txtStopTime2.Text = stop_time.ToShortTimeString();
            }
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStopTime2 = new System.Windows.Forms.TextBox();
            this.txtStartTime2 = new System.Windows.Forms.TextBox();
            this.picHours2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tipHour = new System.Windows.Forms.ToolTip(this.components);
            this.txtStopTime1 = new System.Windows.Forms.TextBox();
            this.txtStartTime1 = new System.Windows.Forms.TextBox();
            this.picHours1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHours2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHours1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(536, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "To";
            // 
            // txtStopTime2
            // 
            this.txtStopTime2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtStopTime2.Location = new System.Drawing.Point(517, 131);
            this.txtStopTime2.Name = "txtStopTime2";
            this.txtStopTime2.ReadOnly = true;
            this.txtStopTime2.Size = new System.Drawing.Size(55, 20);
            this.txtStopTime2.TabIndex = 17;
            this.txtStopTime2.TabStop = false;
            this.txtStopTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStartTime2
            // 
            this.txtStartTime2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtStartTime2.Location = new System.Drawing.Point(517, 92);
            this.txtStartTime2.Name = "txtStartTime2";
            this.txtStartTime2.ReadOnly = true;
            this.txtStartTime2.Size = new System.Drawing.Size(55, 20);
            this.txtStartTime2.TabIndex = 16;
            this.txtStartTime2.TabStop = false;
            this.txtStartTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picHours2
            // 
            this.picHours2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picHours2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picHours2.Location = new System.Drawing.Point(12, 87);
            this.picHours2.Name = "picHours2";
            this.picHours2.Size = new System.Drawing.Size(499, 70);
            this.picHours2.TabIndex = 15;
            this.picHours2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "To";
            // 
            // txtStopTime1
            // 
            this.txtStopTime1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtStopTime1.Location = new System.Drawing.Point(517, 55);
            this.txtStopTime1.Name = "txtStopTime1";
            this.txtStopTime1.ReadOnly = true;
            this.txtStopTime1.Size = new System.Drawing.Size(55, 20);
            this.txtStopTime1.TabIndex = 13;
            this.txtStopTime1.TabStop = false;
            this.txtStopTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStartTime1
            // 
            this.txtStartTime1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtStartTime1.Location = new System.Drawing.Point(517, 16);
            this.txtStartTime1.Name = "txtStartTime1";
            this.txtStartTime1.ReadOnly = true;
            this.txtStartTime1.Size = new System.Drawing.Size(55, 20);
            this.txtStartTime1.TabIndex = 12;
            this.txtStartTime1.TabStop = false;
            this.txtStartTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picHours1
            // 
            this.picHours1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picHours1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picHours1.Location = new System.Drawing.Point(12, 11);
            this.picHours1.Name = "picHours1";
            this.picHours1.Size = new System.Drawing.Size(499, 70);
            this.picHours1.TabIndex = 11;
            this.picHours1.TabStop = false;
            // 
            // howto_select_hours_symbiote_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 169);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStopTime2);
            this.Controls.Add(this.txtStartTime2);
            this.Controls.Add(this.picHours2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStopTime1);
            this.Controls.Add(this.txtStartTime1);
            this.Controls.Add(this.picHours1);
            this.Name = "howto_select_hours_symbiote_Form1";
            this.Text = "howto_select_hours_symbiote";
            this.Load += new System.EventHandler(this.howto_select_hours_symbiote_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHours2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHours1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStopTime2;
        private System.Windows.Forms.TextBox txtStartTime2;
        private System.Windows.Forms.PictureBox picHours2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip tipHour;
        private System.Windows.Forms.TextBox txtStopTime1;
        private System.Windows.Forms.TextBox txtStartTime1;
        private System.Windows.Forms.PictureBox picHours1;
    }
}

