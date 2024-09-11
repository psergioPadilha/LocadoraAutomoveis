using System.Net.Mail;
using ControleLocadoraAutomoveis.Compartilhado;
using ControleLocadoraAutomoveis.Dominio.ModuloCondutor;

namespace ControleLocadoraAutomoveis.Dominio.ModuloCliente;

public class Cliente : EntidadeBase
{
	public string Nome { get; set; }
	public string Email { get; set; }
	public string Telefone { get; set; }
	public TipoClienteEnum TipoCliente { get; set; }
	public string NumeroDocumento { get; set; }
	public string Estado { get; set; }
	public string Cidade { get; set; }
	public string Bairro { get; set; }
	public string Rua { get; set; }
	public string NumeroEndereco { get; set; }
	public List<Condutor>? Condutores { get; set; }

	protected Cliente()
	{
		Condutores = [];
	}

	public Cliente(string nome, string email, string telefone, TipoClienteEnum tipoCliente, string numeroDocumento,
		string estado, string cidade, string bairro, string rua, string numeroEndereco) : this()
	{
		Nome = nome;
		Email = email;
		Telefone = telefone;
		TipoCliente = tipoCliente;
		NumeroDocumento = numeroDocumento;
		Estado = estado;
		Cidade = cidade;
		Bairro = bairro;
		Rua = rua;
		NumeroEndereco = numeroEndereco;
	}

	public override List<string> Validar()
	{
		List<string> erros = [];

		if (string.IsNullOrWhiteSpace(Nome))
			erros.Add("O \"NOME CLIENTE\" é obrigatório!");

		if (string.IsNullOrWhiteSpace(Email))
			erros.Add("O \"EMAIL\" é obrigatório!");

		else if (MailAddress.TryCreate(Email, out _) is false)
			erros.Add("O \"EMAIL\" deve seguir um padrão válido!");

		if (string.IsNullOrWhiteSpace(Telefone))
			erros.Add("O \"TELEFONE\" é obrigatório!");

		if (string.IsNullOrWhiteSpace(NumeroDocumento))
			erros.Add("O \"NÚMERO DO DOCUMENTO\" é obrigatório!");

		if (string.IsNullOrWhiteSpace(Estado))
			erros.Add("O \"ESTADO\" é obrigatório!");

		if (string.IsNullOrWhiteSpace(Cidade))
			erros.Add("A \"CIDADE\" é obrigatória!");

		if (string.IsNullOrWhiteSpace(Bairro))
			erros.Add("O \"BAIRRO\" é obrigatório!");

		if (string.IsNullOrWhiteSpace(Rua))
			erros.Add("A \"RUA\" é obrigatória!");

		if (string.IsNullOrWhiteSpace(NumeroEndereco))
			erros.Add("O \"NÚMERO DA RESIDÊNCIA\" é obrigatório!");

		return erros;
	}
}