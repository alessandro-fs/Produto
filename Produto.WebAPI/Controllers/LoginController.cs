using AutoMapper;
using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.WebAPI.Filters;
using Produto.WebAPI.ViewModels;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Produto.WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IUsuarioAppService _usuarioApp;
        public LoginController(IUsuarioAppService usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        [DeflateCompression]
        [ResponseType(typeof(UsuarioViewModel))]
        [HttpGet]
        public async Task<IHttpActionResult> Auth(string login, string senha)
        {
            if (ModelState.IsValid)
            {
                senha = Shared.Senha.Encriptar(senha);
                var _usuario = await Task.FromResult(_usuarioApp.Login(login, senha));
                if (_usuario == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Mapper.Map<Usuario, UsuarioViewModel>(_usuario));
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
