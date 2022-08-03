using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Album.Handler.Command
{
    public class DeleteBandaCommand : IRequest<DeleteBandaCommandResponse>
    {
        public Guid Id { get; set; }

        public DeleteBandaCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteBandaCommandResponse
    {
        public BandaOutputDto Banda { get; set; }

        public DeleteBandaCommandResponse(BandaOutputDto banda)
        {
            Banda = banda;
        }
    }
}
