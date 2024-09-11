using ControleLocadoraAutomoveis.Dominio.ModuloFuncionario;

namespace ControleLocadoraAutomoveis.Testes.Unidade.ModuloFuncionario;

[TestClass]
[TestCategory("Unidade")]
public class FuncionarioTests
{
	[TestMethod]
	public void Deve_Criar_Instancia_Valida()
	{
		var funcionario = new Funcionario
		(
			idUsuario: 1,
			nome: "Funcionário Teste",
			email: "testefuncionario@exemplo.com",
			dataAdmissão: DateTime.Today.AddYears(-1),
			salario: 1000.0m
		);

		var erros = funcionario.Validar();

		Assert.AreEqual(0, erros.Count);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Invalida()
	{
		var funcionario = new Funcionario
		(
			idUsuario: 1,
			nome: "",
			email: "",
			dataAdmissão: DateTime.Today.AddYears(1),
			salario: 0
		);

		var erros = funcionario.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"NOME DO FUNCIONÁRIO\" é obrigatório!",
			"O \"EMAIL\" é obrigatório!",
			"A \"DATA DE ADMISSÃO\" é inválida!",
			"O \"VALOR DO SALÁRIO\" é inválido!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Com_Nome_invalido()
	{
		var funcionario = new Funcionario
		(
			idUsuario: 1,
			nome: "",
			email: "testefuncionario@exemplo.com",
			dataAdmissão: DateTime.Today.AddYears(-1),
			salario: 1000.0m
		);

		var erros = funcionario.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"NOME DO FUNCIONÁRIO\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Com_Email_Em_Branco()
	{
		var funcionario = new Funcionario
		(
			idUsuario: 1,
			nome: "Funcionário Teste",
			email: "",
			dataAdmissão: DateTime.Today.AddYears(-1),
			salario: 1000.0m
		);

		var erros = funcionario.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"EMAIL\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Com_Email_Invalido()
	{
		var funcionario = new Funcionario
		(
			idUsuario: 1,
			nome: "Funcionário Teste",
			email: "testefuncionarioexemplo.com",
			dataAdmissão: DateTime.Today.AddYears(-1),
			salario: 1000.0m
		);

		var erros = funcionario.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"EMAIL\" deve seguir um padrão válido!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Admissao_Invalida()
	{
		var funcionario = new Funcionario
		(
			idUsuario: 1,
			nome: "Funcionário Teste",
			email: "testefuncionario@exemplo.com",
			dataAdmissão: DateTime.Today.AddYears(1),
			salario: 1000.0m
		);

		var erros = funcionario.Validar();

		List<string> errosEsperados = new List<string>
		{
			"A \"DATA DE ADMISSÃO\" é inválida!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Salario_Invalido()
	{
		var funcionario = new Funcionario
		(
			idUsuario: 1,
			nome: "Funcionário Teste",
			email: "testefuncionario@exemplo.com",
			dataAdmissão: DateTime.Today.AddYears(-1),
			salario: 0
		);

		var erros = funcionario.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"VALOR DO SALÁRIO\" é inválido!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}
}