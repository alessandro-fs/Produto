using Facebook;
using Newtonsoft.Json;
using Produto.ECM.ViewModels;
using System.Dynamic;
using System.Web.Mvc;
using System.Web.Security;

namespace Produto.ECM.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View("Index");
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RetornoFb()
        {
            var _fb = new FacebookClient();
            FacebookOAuthResult oauthResult;
            _fb.TryParseOAuthCallbackUrl(Request.Url, out oauthResult);
            if (oauthResult.IsSuccess)
            {
                //---
                //PEGA O ACCESS TOKEN "PERMANENTE"
                dynamic parameters = new ExpandoObject();
                parameters.client_id = Produto.Shared.Settings.FacebookClientId;
                parameters.redirect_uri = Produto.Shared.Settings.FacebookRedirectUri;
                parameters.client_secret = Produto.Shared.Settings.FacebookClientSecret;
                parameters.code = oauthResult.Code;
                dynamic result = _fb.Get("oauth/access_token", parameters);
                var accessToken = result.access_token;
               
                Session.Add("FACEBOOK_ACCESS_TOKEN", accessToken);
            }
            else
            {
                // tratar
            }
            return RedirectToAction("Index");
        }

        
    }
}