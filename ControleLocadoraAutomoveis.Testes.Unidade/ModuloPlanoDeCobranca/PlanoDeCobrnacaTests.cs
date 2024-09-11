using ControleLocadoraAutomoveis.Dominio.ModuloPlanoDeCobranca;

namespace ControleLocadoraAutomoveis.Testes.Unidade.ModuloPlanoDeCobranca;

[TestClass]
[TestCategory("Unidade")]
public class PlanoDeCobrnacaTests
{
	[TestMethod]
	public void Deve_Criar_Instancia_Valida()
	{
		var planoDeCobrbranca = new PlanoDeCobranca
		(
			1,
			100.0m,
			1.0m,
			200.0m,
			80.0m,
			2.0m,
			150.0m
		);

		var erros = planoDeCobrbranca.Validar();

		Assert.AreEqual(0, erros.Count);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Invalida()
	{
		var planoDeCobrbranca = new PlanoDeCobranca
		(
			0,
			100.0m,
			1.0m,
			200.0m,
			80.0m,
			2.0m,
			150.0m
		);

		var erros = planoDeCobrbranca.Validar();

		List<string> errosEsperados = ["O \"GRUPO AUTOMÓVEIS\" é obrigatório!"];

		Assert.AreEqual(errosEsperados.Count, erros.Count);
		CollectionAssert.AreEqual(errosEsperados, erros);
	}
}