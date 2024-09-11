using ControleLocadoraAutomoveis.Dominio.ModuloCondutor;

namespace ControleLocadoraAutomoveis.Testes.Unidade.ModuloCondutor;

[TestClass]
[TestCategory("Unidade")]
public class CondutorTests
{
	[TestMethod]
	public void Deve_Criar_Instancia_Valida()
	{
		var condutor = new Condutor
		(
				idCliente: 1,
				clienteCondutor: true,
				nome: "Carlos Abreu",
				email: "carlosabreu@exemplo.com",
				telefone: "(49) 99999-9999",
				cpf: "123.456.789-00",
				cnh: "12345678901",
				validadeCnh: DateTime.Today.AddYears(1)
		);

		var erros = condutor.Validar();

		Assert.AreEqual(0, erros.Count);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Invalida()
	{
		var condutor = new Condutor
		(
			idCliente: 1,
			clienteCondutor: true,
			nome: "",
			email: "carlosabreu@exemplo.com",
			telefone: "(49) 99999-9999",
			cpf: "123.456.789-00",
			cnh: "12345678901",
			validadeCnh: DateTime.Today.AddYears(1)
		);

		var erros = condutor.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"NOME DO CONDUTOR\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Com_Erro_Email()
	{
		var condutor = new Condutor
		(
			idCliente: 1,
			clienteCondutor: true,
			nome: "Pedro Cunha",
			email: "",
			telefone: "(49) 99999-9999",
			cpf: "123.456.789-00",
			cnh: "12345678901",
			validadeCnh: DateTime.Today.AddYears(1)
		);

		var erros = condutor.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"EMAIL\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Com_Erro_Email_Invalido()
	{
		var condutor = new Condutor
		(
			idCliente: 1,
			clienteCondutor: true,
			nome: "Pedro Cunha",
			email: "pedrinho @ ",
			telefone: "(49) 99999-9999",
			cpf: "123.456.789-00",
			cnh: "12345678901",
			validadeCnh: DateTime.Today.AddYears(1)
		);

		var erros = condutor.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"EMAIL\" deve seguir um padrão válido!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Com_Erro_Telefone()
	{
		var condutor = new Condutor
		(
			idCliente: 1,
			clienteCondutor: true,
			nome: "Pedro Cunha",
			email: "pedrinh@exemplo.com",
			telefone: "",
			cpf: "123.456.789-00",
			cnh: "12345678901",
			validadeCnh: DateTime.Today.AddYears(1)
		);

		var erros = condutor.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"TELEFONE\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_CPF_Invalido()
	{
		var condutor = new Condutor
		(
			idCliente: 1,
			clienteCondutor: true,
			nome: "Pedro Cunha",
			email: "pedrinh@exemplo.com",
			telefone: "(99) 99999-9999",
			cpf: "",
			cnh: "12345678901",
			validadeCnh: DateTime.Today.AddYears(1)
		);

		var erros = condutor.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"CPF\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_CNH_Invalido()
	{
		var condutor = new Condutor
		(
			idCliente: 1,
			clienteCondutor: true,
			nome: "Pedro Cunha",
			email: "pedrinh@exemplo.com",
			telefone: "(99) 99999-9999",
			cpf: "123.456.789-00",
			cnh: "",
			validadeCnh: DateTime.Today.AddYears(1)
		);

		var erros = condutor.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"CNH\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Validade_CNH_Invalid()
	{
		var condutor = new Condutor
		(
			idCliente: 1,
			clienteCondutor: true,
			nome: "Pedro Cunha",
			email: "pedrinh@exemplo.com",
			telefone: "(99) 99999-9999",
			cpf: "123.456.789-00",
			cnh: "12345678901",
			validadeCnh: DateTime.Today.AddDays(-2)
		);

		var erros = condutor.Validar();

		List<string> errosEsperados = new List<string>
		{
			"A validade da \"CNH\" está vencida!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}
}