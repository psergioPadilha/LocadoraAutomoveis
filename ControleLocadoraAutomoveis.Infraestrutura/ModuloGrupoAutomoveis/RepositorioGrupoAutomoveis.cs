using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloGrupoAutomoveis;
public class RepositorioGrupoAutomoveis : RepositorioBase<GrupoAutomoveis>, IRepositorioGrupoAutomoveis
{
	public RepositorioGrupoAutomoveis(ControleLocadoraAutomoveisDbContext dbContext) : base(dbContext)
	{

	}

	protected override DbSet<GrupoAutomoveis> ObterRegistros()
	{
		return dbContext.GruposAutomoveis;
	}

	public List<GrupoAutomoveis> Filtrar(Func<GrupoAutomoveis, bool> predicate)
	{
		return dbContext.GruposAutomoveis.Where(predicate).ToList();
	}
}
