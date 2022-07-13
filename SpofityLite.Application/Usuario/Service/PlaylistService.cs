using AutoMapper;
using SpofityLite.Application.Usuario.Dto;
using SpotifyLite.Domain.Account;
using SpotifyLite.Domain.Account.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Usuario.Service
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository playlistRepository;
        private readonly IMapper mapper;

        public PlaylistService(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            this.playlistRepository = playlistRepository;
            this.mapper = mapper;
        }

        public async Task<PlaylistOutputDto> Criar(PlaylistInputDto dto)
        {
            var playlist = this.mapper.Map<Playlist>(dto);

            await this.playlistRepository.Save(playlist);

            return this.mapper.Map<PlaylistOutputDto>(playlist);

        }

        public async Task<List<PlaylistOutputDto>> ObterTodasPlaylists()
        {
            var playlist = await this.playlistRepository.GetAll();

            return this.mapper.Map<List<PlaylistOutputDto>>(playlist);
        }


    }
}
