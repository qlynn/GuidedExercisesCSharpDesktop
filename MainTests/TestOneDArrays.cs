using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MainTests
{
    [TestFixture, Description("One dimensional array exercises")]
    class TestOneDArrays : BaseTest<Interfaces.Arrays.IOneDArrays>
    {
        private static object[] EqualPairsData =
            new object[]
                {
                    new object[] { 0, new int[0] },
                    new object[] { 0, null },
                    new object[] { 2, new int[] { 1, 1, 1, 5, 5, 2341, 5, 123, 0, 123 } },
                };

        [Test, TestCaseSource("EqualPairsData")]
        public void TestCalculateEqualPairs(int result, int [] array)
        {
            var impl = GetImpl();
        }
    }
}
