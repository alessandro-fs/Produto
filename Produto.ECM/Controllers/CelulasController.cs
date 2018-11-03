using AutoMapper;
using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.ECM.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Produto.ECM.Controllers
{
    public class CelulasController : Controller
    {
        private readonly ICelulaAppService _celulaApp;

        public CelulasController(ICelulaAppService celulaApp)
        {
            _celulaApp = celulaApp;
        }
        // GET: Celulas
        public ActionResult Index()
        {
            var celulaViewModel = Mapper.Map<IEnumerable<Celula>, IEnumerable<CelulaViewModel>>(_celulaApp.GetAll());
            return View(celulaViewModel);
        }

        // GET: Celulas/Details/5
        public ActionResult Details(int id)
        {
            var _celula = _celulaApp.GetById(id);
            var _celulaViewModel = Mapper.Map<Celula, CelulaViewModel>(_celula);
            return View(_celulaViewModel);
        }


        // GET: Celulas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Celulas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CelulaViewModel celula)
        {
            if (ModelState.IsValid)
            {
                var celulaDomain = Mapper.Map<CelulaViewModel,Celula>(celula);
                _celulaApp.Add(celulaDomain);
                return RedirectToAction("Index");
            }
            return View(celula);
        }

        // GET: Celulas/Edit/5
        public ActionResult Edit(int id)
        {
            var _celula = _celulaApp.GetById(id);
            //TODO: ALESSANDRO - CRIAR UM MÉTODO PARA MAPEAR
            var _celulaViewModel = Mapper.Map<Celula, CelulaViewModel>(_celula);
            return View(_celulaViewModel);
        }

        // POST: Celulas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CelulaViewModel celula)
        {
            if (ModelState.IsValid)
            {
                var celulaDomain = Mapper.Map<CelulaViewModel, Celula>(celula);
                _celulaApp.Update(celulaDomain);
                return RedirectToAction("Index");
            }
            return View(celula);
        }

        // GET: Celulas/Delete/5
        public ActionResult Delete(int id)
        {
            var _celula = _celulaApp.GetById(id);
            //TODO: ALESSANDRO - CRIAR UM MÉTODO PARA MAPEAR
            var _celulaViewModel = Mapper.Map<Celula, CelulaViewModel>(_celula);
            return View(_celulaViewModel);
        }

        // POST: Celulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var _celula = _celulaApp.GetById(id);
            _celulaApp.Remove(_celula);
            return RedirectToAction("Index");
        }
    }
}
