using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Reflection
{
    public interface IEventReflectionProxy
    {
        ReviewModel[] Handle(ReviewModel[] reviewModels);
        string ReviewId { get; }
    }
}