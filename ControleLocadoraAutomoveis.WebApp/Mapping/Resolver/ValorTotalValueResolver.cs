using AutoMapper;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutomovel;
using ControleLocadoraAutomoveis.Aplicacao.ModuloPlanosDeCobranca;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;

public class ValorTotalValueResolver : IValueResolver<Locacao, ConfirmarDevolucaoLocacaoViewModel, decimal>
{
    private readonly ServicoAutomovel servicoAutomovel;
    private readonly ServicoPlanoDeCobranca servicoDePlano;

    public ValorTotalValueResolver(ServicoAutomovel servicoAutomovel, ServicoPlanoDeCobranca servicoDePlano)
    {
        this.servicoAutomovel = servicoAutomovel;
        this.servicoDePlano = servicoDePlano;
    }

    public decimal Resolve(
        Locacao source,
        ConfirmarDevolucaoLocacaoViewModel destination,
        decimal destMember,
        ResolutionContext context
    )
    {
        var veiculo = servicoAutomovel.SelecionarPorId(source.IdAutomovel).Value;

        var planoSelecionado = servicoDePlano.SelecionarPorIdGrupoAutomoveis(veiculo.IdGrupoAutomoveis).Value;

        return source.CalcularValorTotal(planoSelecionado);
    }
}