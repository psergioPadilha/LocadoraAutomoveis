using ControleLocadoraAutomoveis.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloCondutor;

public class MapeadorCondutor : IEntityTypeConfiguration<Condutor>
{
	public void Configure(EntityTypeBuilder<Condutor> builder)
	{
		builder.ToTable("TBCondutor");

		builder.Property(c => c.Id)
			.HasColumnType("int")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(c => c.Nome)
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(c => c.Email)
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(c => c.Telefone)
			.HasColumnType("varchar(20)")
			.IsRequired();

		builder.Property(c => c.CPF)
			.HasColumnType("varchar(20)")
			.IsRequired();

		builder.Property(c => c.CNH)
			.HasColumnType("varchar(20)")
			.IsRequired();

		builder.Property(c => c.ValidadeCNH)
			.HasColumnType("datetime2")
			.IsRequired();

		builder.Property(c => c.ClienteCondutor)
			.HasColumnType("bit")
			.IsRequired();

		builder.Property(c => c.IdCliente)
			.HasColumnType("int")
			.IsRequired();

		builder.HasOne(c => c.Cliente)
			.WithMany(col => col.Condutores)
			.HasForeignKey(c => c.IdCliente)
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