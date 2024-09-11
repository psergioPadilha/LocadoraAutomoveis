using ControleLocadoraAutomoveis.Dominio.ModuloCondutor;
using FluentResults;

namespace ControleLocadoraAutomoveis.Aplicacao.ModuloCondutor;

public class ServicoCondutor
{
	private readonly IRepositorioCondutor repositorioCondutor;

	public ServicoCondutor(IRepositorioCondutor repositorioCondutor)
	{
		this.repositorioCondutor = repositorioCondutor;
	}

	public Result<Condutor> Inserir(Condutor condutor)
	{
		var errosValidacao = condutor.Validar();

		if (errosValidacao.Count > 0)
			return Result.Fail(errosValidacao);

		repositorioCondutor.Inserir(condutor);

		return Result.Ok(condutor);
	}

	public Result<Condutor> Editar(Condutor condutorAtualizado)
	{
		var condutor = repositorioCondutor.SelecionarPorId(condutorAtualizado.Id);

		if (condutor is null)
			return Result.Fail("O \"CONDUTOR\" não foi encontrado!");

		var errosValidacao = condutorAtualizado.Validar();

		if (errosValidacao.Count > 0)
			return Result.Fail(errosValidacao);

		condutor.IdCliente = condutorAtualizado.IdCliente;
		condutor.Nome = condutorAtualizado.Nome;
		condutor.Email = condutorAtualizado.Email;
		condutor.Telefone = condutorAtualizado.Telefone;
		condutor.CPF = condutorAtualizado.CPF;
		condutor.CNH = condutorAtualizado.CNH;
		condutor.ValidadeCNH = condutorAtualizado.ValidadeCNH;

		repositorioCondutor.Editar(condutor);

		return Result.Ok(condutor);
	}

	public Result<Condutor> Excluir(int idCondutor)
	{
		var condutor = repositorioCondutor.SelecionarPorId(idCondutor);

		if (condutor is null)
			return Result.Fail("O \"CONDUTOR\" não foi encontrado!");

		repositorioCondutor.Excluir(condutor);

		return Result.Ok(condutor);
	}

	public Result<Condutor> SelecionarPorId(int idCondutor)
	{
		var condutor = repositorioCondutor.SelecionarPorId(idCondutor);

		if (condutor is null)
			return Result.Fail("O \"CONDUTOR\" não foi encontrado!");

		return Result.Ok(condutor);
	}

	public Result<List<Condutor>> SelecionarTodos(int idEmpresa)
	{
		var condutor = repositorioCondutor.Filtrar(c => c.IdEmpresa == idEmpresa);

		return Result.Ok(condutor);
	}
}