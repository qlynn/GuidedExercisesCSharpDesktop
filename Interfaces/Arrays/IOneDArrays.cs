using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Arrays
{
    public interface IOneDArrays
    {
        /// <summary>
        /// Calculate pairs of equal adjacent elements in the array
        /// Example: 
        ///     array is:   0, 0, 1, 2, 2, 2, 3
        ///     shall be returned:  3 (pairs)
        /// </summary>
        /// <param name="inputArray">input array. Should not be changed.</param>
        /// <returns>number of pairs of equal ajacent array elements. 0 if array doesn't exist</returns>
        int CalculateEqualPairs(int[] inputArray);
    }
}
