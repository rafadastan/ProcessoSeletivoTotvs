using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProcessoSeletivoTotvs.Application.Contracts;
using ProcessoSeletivoTotvs.Application.Models.Perfil;
using ProcessoSeletivoTotvs.Application.Models.Usuarios;
using ProcessoSeletivoTotvs.Domain.Contracts.Services;
using System;

namespace ProcessoSeletivoTotvs.API.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioApplicationService _usuarioApplicationService;     

        public UsuariosController(IUsuarioApplicationService usuarioApplicationService)
        {
            _usuarioApplicationService = usuarioApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post(UsuarioCadastroModel model)
        {
            try
            {
                var usuarioDTO = _usuarioApplicationService.Create(model);

                return StatusCode(201, new
                {
                    Message = "Usuário cadastrado com sucesso.",
                    Usuario = usuarioDTO
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _usuarioApplicationService.GetAll();

                if (result == null || result.Count == 0)
                    return StatusCode(204);

                return StatusCode(200, result);
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
