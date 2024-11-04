using Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTesting
{
    public class NonMockDayTests
    {
        private CheckDate _checkDate;

        [SetUp]
        public void Setup()
        {
            _checkDate = new CheckDate();
        }
        [TestCase(1000, 12, 1, false)]
        [TestCase(3000, 12, 1, false)]
        [TestCase(2021, 0, 1, false)]
        [TestCase(2021, 13, 1, false)]
        [TestCase(2021, 1, 0, false)]
        [TestCase(2021, 1, 32, false)]
        [TestCase(2021, 4, 31, false)]
        [TestCase(2021, 2, 29, false)]
        [TestCase(2000, 2, 30, false)]
        [TestCase(1900, 2, 29, false)]
        [TestCase(2021, 1, 31, true)]
        [TestCase(2021, 3, 31, true)]
        [TestCase(2021, 4, 30, true)]
        [TestCase(2021, 2, 28, true)]
        [TestCase(2020, 2, 29, true)]
        [TestCase(1900, 2, 28, true)]
        public void IsValidDate_ReturnsExpectedResult(int year, int month, int day, bool expected)
        {
            var result = _checkDate.IsValidDate(year, month, day);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
