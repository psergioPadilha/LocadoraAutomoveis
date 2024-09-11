using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ControleLocadoraAutomoveis.Compartilhado;
using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloCombustivel;
using ControleLocadoraAutomoveis.Dominio.ModuloCondutor;
using ControleLocadoraAutomoveis.Dominio.ModuloPlanoDeCobranca;
using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;

namespace ControleLocadoraAutomoveis.Dominio.ModuloLocacao;

public class Locacao : EntidadeBase
{
	public int IdCondutor { get; set; }
	public Condutor? Condutor { get; set; }
	public int IdAutomovel { get; set; }
	public Automovel? Automovel { get; set; }
	public int IdConfiguracaoCombustivel { get; set; }
	public ConfiguracaoCombustivel? ConfiguracaoCombustivel { get; set; }
	public TipoPlanoDeCobrancaEnum TipoPlano { get; set; }
	public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }
	public int QuilometragemPercorrida { get; set; }
	public DateTime DataLocacao { get; set; }
	public DateTime DevolucaoPrevista { get; set; }
	public DateTime? DataDevolucao  { get; set; }
	public List<Taxa> TaxasSelecionadas { get; set; }

	protected Locacao()
	{
		TaxasSelecionadas = new List<Taxa>();
		DataDevolucao = null;
		MarcadorCombustivel = MarcadorCombustivelEnum.Completo;
	}

	public Locacao(int idCondutor, int idAutomovel, int idConfiguracaoCombustivel, 
		TipoPlanoDeCobrancaEnum planoCobranca, DateTime dataLocacao, DateTime devolucaoPrevista) : this()
	{
		IdCondutor = idCondutor;
		IdAutomovel = idAutomovel;
		IdConfiguracaoCombustivel = idConfiguracaoCombustivel;
		TipoPlano = planoCobranca;
		DataLocacao = dataLocacao;
		DevolucaoPrevista = devolucaoPrevista;
	}

	public void Abrir()
	{
		if (Automovel is null)
			return;

		Automovel.Alugar();
	}

	public void Devolucao()
	{
		DataDevolucao = DateTime.Now;

		if (Automovel is null)
			return;

		Automovel.Desocupar();
	}

	public bool TemMulta()
	{
		if(DataDevolucao is null)
			return (DateTime.Now - DevolucaoPrevista).Days > 0;

		return (DataDevolucao - DevolucaoPrevista).Value.Days > 0;
	}

	public decimal CalcularValorParcial(PlanoDeCobranca planoSelecionado)
	{
		var diasDecorridos = ObterDiasDecorridos();

		decimal valorPlano = planoSelecionado.CalcularValor(diasDecorridos, QuilometragemPercorrida, TipoPlano);

		decimal valorTaxa = 0;

		if (TaxasSelecionadas.Count > 0)
			valorTaxa = TaxasSelecionadas.Sum(tx => tx.CalcularValor(diasDecorridos));

		return valorPlano + valorTaxa;
	}

	public decimal CalcularValorTotal(PlanoDeCobranca planoDeCobranca)
	{
		var valorParcial = CalcularValorParcial(planoDeCobranca);

		decimal totalAbastecimento = 0;

		if (Automovel is not null && ConfiguracaoCombustivel is not null)
		{
			var valorCombustivel = ConfiguracaoCombustivel.ObterValorCombustivel(Automovel.TipoCcombustivel);
			totalAbastecimento = Automovel.CalcularLitrosParaAbastecimento(MarcadorCombustivel) * valorCombustivel;
		}

		decimal valorTotal = valorParcial + totalAbastecimento;

		if (TemMulta()) // 10% de multa
			valorTotal += valorTotal * (10 / 100m);

		return valorTotal;
	}

	public int ObterDiasDecorridos()
	{
		int diasLocacao;

		if (DataDevolucao is null)
			diasLocacao = (DevolucaoPrevista.Date - DataLocacao.Date).Days;
		else
			diasLocacao = (DataDevolucao - DataLocacao).Value.Days;

		return diasLocacao;
	}

	public override List<string> Validar()
	{
		List<string> erros = [];

		if(IdCondutor == 0)
			erros.Add("O \"CONDUTOR\" é obrigatório!");

		if (IdAutomovel == 0)
			erros.Add("O \"AUTOMÓVEL\" é obrigatório!");

		if (DataLocacao == DateTime.MinValue)
			erros.Add("Por favor selecione a \"DATA DA LOCAÇÃO\"!");

		if (DevolucaoPrevista == DateTime.MinValue)
			erros.Add("Por favor selecione a \"DATA PREVISTA PARA ENTREGA\"!");

		if (DevolucaoPrevista < DataLocacao)
			erros.Add("A data prevista da \"ENTREGA\" não pode ser menor que a data de \"LOCAÇÃO\"!");

		return erros;
	}
}