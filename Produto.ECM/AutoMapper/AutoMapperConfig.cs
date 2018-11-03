using AutoMapper;

namespace Produto.ECM.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {

            Mapper.Initialize(cfg => {
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });

        }
    }
}