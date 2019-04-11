using AutoMapper;
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
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioAppService _usuarioApp;
        public UsuariosController(IUsuarioAppService usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        [DeflateCompression]
        [ResponseType(typeof(IEnumerable<UsuarioViewModel>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var usuarioViewModel = await Task.FromResult(Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioApp.GetAllAsNoTracking()));
            if (usuarioViewModel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(usuarioViewModel);
            }
        }

        [ResponseType(typeof(UsuarioViewModel))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var _usuario = await Task.FromResult(_usuarioApp.GetById(id));
                if (_usuario == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Mapper.Map<Usuario, UsuarioViewModel>(_usuario));
                }
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IHttpActionResult> Create(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var _usuarioDomain = await Task.FromResult(Mapper.Map<UsuarioViewModel, Usuario>(usuario));
                if (_usuarioDomain == null)
                {
                    return NotFound();
                }
                else
                {
                    _usuarioApp.Add(_usuarioDomain);
                    return Ok();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(UsuarioViewModel))]
        public async Task<IHttpActionResult> Edit(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var _usuarioDomain = await Task.FromResult(Mapper.Map<UsuarioViewModel, Usuario>(usuario));
                if (_usuarioDomain == null)
                {
                    return NotFound();
                }
                else
                {
                    _usuarioApp.Update(_usuarioDomain);
                    return Ok();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(UsuarioViewModel))]
        public async Task<IHttpActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var _usuario = await Task.FromResult(_usuarioApp.GetById(id));
                if (_usuario == null)
                {
                    return NotFound();
                }
                else
                {
                    _usuarioApp.Remove(_usuario);
                    return Ok();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(UsuarioViewModel))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var _usuario = await Task.FromResult(_usuarioApp.GetById(id));
                if (_usuario == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Mapper.Map<Usuario, UsuarioViewModel>(_usuario));
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
