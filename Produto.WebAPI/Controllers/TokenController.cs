using Produto.Application.Interface;
using Produto.WebAPI.Helper;
using System.Net;
using System.Security.Claims;
using System.Web.Http;

namespace Produto.WebAPI.Controllers
{
    public class TokenController : ApiController
    {
        private readonly IUsuarioAppService _usuarioApp;
        public TokenController(IUsuarioAppService usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }
        [AllowAnonymous]
        [HttpPost]
        public string GenerateToken(string login, string senha)
        {
            if (CheckUser(login, senha))
            {
                return JwtManagerHelper.GenerateToken(login);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        [NonAction]
        public bool CheckUser(string login, string senha)
        {
            var _usuario = _usuarioApp.Login(login, senha);
            return (_usuario.Login.Equals(login) && senha.Equals(senha)) ? true : false;
        }

        [HttpGet]
        public bool ValidateToken(string token, string login)
        {
            login = null;

            var _simplePrinciple = JwtManagerHelper.GetPrincipal(token);
            var _identity = _simplePrinciple?.Identity as ClaimsIdentity;

            if (_identity == null)
                return false;

            if (!_identity.IsAuthenticated)
                return false;

            var _usernameClaim = _identity.FindFirst(ClaimTypes.Name);
            login = _usernameClaim?.Value;

            if (string.IsNullOrEmpty(login))
                return false;
            else
                return true;

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
    }
}
