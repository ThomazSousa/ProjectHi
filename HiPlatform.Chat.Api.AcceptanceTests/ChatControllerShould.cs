using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace HiPlatform.Chat.Api.AcceptanceTests
{
    public class ChatControllerShould : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _serverFactory;

        public ChatControllerShould(WebApplicationFactory<Startup> serverFactory)
        {
            _serverFactory = serverFactory;
        }

        [Theory]
        [InlineData("/1.0/api/chat")]
        [InlineData("/1.0/api/chat/1")]
        public async Task ReturnOkForEndpoint(string endpoint)
        {
            // Arrange
            var client = _serverFactory.CreateClient();

            // Act
            var response = await client.GetAsync(endpoint);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/1.0/api/chat/0")]
        public async Task ReturnBadRequestForEndpoint(string endpoint)
        {
            // Arrange
            var client = _serverFactory.CreateClient();

            // Act
            var response = await client.GetAsync(endpoint);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("/1.0/api/chat/9999999")]
        public async Task ReturnNotFoundForEndpoint(string endpoint)
        {
            // Arrange
            var client = _serverFactory.CreateClient();

            // Act
            var response = await client.GetAsync(endpoint);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
