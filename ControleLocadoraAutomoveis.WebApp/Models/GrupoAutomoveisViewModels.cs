using System.ComponentModel.DataAnnotations;

namespace ControleLocadoraAutomoveis.WebApp.Models;

public class InserirGrupoAutomoveisViewModel
{
	[Required(ErrorMessage = "O nome é obrigatório!")]
	[MinLength(3, ErrorMessage = "O nome deve conter pelomenos três caracteres!")]

	public string Descricao { get; set; }
}

public class EditarGrupoAutomoveisViewModel
{
	public int Id { get; set; }

	[Required(ErrorMessage = "O nome é obrigatório!")]
	[MinLength(3, ErrorMessage = "O nome deve conter pelomenos três caracteres!")]

	public string Descricao { get; set; }
}

public class ListarGrupoAutomoveisViewModel
{
	public int Id { get; set; }

	public string Descricao { get; set; }

}

public class DetalhesGrupoAutomoveisViewModel
{
	public int Id { get; set; }

	public string Descricao { get; set; }
}
