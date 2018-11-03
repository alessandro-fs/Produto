using System;
using System.Collections.Generic;

namespace Produto.Domain.Entities
{
    public class Celula
    {
        public int CelulaId { get; set; }
        public string Nome { get; set; }

        public DateTime? DataCadastro { get; set; }
        public string UsuarioCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public virtual IEnumerable<Setor> Setores { get; set; }
    }
}
