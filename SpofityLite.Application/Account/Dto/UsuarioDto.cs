using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Account.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Account.Dto
{
    public record UsuarioInputDto(string Nome, Email Email, Password Senha, List<PlaylistInputDto> Playlists);
    public record UsuarioOutputDto(Guid Id, string Nome, Email Email, Password Senha, List<PlaylistOutputDto> Playlists);
    public record PlaylistInputDto(string Nome, List<MusicaInputDto> Musicas);
    public record PlaylistOutputDto(Guid Id, string Nome, List<MusicaOutputDto> Musicas);
}
