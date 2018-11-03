using System.Collections.Generic;
using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Services;

namespace Produto.Application
{
    public class SetorAppService : AppServiceBase<Setor>, ISetorAppService
    {
        private readonly ISetorService _setorService;

        public SetorAppService(ISetorService setorService)
            : base(setorService)
        {
            _setorService = setorService;
        }

        public IEnumerable<Setor> BuscarPorNome(string nome)
        {
            return _setorService.BuscarPorNome(nome);
        }
    }
}
