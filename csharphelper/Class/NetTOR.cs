using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TorServices
{
   public static class NetWorkTOR
    {

        public static  Task<string> getHTML(this string url)
        { 
            //
          return   Task.Run(() =>
            {
                string _url = url;
               string html = "";
                try
                {
                     System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(_url.Trim());
                    request.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko; Google Page Speed Insights) Chrome/27.0.1453 Safari/537.36";
                    System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                     System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());

                     html =  sr.ReadToEnd();
                     sr.Close();
                    response.Close();

                 

                }
                catch { }
                return html;
            });

        }

        public static Task<List<string>> GetLinkByURL(this string url, string pattern)
        {
     
            return Task.Run(() =>
            {
                List<string> lst = new List<string>();

                lst.AddRange(Regex.Matches(url.getHTML().Result, pattern)
                    .OfType<Match>()
                    .Select(m => m.Groups[1].Value)
                    .ToList<string>());

            return lst;
            });
        }

        public static Task<List<string>> GetLinkByString(this string str, string pattern)
        {

            return Task.Run(() =>
            {
                List<string> lst = new List<string>();

                /* lst.AddRange(Regex.Matches(str, pattern)
                     .OfType<Match>()
                     .Select(m => m.Groups[1].Value)
                     .ToList<string>());*/

                foreach (Match myMatch in Regex.Matches(str, pattern))
                {
                    lst.Add(myMatch.Groups[1].Value);
                }


                return lst;
            });
        }

        public static Task< string> GetValueByURL(this string url, string pattern)
        {
          
            return Task.Run(() =>
                {
                string _value;
                try
                {
                      
                    _value = new Regex(pattern, RegexOptions.None).Matches((string)url.getHTML().Result)[0].Groups[1].Value;
                }
                catch { _value = ""; }

                return _value;
                });
        }



        public static  void LoadByIDM(string link, string file)
        {
            Task.Run(() =>
            {
                string IDMpath = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\DownloadManager", "ExePath", true).ToString();
                System.Diagnostics.Process.Start(IDMpath, "/a /n /d " + link + "  /f \"" + TorServices.FilePath.FileName(file) + "\"");
                System.Threading.Thread.Sleep(1000);
            });

        }

        public static  void LoadByWebClient(string link, string file)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    webClient.DownloadFile(new Uri(link), file);
                    System.Threading.Thread.Sleep(100);
                }
                catch { }

            }
        }


        public static  void SaveFile(string html, string _file)
        {
            Task.Run(() =>
            {
                if (!System.IO.File.Exists(_file))
                {
                    int a = html.IndexOf("<div class=\"entry-content\">") + "<div class=\"entry-content\">".Length;
                    html = html.Substring(a, html.Length - a);
                    int b = html.IndexOf("<!-- .entry-content -->");// html.IndexOf("<div class=\"pvc_clear\"></div>");
                    html = html.Substring(0, b);
                    html = html.Replace("<p>", "").Replace("</p>", "").Replace("<br />", Environment.NewLine);
                    using (StreamWriter sw = File.CreateText(_file))
                    {
                        sw.Write(System.IO.Path.GetFileNameWithoutExtension(_file) + Environment.NewLine + Environment.NewLine + Environment.NewLine + html);
                    }

                    System.Threading.Thread.Sleep(4000);

                }

            });


        }

    }
}
