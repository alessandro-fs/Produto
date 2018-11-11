﻿using AutoMapper;
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

        public IEnumerable<CelulaViewModel> GetAll()
        {
            var celulaViewModel = Mapper.Map<IEnumerable<Celula>, IEnumerable<CelulaViewModel>>(_celulaApp.GetAll());
            return celulaViewModel;
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
                return NotFound();
            }
        }

        public bool Create(CelulaViewModel celula)
        {
            if (ModelState.IsValid)
            {
                var celulaDomain = Mapper.Map<CelulaViewModel, Celula>(celula);
                _celulaApp.Add(celulaDomain);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
