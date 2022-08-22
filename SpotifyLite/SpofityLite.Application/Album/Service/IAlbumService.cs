using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Service
{
    public interface IAlbumService
    {
        Task<AlbumOutputDto> Create(AlbumInputDto dto);
        Task<List<AlbumOutputDto>> GetAll();
        Task<AlbumOutputDto> Edit(AlbumInputDto dto);
        Task<AlbumOutputDto> Delete(Guid id);
        Task<AlbumOutputDto> GetId(Guid id);
    }
}