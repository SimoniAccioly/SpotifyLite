using MediatR;
using SpofityLite.Application.Usuario.Handler.Command;
using SpofityLite.Application.Usuario.Handler.Query;
using SpofityLite.Application.Usuario.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Usuario.Handler
{
    public class UsuarioHandler : IRequestHandler<CreateUsuarioCommand, CreateUsuarioCommandResponse>,
                                IRequestHandler<GetAllUsuarioQuery, GetAllUsuarioQueryResponse>
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<CreateUsuarioCommandResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.Criar(request.Usuario);
            return new CreateUsuarioCommandResponse(result); 
        }

        public async Task<GetAllUsuarioQueryResponse> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.ObterTodos();
            return new GetAllUsuarioQueryResponse(result);
        }
    }
}
