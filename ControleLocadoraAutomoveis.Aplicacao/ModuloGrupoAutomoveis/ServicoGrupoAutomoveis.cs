using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using FluentResults;

namespace ControleLocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;

public class ServicoGrupoAutomoveis
{
	private readonly IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

	public ServicoGrupoAutomoveis(IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
	{
		this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
	}

	public Result<GrupoAutomoveis> Inserir(GrupoAutomoveis grupoAutomoveis)
	{
		repositorioGrupoAutomoveis.Inserir(grupoAutomoveis);

		return Result.Ok(grupoAutomoveis);
	}

	public Result<GrupoAutomoveis> Editar(GrupoAutomoveis grupoAutomoveisAtualizado)
	{
		var grupo = repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveisAtualizado.Id);

		if (grupo is null)
			return Result.Fail("O \"GRUPO DE VEÍCULOS\" solicitado não foi encontrado!");

		grupo.Descricao = grupoAutomoveisAtualizado.Descricao;

		repositorioGrupoAutomoveis.Editar(grupo);

		return Result.Ok(grupo);
	}

	public Result<GrupoAutomoveis> Excluir(int id)
	{
		var grupo = repositorioGrupoAutomoveis.SelecionarPorId(id);

		if (grupo is null)
			return Result.Fail("O \"GRUPO DE VEÍCULOS\" solicitado não foi encontrado!");

		repositorioGrupoAutomoveis.Excluir(grupo);

		return Result.Ok(grupo);
	}

	public Result<GrupoAutomoveis> SelecionarPorId(int id)
	{
		var grupo = repositorioGrupoAutomoveis.SelecionarPorId(id);

		if (grupo is null)
			return Result.Fail("O \"GRUPO DE VEÍCULOS\" solicitado não foi encontrado");

		return Result.Ok(grupo);
	}

	public Result<List<GrupoAutomoveis>> SelecionarTodos(int idEmpresa)
	{
		var grupos = repositorioGrupoAutomoveis.Filtrar(g => g.IdEmpresa == idEmpresa);

		return Result.Ok(grupos);
	}
}
