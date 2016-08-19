namespace SKBKontur.Infrastructure.Common
{
    public interface ITimestampConverter
    {
        double ToJavaTime(long ticks);
        long ToUtcTicks(double javaTimeStamp);
    }
}