using System.Threading.Tasks;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Actualization
{
    public interface IActualizer
    {
        Task ActualizeAsync(long afterTimestamp, int count);
    }
}