using System;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services.TypedHandlers
{
    public class NewRevisionEventBeanHandler : ITypedHandler<NewRevisionEventBean>
    {
        public void Handle(NewRevisionEventBean eventData)
        {
            Console.WriteLine(eventData.CommitMessage);
        }
    }
}