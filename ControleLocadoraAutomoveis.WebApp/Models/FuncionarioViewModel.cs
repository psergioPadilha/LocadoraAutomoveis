using System.ComponentModel.DataAnnotations;

namespace ControleLocadoraAutomoveis.WebApp.Models;

public class InserirFuncionarioViewModel
{
	[Required(ErrorMessage = "O nome do funcionário é obrigatório!")]
	public string Nome { get; set; }

	[Required(ErrorMessage = "o nome do usuário é obrigatório!")]
	public string Usuario { get; set; }

	[Required]
	[EmailAddress]
	public string Email { get; set; }

	[Required, DataType(DataType.Password)]
	public string Senha { get; set; }

	[Display(Name = "Confirme senha!")]
	[DataType(DataType.Password), Compare("Senha", ErrorMessage = "As senhas não conferem!")]
	public string ConfirmarSenha { get; set; }

	[DataType(DataType.Date)]
	public DateTime Admissao { get; set; }

	[DataType(DataType.Currency)]
	public decimal Salario { get; set; }

	public InserirFuncionarioViewModel()
	{
		Admissao = DateTime.Now;
	}
}

public class ListarFuncionarioViewModel
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }
	public DateTime Admissao { get; set; }
	public decimal Salario { get; set; }
}