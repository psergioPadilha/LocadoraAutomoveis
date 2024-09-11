using AutoMapper;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Aplicacao.ModuloCliente;
using ControleLocadoraAutomoveis.Dominio.ModuloCliente;
using ControleLocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ControleLocadoraAutomoveis.WebApp.Controllers;

[Authorize(Roles = "Empresa,Funcionario")]
public class ClienteController : WebControllerBase
{
	private readonly ServicoCliente servico;
	private readonly IMapper mapper;

	public ClienteController(ServicoAutenticacao servicoAutenticacao, ServicoCliente servico, IMapper mapper) : base(servicoAutenticacao)
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

		var clientes = resultado.Value;

		var listarClientes = mapper.Map<IEnumerable<ListarClienteViewModel>>(clientes);

		return View(listarClientes);
	}

	public IActionResult Inserir()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Inserir(InserirClienteViewModel inserir)
	{
		if (!ModelState.IsValid)
			return View(inserir);

		var cliente = mapper.Map<Cliente>(inserir);

		var resultado = servico.Inserir(cliente);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		ApresentarMensagemSucesso($"O registro [{cliente.Nome}] foi inserido com sucesso!");

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

		var cliente = resultado.Value;

		var editar = mapper.Map<EditarClienteViewModel>(cliente);

		return View(editar);
	}

	[HttpPost]
	public IActionResult Editar(EditarClienteViewModel editar)
	{
		if (!ModelState.IsValid)
			return View(editar);

		var cliente = mapper.Map<Cliente>(editar);

		var resultado = servico.Editar(cliente);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		ApresentarMensagemSucesso($"O registro [{cliente.Id}] foi editado com sucesso!");

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

		var cliente = resultado.Value;

		var detalhes = mapper.Map<DetalhesClienteViewModel>(cliente);

		return View(detalhes);
	}

	[HttpPost]
	public IActionResult Excluir(DetalhesClienteViewModel detalhes)
	{
		var resultado = servico.Excluir(detalhes.Id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		ApresentarMensagemSucesso($"O registro [{detalhes.Nome}] foi excluido com sucesso!");

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

		var cliente = resultado.Value;

		var detalhes = mapper.Map<DetalhesClienteViewModel>(cliente);

		return View(detalhes);
	}
}