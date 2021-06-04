using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace HiPlatform.Chat.Api.AcceptanceTests
{
    public class HealthCheckControllerShould : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _serverFactory;

        public HealthCheckControllerShould(WebApplicationFactory<Startup> serverFactory)
        {
            _serverFactory = serverFactory;
        }

        [Theory]
        [InlineData("/1.0/api/healthcheck")]
        public async Task ReturnOkForEndpoint(string endpoint)
        {
            // Arrange
            var client = _serverFactory.CreateClient();

            // Act
            var response = await client.GetAsync(endpoint);

            // Assert
            response.EnsureSuccessStatusCode(); 
        }
    }
}
