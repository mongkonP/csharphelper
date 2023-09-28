
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

  namespace  howto_process_tree

 { 

class ProcessInfo : IComparable<ProcessInfo>
    {
        public Process TheProcess;
        public ProcessInfo Parent;
        public List<ProcessInfo> Children = new List<ProcessInfo>();

        public ProcessInfo(Process the_process)
        {
            TheProcess = the_process;
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]",
                TheProcess.ProcessName, TheProcess.Id);
        }

        public int CompareTo(ProcessInfo other)
        {
            return TheProcess.ProcessName.CompareTo(
                other.TheProcess.ProcessName);
        }
    }

}