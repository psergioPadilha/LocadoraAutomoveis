using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using ControleLocadoraAutomoveis.WebApp.Extensions;
using ControleLocadoraAutomoveis.WebApp.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace ControleLocadoraAutomoveis.WebApp.Controllers.Compartilhado;

public abstract class WebControllerBase : Controller
{
	protected readonly ServicoAutenticacao servicoAutenticacao;

	protected int? IdEmpresa
	{
		get
		{
			var idEmpresa = servicoAutenticacao.ObterIdEmpresaAsync(User).Result;

			return idEmpresa;
		}
	}

	protected WebControllerBase()
	{

	}

	protected WebControllerBase(ServicoAutenticacao servicoAutenticacao)
	{
		this.servicoAutenticacao = servicoAutenticacao;
	}

	protected IActionResult MensagemRegistroNaoEncontrado(int idRegistro)
	{
		TempData.SerializarMensagemViewModel(new MensagemViewModel
		{
			Titulo = "Erro",
			Mensagem = $"Não foi possível encontrar o registro ID [{idRegistro}]"
		});

		return RedirectToAction("Index", "Home");
	}

	protected void ApresentarMensagemFalha(Result resultado)
	{
		ViewBag.Mensagem = new MensagemViewModel
		{
			Titulo = "Falha",
			Mensagem = resultado.Errors[0].Message
		};
	}

	protected void ApresentarMensagemSucesso(string mensagem)
	{
		TempData.SerializarMensagemViewModel(new MensagemViewModel
		{
			Titulo = "Sucesso",
			Mensagem = mensagem
		});
	}

}