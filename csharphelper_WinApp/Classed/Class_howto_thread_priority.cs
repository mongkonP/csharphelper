
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_thread_priority

 { 

// This class's Run method displays a count in the Output window.

    class Counter
    {
        // This counter's number.
        public string Name;

        // Initializing constructor.
        public Counter(string name)
        {
            Name = name;
        }

        // Count off 10 half second intervals in the Output window.
        public void Run()
        {
            for (int i = 1; i <= 10; i++)
            {
                // Display the next message.
                Console.WriteLine(Name + " " + i);

                // See when we should display the next message.
                DateTime next_time = DateTime.Now.AddSeconds(0.5);

                // Waste half a second. We don't sleep or call
                // DoEvents so we don't give up control of the CPU.
                while (DateTime.Now < next_time)
                {
                    // Wait a bit.
                }
            }
        }
    }

}