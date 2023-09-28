
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_stable_appointments

 { 

class Person
    {
        public const int DEFAULT_NUM_PEOPLE = 9;
        public const int NUM_CHOICES = 9;
        public const int NUM_PREFERENCES = 3;
        public const int DONT_WANT = 1000;
        public const int NO_ASSIGNMENT = 1001;

        public string Name;

        // This person's preferences.
        public int[] Preferences;

        // This person's assignment.
        public int Assignment;

        // Return a string representing the Person's assignment.
        public string AssignmentString()
        {
            return Name + " (" + Value + ")";
        }

        // Initialize the Person from a string containing a name and preferences.
        public Person(string txt)
        {
            string[] values = txt.Split(' ');
            Name = values[0];
            Preferences = new int[NUM_PREFERENCES];
            for (int i = 0; i < NUM_PREFERENCES; i++)
            {
                Preferences[i] = int.Parse(values[i + 1]);
            }

            Assignment = -1;
        }

        // Return this Person's assignment value.
        public int Value
        {
            get
            {
                if (Assignment < 0) return NO_ASSIGNMENT;
                return ValueOf(Assignment);
            }
        }

        // Return this person's value for the choice.
        // Return DONT_WANT if the person did not list this choice.
        public int ValueOf(int choice)
        {
            for (int i = 0; i < NUM_PREFERENCES; i++)
            {
                if (Preferences[i] == choice) return i;
            }

            return DONT_WANT;
        }
    }

}