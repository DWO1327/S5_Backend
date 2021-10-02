using Microsoft.AspNetCore.Mvc.Testing;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using System.Text;

namespace GuestbookBackend.Tests
{
    public class IntegrationTests
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("/guestbook/entries")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

        }

        [Theory]
        [InlineData("/guestbook/entries")]
        public async Task CheckIfGetSucceeds(string url)
        {

            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CheckIfContentNotCorrect()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act

            var response = await client.PostAsync("/guestbook/entries"
                , new StringContent(
                JsonConvert.SerializeObject(new StringContent("adgadg")),
            Encoding.UTF8,
            "application/json"));

            // Assert

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }

}
