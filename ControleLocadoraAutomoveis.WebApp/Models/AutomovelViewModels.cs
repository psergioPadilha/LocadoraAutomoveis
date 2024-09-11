using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleLocadoraAutomoveis.WebApp.Models;

public class FormularioAutomovelViewModel
{
	[Required(ErrorMessage = "A \"MARCA\" é obrigatória!")]
	[MinLength(2, ErrorMessage = "A \"MARCA\" deve conter pelomenos dois caracteres!")]
	public string Marca { get; set; }

	[Required(ErrorMessage = "O \"MODELO\" é obrigatório!")]
	[MinLength(3, ErrorMessage = "O \"MODELO\" deve conter ao menos três caracteres!")]
	public string Modelo { get; set; }

	[Required(ErrorMessage = "O \"TIPO DE COMBUSTÍVEL\" é obrigatório!")]
	public int TipoCombustivel { get; set; }

	[Required(ErrorMessage = "A \"CAPACIDADE DO TANQUE\" é obrigatório!")]
	[MinLength(1, ErrorMessage = "A \"CAPACIDADE DO TANQUE\" deve deve ser maior que 0!")]
	public int CapacidadeTanque { get; set; }

	[Required(ErrorMessage = "O \"GRUPO DE VEÍCULOS\" é obrigatório!")]
	public int IdGrupoDeAutomoveis { get; set; }
	public IEnumerable<SelectListItem>? GruposAutomoveis { get; set; }

	[Required(ErrorMessage = "A \"FOTO\" é obrigatório!")]
	public IFormFile Foto { get; set; }
}

public class InserirAutomovelViewModel : FormularioAutomovelViewModel
{

}

public class EditarAutomovelViewModel : FormularioAutomovelViewModel
{
	public int Id { get; set; }
}

public class ListarAutomovelViewModel
{
	public int Id { get; set; }
	public string Modelo { get; set; }
	public string Marca { get; set; }
	public string TipoCombustivel { get; set; }
	public int CapacidadeTanque { get; set; }
	public string GrupoAutomoveis { get; set; }
}

public class DetalhesAutomovelViewModel
{
	public int Id { get; set; }
	public string Modelo { get; set; }
	public string Marca { get; set; }
	public string TipoCombustivel { get; set; }
	public int CapacidadeTanque { get; set; }
	public string GrupoAutomoveis { get; set; }
}