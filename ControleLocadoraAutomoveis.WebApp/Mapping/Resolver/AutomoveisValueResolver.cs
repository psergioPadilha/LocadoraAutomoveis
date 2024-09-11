using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using AutoMapper.Execution;
using AutoMapper.Internal;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutomovel;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;

public class AutomoveisValueResolver : IValueResolver<Locacao, FormularioLocacaoViewModel, IEnumerable<SelectListItem>?>
{
    private readonly ServicoAutomovel _servicoAutomovel;

    public AutomoveisValueResolver(ServicoAutomovel servicoAutomovel)
    {
        _servicoAutomovel = servicoAutomovel;
    }

    public IEnumerable<SelectListItem>? Resolve(Locacao source, FormularioLocacaoViewModel destination, IEnumerable<SelectListItem>? destMember,
        ResolutionContext context)
    {
        if (destination is RealizarDevolucaoViewModel or ConfirmarAberturaLocacaoViewModel or ConfirmarDevolucaoLocacaoViewModel)
        {
            var automovelSelecionado = _servicoAutomovel.SelecionarPorId(source.IdAutomovel).Value;

            return [new SelectListItem(automovelSelecionado!.Modelo, automovelSelecionado.Id.ToString())];
        }

        return _servicoAutomovel
            .SelecionarTodos(source.IdEmpresa)
            .Value
            .Select(v => new SelectListItem(v.Modelo, v.Id.ToString()));
    }
}