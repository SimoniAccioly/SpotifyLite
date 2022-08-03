using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Query
{
    public class GetIdAlbumQuery : IRequest<GetIdAlbumQueryResponse>
    {
        public Guid Id { get; set; }

        public GetIdAlbumQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetIdAlbumQueryResponse
    {
        public AlbumOutputDto Album { get; set; }

        public GetIdAlbumQueryResponse(AlbumOutputDto album)
        {
            Album = album;
        }

    }
}
