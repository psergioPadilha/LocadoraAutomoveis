using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;
using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using ControleLocadoraAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;

public class TaxasValueResolver : IValueResolver<Locacao, FormularioLocacaoViewModel, IEnumerable<SelectListItem>?>
{
    private readonly IRepositorioTaxa repositorioTaxa;

    public TaxasValueResolver(IRepositorioTaxa repositorioTaxa)
    {
        this.repositorioTaxa = repositorioTaxa;
    }

    public IEnumerable<SelectListItem>? Resolve(Locacao source, FormularioLocacaoViewModel destination, IEnumerable<SelectListItem>? destMember,
        ResolutionContext context)
    {

        return repositorioTaxa
            .SelecionarTodos()
            .Select(t => new SelectListItem(t.ToString(), t.Id.ToString()));
    }
}