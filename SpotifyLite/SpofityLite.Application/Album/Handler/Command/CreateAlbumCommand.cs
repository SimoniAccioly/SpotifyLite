﻿using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Command
{
    public class CreateAlbumCommand : IRequest<CreateAlbumCommandResponse>
    {
        public AlbumInputDto Album { get; set; }

        public Guid IdBanda { get; set; }

        public CreateAlbumCommand(AlbumInputDto album)
        {
            Album = album;
        }
    }

    public class CreateAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public CreateAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}