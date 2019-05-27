using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Repositories;
using Produto.Domain.Interfaces.Services;

namespace Produto.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;

        }

        public Usuario Login(string login, string senha)
        {
            return _usuarioRepository.Login(login, senha);
        }
        //---
        //ORQUESTRA, EXECUTA SERVIÇOS DE ALGUM LUGAR PARA ALGUM LUGAR
    }
}
