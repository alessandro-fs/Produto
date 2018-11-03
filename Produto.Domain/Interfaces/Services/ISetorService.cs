using Produto.Domain.Entities;
using System.Collections.Generic;

namespace Produto.Domain.Interfaces.Services
{
    public interface ISetorService : IServiceBase<Setor>
    {
        IEnumerable<Setor> BuscarPorNome(string nome);
    }
}
