using ControleLocadoraAutomoveis.Dominio.ModuloCliente;

namespace ControleLocadoraAutomoveis.Testes.Unidade.ModuloCliente;

[TestClass]
[TestCategory("Unidade")]
public class ClienteTests
{
	[TestMethod]
	public void Deve_Criar_Instancia_Valida()
	{
		var cliente = new Cliente
		(
			nome: "Carlos Abreu",
			email: "carlosabreu@exemplo.com",
			telefone: "(49) 99999-9999",
			tipoCliente: TipoClienteEnum.CPF,
			numeroDocumento: "123.456.789-00",
			estado: "Santa Catarina",
			cidade: "Lages",
			bairro: "Coral",
			rua: "AV Luiz de Camões",
			numeroEndereco: "520"
		);

		var erros = cliente.Validar();

		Assert.AreEqual(0, erros.Count);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Invalida()
	{
		var cliente = new Cliente
		(
			nome: "",
			email: "carlosabreu@exemplo.com",
			telefone: "(49) 99999-9999",
			tipoCliente: TipoClienteEnum.CPF,
			numeroDocumento: "123.456.789-00",
			estado: "Santa Catarina",
			cidade: "Lages",
			bairro: "Coral",
			rua: "AV Luiz de Camões",
			numeroEndereco: "520"
		);

		var erros = cliente.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"NOME CLIENTE\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Com_Erro_Email()
	{
		var cliente = new Cliente
		(
			nome: "Carlos Abreu",
			email: "",
			telefone: "(49) 99999-9999",
			tipoCliente: TipoClienteEnum.CPF,
			numeroDocumento: "123.456.789-00",
			estado: "Santa Catarina",
			cidade: "Lages",
			bairro: "Coral",
			rua: "AV Luiz de Camões",
			numeroEndereco: "520"
		);

		var erros = cliente.Validar();

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
		var cliente = new Cliente
		(
			nome: "Carlos Abreu",
			email: "carlosabreu  com",
			telefone: "(49) 99999-9999",
			tipoCliente: TipoClienteEnum.CPF,
			numeroDocumento: "123.456.789-00",
			estado: "Santa Catarina",
			cidade: "Lages",
			bairro: "Coral",
			rua: "AV Luiz de Camões",
			numeroEndereco: "520"
		);

		var erros = cliente.Validar();

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
		var cliente = new Cliente
		(
			nome: "Carlos Abreu",
			email: "carlosabreu@exemplo.com",
			telefone: "",
			tipoCliente: TipoClienteEnum.CPF,
			numeroDocumento: "123.456.789-00",
			estado: "Santa Catarina",
			cidade: "Lages",
			bairro: "Coral",
			rua: "AV Luiz de Camões",
			numeroEndereco: "520"
		);

		var erros = cliente.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"TELEFONE\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Documento_Invalido()
	{
		var cliente = new Cliente
		(
			nome: "Carlos Abreu",
			email: "carlosabreu@exemplo.com",
			telefone: "(49) 99999-9999",
			tipoCliente: TipoClienteEnum.CPF,
			numeroDocumento: "",
			estado: "Santa Catarina",
			cidade: "Lages",
			bairro: "Coral",
			rua: "AV Luiz de Camões",
			numeroEndereco: "520"
		);

		var erros = cliente.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"NÚMERO DO DOCUMENTO\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Estado_Invalido()
	{
		var cliente = new Cliente
		(
			nome: "Carlos Abreu",
			email: "carlosabreu@exemplo.com",
			telefone: "(49) 99999-9999",
			tipoCliente: TipoClienteEnum.CPF,
			numeroDocumento: "123.456.789-00",
			estado: "",
			cidade: "Lages",
			bairro: "Coral",
			rua: "AV Luiz de Camões",
			numeroEndereco: "520"
		);

		var erros = cliente.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"ESTADO\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Validade_Cidade_Invalida()
	{
		var cliente = new Cliente
		(
			nome: "Carlos Abreu",
			email: "carlosabreu@exemplo.com",
			telefone: "(49) 99999-9999",
			tipoCliente: TipoClienteEnum.CPF,
			numeroDocumento: "123.456.789-00",
			estado: "Santa Catarina",
			cidade: "",
			bairro: "Coral",
			rua: "AV Luiz de Camões",
			numeroEndereco: "520"
		);

		var erros = cliente.Validar();

		List<string> errosEsperados = new List<string>
		{
			"A \"CIDADE\" é obrigatória!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Validade_Bairro_Invalida()
	{
		var cliente = new Cliente
		(
			nome: "Carlos Abreu",
			email: "carlosabreu@exemplo.com",
			telefone: "(49) 99999-9999",
			tipoCliente: TipoClienteEnum.CPF,
			numeroDocumento: "123.456.789-00",
			estado: "Santa Catarina",
			cidade: "Lages",
			bairro: "",
			rua: "AV Luiz de Camões",
			numeroEndereco: "520"
		);

		var erros = cliente.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"BAIRRO\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Validade_Rua_Invalida()
	{
		var cliente = new Cliente
		(
			nome: "Carlos Abreu",
			email: "carlosabreu@exemplo.com",
			telefone: "(49) 99999-9999",
			tipoCliente: TipoClienteEnum.CPF,
			numeroDocumento: "123.456.789-00",
			estado: "Santa Catarina",
			cidade: "Lages",
			bairro: "Coral",
			rua: "",
			numeroEndereco: "520"
		);

		var erros = cliente.Validar();

		List<string> errosEsperados = new List<string>
		{
			"A \"RUA\" é obrigatória!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Validade_Numero_Residencia_Invalida()
	{
		var cliente = new Cliente
		(
			nome: "Carlos Abreu",
			email: "carlosabreu@exemplo.com",
			telefone: "(49) 99999-9999",
			tipoCliente: TipoClienteEnum.CPF,
			numeroDocumento: "123.456.789-00",
			estado: "Santa Catarina",
			cidade: "Lages",
			bairro: "Coral",
			rua: "AV Luiz de Camões",
			numeroEndereco: ""
		);

		var erros = cliente.Validar();

		List<string> errosEsperados = new List<string>
		{
			"O \"NÚMERO DA RESIDÊNCIA\" é obrigatório!"
		};

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}
}