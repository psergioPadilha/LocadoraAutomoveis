using AutoMapper;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Aplicacao.ModuloCliente;
using ControleLocadoraAutomoveis.Aplicacao.ModuloCondutor;
using ControleLocadoraAutomoveis.Dominio.ModuloCondutor;
using ControleLocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleLocadoraAutomoveis.WebApp.Controllers;

[Authorize(Roles = "Empresa,Funcionario")]
public class CondutorController : WebControllerBase
{
	private readonly ServicoCondutor servicoCondutor;
	private readonly ServicoCliente servicoCliente;
	private readonly IMapper mapper;

	public CondutorController(ServicoAutenticacao servicoAutenticacao, ServicoCondutor servicoCondutor,
        ServicoCliente servicoCliente, IMapper mapper) : base(servicoAutenticacao)
	{
		this.servicoCondutor = servicoCondutor;
        this.servicoCliente = servicoCliente;
		this.mapper = mapper;
	}

	public IActionResult Listar()
	{
		var resultado = servicoCondutor.SelecionarTodos(IdEmpresa.GetValueOrDefault());

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction("Index", "Home");
		}

		var condutores = resultado.Value;

		var listarCondutores = mapper.Map<IEnumerable<ListarCondutorViewModel>>(condutores);

		return View(listarCondutores);
	}

	public IActionResult Inserir()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Inserir(InserirCondutorViewModel inserir)
	{
		if (!ModelState.IsValid)
			return View(inserir);

		var condutor = mapper.Map<Condutor>(inserir);

		var resultado = servicoCondutor.Inserir(condutor);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		ApresentarMensagemSucesso($"O registro [{condutor.Nome}] foi inserido com sucesso!");

		return RedirectToAction(nameof(Listar));
	}

	public IActionResult Editar(int id)
	{
		var resultado = servicoCondutor.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var condutor = resultado.Value;

		var editar = mapper.Map<EditarCondutorViewModel>(condutor);

		return View(editar);
	}

	[HttpPost]
	public IActionResult Editar(EditarCondutorViewModel editar)
	{
		if (!ModelState.IsValid)
			return View(editar);

		var condutor = mapper.Map<Condutor>(editar);

		var resultado = servicoCondutor.Editar(condutor);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		ApresentarMensagemSucesso($"O registro [{condutor.Nome}] foi editado com sucesso!");

		return RedirectToAction(nameof(Listar));
	}

    public IActionResult SelecionarCliente()
    {
        var clientesResult = servicoCliente.SelecionarTodos(IdEmpresa.GetValueOrDefault());

        if (clientesResult.IsFailed)
            return RedirectToAction("Index", "Home");

        var clientes = clientesResult.Value;

        var selecionar = new SelecionarClienteViewModel()
        {
            Clientes = clientes.Select(c => new SelectListItem(c.Nome, c.Id.ToString()))
        };

        return View(selecionar);
    }

    [HttpPost]
    public IActionResult SelecionarCliente(SelecionarClienteViewModel selecionarClienteViewmodel)
    {
        if (!ModelState.IsValid)
            return View(selecionarClienteViewmodel);

        int idCliente = selecionarClienteViewmodel.IdCliente;
        bool clienteCondutor = selecionarClienteViewmodel.ClienteCondutor;

        return RedirectToAction("PreencherCondutor", new { clienteId = idCliente, clienteCondutor });
    }

    public IActionResult PreencherCondutor(int idCliente, bool clienteCondutor)
    {
        var clienteResult = servicoCliente.SelecionarPorId(idCliente);

        if (clienteResult.IsFailed)
            return RedirectToAction("SelecionarCliente");

        var cliente = clienteResult.Value;

        var viewModel = new FormularioCondutorViewModel();

        if (clienteCondutor)
        {
            viewModel.IdCliente = idCliente;
            viewModel.ClienteCondutor = clienteCondutor;
            viewModel.Nome = cliente.Nome;
            viewModel.Email = cliente.Email;
            viewModel.Telefone = cliente.Telefone;
            viewModel.CPF = cliente.NumeroDocumento;
        }

        ViewBag.ClienteSelecionado = cliente.Nome;

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult PreencherCondutor(FormularioCondutorViewModel inserir)
    {
        if (!ModelState.IsValid)
            return View(inserir);

        var condutor = mapper.Map<Condutor>(inserir);

        var resultado = servicoCondutor.Inserir(condutor);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{condutor.Id}] foi inserido com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
	{
		var resultado = servicoCondutor.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var condutor = resultado.Value;

		var detalhes = mapper.Map<DetalhesCondutorViewModel>(condutor);

		return View(detalhes);
	}

	[HttpPost]
	public IActionResult Excluir(DetalhesCondutorViewModel detalhes)
	{
		var resultado = servicoCondutor.Excluir(detalhes.Id);

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
		var resultado = servicoCondutor.SelecionarPorId(id);

		if (resultado.IsFailed)
		{
			ApresentarMensagemFalha(resultado.ToResult());

			return RedirectToAction(nameof(Listar));
		}

		var condutor = resultado.Value;

		var detalhes = mapper.Map<DetalhesCondutorViewModel>(condutor);

		return View(detalhes);
	}
}