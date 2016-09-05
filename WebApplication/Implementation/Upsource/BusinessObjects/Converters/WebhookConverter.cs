using Newtonsoft.Json;

namespace SKBKontur.Treller.WebApplication.Implementation.Upsource.BusinessObjects.Converters
{
    public class WebhookConverter : IWebhookConverter
    {
        public Webhook Convert(WebhookModel webhookModel)
        {
            return new Webhook
            {
                DataType = webhookModel.DataType,
                MajorVersion = webhookModel.MajorVersion,
                MinorVersion = webhookModel.MinorVersion,
                ProjectId = webhookModel.ProjectId,
                //todo: вынести в абстракцию
                SerializedData = JsonConvert.SerializeObject(webhookModel.Data)
            };
        }
    }
}