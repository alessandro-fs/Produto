using Newtonsoft.Json;
using Produto.ECM.Repository;
using Produto.ECM.ViewModels;
using RestSharp;
using System.Collections.Generic;

namespace Produto.ECM.Models
{
    public class CelulaModel
    {
        public static IEnumerable<CelulaViewModel> GetAll(string token = "")
        {
            try
            {
                var _request = new RestRequest("api/celulas/GetAll", Method.GET);
                if (token.Length > 0)
                    _request.AddHeader("Authorization", "Bearer " + token);
                var _response = new ServiceRepository().Client.Execute<List<CelulaViewModel>>(_request);

                if (_response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<List<CelulaViewModel>>(_response.Content);
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

        public static CelulaViewModel GetById(int id)
        {
            try
            {
                var _request = new RestRequest("api/celulas/GetById/" + id.ToString(), Method.GET);
                _request.AddObject(id);

                var _response = new ServiceRepository().Client.Execute<List<CelulaViewModel>>(_request);

                if (_response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<CelulaViewModel>(_response.Content);
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

        public static bool Create(CelulaViewModel celula)
        {
            try
            {
                var _request = new RestRequest("api/celulas/Create", Method.POST);
                _request.AddObject(celula);
                var _response = new ServiceRepository().Client.Post(_request);

                return _response.IsSuccessful;
            }
            catch
            {
                return false;
            }
        }

        public static CelulaViewModel Edit(int id)
        {
            try
            {
                var _request = new RestRequest("api/celulas/GetById/" + id.ToString(), Method.GET);
                _request.AddObject(id);
                var _response = new ServiceRepository().Client.Execute<List<CelulaViewModel>>(_request);

                if (_response.IsSuccessful)
                    return JsonConvert.DeserializeObject<CelulaViewModel>(_response.Content);
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public static bool Edit(CelulaViewModel celula)
        {
            try
            {
                var _request = new RestRequest("api/celulas/Edit", Method.POST);
                _request.AddObject(celula);
                var _response = new ServiceRepository().Client.Post(_request);
                return _response.IsSuccessful;
            }
            catch
            {
                return false;
            }
        }

        public static CelulaViewModel Delete(int id)
        {
            try
            {
                var _request = new RestRequest("api/celulas/GetById/" + id.ToString(), Method.GET);
                _request.AddObject(id);
                var _response = new ServiceRepository().Client.Execute<List<CelulaViewModel>>(_request);

                if (_response.IsSuccessful)
                    return JsonConvert.DeserializeObject<CelulaViewModel>(_response.Content);
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public static bool DeleteConfirmed(int id)
        {
            try
            {
                var _request = new RestRequest("api/celulas/DeleteConfirmed/" + id.ToString(), Method.DELETE);
                _request.AddObject(id);
                var _response = new ServiceRepository().Client.Delete(_request);
                return _response.IsSuccessful;
            }
            catch
            {
                return false;
            }
        }
    }
}