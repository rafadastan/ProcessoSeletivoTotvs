using FluentAssertions;
using ProcessoSeletivoTotvs.Api.Test.Contexts;
using ProcessoSeletivoTotvs.Api.Test.Factories;
using ProcessoSeletivoTotvs.Api.Test.Utils;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ProcessoSeletivoTotvs.Api.Test.Scenarios
{
    public class LoginTest
    {
        private readonly TestContext testContext;
        private readonly string endpointUsuario;
        private readonly string endpointLogin;
        private readonly string errorAccessDenied;

        public LoginTest()
        {
            testContext = new TestContext();

            endpointUsuario = "/api/Usuarios";
            endpointLogin = "/api/Login";

            errorAccessDenied = "Usuário não foi encontrado.";
        }


        [Fact]
        public async Task Login_Post_ReturnsBadRequest()
        {
            var auth = LoginFactory.CreateAuth(string.Empty, string.Empty);

            var request = ServicesUtil.CreateRequestContent(auth);
            var response = await testContext.Client.PostAsync(endpointLogin, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
