using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Command
{
    public class EditAlbumCommand : IRequest<EditAlbumCommandResponse>
    {
        public AlbumUpdateDto Album { get; set; }

        public EditAlbumCommand(AlbumUpdateDto album)
        {
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
