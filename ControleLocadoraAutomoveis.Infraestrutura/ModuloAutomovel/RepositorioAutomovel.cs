using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;
using ControleLocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModduloAltomovel;

public class RepositorioAutomovel : RepositorioBase<Automovel>, IRepositorioAutomovel
{
	public RepositorioAutomovel(ControleLocadoraAutomoveisDbContext dbContext) : base(dbContext)
	{
	}

	protected override DbSet<Automovel> ObterRegistros()
	{
		return dbContext.Automoveis;
	}

	public override Automovel? SelecionarPorId(int id)
	{
		return ObterRegistros()
			.Include(a => a.GrupoAutomoveis)
			.FirstOrDefault(a => a.Id == id);
	}

	public override List<Automovel> SelecionarTodos()
	{
		return ObterRegistros().Include(a => a.GrupoAutomoveis).ToList();
	}

	public List<Automovel> Filtrar(Func<Automovel, bool> predicate)
	{
		return dbContext.Automoveis.Where(predicate).ToList();
	}
}
