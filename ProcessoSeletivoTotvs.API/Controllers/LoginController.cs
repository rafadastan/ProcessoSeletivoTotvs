using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessoSeletivoTotvs.API.Security;
using ProcessoSeletivoTotvs.Application.Contracts;
using ProcessoSeletivoTotvs.Application.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessoSeletivoTotvs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioApplicationService usuarioApplicationService;
        private readonly JwtToken jwtToken;

        public LoginController(IUsuarioApplicationService usuarioApplicationService, JwtToken jwtToken)
        {
            this.usuarioApplicationService = usuarioApplicationService;
            this.jwtToken = jwtToken;
        }

        [HttpPost]
        public IActionResult Post(UsuarioAcessoModel model)
        {
            try
            {
                var usuarioDTO = usuarioApplicationService.GetAccess(model);

                if (usuarioDTO != null)
                {
                    return StatusCode(200, new
                    {
                        Message = "Usuário autenticado com sucesso.",
                        Usuario = usuarioDTO,
                        AccessToken = new
                        {
                            BearerToken = jwtToken.GenerateToken(usuarioDTO.Email),
                            Expiration = DateTime.Now.AddDays(1)
                        }
                    });
                }

                throw new Exception("Acesso Negado. Usuário não encontrado.");
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }
    }
}
