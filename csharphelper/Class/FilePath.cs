
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TorServices
{
  public static  class FilePath
    {

        public static void DeleteDirectory(this string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }
        public static  string createFolder( this string fol)
        {
            string _fol = fol;
            try
            {
                if (!System.IO.Directory.Exists(_fol))
                {
                    if (_fol.Length > 200)
                        _fol = _fol.Substring(0, 200);

                    System.IO.Directory.CreateDirectory(_fol); 
                }
               // _fol = fol;
            }
            catch { _fol = ""; }
            return _fol;
        }

        public static string getSizeFile(this double size)
        {

            string _size = "0 Byte";
            if (size < 1024d)
            {
                _size = size.ToString("N2") + " Byte";
            }
            else if (size >= 1024d && size < 1048576d)
            {
                _size = (size / 1024).ToString("N2") + " KB";
            }
            else if (size >= 1048576d && size < 1073741824d)
            {
                _size = (size / 1048576d).ToString("N2") + " MB";
            }
            else if (size >= 1073741824d && size < 1099511627776d)
            {
                _size = (size / 1073741824d).ToString("N2") + " GB";
            }
            else if (size >= 1099511627776d && size < 1125899906842624d)
            {
                _size = (size / 1099511627776d).ToString("N2") + " TB";
            }
            else if (size >= 1125899906842624d && size < 1152921504606846976d)
            {
                _size = (size / 1125899906842624d).ToString("N2") + " PB";
            }
            else if (size >= 1152921504606846976d)
            {
                _size = (size / 1152921504606846976d).ToString("N2") + " EB";
            }

            return _size;
        }
        public static string getSizeFile(this long size)
        {
            return Convert.ToDouble(size).getSizeFile();

        }
        public static string getSizeFile(this int size)
        {
            return Convert.ToDouble(size).getSizeFile();

        }
        public static string FileName(string file)
        {
            string _file= file;
            foreach (char c in "~\"#%&*:<>?/\\{|}.".ToCharArray())
            {
                _file = _file.Replace(c.ToString(), "");
            }

          //  _file = path.Replace("\"", "").Replace("|", "").Replace("?", "").Replace(":", "").Replace("*", "").Replace("<", "").Replace(">", "");
            //\ ? : * “ < > | 
            //~ " # % & * : < > ? / \ { | }.

            return _file;
        }
        public static long DirectorySize(string path)
        {
            long size = 0;
            foreach (FileInfo fi in new DirectoryInfo(path).GetFiles( "*", SearchOption.AllDirectories))
            {
                size += fi.Length;
            }
            return size;
        }
        public static void DelEmptyFolder(string fol)
        {
            if (!Directory.Exists(fol)) return;
            List<string> fols =  Directory.GetDirectories(fol, "*", SearchOption.TopDirectoryOnly).ToList<string>();
            if (fols.Count > 0)
            { 
                fols.ForEach(f =>
                 {
                     if (Directory.Exists(f))

                     { 
                              if (DirectorySize(f) <= 0)
                             { 
                               try { Directory.Delete(f, true); }
                             catch { }                   
                             }                    
                     
                     }


                 });
            }





        }
        public static void DelEmptyFile(string fol)
        {
            (from file in Directory.GetFiles(fol, "*", SearchOption.AllDirectories).ToList<string>()
             where (long)new IWshRuntimeLibrary.FileSystemObject().GetFile(file).Size <= 0
             select file).ToList<string>()
             .ForEach(f =>
               File.Delete(f)
             );
        }
        public static void DelFile(string fol ,String cri)
        {
            Directory.GetFiles(fol, "*"+cri+"*", SearchOption.AllDirectories).ToList<string>()
             .ForEach(f =>
               File.Delete(f)
             );
        }
        public static string RenameFileDup(string _File)
        {
            string stg = _File;
            if (System.IO.File.Exists(_File))
            {
                int i = 1;
                do
                {
                    stg = System.IO.Path.GetDirectoryName(_File) + "\\" + System.IO.Path.GetFileNameWithoutExtension(_File) + "_" + i + System.IO.Path.GetExtension(_File);
                    i++;
                } while (System.IO.File.Exists(stg));
            }
            return stg;
        }
        public static string RenameDirDup(string _Fol)
        {
            string stg = _Fol;
            if (System.IO.Directory.Exists(_Fol))
            {
                int i = 1;
                do
                {
                    stg = System.IO.Path.GetDirectoryName(_Fol) + "\\" + System.IO.Path.GetFileNameWithoutExtension(_Fol) + "_" + i ;
                    i++;
                } while (System.IO.File.Exists(stg));
            }
            return stg;
        }

        public static void SaveFileCode(string f, string code)
        {
            using (StreamWriter writer = !File.Exists(f) ? new StreamWriter(File.Create(f)) : new StreamWriter(f))
            {
                writer.Write(code);
                System.Threading.Thread.Sleep(200);
            }

        }
    }


}
