using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Album.Handler.Query
{
    public class GetIdBandaQuery : IRequest<GetIdBandaQueryResponse>
    {
        public Guid Id { get; set; }

        public GetIdBandaQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetIdBandaQueryResponse
    {
        public BandaOutputDto Banda { get; set; }

        public GetIdBandaQueryResponse(BandaOutputDto banda)
        {
            Banda = banda;
        }

    }
}
