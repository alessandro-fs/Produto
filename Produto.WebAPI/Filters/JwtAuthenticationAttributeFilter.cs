using Produto.Application.Interface;
using Produto.WebAPI.Helper;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Produto.WebAPI.Filters
{
    public class JwtAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public string Realm { get; set; }
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
            {
                context.ErrorResult = new AuthenticationFailureResultFilter("Missing Bearer Token", request);
                return;
            }

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResultFilter("Missing Jwt Token", request);
                return;
            }

            var token = authorization.Parameter;
            var principal = await AuthenticateJwtToken(token);

            if (principal == null)
                context.ErrorResult = new AuthenticationFailureResultFilter("Invalid token", request);

            else
                context.Principal = principal;
        }


        private bool ValidateToken(string token, out string login)
        {
            login = null;

            var simplePrinciple = JwtManagerHelper.GetPrincipal(token);
            var identity = simplePrinciple?.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            login = usernameClaim?.Value;

            if (string.IsNullOrEmpty(login))
                return false;

            return ValidateLogin(login);
        }

        private bool ValidateLogin(string login)
        {
            //---
            //TODO: AVALIAR A NECESSIDADE DE VALIDAR SE O USUÁRIO EXISTE NA BASE DE DADOS, DADO QUE O TOKEN FOI GERADO APÓS A AUTENTICAÇÃO, A RESPOSTA É SIM. NESTE CASO SERIA UM DOUBLECHECK
            return true;
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            string _login;

            if (ValidateToken(token, out _login))
            {
                // based on username to get more information from database in order to build local identity
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, _login)
                    // Add more claims if needed: Roles, ...
                };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter = null;

            if (!string.IsNullOrEmpty(Realm))
                parameter = "realm=\"" + Realm + "\"";

            context.ChallengeWith("Bearer", parameter);
        }
    }
}