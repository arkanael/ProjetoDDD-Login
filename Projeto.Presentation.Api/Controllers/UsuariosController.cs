using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models.Usuarios;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //atributo
        private readonly IUsuarioApplicationService usuarioApplicationService;

        //construtor para injeção de dependência
        public UsuariosController(IUsuarioApplicationService usuarioApplicationService)
        {
            this.usuarioApplicationService = usuarioApplicationService;
        }

        [HttpPost]
        public IActionResult Post(UsuarioCadastroModel model)
        {
            try
            {
                usuarioApplicationService.Create(model);
                return Ok("Usuário cadastrado com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
