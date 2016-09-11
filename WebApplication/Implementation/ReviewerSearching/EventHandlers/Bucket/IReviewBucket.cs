using System.Collections.Generic;
using DomainLogic;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Bucket
{
    public interface IReviewBucket
    {
        Tracking.Review[] GetDomainModel();
        ReviewModel[] Reviews { get; }
        void SetDomainModel(IEnumerable<Tracking.Review> reviews);
    }
}