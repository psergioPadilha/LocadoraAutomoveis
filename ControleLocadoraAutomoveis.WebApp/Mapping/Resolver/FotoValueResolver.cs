using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;
public class FotoValueResolver : IValueResolver<FormularioAutomovelViewModel, Automovel, byte[]>
{
	public FotoValueResolver()
	{

	}

	public byte[] Resolve(FormularioAutomovelViewModel source, Automovel destination, byte[] destMember, ResolutionContext context)
	{
		using (var memoryStream = new MemoryStream())
		{
			source.Foto.CopyTo(memoryStream);

			return memoryStream.ToArray();
		}
	}
}