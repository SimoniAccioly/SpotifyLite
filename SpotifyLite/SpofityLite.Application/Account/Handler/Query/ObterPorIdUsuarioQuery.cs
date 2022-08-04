using MediatR;
using SpofityLite.Application.Account.Dto;

namespace SpofityLite.Application.Account.Handler.Query
{
    public class ObterPorIdUsuarioQuery : IRequest<ObterPorIdUsuarioQueryResponse>
    {
        public Guid Id { get; set; }

        public ObterPorIdUsuarioQuery(Guid id)
        {
            Id = id;
        }
    }

    public class ObterPorIdUsuarioQueryResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public ObterPorIdUsuarioQueryResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }

    }
}
