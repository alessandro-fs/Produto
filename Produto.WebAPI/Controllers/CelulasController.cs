using AutoMapper;
using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.WebAPI.ViewModels;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Produto.WebAPI.Controllers
{
    public class CelulasController : ApiController
    {
        private readonly ICelulaAppService _celulaApp;
        public CelulasController(ICelulaAppService celulaApp)
        {
            _celulaApp = celulaApp;
        }

        [ResponseType(typeof(IEnumerable<CelulaViewModel>))]
        public IHttpActionResult GetAll()
        {
            var celulaViewModel = Mapper.Map<IEnumerable<Celula>, IEnumerable<CelulaViewModel>>(_celulaApp.GetAll());
            if (celulaViewModel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(celulaViewModel);
            }
        }

        [ResponseType(typeof(CelulaViewModel))]
        public IHttpActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var _celula = _celulaApp.GetById(id);
                if (_celula == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Mapper.Map<Celula, CelulaViewModel>(_celula));
                }
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Create(CelulaViewModel celula)
        {
            if (ModelState.IsValid)
            {
                var _celulaDomain = Mapper.Map<CelulaViewModel, Celula>(celula);
                if (_celulaDomain == null)
                {
                     return NotFound();
                }
                else
                {
                    _celulaApp.Add(_celulaDomain);
                    return Ok();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(CelulaViewModel))]
        public IHttpActionResult Edit(CelulaViewModel celula)
        {
            if (ModelState.IsValid)
            {
                var _celulaDomain = Mapper.Map<CelulaViewModel, Celula>(celula);
                if (_celulaDomain == null)
                {
                    return NotFound();
                }
                else
                {
                    _celulaApp.Update(_celulaDomain);
                    return Ok();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(CelulaViewModel))]
        public IHttpActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var _celula = _celulaApp.GetById(id);
                if (_celula == null)
                {
                    return NotFound();
                }
                else
                {
                    _celulaApp.Remove(_celula);
                    return Ok();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(CelulaViewModel))]
        public IHttpActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var _celula = _celulaApp.GetById(id);
                if (_celula == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Mapper.Map<Celula, CelulaViewModel>(_celula));
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
