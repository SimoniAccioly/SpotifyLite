using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Handler.Command;
using SpofityLite.Application.Album.Handler.Query;

namespace SpotifyLite.Api.Controllers
{
   
    [ApiController]
    public class BandaController : ControllerBase
    {
        private readonly IMediator mediator;

        public BandaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("banda/obter-todos")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.mediator.Send(new GetAllBandaQuery()));
        }

        [HttpGet]
        [Route("banda/obter-por-id/{id}")]
        public async Task<IActionResult> GetId(Guid id)
        {
            return Ok(await this.mediator.Send(new GetIdBandaQuery(id)));
        }

        [HttpPost]
        [Route("banda/criar")]
        public async Task<IActionResult> Create(BandaInputDto dto)
        {
            var result = await this.mediator.Send(new CreateBandaCommand(dto));
            return Created($"{result.Banda.Id}", result.Banda);
        }

        [HttpPut]
        [Route("banda/editar/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] BandaInputDto dto)
{
            var result = await this.mediator.Send(new EditBandaCommand(id, dto));
            return Ok(result);
        }

        [HttpDelete]
        [Route("banda/excluir/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await this.mediator.Send(new DeleteBandaCommand(id));
            return Ok(result);
        }
    }
}

