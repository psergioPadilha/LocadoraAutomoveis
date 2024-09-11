using AutoMapper;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Aplicacao.ModuloTaxa;
using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using ControleLocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ControleLocadoraAutomoveis.WebApp.Controllers;

[Authorize (Roles = "Empresa,Funcionario")]
public class TaxaController : WebControllerBase
{
	private readonly ServicoTaxa servico;
	private IMapper mapper;

	public TaxaController(ServicoAutenticacao servicoAutenticacao, ServicoTaxa servico, IMapper mapper) : base(servicoAutenticacao)
	{
		this.servico = servico;
		this.mapper = mapper;
	}

	public IActionResult Listar()
	{
		var resultado = servico.SelecionarTodos(IdEmpresa.GetValueOrDefault());

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction("Index", "Home");
		}

		var taxas = resultado.Value;

		var listarTaxas = mapper.Map<IEnumerable<ListarTaxaViewModel>>(taxas);

		return View(listarTaxas);
	}

	public IActionResult Inserir()
	{
		return View(new InserirTaxaViewModel());
	}

	[HttpPost]
	public IActionResult Inserir(InserirTaxaViewModel inserir)
	{
		if (!ModelState.IsValid)
			return View(inserir);

		var taxa = mapper.Map<Taxa>(inserir);

		var resultado = servico.Inserir(taxa);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		ApresentarMensagemSucesso($"O registro ID [{taxa.Id}] foi inserido com sucesso!");

		return RedirectToAction(nameof(Listar));
	}

	public IActionResult Editar(int id)
	{
		var resultado = servico.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var taxa = resultado.Value;

		var editar = mapper.Map<EditarTaxaViewModel>(taxa);

		return View(editar);
	}

	[HttpPost]
	public IActionResult Editar(EditarTaxaViewModel editar)
	{
		if (!ModelState.IsValid)
			return View(editar);

		var taxa = mapper.Map<Taxa>(editar);

		var resultado = servico.Editar(taxa);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		ApresentarMensagemSucesso($"O registro ID [{taxa.Id}] foi editado com sucesso!");

		return RedirectToAction(nameof(Listar));
	}

	public IActionResult Excluir(int id)
	{
		var resultado = servico.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var taxa = resultado.Value;

		var detalhes = mapper.Map<DetalhesTaxaViewModel>(taxa);

		return View(detalhes);
	}

	[HttpPost]
	public IActionResult Excluir(DetalhesTaxaViewModel detalhes)
	{
		var resultado = servico.Excluir(detalhes.Id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return View(detalhes);
		}

		ApresentarMensagemSucesso($"O registro ID [{detalhes.Id}] foi excluido com sucesso!");

		return RedirectToAction(nameof(Listar));
	}

	public IActionResult Detalhes(int id)
	{
		var resultado = servico.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var taxa = resultado.Value;

		var detalhes = mapper.Map<DetalhesTaxaViewModel>(taxa);

		return View(detalhes);
	}
}