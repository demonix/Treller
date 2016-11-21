﻿using SKBKontur.Infrastructure.Common;
using SKBKontur.Treller.WebApplication.Implementation.Services.News.Storage;

namespace SKBKontur.Treller.WebApplication.Implementation.Services.News.Publisher
{
    public class EmailPublisher : IPublisher
    {
        private readonly INewsNotificator newsNotificator;
        private readonly IDateTimeFactory dateTimeFactory;
        private readonly ITaskNewStorage taskNewStorage;

        public EmailPublisher(
            INewsNotificator newsNotificator,
            IDateTimeFactory dateTimeFactory,
            ITaskNewStorage taskNewStorage
            )
        {
            this.newsNotificator = newsNotificator;
            this.dateTimeFactory = dateTimeFactory;
            this.taskNewStorage = taskNewStorage;
        }

        public void Publish(string taskId)
        {
            var maybeTaskNew = taskNewStorage.Find(taskId);
            if (maybeTaskNew.HasValue)
            {
                var now = dateTimeFactory.UtcNow;
                if (maybeTaskNew.Value.TryPublish(newsNotificator, now))
                {
                    taskNewStorage.Update(maybeTaskNew.Value);
                }
            }
        }
    }
}