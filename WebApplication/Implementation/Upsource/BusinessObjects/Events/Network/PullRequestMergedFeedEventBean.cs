using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network
{
    public class PullRequestMergedFeedEventBean : FeedEventBaseBean
    {
        [JsonProperty("pullRequest")]
        public string BranchName { get; set; }
    }
}