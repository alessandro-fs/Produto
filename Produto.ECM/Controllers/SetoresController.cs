using AutoMapper;
using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.ECM.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Produto.ECM.Controllers
{
    public class SetoresController : Controller
    {
        private readonly ISetorAppService _setorApp;
        private readonly ICelulaAppService _celulaApp;
        public SetoresController(ISetorAppService setorApp, ICelulaAppService celulaApp)
        {
            _setorApp = setorApp;
            _celulaApp = celulaApp;
        }
        // GET: Setores
        [Authorize]
        public ActionResult Index()
        {
            var setorViewModel = Mapper.Map<IEnumerable<Setor>, IEnumerable<SetorViewModel>>(_setorApp.GetAll());
            return View(setorViewModel);
        }

        // GET: Setores/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var _setor = _setorApp.GetById(id);
            var _setorViewModel = Mapper.Map<Setor, SetorViewModel>(_setor);
            return View(_setorViewModel);
        }

        // GET: Setores/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CelulaId = new SelectList(_celulaApp.GetAll(), "CelulaId", "Nome");
            return View();
        }

        // POST: Setores/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SetorViewModel setor)
        {
            if (ModelState.IsValid)
            {
                var _setor = Mapper.Map<SetorViewModel, Setor>(setor);
                _setorApp.Add(_setor);
                return RedirectToAction("Index");
            }
            ViewBag.CelulaId = new SelectList(_celulaApp.GetAll(), "CelulaId", "Nome", setor.CelulaId);

            return View(setor);
        }

        // GET: Setores/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var _setor = _setorApp.GetById(id);
            //TODO: ALESSANDRO - CRIAR UM MÉTODO PARA MAPEAR
            var _setorViewModel = Mapper.Map<Setor, SetorViewModel>(_setor);
            ViewBag.CelulaId = new SelectList(_celulaApp.GetAll(), "CelulaId", "Nome", _setorViewModel.CelulaId);

            return View(_setorViewModel);
        }

        // POST: Setores/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SetorViewModel setor)
        {
            if (ModelState.IsValid)
            {
                var _setor = Mapper.Map<SetorViewModel, Setor>(setor);
                _setorApp.Update(_setor);
                return RedirectToAction("Index");
            }
            return View(setor);
        }

        // GET: Setores/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var _setor = _setorApp.GetById(id);
            //TODO: ALESSANDRO - CRIAR UM MÉTODO PARA MAPEAR
            var _setorViewModel = Mapper.Map<Setor, SetorViewModel>(_setor);
            return View(_setorViewModel);
        }

        // POST: Setores/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var _setor = _setorApp.GetById(id);
            _setorApp.Remove(_setor);
            return RedirectToAction("Index");
        }
    }
}
