using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Command
{
    public class EditBandaCommand : IRequest<EditBandaCommandResponse>
    {
        public BandaUpdateDto Banda { get; set; }

        public EditBandaCommand(BandaUpdateDto banda)
        {
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
