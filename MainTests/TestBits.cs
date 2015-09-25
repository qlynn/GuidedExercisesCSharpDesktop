using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections;

namespace MainTests
{
    [TestFixture, Description("Bit operations exercises")]
    class TestBits : BaseTest<Interfaces.Bits.ISensorAverage>
    {
        private static object[] PrecalculatedSensorData =
            new object[]
        {
                    new object[] 
                    {
                        new ushort[] { 0xE1FA, 0xE1F0, 0xE1F9, 0xE1F5, 0xE1F4 /* wrong checksum */,
                                          0xC1FB, 0xC1F1, 0x21FA, 0x21F0, 0x21F9 },
                

                        new Dictionary<ushort, double>
                                    {
                                        { 0x1, /* 253 + 248 + 252 */ 251.0 }, 
                                        { 0x6, /* 253 + 248 */ 250.5 },
                                        { 0x7, /* 253 + 248 + 252 + 250 */ 250.75 }
                                    }
                    },
                        new object[]
                        {
                            new ushort[] {},
                            new Dictionary<ushort, double>(),
                        },
                        new object[]
                        {
                            new ushort[] { 0x2000, 0x3001 },
                            new Dictionary<ushort, double>(),
                        },
        };

        [Test, TestCaseSource("PrecalculatedSensorData")]
        public void TestGetAverages(
            ushort[] modelData,
            IReadOnlyDictionary<ushort, double> modelResults)
        {
            Tuple<ushort, double>[] result = null;

            var impl = GetImpl();
            
            Assert.DoesNotThrow(() => { result = impl.GetAverages(modelData); }, "Unexpected exception has been thrown from your code.");

            Assert.NotNull(result, "Null result returned");

            Assert.AreEqual(modelResults.Count, result.Length,
                "Wrong number of results. Actual results are: {0}", 
                string.Join(", ", Array.ConvertAll(result, (el) => { return el.Item1 + "-" + el.Item2; } )));

            ushort[] resultSensorCodes = Array.ConvertAll(result, (item) => { return item.Item1; });

            CollectionAssert.AllItemsAreUnique(resultSensorCodes, "Sensor codes are duplicated in response.");
            CollectionAssert.AreEquivalent(modelResults.Keys, resultSensorCodes, "Sensor codes are wrong in response.");

            foreach (var item in result)
            {
                Assert.AreEqual(modelResults[item.Item1], item.Item2, 
                    "Wrong average {0} for sensor {1}. Model value is {2}", item.Item2, item.Item1, modelResults[item.Item1]);
            }
        }
    }
}

