using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Service
{
    public interface IBandaService
    {
        Task<BandaOutputDto> Create(BandaInputDto dto);
        Task<List<BandaOutputDto>> GetAll();
        Task<BandaOutputDto> Edit(Guid id, BandaInputDto dto);
        Task<BandaOutputDto> Delete(Guid id);
        Task<BandaOutputDto> GetId(Guid id);
    }
}