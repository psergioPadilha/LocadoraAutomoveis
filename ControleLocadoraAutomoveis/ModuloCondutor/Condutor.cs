using System.Net.Mail;
using ControleLocadoraAutomoveis.Compartilhado;
using ControleLocadoraAutomoveis.Dominio.ModuloCliente;

namespace ControleLocadoraAutomoveis.Dominio.ModuloCondutor;

public class Condutor : EntidadeBase
{
	public int IdCliente { get; set; }
	public Cliente? Cliente { get; set; }
	public bool ClienteCondutor { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }
	public string Telefone { get; set; }
	public string CPF { get; set; }
	public string CNH { get; set; }
	public DateTime ValidadeCNH { get; set; }

	protected Condutor()
	{

	}

	public Condutor(int idCliente, bool clienteCondutor, string nome, string email, string telefone,
		string cpf, string cnh, DateTime validadeCnh) : this()
	{
		IdCliente = idCliente;
		ClienteCondutor = clienteCondutor;
		Nome = nome;
		Email = email;
		Telefone = telefone;
		CPF = cpf;
		CNH = cnh;
		ValidadeCNH = validadeCnh;
	}

	public override List<string> Validar()
	{
		List<string> erros = [];

		if (string.IsNullOrWhiteSpace(Nome))
			erros.Add("O \"NOME DO CONDUTOR\" é obrigatório!");

		if (string.IsNullOrWhiteSpace(Email))
			erros.Add("O \"EMAIL\" é obrigatório!");

		else if (MailAddress.TryCreate(Email, out _) is false)
			erros.Add("O \"EMAIL\" deve seguir um padrão válido!");

		if (string.IsNullOrWhiteSpace(Telefone))
			erros.Add("O \"TELEFONE\" é obrigatório!");

		if (string.IsNullOrWhiteSpace(CPF))
			erros.Add("O \"CPF\" é obrigatório!");

		if (string.IsNullOrWhiteSpace(CNH))
			erros.Add("O \"CNH\" é obrigatório!");

		if (ValidadeCNH < DateTime.Today)
			erros.Add("A validade da \"CNH\" está vencida!");

		return erros;
	}
}