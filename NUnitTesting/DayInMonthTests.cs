using Function;

namespace NUnitTesting
{
    [TestFixture]
    public class DayInMonthTests
    {
        private CheckDate _checkDate;

        [SetUp]
        public void Setup()
        {
            _checkDate = new CheckDate();
        }

        [TestCase(2000, 1, 31)]
        [TestCase(2000, 3, 31)]
        [TestCase(2000, 5, 31)]
        [TestCase(2000, 7, 31)]
        [TestCase(2000, 8, 31)]
        [TestCase(2000, 10, 31)]
        [TestCase(2000, 12, 31)]
        public void DaysInMonth_31Days_ReturnsExpectedDays(int year, int month, int expectedDays)
        {
            var result = _checkDate.DaysInMonth(year, month);
            Assert.That(result, Is.EqualTo(expectedDays));
        }

        [TestCase(2021, 4, 30)]
        [TestCase(2021, 6, 30)]
        [TestCase(2021, 9, 30)]
        [TestCase(2021, 11, 30)]
        public void DaysInMonth_30Days_ReturnsExpectedDays(int year, int month, int expectedDays)
        {
            var result = _checkDate.DaysInMonth(year, month);
            Assert.That(result, Is.EqualTo(expectedDays));
        }

        [TestCase(2021, 2, 28)]
        [TestCase(1900, 2, 28)]
        public void DaysInMonth_FebruaryNonLeapYear_ReturnsExpectedDays(int year, int month, int expectedDays)
        {
            var result = _checkDate.DaysInMonth(year, month);
            Assert.That(result, Is.EqualTo(expectedDays));
        }

        [TestCase(2020, 2, 29)]
        [TestCase(2000, 2, 29)]
        public void DaysInMonth_FebruaryLeapYear_ReturnsExpectedDays(int year, int month, int expectedDays)
        {
            var result = _checkDate.DaysInMonth(year, month);
            Assert.That(result, Is.EqualTo(expectedDays));
        }

        [TestCase(2021, 0, 0)]
        [TestCase(2021, 13, 0)]
        public void DaysInMonth_InvalidMonth_ReturnsZero(int year, int month, int expectedDays)
        {
            var result = _checkDate.DaysInMonth(year, month);
            Assert.That(result, Is.EqualTo(expectedDays));
        }
    }
}
