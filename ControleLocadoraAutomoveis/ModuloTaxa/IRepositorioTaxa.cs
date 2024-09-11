using ControleLocadoraAutomoveis.Dominio.Compartilhado;

namespace ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;

public interface IRepositorioTaxa : IRepositorio<Taxa>
{
	List<Taxa> SelecionarMuitos(List<int> idsTaxasSelecionadas);
}