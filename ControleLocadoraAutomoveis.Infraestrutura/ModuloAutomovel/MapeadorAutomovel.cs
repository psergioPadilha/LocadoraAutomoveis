using ControleLocadoraAutomoveis.Dominio.ModuloAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloAutomovel;

public class MapeadorAutomovel : IEntityTypeConfiguration<Automovel>
{
	public void Configure(EntityTypeBuilder<Automovel> builder)
	{
		builder.ToTable("TBAutomovel");

		builder.Property(a => a.Id)
			.HasColumnType("int")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(a => a.Marca)
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(a => a.Modelo)
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(a => a.TipoCcombustivel)
			.HasColumnType("int")
			.IsRequired();

		builder.Property(a => a.CapacidadeTanque)
			.HasColumnType("int")
			.IsRequired();

		builder.Property(a => a.Foto)
			.HasColumnType("varbinary(max)")
			.HasDefaultValue(Array.Empty<byte>());

		builder.Property(a => a.IdGrupoAutomoveis)
			.HasColumnType("int")
			.IsRequired();

		builder.HasOne(a => a.GrupoAutomoveis)
			.WithMany(g => g.Automoveis)
			.HasForeignKey(a => a.IdGrupoAutomoveis)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(e => e.IdEmpresa)
			.HasColumnType("int")
			.HasColumnName("Id_Empresa")
			.IsRequired();

		builder.HasOne(g => g.Empresa)
			.WithMany()
			.HasForeignKey(e => e.IdEmpresa)
			.OnDelete(DeleteBehavior.Restrict);
	}
}