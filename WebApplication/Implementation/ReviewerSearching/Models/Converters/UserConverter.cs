using System;
using DomainLogic;
using SKBKontur.Infrastructure.Common;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models.Converters
{
    public class UserConverter : IUserConverter
    {
        private readonly IGuidFactory guidFactory;

        public UserConverter(IGuidFactory guidFactory)
        {
            this.guidFactory = guidFactory;
        }

        public Tracking.User Convert(UserIdBean userIdBean)
        {
            return new Tracking.User(InfrastructureTypes.Name.NewName(userIdBean.Name), InfrastructureTypes.ExternalId.NewExternalId(userIdBean.Id));
        }

        public Tracking.User Convert(UserModel userModel)
        {
            return new Tracking.User(InfrastructureTypes.Name.NewName(userModel.Name), InfrastructureTypes.ExternalId.NewExternalId(userModel.ExternalId));
        }

        public UserModel Convert(Guid userId, Tracking.User userModel)
        {
            return new UserModel
            {
                Id = userId == Guid.Empty ? guidFactory.Create() : userId,
                ExternalId = userModel.Id.Item,
                Name = userModel.Name.Item
            };
        }
    }
}