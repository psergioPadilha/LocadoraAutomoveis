using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloCondutor;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping;

public class CondutorProfile : Profile
{
	public CondutorProfile()
	{
		CreateMap<FormularioCondutorViewModel, Condutor>();

		CreateMap<Condutor, ListarCondutorViewModel>()
			.ForMember(dest => dest.Cliente,
				opt =>
					opt.MapFrom(c => c.Cliente!.Nome))
			.ForMember(dest => dest.ValidadeCNH,
				opt =>
					opt.MapFrom(c => c.ValidadeCNH.ToShortDateString()));

		CreateMap<Condutor, DetalhesCondutorViewModel>()
			.ForMember(dest => dest.Cliente,
				opt =>
					opt.MapFrom(c => c.Cliente!.Nome))
			.ForMember(dest => dest.ValidadeCNH,
				opt =>
					opt.MapFrom(c => c.ValidadeCNH.ToShortDateString()));
	}
}