using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Album.Handler.Command
{
    public class EditBandaCommand : IRequest<EditBandaCommandResponse>
    {
        public Guid Id { get; set; }
        public BandaInputDto Banda { get; set; }

        public EditBandaCommand(Guid id, BandaInputDto banda)
        {
            Id = id;
            Banda = banda;
        }
    }

    public class EditBandaCommandResponse
    {
        public BandaOutputDto Banda { get; set; }

        public EditBandaCommandResponse(BandaOutputDto banda)
        {
            Banda = banda;
        }
    }
}
