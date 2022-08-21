using MediatR;
using SpofityLite.Application.Album.Handler.Command;
using SpofityLite.Application.Album.Handler.Query;
using SpofityLite.Application.Album.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Album.Handler
{
    public class BandaHandler : IRequestHandler<CreateBandaCommand, CreateBandaCommandResponse>,
                                IRequestHandler<EditBandaCommand, EditBandaCommandResponse>,
                                IRequestHandler<DeleteBandaCommand, DeleteBandaCommandResponse>,
                                IRequestHandler<GetAllBandaQuery, GetAllBandaQueryResponse>,
                                IRequestHandler<GetIdBandaQuery, GetIdBandaQueryResponse>
    {

        private readonly IBandaService _bandaService;

        public BandaHandler(IBandaService bandaService)
        {
            _bandaService = bandaService;
        }

        public async Task<GetAllBandaQueryResponse> Handle(GetAllBandaQuery request, CancellationToken cancellationToken)
        {
            var result = await _bandaService.GetAll();
            return new GetAllBandaQueryResponse(result);
        }

        public async Task<GetIdBandaQueryResponse> Handle(GetIdBandaQuery request, CancellationToken cancellationToken)
        {
            var result = await _bandaService.GetId(request.Id);
            return new GetIdBandaQueryResponse(result);
        }

        public async Task<CreateBandaCommandResponse> Handle(CreateBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await _bandaService.Create(request.Banda);
            return new CreateBandaCommandResponse(result);
        }

        public async Task<EditBandaCommandResponse> Handle(EditBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Edit(request.Banda);

            return new EditBandaCommandResponse(result);
        }

        public async Task<DeleteBandaCommandResponse> Handle(DeleteBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Delete(request.Id);

            return new DeleteBandaCommandResponse(result);
        }
    }
}
