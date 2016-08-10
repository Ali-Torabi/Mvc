using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.AspNetCore.Mvc.FunctionalTests
{
    public class DisplayLocalizationTests : IClassFixture<MvcTestFixture<DisplayLocalizationSite.Startup>>
    {
        public DisplayLocalizationTests(MvcTestFixture<DisplayLocalizationSite.Startup> fixture)
        {
            Client = fixture.Client;
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task DisplayAttribute_Localizes()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost");

            // Act
            var response = await Client.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            // Assert
            // Localizes
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("<label class=\"col-md-2 control-label\" for=\"FirstName\">ENUSFIRSTNAME</label>", body);
            Assert.Contains("<p>Base firstname description</p>", body);
            Assert.Contains("placeholder=\"EN prompt\"", body);

            // Falls back
            Assert.Contains("<label class=\"col-md-2 control-label\" for=\"LastName\">LastNameMissingName</label>", body);
            Assert.Contains("<p>LastNameMissingDescription</p>", body);
            Assert.Contains("placeholder=\"LastNameMissingPrompt\"", body);
        }
    }
}
