namespace HiPlatform.Chat.Api.App.Domain.Models
{
    public class MessageWrapper
    {
        public MessageWrapper(string from, string message, int order)
        {
            From = from;
            Message = message;
            Order = order;
        }

        public string From { get; private set; }
        public string Message { get; private set; }
        public int Order { get; private set; }
    }
}
