using Produto.ECM.Extensions;
using Produto.ECM.ViewModels;
using System;
using System.Web.Mvc;

namespace Produto.ECM.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection obj)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                var _login = Request.Form[obj.Keys[1]];
                var _senha = Request.Form[obj.Keys[2]];
                if (Models.AuthModel.Auth(new AuthViewModel { Login = _login, Senha = _senha }) != null)
                {
                    Session["LOGADO"] = "S";
                    //---
                    //CREATE SESSION HERE
                    this.AddNotification(@Resources.Resource1.RegistroIncluido, NotificationType.SUCCESS);

                }
                else
                {
                    this.AddNotification(@Resources.Resource1.FalhaOperacao, NotificationType.ERROR);
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                this.AddNotification(@Resources.Resource1.FalhaOperacao + " - " + ex.Message, NotificationType.ERROR);
                return View("Index");
            }
        }
    }
}