using System;

namespace EmployeeSystem.Domain.Utils
{
    public static class DateTimeUtils
    {
        public static int GetAge(DateTime birthdate) =>
            new DateTime((DateTime.Now - birthdate).Ticks).Year - 1;
    }
}
