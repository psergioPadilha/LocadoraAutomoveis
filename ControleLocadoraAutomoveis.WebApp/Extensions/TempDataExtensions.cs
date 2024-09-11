using System.Text.Json;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ControleLocadoraAutomoveis.WebApp.Extensions;
public static class TempDataDictionaryExtensions
{
	public static void SerializarMensagemViewModel(this ITempDataDictionary dicionario, MensagemViewModel mensagem)
	{
		dicionario["Mensagem"] = JsonSerializer.Serialize(mensagem);
	}

	public static MensagemViewModel? DesserializarMensagemViewModel(this ITempDataDictionary dicionario)
	{
		var mensagem = dicionario["Mensagem"]?.ToString();

		if (mensagem is null)
			return null;

		return JsonSerializer.Deserialize<MensagemViewModel>(mensagem);
	}
}