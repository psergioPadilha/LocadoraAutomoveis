using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace ControleLocadoraAutomoveis.Testes.Unidade.ModuloGrupoAutomoveis;

[TestClass]
[TestCategory("Unidade")]
public class GrupoAutomoveisTests
{
	[TestMethod]
	public void Deve_Validar_GrupoAutomoveis_Corretamente()
	{
		// Arrange (preparação do teste)
		GrupoAutomoveis grupoAutomoveisInvalido = new GrupoAutomoveis("");

		List<string> errosEsperados =
		[
			"O campo \"DESCRIÇÃO\" é obrigatorio!"
		];

		// Act (ação do teste)
		List<string> erros = grupoAutomoveisInvalido.Validar();

		// Assert (asserção do teste)
		CollectionAssert.AreEqual(errosEsperados, erros);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Valida()
	{
		// Arrange (preparação do teste)
		var grupo = new GrupoAutomoveis("PCD");

		// Act (ação do teste)
		var erros = grupo.Validar();

		// Assert (asserção do teste)
		Assert.AreEqual(0, erros.Count);
	}

	[TestMethod]
	public void Deve_Criar_Instancia_Invalida()
	{
		// Arrange (preparação do teste)
		var grupo = new GrupoAutomoveis("PC");

		// Act (ação do teste)
		var erros = grupo.Validar();

		// Assert (asserção do teste)
		Assert.AreEqual(1, erros.Count);
	}
}
