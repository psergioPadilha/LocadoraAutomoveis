using ControleLocadoraAutomoveis.Dominio.ModuloCondutor;
using ControleLocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloCondutor;

public class RepositorioCondutor : RepositorioBase<Condutor>, IRepositorioCondutor
{
	public RepositorioCondutor(ControleLocadoraAutomoveisDbContext dbContext) : base(dbContext)
	{

	}

	protected override DbSet<Condutor> ObterRegistros()
	{
		return dbContext.Condutores;
	}

	public override Condutor? SelecionarPorId(int id)
	{
		return ObterRegistros()
			.Include(c => c.Cliente)
			.FirstOrDefault(c => c.Id == id);
	}

	public override List<Condutor> SelecionarTodos()
	{
		return ObterRegistros()
			.Include(c => c.Cliente)
			.ToList();
	}

	public List<Condutor> Filtrar(Func<Condutor, bool> predicate)
	{
		return ObterRegistros().Include(c => c.Cliente).Where(predicate).ToList();
	}
}