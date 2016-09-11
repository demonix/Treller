using System;
using DomainLogic;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Converters
{
    public interface IUserConverter
    {
        Tracking.User Convert(UserIdBean userIdBean);
        Tracking.User Convert(UserModel userModel);
        UserModel Convert(Guid userId, Tracking.User userModel);
    }
}