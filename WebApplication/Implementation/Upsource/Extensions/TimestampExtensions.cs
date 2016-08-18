using System;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Extensions
{
    public static class TimestampExtensions
    {
        private static readonly DateTime unixEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        private const int javaModifier = 1000;

        public static long ToUtcTicks(this double javaTimeStamp)
        {
            var dateTime = unixEpochStart.AddSeconds(Math.Round(javaTimeStamp / javaModifier));
            return dateTime.Ticks;
        }

        public static double ToJavaTime(this long ticks)
        {
            var dateTime = new DateTime(ticks);
            return (dateTime - unixEpochStart).TotalSeconds * javaModifier;
        }
    }
}