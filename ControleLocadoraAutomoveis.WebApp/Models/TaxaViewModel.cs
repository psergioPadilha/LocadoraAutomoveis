using System.ComponentModel.DataAnnotations;
using ControleLocadoraAutomoveis.Dominio.ModuloTaxa;
using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleLocadoraAutomoveis.WebApp.Models;

public class FormularioTaxaViewModel
{
	[Required(ErrorMessage = "A \"DESCRIÇÃO\" é obrigatório!")]
	[MinLength(3, ErrorMessage = "A \"DESCRIÇÃO\" deve conter pelomenos três caracteres!")]
	public string Descricao { get; set; }

	[Required(ErrorMessage = "O \"VALOR\" é obrigatório!")]
	[Range(0.01, double.MaxValue, ErrorMessage = "O \"VALOR\" deve deve ser maior que 0!")]
	public string Valor { get; set; }

	[Required(ErrorMessage = "O \"TIPO DE COBRANÇA\" é obrigatório!")]
	public TipoCobrancaEnum TipoCobranca { get; set; }

	public IEnumerable<SelectListItem>? TiposCobrancas { get; set; }
}

public class InserirTaxaViewModel : FormularioTaxaViewModel
{

}

public class EditarTaxaViewModel : FormularioTaxaViewModel
{
	public int Id { get; set; }
}

public class ListarTaxaViewModel
{
	public int Id { get; set; }
	public string Descricao { get; set; }
	public decimal Valor { get; set; }
	public string TipoCobranca { get; set; }
}

public class DetalhesTaxaViewModel
{
	public int Id { get; set; }
	public string Descricao { get; set; }
	public decimal Valor { get; set; }
	public string TipoCobranca { get; set; }
}