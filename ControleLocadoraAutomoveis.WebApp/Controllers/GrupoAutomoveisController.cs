using AutoMapper;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleLocadoraAutomoveis.WebApp.Controllers;

[Authorize(Roles = "Empresa,Funcionario")]
public class GrupoAutomoveisController : WebControllerBase
{
	private readonly ServicoGrupoAutomoveis servicoGrupoAutomoveis;
	private readonly IMapper mapper;

	public GrupoAutomoveisController(ServicoAutenticacao servicoAutenticacao,
        ServicoGrupoAutomoveis servicoGrupoAutomoveis, IMapper mapper) : base(servicoAutenticacao)
	{
		this.servicoGrupoAutomoveis = servicoGrupoAutomoveis;
		this.mapper = mapper;
	}

	public IActionResult Listar()
	{
		var resultado = servicoGrupoAutomoveis.SelecionarTodos(IdEmpresa.GetValueOrDefault());

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction("Index", "Home");
		}

		var grupos = resultado.Value;

		var ListarGrupos = mapper.Map<IEnumerable<ListarGrupoAutomoveisViewModel>>(grupos);

		return View(ListarGrupos);
	}

	public IActionResult Inserir()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Inserir(InserirGrupoAutomoveisViewModel inserir)
	{
		if (!ModelState.IsValid)
			return View(inserir);

		var grupo = mapper.Map<GrupoAutomoveis>(inserir);

		var resultado = servicoGrupoAutomoveis.Inserir(grupo);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi inserido com sucesso!");

		return RedirectToAction(nameof(Listar));
	}

	public IActionResult Editar(int id)
	{
		var resultado = servicoGrupoAutomoveis.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var grupo = resultado.Value;

		var editar = mapper.Map<EditarGrupoAutomoveisViewModel>(grupo);

		return View(editar);
	}

	[HttpPost]
	public IActionResult Editar(EditarGrupoAutomoveisViewModel editar)
	{
		if (!ModelState.IsValid)
			return View(editar);

		var grupo = mapper.Map<GrupoAutomoveis>(editar);

		var resultado = servicoGrupoAutomoveis.Editar(grupo);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi editado com sucesso!");

		return RedirectToAction(nameof(Listar));
	}

	public IActionResult Excluir(int id)
	{
		var resultado = servicoGrupoAutomoveis.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var grupo = resultado.Value;

		var detalhes = mapper.Map<DetalhesGrupoAutomoveisViewModel>(grupo);

		return View(detalhes);
	}

	[HttpPost]
	public IActionResult Excluir(DetalhesGrupoAutomoveisViewModel detalhes)
	{
		var resultado = servicoGrupoAutomoveis.Excluir(detalhes.Id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		ApresentarMensagemSucesso($"O registro ID [{detalhes.Id}] foi excluido com sucesso!");

		return RedirectToAction(nameof(Listar));
	}

	public IActionResult Detalhes(int id)
	{
		var resultado = servicoGrupoAutomoveis.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var grupo = resultado.Value;

		var detalhes = mapper.Map<DetalhesGrupoAutomoveisViewModel>(grupo);

		return View(detalhes);
	}
}
