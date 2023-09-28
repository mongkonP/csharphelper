
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_complex_number_class2

 { 

class Complex
    {
        public double Re = 0, Im = 0;

        // Constructor using real and imaginary parts.
        public Complex(double real, double imaginary)
        {
            Re = real;
            Im = imaginary;
        }

        // Constructor using only a real part.
        public Complex(double real)
            : this(real, 0)
        {
        }

        // Parse a String of the form R + Ii.
        public static Complex Parse(string string_value)
        {
            // Remove spaces and the "i".
            string_value = string_value.Replace(" ", "");
            string_value = string_value.ToLower().Replace("i", "");

            // Find the + or - between the parts.
            char[] plus_or_minus = { '+', '-' };
            int pos = string_value.IndexOfAny(plus_or_minus);
            if (pos == 0)
            {
                // Skip the leading +/-.
                pos = string_value.IndexOfAny(plus_or_minus, 1);
            }

            // Get the real and imaginary parts.
            double re = double.Parse(string_value.Substring(0, pos));
            double im = double.Parse(string_value.Substring(pos));

            return new Complex(re, im);
        }

        // Return a string representation.
        public override string ToString()
        {
            if (Im < 0)
            {
                return Re.ToString() + " - " + Math.Abs(Im).ToString() + "i";
            }
            else
            {
                return Re.ToString() + " + " + Im.ToString() + "i";
            }
        }
        public string ToString(string format)
        {
            if (Im < 0)
            {
                return Re.ToString(format) + " - " + Math.Abs(Im).ToString(format) + "i";
            }
            else
            {
                return Re.ToString(format) + " + " + Im.ToString(format) + "i";
            }
        }

#region Complex op Complex Operators

        // Return -me.
        public static Complex operator -(Complex me)
        {
            return new Complex(-me.Re, -me.Im);
        }

        // Return A + B.
        public static Complex operator +(Complex A, Complex B)
        {
            return new Complex(A.Re + B.Re, A.Im + B.Im);
        }

        // Return A - B.
        public static Complex operator -(Complex A, Complex B)
        {
            return A + (-B);
        }

        // Return A * B.
        public static Complex operator *(Complex A, Complex B)
        {
            return new Complex(
                A.Re * B.Re - A.Im * B.Im,
                A.Re * B.Im + A.Im * B.Re);
        }

        // Return A / B.
        public static Complex operator /(Complex A, Complex B)
        {
            Complex conjugate = new Complex(B.Re, -B.Im);
            B *= conjugate;

            Complex numerator = A * conjugate;

            return new Complex(
                numerator.Re / B.Re,
                numerator.Im / B.Re);
        }

#endregion Complex op Complex Operators

#region Equality Operators

        // Return A == B.
        public static bool operator ==(Complex A, Complex B)
        {
            if (object.ReferenceEquals(A, null))
                return object.ReferenceEquals(B, null);
            if (object.ReferenceEquals(B, null)) return false;

            // Compare the field values.
            return ((A.Re == B.Re) && (A.Im == B.Im));
        }

        // Return A != B.
        public static bool operator !=(Complex A, Complex B)
        {
            return !(A == B);
        }

        // Return true if the objects contain the same values.
        public bool Equals(Complex B)
        {
            return this == B;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Complex);
        }

        // Return a hash code for this object.
        public override int GetHashCode()
        {
            return Re.GetHashCode() ^ Im.GetHashCode();
        }

#endregion Equality Operators

    }

}