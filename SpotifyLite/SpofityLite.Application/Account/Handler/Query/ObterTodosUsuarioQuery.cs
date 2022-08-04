using MediatR;
using SpofityLite.Application.Account.Dto;

namespace SpofityLite.Application.Account.Handler.Query
{
    public class ObterTodosUsuarioQuery: IRequest<ObterTodosUsuarioQueryResponse>
    {
    }

    public class ObterTodosUsuarioQueryResponse 
    {
        public IList<UsuarioOutputDto> Usuarios { get; set; }

        public ObterTodosUsuarioQueryResponse(IList<UsuarioOutputDto> usuarios)
        {
            Usuarios = usuarios;
        }
    }
}
