using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloCliente;
using ControleLocadoraAutomoveis.Dominio.ModuloCondutor;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloPlanoDeCobranca;
using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using ControleLocadoraAutomoveis.Infraestrutura.Compartilhado;
using ControleLocadoraAutomoveis.Infraestrutura.ModduloAltomovel;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloCliente;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloCondutor;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloGrupoPlanoDeCobranca;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloTaxa;
using FizzWare.NBuilder;

namespace ControleLocadoraAutomoveis.Testes.Infraestrutura.Compartilhado;

public class RepositorioTestsBase
{
	protected ControleLocadoraAutomoveisDbContext dbContext;

	protected RepositorioGrupoAutomoveis repositorioGrupoAutomoveis;
	protected RepositorioAutomovel repositorioAutomovel;
	protected RepositorioCliente repositorioCliente;
	protected RepositorioCondutor repositorioCondutor;
	protected RepositorioPlanoDeCobranca repositorioPlanoDeCobranca;
	protected RepositorioTaxa repositorioTaxa;

	[TestInitialize]
	public void Inicializar()
	{
		dbContext = new ControleLocadoraAutomoveisDbContext();

		dbContext.GruposAutomoveis.RemoveRange(dbContext.GruposAutomoveis);
		dbContext.Automoveis.RemoveRange(dbContext.Automoveis);
		dbContext.Clientes.RemoveRange(dbContext.Clientes);
		dbContext.Condutores.RemoveRange(dbContext.Condutores);
		dbContext.PlanosDeCobrancas.RemoveRange(dbContext.PlanosDeCobrancas);
		dbContext.Taxas.RemoveRange(dbContext.Taxas);

		dbContext.SaveChanges();

		repositorioGrupoAutomoveis = new RepositorioGrupoAutomoveis(dbContext);
		repositorioAutomovel = new RepositorioAutomovel(dbContext);
		repositorioCliente = new RepositorioCliente(dbContext);
		repositorioCondutor = new RepositorioCondutor(dbContext);
		repositorioPlanoDeCobranca = new RepositorioPlanoDeCobranca(dbContext);
		repositorioTaxa = new RepositorioTaxa(dbContext);

		BuilderSetup.SetCreatePersistenceMethod<GrupoAutomoveis>(repositorioGrupoAutomoveis.Inserir);
		BuilderSetup.SetCreatePersistenceMethod<Automovel>(repositorioAutomovel.Inserir);
		BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);
		BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorioCondutor.Inserir);
		BuilderSetup.SetCreatePersistenceMethod<PlanoDeCobranca>(repositorioPlanoDeCobranca.Inserir);
		BuilderSetup.SetCreatePersistenceMethod<Taxa>(repositorioTaxa.Inserir);
	}
}