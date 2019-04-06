using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Services;

namespace Produto.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }
    }
}
