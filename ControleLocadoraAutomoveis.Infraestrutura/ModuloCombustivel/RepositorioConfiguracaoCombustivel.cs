using ControleLocadoraAutomoveis.Dominio.ModuloCombustivel;
using ControleLocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloCombustivel;
public class RepositorioConfiguracaoCombustivel : IRepositorioConfiguracaoCombustivel
{
	private readonly ControleLocadoraAutomoveisDbContext dbContext;

	public RepositorioConfiguracaoCombustivel(ControleLocadoraAutomoveisDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public void GravarConfiguracao(ConfiguracaoCombustivel configuracaoCombustivel)
	{
		dbContext.ConfiguracoesCombustiveis.Add(configuracaoCombustivel);

		dbContext.SaveChanges();
	}

	public ConfiguracaoCombustivel? ObterConfiguracao(int idEmpresa)
	{
		return dbContext.ConfiguracoesCombustiveis
			.OrderByDescending(c => c.Id)
			.FirstOrDefault(c => c.IdEmpresa == idEmpresa);
	}
}