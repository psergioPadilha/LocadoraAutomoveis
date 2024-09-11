using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloGrupoAutomoveis;
public class MapeadorGrupoAutomoveis : IEntityTypeConfiguration<GrupoAutomoveis>
{
	public void Configure(EntityTypeBuilder<GrupoAutomoveis> builder)
	{
		builder.ToTable("TBGrupoAutomoveis");

		builder.Property(g => g.Id)
			.HasColumnType("int")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(g => g.Descricao)
			.HasColumnType("varchar(150)")
			.IsRequired();

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
