using SpotifyLite.Domain.Account.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Usuario.Dto
{
    public record UsuarioInputDto(string Nome, Email Email, Password Password, List<PlayListInputDto> PlayLists);

    public record UsuarioOutputDto(Guid Id,  string Nome, Email Email, Password Password, List<PlayListOutputDto> PlayLists);

    public record PlayListInputDto(string Nome, List<MusicaInput> Musicas);

    public record PlayListOutputDto(Guid Id, List<MusicaOutput> Musicas);

    public record MusicaInput(string Nome, int Duracao);

    public record MusicaOutput(Guid Id, string Nome, int Duracao);
}





