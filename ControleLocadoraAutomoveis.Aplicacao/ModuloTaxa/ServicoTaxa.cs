using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using FluentResults;

namespace ControleLocadoraAutomoveis.Aplicacao.ModuloTaxa;

public class ServicoTaxa
{
	private readonly IRepositorioTaxa repositorioTaxa;

	public ServicoTaxa(IRepositorioTaxa repositorioTaxa)
	{
		this.repositorioTaxa = repositorioTaxa;
	}

	public Result<Taxa> Inserir(Taxa taxa)
	{
		var errosValidacao = taxa.Validar();

		if (errosValidacao.Count > 0)
			return Result.Fail(errosValidacao);

		repositorioTaxa.Inserir(taxa);

		return Result.Ok(taxa);
	}

	public Result<Taxa> Editar(Taxa taxaAtualizada)
	{
		var taxa = repositorioTaxa.SelecionarPorId(taxaAtualizada.Id);

		if (taxa is null)
			return Result.Fail("A \"TAXA\" não foi encontrada!");

		var errosValidacao = taxaAtualizada.Validar();

		if (errosValidacao.Count > 0)
			return Result.Fail(errosValidacao);

		taxa.Descricao = taxaAtualizada.Descricao;
		taxa.Valor = taxaAtualizada.Valor;
		taxa.TipoCobranca = taxaAtualizada.TipoCobranca;

		return Result.Ok(taxa);
	}

	public Result<Taxa> Excluir(int idTaxa)
	{
		var taxa = repositorioTaxa.SelecionarPorId(idTaxa);

		if (taxa is null)
			return Result.Fail("A \"TAXA\" não foi encontrada!");

		repositorioTaxa.Excluir(taxa);

		return Result.Ok(taxa);
	}

	public Result<Taxa> SelecionarPorId(int idTaxa)
	{
		var taxa = repositorioTaxa.SelecionarPorId(idTaxa);

		if (taxa is null)
			return Result.Fail("A \"TAXA\" não foi encontrada!");

		return Result.Ok(taxa);
	}

	public Result<List<Taxa>> SelecionarTodos(int idEmpresa)
	{
		var taxas = repositorioTaxa.Filtrar(l => l.IdEmpresa == idEmpresa);

		return Result.Ok(taxas);
	}
}