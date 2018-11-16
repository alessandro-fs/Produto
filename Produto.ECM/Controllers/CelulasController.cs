using AutoMapper;
using Newtonsoft.Json;
using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.ECM.Extensions;
using Produto.ECM.Repository;
using Produto.ECM.ViewModels;
using RestSharp;
using System;
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
            return View(Models.CelulaModel.GetAll());
        }

        // GET: Celulas/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(Models.CelulaModel.GetById(id));
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
                return View(Models.CelulaModel.Edit(id));
            else
                return View(new CelulaViewModel());
        }

        // POST: Celulas/Edit/5
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
