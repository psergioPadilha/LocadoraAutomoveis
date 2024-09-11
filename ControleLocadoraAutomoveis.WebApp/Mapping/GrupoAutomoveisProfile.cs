using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping;

public class GrupoAutomoveisProfile : Profile
{
	public GrupoAutomoveisProfile()
	{
		CreateMap<InserirGrupoAutomoveisViewModel, GrupoAutomoveis>()
			.ForMember(dest => dest.IdEmpresa,
				opt => 
					opt.MapFrom<IdEmpresaValueResolver>());

		CreateMap<EditarGrupoAutomoveisViewModel, GrupoAutomoveis>();

		CreateMap<GrupoAutomoveis, ListarGrupoAutomoveisViewModel>();
		CreateMap<GrupoAutomoveis, DetalhesGrupoAutomoveisViewModel>();
		CreateMap<GrupoAutomoveis, EditarGrupoAutomoveisViewModel>();
	}
}