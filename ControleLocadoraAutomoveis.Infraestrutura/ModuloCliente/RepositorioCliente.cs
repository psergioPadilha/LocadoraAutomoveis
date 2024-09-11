using ControleLocadoraAutomoveis.Dominio.ModuloCliente;
using ControleLocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloCliente;
public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
{
	public RepositorioCliente(ControleLocadoraAutomoveisDbContext dbContext) : base(dbContext)
	{

	}

	protected override DbSet<Cliente> ObterRegistros()
	{
		return dbContext.Clientes;
	}

	public List<Cliente> Filtrar(Func<Cliente, bool> predicate)
	{
		return dbContext.Clientes.Where(predicate).ToList();
	}
}