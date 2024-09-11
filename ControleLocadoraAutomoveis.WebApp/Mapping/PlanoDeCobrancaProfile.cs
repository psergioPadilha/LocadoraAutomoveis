using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloPlanoDeCobranca;
using ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping;

public class PlanoDeCobrancaProfile : Profile
{
	public PlanoDeCobrancaProfile()
	{
		CreateMap<InserirPlanoDeCobrancaViewModel, PlanoDeCobranca>();
		CreateMap<EditarPlanoDeCobrancaViewModel, PlanoDeCobranca>();
		CreateMap<PlanoDeCobranca, ListarPlanoDeCobrancaViewModel>()
			.ForMember(
				dest => dest.GrupoAutomoveis,
				opt =>
                    opt.MapFrom(src => src.GrupoAutomoveis!.Descricao));

		CreateMap<PlanoDeCobranca, DetalhesPlanoDeCobrancaViewModel>()
			.ForMember(dest => dest.GrupoAutomoveis,
				opt =>
                    opt.MapFrom(src => src.GrupoAutomoveis!.Descricao));

		CreateMap<PlanoDeCobranca, EditarPlanoDeCobrancaViewModel>()
			.ForMember(dest => dest.GruposAutomoveis,
				opt =>
                    opt.MapFrom<GrupoDeAutomoveisValueResolver>());
	}
}