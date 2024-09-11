using ControleLocadoraAutomoveis.Dominio.ModuloFuncionario;
using ControleLocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloFuncionario;

public class RepositorioFuncionario : RepositorioBase<Funcionario>, IRepositorioFuncionario
{
	public RepositorioFuncionario(ControleLocadoraAutomoveisDbContext dbContext) : base(dbContext)
	{
	}

	protected override DbSet<Funcionario> ObterRegistros()
	{
		return dbContext.Funcionarios;
	}

	public override Funcionario? SelecionarPorId(int idFuncionario)
	{
		return dbContext.Funcionarios
			.Include(u => u.Empresa)
			.FirstOrDefault(f => f.Id == idFuncionario);
	}

	public Funcionario? SelecionarPorId(Func<Funcionario, bool> predicate)
	{
		return dbContext.Funcionarios
			.Include(u => u.Empresa)
			.FirstOrDefault(predicate);
	}

	public List<Funcionario> SelecionarTodos(Func<Funcionario, bool> predicate)
	{
		return dbContext.Funcionarios
			.Include(u => u.Empresa)
			.Where(predicate)
			.ToList();
	}

	public List<Funcionario> Filtrar(Func<Funcionario, bool> predicate)
	{
		return ObterRegistros().Include(e => e.Empresa).Where(predicate).ToList();
	}
}