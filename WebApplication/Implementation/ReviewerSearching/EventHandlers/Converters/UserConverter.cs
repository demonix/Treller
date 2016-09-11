using System;
using DomainLogic;
using SKBKontur.Infrastructure.Common;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Converters
{
    public class UserConverter : IUserConverter
    {
        private readonly IGuidFactory guidFactory;

        public UserConverter(IGuidFactory guidFactory)
        {
            this.guidFactory = guidFactory;
        }

        public Tracking.User ConvertToDomain(UserIdBean userIdBean)
        {
            return new Tracking.User(CommonTypes.Name.NewName(userIdBean.Name), CommonTypes.ExternalId.NewExternalId(userIdBean.Id));
        }

        public Tracking.User ConvertToDomain(UserModel userModel)
        {
            return new Tracking.User(CommonTypes.Name.NewName(userModel.Name), CommonTypes.ExternalId.NewExternalId(userModel.ExternalId));
        }

        public UserModel ConvertToModel(Guid userId, Tracking.User userModel, long timestamp)
        {
            return new UserModel
            {
                Id = userId == Guid.Empty ? guidFactory.Create() : userId,
                ExternalId = userModel.Id.Item,
                Name = userModel.Name.Item,
                Timestamp = timestamp
            };
        }

        public UserModel ConvertToModel(ReviewerSearchingUser reviewerSearchingUser)
        {
            return new UserModel
            {
                Id = reviewerSearchingUser.Id,
                ExternalId = reviewerSearchingUser.ExtnernalUserId,
                Name = reviewerSearchingUser.Name,
                Timestamp = reviewerSearchingUser.Timestamp
            };
        }

        public ReviewerSearchingUser ConvertToDb(UserModel userModel)
        {
            return new ReviewerSearchingUser
            {
                Id = userModel.Id,
                ExtnernalUserId = userModel.ExternalId,
                Name = userModel.Name,
                Timestamp = userModel.Timestamp
            };
        }
    }
}