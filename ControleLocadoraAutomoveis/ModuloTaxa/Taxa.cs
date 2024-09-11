using System.ComponentModel.DataAnnotations;
using ControleLocadoraAutomoveis.Compartilhado;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;
using ControleLocadoraAutomoveis.Dominio.ModuloTaxa;

namespace ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;

public class Taxa : EntidadeBase
{
	public string Descricao { get; set; }
	public decimal Valor { get; set; }
	public TipoCobrancaEnum TipoCobranca { get; set; }
	public List<Locacao> Locacoes { get; set; }

	protected Taxa()
	{
		Locacoes = new List<Locacao>();
	}

	public Taxa(string descricao, decimal valor, TipoCobrancaEnum tipoCobranca) : this()
	{
		Descricao = descricao;
		Valor = valor;
		TipoCobranca = tipoCobranca;
	}

	public override string ToString()
	{
		return $"{Valor.ToString("C2")}\t{Descricao}\t({TipoCobranca.ToString()})";
	}

	public decimal CalcularValor(int diasDecorridos)
	{
		if(TipoCobranca == TipoCobrancaEnum.Diaria)
			return Valor * diasDecorridos;

		return Valor;
	}

	public override List<string> Validar()
	{
		List<string> erros = [];

		if (Descricao.Length < 3)
			erros.Add("A \"DESCRIÇÃO\" precisa conter pelomenos três caracteres!");

		if (Valor < 1.0m)
			erros.Add("O \"VALOR\" mínimo é 1");

		return erros;
	}
}