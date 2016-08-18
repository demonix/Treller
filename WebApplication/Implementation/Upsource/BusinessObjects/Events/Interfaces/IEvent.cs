namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces
{
    public interface IEvent
    {
        long Timestamp { get; }
        string Id { get; }
    }
}