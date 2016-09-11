using System;
using System.Reflection;
using Newtonsoft.Json;
using SKBKontur.Infrastructure.ContainerConfiguration;
using SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.Models;
using SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Events.Interfaces;

namespace SKBKontur.Treller.WebApplication.Implementation.ReviewerSearching.EventHandlers.Reflection
{
    public class EventReflectionProxy : IEventReflectionProxy
    {
        private const string handleMethodName = nameof(IEventBeanHandler<IEventBean>.Handle);
        private readonly object eventBeanHandler;
        private readonly object eventObject;
        private readonly MethodInfo handleMethod;

        public EventReflectionProxy(string serializedEventData, Type eventDataType, IContainer container)
        {
            eventObject = JsonConvert.DeserializeObject(serializedEventData, eventDataType);
            var eventBeanHandlerType = typeof(IEventBeanHandler<>).MakeGenericType(eventDataType);
            eventBeanHandler = container.Get(eventBeanHandlerType);
            handleMethod = eventBeanHandlerType.GetMethod(handleMethodName);
        }

        public ReviewModel[] Handle(ReviewModel[] reviewModels)
        {
            return (ReviewModel[]) handleMethod.Invoke(eventBeanHandler, new[] {eventObject, reviewModels});
        }

        public string ReviewId => ((IEventBean) eventObject).ReviewId;
    }
}