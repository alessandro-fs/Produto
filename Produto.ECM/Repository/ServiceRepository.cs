using Produto.ECM.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Produto.ECM.Repository
{
    public class ServiceRepository
    {
        public RestClient Client { get; set; }
        public ServiceRepository()
        {
            Client = new RestClient(ConfigurationManager.AppSettings["URL_WEB_API"].ToString());
        }
    }
}