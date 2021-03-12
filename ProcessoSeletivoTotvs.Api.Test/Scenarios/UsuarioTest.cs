using FluentAssertions;
using ProcessoSeletivoTotvs.Api.Test.Contexts;
using ProcessoSeletivoTotvs.Api.Test.Factories;
using ProcessoSeletivoTotvs.Api.Test.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProcessoSeletivoTotvs.Api.Test.Scenarios
{
    public class UsuarioTest
    {
        private readonly TestContext testContext;
        private readonly string endpoint;
        private readonly string createUserMessage;
        private readonly string erroLoginMessage;

        public UsuarioTest()
        {
            testContext = new TestContext();
            endpoint = "/api/Usuarios";

            createUserMessage = "Usuário cadastrado com sucesso.";
            erroLoginMessage = "Erro. O login informado já encontra-se cadastrado";
        }

        [Fact]
        public async Task Usuario_Post_ReturnsBadRequest()
        {
            var request = ServicesUtil.CreateRequestContent(UsuarioFactory.CreateUsuarioEmpty);

            var response = await testContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        } 
    }
}
