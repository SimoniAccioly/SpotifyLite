using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
