using MediatR;
using SpofityLite.Application.Album.Handler.Command;
using SpofityLite.Application.Album.Handler.Query;
using SpofityLite.Application.Album.Service;

namespace SpofityLite.Application.Album.Handler
{
    public class AlbumHandler : IRequestHandler<CreateAlbumCommand, CreateAlbumCommandResponse>,
                                IRequestHandler<GetAllAlbumQuery, GetAllAlbumQueryResponse>,
                                IRequestHandler<EditAlbumCommand, EditAlbumCommandResponse>,
                                IRequestHandler<DeleteAlbumCommand, DeleteAlbumCommandResponse>,
        IRequestHandler<GetIdAlbumQuery, GetIdAlbumQueryResponse>
    {
        private readonly IAlbumService _albumService;

        public AlbumHandler(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<CreateAlbumCommandResponse> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Create(request.Album);
            return new CreateAlbumCommandResponse(result); 
        }

        public async Task<GetAllAlbumQueryResponse> Handle(GetAllAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.GetAll();
            return new GetAllAlbumQueryResponse(result);
        }

        public async Task<EditAlbumCommandResponse> Handle(EditAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Edit(request.Album);

            return new EditAlbumCommandResponse(result);
        }

        public async Task<DeleteAlbumCommandResponse> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Delete(request.Id);

            return new DeleteAlbumCommandResponse(result);
        }

        public async Task<GetIdAlbumQueryResponse> Handle(GetIdAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.GetId(request.Id);
            return new GetIdAlbumQueryResponse(result);
        }
    }
}
