using Produto.Domain.Entities;

namespace Produto.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario Login(string login, string senha);
    }
}
