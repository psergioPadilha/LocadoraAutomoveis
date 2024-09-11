using AutoMapper;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutomovel;
using ControleLocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;
using ControleLocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleLocadoraAutomoveis.WebApp.Controllers;

[Authorize(Roles = "Empresa,Funcionario")]
public class AutomovelController : WebControllerBase
{
	private readonly ServicoAutomovel servicoAumovel;
	private readonly ServicoGrupoAutomoveis servicoGrupoAutomoveis;
	private readonly IMapper mapper;

	public AutomovelController(ServicoAutenticacao servicoAutenticacao, ServicoAutomovel servicoAumovel,
        ServicoGrupoAutomoveis servicoGrupoAutomoveis, IMapper mapper) : base(servicoAutenticacao)
	{
		this.servicoAumovel = servicoAumovel;
		this.servicoGrupoAutomoveis = servicoGrupoAutomoveis;
		this.mapper = mapper;
	}

	public IActionResult Listar()
	{
		var resultado = servicoAumovel.SelecionarTodos(IdEmpresa.GetValueOrDefault());

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction("Index", "Home");
		}

		var automoveis = resultado.Value;

		var listarAutomovel = mapper.Map<IEnumerable<ListarAutomovelViewModel>>(automoveis);

		return View(listarAutomovel);
	}

	public IActionResult Inserir()
	{
		return View(CarregarDadosFormulario());
	}

	[HttpPost]
	public IActionResult Inserir(InserirAutomovelViewModel inserir)
	{
		if (!ModelState.IsValid)
			return View(CarregarDadosFormulario(inserir));

		var automovel = mapper.Map<Automovel>(inserir);

		var resultado = servicoAumovel.Inserir(automovel);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		ApresentarMensagemSucesso($"O registro ID [{automovel.Id}] foi inserido com sucesso!");

		return RedirectToAction(nameof(Listar));
	}

	public IActionResult Editar(int id)
	{
		var resultado = servicoAumovel.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var resultadoGrupo = servicoGrupoAutomoveis.SelecionarTodos(IdEmpresa.GetValueOrDefault());

		if (resultadoGrupo.IsFailed)
		{
			ApresentarMensagemFalha(resultadoGrupo.ToResult());

			return null;
		}

		var automovel = resultado.Value;

		var editar = mapper.Map<EditarAutomovelViewModel>(automovel);

		return View(editar);
	}

	[HttpPost]
	public IActionResult Editar(EditarAutomovelViewModel editar)
	{
		if (!ModelState.IsValid)
			return View(CarregarDadosFormulario(editar));

		var automovel = mapper.Map<Automovel>(editar);

		var resultado = servicoAumovel.Editar(automovel);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		ApresentarMensagemSucesso($"O registro ID [{automovel.Id}] foi editado com sucesso!");

		return RedirectToAction(nameof(Listar));
	}

	public IActionResult Excluir(int id)
	{
		var resultado = servicoAumovel.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var automovel = resultado.Value;

		var detalhes = mapper.Map<DetalhesAutomovelViewModel>(automovel);

		return View(detalhes);
	}

	[HttpPost]
	public IActionResult Excluir(DetalhesAutomovelViewModel detalhes)
	{
		var resultado = servicoAumovel.Excluir(detalhes.Id);

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
		var resultado = servicoAumovel.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var automovel = resultado.Value;

		var detalhes = mapper.Map<DetalhesAutomovelViewModel>(automovel);

		return View(detalhes);
	}

	public IActionResult ObterFoto(int id)
	{
		var resultado = servicoAumovel.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return NotFound();
		}

		var automovel = resultado.Value;

		return File(automovel.Foto, "image/jpeg");
	}

	private FormularioAutomovelViewModel? CarregarDadosFormulario(FormularioAutomovelViewModel? dadosPrevios = null)
	{
		var resultadoGrupos = servicoGrupoAutomoveis.SelecionarTodos(IdEmpresa.GetValueOrDefault());

		if (resultadoGrupos.IsFailed)
		{
			ApresentarMensagemFalha(resultadoGrupos.ToResult());

			return null;
		}

		var gruposDisponiveis = resultadoGrupos.Value;

		if (dadosPrevios is null)
			dadosPrevios = new FormularioAutomovelViewModel();

		dadosPrevios.GruposAutomoveis = gruposDisponiveis
			.Select(g => new SelectListItem(g.Descricao, g.Id.ToString()));

		return dadosPrevios;
	}
}