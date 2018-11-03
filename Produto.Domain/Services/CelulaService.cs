using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Repositories;
using Produto.Domain.Interfaces.Services;

namespace Produto.Domain.Services
{
    public class CelulaService : ServiceBase<Celula>, ICelulaService
    {
        private readonly ICelulaRepository _celulaRepository;

        public CelulaService(ICelulaRepository celulaRepository)
            :base(celulaRepository)
        {
            _celulaRepository = celulaRepository;

        }
        //---
        //ORQUESTRA, EXECUTA SERVIÇOS DE ALGUM LUGAR PARA ALGUM LUGAR
    }
}
