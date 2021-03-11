using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessoSeletivoTotvs.Application.Contracts;
using ProcessoSeletivoTotvs.Application.Models.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessoSeletivoTotvs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilApplicationService _perfilApplicationService;

        public PerfilController(IPerfilApplicationService perfilApplicationService)
        {
            _perfilApplicationService = perfilApplicationService;
        }


        [HttpPost]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post(PerfilCadastroModel model)
        {
            try
            {
                var perfilDTO = _perfilApplicationService.Create(model);

                return StatusCode(201, new
                {
                    Message = "Perfil cadastrado com sucesso.",
                    Perfil = perfilDTO
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
                var result = _perfilApplicationService.GetAll();

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
