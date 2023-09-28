using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csharphelper.Class
{
    public class ProjectID
    {
        //https://www.thaicreate.com/dotnet/forum/125604.html

        private List<int> Numbers;
        private Random r = new Random();

        private void InitNumber()
        {
            for (int i = 0; i < 16; i++)
                this.Numbers.Add(i);
        }

        public ProjectID()
        {
            Numbers = new List<int>();
            InitNumber();
        }

        private int NextNumber()
        {
            Thread.Sleep(200);
            int randomIndex = r.Next(this.Numbers.Count);
            int number = this.Numbers[randomIndex];
            // this.Numbers.RemoveAt(randomIndex);
            return number;
        }

        public string ToHex()
        {
            string result = "";
            for (int index = 0; index < 36; index++)
                result += ((index == 8 || index == 13 || index == 18 || index == 23) ? "-" : NextNumber().ToString("X"));
            return "{" + result + "}";
        }
    }
}
