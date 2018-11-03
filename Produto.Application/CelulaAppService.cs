using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Services;

namespace Produto.Application
{

    public class CelulaAppService : AppServiceBase<Celula>, ICelulaAppService
    {
        private readonly ICelulaService _celulaService;

        /// <summary>
        /// CONTRUTOR BASE, INJEÇÃO DE DEPENDÊNCIA
        /// </summary>
        /// <param name="celulaService"></param>
        public CelulaAppService(ICelulaService celulaService)
            :base (celulaService)
        {
            _celulaService = celulaService;
        }
    }
}
