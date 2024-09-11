using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using ControleLocadoraAutomoveis.Testes.Infraestrutura.Compartilhado;
using FizzWare.NBuilder;

namespace ControleLocadoraAutomoveis.Testes.Infraestrutura.ModuloTaxa;

[TestClass]
[TestCategory("Integração")]
public class RepositorioTaxaTests : RepositorioTestsBase
{
	[TestMethod]
	public void Deve_Inserir_Taxa()
	{
		var taxa = Builder<Taxa>
			.CreateNew()
			.With(t => t.Id = 0)
			.Build();

		repositorioTaxa.Inserir(taxa);

		var taxaSelecionada = repositorioTaxa.SelecionarPorId(taxa.Id);

		Assert.IsNotNull(taxaSelecionada);
		Assert.AreEqual(taxa, taxaSelecionada);
	}

	[TestMethod]
	public void Deve_Editar_Taxa()
	{
		var taxa = Builder<Taxa>
			.CreateNew()
			.With(t => t.Id = 0)
			.Persist();

		taxa.Descricao = "Descrição Atualizada";
		taxa.Valor = 1.0m;

		repositorioTaxa.Editar(taxa);

		var taxaSelecionada = repositorioTaxa.SelecionarPorId(taxa.Id);

		Assert.IsNotNull(taxaSelecionada);
		Assert.AreEqual(taxa, taxaSelecionada);
	}

	[TestMethod]
	public void Deve_Excluir_Taxa()
	{
		var taxa = Builder<Taxa>
			.CreateNew()
			.With(t => t.Id = 0)
			.Persist();

		repositorioTaxa.Excluir(taxa);

		var taxaSelecionada = repositorioTaxa.SelecionarPorId(taxa.Id);

		var taxas = repositorioTaxa.SelecionarTodos();

		Assert.IsNull(taxaSelecionada);
		Assert.AreEqual(0, taxas.Count);
	}
}