namespace Function
{
    public interface ICheckDate
    {
        int DaysInMonth(int year, int month);
        bool IsValidDate(int year, int month, int day);
    }
}
