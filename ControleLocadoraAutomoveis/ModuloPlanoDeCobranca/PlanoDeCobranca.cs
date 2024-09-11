using ControleLocadoraAutomoveis.Compartilhado;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;

namespace ControleLocadoraAutomoveis.Dominio.ModuloPlanoDeCobranca;

public class PlanoDeCobranca : EntidadeBase
{
	public int IdGrupoAutomoveis { get; set; }
	public GrupoAutomoveis? GrupoAutomoveis { get; set; }
	public decimal PrecoDiarioPlanoDiario { get; set; }
	public decimal PrecoQuilometroPlanoDiario { get; set; }
	public decimal QuilometrosDisponiveisPlanoControlado { get; set; }
	public decimal PrecoDiarioPlanoControlado { get; set; }
	public decimal PrecoQuilometroExtrapoldoPlanoControlado { get; set; }
	public decimal PrecoDiarioPlanoLivre { get; set; }

	protected PlanoDeCobranca() { }

	public PlanoDeCobranca(
		int idIdGrupoAutomoveis,
		decimal precoDiarioPlanoDiario,
		decimal precoQuilometroPlanoDiario,
		decimal quilometrosDisponiveisPlanoControlado,
		decimal precoDiarioPlanoControlado,
		decimal precoQuilometroExtrapoldoPlanoControlado,
		decimal precoDiarioPlanoLivre
	)
	{
		this.IdGrupoAutomoveis = idIdGrupoAutomoveis;
		this.PrecoDiarioPlanoDiario = precoDiarioPlanoDiario;
		this.PrecoQuilometroPlanoDiario = precoQuilometroPlanoDiario;
		this.QuilometrosDisponiveisPlanoControlado = quilometrosDisponiveisPlanoControlado;
		this.PrecoDiarioPlanoControlado = precoDiarioPlanoControlado;
		this.PrecoQuilometroExtrapoldoPlanoControlado = precoQuilometroExtrapoldoPlanoControlado;
		this.PrecoDiarioPlanoLivre = precoDiarioPlanoLivre;
	}

	public decimal CalcularValor(int diasDecorridos, int quilometragemPercorrida, TipoPlanoDeCobrancaEnum tipoPlano)
	{
		decimal valor = 0.0m;

		switch (tipoPlano)
		{
			case TipoPlanoDeCobrancaEnum.Diario:
				decimal valorDiasPlanoDiario = diasDecorridos * PrecoDiarioPlanoDiario;

				decimal valorQuilometragemPercorridaPlanoDiario = quilometragemPercorrida * PrecoQuilometroPlanoDiario;

				valor = valorDiasPlanoDiario + valorQuilometragemPercorridaPlanoDiario;
				break;

			case TipoPlanoDeCobrancaEnum.Controlado:
				decimal valorDiasPlanoControlado = diasDecorridos * PrecoDiarioPlanoDiario;

				decimal quilometrosExtrapolados = quilometragemPercorrida - QuilometrosDisponiveisPlanoControlado;

				decimal valorQuilometragemPlanoControlado = quilometrosExtrapolados * PrecoQuilometroExtrapoldoPlanoControlado;

				valor = valorDiasPlanoControlado;

				if (quilometrosExtrapolados > 0)
					valor += valorQuilometragemPlanoControlado;
				break;

			case TipoPlanoDeCobrancaEnum.Livre:
				valor = diasDecorridos * PrecoDiarioPlanoLivre;
				break;
		}

		return valor;
	}

	public override List<string> Validar()
	{
		List<string> erros = [];

		if (IdGrupoAutomoveis == 0)
			erros.Add("O \"GRUPO AUTOMÓVEIS\" é obrigatório!");

		return erros;
	}
}
