using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleLocadoraAutomoveis.WebApp.Models;

public class SelecionarClienteViewModel
{
    [Required(ErrorMessage = "O \"CLIENTE\" é obrigatório!")]
    public int IdCliente { get; set; }
    public bool ClienteCondutor { get; set; }

    public IEnumerable<SelectListItem>? Clientes { get; set; }
}

public class FormularioCondutorViewModel
{
	[Required(ErrorMessage = "O \"CLIENTE\" é obrigatório!")]
	public int IdCliente { get; set; }
	public bool ClienteCondutor { get; set; }

	[Required(ErrorMessage = "O \"NOME\" é obrigatório!")]
	[MinLength(3, ErrorMessage = "O \"NOME\" deve conter pelomenos 3 caracteres!")]
	public string Nome { get; set; }

	[Required(ErrorMessage = "O \"EMAIL\" é obrigatório!")]
	[EmailAddress(ErrorMessage = "O \"EMAIL\" deve ser válido!")]
	public string Email { get; set; }

	[Required(ErrorMessage = "O \"TELEFONE\" é obrigatório!")]
	[Phone(ErrorMessage = "O \"TELEFONE\" deve ser válido!")]
	public string Telefone { get; set; }

	[Required(ErrorMessage = "O \"CPF\" é obrigatório!")]
	[MinLength(11, ErrorMessage = "O \"CPF\" deve conter pelomenos 11 caracteres!")]
	public string CPF { get; set; }

	[Required(ErrorMessage = "A \"CNH\" é obrigatória!")]
	public string CNH { get; set; }

	[Required(ErrorMessage = "A validade da \"CNH\" é obrigatória!")]
	[DataType(DataType.Date, ErrorMessage = "A validade da \"CNH\" deve ser uma data válida!")]
	public DateTime ValidadeCNH { get; set; }
}

public class InserirCondutorViewModel : FormularioCondutorViewModel
{

}

public class EditarCondutorViewModel : FormularioCondutorViewModel
{
	public int Id { get; set; }
}

public class ListarCondutorViewModel
{
	public int Id { get; set; }
	public string Cliente { get; set; }
	public bool ClienteCondutor { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }
	public string Telefone { get; set; }
	public string CPF { get; set; }
	public string CNH { get; set; }
	public string ValidadeCNH { get; set; }
}

public class DetalhesCondutorViewModel
{
	public int Id { get; set; }
	public string Cliente { get; set; }
	public bool ClienteCondutor { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }
	public string Telefone { get; set; }
	public string CPF { get; set; }
	public string CNH { get; set; }
	public string ValidadeCNH { get; set; }
}

