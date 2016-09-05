using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Network;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.Services.TypedHandlers
{
    public class NewRevisionEventBeanHandler : ITypedHandler<NewRevisionEventBean>
    {
        public void Handle(NewRevisionEventBean eventData)
        {
            //Election.chooseBySingle(new Election.Developer(new[] {new Election.Reviewer()}));
        }
    }
}