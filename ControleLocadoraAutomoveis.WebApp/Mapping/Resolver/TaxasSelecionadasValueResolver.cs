using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;
using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;

public class TaxasSelecionadasValueResolver : IValueResolver<FormularioLocacaoViewModel, Locacao, List<Taxa>>
{
    private readonly IRepositorioTaxa repositorioTaxa;

    public TaxasSelecionadasValueResolver(IRepositorioTaxa repositorioTaxa)
    {
        this.repositorioTaxa = repositorioTaxa;
    }

    public List<Taxa> Resolve(
        FormularioLocacaoViewModel source,
        Locacao destination,
        List<Taxa> destMember,
        ResolutionContext context
    )
    {
        var idsTaxasSelecionadas = source.TaxasSelecionadas.ToList();

        return repositorioTaxa.SelecionarMuitos(idsTaxasSelecionadas);
    }
}