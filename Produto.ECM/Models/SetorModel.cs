using Newtonsoft.Json;
using Produto.ECM.Repository;
using Produto.ECM.ViewModels;
using RestSharp;
using System.Collections.Generic;

namespace Produto.ECM.Models
{
    public class SetorModel
    {
        public static IEnumerable<SetorViewModel> GetAll()
        {
            try
            {
                var _request = new RestRequest("api/setores/GetAll", Method.GET);
                var _response = new ServiceRepository().Client.Execute<List<SetorViewModel>>(_request);

                if (_response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<List<SetorViewModel>>(_response.Content);
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

        public static SetorViewModel GetById(int id)
        {
            try
            {
                var _request = new RestRequest("api/setores/GetById/" + id.ToString(), Method.GET);
                _request.AddObject(id);

                var _response = new ServiceRepository().Client.Execute<List<SetorViewModel>>(_request);

                if (_response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<SetorViewModel>(_response.Content);
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

        public static bool Create(SetorViewModel obj)
        {
            try
            {
                var _request = new RestRequest("api/setores/Create", Method.POST);
                _request.AddObject(obj);
                var _response = new ServiceRepository().Client.Post(_request);

                return _response.IsSuccessful;
            }
            catch
            {
                return false;
            }
        }

        public static SetorViewModel Edit(int id)
        {
            try
            {
                var _request = new RestRequest("api/setores/GetById/" + id.ToString(), Method.GET);
                _request.AddObject(id);
                var _response = new ServiceRepository().Client.Execute<List<SetorViewModel>>(_request);

                if (_response.IsSuccessful)
                    return JsonConvert.DeserializeObject<SetorViewModel>(_response.Content);
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public static bool Edit(SetorViewModel celula)
        {
            try
            {
                var _request = new RestRequest("api/setores/Edit", Method.POST);
                _request.AddObject(celula);
                var _response = new ServiceRepository().Client.Post(_request);
                return _response.IsSuccessful;
            }
            catch
            {
                return false;
            }
        }

        public static SetorViewModel Delete(int id)
        {
            try
            {
                var _request = new RestRequest("api/setores/GetById/" + id.ToString(), Method.GET);
                _request.AddObject(id);
                var _response = new ServiceRepository().Client.Execute<List<SetorViewModel>>(_request);

                if (_response.IsSuccessful)
                    return JsonConvert.DeserializeObject<SetorViewModel>(_response.Content);
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
                var _request = new RestRequest("api/setores/DeleteConfirmed/" + id.ToString(), Method.DELETE);
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