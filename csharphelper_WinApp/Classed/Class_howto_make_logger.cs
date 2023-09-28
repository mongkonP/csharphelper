
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

  namespace  howto_make_logger

 { 

public static class Logger
    {
        // Calculate the log file's name.
        private static string LogFile =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
            "\\Log.txt";

        // Write the current date and time plus
        // a line of text into the log file.
        public static void WriteLine(string txt)
        {
            File.AppendAllText(LogFile,
                DateTime.Now.ToString() + ": " + txt + "\n");
        }

        // Delete the log file.
        public static void DeleteLog()
        {
            File.Delete(LogFile);
        }
    }

}