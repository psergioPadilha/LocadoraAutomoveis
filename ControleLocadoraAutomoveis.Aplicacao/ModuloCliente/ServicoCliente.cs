using ControleLocadoraAutomoveis.Dominio.ModuloCliente;
using FluentResults;

namespace ControleLocadoraAutomoveis.Aplicacao.ModuloCliente;

public class ServicoCliente
{
	private readonly IRepositorioCliente repositorioCliente;

	public ServicoCliente(IRepositorioCliente repositorioCliente)
	{
		this.repositorioCliente = repositorioCliente;
	}

	public Result<Cliente> Inserir(Cliente cliente)
	{
		var errosValidacao = cliente.Validar();

		if (errosValidacao.Count > 0)
			return Result.Fail(errosValidacao);

		repositorioCliente.Inserir(cliente);

		return Result.Ok(cliente);
	}

	public Result<Cliente> Editar(Cliente clienteAtualizado)
	{
		var cliente = repositorioCliente.SelecionarPorId(clienteAtualizado.Id);

		if (cliente is null)
			return Result.Fail("O \"CLIENTE\" não foi encontrado!");

		var errosValidacao = clienteAtualizado.Validar();

		if (errosValidacao.Count > 0)
			return Result.Fail(errosValidacao);

		cliente.Nome = clienteAtualizado.Nome;
		cliente.Email = clienteAtualizado.Email;
		cliente.Telefone = clienteAtualizado.Telefone;
		cliente.TipoCliente = clienteAtualizado.TipoCliente;
		cliente.NumeroEndereco = clienteAtualizado.NumeroEndereco;
		cliente.Estado = clienteAtualizado.Estado;
		cliente.Cidade = clienteAtualizado.Cidade;
		cliente.Bairro = clienteAtualizado.Bairro;
		cliente.Rua = clienteAtualizado.Rua;
		cliente.NumeroEndereco = clienteAtualizado.NumeroEndereco;

		repositorioCliente.Editar(cliente);

		return Result.Ok(cliente);
	}

	public Result<Cliente> Excluir(int idCliente)
	{
		var cliente = repositorioCliente.SelecionarPorId(idCliente);

		if (cliente is null)
			return Result.Fail("O \"CLIENTE\" não foi encontrado!");

		repositorioCliente.Excluir(cliente);

		return Result.Ok(cliente);
	}

	public Result<Cliente> SelecionarPorId(int idCliente)
	{
		var cliente = repositorioCliente.SelecionarPorId(idCliente);

		if (cliente is null)
			return Result.Fail("O \"CLIENTE\" não foi encontrado!");

		return Result.Ok(cliente);
	}

	public Result<List<Cliente>> SelecionarTodos(int idEmpresa)
    {
        var clientes = repositorioCliente.Filtrar(c => c.IdEmpresa == idEmpresa);

		return Result.Ok(clientes);
	}
}