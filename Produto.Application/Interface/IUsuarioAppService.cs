using Produto.Domain.Entities;

namespace Produto.Application.Interface
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Usuario Login(string login, string senha);

        Usuario BuscarPorFacebookId(string facebookId);

        bool LoginExiste(string login);
    }
}
