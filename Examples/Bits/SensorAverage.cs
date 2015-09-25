using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Bits
{
    public class SensorAverage : Interfaces.Bits.ISensorAverage
    {
        private class SensorData
        {
            public int Sum;
            public int Count;
        }

        private bool ChecksumOK(int checksum, int otherData)
        {
            int sumOfOne = 0;
            while (otherData > 0)
            {
                sumOfOne += otherData % 2;
                otherData /= 2;
            }
            return sumOfOne % 2 == checksum;
        }

        public Tuple<ushort, double>[] GetAverages(ushort[] data)
        {
            Dictionary<ushort, SensorData> sensors = new Dictionary<ushort, SensorData>();

            foreach (var d in data)
            {
                BitVector32 item = new BitVector32(d);
                BitVector32.Section checksum = BitVector32.CreateSection(1);
                BitVector32.Section sensorData = BitVector32.CreateSection(2067, checksum);
                BitVector32.Section sensorCode = BitVector32.CreateSection(7, sensorData);

                if (ChecksumOK(item[checksum], d >> 1))
                {
                    ushort code = (ushort)item[sensorCode];

                    if(!sensors.ContainsKey(code))
                    {
                        sensors.Add(code, new SensorData {Sum = 0, Count = 0});
                    }
                    sensors[code].Sum += item[sensorData];
                    sensors[code].Count++;
                }
            }
            Tuple<ushort, double>[] result = new Tuple<ushort, double>[sensors.Count];
            int index = 0;
            foreach (var sensor in sensors)
            { 
                result[index++] = new Tuple<ushort,double>(sensor.Key, (double)sensor.Value.Sum / sensor.Value.Count);
            }
            return result;
        }
    }
}
