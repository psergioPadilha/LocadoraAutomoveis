using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleLocadoraAutomoveis.WebApp.Models;

public class FormularioPlanoDeCobrancaViewModel
{
	[Required(ErrorMessage = "O grupo de veículos é obrigatório!")]
	public int IdGrupoAutomoveis { get; set; }

	[Required(ErrorMessage = "O preço diário do plano diário é obrigatório!")]
	[Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano diário deve ser maior que 0!")]
	public decimal PrecoDiarioPlanoDiario { get; set; }

	[Required(ErrorMessage = "O preço por quilômetro do plano diário é obrigatório!")]
	[Range(0.01, double.MaxValue, ErrorMessage = "O preço por quilômetro do plano diário deve ser maior que 0!")]
	public decimal PrecoQuilometroPlanoDiario { get; set; }

	[Required(ErrorMessage = "Os quilômetros disponíveis no plano controlado são obrigatórios!")]
	[Range(0.01, double.MaxValue, ErrorMessage = "Os quilômetros disponíveis no plano controlado devem ser maiores que 0!")]
	public decimal QuilometrosDisponiveisPlanoControlado { get; set; }

	[Required(ErrorMessage = "O preço diário do plano controlado é obrigatório!")]
	[Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano controlado deve ser maior que 0!")]
	public decimal PrecoDiarioPlanoControlado { get; set; }

	[Required(ErrorMessage = "O preço por quilômetro extrapolado no plano controlado é obrigatório!")]
	[Range(0.01, double.MaxValue, ErrorMessage = "O preço por quilômetro extrapolado no plano controlado deve ser maior que 0!")]
	public decimal PrecoQuilometroExtrapoladoPlanoControlado { get; set; }

	[Required(ErrorMessage = "O preço diário do plano livre é obrigatório!")]
	[Range(0.01, double.MaxValue, ErrorMessage = "O preço diário do plano livre deve ser maior que 0!")]
	public decimal PrecoDiarioPlanoLivre { get; set; }

	public IEnumerable<SelectListItem>? GruposAutomoveis { get; set; }
}

public class InserirPlanoDeCobrancaViewModel : FormularioPlanoDeCobrancaViewModel
{

}

public class EditarPlanoDeCobrancaViewModel : FormularioPlanoDeCobrancaViewModel
{
	public int Id { get; set; }
}

public class ListarPlanoDeCobrancaViewModel
{
	public int Id { get; set; }
	public string GrupoAutomoveis { get; set; }
	public decimal PrecoDiarioPlanoDiario { get; set; }
	public decimal PrecoQuilometroPlanoDiario { get; set; }
	public decimal QuilometrosDisponiveisPlanoControlado { get; set; }
	public decimal PrecoDiarioPlanoControlado { get; set; }
	public decimal PrecoQuilometroExtrapoladoPlanoControlado { get; set; }
	public decimal PrecoDiarioPlanoLivre { get; set; }
}

public class DetalhesPlanoDeCobrancaViewModel
{
	public int Id { get; set; }
	public string GrupoAutomoveis { get; set; }
	public decimal PrecoDiarioPlanoDiario { get; set; }
	public decimal PrecoQuilometroPlanoDiario { get; set; }
	public decimal QuilometrosDisponiveisPlanoControlado { get; set; }
	public decimal PrecoDiarioPlanoControlado { get; set; }
	public decimal PrecoQuilometroExtrapoladoPlanoControlado { get; set; }
	public decimal PrecoDiarioPlanoLivre { get; set; }
}