using ControleLocadoraAutomoveis.Dominio.ModuloPlanoDeCobranca;
using ControleLocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloGrupoPlanoDeCobranca;

public class RepositorioPlanoDeCobranca : RepositorioBase<PlanoDeCobranca>, IRepositorioPlanoDeCobranca
{
	public RepositorioPlanoDeCobranca(ControleLocadoraAutomoveisDbContext dbContext) : base(dbContext)
	{
	}

	protected override DbSet<PlanoDeCobranca> ObterRegistros()
	{
		return dbContext.PlanosDeCobrancas;
	}

	public override PlanoDeCobranca? SelecionarPorId(int id)
	{
		return ObterRegistros()
			.Include(p => p.GrupoAutomoveis)
			.FirstOrDefault(p => p.Id == id);
	}

	public override List<PlanoDeCobranca> SelecionarTodos()
	{
		return ObterRegistros()
			.Include(p => p.GrupoAutomoveis)
			.AsNoTracking()
			.ToList();
	}

	public PlanoDeCobranca? FiltrarPlano(Func<PlanoDeCobranca, bool> predicate)
	{
		return ObterRegistros()
			.Include(p => p.GrupoAutomoveis)
			.Where(predicate)
			.FirstOrDefault();
	}

	public List<PlanoDeCobranca> Filtrar(Func<PlanoDeCobranca, bool> predicate)
	{
		return ObterRegistros()
			.Include(p => p.GrupoAutomoveis)
			.Where(predicate)
			.ToList();
	}
}
