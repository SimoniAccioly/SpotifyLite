using SpofityLite.Application.Account.Dto;
using SpotifyLite.Domain.Account;

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
