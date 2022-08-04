using MediatR;
using SpofityLite.Application.Account.Dto;

namespace SpofityLite.Application.Account.Handler.Command
{
    public class EditarUsuarioCommand : IRequest<EditarUsuarioCommandResponse>
    {
        public Guid Id { get; set; }
        public UsuarioInputDto Usuario { get; set; }

        public EditarUsuarioCommand(Guid id, UsuarioInputDto usuario)
        {
            Id = id;
            Usuario = usuario;
        }
    }

    public class EditarUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public EditarUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
