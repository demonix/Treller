using DomainLogic;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Base
{
    public interface IEventHandler
    {
        ReviewModel[] Apply(Tracking.Event @event, ReviewModel[] reviewModels);
    }
}