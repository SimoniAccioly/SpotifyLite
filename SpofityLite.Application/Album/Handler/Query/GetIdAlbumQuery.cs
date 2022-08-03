using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
