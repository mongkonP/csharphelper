
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_fraction_class

 { 

class Fraction
    {
        public long Numerator, Denominator;

        // Initialize the fraction from a string A/B.
        public Fraction(string txt)
        {
            string[] pieces = txt.Split('/');
            Numerator = long.Parse(pieces[0]);
            Denominator = long.Parse(pieces[1]);
            Simplify();
        }

        // Initialize the fraction from numerator and denominator.
        public Fraction(long numer, long denom)
        {
            Numerator = numer;
            Denominator = denom;
            Simplify();
        }

        // Return a * b.
        public static Fraction operator *(Fraction a, Fraction b)
        {
            // Swap numerators and denominators to simplify.
            Fraction result1 = new Fraction(a.Numerator, b.Denominator);
            Fraction result2 = new Fraction(b.Numerator, a.Denominator);

            return new Fraction(
                result1.Numerator * result2.Numerator,
                result1.Denominator * result2.Denominator);
        }

        // Return -a.
        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.Numerator, a.Denominator);
        }

        // Return a + b.
        public static Fraction operator +(Fraction a, Fraction b)
        {
            // Get the denominators' greatest common divisor.
            long gcd_ab = MathStuff.GCD(a.Denominator, b.Denominator);

            long numer =
                a.Numerator * (b.Denominator / gcd_ab) +
                b.Numerator * (a.Denominator / gcd_ab);
            long denom =
                a.Denominator * (b.Denominator / gcd_ab);
            return new Fraction(numer, denom);
        }

        // Return a - b.
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a + -b;
        }

        // Return a / b.
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return a * new Fraction(b.Denominator, b.Numerator);
        }

        // Simplify the fraction.
        private void Simplify()
        {
            // Simplify the sign.
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }

            // Factor out the greatest common divisor of the
            // numerator and the denominator.
            long gcd_ab = MathStuff.GCD(Numerator, Denominator);
            Numerator = Numerator / gcd_ab;
            Denominator = Denominator / gcd_ab;
        }

        // Convert a to a double.
        public static implicit operator double(Fraction a)
        {
            return (double)a.Numerator / a.Denominator;
        }

        // Return the fraction's value as a string.
        public override string ToString()
        {
            return Numerator.ToString() + "/" + Denominator.ToString();
        }
    }








    public class MathStuff
    {
        // Return the greatest common divisor (GCD) of a and b.
        public static long GCD(long a, long b)
        {
            // Make a >= b.
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a < b)
            {
                long tmp = a;
                a = b;
                b = tmp;
            }

            // Pull out remainders.
            for (;;)
            {
                long remainder = a % b;
                if (remainder == 0) return b;
                a = b;
                b = remainder;
            }
        }

        // Return the least common multiple of a and b.
        public static long LCM(long a, long b)
        {
            long gcd_ab = GCD(a, b);
            return ((a / gcd_ab) * (b / gcd_ab)) * gcd_ab;
        }
    }

}