using AutoMapper;
using Produto.ECM.ViewModels;
using Produto.Domain.Entities;
namespace Produto.ECM.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Celula, CelulaViewModel>();
            CreateMap<Setor, SetorViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();

        }
    }
}