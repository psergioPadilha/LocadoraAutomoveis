using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;
using ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping;

public class AutomovelProfile : Profile
{
	public AutomovelProfile()
	{
		CreateMap<InserirAutomovelViewModel, Automovel>()
			.ForMember(dest => dest.IdEmpresa,
				opt =>
					opt.MapFrom<IdEmpresaValueResolver>())
			.ForMember(dest => dest.Foto,
				opt =>
					opt.MapFrom<FotoValueResolver>());

		CreateMap<EditarAutomovelViewModel, Automovel>()
			.ForMember(dest => dest.Foto,
				opt =>
					opt.MapFrom<FotoValueResolver>());

		CreateMap<Automovel, ListarAutomovelViewModel>()
			.ForMember(dest => dest.GrupoAutomoveis,
				opt =>
					opt.MapFrom(src => src.GrupoAutomoveis!.Descricao));

		CreateMap<Automovel, DetalhesAutomovelViewModel>()
			.ForMember(dest => dest.GrupoAutomoveis,
				opt =>
					opt.MapFrom(src => src.GrupoAutomoveis!.Descricao));

		CreateMap<Automovel, EditarAutomovelViewModel>()
			.ForMember(v => v.Foto,
				opt =>opt.Ignore())
			.ForMember(v => v.GruposAutomoveis,
				opt =>
					opt.MapFrom<GrupoDeAutomoveisValueResolver>());
	}
}