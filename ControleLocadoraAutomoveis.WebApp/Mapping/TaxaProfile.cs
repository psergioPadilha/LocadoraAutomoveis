using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping;

public class TaxaProfile : Profile
{
	public TaxaProfile()
	{
        CreateMap<InserirTaxaViewModel, Taxa>()
            .ForMember(dest => dest.IdEmpresa, 
                opt => 
                    opt.MapFrom<IdEmpresaValueResolver>());

        CreateMap<EditarTaxaViewModel, Taxa>();

        CreateMap<Taxa, ListarTaxaViewModel>()
            .ForMember(
                dest => dest.TipoCobranca,
                opt =>
                    opt.MapFrom(x => x.TipoCobranca.ToString())
            );

        CreateMap<Taxa, DetalhesTaxaViewModel>()
            .ForMember(
                dest => dest.TipoCobranca,
                opt => 
                    opt.MapFrom(x => x.TipoCobranca.ToString())
            );

        CreateMap<Taxa, EditarTaxaViewModel>();
    }
}