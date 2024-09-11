using ControleLocadoraAutomoveis.Compartilhado;
using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;

namespace ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
public class GrupoAutomoveis : EntidadeBase
{
	public string Descricao { get; set; }
	public List<Automovel> Automoveis { get; set; } = [];

	protected GrupoAutomoveis() { }

	public GrupoAutomoveis(string descricao)
	{
		this.Descricao = descricao;
	}

	public GrupoAutomoveis(int id, string descricao)
	{
		this.Id = id;
		this.Descricao = descricao;
	}

	public override List<string> Validar()
	{
		List<string> erros = [];

		if (string.IsNullOrEmpty(Descricao.Trim()))
			erros.Add("O campo \"DESCRIÇÃO\" é obrigatorio!");

		else if (Descricao.Length < 3)
			erros.Add("O nome precisa ter pelomenos três caracteres!");

		return erros;
	}
}
