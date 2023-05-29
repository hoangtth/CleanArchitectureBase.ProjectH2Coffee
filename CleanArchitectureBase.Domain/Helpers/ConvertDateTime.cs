using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Domain.Helpers
{
    public static class ConvertDateTime
    {
        public static int GetCurrentUnixTimeStamp()
            => (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

        public static int GetCurrentUnixTimeStampEndDay()
       => (int)(DateTime.UtcNow.GetEndOfTheDay().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

        public static DateTime GetFirstDayOfMonth(this DateTime date)
            => new(date.Year, date.Month, 1, 0, 0, 0);

        public static DateTime GetLastDayOfMonth(this DateTime date)
        {
            var firstDay = GetFirstDayOfMonth(date);
            return firstDay.AddMonths(1).AddSeconds(-1);
        }

        public static int? DateTimeToUnixTimeStamp(this DateTime? dt)
        {
            if (dt == null) return null;
            var dateTimeOffset = new DateTimeOffset(dt.Value).ToUniversalTime();
            return (int)dateTimeOffset.ToUnixTimeSeconds();
        }

        public static DateTime? UnixTimeStampToDateTime(this int? unixTimeStamp)
        {
            if (unixTimeStamp == null) return null;
            return DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp.Value).ToLocalTime().DateTime;
        }

        public static DateOnly? UnixTimeStampToDateOnly(this int? unixTimeStamp)
        {
            if (unixTimeStamp == null) return null;
            return DateOnly.FromDateTime(DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp.Value).ToLocalTime().DateTime);
        }

        public static int? DateOnlyToUnixTimeStamp(this DateOnly? dateOnly)
        {
            if (dateOnly == null) return null;
            var dateTimeOffset = new DateTimeOffset(GetFromDateOnly(dateOnly.Value)).ToUniversalTime();
            return (int)dateTimeOffset.ToUnixTimeSeconds();
        }

        public static DateTime GetStartOfTheDay(this DateTime date) =>
            new(date.Year, date.Month, date.Day, 0, 0, 0);


        public static DateTime GetFromDateOnly(this DateOnly? date) =>
        new(date.Value.Year, date.Value.Month, date.Value.Day, 0, 0, 0);

        public static DateTime GetEndOfTheDay(this DateTime date) =>
            new(date.Year, date.Month, date.Day, 23, 59, 59);

        public static int HourToCurrentDate(this DateTime currentDate, int hour) =>
            DateTimeToUnixTimeStamp(GetStartOfTheDay(currentDate)).Value + hour;

        /// <summary>
        /// Tính số tuổi(năm) đến thời điểm hiện tại
        /// </summary>
        /// <param name="dateOfBirth">ngày sinh</param>
        /// lcliem 13/7/2021
        public static double CaculateAge(this DateTime dateOfBirth)
        {
            double age = 0;
            var currentDate = DateTime.Now;
            age = currentDate.Year - dateOfBirth.Year;
            var temp = (double)currentDate.DayOfYear / (double)dateOfBirth.DayOfYear;
            if (currentDate.DayOfYear != 1 && dateOfBirth.DayOfYear == 1)
            {
                age = age * 1.001;
            }
            else if (temp > 1)
            {
                age = age + (temp - currentDate.DayOfYear / dateOfBirth.DayOfYear);
            }
            else if (temp < 1)
            {
                age = age - 1 + temp;
            }
            return age;
        }

        public static DateTime TryParseDate(this string strDate)
        {
            DateTime dateTime;
            string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                    "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy"};
            DateTime.TryParseExact(strDate,
                            formats,
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out dateTime);
            return dateTime;
        }

        public static bool IsValidDate(string strDate)
        {
            DateTime dateTime;
            string[] formats = { "dd/MM/yyyy" };
            return DateTime.TryParseExact(strDate,
                              formats,
                              CultureInfo.InvariantCulture,
                              DateTimeStyles.None,
                              out dateTime);
        }
    }
}
