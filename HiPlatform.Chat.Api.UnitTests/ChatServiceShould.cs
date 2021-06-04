using HiPlatform.Chat.Api.App.Domain.Services;
using Xunit;

namespace HiPlatform.Chat.Api.UnitTests
{
    public class ChatServiceShould
    {
        private readonly ChatService _chatService;

        public ChatServiceShould()
        {
            _chatService = new ChatService();
        }

        [Fact]
        public void ReturnProtocols()
        {
            var result = _chatService.GetAvailableDialogs();

            Assert.NotNull(result);
        }

        [Fact]
        public void ReturnMessages()
        {
            var result = _chatService.GetDialog(1);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
