using AutoMapper;
using SpofityLite.Application.Album.Dto;
using SpotifyLite.CrossCutting.Infrastructure;
using SpotifyLite.Domain.Album.Repository;


namespace SpofityLite.Application.Album.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IMapper mapper;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly AzureBlobStorage storage;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper, IHttpClientFactory httpClientFactory, AzureBlobStorage storage)
        {
            this.albumRepository = albumRepository;
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
            this.storage = storage;
        }

        public async Task<AlbumOutputDto> Create(AlbumInputDto dto)
        {
            var album = this.mapper.Map<SpotifyLite.Domain.Album.Album>(dto);

            HttpClient httpClient = this.httpClientFactory.CreateClient();

            using var response = await httpClient.GetAsync(album.Backdrop);

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();

                var fileName = $"{Guid.NewGuid()}.jpg";

                var pathStorage = await this.storage.UploadFile(fileName, stream);

                album.Backdrop = pathStorage;

            }

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
