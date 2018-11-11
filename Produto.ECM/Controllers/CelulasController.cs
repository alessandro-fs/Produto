﻿using AutoMapper;
using Newtonsoft.Json;
using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.ECM.Repository;
using Produto.ECM.ViewModels;
using RestSharp;
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
            //DESCONTINUANDO A CHAMADA DIRETO DA UI
            //var celulaViewModel = Mapper.Map<IEnumerable<Celula>, IEnumerable<CelulaViewModel>>(_celulaApp.GetAll());
            //return View(celulaViewModel);
            //---
            //CHAMANDO A CAMADA DE INFRA PELA WEBAPI
            var request = new RestRequest("api/celulas/GetAll", Method.GET);
            var response = new ServiceRepository().Client.Execute<List<CelulaViewModel>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<CelulaViewModel>>(response.Content);
                return View(data);
            }
            else
            {
                return View();
            }
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
                var request = new RestRequest("api/celulas/Create", Method.POST);
                request.AddObject(celula);
                var response = new ServiceRepository().Client.Post(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<bool>(response.Content);
                    if (data)
                        return RedirectToAction("Index");
                }
            }
            return View(celula);
        }

        // GET: Celulas/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var request = new RestRequest("api/celulas/GetById/" + id.ToString(), Method.GET);
            request.AddObject(id);

            var response = new ServiceRepository().Client.Execute<List<CelulaViewModel>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<CelulaViewModel>(response.Content);
                return View(data);
            }
            else
            {
                return View(new CelulaViewModel());
            }
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
