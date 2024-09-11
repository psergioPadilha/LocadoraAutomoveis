using System.Reflection;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutomovel;
using ControleLocadoraAutomoveis.Aplicacao.ModuloCliente;
using ControleLocadoraAutomoveis.Aplicacao.ModuloCombustivel;
using ControleLocadoraAutomoveis.Aplicacao.ModuloCondutor;
using ControleLocadoraAutomoveis.Aplicacao.ModuloFuncionario;
using ControleLocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Aplicacao.ModuloLocacao;
using ControleLocadoraAutomoveis.Aplicacao.ModuloPlanosDeCobranca;
using ControleLocadoraAutomoveis.Aplicacao.ModuloTaxa;
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
using ControleLocadoraAutomoveis.Infraestrutura.Compartilhado;
using ControleLocadoraAutomoveis.Infraestrutura.ModduloAltomovel;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloCliente;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloCombustivel;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloCondutor;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloFuncionario;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloGrupoPlanoDeCobranca;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloLocacao;
using ControleLocadoraAutomoveis.Infraestrutura.ModuloTaxa;
using ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace ControleLocadoraAutomoveis.WebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<ControleLocadoraAutomoveisDbContext>();

			builder.Services.AddScoped<IRepositorioGrupoAutomoveis, RepositorioGrupoAutomoveis>();
			builder.Services.AddScoped<IRepositorioAutomovel, RepositorioAutomovel>();
			builder.Services.AddScoped<IRepositorioPlanoDeCobranca, RepositorioPlanoDeCobranca>();
			builder.Services.AddScoped<IRepositorioTaxa, RepositorioTaxa>();
			builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
			builder.Services.AddScoped<IRepositorioCondutor, RepositorioCondutor>();
			builder.Services.AddScoped<IRepositorioConfiguracaoCombustivel, RepositorioConfiguracaoCombustivel>();
            builder.Services.AddScoped<IRepositorioLocacao, RepositorioLocacao>();
			builder.Services.AddScoped<IRepositorioFuncionario, RepositorioFuncionario>();

			builder.Services.AddScoped<ServicoGrupoAutomoveis>();
			builder.Services.AddScoped<ServicoAutomovel>();
			builder.Services.AddScoped<ServicoPlanoDeCobranca>();
			builder.Services.AddScoped<ServicoTaxa>();
			builder.Services.AddScoped<ServicoCliente>();
			builder.Services.AddScoped<ServicoCondutor>();
			builder.Services.AddScoped<ServicoCombustivel>();
            builder.Services.AddScoped<ServicoLocacao>();
			builder.Services.AddScoped<ServicoFuncionario>();

			builder.Services.AddScoped<FotoValueResolver>();
			builder.Services.AddScoped<GrupoDeAutomoveisValueResolver>();
			builder.Services.AddScoped<TaxasSelecionadasValueResolver>();
			builder.Services.AddScoped<TaxasValueResolver>();
			builder.Services.AddScoped<CondutoresValueResolver>();
			builder.Services.AddScoped<AutomoveisValueResolver>();
			builder.Services.AddScoped<ValorParcialValueResolver>();
			builder.Services.AddScoped<ValorTotalValueResolver>();
			builder.Services.AddScoped<IdEmpresaValueResolver>();

			builder.Services.AddAutoMapper(cfg =>
			{
				cfg.AddMaps(Assembly.GetExecutingAssembly());
			});

			builder.Services.AddScoped<ServicoAutenticacao>();

			builder.Services.AddIdentity<Usuario, Perfil>()
				.AddEntityFrameworkStores<ControleLocadoraAutomoveisDbContext>()
				.AddDefaultTokenProviders();

			builder.Services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequiredLength = 3;
				options.Password.RequiredUniqueChars = 1;
			});

			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.Cookie.Name = "AspNetCore.Cookies";
					options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
					options.SlidingExpiration = true;
				});

			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Autenticacao/Login";
				options.AccessDeniedPath = "/Autenticacao/AcessoNegado";
			});

			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				// Faz com que a aplicação permita apenas conexões HTTPS em navegadores suportados
				app.UseHsts();
			}

			// Redireciona requisições HTTP para HTTPS
			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
