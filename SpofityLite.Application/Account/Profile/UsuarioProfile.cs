using SpofityLite.Application.Account.Dto;
using SpotifyLite.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Account.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioOutputDto>();
            CreateMap<UsuarioInputDto, Usuario>();

            CreateMap<Playlist, PlaylistOutputDto>();
            CreateMap<PlaylistInputDto, Playlist>();
        }
    }
}
