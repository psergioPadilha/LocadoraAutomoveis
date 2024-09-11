using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleLocadoraAutomoveis.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloLocacao;
public class MapeadorLocacao : IEntityTypeConfiguration<Locacao>
{
	public void Configure(EntityTypeBuilder<Locacao> builder)
	{
		builder.ToTable("TBLocacao");

		builder.Property(l => l.Id)
			.HasColumnType("int")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(l => l.TipoPlano)
			.HasColumnType("int")
			.IsRequired();

		builder.Property(l => l.MarcadorCombustivel)
			.HasColumnType("int")
			.IsRequired();

		builder.Property(l => l.QuilometragemPercorrida)
			.HasColumnType("int")
			.IsRequired();

		builder.Property(l => l.DataLocacao)
			.HasColumnType("datetime2")
			.IsRequired();

		builder.Property(l => l.DevolucaoPrevista)
			.HasColumnType("datetime2")
			.IsRequired();

		builder.Property(l => l.DataDevolucao)
			.HasColumnType("datetime2")
			.IsRequired(false);

		builder.Property(l => l.IdAutomovel)
			.HasColumnType("int")
			.IsRequired();

		builder.HasOne(l => l.Automovel)
			.WithMany()
			.HasForeignKey(l => l.IdAutomovel)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(l => l.IdCondutor)
			.HasColumnType("int")
			.IsRequired();

		builder.HasOne(l => l.Condutor)
			.WithMany()
			.HasForeignKey(l => l.IdCondutor)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(l => l.IdConfiguracaoCombustivel)
			.HasColumnType("int")
			.IsRequired();

		builder.HasOne(l => l.ConfiguracaoCombustivel)
			.WithMany()
			.HasForeignKey(l => l.IdConfiguracaoCombustivel)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(l => l.TaxasSelecionadas)
			.WithMany(t => t.Locacoes)
			.UsingEntity(j => j.ToTable("TBLocacaoTaxa"));

		builder.Property(s => s.IdEmpresa)
			.HasColumnType("int")
			.HasColumnName("Id_Empresa");

		builder.HasOne(g => g.Empresa)
			.WithMany()
			.HasForeignKey(s => s.IdEmpresa)
			.OnDelete(DeleteBehavior.NoAction);
	}
}