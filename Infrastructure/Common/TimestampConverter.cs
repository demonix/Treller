using System;

namespace SKBKontur.Infrastructure.Common
{
    public class TimestampConverter : ITimestampConverter
    {
        private static readonly DateTime unixEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        private const int javaModifier = 1000;

        public long ToUtcTicks(double javaTimeStamp)
        {
            var dateTime = unixEpochStart.AddSeconds(Math.Round(javaTimeStamp / javaModifier));
            return dateTime.Ticks;
        }

        public double ToJavaTime(long ticks)
        {
            var dateTime = new DateTime(ticks);
            return (dateTime - unixEpochStart).TotalSeconds * javaModifier;
        }
    }
}