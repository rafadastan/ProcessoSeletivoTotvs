using ProcessoSeletivoTotvs.Application.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivoTotvs.Api.Test.Factories
{
    public class UsuarioFactory
    {
        public static UsuarioCadastroModel CreateUsuario
        {
            get
            {
                var random = new Random();
                var login = "raphael" + random.Next(999999);

                var model = new UsuarioCadastroModel
                {
                    Nome = "Raphael Augusto Pereira de Assis",
                    Email = login,
                    Senha = "adminadmin",
                    SenhaConfirmacao = "adminadmin"
                };

                return model;
            }
        }

        public static UsuarioCadastroModel CreateUsuarioEmpty
        {
            get
            {
                var model = new UsuarioCadastroModel
                {
                    Nome = string.Empty,
                    Email = string.Empty,
                    Senha = string.Empty,
                    SenhaConfirmacao = string.Empty
                };

                return model;
            }
        }
    }
}
