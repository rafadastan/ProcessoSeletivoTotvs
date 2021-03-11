using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace ProcessoSeletivoTotvs.Test.Contexts
{
    public class TestContext
    {
        public HttpClient Client { get; set; }

        private TestServer testServer;

        //ler o arquivo appsettings.json do projeto API
        public TestContext()
        {
            //lendo o arquivo appsettings.json do projeto API
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //iniciando o servidor de testes
            testServer = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Startup>());

            //gerar o objeto para executar os testes
            Client = testServer.CreateClient();
        }
    }
}
