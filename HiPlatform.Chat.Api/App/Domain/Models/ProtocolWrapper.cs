namespace HiPlatform.Chat.Api.App.Domain.Models
{
    public class ProtocolWrapper
    {
        public ProtocolWrapper(int protocolId)
        {
            Protocol = protocolId;
        }

        public int Protocol { get; private set; }
    }
}
