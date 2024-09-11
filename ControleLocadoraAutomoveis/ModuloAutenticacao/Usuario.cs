using Microsoft.AspNetCore.Identity;

namespace ControleLocadoraAutomoveis.Dominio.ModuloAutenticacao;

public class Usuario : IdentityUser<int>
{
	public Usuario()
	{
		EmailConfirmed = true;
	}
}