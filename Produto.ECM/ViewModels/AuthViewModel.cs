using System.ComponentModel.DataAnnotations;
namespace Produto.ECM.ViewModels
{
    public class AuthViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource1), ErrorMessageResourceName = "VSLogin")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource1), ErrorMessageResourceName = "VSSenha")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}