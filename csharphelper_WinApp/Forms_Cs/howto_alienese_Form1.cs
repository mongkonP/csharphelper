using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Glyph image at: http://futurama.wikia.com/wiki/Alienese

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_alienese_Form1:Form
  { 


        public howto_alienese_Form1()
        {
            InitializeComponent();
        }

        // Dictionary to map characters to glyph buttons.
        private Dictionary<char, Image> GlyphDict =
            new Dictionary<char, Image>();

        private void howto_alienese_Form1_Load(object sender, EventArgs e)
        {
            // Create the decoding buttons.
            for (char ch = 'A'; ch <= 'M'; ch++)
                MakeButton(GlyphDict, flpButtons1, ch.ToString());
            for (char ch = 'N'; ch <= 'Z'; ch++)
                MakeButton(GlyphDict, flpButtons2, ch.ToString());
            for (char ch = '0'; ch <= '9'; ch++)
                MakeButton(GlyphDict, flpButtons3, ch.ToString());
            foreach (char ch in "\'!“”:-.; ")
                MakeButton(GlyphDict, flpButtons4, ch.ToString());

            Button btnCl = new Button();
            btnCl.Font = this.Font;
            btnCl.Parent = flpButtons4;
            btnCl.Size = new Size(54, 24);
            btnCl.Text = "CL";
            btnCl.Click += btnCl_Click;

            Button btnBs = new Button();
            btnBs.Font = this.Font;
            btnBs.Parent = flpButtons4;
            btnBs.Size = new Size(54, 24);
            btnBs.Text = "BS";
            btnBs.Click += btnBs_Click;
        }

        // Make a button.
        private const int BTN_WID = 24;
        private void MakeButton(
            Dictionary<char, Image> glyph_dict,
            Control parent, string text)
        {
            // Make the button.
            Button btn = new Button();
            btn.Parent = parent;
            btn.Size = new Size(BTN_WID, BTN_WID);
            btn.Tag = text;
            btn.Font = this.Font;
            btn.Click += btnDecode_Click;
            ttip.SetToolTip(btn, text);

            // Get the button's image.
            string name = ResourceName(text);
            Bitmap bm = Properties.Resources.ResourceManager.GetObject(name) as Bitmap;
            Bitmap new_bm = new Bitmap(BTN_WID, BTN_WID);
            using (Graphics gr = Graphics.FromImage(new_bm))
            {
                gr.InterpolationMode = InterpolationMode.High;
                gr.Clear(Color.White);
                Point[] dest_points =
                {
                    new Point(2, 2),
                    new Point(btn.ClientSize.Width - 3, 2),
                    new Point(2, btn.ClientSize.Height - 3),
                };
                gr.DrawImage(bm, dest_points);
            }
            btn.Image = new_bm;

            // Save the image in the glyph dictionary.
            glyph_dict.Add(text[0], new_bm);
        }

        // Convert a character into its resource name.
        private string ResourceName(string text)
        {
            char ch = text[0];
            if ((ch >= 'A') && (ch <= 'Z')) return text;
            if ((ch >= '0') && (ch <= '9')) return "_" + text;
            switch (ch)
            {
                case '\'': return "Apostrophe";
                case '!': return "Bang";
                case '“': return "OpenQuote";
                case '”': return "OpenQuote";
                case ':': return "Colon";
                case '-': return "Dash";
                case '.': return "Period";
                case ';': return "SemiColon";
                case ' ': return "Space";
                default: return null;
            }
        }

        // Clear the decoded message.
        private void btnCl_Click(object sender, EventArgs e)
        {
            txtDecode.Clear();
        }

        // Remove the last letter from the decoded message.
        private void btnBs_Click(object sender, EventArgs e)
        {
            int len = txtDecode.Text.Length;
            if (len > 0)
                txtDecode.Text = txtDecode.Text.Substring(0, len - 1);
        }

        // Add a character to the decoded message.
        private void btnDecode_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtDecode.AppendText(btn.Tag as string);
        }

        // Add a character to the decoded message.
        private void txtEncode_TextChanged(object sender, EventArgs e)
        {
            flpEncoding.Controls.Clear();
            foreach (char ch in txtEncode.Text.ToUpper())
            {
                if (GlyphDict.ContainsKey(ch))
                {
                    PictureBox pic = new PictureBox();
                    pic.SizeMode = PictureBoxSizeMode.AutoSize;
                    pic.Image = GlyphDict[ch];
                    pic.Parent = flpEncoding;
                }
            }
        }

        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
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
            this.txtEncode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDecode = new System.Windows.Forms.TextBox();
            this.flpButtons1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpEncoding = new System.Windows.Forms.FlowLayoutPanel();
            this.ttip = new System.Windows.Forms.ToolTip(this.components);
            this.flpButtons3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpButtons4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpButtons2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEncode
            // 
            this.txtEncode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEncode.Location = new System.Drawing.Point(3, 23);
            this.txtEncode.Multiline = true;
            this.txtEncode.Name = "txtEncode";
            this.tableLayoutPanel1.SetRowSpan(this.txtEncode, 4);
            this.txtEncode.Size = new System.Drawing.Size(208, 122);
            this.txtEncode.TabIndex = 0;
            this.txtEncode.TextChanged += new System.EventHandler(this.txtEncode_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 404F));
            this.tableLayoutPanel1.Controls.Add(this.flpButtons4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpButtons3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.flpButtons2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtEncode, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpButtons1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flpEncoding, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtDecode, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(618, 321);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // txtDecode
            // 
            this.txtDecode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDecode.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecode.Location = new System.Drawing.Point(217, 151);
            this.txtDecode.Multiline = true;
            this.txtDecode.Name = "txtDecode";
            this.txtDecode.ReadOnly = true;
            this.txtDecode.Size = new System.Drawing.Size(398, 167);
            this.txtDecode.TabIndex = 3;
            // 
            // flpButtons1
            // 
            this.flpButtons1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.flpButtons1.Location = new System.Drawing.Point(217, 23);
            this.flpButtons1.Name = "flpButtons1";
            this.flpButtons1.Size = new System.Drawing.Size(398, 26);
            this.flpButtons1.TabIndex = 0;
            // 
            // flpEncoding
            // 
            this.flpEncoding.BackColor = System.Drawing.Color.White;
            this.flpEncoding.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpEncoding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpEncoding.Location = new System.Drawing.Point(3, 151);
            this.flpEncoding.Name = "flpEncoding";
            this.flpEncoding.Size = new System.Drawing.Size(208, 167);
            this.flpEncoding.TabIndex = 1;
            // 
            // flpButtons3
            // 
            this.flpButtons3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.flpButtons3.Location = new System.Drawing.Point(217, 87);
            this.flpButtons3.Name = "flpButtons3";
            this.flpButtons3.Size = new System.Drawing.Size(398, 26);
            this.flpButtons3.TabIndex = 2;
            // 
            // flpButtons4
            // 
            this.flpButtons4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.flpButtons4.Location = new System.Drawing.Point(217, 119);
            this.flpButtons4.Name = "flpButtons4";
            this.flpButtons4.Size = new System.Drawing.Size(398, 26);
            this.flpButtons4.TabIndex = 3;
            // 
            // flpButtons2
            // 
            this.flpButtons2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.flpButtons2.Location = new System.Drawing.Point(217, 55);
            this.flpButtons2.Name = "flpButtons2";
            this.flpButtons2.Size = new System.Drawing.Size(398, 26);
            this.flpButtons2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(217, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Decode";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_alienese_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 345);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_alienese_Form1";
            this.Text = "howto_alienese";
            this.Load += new System.EventHandler(this.howto_alienese_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtEncode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtDecode;
        private System.Windows.Forms.ToolTip ttip;
        private System.Windows.Forms.FlowLayoutPanel flpEncoding;
        private System.Windows.Forms.FlowLayoutPanel flpButtons1;
        private System.Windows.Forms.FlowLayoutPanel flpButtons3;
        private System.Windows.Forms.FlowLayoutPanel flpButtons4;
        private System.Windows.Forms.FlowLayoutPanel flpButtons2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

