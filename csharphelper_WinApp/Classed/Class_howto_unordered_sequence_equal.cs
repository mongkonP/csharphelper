
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_unordered_sequence_equal

 { 

public static class EnumerableExtensions
    {
        // Return true if the lists contain the
        // same elements, possibly in different orders.
        public static bool HashableSequenceEqual<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
        {
            // Order the items in each list.
            var ordered1 =
                from T item in list1
                orderby item.GetHashCode()
                select item;
            var ordered2 =
                from T item in list2
                orderby item.GetHashCode()
                select item;

            // Compare the lists.
            return ordered1.SequenceEqual(ordered2);
        }

        // Return true if the lists contain the
        // same elements, possibly in different orders.
        public static bool ComparableSequenceEqual<T>(
            this IEnumerable<T> list1, IEnumerable<T> list2)
            where T : IComparable<T>
        {
            // Order the items in each list.
            var ordered1 =
                from T item in list1
                orderby item
                select item;
            var ordered2 =
                from T item in list2
                orderby item
                select item;

            // Compare the lists.
            return ordered1.SequenceEqual(ordered2);
        }
    }








    public class Person : IEquatable<Person>, IComparable<Person>
    {
        public string FirstName, LastName;

        public Person(string first_name, string last_name)
        {
            FirstName = first_name;
            LastName = last_name;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        // IEquatable<Person>
        public bool Equals(Person other)
        {
            // If other is null, we're not equal.
            if (Object.ReferenceEquals(other, null)) return false;

            // If the references are the same, we are equal.
            if (Object.ReferenceEquals(this, other)) return true;

            // We're equal if the names are equal.
            return FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName);
        }

        // Override GetHashCode so we can order items by hash code.
        public override int GetHashCode()
        {
            int hash1 = FirstName.GetHashCode().GetHashCode();
            int hash2 = LastName.GetHashCode();
            return hash1 ^ hash2;
        }

        // IComparable.
        public int CompareTo(Person other)
        {
            // If other is not a Person, we come second.
            if (other == null) return 1;

            if (FirstName != other.FirstName)
            {
                // If we have no first name, we come first.
                if (FirstName == null) return -1;
                return FirstName.CompareTo(other.FirstName);
            }

            // If we have no last name, we come first.
            if (LastName == null) return -1;
            return LastName.CompareTo(other.LastName);
        }
    }

}