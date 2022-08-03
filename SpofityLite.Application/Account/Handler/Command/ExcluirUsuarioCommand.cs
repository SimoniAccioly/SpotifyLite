using MediatR;
using SpofityLite.Application.Account.Dto;

namespace SpofityLite.Application.Account.Handler.Command
{
    public class ExcluirUsuarioCommand : IRequest<ExcluirUsuarioCommandResponse>
    {
        public Guid Id { get; set; }

        public ExcluirUsuarioCommand(Guid id)
        {
            Id = id;
        }
    }

    public class ExcluirUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public ExcluirUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
