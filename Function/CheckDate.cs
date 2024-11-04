namespace Function
{
    public class CheckDate : ICheckDate
    {
        public int DaysInMonth(int year, int month)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if ((year % 400 == 0) || ((year % 4 == 0) && (year % 100 != 0)))
                        return 29;
                    else
                        return 28;
                default:
                    return 0;
            }
        }

        public bool IsValidDate(int year, int month, int day)
        {
            int min = 1000;
            int max = 3000;
            if (month < 1 || month > 12 || year <= min || year >= max)
            {
                return false;
            }

            int daysInMonth = DaysInMonth(year, month);

            return day >= 1 && day <= daysInMonth;
        }
    }
}
