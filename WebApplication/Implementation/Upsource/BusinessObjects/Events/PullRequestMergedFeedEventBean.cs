using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events
{
    public class PullRequestMergedFeedEventBean : FeedEventBase
    {
        [JsonProperty("pullRequest")]
        public string BranchName { get; set; }
    }
}