using ControleLocadoraAutomoveis.Dominio.ModuloAutenticacao;

namespace ControleLocadoraAutomoveis.Compartilhado;
public abstract class EntidadeBase
{
	public int Id { get; set; }
	public int IdEmpresa { get; set; }
	public Usuario? Empresa { get; set; }

	public abstract List<string> Validar();
}