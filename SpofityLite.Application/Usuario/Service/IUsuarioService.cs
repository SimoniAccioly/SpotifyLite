using SpofityLite.Application.Usuario.Dto;

namespace SpofityLite.Application.Usuario.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Criar(UsuarioInputDto dto);
        Task<List<UsuarioOutputDto>> ObterTodos();
    }
}