using ControleLocadoraAutomoveis.Dominio.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloCliente;
using ControleLocadoraAutomoveis.Dominio.ModuloCombustivel;
using ControleLocadoraAutomoveis.Dominio.ModuloCondutor;
using ControleLocadoraAutomoveis.Dominio.ModuloFuncionario;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;
using ControleLocadoraAutomoveis.Dominio.ModuloPlanoDeCobranca;
using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloGrupoAutomoveis;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleLocadoraAutomoveis.Infraestrutura.Compartilhado;
public class ControleLocadoraAutomoveisDbContext : IdentityDbContext<Usuario, Perfil, int>
{
	public DbSet<GrupoAutomoveis> GruposAutomoveis { get; set; }
	public DbSet<Automovel> Automoveis { get; set; }
	public DbSet<PlanoDeCobranca> PlanosDeCobrancas { get; set; }
	public DbSet<Taxa> Taxas { get; set; }
	public DbSet<Cliente> Clientes { get; set; }
	public DbSet<Condutor> Condutores { get; set; }
	public DbSet<Funcionario> Funcionarios { get; set; }
	public DbSet<Usuario> Usuarios { get; set; }
	public DbSet<Locacao> Locacoes { get; set; }
	public DbSet<ConfiguracaoCombustivel> ConfiguracoesCombustiveis { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var connectionString = config.GetConnectionString("SqlServer");

		optionsBuilder.UseSqlServer(connectionString);

		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var assembly = typeof(ControleLocadoraAutomoveisDbContext).Assembly;

		modelBuilder.ApplyConfigurationsFromAssembly(assembly);

		base.OnModelCreating(modelBuilder);
	}
}