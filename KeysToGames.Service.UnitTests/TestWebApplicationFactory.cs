using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace KeysToGames.Service.UnitTests
{
    public class TestWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly Action<IServiceCollection>? _overrideDependencies;

        public TestWebApplicationFactory(Action<IServiceCollection>? overrideDependencies = null)
        {
            _overrideDependencies = overrideDependencies;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => _overrideDependencies?.Invoke(services));
        }
    }
}
