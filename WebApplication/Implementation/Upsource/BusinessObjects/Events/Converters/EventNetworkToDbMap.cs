using System;
using System.Collections.Generic;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.DB;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Converters
{
    public class EventNetworkToDbMap : IEventNetworkToDbMap
    {
        private readonly Dictionary<Type, Type> map = new Dictionary<Type, Type>
        {
            { typeof(DiscussionFeedEventBean), typeof(DiscussionFeedEvent) },
            { typeof(NewParticipantInReviewFeedEventBean), typeof(NewParticipantInReviewFeedEvent) },
            { typeof(NewRevisionEventBean), typeof(NewRevisionEvent) },
            { typeof(ParticipantStateChangedFeedEventBean), typeof(ParticipantStateChangedFeedEvent) },
            { typeof(PullRequestMergedFeedEventBean), typeof(PullRequestMergedFeedEvent) },
            { typeof(RemovedParticipantFromReviewFeedEventBean), typeof(RemovedParticipantFromReviewFeedEvent) },
            { typeof(ReviewCreatedFeedEventBean), typeof(ReviewCreatedFeedEvent) },
            { typeof(ReviewRemovedFeedEventBean), typeof(ReviewRemovedFeedEvent) },
            { typeof(ReviewStateChangedFeedEventBean), typeof(ReviewStateChangedFeedEvent) },
            { typeof(ReviewStoppedBranchTrackingFeedEventBean), typeof(ReviewStoppedBranchTrackingFeedEvent) },
            { typeof(RevisionAddedToReviewFeedEventBean), typeof(RevisionAddedToReviewFeedEvent) },
            { typeof(RevisionRemovedFromReviewFeedEventBean), typeof(RevisionRemovedFromReviewFeedEvent) }
        };

        public Type GetDbType(Type networkType)
        {
            if (!map.ContainsKey(networkType))
            {
                throw new Exception($"Mapping for type {networkType} not found");
            }

            return map[networkType];
        }
    }
}