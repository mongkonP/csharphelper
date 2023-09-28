
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_complex_number_class4

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

        #region "Complex op Complex Operators"

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

        #endregion // Complex op Complex Operators

        #region "Equality Operators"

        // Return true if the objects contain the same values.
        public bool Equals(Complex B)
        {
            if ((object)B == null) return false;
            return ((this.Re == B.Re) && (this.Im == B.Im));
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Complex)) return false;
            return this.Equals(obj as Complex);
        }

        // Return A == B.
        public static bool operator ==(Complex A, Complex B)
        {
            // If both are null or the same object, return true.
            if (System.Object.ReferenceEquals(A, B)) return true;

            // If one is null but not the other, return false.
            if (((object)A == null) || ((object)B == null)) return false;

            // Compare the field values.
            return A.Equals(B);
        }

        // Return A != B.
        public static bool operator !=(Complex A, Complex B)
        {
            return !(A == B);
        }

        // Return a hash code for this object.
        public override int GetHashCode()
        {
            return (Re.GetHashCode() + Im).GetHashCode();
        }

        #endregion // Equality Operators

        // Double to Complex conversion.
        // The implicit keyword means you don't need an explicit cast.
        public static implicit operator Complex(double real)
        {
            return new Complex(real);
        }
    }

}