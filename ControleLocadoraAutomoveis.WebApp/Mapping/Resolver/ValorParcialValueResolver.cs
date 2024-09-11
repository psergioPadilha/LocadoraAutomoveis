using AutoMapper;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutomovel;
using ControleLocadoraAutomoveis.Aplicacao.ModuloPlanosDeCobranca;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;

public class ValorParcialValueResolver : IValueResolver<Locacao, ConfirmarAberturaLocacaoViewModel, decimal>
{
    private readonly ServicoAutomovel servicoAutomovel;
    private readonly ServicoPlanoDeCobranca servicoPlanoDeCobranca;

    public ValorParcialValueResolver(ServicoAutomovel servicoAutomovel, ServicoPlanoDeCobranca servicoPlanoDeCobranca)
    {
        this.servicoAutomovel = servicoAutomovel;
        this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
    }

    public decimal Resolve(
        Locacao source,
        ConfirmarAberturaLocacaoViewModel destination,
        decimal destMember,
        ResolutionContext context
    )
    {
        var veiculo = servicoAutomovel.SelecionarPorId(source.IdAutomovel).Value;

        var planoSelecionado = servicoPlanoDeCobranca.SelecionarPorIdGrupoAutomoveis(veiculo.IdGrupoAutomoveis).Value;

        return source.CalcularValorParcial(planoSelecionado);
    }
}