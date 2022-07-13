using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpofityLite.Application.Usuario.Dto;
using SpofityLite.Application.Usuario.Service;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            this.playlistService = playlistService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodasPlaylists()
        {
            return Ok(await this.playlistService.ObterTodasPlaylists());
        }

        [HttpPost]
        public async Task<IActionResult> Criar(PlaylistInputDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = await this.playlistService.Criar(dto);

            return Created($"/{result.Id}", result);
        }
    }
}
