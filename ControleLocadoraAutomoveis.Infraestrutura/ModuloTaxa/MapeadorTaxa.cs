using ControleLocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloTaxa;

public class MapeadorTaxa : IEntityTypeConfiguration<Taxa>
{
	public void Configure(EntityTypeBuilder<Taxa> builder)
	{
		builder.ToTable("TBTaxa");

		builder.Property(t => t.Id)
			.HasColumnType("int")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(t => t.Descricao)
			.HasColumnType("varchar(200)")
			.IsRequired();

		builder.Property(t => t.Valor)
			.HasColumnType("decimal(18,2)")
			.IsRequired();

		builder.Property(t => t.TipoCobranca)
			.HasColumnType("int")
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