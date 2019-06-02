using Produto.ECM.Extensions;
using Produto.ECM.ViewModels;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Produto.ECM.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel obj)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                var _usuario = Models.LoginModel.Login(obj);
                if (_usuario != null)
                {
                    Session["LOGADO"] = "S";
                    Session["NOME"] = string.Format("{0} {1}", _usuario.Nome, _usuario.Sobrenome);
                    Session["SESSION_ID"] = Session.SessionID;
                    FormsAuthentication.SetAuthCookie(obj.Login, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    this.AddNotification(@Resources.Resource1.FalhaOperacao, NotificationType.ERROR);
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                this.AddNotification(@Resources.Resource1.FalhaOperacao + " - " + ex.Message, NotificationType.ERROR);
                return View("Index");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Index");
        }
    }
}
