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
     public partial class howto_initialize_array_of_arrays_Form1:Form
  { 


        public howto_initialize_array_of_arrays_Form1()
        {
            InitializeComponent();
        }

        // True if it is X's turn.
        private bool XsTurn = true;

        // An array of arrays holding the squares.
        private Label[][] Squares;

        // Initialize the array of arrays holding the squares.
        private void howto_initialize_array_of_arrays_Form1_Load(object sender, EventArgs e)
        {
            Squares = new Label[][]
            {
                new Label[] { lblSquare00, lblSquare01, lblSquare02},
                new Label[] { lblSquare10, lblSquare11, lblSquare12},
                new Label[] { lblSquare20, lblSquare21, lblSquare22},
            };
        }

        // Clear all squares.
        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Label[] array in Squares)
                foreach (Label label in array) label.Text = "";
        }

        // A square was clicked.
        private void lblSquare_Click(object sender, EventArgs e)
        {
            // Get the label clicked.
            Label lbl = sender as Label;

            // If the square is already taken, do nothing.
            if (lbl.Text != "") return;

            // Take it for the current player.
            if (XsTurn) lbl.Text = "X";
            else lbl.Text = "O";

            XsTurn = !XsTurn;
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
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSquare22 = new System.Windows.Forms.Label();
            this.lblSquare21 = new System.Windows.Forms.Label();
            this.lblSquare20 = new System.Windows.Forms.Label();
            this.lblSquare12 = new System.Windows.Forms.Label();
            this.lblSquare11 = new System.Windows.Forms.Label();
            this.lblSquare10 = new System.Windows.Forms.Label();
            this.lblSquare02 = new System.Windows.Forms.Label();
            this.lblSquare01 = new System.Windows.Forms.Label();
            this.lblSquare00 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(221, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblSquare22
            // 
            this.lblSquare22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSquare22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSquare22.Font = new System.Drawing.Font("Times New Roman", 40F);
            this.lblSquare22.Location = new System.Drawing.Point(151, 155);
            this.lblSquare22.Name = "lblSquare22";
            this.lblSquare22.Size = new System.Drawing.Size(64, 64);
            this.lblSquare22.TabIndex = 28;
            this.lblSquare22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSquare22.Click += new System.EventHandler(this.lblSquare_Click);
            // 
            // lblSquare21
            // 
            this.lblSquare21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSquare21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSquare21.Font = new System.Drawing.Font("Times New Roman", 40F);
            this.lblSquare21.Location = new System.Drawing.Point(81, 155);
            this.lblSquare21.Name = "lblSquare21";
            this.lblSquare21.Size = new System.Drawing.Size(64, 64);
            this.lblSquare21.TabIndex = 27;
            this.lblSquare21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSquare21.Click += new System.EventHandler(this.lblSquare_Click);
            // 
            // lblSquare20
            // 
            this.lblSquare20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSquare20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSquare20.Font = new System.Drawing.Font("Times New Roman", 40F);
            this.lblSquare20.Location = new System.Drawing.Point(11, 155);
            this.lblSquare20.Name = "lblSquare20";
            this.lblSquare20.Size = new System.Drawing.Size(64, 64);
            this.lblSquare20.TabIndex = 26;
            this.lblSquare20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSquare20.Click += new System.EventHandler(this.lblSquare_Click);
            // 
            // lblSquare12
            // 
            this.lblSquare12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSquare12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSquare12.Font = new System.Drawing.Font("Times New Roman", 40F);
            this.lblSquare12.Location = new System.Drawing.Point(151, 82);
            this.lblSquare12.Name = "lblSquare12";
            this.lblSquare12.Size = new System.Drawing.Size(64, 64);
            this.lblSquare12.TabIndex = 25;
            this.lblSquare12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSquare12.Click += new System.EventHandler(this.lblSquare_Click);
            // 
            // lblSquare11
            // 
            this.lblSquare11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSquare11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSquare11.Font = new System.Drawing.Font("Times New Roman", 40F);
            this.lblSquare11.Location = new System.Drawing.Point(81, 82);
            this.lblSquare11.Name = "lblSquare11";
            this.lblSquare11.Size = new System.Drawing.Size(64, 64);
            this.lblSquare11.TabIndex = 24;
            this.lblSquare11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSquare11.Click += new System.EventHandler(this.lblSquare_Click);
            // 
            // lblSquare10
            // 
            this.lblSquare10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSquare10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSquare10.Font = new System.Drawing.Font("Times New Roman", 40F);
            this.lblSquare10.Location = new System.Drawing.Point(11, 82);
            this.lblSquare10.Name = "lblSquare10";
            this.lblSquare10.Size = new System.Drawing.Size(64, 64);
            this.lblSquare10.TabIndex = 23;
            this.lblSquare10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSquare10.Click += new System.EventHandler(this.lblSquare_Click);
            // 
            // lblSquare02
            // 
            this.lblSquare02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSquare02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSquare02.Font = new System.Drawing.Font("Times New Roman", 40F);
            this.lblSquare02.Location = new System.Drawing.Point(151, 9);
            this.lblSquare02.Name = "lblSquare02";
            this.lblSquare02.Size = new System.Drawing.Size(64, 64);
            this.lblSquare02.TabIndex = 22;
            this.lblSquare02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSquare02.Click += new System.EventHandler(this.lblSquare_Click);
            // 
            // lblSquare01
            // 
            this.lblSquare01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSquare01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSquare01.Font = new System.Drawing.Font("Times New Roman", 40F);
            this.lblSquare01.Location = new System.Drawing.Point(81, 9);
            this.lblSquare01.Name = "lblSquare01";
            this.lblSquare01.Size = new System.Drawing.Size(64, 64);
            this.lblSquare01.TabIndex = 21;
            this.lblSquare01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSquare01.Click += new System.EventHandler(this.lblSquare_Click);
            // 
            // lblSquare00
            // 
            this.lblSquare00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSquare00.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSquare00.Font = new System.Drawing.Font("Times New Roman", 40F);
            this.lblSquare00.Location = new System.Drawing.Point(11, 9);
            this.lblSquare00.Name = "lblSquare00";
            this.lblSquare00.Size = new System.Drawing.Size(64, 64);
            this.lblSquare00.TabIndex = 20;
            this.lblSquare00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSquare00.Click += new System.EventHandler(this.lblSquare_Click);
            // 
            // howto_initialize_array_of_arrays_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 229);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblSquare22);
            this.Controls.Add(this.lblSquare21);
            this.Controls.Add(this.lblSquare20);
            this.Controls.Add(this.lblSquare12);
            this.Controls.Add(this.lblSquare11);
            this.Controls.Add(this.lblSquare10);
            this.Controls.Add(this.lblSquare02);
            this.Controls.Add(this.lblSquare01);
            this.Controls.Add(this.lblSquare00);
            this.Name = "howto_initialize_array_of_arrays_Form1";
            this.Text = "howto_initialize_array_of_arrays";
            this.Load += new System.EventHandler(this.howto_initialize_array_of_arrays_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSquare22;
        private System.Windows.Forms.Label lblSquare21;
        private System.Windows.Forms.Label lblSquare20;
        private System.Windows.Forms.Label lblSquare12;
        private System.Windows.Forms.Label lblSquare11;
        private System.Windows.Forms.Label lblSquare10;
        private System.Windows.Forms.Label lblSquare02;
        private System.Windows.Forms.Label lblSquare01;
        private System.Windows.Forms.Label lblSquare00;
    }
}

