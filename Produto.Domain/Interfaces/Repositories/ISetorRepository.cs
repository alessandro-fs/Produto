using Produto.Domain.Entities;
using System.Collections.Generic;

namespace Produto.Domain.Interfaces.Repositories
{
    public interface ISetorRepository : IRepositoryBase<Setor>
    {
        IEnumerable<Setor> BuscaPorNome(string nome);
    }
}
