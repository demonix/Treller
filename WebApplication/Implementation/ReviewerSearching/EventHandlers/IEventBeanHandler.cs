using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers
{
    public interface IEventBeanHandler<in TEventBean> where TEventBean : IEventBean
    {
        ReviewModel[] Handle(TEventBean eventData, ReviewModel[] reviewModels);
    }
}