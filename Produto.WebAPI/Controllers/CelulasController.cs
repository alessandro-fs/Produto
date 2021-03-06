﻿using AutoMapper;
using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.WebAPI.Filters;
using Produto.WebAPI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        [DeflateCompression]
        [ResponseType(typeof(IEnumerable<CelulaViewModel>))]
        [JwtAuthentication]
        public async Task<IHttpActionResult> GetAll()
        {
            var celulaViewModel = await Task.FromResult(Mapper.Map<IEnumerable<Celula>, IEnumerable<CelulaViewModel>>(_celulaApp.GetAllAsNoTracking()));
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
        [JwtAuthentication]
        public async Task<IHttpActionResult> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var _celula = await Task.FromResult(_celulaApp.GetById(id));
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

        [JwtAuthentication]
        public async Task<IHttpActionResult> Create(CelulaViewModel celula)
        {
            if (ModelState.IsValid)
            {
                var _celulaDomain = await Task.FromResult(Mapper.Map<CelulaViewModel, Celula>(celula));
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
        [JwtAuthentication]
        public async Task<IHttpActionResult> Edit(CelulaViewModel celula)
        {
            if (ModelState.IsValid)
            {
                var _celulaDomain = await Task.FromResult(Mapper.Map<CelulaViewModel, Celula>(celula));
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
        [JwtAuthentication]
        public async Task<IHttpActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var _celula = await Task.FromResult(_celulaApp.GetById(id));
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
        [JwtAuthentication]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var _celula = await Task.FromResult(_celulaApp.GetById(id));
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
