using AutoMapper;
using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.WebAPI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Produto.WebAPI.Controllers
{
    public class SetoresController : ApiController
    {
        public readonly ISetorAppService _setorApp;

        public SetoresController(ISetorAppService setorApp)
        {
            _setorApp = setorApp;
        }

        [ResponseType(typeof(IEnumerable<SetorViewModel>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var _response = await Task.FromResult(Mapper.Map<IEnumerable<Setor>, IEnumerable<SetorViewModel>>(_setorApp.GetAll()));
            if (_response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_response);
            }
        }

        [ResponseType(typeof(SetorViewModel))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var _response = await Task.FromResult(_setorApp.GetById(id));
                if (_response == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Mapper.Map<Setor, SetorViewModel>(_response));
                }
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IHttpActionResult> Create(SetorViewModel request)
        {
            if (ModelState.IsValid)
            {
                var _response = await Task.FromResult(Mapper.Map<SetorViewModel, Setor>(request));
                if (_response == null)
                {
                    return NotFound();
                }
                else
                {
                    _setorApp.Add(_response);
                    return Ok();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(SetorViewModel))]
        public async Task<IHttpActionResult> Edit(SetorViewModel request)
        {
            if (ModelState.IsValid)
            {
                var _response = await Task.FromResult(Mapper.Map<SetorViewModel, Setor>(request));
                if (_response == null)
                {
                    return NotFound();
                }
                else
                {
                    _setorApp.Update(_response);
                    return Ok();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(SetorViewModel))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var _response = await Task.FromResult(_setorApp.GetById(id));
                if (_response == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Mapper.Map<Setor, SetorViewModel>(_response));
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(SetorViewModel))]
        public async Task<IHttpActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var _response = await Task.FromResult(_setorApp.GetById(id));
                if (_response == null)
                {
                    return NotFound();
                }
                else
                {
                    _setorApp.Remove(_response);
                    return Ok();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
