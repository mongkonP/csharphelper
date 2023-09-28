
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_hashset_operators

 { 

public class Set<T> : HashSet<T>
    {
        // Constructors.
        public Set()
            : base()
        {
        }
        public Set(IEnumerable<T> enumerable)
            : base(enumerable)
        {
        }
        public Set(IEqualityComparer<T> comparer)
            : base(comparer)
        {
        }
        public Set(IEnumerable<T> enumerable, IEqualityComparer<T> comparer)
            : base(enumerable, comparer)
        {
        }

        // Union.
        public static Set<T> operator |(Set<T> A, Set<T> B)
        {
            Set<T> result = new Set<T>(A);
            result.UnionWith(B);
            return result;
        }

        // Intersection.
        public static Set<T> operator &(Set<T> A, Set<T> B)
        {
            Set<T> result = new Set<T>(A);
            result.IntersectWith(B);
            return result;
        }

        // Xor.
        public static Set<T> operator ^(Set<T> A, Set<T> B)
        {
            Set<T> result = new Set<T>(A);
            result.SymmetricExceptWith(B);
            return result;
        }

        // Subset.
        public static bool operator <(Set<T> A, Set<T> B)
        {
            return A.IsSubsetOf(B);
        }

        // Superset.
        public static bool operator >(Set<T> A, Set<T> B)
        {
            return A.IsSupersetOf(B);
        }

        // Contains element.
        public static bool operator >(Set<T> A, T element)
        {
            return A.Contains(element);
        }

        // Consists of a single element.
        public static bool operator <(Set<T> A, T element)
        {
            return (A > element) && (A.Count == 1);
        }
    }

}