using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharphelper.Class
{
    public class RandomNumber
    {
        //https://www.thaicreate.com/dotnet/forum/125604.html
        public int StartNumber { set; get; }
        public int EndNumber { set; get; }

        private List<int> Numbers;
        private Random r = new Random();

        private void InitNumber()
        {
            for (int i = StartNumber; i <= EndNumber; i++)
                this.Numbers.Add(i);
        }

        public void Start()
        {
            Reset();
            Numbers = new List<int>();
            InitNumber();
        }

        public void Reset()
        {
            this.Numbers.Clear();
        }

        public int NextNumber()
        {
            int randomIndex = r.Next(this.Numbers.Count);
            int number = this.Numbers[randomIndex];
            this.Numbers.RemoveAt(randomIndex);
            return number;
        }
    }
}
