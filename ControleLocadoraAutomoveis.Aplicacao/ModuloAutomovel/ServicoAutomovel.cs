using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using FluentResults;

namespace ControleLocadoraAutomoveis.Aplicacao.ModuloAutomovel;

public class ServicoAutomovel
{
	private readonly IRepositorioAutomovel repositorio;

	public ServicoAutomovel(IRepositorioAutomovel repositorio)
	{
		this.repositorio = repositorio;
	}

	public Result<Automovel> Inserir(Automovel automovel)
	{
		repositorio.Inserir(automovel);

		return Result.Ok(automovel);
	}

	public Result<Automovel> Editar(Automovel automovelAtualizado)
	{
		var automovel = repositorio.SelecionarPorId(automovelAtualizado.Id);

		if (automovel is null)
			return Result.Fail("O \"VEÍCULO\" solicitado não foi encontrado!");

		automovel.Marca = automovelAtualizado.Marca;
		automovel.Modelo = automovelAtualizado.Modelo;
		automovel.CapacidadeTanque = automovelAtualizado.CapacidadeTanque;
		automovel.Foto = automovelAtualizado.Foto;
		automovel.IdGrupoAutomoveis = automovelAtualizado.IdGrupoAutomoveis;
		automovel.TipoCcombustivel = automovelAtualizado.TipoCcombustivel;

		repositorio.Editar(automovel);

		return Result.Ok(automovel);
	}

	public Result<Automovel> Excluir(int id)
	{
		var automovel = repositorio.SelecionarPorId(id);

		if (automovel is null)
			return Result.Fail("O \"VEÍCULO\" solicitado não foi encontrado!");

		repositorio.Excluir(automovel);

		return Result.Ok(automovel);
	}

	public Result<Automovel> SelecionarPorId(int id)
	{
		var automovel = repositorio.SelecionarPorId(id);

		if (automovel is null)
			return Result.Fail("O \"VEÍCULO\" solicitado não foi encontrado!");

		return Result.Ok(automovel);
	}

	public Result<List<Automovel>> SelecionarTodos(int idEmpresa)
	{
		var automovel = repositorio.Filtrar(l =>
            l.IdEmpresa == idEmpresa && l.Alugado == false);

		return Result.Ok(automovel);
	}
}