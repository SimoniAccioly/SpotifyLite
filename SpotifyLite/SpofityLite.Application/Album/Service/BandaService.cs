using AutoMapper;
using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;

namespace SpofityLite.Application.Album.Service
{
    public class BandaService : IBandaService
    {
        private readonly IBandaRepository bandaRepository;
        private readonly IMapper mapper;

        public BandaService(IBandaRepository bandaRepository, IMapper mapper)
        {
            this.bandaRepository = bandaRepository;
            this.mapper = mapper;
        }

        public async Task<BandaOutputDto> Create(BandaInputDto dto)
        {
            var banda = this.mapper.Map<Banda>(dto);

            await this.bandaRepository.Save(banda);

            return this.mapper.Map<BandaOutputDto>(banda);
        }

        public async Task<List<BandaOutputDto>> GetAll()
        {
            var result = await this.bandaRepository.GetAll();

            return this.mapper.Map<List<BandaOutputDto>>(result);
        }

        public async Task<BandaOutputDto> Edit(Guid id, BandaInputDto dto)
        {
            var banda = this.mapper.Map<Banda>(dto);
            banda.Id = id;

            await this.bandaRepository.Update(banda);

            return this.mapper.Map<BandaOutputDto>(banda);
        }

        public async Task<BandaOutputDto> Delete(Guid id)
        {
            var banda = await this.bandaRepository.Get(id);

            await this.bandaRepository.Delete(banda);

            return this.mapper.Map<BandaOutputDto>(banda);
        }

        public async Task<BandaOutputDto> GetId(Guid id)
        {
            var result = await this.bandaRepository.Get(id);

            return this.mapper.Map<BandaOutputDto>(result);
        }
    }
}
