using SpofityLite.Application.Usuario.Dto;

namespace SpofityLite.Application.Usuario.Service
{
    public interface IPlaylistService
    {
        Task<PlaylistOutputDto> Criar(PlaylistInputDto dto);
        Task<List<PlaylistOutputDto>> ObterTodasPlaylists();
    }
}