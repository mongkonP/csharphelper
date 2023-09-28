using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TorServices;
using System.IO;
using System.Text.RegularExpressions;

namespace csharphelper
{
   public  class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        int i = 0;
        void LoadByUrl(string Url)
        {
            // richTextBox1.Invoke(new Action(() => richTextBox1.Text += "\n" + Url));//@"""(.*?\.[razip]{3,})"""
            richTextBox1.Invoke(new Action(() => richTextBox1.Text += "\n\n\n" + Url));
            string link;
            Url.GetLinkByURL(@"""(https?://www\..*?\.[razip7]{2,})""").Result
                .ForEach(l =>
                {
                    i++;
                    link = (l.IndexOf("<a href=\"") > 0) ? new Regex(@"<a href=""(http://www.csharphelper.com/.*?\.zip)", RegexOptions.None).Matches(l)[0].Groups[1].Value : l;

                     richTextBox1.Invoke(new Action(() => richTextBox1.Text += "\n" + i + ":" + link));
                    TorServices.NetWorkTOR.LoadByIDM(link, Path.GetFileName(link));

                    Thread.Sleep(200);
                });
            // richTextBox1.Invoke(new Action(() => richTextBox1.Text += "\n" + Url + " Complete..."));
           // Thread.Sleep(2000);

        }
        private void frmMain_Load(object sender, EventArgs e)
        {


            // List<Task> tasks = new List<Task>();
            /*  string url;
              Task.Run(() =>
              {
                  for (int i = 1; i < 160; i++) 
                      {
                      url = "http://csharphelper.com/blog/page/" + i + "/";
                      this.Invoke(new Action(() => this.Text = "page:" + url));
                      LoadByUrl(url);
                          Thread.Sleep(10000);
                      }
                  //Task.WaitAll(tasks.ToArray());
                  Thread.Sleep(2000);
                  this.Invoke(new Action(() => this.Text += "Complete..."));

              }); */

          /*  Task.Run(() =>
            {
                this.Invoke(new Action(() => this.Text = "Runing..."));
                Directory.GetFiles(@"G:\csharphelper\2020-05-27", "*.zip").ToList<string>()
               .ForEach(f =>
               {
                   try
                   {
                       Directory.Delete(@"G:\csharphelper\csharphelper\" + Path.GetFileNameWithoutExtension(f),true);
                       Directory.Delete(@"G:\csharphelper\csharphelper_2\_New folder\" + Path.GetFileNameWithoutExtension(f),true);
                   }
                   catch { }
               });

                this.Invoke(new Action(() => this.Text = "Complete..."));

            });*/
           



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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(800, 450);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
