using AutoMapper;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Aplicacao.ModuloCombustivel;
using ControleLocadoraAutomoveis.Dominio.ModuloCombustivel;
using ControleLocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleLocadoraAutomoveis.WebApp.Controllers;

[Authorize(Roles = "Empresa,Funcionario")]
public class CombustivelController : WebControllerBase
{
    private readonly ServicoCombustivel servicoCombustivel;
    private readonly IMapper mapper;

    public CombustivelController(
        ServicoAutenticacao servicoAutenticacao,
        ServicoCombustivel servicoCombustivel,
        IMapper mapper
    ) : base(servicoAutenticacao)
    {
        this.servicoCombustivel = servicoCombustivel;
        this.mapper = mapper;
    }

    public IActionResult Configurar()
    {
        var resultado = servicoCombustivel
            .ObterConfiguracao(IdEmpresa.GetValueOrDefault());

        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");

        var configuracaoCombustivel = resultado.Value;

        var formulario = mapper.Map<FormularioConfiguracaoCombustivelViewModel>(configuracaoCombustivel);

        return View(formulario);
    }

    [HttpPost]
    public IActionResult Configurar(FormularioConfiguracaoCombustivelViewModel formularioVm)
    {
        var configuracao = mapper.Map<ConfiguracaoCombustivel>(formularioVm);

        var resultado = servicoCombustivel.SalvarConfiguracao(configuracao);

        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");

        ApresentarMensagemSucesso("A configuração foi salva com sucesso!");

        return RedirectToAction("Index", "Home");
    }
}