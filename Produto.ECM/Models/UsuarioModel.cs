using Newtonsoft.Json;
using Produto.ECM.Repository;
using Produto.ECM.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Produto.ECM.Models
{
    public class UsuarioModel
    {
        public static IEnumerable<UsuarioViewModel> GetAll(string token = "")
        {
            try
            {
                var _request = new RestRequest("api/usuarios/GetAll", Method.GET);
                if (token.Length > 0)
                    _request.AddHeader("Authorization", "Bearer " + token);
                var _response = new ServiceRepository().Client.Execute<List<UsuarioViewModel>>(_request);

                if (_response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<List<UsuarioViewModel>>(_response.Content);
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

        public static UsuarioViewModel GetById(int id, string token = "")
        {
            try
            {
                var _request = new RestRequest("api/usuarios/GetById/" + id.ToString(), Method.GET);
                if (token.Length > 0)
                    _request.AddHeader("Authorization", "Bearer " + token);

                _request.AddObject(id);

                var _response = new ServiceRepository().Client.Execute<List<UsuarioViewModel>>(_request);

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

        public static bool Create(UsuarioViewModel usuario, string token = "")
        {
            try
            {
                var _request = new RestRequest("api/usuarios/Create", Method.POST);
                _request.AddObject(usuario);

                if (token.Length > 0)
                    _request.AddHeader("Authorization", "Bearer " + token);

                var _response = new ServiceRepository().Client.Post(_request);

                return _response.IsSuccessful;
            }
            catch
            {
                return false;
            }
        }

        public static UsuarioViewModel Edit(int id, string token = "")
        {
            try
            {
                var _request = new RestRequest("api/usuarios/GetById/" + id.ToString(), Method.GET);
                _request.AddObject(id);

                if (token.Length > 0)
                    _request.AddHeader("Authorization", "Bearer " + token);

                var _response = new ServiceRepository().Client.Execute<List<UsuarioViewModel>>(_request);

                if (_response.IsSuccessful)
                    return JsonConvert.DeserializeObject<UsuarioViewModel>(_response.Content);
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public static bool Edit(UsuarioViewModel usuario, string token = "")
        {
            try
            {
                var _request = new RestRequest("api/usuarios/Edit", Method.POST);
                _request.AddObject(usuario);

                if (token.Length > 0)
                    _request.AddHeader("Authorization", "Bearer " + token);

                var _response = new ServiceRepository().Client.Post(_request);
                return _response.IsSuccessful;
            }
            catch
            {
                return false;
            }
        }

        public static UsuarioViewModel Delete(int id, string token = "")
        {
            try
            {
                var _request = new RestRequest("api/usuarios/GetById/" + id.ToString(), Method.GET);
                _request.AddObject(id);

                if (token.Length > 0)
                    _request.AddHeader("Authorization", "Bearer " + token);

                var _response = new ServiceRepository().Client.Execute<List<UsuarioViewModel>>(_request);

                if (_response.IsSuccessful)
                    return JsonConvert.DeserializeObject<UsuarioViewModel>(_response.Content);
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public static bool DeleteConfirmed(int id, string token = "")
        {
            try
            {
                var _request = new RestRequest("api/usuarios/DeleteConfirmed/" + id.ToString(), Method.DELETE);
                _request.AddObject(id);

                if (token.Length > 0)
                    _request.AddHeader("Authorization", "Bearer " + token);

                var _response = new ServiceRepository().Client.Delete(_request);
                return _response.IsSuccessful;
            }
            catch
            {
                return false;
            }
        }

        #region FACEBOOK METHODS
        public static UsuarioViewModel GetByFacebookId(string facebookId)
        {
            try
            {
                //var _request = new RestRequest("api/usuarios/GetByFacebookId/" + facebookId, Method.GET);

                var _request = new RestRequest("api/usuarios/GetByFacebookId/", Method.GET);
                _request.AddParameter("id", facebookId);

                var _response = new ServiceRepository().Client.Execute<List<UsuarioViewModel>>(_request);

                if (_response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<UsuarioViewModel>(_response.Content);
                }
                else
                {
                    return new UsuarioViewModel();
                }
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}