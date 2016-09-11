using System.Threading.Tasks;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories.Objects;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Repositories
{
    public interface IReviewRepository
    {
        Task<Review> SelectAllAsync();
    }

    public interface IReviewerSearchingUserRepository
    {
        Task<ReviewerSearchingUser> SelectAllAsync();
    }

    public interface IReviewLinkRepository
    {
        Task<ReviewLink> SelectAllAsync();
    }
}