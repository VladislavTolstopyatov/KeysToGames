using KeysToGames.DataAccess;
using KeysToGames.Service.UnitTests.Helpers;
using KeysToGames.Service.UnitTests;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;
using Moq;

namespace KeysToGames.BL.UnitTests
{
    public class KeysToGamesTestBaseClass
    {

        private readonly WebApplicationFactory<Program> _testServer;
        protected HttpClient TestHttpClient => _testServer.CreateClient();

        public KeysToGamesTestBaseClass()
        {
            var settings = TestSettingsHelper.GetSettings();

            _testServer = new TestWebApplicationFactory(services =>
            {
                services.Replace(ServiceDescriptor.Scoped(_ =>
                {
                    var httpClientFactoryMock = new Mock<IHttpClientFactory>();
                    httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
                        .Returns(TestHttpClient);
                    return httpClientFactoryMock.Object;
                }));
                services.PostConfigureAll<JwtBearerOptions>(options =>
                {
                    options.ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                        $"{settings.IdentityServerUri}/.well-known/openid-configuration",
                        new OpenIdConnectConfigurationRetriever(),
                        new HttpDocumentRetriever(TestHttpClient) //important
                        {
                            RequireHttps = false,
                            SendAdditionalHeaderData = true
                        });
                });
            });
        }



        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }

        public T? GetService<T>()
        {
            return _testServer.Services.GetRequiredService<T>();
        }
    }
}
