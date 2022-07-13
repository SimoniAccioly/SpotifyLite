using SpotifyLite.Domain.Account.ValueObject;
using SpotifyLite.Domain.Album.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Usuario.Dto
{
    public record UsuarioInputDto(
        [Required(ErrorMessage = "Nome é obrigatório")] string Nome, 
        [Required(ErrorMessage = "E-mail é obrigatório")] Email Email, 
        [Required(ErrorMessage = "Senha é obrigatória")] Password Password);

    public record UsuarioOutputDto(Guid Id, string Nome, Email Email, Password Password);

    public record PlaylistInputDto(string Nome, List<MusicaInputDto>Musicas);

    public record PlaylistOutputDto(Guid Id, List<MusicaOutputDto> Musicas);

    public record MusicaInputDto(Guid Id,string Musicas, Duracao Duracao);

    public record MusicaOutputDto(Guid Id, string Musicas, Duracao Duracao);



}





