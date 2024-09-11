using ControleLocadoraAutomoveis.Dominio.ModuloAutenticacao;
using ControleLocadoraAutomoveis.Dominio.ModuloFuncionario;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace ControleLocadoraAutomoveis.Aplicacao.ModuloFuncionario;

public class ServicoFuncionario
{
	private readonly IRepositorioFuncionario repositorioFuncionario;
	private readonly UserManager<Usuario> userManager;
	private readonly RoleManager<Perfil> roleManager;

	public ServicoFuncionario
	(
		IRepositorioFuncionario repositorioFuncionario,
		UserManager<Usuario> userManager,
		RoleManager<Perfil> roleManager)
	{
		this.repositorioFuncionario = repositorioFuncionario;
		this.userManager = userManager;
		this.roleManager = roleManager;
	}

	public async Task<Result<Funcionario>> Inserir(Funcionario funcionario, string nomeUusario, string senha)
	{
		var usuario = new Usuario()
		{
			UserName = nomeUusario,
			Email = funcionario.Email
		};

		var resultadoCriacaoUsuario = await userManager.CreateAsync(usuario, senha);

		if (!resultadoCriacaoUsuario.Succeeded)
			return Result.Fail(resultadoCriacaoUsuario.Errors.Select(e => e.Description));

		var perfilStr = TipoUsuarioEnum.Funcionario.ToString();

		var resultadoBuscaPerfil = await roleManager.FindByNameAsync(perfilStr);

		if (resultadoBuscaPerfil is null)
		{
			var perfil = new Perfil()
			{
				Name = perfilStr,
				NormalizedName = perfilStr.ToUpperInvariant(),
				ConcurrencyStamp = Guid.NewGuid().ToString()
			};

			await roleManager.CreateAsync(perfil);
		}

		await userManager.AddToRoleAsync(usuario, perfilStr);

		funcionario.IdUsuario = usuario.Id;

		repositorioFuncionario.Inserir(funcionario);

		return Result.Ok(funcionario);
	}

	public Result<Funcionario> Editar(Funcionario funcionario)
	{
		var erros = funcionario.Validar();

		if (erros.Count > 0)
			return Result.Fail(erros);

		repositorioFuncionario.Editar(funcionario);

		return Result.Ok(funcionario);
	}

	public async Task<Result> Excluir(int idFuncionario)
	{
		var funcionario = repositorioFuncionario.SelecionarPorId(f => f.Id == idFuncionario);

		if (funcionario is null)
			return Result.Fail("O \"FUNCIONÁRIO\" não foi encontrado!");

		var usuario = await userManager.FindByIdAsync(funcionario.IdUsuario.ToString());

		if (usuario is null)
			return Result.Fail("O \"FUNCIONÁRIO\" não foi encontrado!");

		var resultadoExclusao = await userManager.DeleteAsync(usuario);

		if (!resultadoExclusao.Succeeded)
			return Result.Fail("Não foi possível excluir o \"FUNCIONÁRIO\"!");

		repositorioFuncionario.Excluir(funcionario);

		return Result.Ok();
	}

	public Result<Funcionario?> SelecionarPorId(int idFuncionario)
	{
		var funcionario = repositorioFuncionario.SelecionarPorId(f => f.Id == idFuncionario);

		return Result.Ok(funcionario);
	}

	public Result<List<Funcionario>> SelecionarFuncionariosDaEmpresa(int idEmpresa)
	{
		var funcionarios = repositorioFuncionario.SelecionarTodos(f => f.IdEmpresa == idEmpresa);

		return Result.Ok(funcionarios);
	}
}