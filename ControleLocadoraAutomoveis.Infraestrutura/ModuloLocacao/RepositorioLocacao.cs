using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;
using ControleLocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloLocacao;

public class RepositorioLocacao : RepositorioBase<Locacao>, IRepositorioLocacao
{
	public RepositorioLocacao(ControleLocadoraAutomoveisDbContext dbContext) : base(dbContext)
	{

	}

	protected override DbSet<Locacao> ObterRegistros()
	{
		return dbContext.Locacoes;
	}

	public override Locacao? SelecionarPorId(int id)
	{
		return ObterRegistros()
			.Include(l => l.Condutor)
			.Include(l => l.Automovel)
			.Include(l => l.ConfiguracaoCombustivel)
			.Include(l => l.TaxasSelecionadas)
			.FirstOrDefault(l => l.Id == id);
	}

	public override List<Locacao> SelecionarTodos()
	{
		return ObterRegistros()
			.Include(l => l.Condutor)
			.Include(l => l.Automovel)
			.Include(l => l.ConfiguracaoCombustivel)
			.ToList();
	}

	public List<Locacao> Filtrar(Func<Locacao, bool> predicate)
	{
		return ObterRegistros()
			.Include(l => l.Condutor)
			.Include(l => l.Automovel)
			.Include(l => l.ConfiguracaoCombustivel)
			.Where(predicate)
			.ToList();
	}
}