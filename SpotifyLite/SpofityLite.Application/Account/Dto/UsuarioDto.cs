using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Account.ValueObject;

namespace SpofityLite.Application.Account.Dto
{
    public record UsuarioInputDto(string Nome, Email Email, Password Password, List<PlaylistInputDto> Playlists);
    public record UsuarioOutputDto(Guid Id, string Nome, Email Email, Password Password, List<PlaylistOutputDto> Playlists);
    public record PlaylistInputDto(string Nome, List<MusicaInputDto> Musicas);
    public record PlaylistOutputDto(Guid Id, string Nome, List<MusicaOutputDto> Musicas);
}
