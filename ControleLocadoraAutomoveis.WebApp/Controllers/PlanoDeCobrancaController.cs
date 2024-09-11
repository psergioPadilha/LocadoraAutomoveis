using AutoMapper;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Aplicacao.ModuloPlanosDeCobranca;
using ControleLocadoraAutomoveis.Dominio.ModuloPlanoDeCobranca;
using ControleLocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleLocadoraAutomoveis.WebApp.Controllers;

[Authorize(Roles = "Empresa,Funcionario")]
public class PlanoDeCobrancaController : WebControllerBase
{
    private readonly ServicoPlanoDeCobranca servicoPlanoDeCobranca;
    private readonly ServicoGrupoAutomoveis servicoGrupoAutomoveis;
    private readonly IMapper mapper;

    public PlanoDeCobrancaController(ServicoAutenticacao servicoAutenticacao, ServicoPlanoDeCobranca servicoPlanoDeCobranca,
        ServicoGrupoAutomoveis servicoGrupoAutomoveis, IMapper mapper) : base (servicoAutenticacao)
    {
        this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
        this.servicoGrupoAutomoveis = servicoGrupoAutomoveis;
        this.mapper = mapper;
    }

    public IActionResult Listar()
    {
        var resultado = servicoPlanoDeCobranca.SelecionarTodos(IdEmpresa.GetValueOrDefault());

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var planosCobrancas = resultado.Value;

        var listarPlanos = mapper.Map<IEnumerable<ListarPlanoDeCobrancaViewModel>>(planosCobrancas);

        return View(listarPlanos);
    }

    public IActionResult Inserir()
    {
        return View(CarregarDadosFormulario());
    }

    [HttpPost]
    public IActionResult Inserir(InserirPlanoDeCobrancaViewModel inserirViewModel)
    {
        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(inserirViewModel));

        var planoDeCobranca = mapper.Map<PlanoDeCobranca>(inserirViewModel);

        var resultado = servicoPlanoDeCobranca.Inserir(planoDeCobranca);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{planoDeCobranca.Id}] foi inserido com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var resultado = servicoPlanoDeCobranca.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var planoDeCobranca = resultado.Value;

        var editar = mapper.Map<EditarPlanoDeCobrancaViewModel>(planoDeCobranca);

        var grupos = servicoGrupoAutomoveis.SelecionarTodos(IdEmpresa.GetValueOrDefault()).Value;

        editar.GruposAutomoveis = grupos.Select(g => new SelectListItem(g.Descricao, g.Id.ToString()));

        return View(editar);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(EditarPlanoDeCobrancaViewModel editar)
    {
        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(editar));

        var planoDeCobranca = mapper.Map<PlanoDeCobranca>(editar);

        var resultado = servicoPlanoDeCobranca.Editar(planoDeCobranca);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{planoDeCobranca.Id}] foi editado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = servicoPlanoDeCobranca.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var planoDeCobranca = resultado.Value;

        var detalhes = mapper.Map<DetalhesPlanoDeCobrancaViewModel>(planoDeCobranca);

        return View(detalhes);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesPlanoDeCobrancaViewModel detalhes)
    {
        var resultado = servicoPlanoDeCobranca.Excluir(detalhes.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{detalhes.Id}] foi excluído com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Detalhes(int id)
    {
        var resultado = servicoPlanoDeCobranca.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var planoDeCobranca = resultado.Value;

        var detalhes = mapper.Map<DetalhesPlanoDeCobrancaViewModel>(planoDeCobranca);

        return View(detalhes);
    }

    private FormularioPlanoDeCobrancaViewModel? CarregarDadosFormulario(FormularioPlanoDeCobrancaViewModel? formulario = null)
    {
        var resultadoGrupoAutomoveis = servicoGrupoAutomoveis.SelecionarTodos(IdEmpresa.GetValueOrDefault());

        if (resultadoGrupoAutomoveis.IsFailed)
        {
            ApresentarMensagemFalha(resultadoGrupoAutomoveis.ToResult());

            return null;
        }

        if (formulario is null)
        {
            var formularioViewModel = new FormularioPlanoDeCobrancaViewModel
            {
                GruposAutomoveis = resultadoGrupoAutomoveis.Value
                    .Select(g => new SelectListItem(g.Descricao, g.Id.ToString()))
            };

            return formularioViewModel;
        }

        formulario.GruposAutomoveis = resultadoGrupoAutomoveis.Value
            .Select(g => new SelectListItem(g.Descricao, g.Id.ToString()));

        return formulario;
    }
}