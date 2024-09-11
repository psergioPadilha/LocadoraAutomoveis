using ControleLocadoraAutomoveis.Dominio.ModuloCombustivel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloCombustivel;

public class MapeadorConfiguracaoCombustivel : IEntityTypeConfiguration<ConfiguracaoCombustivel>
{
	public void Configure(EntityTypeBuilder<ConfiguracaoCombustivel> builder)
	{
		builder.ToTable("TBConfiguracaoCombustivel");

		builder.Property(c => c.DataCriacao)
			.HasColumnType("datetime2")
			.IsRequired();

		builder.Property(c => c.ValorGasolina)
			.HasColumnType("decimal(18,2)")
			.IsRequired();

		builder.Property(c => c.ValorGas)
			.HasColumnType("decimal(18,2)")
			.IsRequired();

		builder.Property(c => c.ValorDiesel)
			.HasColumnType("decimal(18,2)")
			.IsRequired();

		builder.Property(c => c.ValorAlcool)
			.HasColumnType("decimal(18,2)")
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