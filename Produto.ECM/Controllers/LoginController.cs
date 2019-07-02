using Facebook;
using Newtonsoft.Json;
using Produto.ECM.Extensions;
using Produto.ECM.ViewModels;
using System;
using System.Dynamic;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
namespace Produto.ECM.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.UrlFb = GetFacebookLoginUrl();
            if (Session["FACEBOOK_ACCESS_TOKEN"] != null)
            {
                var _facebook = new FacebookClient(Session["FACEBOOK_ACCESS_TOKEN"].ToString());
                var _requestFB = _facebook.Get("me");
                string _output = JsonConvert.SerializeObject(_requestFB);
                { }

                FacebookViewModel _fbVM = JsonConvert.DeserializeObject<FacebookViewModel>(_output);
                this.AutenticaUsuario(new UsuarioViewModel() { Nome = _fbVM.name, Login = _fbVM.id });

                //---
                //VALIDAR SE FACEBOOKID EXISTE
                var _usuario = Models.UsuarioModel.GetByFacebookId(_fbVM.id);
                if (_usuario != null)
                {
                    if (_usuario.UsuarioId > 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //---
                        //CADASTRAR USUÁRIO
                        if (Models.UsuarioModel.Create(new UsuarioViewModel()
                        {
                            Nome = _fbVM.name,
                            FacebookAccessToken = Session["FACEBOOK_ACCESS_TOKEN"].ToString(),
                            FacebookId = _fbVM.id
                        }))
                        {
                            //---
                            //REDIRECIONAR PARA TELA DE USUÁRIO PARA COMPLETAR CADASTRO
                            return RedirectToAction("Edit", "Usuarios", new { id = Models.UsuarioModel.GetByFacebookId(_fbVM.id).UsuarioId});
                        }
                        else
                        {
                            this.AddNotification(@Resources.Resource1.FalhaOperacao, NotificationType.ERROR);
                            return View("Index");
                        }
                    }
                }
                else
                {
                    this.AddNotification(@Resources.Resource1.FalhaOperacao, NotificationType.ERROR);
                    return View("Index");
                }
            }
            else
            {
                return View();
            }
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
                    AutenticaUsuario(_usuario);
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
            ViewData.Clear();
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        public string GetFacebookLoginUrl()
        {
            dynamic parameters = new ExpandoObject();
            parameters.client_id = Produto.Shared.Settings.FacebookClientId;
            parameters.redirect_uri = Produto.Shared.Settings.FacebookRedirectUri;
            parameters.response_type = "code";
            parameters.display = "page";
            //var extendedPermissions = "user_about_me,read_stream,publish_stream";
            //parameters.scope = extendedPermissions;
            var _fb = new FacebookClient();
            var url = _fb.GetLoginUrl(parameters);
            return url.ToString();
        }

        public void AutenticaUsuario(UsuarioViewModel usuario)
        {
            Session.Add("LOGADO", "S");
            Session.Add("SESSION_ID", Session.SessionID);
            Session.Add("NOME", string.Format("{0} {1}", usuario.Nome, usuario.Sobrenome));
            ViewBag.NomeFacebook = Session["NOME"];
            FormsAuthentication.SetAuthCookie(usuario.Login, false);
            if (Session["FACEBOOK_ACCESS_TOKEN"] != null)
            {
                //TODO: Guardar no banco
                //VERIFICAR SE USUÁRIO JÁ EXISTE
                //SENÃO EXISTE, INCLUIR
                //SE EXISTE, RESGATAR DADOS
            }
        }
        
    }
}
