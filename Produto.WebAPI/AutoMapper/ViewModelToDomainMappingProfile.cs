using AutoMapper;
using Produto.Domain.Entities;
using Produto.WebAPI.ViewModels;

namespace Produto.WebAPI.AutoMapper
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