using AutoMapper;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutomovel;
using ControleLocadoraAutomoveis.Aplicacao.ModuloCondutor;
using ControleLocadoraAutomoveis.Aplicacao.ModuloLocacao;
using ControleLocadoraAutomoveis.Aplicacao.ModuloTaxa;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;
using ControleLocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ControleLocadoraAutomoveis.WebApp.Controllers;

[Authorize(Roles = "Empresa,Funcionario")]
public class LocacaoController : WebControllerBase
{
    private readonly ServicoLocacao servicoLocacao;
    private readonly ServicoAutomovel servicoAutomovel;
    private readonly ServicoCondutor servicoCondutor;
    private readonly ServicoTaxa servicoTaxa;
    private readonly IMapper mapper;

    public LocacaoController(
        ServicoAutenticacao servicoAutenticacao,
        ServicoLocacao servicoLocacao,
        ServicoAutomovel servicoAutomovel,
        ServicoCondutor servicoCondutor,
        ServicoTaxa servicoTaxa,
        IMapper mapper
    ) : base(servicoAutenticacao)
    {
        this.servicoLocacao = servicoLocacao;
        this.servicoAutomovel = servicoAutomovel;
        this.servicoCondutor = servicoCondutor;
        this.servicoTaxa = servicoTaxa;
        this.mapper = mapper;
    }

    public IActionResult Listar()
    {
        var resultado = servicoLocacao.SelecionarTodos(IdEmpresa.GetValueOrDefault());

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var locacoes = resultado.Value;

        var listarLocacoesVm = mapper.Map<IEnumerable<ListarLocacaoViewModel>>(locacoes);

        return View(listarLocacoesVm);
    }

    public IActionResult Inserir()
    {
        return View(CarregarDadosFormulario());
    }

    [HttpPost]
    public IActionResult Inserir(InserirLocacaoViewModel inserir)
    {
        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(inserir));

        var locacao = mapper.Map<Locacao>(inserir);

        var confirmar = mapper.Map<ConfirmarAberturaLocacaoViewModel>(locacao);

        TempData["LocacaoParaInsercao"] = JsonSerializer.Serialize(confirmar);

        return RedirectToAction("ConfirmarAbertura");
    }

    public IActionResult ConfirmarAbertura()
    {
        if (TempData["LocacaoParaInsercao"] is null)
            return RedirectToAction(nameof(Inserir));

        var locacaoDataJson = TempData["LocacaoParaInsercao"]!.ToString();

        var confirmar = JsonSerializer.Deserialize<ConfirmarAberturaLocacaoViewModel>(locacaoDataJson);

        return View(confirmar);
    }

    [HttpPost]
    public IActionResult ConfirmarAbertura(ConfirmarAberturaLocacaoViewModel confirmarVm)
    {
        var locacao = mapper.Map<Locacao>(confirmarVm);

        var resultado = servicoLocacao.Inserir(locacao);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"A locação ID [{locacao.Id}] foi aberta com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult RealizarDevolucao(int id)
    {
        var resultado = servicoLocacao.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var locacao = resultado.Value;

        var devolucaoVm = mapper.Map<RealizarDevolucaoViewModel>(locacao);

        return View(devolucaoVm);
    }

    [HttpPost]
    public IActionResult RealizarDevolucao(RealizarDevolucaoViewModel devolucao)
    {
        var locacao = mapper.Map<Locacao>(devolucao);

        var confirmarVm = mapper.Map<ConfirmarDevolucaoLocacaoViewModel>(locacao);

        TempData["LocacaoParaDevolucao"] = JsonSerializer.Serialize(confirmarVm);

        return RedirectToAction("ConfirmarDevolucao");

    }

    public IActionResult ConfirmarDevolucao()
    {
        if (TempData["LocacaoParaDevolucao"] is null)
            return RedirectToAction(nameof(Listar));

        var locacaoDataJson = TempData["LocacaoParaDevolucao"]!.ToString();

        var confirmarVm = JsonSerializer.Deserialize<ConfirmarDevolucaoLocacaoViewModel>(locacaoDataJson);

        return View(confirmarVm);
    }

    [HttpPost]
    public IActionResult ConfirmarDevolucao(ConfirmarDevolucaoLocacaoViewModel confirmarVm)
    {
        var locacaoOriginal = servicoLocacao.SelecionarPorId(confirmarVm.Id).Value;

        var locacaoAtualizada = mapper.Map<ConfirmarDevolucaoLocacaoViewModel, Locacao>(confirmarVm, locacaoOriginal);

        var resultado = servicoLocacao.Devolucao(locacaoAtualizada);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"A locação ID [{locacaoAtualizada.Id}] foi concluída com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    private InserirLocacaoViewModel CarregarDadosFormulario(InserirLocacaoViewModel? formularioVm = null)
    {
        var condutores = servicoCondutor.SelecionarTodos(IdEmpresa.GetValueOrDefault()).Value;
        var veiculos = servicoAutomovel.SelecionarTodos(IdEmpresa.GetValueOrDefault()).Value;
        var taxas = servicoTaxa.SelecionarTodos(IdEmpresa.GetValueOrDefault()).Value;

        if (formularioVm is null)
            formularioVm = new InserirLocacaoViewModel();

        formularioVm.Condutores =
            condutores.Select(c => new SelectListItem(c.Nome, c.Id.ToString()));

        formularioVm.Automoveis =
            veiculos.Select(c => new SelectListItem(c.Modelo, c.Id.ToString()));

        formularioVm.Taxas =
            taxas.Select(c => new SelectListItem(c.ToString(), c.Id.ToString()));

        return formularioVm;
    }
}