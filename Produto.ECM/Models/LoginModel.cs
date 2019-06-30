using Newtonsoft.Json;
using Produto.ECM.Repository;
using Produto.ECM.ViewModels;
using RestSharp;

namespace Produto.ECM.Models
{
    public class LoginModel
    {
        public static UsuarioViewModel Login(LoginViewModel obj)
        {
            try
            {
                var _request = new RestRequest("api/login/auth", Method.POST);
                _request.AddQueryParameter("login", obj.Login);
                _request.AddQueryParameter("senha", obj.Senha);
                var _response = new ServiceRepository().Client.Post(_request);

                if (_response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<UsuarioViewModel>(_response.Content);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}