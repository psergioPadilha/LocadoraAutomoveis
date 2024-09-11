using System.Net.Mail;
using ControleLocadoraAutomoveis.Compartilhado;

namespace ControleLocadoraAutomoveis.Dominio.ModuloFuncionario;

public class Funcionario : EntidadeBase
{
	public int IdUsuario { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }
	public DateTime DataAdmissão { get; set; }
	public decimal Salario { get; set; }

	protected Funcionario()
	{

	}

	public Funcionario(int idUsuario, string nome, String email, DateTime dataAdmissão, decimal salario)
	{
		this.IdUsuario = idUsuario;
		this.Nome = nome;
		this.Email = email;
		this.DataAdmissão = dataAdmissão;
		this.Salario = salario;
	}

	public override List<string> Validar()
	{
		List<string> erros = [];

		if (string.IsNullOrWhiteSpace(Nome))
			erros.Add("O \"NOME DO FUNCIONÁRIO\" é obrigatório!");

		if (string.IsNullOrWhiteSpace(Email))
			erros.Add("O \"EMAIL\" é obrigatório!");

		else if (MailAddress.TryCreate(Email, out _) is false)
			erros.Add("O \"EMAIL\" deve seguir um padrão válido!");

		if (DataAdmissão > DateTime.Today)
			erros.Add("A \"DATA DE ADMISSÃO\" é inválida!");

		if (Salario <= 0)
			erros.Add("O \"VALOR DO SALÁRIO\" é inválido!");

		return erros;
	}
}