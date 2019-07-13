using Produto.WebAPI.Helper;
using System.Net;
using System.Security.Claims;
using System.Web.Http;

namespace Produto.WebAPI.Controllers
{
    public class TokenController : ApiController
    {
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
            //TODO: VALIDAR ACESSO NO BANCO DE DADOS
            return (login.Equals("alesfsi") && senha.Equals(Shared.Senha.Encriptar("123"))) ? true : false;
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
