using ControleLocadoraAutomoveis.Dominio.ModuloPlanoDeCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloGrupoPlanoDeCobranca;

public class MapeadorPlanoDeCobranca : IEntityTypeConfiguration<PlanoDeCobranca>
{
	public void Configure(EntityTypeBuilder<PlanoDeCobranca> builder)
	{
		builder.ToTable("TBPlanoDeCobranca");

		builder.Property(p => p.Id)
			.HasColumnType("int")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(p => p.PrecoDiarioPlanoDiario)
			.HasColumnType("decimal(18,2)")
			.IsRequired();

		builder.Property(p => p.PrecoQuilometroPlanoDiario)
			.IsRequired()
			.HasColumnType("decimal(18,2)");

		builder.Property(p => p.QuilometrosDisponiveisPlanoControlado)
			.IsRequired()
			.HasColumnType("decimal(18,2)");

		builder.Property(p => p.PrecoDiarioPlanoControlado)
			.IsRequired()
			.HasColumnType("decimal(18,2)");

		builder.Property(p => p.PrecoQuilometroExtrapoldoPlanoControlado)
			.IsRequired()
			.HasColumnType("decimal(18,2)");

		builder.Property(p => p.PrecoDiarioPlanoLivre)
			.IsRequired()
			.HasColumnType("decimal(18,2)");

		builder.Property(p => p.IdGrupoAutomoveis)
			.IsRequired()
			.HasColumnType("int");

		builder.HasOne(p => p.GrupoAutomoveis)
			.WithMany()
			.HasForeignKey(p => p.IdGrupoAutomoveis)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(s => s.IdEmpresa)
			.HasColumnType("int")
			.HasColumnName("Id_Empresa")
			.IsRequired();

		builder.HasOne(g => g.Empresa)
			.WithMany()
			.HasForeignKey(s => s.IdEmpresa)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
