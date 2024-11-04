using Function;
using Moq;

namespace NUnitTesting
{
    [TestFixture]
    public class DateTests
    {
        private Mock<ICheckDate> _mockCheckDate;
        private CheckDate _checkDate;

        [SetUp]
        public void Setup()
        {
            _mockCheckDate = new Mock<ICheckDate>();
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
        [TestCase(2000, 2, 29, true)]
        [TestCase(2000, 2, 29, true)]
        [TestCase(1900, 2, 28, true)]
        public void IsValidDate_MockedDaysInMonth_ReturnsExpectedResult(int year, int month, int day, bool expected)
        {
            _mockCheckDate.Setup(x => x.DaysInMonth(year, month)).Returns(GetDaysInMonth(year, month));
            var result = _checkDate.IsValidDate(year, month, day);
            Assert.That(result, Is.EqualTo(expected));
        }

        private int GetDaysInMonth(int year, int month) //Cài đặt cho giả lập
        {
            return month switch
            {
                1 => 31,
                3 => 31,
                4 => 30,
                5 => 31,
                6 => 30,
                7 => 31,
                8 => 31,
                9 => 30,
                10 => 31,
                11 => 30,
                12 => 31,
                2 when (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)) => 29,
                2 => 28,
                _ => 0
            };
        }
    }
}