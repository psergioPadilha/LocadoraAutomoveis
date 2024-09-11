using System.ComponentModel.DataAnnotations;
using ControleLocadoraAutomoveis.Dominio.ModuloCliente;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleLocadoraAutomoveis.WebApp.Models;

//public class SelecionarClienteViewModel
//{
//	[Required(ErrorMessage = "O \"NOME\" é obrigatório!")]
//	public int IdCliente { get; set; }
//	public bool ClienteCondutor { get; set; }

//	public IEnumerable<SelectListItem>? Clientes { get; set; }
//}

public class FormularioClienteViewModel
{
	[Required(ErrorMessage = "O \"NOME\" é obrigatório!")]
	[MinLength(3, ErrorMessage = "O \"NOME\" deve conter pelomenos 3 caracteres!")]
	public string Nome { get; set; }

	[Required(ErrorMessage = "O \"EMAIL\" é obrigatório!")]
	[EmailAddress(ErrorMessage = "O \"EMAIL\" deve ser válido!")]
	public string Email { get; set; }

	[Required(ErrorMessage = "O \"TELEFONE\" é obrigatório!")]
	[Phone(ErrorMessage = "O \"TELEFONE\" deve ser válido!")]
	public string Telefone { get; set; }

    [Required(ErrorMessage = "O tipo de cadastro é obrigatório")]
    public TipoClienteEnum TipoCliente { get; set; }

    [Required(ErrorMessage = "O \"CPF\" é obrigatório!")]
	[MinLength(11, ErrorMessage = "O \"CPF\" deve conter pelomenos 11 caracteres!")]
	public string NumeroDocumento { get; set; }

	[Required(ErrorMessage = "O \"ESTADO\" é obrigatório!")]
	[MinLength(2, ErrorMessage = "O \"ESTADO\" deve conter pelomenos 2 caracteres!")]
	public string Estado { get; set; }

	[Required(ErrorMessage = "A \"CIDADE\" é obrigatória!")]
	[MinLength(2, ErrorMessage = "A \"CIDADE\" deve conter pelomenos 2 caracteres!")]
	public string Cidade { get; set; }

	[Required(ErrorMessage = "O \"BAIRRO\" é obrigatório!")]
	[MinLength(2, ErrorMessage = "O \"BAIRRO\" deve conter pelomenos 2 caracteres!")]
	public string Bairro { get; set; }

	[Required(ErrorMessage = "A \"RUA\" é obrigatória!")]
	[MinLength(2, ErrorMessage = "A \"RUA\" deve conter pelomenos 2 caracteres!")]
	public string Rua { get; set; }

	[Required(ErrorMessage = "O \"NÚMERO DA RESIDÊNCIA\" é obrigatório!")]
	[MinLength(1, ErrorMessage = "O \"NÚMERO DA RESIDÊNCIA\" deve conter pelomenos 1 caracteres!")]
	public string NumeroEndereco { get; set; }
}

public class InserirClienteViewModel : FormularioClienteViewModel
{

}

public class EditarClienteViewModel : FormularioClienteViewModel
{
	public int Id { get; set; }
}

public class ListarClienteViewModel
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }
	public string Telefone { get; set; }
	public string TipoCliente { get; set; }
	public string NumeroDocumento { get; set; }
	public string Estado { get; set; }
	public string Cidade { get; set; }
	public string Bairro { get; set; }
	public string Rua { get; set; }
	public string NumeroEndereco { get; set; }
}

public class DetalhesClienteViewModel
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }
	public string Telefone { get; set; }
	public string TipoCliente { get; set; }
	public string NumeroDocumento { get; set; }
	public string Estado { get; set; }
	public string Cidade { get; set; }
	public string Bairro { get; set; }
	public string Rua { get; set; }
	public string NumeroEndereco { get; set; }
}
