using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;
using ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping;

public class LocacaoProfile : Profile
{
    public LocacaoProfile()
    {
        CreateMap<InserirLocacaoViewModel, Locacao>()
            .ForMember(dest => dest.IdEmpresa, opt => opt.MapFrom<IdEmpresaValueResolver>())
            .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());

        CreateMap<RealizarDevolucaoViewModel, Locacao>()
            .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());

        CreateMap<Locacao, ListarLocacaoViewModel>()
            .ForMember(l => l.Veiculo, opt => opt.MapFrom(src => src.Automovel!.Modelo))
            .ForMember(l => l.Condutor, opt => opt.MapFrom(src => src.Condutor!.Nome))
            .ForMember(l => l.TipoPlano, opt => opt.MapFrom(src => src.TipoPlano.ToString()));

        CreateMap<Locacao, RealizarDevolucaoViewModel>()
            .ForMember(l => l.Condutores, opt => opt.MapFrom<CondutoresValueResolver>())
            .ForMember(l => l.Automoveis, opt => opt.MapFrom<AutomoveisValueResolver>())
            .ForMember(l => l.Taxas, opt => opt.MapFrom<TaxasValueResolver>())
            .ForMember(l => l.TaxasSelecionadas,
                opt => opt.MapFrom(src => src.TaxasSelecionadas.Select(tx => tx.Id)));

        // Check-in
        CreateMap<Locacao, ConfirmarAberturaLocacaoViewModel>()
            .ForMember(l => l.ValorParcial, opt => opt.MapFrom<ValorParcialValueResolver>())
            .ForMember(l => l.Condutores, opt => opt.MapFrom<CondutoresValueResolver>())
            .ForMember(l => l.Automoveis, opt => opt.MapFrom<AutomoveisValueResolver>())
            .ForMember(l => l.Taxas, opt => opt.MapFrom<TaxasValueResolver>())
            .ForMember(l => l.TaxasSelecionadas,
                opt => opt.MapFrom(src => src.TaxasSelecionadas.Select(tx => tx.Id)));

        CreateMap<ConfirmarAberturaLocacaoViewModel, Locacao>()
            .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());

        // Check-out
        CreateMap<Locacao, ConfirmarDevolucaoLocacaoViewModel>()
            .ForMember(vm => vm.ValorTotal, opt => opt.MapFrom<ValorTotalValueResolver>())
            .ForMember(l => l.Condutores, opt => opt.MapFrom<CondutoresValueResolver>())
            .ForMember(l => l.Automoveis, opt => opt.MapFrom<AutomoveisValueResolver>())
            .ForMember(l => l.Taxas, opt => opt.MapFrom<TaxasValueResolver>())
            .ForMember(l => l.TaxasSelecionadas,
                opt => opt.MapFrom(src => src.TaxasSelecionadas.Select(tx => tx.Id)));

        CreateMap<ConfirmarDevolucaoLocacaoViewModel, Locacao>()
            .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());
    }
}