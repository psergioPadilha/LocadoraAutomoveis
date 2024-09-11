using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloPlanoDeCobranca;
using ControleLocadoraAutomoveis.Testes.Infraestrutura.Compartilhado;
using FizzWare.NBuilder;

namespace ControleLocadoraAutomoveis.Testes.Infraestrutura.ModuloPlanoDeCobranca;

[TestClass]
[TestCategory("Integração")]
public class RepositorioPlanoDeCobrancaTests : RepositorioTestsBase
{
	[TestMethod]
	public void Deve_Inserir_PlanoDeCobranca()
	{
		var grupo = Builder<GrupoAutomoveis>
			.CreateNew()
			.With(g => g.Id = 0)
			.Persist();

		var planoDeCobranca = Builder<PlanoDeCobranca>
			.CreateNew()
			.With(p => p.Id = 0)
			.With(p => p.IdGrupoAutomoveis = grupo.Id)
			.Build();

		repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

		var planoDeCobrancaSelecionado = repositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

		Assert.IsNotNull(planoDeCobrancaSelecionado);
		Assert.AreEqual(planoDeCobranca, planoDeCobrancaSelecionado);
	}

	[TestMethod]
	public void Deve_Editar_PlanoDeCobranca()
	{
		var grupo = Builder<GrupoAutomoveis>
			.CreateNew()
			.With(g => g.Id = 0)
			.Persist();

		var planoDeCobranca = Builder<PlanoDeCobranca>
			.CreateNew()
			.With(p => p.Id = 0)
			.With(p => p.IdGrupoAutomoveis = grupo.Id)
			.Persist();

		planoDeCobranca.PrecoDiarioPlanoDiario = 200.0m;

		repositorioPlanoDeCobranca.Editar(planoDeCobranca);

		var planoDeCobrancaSelecionado = repositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

		Assert.IsNotNull(planoDeCobrancaSelecionado);
		Assert.AreEqual(planoDeCobranca, planoDeCobrancaSelecionado);
	}

	[TestMethod]
	public void Deve_Excluir_PlanoDeCobranca()
	{
		var grupo = Builder<GrupoAutomoveis>
			.CreateNew()
			.With(g => g.Id = 0)
			.Persist();

		var planoDecobranca = Builder<PlanoDeCobranca>
			.CreateNew()
			.With(p => p.Id = 0)
			.With(p => p.IdGrupoAutomoveis = grupo.Id)
			.Persist();

		repositorioPlanoDeCobranca.Excluir(planoDecobranca);

		var planoDeCobrancaSelecionado = repositorioPlanoDeCobranca.SelecionarPorId(planoDecobranca.Id);

		var planosDeCobrancas = repositorioPlanoDeCobranca.SelecionarTodos();

		Assert.IsNull(planoDeCobrancaSelecionado);
		Assert.AreEqual(0, planosDeCobrancas.Count);
	}
}