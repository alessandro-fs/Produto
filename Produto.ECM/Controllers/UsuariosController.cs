using PagedList;
using Produto.Application.Interface;
using Produto.ECM.Extensions;
using Produto.ECM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Produto.ECM.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        [Authorize]
        public ActionResult Index(string ordenacao, int? pagina)
        {
            try
            {
                IEnumerable<UsuarioViewModel> _usuarios = Models.UsuarioModel.GetAll();

                //ORDENAÇÃO DOS DADOS
                ordenacao = (String.IsNullOrEmpty(ordenacao) ? "Nome_Asc" : ordenacao);
                switch (ordenacao)
                {
                    case ("Nome_Desc"):
                        _usuarios = _usuarios.OrderByDescending(c => c.Nome);
                        break;
                    default:
                        _usuarios = _usuarios.OrderBy(c => c.Nome);
                        break;

                }
                //PAGINAÇÃO            
                int _tamanhoPagina = UtilExtensions.GetTamanhoPagina();
                pagina = pagina == null ? 1 : pagina;
                pagina = pagina < 1 ? 1 : pagina;
                pagina = _tamanhoPagina >= _usuarios.Count() ? 1 : pagina;

                int _numeroPagina = (pagina ?? 1);
                IPagedList _model = _usuarios.ToPagedList(_numeroPagina, _tamanhoPagina);
                _numeroPagina = _model.PageNumber;

                //VIEWBAGS      
                ViewBag.OrdemPor = (ordenacao == "Nome_Asc" || String.IsNullOrEmpty(ordenacao) ? "Nome_Desc" : "Nome_Asc");
                ViewBag.Ordenacao = ordenacao;
                ViewBag.NomeCorrente = string.Empty;
                ViewBag.PaginaAtual = _numeroPagina;
                ViewBag.TotalRegistros = UtilExtensions.GetPageInfo(_usuarios.Count(), _model);

                return View(_usuarios.ToPagedList(_numeroPagina, _tamanhoPagina));

            }
            catch (Exception ex)
            {
                this.AddNotification(@Resources.Resource1.FalhaOperacao + " - " + ex.Message, NotificationType.ERROR);
                return View();
            }
        }

        // GET: Usuarios/Details/5
        [Authorize]
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(Models.UsuarioModel.GetById(id));
        }

        // GET: Usuarios/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                if (Models.UsuarioModel.Create(usuario))
                {
                    this.AddNotification(@Resources.Resource1.RegistroIncluido, NotificationType.SUCCESS);
                }
                else
                {
                    this.AddNotification(@Resources.Resource1.FalhaOperacao, NotificationType.ERROR);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.AddNotification(@Resources.Resource1.FalhaOperacao + " - " + ex.Message, NotificationType.ERROR);
                return View(usuario);
            }
        }

        // GET: Usuarios/Edit/5
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
                return View(Models.UsuarioModel.Edit(id));
            else
                return View(new UsuarioViewModel());
        }

        // POST: Usuarios/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                if (Models.UsuarioModel.Edit(usuario))
                {
                    this.AddNotification(@Resources.Resource1.RegistroAlterado, NotificationType.SUCCESS);
                }
                else
                {
                    this.AddNotification(@Resources.Resource1.FalhaOperacao, NotificationType.ERROR);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.AddNotification(@Resources.Resource1.FalhaOperacao + " - " + ex.Message, NotificationType.ERROR);
                return View(usuario);
            }
        }

        // GET: Usuarios/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                return View(Models.UsuarioModel.Delete(id));
            }
            else
            {
                return View(new UsuarioViewModel());
            }
        }

        // POST: Usuarios/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                if (Models.UsuarioModel.DeleteConfirmed(id))
                {
                    this.AddNotification(@Resources.Resource1.RegistroExcluido, NotificationType.SUCCESS);

                }
                else
                {
                    this.AddNotification(@Resources.Resource1.FalhaOperacao, NotificationType.ERROR);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.AddNotification(@Resources.Resource1.FalhaOperacao + " - " + ex.Message, NotificationType.ERROR);
                return View("Index");
            }
        }
    }
}
