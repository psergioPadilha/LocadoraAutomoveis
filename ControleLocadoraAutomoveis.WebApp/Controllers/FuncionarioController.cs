using AutoMapper;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Aplicacao.ModuloFuncionario;
using ControleLocadoraAutomoveis.Dominio.ModuloFuncionario;
using ControleLocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleLocadoraAutomoveis.WebApp.Controllers;

[Authorize(Roles = "Empresa")]
public class FuncionarioController : WebControllerBase
{
    private readonly ServicoFuncionario servicoFuncionario;
    private readonly IMapper mapper;

    public FuncionarioController
    (
        ServicoFuncionario servicoFuncionario,
        ServicoAutenticacao servicoAutenticacao,
        IMapper mapper
    ) : base(servicoAutenticacao)
    {
        this.servicoFuncionario = servicoFuncionario;
        this.mapper = mapper;
    }

    public async Task<IActionResult> Listar()
    {
        var resultado = servicoFuncionario
            .SelecionarFuncionariosDaEmpresa(IdEmpresa.GetValueOrDefault());

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var funcionarios = resultado.Value;

        var listarFuncionarios = mapper.Map<IEnumerable<ListarFuncionarioViewModel>>(funcionarios);

        return View(listarFuncionarios);
    }

    public IActionResult Inserir()
    {
        return View(new InserirFuncionarioViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Inserir(InserirFuncionarioViewModel inserir)
    {
        if (!ModelState.IsValid)
            return View(inserir);

        var funcionario = mapper.Map<Funcionario>(inserir);

        var resultadoFuncionario = await servicoFuncionario.Inserir
        (
            funcionario,
            inserir.Usuario,
            inserir.Senha
        );

        if (resultadoFuncionario.IsFailed)
        {
            ApresentarMensagemFalha(resultadoFuncionario.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O funcionário ID \"[{funcionario.Nome}]\" foi inserido com sucesso!");

        return RedirectToAction(nameof(Listar));
    }
}