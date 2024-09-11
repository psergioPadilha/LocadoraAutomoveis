using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloCombustivel;
using ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping;

public class ConfiguracaoCombustivelProfile : Profile
{
    public ConfiguracaoCombustivelProfile()
    {
        CreateMap<FormularioConfiguracaoCombustivelViewModel, ConfiguracaoCombustivel>()
            .ForMember(dest => dest.IdEmpresa,
                opt =>
                    opt.MapFrom<IdEmpresaValueResolver>());

        CreateMap<ConfiguracaoCombustivel, FormularioConfiguracaoCombustivelViewModel>();
    }
}