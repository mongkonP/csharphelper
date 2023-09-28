using csharphelper.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharphelper
{
    public partial class frm_project : Form
    {
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
            // frm_project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Name = "frm_project";
            this.Text = "frm_project";
            this.Load += new System.EventHandler(this.frm_project_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        public frm_project()
        {
            InitializeComponent();
        }
        string str_frm_1 = "", str_frm_2 = "", str_frm_3 = "";
        void SetProject(string path,string ID)
        {
           

            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() =>
            {
                System.IO.Directory.GetFiles(path, "*.csproj", System.IO.SearchOption.AllDirectories).ToList<string>()
                .ForEach(f =>
                {
                    this.Invoke(new Action(() => this.Text = "SetProject ID File:" + f));

                    string file_Code;
                    using (StreamReader reader = new StreamReader(f))
                    {
                        file_Code = reader.ReadToEnd();
                        reader.Dispose();
                        reader.Close();
                    }
                    string ProjectGuid;
                    try
                    {
                        ProjectGuid = new Regex(@"<ProjectGuid>({.*?})</ProjectGuid>", RegexOptions.None).Matches(file_Code)[0].Groups[1].Value.Trim();
                    }
                    catch { ProjectGuid = ""; }
                    if ( ProjectIDs._ProjectIDs.Contains(ProjectGuid))
                    {
                        string ProjectGuid_temp = ProjectGuid;
                        ProjectGuid = ProjectIDs.GetProjectID();

                        file_Code = file_Code.Replace(ProjectGuid_temp, ProjectGuid);
                        using (StreamWriter writer = new StreamWriter(f))
                        {
                            writer.Write(file_Code);
                        }

                    }
                    if (ProjectGuid != "") ProjectIDs._ProjectIDs.Add(ProjectGuid);
                    string AssemblyName;

                    try
                    {
                        AssemblyName = new Regex(@"<AssemblyName>(.*?)</AssemblyName>", RegexOptions.None).Matches(file_Code)[0].Groups[1].Value.Trim();
                    }
                    catch { AssemblyName = ""; }
                if (ProjectGuid != "")
                {
                    str_frm_1 += "Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"" + AssemblyName + "\", \"" + f.Replace(@"D:\Mega_TOR\Test_Code\csharphelper_project\", "") + "\", \"" + ProjectGuid + "\"\nEndProject\n" ;
                    str_frm_2 += ProjectGuid + ".Debug|Any CPU.ActiveCfg = Debug|x86  \n"
                            + ProjectGuid + ".Debug|x86.ActiveCfg = Debug|x86  \n"
                            + ProjectGuid + ".Debug|x86.Build.0 = Debug|x86 \n"
                             + ProjectGuid + ".Release|Any CPU.ActiveCfg = Release|x86 \n"
                              + ProjectGuid + ".Release|x86.ActiveCfg = Release|x86 \n"
                               + ProjectGuid + ".Release|x86.Build.0 = Release|x86 \n";
                    str_frm_3 += ProjectGuid + " = "+ ID+"\n";
                    }
                    else
                    {
                        richTextBox1.Invoke(new Action(() => richTextBox1.Text += "\nSetProject ID File Error:" + f + ":" + ProjectGuid));
                    }
                });
             
            }));
           


            Task.WaitAll(tasks.ToArray());
            System.Threading.Thread.Sleep(100);


            this.Invoke(new Action(() => this.Text = " SetProject ID File: Complete.." + DateTime.Now));
        }
        void MoveFolderProject()
        {

            List<Task> tasks = new List<Task>();
            System.IO.Directory.GetFiles(Program.folCode, "*.csproj", System.IO.SearchOption.AllDirectories).ToList<string>()
                       .ForEach(f =>
                       {
                           richTextBox1.Invoke(new Action(() => richTextBox1.Text = "\nMoveFolderProject File:" + f));
                           tasks.Add(Task.Run(() =>
                           {
                               string fol = Path.GetDirectoryName(f);
                               if (Directory.Exists(fol))
                               {
                                   if (File.Exists(f.Replace(".csproj", ".png"))) File.Delete(f.Replace(".csproj", ".png"));
                                   var dirs = Directory.GetFiles(fol, "App.xaml.cs", SearchOption.TopDirectoryOnly);
                                   string dir = TorServices.FilePath.RenameDirDup(((dirs.Length > 0) ? Program.folWinWPF : Program.folWinApp) + @"\" + Path.GetFileName(fol));
                                   Directory.Move(fol, dir);
                               }
                               Thread.Sleep(1000);
                           }));



                       });
            Task.WaitAll(tasks.ToArray());
            Thread.Sleep(2000);
            this.Invoke(new Action(() => this.Text = " MoveFolderProject File: Complete.." + DateTime.Now));
        }

        void SetFileProject()
        {
            string Project_ToolsVersion = "<Project ToolsVersion=\"15.0\" DefaultTargets=";
            string TargetFrameworkVersion = "<TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>";
            string RequiredTargetFramework = "<RequiredTargetFramework>4.7.2</RequiredTargetFramework>";
            List<Task> tasks = new List<Task>();
            Directory.GetFiles(Program.pathrun, "*.csproj", SearchOption.AllDirectories).ToList<string>()
                .ForEach(f =>
                {
                    tasks.Add(Task.Run(() =>
                    {
                        string f_csproj = f;
                        richTextBox1.Invoke(new Action(() => richTextBox1.Text = "\n SetFileProject File:" + f));
                        string code_csproj;
                        using (StreamReader reader = new StreamReader(f_csproj))
                        {
                            code_csproj = reader.ReadToEnd();

                            code_csproj = new Regex(@"<Project ToolsVersion=""(.*?)""\s{0,}DefaultTargets=", RegexOptions.None).Replace(code_csproj, Project_ToolsVersion);
                            code_csproj = new Regex(@"<TargetFrameworkVersion>(.*?)</TargetFrameworkVersion>", RegexOptions.None).Replace(code_csproj, TargetFrameworkVersion);
                            code_csproj = new Regex(@"<RequiredTargetFramework>(.*?)</RequiredTargetFramework>", RegexOptions.None).Replace(code_csproj, RequiredTargetFramework);

                            reader.Dispose();
                            reader.Close();
                        }
                        string ProjectGuid;
                        try
                        {
                            ProjectGuid = new Regex(@"<ProjectGuid>({.*?})</ProjectGuid>", RegexOptions.None).Matches(code_csproj)[0].Groups[1].Value.Trim();
                        }
                        catch { ProjectGuid = ""; }
                        if (ProjectIDs._ProjectIDs.Contains(ProjectGuid))
                        {
                            string ProjectGuid_temp = ProjectGuid;
                            ProjectGuid = ProjectIDs.GetProjectID();

                            code_csproj = code_csproj.Replace(ProjectGuid_temp, ProjectGuid);

                        }
                        if (ProjectGuid != "") ProjectIDs._ProjectIDs.Add(ProjectGuid);

                        using (StreamWriter writer = new StreamWriter(f_csproj))
                        {

                            writer.Write(code_csproj);
                        }
                        Thread.Sleep(1000);
                    }));
                   
                });
            Task.WaitAll(tasks.ToArray());
            Thread.Sleep(1000);
            this.Invoke(new Action(() => this.Text = " SetFileProject File: Complete.." + DateTime.Now));
        }
        private void frm_project_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                /*  List<Task> tasks = new List<Task>();
                  this.Invoke(new Action(() => this.Text = "delete File:"));
                  tasks.Add(Task.Run(() => Program.deletepngFile()));
                  tasks.Add(Task.Run(() => TorServices.FilePath.DelFile(Program.pathrun, ".sln")));
                  tasks.Add(Task.Run(() => TorServices.FilePath.DelFile(Program.pathrun, ".suo")));

                  this.Invoke(new Action(() => this.Text = "delete File: Complete" + DateTime.Now));
                  Task.WaitAll(tasks.ToArray());
                  Thread.Sleep(1000);
                  richTextBox1.Invoke(new Action(() => richTextBox1.Text = " SetFileProject File:"));
                  SetFileProject();
                  Thread.Sleep(1000);
                  richTextBox1.Invoke(new Action(() => richTextBox1.Text = " MoveFolderProject File:"));
                  MoveFolderProject();
                  Thread.Sleep(1000);*/

                //  TorServices.FilePath.DelEmptyFolder(Program.pathrun);

                richTextBox1.Invoke(new Action(() => richTextBox1.Text = " SetProject File:"));

                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\WinWPF", "{541902EA-48DC-42E6-A46D-38ADA14EAF80}");
               SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\WinForm\_frm_2", "{D4E3A729-962F-43C1-9083-7F1A993F0A36}");
               SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\top100src", "{4D6E58E5-1C19-4E64-AC6E-AB8F104AC810}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch01",  "{7174B18F-6D4A-184B-2904-B18FC2F6D384}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch02", "{B29D907E-A15C-3A0D-4B18-5C0C3A15C85C}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch04", "{27D4B2E5-26D4-07B2-9FC3-A6D185B2F5C0}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch05", "{748F6C30-7DA1-B7E2-96C1-74B7B8595963}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch06", "{7EA7D28F-637E-4B29-5C9D-4A7E518F3A17}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch07", "{E528F6A1-8415-C3F6-D407-B8F59637E418}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch08", "{4B29D4A7-E5B0-C9D4-0A1E-2E526296A6B1}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch09", "{8F62907E-A18F-5C07-E5C8-F626D415C2F6}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch10", "{D7D41D1E-595C-3DA0-D4BF-62906BD1E5B2}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch11", "{F5C07EB5-B8F3-A6D4-07E2-F3F6D4B7B296}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch12", "{C3A184B2-9F4A-18FB-2907-D28F6D907E5B}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch13", "{8F5C37E5-C3F6-D3A1-E4B2-9D4B185C2790}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch14", "{6D48B16C-93A6-071B-7EE8-44EA74851EE8}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch15", "{FBFC9F40-D3A1-5263-F36C-17E528F6A1DA}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch16", "{18C3F6D9-E4B2-95C0-7EA1-85B29DA17EBF}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch17", "{B06DA177-EAF5-26D9-07E8-F1528F6A18FB}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch18", "{8F3A074A-7E5B-263A-17C2-96D907E2E5C8}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch19", "{F6A18F52-906D-48F6-D307-E4B8F5C37E5C}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch20", "{296C3A1D-4B29-D4A1-8FB2-907B285C396A}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch21", "{7374BF18-2F5A-6A73-8417-E5C07E8EB7E2}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch22", "{FC0C374B-5B29-62C3-A07E-290C9040D1E5}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch23", "{906DA6D4-B18F-6A18-EB8C-3F6D48EB82E2}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch24", "{F60C0373-7415-C8FB-26D4-B28F63907E59}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch25", "{06906D4B-2829-07EA-18C3-F6D4A15C3A17}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch26", "{4B28FC39-07B2-906D-A17E-528F6D184B26}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch27", "{3F30C174-BF62-F3A6-3748-418F5A07EB1E}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch28", "{295C374B-1E2F-526D-4B7B-849528F90418}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch29", "{48FC8F30-7D28-FC6C-907D-415C396D18E5}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch30", "{C9F6D407-E5C0-7D4B-2E5C-3A6D4B18C3A1}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch31", "{84B29F6A-7E5B-8F5C-37E5-C2F6D3A1E4B2}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch32", "{9D4B18FC-2907-B29F-63A0-7E5F6C906D4B}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch33", "{7E5C37E4-B2F3-A07E-518F-6D907E49F6D4}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch34", "{B7E5C296-C3A1-5C39-6D4A-F5C3A6D4B285}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\wpf3dsrc\Ch35", "{C3904B29-0C3A-17EB-28F6-A18F52906D48}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 01", "{DF7AE4A4-40DB-0B9C-4BD6-4BFFE4015761}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 02", "{C49A9BEC-4569-C818-AFA3-00B8FE2C4486}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 03", "{B9AA3234-4A06-7494-0260-D472084741AB}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 04", "{D84617B3-6788-E49A-11D1-9EB7A87C0C31}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 05", "{F7E30C43-831A-54A0-2031-68FC47B2D8C7}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 06", "{91CC635A-9AD0-1BFC-C49B-0E0CCD1E67F8}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 07", "{1A90880A-A53A-8022-826F-F7FBF1139061}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 08", "{A479FF22-BCF0-487E-36C9-9C0B777F2F93}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 09", "{C316D4A2-D882-B784-452A-664006A4FB29}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 10", "{6D0F4BC9-DF58-7FD0-EA84-0C508C00795A}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 12", "{8C9C2159-FBDA-EED6-F8E4-D6962B4645E0}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 13", "{AA3806D8-286C-5EDC-0745-90DBCB8C1176}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 14", "{9F48BC10-1DFA-0B58-6B12-6494D5A70D9B}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 15", "{BEE592A0-498C-7B6E-7972-2EDA75DCD920}");
                SetProject(@"D:\Mega_TOR\Test_Code\csharphelper_project\algs2e_csharp\Chapter 16", "{58DE09B8-4051-32BA-1EDD-D4E9FA385852}");

                using (StreamWriter writer = new StreamWriter(File.Create(Program.pathTemp + "\\_str_frm_1.txt")))
                {
                    writer.Write(str_frm_1);
                    System.Threading.Thread.Sleep(1000);
                }
                using (StreamWriter writer = new StreamWriter(File.Create(Program.pathTemp + "\\_str_frm_2.txt")))
                {
                    writer.Write(str_frm_2);
                    System.Threading.Thread.Sleep(1000);
                }
                using (StreamWriter writer = new StreamWriter(File.Create(Program.pathTemp + "\\_str_frm_3.txt")))
                {
                    writer.Write(str_frm_3);
                    System.Threading.Thread.Sleep(1000);
                }
                MessageBox.Show("Complete...");
            });
        }
    }
}
