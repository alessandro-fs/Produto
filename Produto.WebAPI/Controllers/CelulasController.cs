using AutoMapper;
using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.WebAPI.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace Produto.WebAPI.Controllers
{
    public class CelulasController : ApiController
    {
        private readonly ICelulaAppService _celulaApp;
        public CelulasController(ICelulaAppService celulaApp)
        {
            _celulaApp = celulaApp;
        }

        public IEnumerable<CelulaViewModel> GetAll()
        {
            var celulaViewModel = Mapper.Map<IEnumerable<Celula>, IEnumerable<CelulaViewModel>>(_celulaApp.GetAll());
            return celulaViewModel;
        }
    }
}
