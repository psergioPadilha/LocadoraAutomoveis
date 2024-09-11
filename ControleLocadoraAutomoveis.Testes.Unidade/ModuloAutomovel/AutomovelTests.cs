using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;

namespace ControleLocadoraAutomoveis.Testes.Unidade.ModuloAutomovel;

[TestClass]
[TestCategory("Unidade")]
public class AutomovelTests
{
	[TestMethod]
	public void Deve_Validar_Automovel_Corretamente()
	{
		// Arrange (preparação do teste)
		Automovel automovel = new Automovel("", "", 0, 0, 0);

		List<string> errosEsperados =
		[
			"O campo \"MARCA\" é obrigatório!",
			"O campo \"MODELO\" é obrigatório!",
			"A \"CAPACIDADE DO TANQUE\" precisa ser informada!",
			"O \"GRUPO VEÍCULOS\" é obrigatório!",
			"O \"TIPO DE COMBUSTÍVEL\" precisa ser informado!"
		];

		// Act (ação do teste)
		List<string> erros = automovel.Validar();

		// Assert (asserção do teste)
		CollectionAssert.AreEqual(errosEsperados, erros);
		Assert.AreEqual(errosEsperados.Count, erros.Count);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Valida()
	{
		var automovel = new Automovel("Ford", "KA 1.0 Flex", 35, 2, TipoCombustivelEnum.Gasolina);

		var erros = automovel.Validar();

		Assert.AreEqual(0, erros.Count);
	}
}
