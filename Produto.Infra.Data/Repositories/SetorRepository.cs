using System.Collections.Generic;
using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Repositories;
using System.Linq;
namespace Produto.Infra.Data.Repositories
{
    public class SetorRepository : RepositoryBase<Setor>, ISetorRepository
    {
        public IEnumerable<Setor> BuscaPorNome(string nome)
        {
            return Db.Setores.Where(s => s.Nome == nome);
        }
    }
}
