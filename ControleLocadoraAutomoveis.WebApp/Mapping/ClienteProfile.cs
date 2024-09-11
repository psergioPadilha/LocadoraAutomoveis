using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloCliente;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping;

public class ClienteProfile : Profile
{
	public ClienteProfile()
	{
		CreateMap<InserirClienteViewModel, Cliente>();
		CreateMap<EditarClienteViewModel, Cliente>();

		CreateMap<Cliente, ListarClienteViewModel>()
			.ForMember(
				dest => dest.TipoCliente,
				opt =>
					opt.MapFrom(x => x.TipoCliente.ToString())
			);

		CreateMap<Cliente, DetalhesClienteViewModel>()
			.ForMember(
				dest => dest.TipoCliente,
				opt =>
					opt.MapFrom(x => x.TipoCliente.ToString())
			);

		CreateMap<Cliente, EditarClienteViewModel>();
	}
}