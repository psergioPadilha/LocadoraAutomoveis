using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Dominio.ModuloAutenticacao;
using ControleLocadoraAutomoveis.WebApp.Controllers.Compartilhado;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleLocadoraAutomoveis.WebApp.Controllers;

public class AutenticacaoController : WebControllerBase
{
    private readonly ServicoAutenticacao servicoAutenticacao;

    public AutenticacaoController(ServicoAutenticacao servicoAutenticacao) : base(servicoAutenticacao)
    {
        this.servicoAutenticacao = servicoAutenticacao;
    }

    public IActionResult Registrar()
    {
        return View(new RegistrarViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(RegistrarViewModel registrar)
    {
        if (!ModelState.IsValid)
            return View(registrar);

        var usuario = new Usuario()
        {
            UserName = registrar.Usuario,
            Email = registrar.Email
        };

        var senha = registrar.Senha!;

        var resultado = await servicoAutenticacao
            .Registrar(usuario, senha, TipoUsuarioEnum.Empresa);

        if (resultado.IsSuccess)
            return RedirectToAction("Index", "Home");

        foreach (var erro in resultado.Errors)
            ModelState.AddModelError(string.Empty, erro.Message);

        return View(registrar);
    }

    public IActionResult Login(string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel login, string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        if (!ModelState.IsValid)
            return View(login);

        var resultado = await servicoAutenticacao.Login(login.Usuario!, login.Senha!);

        if (resultado.IsSuccess)
            return LocalRedirect(returnUrl ?? "/");

        var msgErro = resultado.Errors.First().Message;

        ModelState.AddModelError(string.Empty, msgErro);

        return View(login);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await servicoAutenticacao.Logout();

        return RedirectToAction(nameof(Login));
    }

    public IActionResult AcessoNegado()
    {
        return View();
    }
}