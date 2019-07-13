using PagedList;
using System;
using System.Configuration;

namespace Produto.ECM.Extensions
{
    public static class UtilExtensions
    {
        public static string GetPageInfo(int totalRegistros, IPagedList Model)
        {
            try
            {
                if (totalRegistros == 0)
                    return Resources.Resource1.NenhumRegistroEncontrado;
                else if (totalRegistros == 1)
                    return string.Format(Resources.Resource1.RegistroEncontrado1, totalRegistros.ToString(), Model.PageCount);
                else if (totalRegistros > 1 && (totalRegistros <= Model.PageSize))
                    return string.Format(Resources.Resource1.RegistroEncontrado2, totalRegistros.ToString(), Model.PageCount);
                else
                    return string.Format(Resources.Resource1.RegistroEncontrado3, totalRegistros.ToString(), Model.PageCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetTamanhoPagina()
        {
            string _x = ConfigurationManager.AppSettings["TAMANHO_PAGINA"].ToString();
            int _value;
            if (int.TryParse(_x, out _value))
                return _value;
            else
                return 15;//VALOR DEFAULT
        }

        public static string GetToken(string login, string senha, string token = "")
        {
            //---
            //VALIDA SE TOKEN AINDA É VALIDO
            var _reponse = Models.LoginModel.ValidateWebApiToken(token, login);
            if (token.Length > 0 && _reponse.ToUpper().Equals("TRUE"))
            {
                return token;
            }
            else
            { 
                //---
                //CRIA NOVO TOKEN
                var _token = Models.LoginModel.GenerateWebApiToken(new ViewModels.LoginViewModel()
                {
                    Login = login,
                    Senha = senha
                });
                return _token;
            }
        }
    }
}