using AutoMapper;
using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Album.Repository;

namespace SpofityLite.Application.Album.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IMapper mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            this.albumRepository = albumRepository;
            this.mapper = mapper;
        }

        public async Task<AlbumOutputDto> Create(AlbumInputDto dto)
        {
            var album = this.mapper.Map<SpotifyLite.Domain.Album.Album>(dto);

            await this.albumRepository.Save(album);

            return this.mapper.Map<AlbumOutputDto>(album);

        }

        public async Task<List<AlbumOutputDto>> GetAll()
        {
            var album = await this.albumRepository.GetAll();

            return this.mapper.Map<List<AlbumOutputDto>>(album);
        }

        public async Task<AlbumOutputDto> Edit(AlbumInputDto dto)
        {
            var album = this.mapper.Map<SpotifyLite.Domain.Album.Album>(dto);

            await this.albumRepository.Update(album);

            return this.mapper.Map<AlbumOutputDto>(album);
        }

        public async Task<AlbumOutputDto> Delete(Guid id)
        {
            var album = await this.albumRepository.Get(id);

            await this.albumRepository.Delete(album);

            return this.mapper.Map<AlbumOutputDto>(album);
        }
        public async Task<AlbumOutputDto> GetId(Guid id)
        {
            var result = await this.albumRepository.Get(id);

            return this.mapper.Map<AlbumOutputDto>(result);
        }
    }
}
