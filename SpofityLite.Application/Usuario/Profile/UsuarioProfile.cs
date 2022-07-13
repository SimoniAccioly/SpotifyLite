using SpofityLite.Application.Usuario.Dto;
using SpotifyLite.Domain.Account;
using SpotifyLite.Domain.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Usuario.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Musica, MusicaOutputDto>()
                .ForMember(x => x.Duracao, f => f.MapFrom(m => m.Duracao.ValorFormatado()));

            CreateMap<MusicaInputDto, Musica>()
                .ForPath(x => x.Duracao.Valor, f => f.MapFrom(m => m.Duracao));

            CreateMap<SpotifyLite.Domain.Account.Usuario, UsuarioOutputDto>();

            CreateMap<UsuarioInputDto, SpotifyLite.Domain.Account.Usuario>();

            CreateMap<PlaylistInputDto, Playlist>();

            CreateMap<Playlist, PlaylistOutputDto>();

        }

    }
}
