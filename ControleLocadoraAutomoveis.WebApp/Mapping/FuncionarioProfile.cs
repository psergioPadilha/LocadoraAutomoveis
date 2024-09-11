using AutoMapper;
using ControleLocadoraAutomoveis.Dominio.ModuloFuncionario;
using ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;
using ControleLocadoraAutomoveis.WebApp.Models;

namespace ControleLocadoraAutomoveis.WebApp.Mapping;

public class FuncionarioProfile : Profile
{
    public FuncionarioProfile()
    {
        CreateMap<InserirFuncionarioViewModel, Funcionario>()
            .ForMember(dest => dest.IdEmpresa,
                opt =>
                    opt.MapFrom<IdEmpresaValueResolver>());

        CreateMap<Funcionario, ListarFuncionarioViewModel>();
    }
}