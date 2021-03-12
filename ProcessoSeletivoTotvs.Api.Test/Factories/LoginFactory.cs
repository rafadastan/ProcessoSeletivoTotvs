using ProcessoSeletivoTotvs.Application.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivoTotvs.Api.Test.Factories
{
    public class LoginFactory
    {
        public static UsuarioAcessoModel CreateAuth(string login, string senha)
        {
            var model = new UsuarioAcessoModel();
            model.Email = login;
            model.Senha = senha;

            return model;
        }
    }
}
