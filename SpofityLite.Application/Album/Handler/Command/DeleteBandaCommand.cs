using MediatR;
using SpofityLite.Application.Album.Dto;

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
