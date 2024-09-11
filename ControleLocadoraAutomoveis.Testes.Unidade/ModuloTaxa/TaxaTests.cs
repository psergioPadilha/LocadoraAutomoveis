using ControleLocadoraAutomoveis.Dominio.ModuloTaxa;
using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;

namespace ControleLocadoraAutomoveis.Testes.Unidade.ModuloTaxa;

[TestClass]
[TestCategory("Unidade")]
public class TaxaTests
{
	[TestMethod]
	public void Deve_Criar_Instancia_Valida()
	{
		var taxa = new Taxa("Taxa de Serviço", 10.0m, TipoCobrancaEnum.Diaria);

		var erros = taxa.Validar();

		Assert.AreEqual(0, erros.Count);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Invalida_Descricao_Valor()
	{
		var taxa = new Taxa("TX", 0, TipoCobrancaEnum.Diaria);

		var erros = taxa.Validar();

		List<string> errosEsperados =
		[
			"A \"DESCRIÇÃO\" precisa conter pelomenos três caracteres!",
			"O \"VALOR\" mínimo é 1"
		];

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Invalida_Descricao()
	{
		var taxa = new Taxa("TX", 10.0m, TipoCobrancaEnum.Diaria);

		var erros = taxa.Validar();

		List<string> errosEsperados = ["A \"DESCRIÇÃO\" precisa conter pelomenos três caracteres!"];

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Invalida_Valor()
	{
		var taxa = new Taxa("Taxa de Serviço", 0, TipoCobrancaEnum.Diaria);

		var erros = taxa.Validar();

		List<string> errosEsperados = ["O \"VALOR\" mínimo é 1"];

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}
}