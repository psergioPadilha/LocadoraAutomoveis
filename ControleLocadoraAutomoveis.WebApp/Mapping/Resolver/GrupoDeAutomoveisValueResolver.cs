using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;
public class GrupoDeAutomoveisValueResolver : IValueResolver<object, object, IEnumerable<SelectListItem>?>
{
	private readonly IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

	public GrupoDeAutomoveisValueResolver(IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
	{
		this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
	}

	public IEnumerable<SelectListItem>? Resolve(object source, object destination, IEnumerable<SelectListItem>? destMember, ResolutionContext context)
	{
		return repositorioGrupoAutomoveis.SelecionarTodos()
			.Select(g => new SelectListItem(g.Descricao, g.Id.ToString()));
	}
}
