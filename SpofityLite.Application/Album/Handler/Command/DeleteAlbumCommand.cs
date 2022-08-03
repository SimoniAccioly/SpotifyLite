using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Command
{
    public class DeleteAlbumCommand : IRequest<DeleteAlbumCommandResponse>
    {
        public Guid Id { get; set; }

        public DeleteAlbumCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public DeleteAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
