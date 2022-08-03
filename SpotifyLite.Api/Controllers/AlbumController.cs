using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Handler.Command;
using SpofityLite.Application.Album.Handler.Query;
using SpotifyLite.Domain.Album.Repository;

namespace SpotifyLite.Api.Controllers
{
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator mediator;

        public AlbumController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("album/obter-todos")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.mediator.Send(new GetAllAlbumQuery());
            return Ok(result);
        }

        [HttpPost()]
        [Route("album/criar")]
        public async Task<IActionResult> Create(AlbumInputDto dto)
        {
            var result = await this.mediator.Send(new CreateAlbumCommand(dto));
            return Created($"{result.Album.Id}", result.Album);
        }

        [HttpGet]
        [Route("album/obter-por-id/{id}")]
        public async Task<IActionResult> GetId(Guid id)
        {
            var result = await this.mediator.Send(new GetIdAlbumQuery(id));
            return Ok(result);
        }

        [HttpPut]
        [Route("album/editar/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] AlbumInputDto dto)
        {
            var result = await this.mediator.Send(new EditAlbumCommand(id, dto));
            return Ok(result);
        }

        [HttpDelete]
        [Route("album/excluir/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await this.mediator.Send(new DeleteAlbumCommand(id));
            return Ok(result);
        }
    }
}
