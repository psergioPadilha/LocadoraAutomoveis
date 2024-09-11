using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloCombustivel;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;
using FluentResults;

namespace ControleLocadoraAutomoveis.Aplicacao.ModuloLocacao;

public class ServicoLocacao
{
	private readonly IRepositorioLocacao repositorioLocacao;
	private readonly IRepositorioConfiguracaoCombustivel repositorioConfiguracaoCombustivel;
	private readonly IRepositorioAutomovel repositorioAutomovel;

	public ServicoLocacao(
		IRepositorioLocacao repositorioLocacao,
		IRepositorioConfiguracaoCombustivel repositorioConfiguracaoCombustivel,
		IRepositorioAutomovel repositorioAutomovel
	)
	{
		this.repositorioLocacao = repositorioLocacao;
		this.repositorioConfiguracaoCombustivel = repositorioConfiguracaoCombustivel;
		this.repositorioAutomovel = repositorioAutomovel;
	}

	public Result<Locacao> Inserir(Locacao locacao)
	{
		var config = repositorioConfiguracaoCombustivel.ObterConfiguracao(locacao.IdEmpresa);

		if (config is null)
			return Result.Fail("Não foi possível obter a configuração de valores de combustíveis!");

		locacao.IdConfiguracaoCombustivel = config.Id;

		var erros = locacao.Validar();

		if (erros.Count > 0)
			return Result.Fail(erros);

		AbrirLocacao(locacao);

		repositorioLocacao.Inserir(locacao);

		return Result.Ok(locacao);
	}

	public Result<Locacao> Devolucao(Locacao locacaoParaDevolucao)
	{
		if (locacaoParaDevolucao.DataDevolucao is not null)
			return Result.Fail("A devolução já foi realizada!");

		FecharLocacao(locacaoParaDevolucao);

		repositorioLocacao.Editar(locacaoParaDevolucao);

		return Result.Ok(locacaoParaDevolucao);
	}

	public Result<Locacao> Editar(Locacao locacaoAtualizada)
	{
		var locacao = repositorioLocacao.SelecionarPorId(locacaoAtualizada.Id);

		if (locacao is null)
			return Result.Fail("A \"LOCAÇÃO\" não foi encontrada!");

		if (locacao.DataDevolucao is not null)
			return Result.Fail("A \"DEVOLUÇÃO\" já foi realizada!");

		var erros = locacaoAtualizada.Validar();

		if (erros.Count > 0)
			return Result.Fail(erros);

		locacao.Automovel!.Desocupar();

		locacao.IdAutomovel = locacaoAtualizada.IdAutomovel;
		locacao.IdCondutor = locacaoAtualizada.IdCondutor;
		locacao.IdConfiguracaoCombustivel = locacaoAtualizada.IdConfiguracaoCombustivel;
		locacao.TipoPlano = locacaoAtualizada.TipoPlano;
		locacao.MarcadorCombustivel = locacaoAtualizada.MarcadorCombustivel;
		locacao.QuilometragemPercorrida = locacaoAtualizada.QuilometragemPercorrida;
		locacao.DataLocacao = locacaoAtualizada.DataLocacao;
		locacao.DevolucaoPrevista = locacaoAtualizada.DevolucaoPrevista;
		locacao.DataDevolucao = locacaoAtualizada.DataDevolucao;
		locacao.TaxasSelecionadas = locacaoAtualizada.TaxasSelecionadas;

		repositorioLocacao.Editar(locacao);

		return Result.Ok(locacao);
	}

	public Result<Locacao> Excluir(int locacaoId)
	{
		var locacao = repositorioLocacao.SelecionarPorId(locacaoId);

		if (locacao is null)
			return Result.Fail("A \"LOCAÇÃO\" não foi encontrada!");

		repositorioLocacao.Excluir(locacao);

		return Result.Ok(locacao);
	}

	public Result<Locacao> SelecionarPorId(int locacaoId)
	{
		var locacao = repositorioLocacao.SelecionarPorId(locacaoId);

		if (locacao is null)
			return Result.Fail("A \"LOCAÇÃO\" não foi encontrada!");

		return Result.Ok(locacao);
	}

	public Result<List<Locacao>> SelecionarTodos(int idEmpresa)
	{
		var locacoes = repositorioLocacao.Filtrar(l => l.IdEmpresa == idEmpresa);

		return Result.Ok(locacoes);
	}

	private void AbrirLocacao(Locacao locacao)
	{
		var automovelSelecionado = repositorioAutomovel.SelecionarPorId(locacao.IdAutomovel);

		locacao.Automovel = automovelSelecionado;

		locacao.Abrir();

		repositorioAutomovel.Editar(locacao.Automovel!);
	}


	private void FecharLocacao(Locacao locacao)
	{
		var automovelSelecionado = repositorioAutomovel.SelecionarPorId(locacao.IdAutomovel);

		locacao.Automovel = automovelSelecionado;

		locacao.Devolucao();
		repositorioAutomovel.Editar(locacao.Automovel!);
	}
}