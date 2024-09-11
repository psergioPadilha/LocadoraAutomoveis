using ControleLocadoraAutomoveis.Compartilhado;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;

namespace ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;

public class Automovel : EntidadeBase
{
	public string Marca { get; set; }
	public string Modelo { get; set; }
	public int CapacidadeTanque { get; set; }
	public byte[] Foto { get; set; }
	public int IdGrupoAutomoveis { get; set; }
	public GrupoAutomoveis? GrupoAutomoveis { get; set; }
	public TipoCombustivelEnum TipoCcombustivel { get; set; }
	public bool Alugado { get; set; }

	protected Automovel() { }

	public Automovel(string marca, string modelo, int capacidadeTanque, int idGrupoAutomoveis, TipoCombustivelEnum tipoCcombustivel)
	{
		Marca = marca;
		Modelo = modelo;
		CapacidadeTanque = capacidadeTanque;
		IdGrupoAutomoveis = idGrupoAutomoveis;
		TipoCcombustivel = tipoCcombustivel;
	}

	public void Alugar()
	{
		Alugado = true;
	}

	public void Desocupar()
	{
		Alugado = false;
	}

	public decimal CalcularLitrosParaAbastecimento(MarcadorCombustivelEnum marcadorCombustivel)
	{
		switch (marcadorCombustivel)
		{
			case MarcadorCombustivelEnum.Vazio: return CapacidadeTanque;
			case MarcadorCombustivelEnum.UmQuarto: return CapacidadeTanque - (CapacidadeTanque * (1m / 4m));
			case MarcadorCombustivelEnum.MeioTanque: return CapacidadeTanque - (CapacidadeTanque * (1m /2m));
			case MarcadorCombustivelEnum.TresQuartos: return CapacidadeTanque - (CapacidadeTanque * (3m / 4m));

			default:
				return 0;
		}
	}

	public override List<string> Validar()
	{
		List<string> erros = [];

		if (string.IsNullOrEmpty(Marca))
			erros.Add("O campo \"MARCA\" é obrigatório!");

		if (string.IsNullOrEmpty(Modelo))
			erros.Add("O campo \"MODELO\" é obrigatório!");

		if (CapacidadeTanque == 0)
			erros.Add("A \"CAPACIDADE DO TANQUE\" precisa ser informada!");

		if (IdGrupoAutomoveis == 0)
			erros.Add("O \"GRUPO VEÍCULOS\" é obrigatório!");

		if (TipoCcombustivel == 0)
			erros.Add("O \"TIPO DE COMBUSTÍVEL\" precisa ser informado!");

		return erros;
	}
}
