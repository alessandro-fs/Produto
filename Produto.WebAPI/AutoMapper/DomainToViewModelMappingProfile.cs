using AutoMapper;
using Produto.Domain.Entities;
using Produto.WebAPI.ViewModels;

namespace Produto.WebAPI.AutoMapper
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