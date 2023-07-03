using _113918_mazavictornicolas.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static _113918_mazavictornicolas.Bussines.Comand.PostUsuario;
using static _113918_mazavictornicolas.Bussines.Queries.GetAviones;

namespace _113918_mazavictornicolas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AvionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/listaAviones")]

        public async Task<List<DtoAvion>> listaAviones()
        {
            return await _mediator.Send(new GetAvionesQuery());
        }

        [HttpPost]
        [Route("/postUsuario")]

        public async Task<UserDto> postUsuario([FromBody] PostUsuarioComand comando)
        {
            return await _mediator.Send(comando);
        }
    }
}
