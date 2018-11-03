using AutoMapper;
using Produto.ECM.ViewModels;
using Produto.Domain.Entities;

namespace Produto.ECM.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<CelulaViewModel, Celula>();
            CreateMap<SetorViewModel, Setor>();
        }
    }
}