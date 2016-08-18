﻿using SKBKontur.Treller.WebApplication.Implementation.Services.ErrorService;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.Services;

namespace SKBKontur.Treller.WebApplication.Controllers
{
    public class UpsourceEventController : ExceptionHandledController
    {
        private readonly IEventHandler eventHandler;

        public UpsourceEventController(
            IErrorService errorService,
            IEventHandler eventHandler)
            : base(errorService)
        {
            this.eventHandler = eventHandler;
        }

        public void Handle(WebhookModel webhookModel)
        {
            eventHandler.Handle(webhookModel);
        }
    }
}