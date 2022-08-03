using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Command
{
    public class EditAlbumCommand : IRequest<EditAlbumCommandResponse>
    {
        public Guid Id { get; set; }
        public AlbumInputDto Album { get; set; }

        public EditAlbumCommand(Guid id, AlbumInputDto album)
        {
            Id = id;
            Album = album;
        }
    }

    public class EditAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public EditAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
