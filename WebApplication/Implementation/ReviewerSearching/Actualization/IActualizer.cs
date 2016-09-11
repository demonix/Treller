using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.Services;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Actualization
{
    public interface IActualizer
    {
        Task ActualizeAsync(long afterTimestamp, int count);
    }

    public class ReviewActualizer : IActualizer
    {
        private readonly IEventService eventService;
        private readonly IReviewLinkRepository reviewLinkRepository;
        private readonly IReviewRepository reviewRepository;
        private readonly IReviewerSearchingUserRepository reviewerSearchingUserRepository;

        public ReviewActualizer(
            IEventService eventService,
            IReviewLinkRepository reviewLinkRepository,
            IReviewRepository reviewRepository,
            IReviewerSearchingUserRepository reviewerSearchingUserRepository
            )
        {
            this.eventService = eventService;
            this.reviewLinkRepository = reviewLinkRepository;
            this.reviewRepository = reviewRepository;
            this.reviewerSearchingUserRepository = reviewerSearchingUserRepository;
        }

        public async Task ActualizeAsync(long afterTimestamp, int count)
        {
            var upsourceEvents = await eventService.EnumerateAsync(afterTimestamp, count).ConfigureAwait(false);

            var reviewLink = await reviewLinkRepository.SelectAllAsync().ConfigureAwait(false);
            var review = await reviewRepository.SelectAllAsync().ConfigureAwait(false);
            var reviewerSearchingUser = await reviewerSearchingUserRepository.SelectAllAsync().ConfigureAwait(false);
        }
    }
}