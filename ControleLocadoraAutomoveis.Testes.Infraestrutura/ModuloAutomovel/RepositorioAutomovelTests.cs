using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Testes.Infraestrutura.Compartilhado;
using FizzWare.NBuilder;

namespace ControleLocadoraAutomoveis.Testes.Infraestrutura.ModuloAutomovel;

[TestClass]
[TestCategory("Integração")]
public class RepositorioAutomovelTests : RepositorioTestsBase
{
	[TestMethod]
	public void Deve_Inserir_Automovel()
	{
		var grupo = Builder<GrupoAutomoveis>
			.CreateNew()
			.With(g => g.Id = 0)
			.Persist();

		var automovel = Builder<Automovel>
			.CreateNew()
			.With(a => a.Id = 0)
			.With(a => a.IdGrupoAutomoveis = grupo.Id)
			.Build();

		repositorioAutomovel.Inserir(automovel);

		var automovelSelecionado = repositorioAutomovel.SelecionarPorId(automovel.Id);

		Assert.IsNotNull(automovelSelecionado);
		Assert.AreEqual(automovel, automovelSelecionado);
	}

	[TestMethod]
	public void Deve_Editar_Automovel()
	{
		var grupo = Builder<GrupoAutomoveis>
			.CreateNew()
			.With(g => g.Id = 0)
			.Persist();

		var automovel = Builder<Automovel>
			.CreateNew()
			.With(a => a.Id = 0)
			.With(a => a.IdGrupoAutomoveis = grupo.Id)
			.Persist();

		automovel.Modelo = "Novo Modelo";

		repositorioAutomovel.Editar(automovel);

		var automovelSelecionado = repositorioAutomovel.SelecionarPorId(automovel.Id);

		Assert.IsNotNull(automovelSelecionado);
		Assert.AreEqual(automovel, automovelSelecionado);
	}

	[TestMethod]
	public void Deve_Excluir_Automovel()
	{
		var grupo = Builder<GrupoAutomoveis>
			.CreateNew()
			.With(g => g.Id = 0)
			.Persist();

		var automovel = Builder<Automovel>
			.CreateNew()
			.With(a => a.Id = 0)
			.With(a => a.IdGrupoAutomoveis = grupo.Id)
			.Persist();

		repositorioAutomovel.Excluir(automovel);

		var automovelSelecionado = repositorioAutomovel.SelecionarPorId(automovel.Id);

		var automoveis = repositorioAutomovel.SelecionarTodos();

		Assert.IsNotNull(automovelSelecionado);
		Assert.AreEqual(0, automoveis.Count);
	}
}