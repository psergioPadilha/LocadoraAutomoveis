using ControleLocadoraAutomoveis.Dominio.Compartilhado;

namespace ControleLocadoraAutomoveis.Dominio.ModuloPlanoDeCobranca;

public interface IRepositorioPlanoDeCobranca : IRepositorio<PlanoDeCobranca>
{
	PlanoDeCobranca? FiltrarPlano(Func<PlanoDeCobranca, bool> predicate);
}