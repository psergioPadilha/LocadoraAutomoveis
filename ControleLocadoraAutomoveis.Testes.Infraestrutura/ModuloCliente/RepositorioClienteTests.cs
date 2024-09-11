using ControleLocadoraAutomoveis.Dominio.ModuloCliente;
using ControleLocadoraAutomoveis.Testes.Infraestrutura.Compartilhado;
using FizzWare.NBuilder;

namespace ControleLocadoraAutomoveis.Testes.Infraestrutura.ModuloCliente;

[TestClass]
[TestCategory("Integração")]
public class RepositorioClienteTests : RepositorioTestsBase
{
	[TestMethod]
	public void Deve_Inserir_Cliente()
	{
		var cliente = Builder<Cliente>
			.CreateNew()
			.With(c => c.Id = 0)
			.Build();

		repositorioCliente.Inserir(cliente);

		var clienteSelecionado = repositorioCliente.SelecionarPorId(cliente.Id);

		Assert.IsNotNull(clienteSelecionado);
		Assert.AreEqual(cliente, clienteSelecionado);
	}

	[TestMethod]
	public void Deve_Editar_Cliente()
	{
		var cliente = Builder<Cliente>
			.CreateNew()
			.With(c => c.Id = 0)
			.Persist();

		cliente.Nome = "Nome Atualizado";
		cliente.Email = "nomeatualizado@exemplo.com";

		repositorioCliente.Editar(cliente);

		var clienteSelecionado = repositorioCliente.SelecionarPorId(cliente.Id);

		Assert.IsNotNull(clienteSelecionado);
		Assert.AreEqual(cliente, clienteSelecionado);
	}

	[TestMethod]
	public void Deve_Excluir_Cliente()
	{
		var cliente = Builder<Cliente>
			.CreateNew()
			.With(c => c.Id = 0)
			.Persist();

		repositorioCliente.Excluir(cliente);

		var clienteSelecionado = repositorioCliente.SelecionarPorId(cliente.Id);

		var clientes = repositorioCliente.SelecionarTodos();

		Assert.IsNull(clienteSelecionado);
		Assert.AreEqual(0, clientes.Count);
	}
}