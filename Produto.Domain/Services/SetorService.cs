using System.Collections.Generic;
using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Repositories;
using Produto.Domain.Interfaces.Services;

namespace Produto.Domain.Services
{
    public class SetorService : ServiceBase<Setor>, ISetorService
    {
        private readonly ISetorRepository _setorRepository;

        public SetorService(ISetorRepository setorRepository)
            : base(setorRepository)
        {
            _setorRepository = setorRepository;
        }

        public IEnumerable<Setor> BuscarPorNome(string nome)
        {
            return _setorRepository.BuscaPorNome(nome);
        }
    }
}
