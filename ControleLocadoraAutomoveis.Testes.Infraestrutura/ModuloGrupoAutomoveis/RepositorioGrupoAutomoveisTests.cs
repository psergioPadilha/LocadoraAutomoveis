using ControleLocadoraAutomoveis.Testes.Infraestrutura.Compartilhado;
using FizzWare.NBuilder;
using GrupoAutomoveis = ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis;

namespace ControleLocadoraAutomoveis.Testes.Infraestrutura.ModuloGrupoAutomoveis;

[TestClass]
[TestCategory("Integração")]
public class RepositorioGrupoAutomoveisTests : RepositorioTestsBase
{
	[TestMethod]
	public void Deve_Inserir_GrupoAutomoveis()
	{
		var grupo = Builder<GrupoAutomoveis>.CreateNew().With(g => g.Id = 0).Build();

		repositorioGrupoAutomoveis.Inserir(grupo);

		var grupoSelecionado = repositorioGrupoAutomoveis.SelecionarPorId(grupo.Id);

		Assert.IsNotNull(grupoSelecionado);
		Assert.AreEqual(grupo, grupoSelecionado);
	}

	[TestMethod]
	public void Deve_Editar_GrupoAutomoveis()
	{
		var grupo = Builder<GrupoAutomoveis>.CreateNew().With(g => g.Id = 0).Persist();

		grupo.Descricao = "Teste de Edição";

		repositorioGrupoAutomoveis.Editar(grupo);

		var grupoSelecionado = repositorioGrupoAutomoveis.SelecionarPorId(grupo.Id);

		Assert.IsNotNull(grupoSelecionado);
		Assert.AreEqual(grupo, grupoSelecionado);
	}

	[TestMethod]
	public void Deve_Excluir_GrupoAutomoveis()
	{
		var grupo = Builder<GrupoAutomoveis>.CreateNew().With(g => g.Id = 0).Persist();

		repositorioGrupoAutomoveis.Excluir(grupo);

		var grupoSelecionado = repositorioGrupoAutomoveis.SelecionarPorId(grupo.Id);

		var grupos = repositorioGrupoAutomoveis.SelecionarTodos();

		Assert.IsNull(grupoSelecionado);
		Assert.AreEqual(0, grupos.Count);
	}
}
