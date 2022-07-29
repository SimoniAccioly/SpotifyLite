using MediatR;
using SpofityLite.Application.Account.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
