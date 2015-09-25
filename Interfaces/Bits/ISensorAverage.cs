using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Bits
{
    public interface ISensorAverage
    {
        /// <summary>
        /// Calculates average of data from several sensors (up to 8).
        /// Format of 16-bit data item:
        ///     3 bits: code of sensor
        ///     12 bits: data of sensor
        ///     1 bit: checksum (if oddness of previous 15 bits - value is 1, else 0)
        ///  if checksum is failed, that piece of data should not be used for calculation.
        ///  
        /// Hint: Use BitVector32 for "parsed" data
        /// </summary>
        /// <param name="data">Array of sensor data</param>
        /// <returns>Array of pairs &lt;sensor code, average of data of this sensor&gt; </returns>
        Tuple<ushort, double>[] GetAverages(ushort[] data);
    }
}
