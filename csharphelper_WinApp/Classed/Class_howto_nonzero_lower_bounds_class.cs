
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_nonzero_lower_bounds_class

 { 

class BoundsArray<T>
    {
        // A one-dimensional array holding the data.
        T[] Data;

        // The bounds.
        int NumDimensions;
        int[] LowerBound, Offset;

        // Constructor.
        public BoundsArray(params int[] bounds)
        {
            // Make sure there is an even number of bounds.
            if (bounds.Length % 2 == 1)
                throw new ArgumentException("Number of bounds must be even.", "bounds");

            // Make sure there are at least two bounds.
            if (bounds.Length < 2)
                throw new ArgumentException("There must be at least two bounds, one upper and one lower.", "bounds");

            // Get the bounds.
            NumDimensions = (int)(bounds.Length / 2);
            LowerBound = new int[NumDimensions];
            Offset = new int[NumDimensions];
            int total_size = 1;
            for (int i = NumDimensions - 1; i >= 0; i--)
            {
                Offset[i] = total_size;

                LowerBound[i] = bounds[2 * i];
                int upper_bound = bounds[2 * i + 1];
                int bound_size = upper_bound - LowerBound[i] + 1;
                total_size *= bound_size;
            }

            // Allocate room for all of the items.
            Data = new T[total_size];
        }

        // The indexer.
        public T this[params int[] indexes]
        {
            get
            {
                if (indexes.Length != NumDimensions)
                    throw new IndexOutOfRangeException(
                        "Number of indexes does not match number of dimensions");
                return Data[Index(indexes)];
            }
            set
            {
                if (indexes.Length != NumDimensions)
                    throw new IndexOutOfRangeException(
                        "Number of indexes does not match number of dimensions");
                Data[Index(indexes)] = value;
            }
        }

        // Calculate the index for a series of indexes.
        private int Index(params int[] indexes)
        {
            int total_offset = 0;
            for (int i = 0; i < indexes.Length; i++)
            {
                total_offset += (indexes[i] - LowerBound[i]) * Offset[i];
            }
            return total_offset;
        }
    }

}