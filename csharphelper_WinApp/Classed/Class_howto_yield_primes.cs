
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

  namespace  howto_yield_primes

 { 

public class PrimeGenerator : IEnumerable<long>
    {
        // Return true if the value is prime.
        private bool IsOddPrime(long value)
        {
            long sqrt = (long)Math.Sqrt(value);
            for (long i = 3; i <= sqrt; i += 2)
                if (value % i == 0) return false;

            // If we get here, value is prime.
            return true;
        }

        public IEnumerator<long> GetEnumerator()
        {
            // Start with 2.
            yield return 2;

            // Generate odd primes.
            for (long i = 3; ; i += 2)
                if (IsOddPrime(i)) yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}