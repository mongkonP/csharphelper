using csharphelper.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TorServices;

namespace csharphelper
{
    /*
     //Create scheduler from MSDN example and specify max tasks
            LimitedConcurrencyLevelTaskScheduler scheduler =new  LimitedConcurrencyLevelTaskScheduler(10);
            var factory = new TaskFactory(scheduler);

            //Optionally set up a cancellation token

            //Do the work
            var tasks = new List<Task>();
            foreach (var p in Listpage)
                tasks.Add(factory.StartNew(() => loadPicturebyURL(p)));
            
            //Wait for the work to complete
            Task.WaitAll(tasks.ToArray());
         
         */
    #region


    #endregion
    static class Program
    {
        public static string folCode = @"D:\csharphelper\2020-05-27";
        public static string folWinApp = @"D:\csharphelper\WinApp";
        public static string folWinWPF = @"D:\csharphelper\WinWPF";
        public static string folForms = @"D:\csharphelper\Forms";
        public static string folAppClass = @"D:\csharphelper\WinApp_Class";
        public static string folWindows = @"D:\csharphelper\Windows";
        public static string folWPFClass = @"D:\csharphelper\WinWPF_Class";
        public static string pathrun = @"D:\csharphelper\csharphelper_project";
        public static string pathTemp = @"D:\csharphelper\csharphelper_project\temp";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*  List<Task> tasks = new List<Task>();
          foreach (var f in (from wn in Directory.GetFiles(Program.folCode, "*.xaml.cs", SearchOption.AllDirectories)
                               where Path.GetFileName(wn) != "App.xaml.cs"
                               select wn).ToList<string>())
            {
                string fol = Path.GetDirectoryName(f);
                string _fol = folWinWPF + "\\" + Path.GetFileName(fol);
                if (Directory.Exists(_fol))
                    _fol = TorServices.FilePath.RenameDirDup(_fol);
                try
                {
                    Directory.Move(fol, _fol);
                }
                catch { }
            }*/
            /*tasks.Add(Task.Run(()=> SetWinForm()));
            tasks.Add(Task.Run(() => SetWinWPF()));
             Task.WaitAll(tasks.ToArray());
            Directory.CreateDirectory(folWinApp);
            Directory.CreateDirectory(folWinWPF);
            foreach (var f in Directory.GetFiles(Program.folCode, "Program.cs", SearchOption.AllDirectories).ToList<string>())
            {
                string fol = Path.GetDirectoryName(f);
                string _fol = folWinApp + "\\" + Path.GetFileName(fol);
                if (Directory.Exists(_fol))
                    _fol = TorServices.FilePath.RenameDirDup(_fol);
                try
                {
                    Directory.Move(fol, _fol);
                }
                catch { }
            }
            */
           // TorServices.FilePath.DelEmptyFolder(folCode);
          //  Set_File_sln_csproj(@"D:\csharphelper");
           // MessageBox.Show("Complete");

            Application.Run(new frm_test());
        }
  

        private static void Set_File_sln_csproj(string path)
        {
            string _path = path;
          List<Task>  tasks = new List<Task>();
            tasks.Add(Task.Run(() => Directory.GetFiles(_path, "*.sln", SearchOption.AllDirectories).ToList<string>()
            .ForEach(f => {

                if (File.Exists(f))
                { 
                     using (FileClass reader = new FileClass(f))
                    {

                        reader.code = new Regex(@"(Format Version .*?)\n", RegexOptions.None).Replace(reader.code, "Format Version 12.00\nVisualStudioVersion = 16.0.30011.22\nMinimumVisualStudioVersion = 10.0.40219.1\n");
                        reader.code = new Regex(@"(<Project ToolsVersion=\"".*?\"")", RegexOptions.None).Replace(reader.code, "<Project ToolsVersion=\"15.0\"");
                        reader.Save();
                        reader.Dispose();

                    }
                    try
                    {
                        File.Delete(f.Replace(".sln", ".png"));
                        File.Delete(f.Replace(".sln", "1.png"));
                        File.Delete(f.Replace(".sln", "2.png"));
                        File.Delete(f.Replace(".sln", "3.png"));
                        File.Delete(f.Replace(".sln", "4.png"));
                        File.Delete(f.Replace(".sln", ".suo"));
                    }
                    catch { }
                }




            })));

            tasks.Add(Task.Run(() => Directory.GetFiles(_path, "*.csproj", SearchOption.AllDirectories).ToList<string>()
            .ForEach(f => {

                if (File.Exists(f))
                {
                    using (FileClass reader = new FileClass(f))
                    {
                        //ตั้งค่า ToolsVersion ใหม่
                        reader.code = new Regex(@"<TargetFrameworkVersion>.*?</TargetFrameworkVersion>", RegexOptions.None).Replace(reader.code, "<TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>");
                        reader.code = new Regex(@"(<Project ToolsVersion=.*? DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">)",
                            RegexOptions.None).Replace(reader.code, @"<Project ToolsVersion=""Current"" DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">");
                        // ลบ Designer และ resx ทิ้ง ซะเลย
                        reader.code = new Regex(@" (<Compile Include="".*?.Designer.cs"">[\n\s]{0,}<DependentUpon>.*?.cs</DependentUpon>[\n\s]{0,}</Compile>)", RegexOptions.None).Replace(reader.code, "");
                        reader.code = new Regex(@"(<EmbeddedResource Include="".*?.resx"">[\n\s]{0,}<DependentUpon>.*?.cs</DependentUpon>[\n\s]{0,}</EmbeddedResource>)", RegexOptions.None).Replace(reader.code, "");
                        reader.Save();
                        reader.Dispose();
                    }
                }
            })));
            Task.WaitAll(tasks.ToArray());

        }
        
        private static void Set_File_WinApp(string _f)
        {
            string f = _f;
            string FolSet = Path.GetDirectoryName(f);
            
            if (Directory.Exists(FolSet))
            {

                // Set Class
                List<string> lcs = Directory.GetFiles(FolSet, "*.*esigner.cs", SearchOption.TopDirectoryOnly).ToList<string>();
                List<FileClass> _lcs = new List<FileClass>();
               // List<FileReplace> frp = new List<FileReplace>();
                if (lcs.Count > 0)
                {
                    //set file form
                    
                    lcs.ForEach(f_Designer =>
                    {
                                string ClassName, ClassType, file_cs, code = "";
                                string f_Form = f_Designer.ToLower().Replace(".designer.cs", ".cs");
                        if (File.Exists(f_Form))
                        {
                            using (FileClass reader = new FileClass(f_Form))
                            {

                                ClassName = new Regex(@".*?partial class(.*?):.*?", RegexOptions.None).Matches(reader.code)[0].Groups[1].Value.Trim();
                                try
                                { ClassType = new Regex(@"class.*?:\s{0,}(.*?)[\n\s]{1,}", RegexOptions.None).Matches(reader.code)[0].Groups[1].Value.Trim().Replace(" ", "_"); }
                                catch { ClassType = ""; }


                               
                                    using (FileClass r = new FileClass(f_Designer))
                                    {
                                        r.code = new Regex(@"(namespace.*?[\n\s{]{2,}partial class.*?[\s\n{]{3,})", RegexOptions.None).Replace(r.code, "");
                                        code = r.code;
                                        r.Dispose();
                                    }

                                reader.code = (reader.code.Trim().TrimEnd('}').Trim().TrimEnd('}') + "\n\n" + code);
                                file_cs = FilePath.RenameFileDup(Program.folForms + @"\" + (Path.GetFileName(Path.GetDirectoryName(f_Form)).Replace(" ", "_") + "_" + ClassName).Replace(" ", "_").Replace(",", "_") + ".cs");
                                reader.code = reader.code.Replace(ClassName, Path.GetFileNameWithoutExtension(file_cs));

                                reader.code = new Regex(@"(namespace.*?[\n\s]{0,}\{[\n\s]{0,}public\s{1,}partial class.*?:.*?[\n\s]{0,}\{)", RegexOptions.None)
                            .Replace(reader.code, " \n\nnamespace Test_WinApp.WinApp_csharphelper.Forms \n    {\n     public partial class "
                            + Path.GetFileNameWithoutExtension(file_cs) + ":" + ClassType
                            + Environment.NewLine +
                            "  { \n\n"
                            );

                                
                                foreach (Match myMatch in new Regex(@"(global::.*?\.Properties\.Resources)\.(.*?)[\s;]{1,}", RegexOptions.None).Matches(reader.code))
                                {
                                    string _cri = myMatch.Groups[2].Value;
                                    reader.code = reader.code.Replace(myMatch.Groups[1].Value + myMatch.Groups[2].Value, "Properties.Resources."+ myMatch.Groups[2].Value.ToLower());
                                }

                                //  reader.code = new Regex(@"(global::.*?.Properties.Resources.)", RegexOptions.None).Replace(reader.code, "Properties.Resources.");
                                reader.SaveAs(file_cs);
                                _lcs.Add(new FileClass(file_cs));
                               // frp.Add(new FileReplace(ClassName, Path.GetFileNameWithoutExtension(file_cs)));
                                reader.Dispose();


                            }
                            try
                            {
                                File.Delete(f_Form); 
                                File.Delete(f_Designer); 
                                File.Delete(f_Designer.ToLower().Replace(".designer.cs", ".resx"));
                                
                            }
                            catch { }


                        }
                                
                     
                       


                    });
                        
                        
                    //delete file
                        
                        try
                        {
                            if (Directory.Exists(FolSet))
                            {
                                Directory.GetDirectories(FolSet ,"*",SearchOption.TopDirectoryOnly).ToList<string>()
                                    .ForEach(fl=> { try { Directory.Delete(fl, true); } catch { } });

                            var fffs = (from fff in Directory.GetFiles(FolSet, "*", SearchOption.AllDirectories)
                                        where Path.GetFileName(fff).Contains("csproj")
                                        || Path.GetFileName(fff).Contains("Program")
                                        || Path.GetExtension(fff) == ".sln"
                                        || Path.GetExtension(fff) == ".suo"
                                        || Path.GetFileName(fff) == Path.GetFileName(Path.GetDirectoryName(fff)) + ".png"
                                        || Path.GetFileName(fff) == Path.GetFileName(Path.GetDirectoryName(fff)) + "1.png"
                                        || Path.GetFileName(fff) == Path.GetFileName(Path.GetDirectoryName(fff)) + "2.png"
                                        || Path.GetFileName(fff) == Path.GetFileName(Path.GetDirectoryName(fff)) + "3.png"
                                        || Path.GetFileName(fff) == Path.GetFileName(Path.GetDirectoryName(fff)) + "4.png"
                                        select fff)
                                .ToList<string>();
                                if(fffs.Count >0)
                                fffs.ForEach(__f => { try { File.Delete(__f); } catch { }});

                            }
                         
                        }
                        catch { }
                    // set file .cs 
                        if (Directory.Exists(FolSet))
                        { 
                              var fcs_ = Directory.GetFiles(FolSet, "*.cs", SearchOption.TopDirectoryOnly).ToList<string>();
                            if (fcs_ != null )
                            {
                                if (fcs_.Count > 0)
                                {
                                    if (_lcs.Count > 0)
                                    {
                                    _lcs.ForEach(r =>
                                    {
                                        
                                            r.AddUsing("using "+Path.GetFileName(FolSet).Replace(" ", "_") + ";");
                                            r.Save();
                                            r.Dispose();
                                        

                                    });

                                    }
                                string _using = "";
                                string _code = "";
                                try
                                {
                                     fcs_.ForEach(_fcs =>
                                                     {
                                                         using (FileClass reader = new FileClass(_fcs))
                                                         {
                                                             // reader.code = new Regex(@"(namespace .*?)", RegexOptions.None) .Replace(reader.code, "namespace  " + Path.GetFileName(FolSet).Replace(" ","_"));
                                                
                                                             foreach (Match myMatch in new Regex(@"(using.*?;)", RegexOptions.None).Matches(reader.code))
                                                             {
                                                                 if (!_using.Contains(myMatch.Groups[1].Value))
                                                                     _using += "\n" + myMatch.Groups[1].Value;
                                                             }
                                                             _code += new Regex(@"(namespace[\n\s\w\._]{0,}){", RegexOptions.None).Replace(reader.code, "").Trim().TrimEnd('}') + "\n\n";
                                                             reader.Dispose();
                                                         }
                                                         //  File.Move(_fcs, TorServices.FilePath.RenameFileDup(FolSet + "\\" + Path.GetFileNameWithoutExtension(_fcs) + "_" + Path.GetFileName(FolSet) + ".cs"));

                                                         File.Delete(_fcs);
                                                     });

                                    _code = new Regex(@"(using.*?;)", RegexOptions.None).Replace(_code, "").Trim();
                                    System.Threading.Thread.Sleep(1000);
                                            using (FileClass reader = new FileClass(folAppClass + "\\" +  "Class_" + Path.GetFileName(FolSet) + ".cs"))
                                            {
                                                reader.code = _using + "\n\n  namespace  " + Path.GetFileName(FolSet).Replace(" ", "_") + "\n\n { \n\n" + _code + "\n\n}";
                                               /*frp.ForEach(cri =>
                                                {
                                                    reader.code = reader.code.Replace(cri.oldString, cri.newString);
                                                });*/
                                                reader.Save();
                                                reader.Dispose();

                                            }

                                }
                                catch { }
                                  
                                }
                   
                            }                      
                        }



                  

               }


            }

        }
        private static void SetWinForm()
        {
            Directory.CreateDirectory(Program.folForms);
            Directory.CreateDirectory(Program.folWinApp);
            Directory.CreateDirectory(Program.folAppClass);
            //Create scheduler from MSDN example and specify max tasks
            LimitedConcurrencyLevelTaskScheduler scheduler = new LimitedConcurrencyLevelTaskScheduler(10);
            var factory = new TaskFactory(scheduler);

            //Optionally set up a cancellation token
            //Do the work
            var tasks = new List<Task>();
            foreach (var f in Directory.GetFiles(Program.folCode, "Program.cs", SearchOption.AllDirectories).ToList<string>())
               tasks.Add(factory.StartNew(() => Set_File_WinApp(f)));

            //Wait for the work to complete
            Task.WaitAll(tasks.ToArray());


        }

        private static void SetWinWPF()
        {
            Directory.CreateDirectory(Program.folWinWPF);
            Directory.CreateDirectory(Program.folWindows);
            Directory.CreateDirectory(Program.folWPFClass);
            Directory.GetFiles(Program.folCode, "App.xaml.cs", SearchOption.AllDirectories).ToList<string>()
              .ForEach(_f =>
              {
                  string folS = Path.GetDirectoryName(_f);
                  //check file xaml in fol_target
                  var files_xaml = (from wn in Directory.GetFiles(folS, "*.xaml.cs", SearchOption.TopDirectoryOnly)
                                    where Path.GetFileName(wn) != "App.xaml.cs"
                                    select wn).ToList<string>();
                  // ถ้า == 1 ก็ลาก ไปลงใน folWindows ได้เลย
                  files_xaml.ForEach(ff =>
                  {
                      string f_xaml_cs = ff;
                      string f_xaml = ff.Replace("xaml.cs", "xaml");
                      string _namespace;
                      string filename;

                      using (FileClass reader = new FileClass(f_xaml_cs))
                      {
                          _namespace = new Regex(@"namespace(.*?)\n", RegexOptions.None).Matches(reader.code)[0].Groups[1].Value.Trim();
                          filename = _namespace + "_" + Path.GetFileNameWithoutExtension(f_xaml);
                          reader.code = reader.code.Replace(Path.GetFileNameWithoutExtension(f_xaml), filename).Replace("using howto_", "//using howto_");
                          reader.code = new Regex(@"namespace(.*?)\n", RegexOptions.None).Replace(reader.code, " \n\nnamespace wpf_csharphelper.Windows \n\n");


                          reader.SaveAs(Program.folWindows + "\\" + filename + ".xaml.cs");
                          reader.Dispose();

                      }
                      using (FileClass reader = new FileClass(f_xaml))
                      {

                          reader.code = reader.code.Replace(Path.GetFileNameWithoutExtension(f_xaml), filename).Replace(_namespace + ".", "wpf_csharphelper.Windows.");
                          reader.SaveAs(Program.folWindows + "\\" + filename + ".xaml");
                          reader.Dispose();

                      }
                      try
                      {
                          File.Delete(f_xaml_cs); File.Delete(f_xaml);
                      }
                      catch { }
                     

                  });
                  try {
                      Directory.GetDirectories(folS, "*", SearchOption.TopDirectoryOnly).ToList<string>()
                                    .ForEach(fl => Directory.Delete(fl, true));
                  }
                  catch { }

                  (from fff in Directory.GetFiles(folS, "*", SearchOption.AllDirectories)
                   where Path.GetFileNameWithoutExtension(fff).Contains("App")
                   || Path.GetFileName(fff).Contains("csproj")
                   || Path.GetExtension(fff) == ".sln"
                   || Path.GetExtension(fff) == ".suo"
                   || Path.GetFileName(fff) == Path.GetFileName(Path.GetDirectoryName(fff)) + ".png"
                   || Path.GetFileName(fff) == Path.GetFileName(Path.GetDirectoryName(fff)) + "1.png"
                                 || Path.GetFileName(fff) == Path.GetFileName(Path.GetDirectoryName(fff)) + "2.png"
                                 || Path.GetFileName(fff) == Path.GetFileName(Path.GetDirectoryName(fff)) + "3.png"
                                 || Path.GetFileName(fff) == Path.GetFileName(Path.GetDirectoryName(fff)) + "4.png"
                   select fff)
                  .ToList<string>()
                  .ForEach(__f =>
                  {
                      try { File.Delete(__f); } catch { }
                  });
                  if (Directory.Exists(folS))
                  {
                      var fcs_ = Directory.GetFiles(folS, "*.cs", SearchOption.TopDirectoryOnly).ToList<string>();
                      if (fcs_ != null)
                      {
                          if (fcs_.Count > 0)
                          {
                              fcs_.ForEach(_fcs =>
                              {
                                  using (FileClass reader = new FileClass(_fcs))
                                  {
                                      try
                                      {
                                          reader.code = new Regex(@"(namespace .*?)", RegexOptions.None).Replace(reader.code, "namespace  " + Path.GetFileName(folS).Replace(" ", "_"));
                                      }
                                      catch { }
                                  }


                                  File.Move(_fcs, TorServices.FilePath.RenameFileDup(folWPFClass + "\\" + Path.GetFileNameWithoutExtension(_fcs) + "_" + Path.GetFileName(folS) + ".cs"));

                              });
                          }

                      }
                  }
              });



        }
        /*
        private static void Test_3()
        {
         Task t = Task.Run(() =>
            {

                #region 1. delete File  .sln .suo .png
                List<Task> tasks = new List<Task>();
               // this.Invoke(new Action(() => this.Text = "1. delete File  .sln .suo .png"));
                // tasks.Add(Task.Run(() => Directory.GetFiles(Program.folCode, "*.sln", SearchOption.AllDirectories).ToList<string>().ForEach(f => File.Delete(f))));
                // tasks.Add(Task.Run(() => Directory.GetFiles(Program.folCode, "*.suo", SearchOption.AllDirectories).ToList<string>().ForEach(f => File.Delete(f))));

                tasks.Add(Task.Run(() => (from file in Directory.GetFiles(Program.folCode, "*.png", SearchOption.AllDirectories)
                                          where Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file)) ||
                                          Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file)) + "1" ||
                                          Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file)) + "2" ||
                                          Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file)) + "3" ||
                                          Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file)) + "4" ||
                                          Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file)) + "5" ||
                                          Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file))
                                          select file)
                                            .ToList<string>().ForEach(f => File.Delete(f))));

                Task.WaitAll(tasks.ToArray());
                // this.Invoke(new Action(() => this.Text = "delete File  .sln .suo .png  Complete..."));

                MessageBox.Show("delete File.sln.suo.png  Complete...");
                #endregion
                #region 2. Change .sln .csproj File

               // this.Invoke(new Action(() => this.Text = "Change .sln .csproj File"));
                tasks = new List<Task>();
                tasks.Add(Task.Run(() => Directory.GetFiles(Program.folCode, "*.sln", SearchOption.AllDirectories).ToList<string>()
                .ForEach(f => {

                   // label1.Invoke(new Action(() => label1.Text = "Change File sln:" + f));
                    using (FileClass reader = new FileClass(f))
                    {

                        reader.code = new Regex(@"(Format Version .*?)\n", RegexOptions.None).Replace(reader.code, "Format Version 12.00\nVisualStudioVersion = 16.0.30011.22\nMinimumVisualStudioVersion = 10.0.40219.1\n");
                        reader.code = new Regex(@"(<Project ToolsVersion=\"".*?\"")", RegexOptions.None).Replace(reader.code, "<Project ToolsVersion=\"15.0\"");
                        reader.Save();
                        reader.Dispose();

                    }



                })));

                tasks.Add(Task.Run(() => Directory.GetFiles(Program.folCode, "*.csproj", SearchOption.AllDirectories).ToList<string>()
                .ForEach(f => {

                   // label1.Invoke(new Action(() => label1.Text = "Change File csproj:" + f));
                    using (FileClass reader = new FileClass(f))
                    {
                        reader.code = new Regex(@"<TargetFrameworkVersion>.*?</TargetFrameworkVersion>", RegexOptions.None).Replace(reader.code, "<TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>");
                        reader.code = new Regex(@"(<Project ToolsVersion=.*? DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">)",
                            RegexOptions.None).Replace(reader.code, @"<Project ToolsVersion=""Current"" DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">");


                        reader.Save();
                        reader.Dispose();
                    }

                })));
                tasks.Add(Task.Run(() => Directory.GetFiles(Program.folCode, "*.Designer.cs", SearchOption.AllDirectories).ToList<string>()
                     .ForEach(fds =>
                     {
                         string f_Form = fds.ToLower().Replace(".designer.cs", ".cs");
                         string f_Designer = fds;
                         string f_resx = fds.ToLower().Replace(".designer.cs", ".resx");
                         //  string file_cs = "";
                         if (File.Exists(f_Form) && File.Exists(f_Designer))
                         {
                             string fol = Path.GetDirectoryName(f_Form); ;
                             string code_Designer, ClassName, ClassType, code;

                             using (FileClass reader = new FileClass(f_Form))
                             {

                                 ClassName = new Regex(@".*?partial class(.*?):.*?", RegexOptions.None).Matches(reader.code)[0].Groups[1].Value.Trim();
                                 try
                                 { ClassType = new Regex(@"public partial class.*?:(.*?)[\n\s]{1,}{", RegexOptions.None).Matches(reader.code)[0].Groups[1].Value.Trim().Replace(" ", "_"); }
                                 catch { ClassType = ""; }

                                 code = reader.code;


                                 reader.Dispose();

                             }
                             if (ClassType.Trim() == "Form")
                             {
                                 using (StreamReader reader = new StreamReader(f_Designer))
                                 {
                                     code_Designer = reader.ReadToEnd();
                                     code_Designer = new Regex(@"(namespace.*?[\n\s{]{2,}partial class.*?[\s\n{]{3,})", RegexOptions.None).Replace(code_Designer, "");
                                     reader.Dispose();
                                     reader.Close();
                                 }
                                 code = (code.Trim().TrimEnd('}').Trim().TrimEnd('}') + "\n\n" + code_Designer);
                                 using (StreamWriter writer = new StreamWriter(f_Form))
                                 {
                                     writer.Write(code);
                                     System.Threading.Thread.Sleep(200);
                                 }


                                 try
                                 {
                                     File.Delete(f_Designer); File.Delete(f_resx);
                                 }
                                 catch { }

                             }



                         }
                        // label1.Invoke(new Action(() => label1.Text = "Set Form/Control and Set All File \n in \n" + fds + "\n Complete.."));
                     })));

                Task.WaitAll(tasks.ToArray());
                // this.Invoke(new Action(() => this.Text = "Change .sln .csproj File  Complete..."));
                MessageBox.Show("Change .sln .csproj File  Complete...");
                #endregion

                Directory.Move(@"D:\2020-05-27\2020-05-27\algs2e_csharp\algs2e_csharp", @"D:\2020-05-27\algs2e_csharp");
                Directory.Move(@"D:\2020-05-27\2020-05-27\wpf3dsrc\Wpf3dSrc", @"D:\2020-05-27\Wpf3dSrc");
                Directory.Move(@"D:\2020-05-27\2020-05-27\top100src\Src", @"D:\2020-05-27\top100src");

                System.Threading.Thread.Sleep(1000);

                #region 3. Set Form/Control and Set All File
                Directory.CreateDirectory(Program.folForms);
                Directory.CreateDirectory(Program.folAppClass);
                Directory.CreateDirectory(Program.folWinApp);
                Directory.CreateDirectory(Program.folWinWPF);
               // this.Invoke(new Action(() => this.Text = "Move WinApp/WPF"));
                tasks = new List<Task>();

                tasks.Add(Task.Run(() => Directory.GetFiles(Program.folCode, "Program.cs", SearchOption.AllDirectories).ToList<string>()
                   .ForEach(f =>
                   {
                       string FolSet = Path.GetDirectoryName(f);
                       if (Directory.Exists(FolSet))
                       {

                            // Set Class
                            List<string> lcs = (from file in Directory.GetFiles(FolSet, "*.cs", SearchOption.TopDirectoryOnly)
                                               where Path.GetFileName(file) != "Program.cs"
                                               select file).ToList<string>();
                           if (lcs.Count == 1)
                           {
                               string fcs = lcs[0];

                               string code_cs, file_cs, ClassName, ClassType;

                               using (StreamReader reader = new StreamReader(fcs))
                               {
                                   code_cs = reader.ReadToEnd();
                                   ClassName = new Regex(@".*?partial class(.*?):.*?", RegexOptions.None).Matches(code_cs)[0].Groups[1].Value.Trim();
                                   try
                                   { ClassType = new Regex(@"public partial class.*?:(.*?)[\n\s]{1,}{", RegexOptions.None).Matches(code_cs)[0].Groups[1].Value.Trim().Replace(" ", "_"); }
                                   catch { ClassType = ""; }

                                   file_cs = FilePath.RenameFileDup(Program.folForms + @"\" + (Path.GetFileName(Path.GetDirectoryName(fcs)).Replace(" ", "_") + "_" + ClassName).Replace(" ", "_").Replace(",", "_") + ".cs");
                                   code_cs = code_cs.Replace(ClassName, Path.GetFileNameWithoutExtension(file_cs));

                                   code_cs = new Regex(@"(namespace.*?[\n\s]{0,}\{[\n\s]{0,}public\s{1,}partial class.*?:.*?[\n\s]{0,}\{)", RegexOptions.None)
                               .Replace(code_cs, " \n\nnamespace csharphelper.Forms_Cs \n    {\n     public partial class "
                               + Path.GetFileNameWithoutExtension(file_cs) + ":" + ClassType
                               + Environment.NewLine +
                               "  { \n\n"
                               );

                                   code_cs = new Regex(@"(global::.*?.Properties.Resources.)", RegexOptions.None).Replace(code_cs, "Properties.Resources.");
                                   reader.Dispose();
                                   reader.Close();
                               }

                               using (StreamWriter writer = new StreamWriter(File.Create(file_cs)))
                               {
                                   writer.Write(code_cs);
                                   System.Threading.Thread.Sleep(500);
                               }



                               TorServices.FilePath.DeleteDirectory(FolSet);
                           }

                           else
                           {
                               Directory.Move(Path.GetDirectoryName(f), FilePath.RenameDirDup(Program.folWinApp + "\\" + Path.GetFileName(Path.GetDirectoryName(f))));
                           }
                       }



                      // label1.Invoke(new Action(() => label1.Text = "Move:" + Path.GetDirectoryName(f) + "\n to:" + Program.folWinApp + "\\" + Path.GetFileName(Path.GetDirectoryName(f))));

                   })));
                tasks.Add(Task.Run(() => Directory.GetFiles(Program.folCode, "App.xaml.cs", SearchOption.AllDirectories).ToList<string>()
                  .ForEach(_f =>
                  {

                  string f = FilePath.RenameDirDup(Program.folWinWPF + "\\" + Path.GetFileName(Path.GetDirectoryName(_f)));
                      if (Directory.Exists(Path.GetDirectoryName(_f)))
                          Directory.Move(Path.GetDirectoryName(_f), f);

                      string F_cs, f_xaml, fol, file;
                      F_cs = f;
                      fol = Path.GetDirectoryName(f);
                      file = Path.GetFileName(fol).Replace(" ", "") + "Window1";
                      File.Move(F_cs, fol + "\\" + file + ".xaml.cs");
                      F_cs = fol + "\\" + file + ".xaml.cs";

                      using (FileClass reader = new FileClass(F_cs))
                      {

                          reader.code = reader.code.Replace("Window1", file);
                          reader.Save();
                          reader.Dispose();

                      }



                      f_xaml = f.Replace(".xaml.cs", ".xaml");

                      File.Move(f_xaml, fol + "\\" + file + ".xaml");
                      f_xaml = fol + "\\" + file + ".xaml";

                      using (FileClass reader = new FileClass(f_xaml))
                      {
                          reader.code = reader.code.Replace("Window1", file);
                          reader.Save();
                          reader.Dispose();

                      }



                      string f_sln;
                      f_sln = Directory.GetFiles(fol, "*.sln", SearchOption.TopDirectoryOnly)[0];
                      using (FileClass reader = new FileClass(f_sln))
                      {
                          reader.code = reader.code.Replace("Window1", file);
                          reader.Save();
                          reader.Dispose();

                      }



                      string f_csproj;
                      f_csproj = Directory.GetFiles(fol, "*.csproj", SearchOption.TopDirectoryOnly)[0];
                      using (FileClass reader = new FileClass(f_csproj))
                      {
                          reader.code = reader.code.Replace("Window1", file);
                          reader.Save();
                          reader.Dispose();

                      }

                      // label1.Invoke(new Action(() => label1.Text = "Move:" + Path.GetDirectoryName(f) + "\n to:" + Program.folWinWPF + "\\" + Path.GetFileName(Path.GetDirectoryName(f))));

                  })));

                Task.WaitAll(tasks.ToArray());

                TorServices.FilePath.DelEmptyFolder(Program.folCode);
                // this.Invoke(new Action(() => this.Text = "Move WinApp/WPF  Complete..."));

                // label1.Invoke(new Action(() => label1.Text = "Move WinApp/WPF  Complete..."));

                MessageBox.Show("Move WinApp/WPF  Complete...");
                #endregion

                MessageBox.Show("Complete");
            });
            t.Wait();
        }
        private static void Test_2()
        {
            

                Directory.GetFiles(Program.folWinWPF, "Window1.xaml.cs", SearchOption.AllDirectories)
                            .ToList<string>().ForEach(f =>
                            {

                                string F_cs, f_xaml, fol,file;
                                F_cs = f;
                                fol = Path.GetDirectoryName(f);
                                file = Path.GetFileName(fol).Replace(" ", "") + "Window1";
                                File.Move(F_cs, fol + "\\" + file + ".xaml.cs");
                                F_cs = fol + "\\" + file + ".xaml.cs";

                                using (FileClass reader = new  FileClass(F_cs))
                                {
                                    
                                    reader.code = reader.code.Replace("Window1", file);
                                    reader.Save();
                                    reader.Dispose();

                                }



                                f_xaml = f.Replace(".xaml.cs",".xaml");

                                File.Move(f_xaml, fol + "\\" + file+".xaml");
                                f_xaml = fol + "\\" + file+".xaml";

                                using (FileClass reader = new FileClass(f_xaml))
                                {
                                    reader.code = reader.code.Replace("Window1", file);
                                    reader.Save();
                                    reader.Dispose();

                                }



                                string f_sln;
                                f_sln = Directory.GetFiles(fol, "*.sln", SearchOption.TopDirectoryOnly)[0];
                                using (FileClass reader = new FileClass(f_sln))
                                {
                                    reader.code = reader.code.Replace("Window1", file);
                                    reader.Save();
                                    reader.Dispose();

                                }



                                string  f_csproj;
                                f_csproj = Directory.GetFiles(fol, "*.csproj", SearchOption.TopDirectoryOnly)[0];
                                using (FileClass reader = new FileClass(f_csproj))
                                {
                                    reader.code = reader.code.Replace("Window1", file);
                                    reader.Save();
                                    reader.Dispose();

                                }


                            });
         

        }

        private static void Test_1()
        {
            Task.Run(() =>
               {

                #region 1. delete File  .sln .suo .png
                List<Task> tasks = new List<Task>();
                 // // this.Invoke(new Action(() => this.Text = "1. delete File  .sln .suo .png"));
                   tasks.Add(Task.Run(() => (from file in Directory.GetFiles(Program.folCode, "*.png", SearchOption.AllDirectories)
                                             where Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file)) ||
                                             Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file)) + "1" ||
                                             Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file)) + "2" ||
                                             Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file)) + "3" ||
                                             Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file)) + "4" ||
                                             Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file)) + "5" ||
                                             Path.GetFileNameWithoutExtension(file) == Path.GetFileName(Path.GetDirectoryName(file))
                                             select file)
                                               .ToList<string>().ForEach(f => File.Delete(f))));

                   Task.WaitAll(tasks.ToArray());
                 // // this.Invoke(new Action(() => this.Text = "delete File  .sln .suo .png  Complete..."));

                #endregion
                #region 2. Change .sln .csproj File

               //// this.Invoke(new Action(() => this.Text = "Change .sln .csproj File"));
                   tasks = new List<Task>();
                   tasks.Add(Task.Run(() => Directory.GetFiles(Program.folCode, "*.sln", SearchOption.AllDirectories).ToList<string>()
                   .ForEach(f =>
                   {
                       string code_sln;
                    //  // this.Invoke(new Action(() => this.Text = "Change File sln:" + f));
                       using (StreamReader reader = new StreamReader(f))
                       {
                           code_sln = reader.ReadToEnd();

                           reader.Dispose();
                           reader.Close();
                       }
                       code_sln = new Regex(@"(Format Version .*?)\n", RegexOptions.None).Replace(code_sln, "Format Version 12.00\nVisualStudioVersion = 16.0.30011.22\nMinimumVisualStudioVersion = 10.0.40219.1\n");
                       code_sln = new Regex(@"(<Project ToolsVersion=\"".*?\"")", RegexOptions.None).Replace(code_sln, "<Project ToolsVersion=\"15.0\"");
                       using (StreamWriter writer = new StreamWriter(f))
                       {
                           writer.Write(code_sln);
                           System.Threading.Thread.Sleep(500);
                       }

                   })));
                   tasks.Add(Task.Run(() => Directory.GetFiles(Program.folCode, "*.csproj", SearchOption.AllDirectories).ToList<string>()
                   .ForEach(f =>
                   {
                       string code_csproj;
                      //// this.Invoke(new Action(() => this.Text = "Change File csproj:" + f));
                       using (StreamReader reader = new StreamReader(f))
                       {
                           code_csproj = reader.ReadToEnd();
                           reader.Dispose();
                           reader.Close();
                       }
                       code_csproj = new Regex(@"<TargetFrameworkVersion>.*?</TargetFrameworkVersion>", RegexOptions.None).Replace(code_csproj, "<TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>");
                       code_csproj = new Regex(@"(<Project ToolsVersion=\"".*?\"")", RegexOptions.None).Replace(code_csproj, "<Project ToolsVersion=\"15.0\"");
                       using (StreamWriter writer = new StreamWriter(f))
                       {
                           writer.Write(code_csproj);
                           System.Threading.Thread.Sleep(500);
                       }
                   })));
                   tasks.Add(Task.Run(() => Directory.GetFiles(Program.folCode, "*.Designer.cs", SearchOption.AllDirectories).ToList<string>()
                        .ForEach(fds =>
                        {
                            string f_Form = fds.ToLower().Replace(".designer.cs", ".cs");
                            string f_Designer = fds;
                            string f_resx = fds.ToLower().Replace(".designer.cs", ".resx");
                         //  string file_cs = "";
                         if (File.Exists(f_Form) && File.Exists(f_Designer))
                            {
                                string fol = Path.GetDirectoryName(f_Form); ;
                                string code_Designer, code_Form1, ClassName, ClassType, code;

                                using (StreamReader reader = new StreamReader(f_Form))
                                {
                                    code_Form1 = reader.ReadToEnd().Trim();
                                    ClassName = new Regex(@".*?partial class(.*?):.*?", RegexOptions.None).Matches(code_Form1)[0].Groups[1].Value.Trim();
                                    try
                                    { ClassType = new Regex(@"public partial class.*?:(.*?)[\n\s]{1,}{", RegexOptions.None).Matches(code_Form1)[0].Groups[1].Value.Trim().Replace(" ", "_"); }
                                    catch { ClassType = ""; }

                                    reader.Dispose();
                                    reader.Close();
                                }
                                if (ClassType.Trim() == "Form")
                                {
                                    using (StreamReader reader = new StreamReader(f_Designer))
                                    {
                                        code_Designer = reader.ReadToEnd();
                                        code_Designer = new Regex(@"(namespace.*?[\n\s{]{2,}partial class.*?[\s\n{]{3,})", RegexOptions.None).Replace(code_Designer, "");
                                        reader.Dispose();
                                        reader.Close();
                                    }
                                    code = (code_Form1.Trim().TrimEnd('}').Trim().TrimEnd('}') + "\n\n" + code_Designer);
                                    using (StreamWriter writer = new StreamWriter(f_Form))
                                    {
                                        writer.Write(code);
                                        System.Threading.Thread.Sleep(200);
                                    }


                                    try
                                    {
                                        File.Delete(f_Designer); File.Delete(f_resx);
                                    }
                                    catch { }

                                    string f_csproj = "";
                                    try
                                    {
                                        f_csproj = Directory.GetFiles(Path.GetDirectoryName(f_Form), "*.csproj", SearchOption.TopDirectoryOnly)[0];

                                    }
                                    catch { }
                                    if (File.Exists(f_csproj))
                                    {
                                        string code_csproj;
                                        using (StreamReader reader = new StreamReader(f_csproj))
                                        {
                                            code_csproj = reader.ReadToEnd();
                                            code_csproj = new Regex(@"(<Compile Include=""" + ClassName + @"\.Designer.cs"">[\n\s{]{0,}<DependentUpon>" + ClassName + @"\.cs</DependentUpon>[\n\s{]{0,}</Compile>)", RegexOptions.None).Replace(code_csproj, "");
                                            code_csproj = new Regex(@"(<EmbeddedResource Include=""" + ClassName + @"\.resx"">[\n\s{]{0,}<DependentUpon>" + ClassName + @"\.cs</DependentUpon>[\n\s{]{0,}</EmbeddedResource>)", RegexOptions.None).Replace(code_csproj, "");
                                            reader.Dispose();
                                            reader.Close();
                                        }

                                        using (StreamWriter writer = new StreamWriter(f_csproj))

                                            writer.Write(code_csproj);
                                        System.Threading.Thread.Sleep(200);
                                    }


                                }





                            }
                            //this.Invoke(new Action(() => this.Text = "Set Form/Control and Set All File \n in \n" + fds + "\n Complete.."));
                        })));

                   Task.WaitAll(tasks.ToArray());
                  //// this.Invoke(new Action(() => this.Text = "Change .sln .csproj File  Complete..."));
                #endregion



            });



            


        }*/
    }
}
