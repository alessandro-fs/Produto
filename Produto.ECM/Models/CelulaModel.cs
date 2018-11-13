using Newtonsoft.Json;
using Produto.ECM.Repository;
using Produto.ECM.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Produto.ECM.Models
{
    public class CelulaModel
    {
        public static IEnumerable<CelulaViewModel> GetAll()
        {
            try
            {
                var _request = new RestRequest("api/celulas/GetAll", Method.GET);
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
                var request = new RestRequest("api/celulas/GetById/" + id.ToString(), Method.GET);
                request.AddObject(id);

                var response = new ServiceRepository().Client.Execute<List<CelulaViewModel>>(request);

                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<CelulaViewModel>(response.Content);
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