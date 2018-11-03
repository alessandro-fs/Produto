using System;
using System.ComponentModel.DataAnnotations;

namespace Produto.ECM.ViewModels
{
    public class SetorViewModel
    {
        [Key]
        public int SetorId { get; set; }
        public int CelulaId { get; set; }
        public virtual CelulaViewModel Celula { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource1), ErrorMessageResourceName = "VSNome")]
        //[Display(ResourceType = typeof(Resources.Resource1), Name = "Nome")]
        [Display(Name = "Nome")]
        [MaxLength(150, ErrorMessageResourceType = typeof(Resources.Resource1), ErrorMessageResourceName = "MaximoCaracteres")]
        [MinLength(2, ErrorMessageResourceType = typeof(Resources.Resource1), ErrorMessageResourceName = "MinimoCaracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public string UsuarioCadastro { get; set; }

        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime DataAlteracao { get; set; }

        [ScaffoldColumn(false)]
        public string UsuarioAlteracao { get; set; }

        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public bool Excluido { get; set; }
    }
}