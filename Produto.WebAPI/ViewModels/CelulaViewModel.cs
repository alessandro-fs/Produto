using System;

namespace Produto.WebAPI.ViewModels
{
    public class CelulaViewModel
    {
        public int CelulaId { get; set; }

        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }

        public string UsuarioCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public string UsuarioAlteracao { get; set; }

        public bool Ativo { get; set; }

        public bool Excluido { get; set; }
    }
}