using System.ComponentModel.DataAnnotations;

namespace ControleLocadoraAutomoveis.Dominio.ModuloAutenticacao;
public enum TipoUsuarioEnum
{
	Empresa,
	[Display(Name = "Funcionário")] Funcionario
}