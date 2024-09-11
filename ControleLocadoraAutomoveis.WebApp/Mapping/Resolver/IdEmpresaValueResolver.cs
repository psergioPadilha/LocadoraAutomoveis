using System.Security.Authentication;
using AutoMapper;
using AutoMapper.Execution;
using ControleLocadoraAutomoveis.Aplicacao.ModuloAutenticacao;
using Microsoft.AspNetCore.Http.Features;

namespace ControleLocadoraAutomoveis.WebApp.Mapping.Resolver;

public class IdEmpresaValueResolver : IValueResolver<object, object, int>
{
	private readonly ServicoAutenticacao servicoAutenticacao;
	private readonly IHttpContextAccessor httpContextAccessor;

	public IdEmpresaValueResolver(ServicoAutenticacao servicoAutenticacao, IHttpContextAccessor httpContextAccessor)
	{
		this.servicoAutenticacao = servicoAutenticacao;
		this.httpContextAccessor = httpContextAccessor;
	}

	public int Resolve(object source, object destination, int destMember, ResolutionContext context)
	{
		var usuarioClaim = httpContextAccessor.HttpContext?.User;

		var idEmpresa = servicoAutenticacao.ObterIdEmpresaAsync(usuarioClaim!).Result;

		if (idEmpresa is null)
			throw new AuthenticationException("Não foi possível obter o ID da empresa requisitada!");

		return idEmpresa.Value;
	}
}