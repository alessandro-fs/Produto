using PagedList;
using Produto.ECM.Extensions;
using Produto.ECM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Produto.ECM.Controllers
{
    public class CelulasController : Controller
    {

        [Authorize]// GET: Celulas
        public ActionResult Index(string ordenacao, int? pagina)
        {
            try
            {
                IEnumerable<CelulaViewModel> _celulas = Models.CelulaModel.GetAll(UtilExtensions.GetToken(Session["USUARIO_LOGIN"].ToString(), Session["USUARIO_SENHA"].ToString(), Session["WEB_API_TOKEN"].ToString()));

                //ORDENAÇÃO DOS DADOS
                ordenacao = (String.IsNullOrEmpty(ordenacao) ? "Nome_Asc" : ordenacao);
                switch (ordenacao)
                {
                    case ("Nome_Desc"):
                        _celulas = _celulas.OrderByDescending(c => c.Nome);
                        break;
                    default:
                        _celulas = _celulas.OrderBy(c => c.Nome);
                        break;

                }
                //PAGINAÇÃO            
                int _tamanhoPagina = UtilExtensions.GetTamanhoPagina();
                pagina = pagina == null ? 1 : pagina;
                pagina = pagina < 1 ? 1 : pagina;
                pagina = _tamanhoPagina >= _celulas.Count() ? 1 : pagina;

                int _numeroPagina = (pagina ?? 1);
                IPagedList _model = _celulas.ToPagedList(_numeroPagina, _tamanhoPagina);
                _numeroPagina = _model.PageNumber;

                //VIEWBAGS      
                ViewBag.OrdemPor = (ordenacao == "Nome_Asc" || String.IsNullOrEmpty(ordenacao) ? "Nome_Desc" : "Nome_Asc");
                ViewBag.Ordenacao = ordenacao;
                ViewBag.NomeCorrente = string.Empty;
                ViewBag.PaginaAtual = _numeroPagina;
                ViewBag.TotalRegistros = UtilExtensions.GetPageInfo(_celulas.Count(), _model);

                return View(_celulas.ToPagedList(_numeroPagina, _tamanhoPagina));

            }
            catch (Exception ex)
            {
                this.AddNotification(@Resources.Resource1.FalhaOperacao + " - " + ex.Message, NotificationType.ERROR);
                return View();
            }
        }

        // GET: Celulas/Details/5
        [Authorize]
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(Models.CelulaModel.GetById(id));
        }

        [Authorize]// GET: Celulas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Celulas/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CelulaViewModel celula)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                if (Models.CelulaModel.Create(celula))
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
                return View(celula);
            }
        }

        // GET: Celulas/Edit/5
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
                return View(Models.CelulaModel.Edit(id));
            else
                return View(new CelulaViewModel());
        }

        // POST: Celulas/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CelulaViewModel celula)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                if (Models.CelulaModel.Edit(celula))
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
                return View(celula);
            }
        }

        // GET: Celulas/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                return View(Models.CelulaModel.Delete(id));
            }
            else
            {
                return View(new CelulaViewModel());
            }
        }

        // POST: Celulas/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                if (Models.CelulaModel.DeleteConfirmed(id))
                {
                    this.AddNotification(@Resources.Resource1.RegistroExcluido, NotificationType.SUCCESS);

                }else
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
