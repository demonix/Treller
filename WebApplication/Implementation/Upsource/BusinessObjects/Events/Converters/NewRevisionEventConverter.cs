using SKBKontur.Infrastructure.Common;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class NewRevisionEventConverter : INewRevisionEventConverter
    {
        private readonly IDateTimeFactory dateTimeFactory;
        private readonly ITimestampConverter timestampConverter;

        public NewRevisionEventConverter(
            IDateTimeFactory dateTimeFactory,
            ITimestampConverter timestampConverter)
        {
            this.dateTimeFactory = dateTimeFactory;
            this.timestampConverter = timestampConverter;
        }

        public NewRevisionEvent Convert(NewRevisionEventBean newRevisionEventBean)
        {
            return new NewRevisionEvent
            {
                Id = newRevisionEventBean.RevisionId,
                Timestamp = newRevisionEventBean.CommitTimestamp.HasValue
                    ? timestampConverter.ToUtcTicks(newRevisionEventBean.CommitTimestamp.Value)
                    : dateTimeFactory.UtcTicks,
                AuthorId = newRevisionEventBean.AuthorId,
                Branches = newRevisionEventBean.Branches ?? new string[0],
                CommitMessage = newRevisionEventBean.CommitMessage
            };
        }
    }
}