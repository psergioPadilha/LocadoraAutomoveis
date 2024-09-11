using ControleLocadoraAutomoveis.Dominio.ModuloPlanoDeCobranca;
using FluentResults;

namespace ControleLocadoraAutomoveis.Aplicacao.ModuloPlanosDeCobranca;

public class ServicoPlanoDeCobranca
{
    private readonly IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;

    public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca)
    {
        this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
    }

    public Result<PlanoDeCobranca> Inserir(PlanoDeCobranca planoDeCobranca)
    {
        repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

        return Result.Ok(planoDeCobranca);
    }

    public Result<PlanoDeCobranca> Editar(PlanoDeCobranca planoCobrancaAtualizado)
    {
        var planoCobranca = repositorioPlanoDeCobranca.SelecionarPorId(planoCobrancaAtualizado.Id);

        if (planoCobranca is null)
            return Result.Fail("O \"PLANO DE COBRANÇA\" não foi encontrado!");

        planoCobranca.IdGrupoAutomoveis = planoCobrancaAtualizado.IdGrupoAutomoveis;
        planoCobranca.PrecoDiarioPlanoDiario = planoCobrancaAtualizado.PrecoDiarioPlanoDiario;
        planoCobranca.PrecoQuilometroPlanoDiario = planoCobrancaAtualizado.PrecoQuilometroPlanoDiario;
        planoCobranca.QuilometrosDisponiveisPlanoControlado = planoCobrancaAtualizado.QuilometrosDisponiveisPlanoControlado;
        planoCobranca.PrecoDiarioPlanoControlado = planoCobrancaAtualizado.PrecoDiarioPlanoControlado;
        planoCobranca.PrecoQuilometroExtrapoldoPlanoControlado = planoCobrancaAtualizado.PrecoQuilometroExtrapoldoPlanoControlado;
        planoCobranca.PrecoDiarioPlanoLivre = planoCobrancaAtualizado.PrecoDiarioPlanoLivre;

        repositorioPlanoDeCobranca.Editar(planoCobranca);

        return Result.Ok(planoCobranca);
    }

    public Result<PlanoDeCobranca> Excluir(int planoCobrancaId)
    {
        var planoCobranca = repositorioPlanoDeCobranca.SelecionarPorId(planoCobrancaId);

        if (planoCobranca is null)
            return Result.Fail("O \"PLANO DE COBRANÇA\" não foi encontrado!");

        repositorioPlanoDeCobranca.Excluir(planoCobranca);

        return Result.Ok(planoCobranca);
    }

    public Result<PlanoDeCobranca> SelecionarPorId(int planoCobrancaId)
    {
        var planoCobranca = repositorioPlanoDeCobranca.SelecionarPorId(planoCobrancaId);

        if (planoCobranca is null)
            return Result.Fail("O \"PLANO DE COBRANÇA\" não foi encontrado!");

        return Result.Ok(planoCobranca);
    }

    public Result<List<PlanoDeCobranca>> SelecionarTodos(int empresaId)
    {
        var planosCobranca = repositorioPlanoDeCobranca.Filtrar(l => l.IdEmpresa == empresaId);

        return Result.Ok(planosCobranca);
    }

    public Result<PlanoDeCobranca> SelecionarPorIdGrupoAutomoveis(int grupoVeiculosId)
    {
        var plano = repositorioPlanoDeCobranca.FiltrarPlano(p => p.IdGrupoAutomoveis == grupoVeiculosId);

        if (plano is null)
            return Result.Fail("O \"PLANO DE COBRANÇA\" não foi encontrado!");

        return Result.Ok(plano);
    }
}
