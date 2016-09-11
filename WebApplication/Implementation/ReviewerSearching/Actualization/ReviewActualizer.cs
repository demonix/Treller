using System.Linq;
using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Converters;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Reflection;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.Services;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Actualization
{
    public class ReviewActualizer : IActualizer
    {
        private readonly IEventService eventService;
        private readonly IReviewLinkRepository reviewLinkRepository;
        private readonly IReviewRepository reviewRepository;
        private readonly IReviewerSearchingUserRepository reviewerSearchingUserRepository;
        private readonly IReviewConverter reviewConverter;
        private readonly IEventReflectionProxyFactory eventReflectionProxyFactory;

        public ReviewActualizer(
            IEventService eventService,
            IReviewLinkRepository reviewLinkRepository,
            IReviewRepository reviewRepository,
            IReviewerSearchingUserRepository reviewerSearchingUserRepository,
            IReviewConverter reviewConverter,
            IEventReflectionProxyFactory eventReflectionProxyFactory
            )
        {
            this.eventService = eventService;
            this.reviewLinkRepository = reviewLinkRepository;
            this.reviewRepository = reviewRepository;
            this.reviewerSearchingUserRepository = reviewerSearchingUserRepository;
            this.reviewConverter = reviewConverter;
            this.eventReflectionProxyFactory = eventReflectionProxyFactory;
        }

        public async Task ActualizeAsync(long afterTimestamp, int count)
        {
            var upsourceEvents = await eventService.EnumerateAsync(afterTimestamp, count).ConfigureAwait(false);
            var eventReflectionProxies = upsourceEvents.Select(u => eventReflectionProxyFactory.Create(u.Webhook)).ToArray();

            var externalReviewIds = eventReflectionProxies.Select(e => e.ReviewId).ToArray();
            var reviews = await reviewRepository.SelectAsync(externalReviewIds).ConfigureAwait(false);
            var reviewIds = reviews.Select(r => r.Id).Distinct().ToArray();
            var reviewLinks = await reviewLinkRepository.SelectAsync(reviewIds).ConfigureAwait(false);
            var userIds = reviewLinks.Select(l => l.UserId).Distinct().ToArray();
            var reviewerSearchingUsers = await reviewerSearchingUserRepository.SelectAsync(userIds).ConfigureAwait(false);

            var reviewModels = reviewConverter.Convert(reviews, reviewLinks, reviewerSearchingUsers);

            foreach (var eventReflectionProxy in eventReflectionProxies)
            {
                reviewModels = eventReflectionProxy.Handle(reviewModels);
            }

            var dbTuple = reviewConverter.Convert(reviewModels);
            var actualizedReviews = dbTuple.Item1;
            var actualizedReviewLinks = dbTuple.Item2;
            var actualizedReviewSearchingUsers = dbTuple.Item2;

            //todo: написать merge и сохранять в базу
        }
    }
}