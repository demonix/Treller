using System;
using DomainLogic;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Converters
{
    public interface IUserConverter
    {
        Tracking.User ConvertToDomain(UserIdBean userIdBean);
        Tracking.User ConvertToDomain(UserModel userModel);
        UserModel ConvertToModel(Guid userId, Tracking.User userModel, long timestamp);
        UserModel ConvertToModel(ReviewerSearchingUser reviewerSearchingUser);
        ReviewerSearchingUser ConvertToDb(UserModel userModel);
    }
}