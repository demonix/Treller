using System;
using System.Collections.Generic;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Enums;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models
{
    public class ReviewModel
    {
        public Guid Id { get; set; }
        public string ExternalId { get; set; }
        public long Timestamp { get; set; }
        public List<UserModel> Authors { get; set; }
        public List<UserModel> Reviewers { get; set; }
        public ReviewState State { get; set; }
    }
}