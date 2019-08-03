using PagedList;
using Produto.ECM.Extensions;
using Produto.ECM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Produto.ECM.Controllers
{
    public class SetoresController : Controller
    {
        // GET: Setores
        [Authorize]
        public ActionResult Index(string ordenacao, int? pagina)
        {
            IEnumerable<SetorViewModel> _setores = Models.SetorModel.GetAll(UtilExtensions.GetToken(Session["USUARIO_LOGIN"].ToString(), Session["USUARIO_SENHA"].ToString(), Session["WEB_API_TOKEN"].ToString()));

            //ORDENAÇÃO DOS DADOS
            ordenacao = (String.IsNullOrEmpty(ordenacao) ? "Nome_Asc" : ordenacao);
            switch (ordenacao)
            {
                case ("Nome_Desc"):
                    _setores = _setores.OrderByDescending(c => c.Nome);
                    break;
                default:
                    _setores = _setores.OrderBy(c => c.Nome);
                    break;

            }
            //PAGINAÇÃO            
            int _tamanhoPagina = UtilExtensions.GetTamanhoPagina();
            pagina = pagina == null ? 1 : pagina;
            pagina = pagina < 1 ? 1 : pagina;
            pagina = _tamanhoPagina >= _setores.Count() ? 1 : pagina;

            int _numeroPagina = (pagina ?? 1);
            IPagedList _model = _setores.ToPagedList(_numeroPagina, _tamanhoPagina);
            _numeroPagina = _model.PageNumber;

            //VIEWBAGS      
            ViewBag.OrdemPor = (ordenacao == "Nome_Asc" || String.IsNullOrEmpty(ordenacao) ? "Nome_Desc" : "Nome_Asc");
            ViewBag.Ordenacao = ordenacao;
            ViewBag.NomeCorrente = string.Empty;
            ViewBag.PaginaAtual = _numeroPagina;
            ViewBag.TotalRegistros = UtilExtensions.GetPageInfo(_setores.Count(), _model);

            return View(_setores.ToPagedList(_numeroPagina, _tamanhoPagina));
        }

        // GET: Setores/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View(Models.SetorModel.GetById(id));
        }

        // GET: Setores/Create
        [Authorize]
        public ActionResult Create()
        {
            IEnumerable<CelulaViewModel> _celulas = Models.CelulaModel.GetAll(UtilExtensions.GetToken(Session["USUARIO_LOGIN"].ToString(), Session["USUARIO_SENHA"].ToString(), Session["WEB_API_TOKEN"].ToString()));
            ViewBag.CelulaId = new SelectList(_celulas, "CelulaId", "Nome");

            return View();
        }

        // POST: Setores/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SetorViewModel setor)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                if (Models.SetorModel.Create(setor, UtilExtensions.GetToken(Session["USUARIO_LOGIN"].ToString(), Session["USUARIO_SENHA"].ToString(), Session["WEB_API_TOKEN"].ToString())))
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
                return View(setor);
            }
        }

        // GET: Setores/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
                return View(Models.SetorModel.Edit(id));
            else
                return View(new SetorViewModel());
        }

        // POST: Setores/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SetorViewModel setor)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                if (Models.SetorModel.Edit(setor))
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
                return View(setor);
            }
        }

        // GET: Setores/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                return View(Models.SetorModel.Delete(id));
            }
            else
            {
                return View(new SetorViewModel());
            }
        }

        // POST: Setores/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                if (Models.SetorModel.DeleteConfirmed(id))
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
