using ControleLocadoraAutomoveis.Dominio.ModuloCombustivel;
using FluentResults;

namespace ControleLocadoraAutomoveis.Aplicacao.ModuloCombustivel;

public class ServicoCombustivel
{
	private readonly IRepositorioConfiguracaoCombustivel repositorioConfiguracaoCombustivel;

	public ServicoCombustivel(IRepositorioConfiguracaoCombustivel repositorioConfiguracaoCombustivel)
	{
		this.repositorioConfiguracaoCombustivel = repositorioConfiguracaoCombustivel;
	}

	public Result SalvarConfiguracao(ConfiguracaoCombustivel configuracao)
	{
		configuracao.DataCriacao = DateTime.Now;

		repositorioConfiguracaoCombustivel.GravarConfiguracao(configuracao);

		return Result.Ok();
	}

	public Result<ConfiguracaoCombustivel> ObterConfiguracao(int idEmpresa)
	{
		var configuracao = repositorioConfiguracaoCombustivel.ObterConfiguracao(idEmpresa);

		if (configuracao is null)
		{
			configuracao = new ConfiguracaoCombustivel(valorGasolina: 0.0m, valorGas: 0.0m, valorDiesel: 0.0m, valorAlcool: 0.0m);
		}

		return Result.Ok(configuracao);
	}
}