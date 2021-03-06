using SpofityLite.Application.Account.Dto;


namespace SpofityLite.Application.Account.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Criar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> Editar(Guid id, UsuarioInputDto dto);
        Task<UsuarioOutputDto> Excluir(Guid id);
        Task<List<UsuarioOutputDto>> ObterTodos();
        Task<UsuarioOutputDto> ObterPorId(Guid id);
       
    }
}