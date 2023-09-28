using System;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class challenge_Form1:Form
  { 


        public challenge_Form1()
        {
            InitializeComponent();
        }

        private void challenge_Form1_Load(object sender, EventArgs e)
        {
            string[] code = new string[] { "using System;", "using System.Text;", "using System.Windows.Forms;", "", "namespace challenge", "{", "    public partial class challenge_Form1 : Form", "    {", "        public challenge_Form1()", "        {", "            InitializeComponent();", "        }", "", "        private void challenge_Form1_Load(object sender, EventArgs e)", "        {", "!!", "            StringBuilder sb = new StringBuilder();", "            string self = \"            string[] code = new string[] {\";", "            foreach (string s in code)", "            {", "                string temp=s;", "                for (int i = 0; i < temp.Length; i++)", "                {", "                    if (temp[i] == '\\\"'||temp[i]=='\\\\')", "                    {", "                        temp = temp.Insert(i, \"\\\\\");", "                        i++;", "                    }", "            }", "                self += \"\\\"\" + temp + \"\\\", \";", "            }", "            self.Remove(self.Length - 1);", "            self += \"};\";", "            code[15]=self;", "            foreach (string s in code)", "            {", "                sb.AppendLine(s);", "            }", "            textBox1.Text = sb.ToString();", "        }", "    }", "}" };
            StringBuilder sb = new StringBuilder();
            string self = "             string[] code = new string[] {";
            foreach (string s in code)
            {
                string temp=s;
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] == '\"'||temp[i]=='\\')
                    {
                        temp = temp.Insert(i, "\\");
                        i++;
                    }
                }
                self += "\"" + temp + "\", ";
            }
            self.Remove(self.Length - 1);
            self += "};";
            code[15]=self;
            foreach (string s in code)
            {
                sb.AppendLine(s);
            }
            textBox1.Text = sb.ToString();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1247, 489);
            this.textBox1.TabIndex = 0;
            // 
            // challenge_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 489);
            this.Controls.Add(this.textBox1);
            this.Name = "challenge_Form1";
            this.Text = "challenge_Form1";
            this.Load += new System.EventHandler(this.challenge_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
    }
}

