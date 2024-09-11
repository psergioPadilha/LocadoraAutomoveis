using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using ControleLocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloTaxa;

public class RepositorioTaxa : RepositorioBase<Taxa>, IRepositorioTaxa
{
	public RepositorioTaxa(ControleLocadoraAutomoveisDbContext dbContext) : base(dbContext)
	{

	}

	protected override DbSet<Taxa> ObterRegistros()
	{
		return dbContext.Taxas;
	}

	public List<Taxa> SelecionarMuitos(List<int> idsTaxasSelecionadas)
	{
		return dbContext.Taxas.Where(taxa => idsTaxasSelecionadas.Contains(taxa.Id)).ToList();
	}

	public List<Taxa> Filtrar(Func<Taxa, bool> predicate)
	{
		return ObterRegistros().Where(predicate).ToList();
	}
}